Imports System.Collections.Generic
Imports System.ComponentModel

Friend Class ControlDesigner

#Region " Declarations "
    Public mouseLocation As New Point

    Private Const HANDLESIZE As Integer = 8
    Private Const MINSIZE As Integer = 5

    Private intSnapMargin As Integer = 0
    Private frmCurrent As Form = Nothing
    Private frmBackColor As Color = Nothing
    Private ctlCurrent As Control = Nothing
    Private lblHandle(7) As Label
    Private start_Left As Integer
    Private start_Top As Integer
    Private start_Width As Integer
    Private start_Height As Integer
    Private start_X As Integer
    Private start_Y As Integer
    Private bolDragging As Boolean
    Private lstControls As List(Of ControlWrapper) = Nothing
    Private lstExceptCtls As List(Of Control) = Nothing
    Private lstSelectedControls As List(Of Control) = Nothing
    Private arrArrow() As Cursor = New Cursor() {Cursors.SizeNWSE, _
                                                 Cursors.SizeNS, _
                                                 Cursors.SizeNESW, _
                                                 Cursors.SizeWE, _
                                                 Cursors.SizeNWSE, _
                                                 Cursors.SizeNS, _
                                                 Cursors.SizeNESW, _
                                                 Cursors.SizeWE}

#End Region

#Region " Public interface "
    Public Sub New(ByRef Form As Form, ByVal ExceptControls As List(Of Control), ByVal EditColor As Color, Optional ByVal SnapMargin As Integer = 8)
        'Creating this class with the parameters above starts the design mode for the passed form

        'Set snap width (used on mouse dragging with Ctrl key down)
        intSnapMargin = SnapMargin

        'Get the form to activate designer in and save some settings to be replaced while in design mode
        frmCurrent = Form
        frmBackColor = frmCurrent.BackColor

        'Create control collections
        lstExceptCtls = ExceptControls              'contains the controls excepted from design
        lstControls = New List(Of ControlWrapper)   'contains wrappers for the controls allowed to design
        lstSelectedControls = New List(Of Control)  'will contain the selected controls at any one time

        'Create sizing handles displayed around selected control(s)
        For i As Integer = 0 To 7
            lblHandle(i) = New Label

            With lblHandle(i)
                .TabIndex = i
                .FlatStyle = 0
                .BorderStyle = BorderStyle.FixedSingle
                .BackColor = Color.White
                .Cursor = arrArrow(i)
                .Text = ""
                .Visible = False
            End With

            AddHandler frmCurrent.Click, AddressOf Me.Parent_Click
            AddHandler lblHandle(i).MouseDown, AddressOf Me.Handle_MouseDown
            AddHandler lblHandle(i).MouseMove, AddressOf Me.Handle_MouseMove
            AddHandler lblHandle(i).MouseUp, AddressOf Me.Handle_MouseUp
        Next

        'Add allowed controls of the passed form to the control wrapper collection
        AddControls(frmCurrent)

        'Replace context menu and backcolor of the passed form
        frmCurrent.BackColor = EditColor
    End Sub

    Public Sub Dispose()
        'Call this method to terminate design mode of the passed form

        'Release all controls allowed for design
        For Each ctl As ControlWrapper In lstControls
            'Remove event handlers appended by this class
            RemoveHandler ctl.Control.MouseDown, AddressOf Me.Control_MouseDown
            RemoveHandler ctl.Control.MouseMove, AddressOf Me.Control_MouseMove
            RemoveHandler ctl.Control.MouseUp, AddressOf Me.Control_MouseUp
            RemoveHandler ctl.Control.PreviewKeyDown, AddressOf Me.Control_KeyDown
            RemoveHandler ctl.Control.Click, AddressOf SelectControl

            If ctl.GetType.ToString = "System.Windows.Forms.TextBox" Then
                RemoveHandler CType(ctl.Control, System.Windows.Forms.TextBox).MultilineChanged, AddressOf UpdateHandles
            End If

            If Not ctl.Control.Parent.Equals(frmCurrent) Then
                RemoveHandler ctl.Control.Parent.Click, AddressOf Me.Parent_Click
            End If

            'Reset replaced control settings with original values
            ctl.Control.Cursor = ctl.Cursor
            ctl.Control.ContextMenuStrip = ctl.ContextMenuStrip
        Next

        'Clear all collections
        lstControls.Clear()
        lstExceptCtls.Clear()
        lstSelectedControls.Clear()

        'Remove sizing handles
        For i As Integer = 0 To 7
            RemoveHandler lblHandle(i).MouseDown, AddressOf Me.Handle_MouseDown
            RemoveHandler lblHandle(i).MouseMove, AddressOf Me.Handle_MouseMove
            RemoveHandler lblHandle(i).MouseUp, AddressOf Me.Handle_MouseUp

            If lblHandle(i).Parent IsNot Nothing Then
                lblHandle(i).Parent.Controls.Remove(lblHandle(i))
            End If
        Next

        'Reset replaced from settings with original values
        RemoveHandler frmCurrent.Click, AddressOf Me.Parent_Click
        frmCurrent.BackColor = frmBackColor

        'Release objects of this class
        lstControls = Nothing
        lstExceptCtls = Nothing
        lstSelectedControls = Nothing
    End Sub
#End Region

#Region " Sizing handle events "
    Private Sub Handle_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        'Starts the drag mode for a sizing handle
        bolDragging = True

        start_Left = e.X
        start_Top = e.Y

        HideHandles()
    End Sub

    Private Sub Handle_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
        'Performs dragging of a sizing handle
        If bolDragging Then
            Dim DiffWidth As Integer = (e.X - start_Left)
            Dim DiffHeight As Integer = (e.Y - start_Top)

            start_Left = e.X
            start_Top = e.Y

            For Each ctl As Control In lstSelectedControls
                With ctl
                    Select Case (CType(sender, Label)).TabIndex
                        Case 0 ' bolDragging top-left sizing box
                            .SetBounds(IIf(.Bounds.Left + DiffWidth < 0, 0, .Bounds.Left + DiffWidth), IIf(.Bounds.Top + DiffHeight < 0, 0, .Bounds.Top + DiffHeight), IIf(.Bounds.Width - DiffWidth < MINSIZE, MINSIZE, .Bounds.Width - DiffWidth), IIf(.Bounds.Height - DiffHeight < MINSIZE, MINSIZE, .Bounds.Height - DiffHeight))
                        Case 1 ' bolDragging top-center sizing box
                            .SetBounds(.Bounds.Left, IIf(.Bounds.Top + DiffHeight < 0, 0, .Bounds.Top + DiffHeight), .Bounds.Width, IIf(.Bounds.Height - DiffHeight < MINSIZE, MINSIZE, .Bounds.Height - DiffHeight))
                        Case 2 ' bolDragging top-right sizing box
                            .SetBounds(.Bounds.Left, IIf(.Bounds.Top + DiffHeight < 0, 0, .Bounds.Top + DiffHeight), IIf(.Bounds.Width + DiffWidth < MINSIZE, MINSIZE, .Bounds.Width + DiffWidth), IIf(.Bounds.Height - DiffHeight < MINSIZE, MINSIZE, .Bounds.Height - DiffHeight))
                        Case 3 ' bolDragging right-middle sizing box
                            .SetBounds(.Bounds.Left, .Bounds.Top, IIf(.Bounds.Width + DiffWidth < MINSIZE, MINSIZE, .Bounds.Width + DiffWidth), .Bounds.Height)
                        Case 4 ' bolDragging right-bottom sizing box
                            .SetBounds(.Bounds.Left, .Bounds.Top, IIf(.Bounds.Width + DiffWidth < MINSIZE, MINSIZE, .Bounds.Width + DiffWidth), IIf(.Bounds.Height + DiffHeight < MINSIZE, MINSIZE, .Bounds.Height + DiffHeight))
                        Case 5 ' bolDragging center-bottom sizing box
                            .SetBounds(.Bounds.Left, .Bounds.Top, .Bounds.Width, IIf(.Bounds.Height + DiffHeight < MINSIZE, MINSIZE, .Bounds.Height + DiffHeight))
                        Case 6 ' bolDragging left-bottom sizing box
                            .SetBounds(IIf(.Bounds.Left + DiffWidth < 0, 0, .Bounds.Left + DiffWidth), .Bounds.Top, IIf(.Bounds.Width - DiffWidth < MINSIZE, MINSIZE, .Bounds.Width - DiffWidth), IIf(.Bounds.Height + DiffHeight < MINSIZE, MINSIZE, .Bounds.Height + DiffHeight))
                        Case 7 ' bolDragging left-middle sizing box
                            .SetBounds(IIf(.Bounds.Left + DiffWidth < 0, 0, .Bounds.Left + DiffWidth), .Bounds.Top, IIf(.Bounds.Width - DiffWidth < MINSIZE, MINSIZE, .Bounds.Width - DiffWidth), .Bounds.Height)
                    End Select
                End With
            Next
        End If
    End Sub

    Private Sub Handle_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs)
        'Ends the drag mode for a sizing handle
        bolDragging = False

        UpdateHandles(ctlCurrent, New EventArgs)
    End Sub
#End Region

#Region " Control events "
    Private Sub SelectControl(ByVal sender As Object, ByVal e As EventArgs)
        'Manages single or multiple control selection on left mouse click
      
        Try
            'Check shift state and new selection
            If (Not My.Computer.Keyboard.ShiftKeyDown) AndAlso (Not lstSelectedControls.Contains(sender)) Then
                'Single selection mode - remove all selected controls if shift is not down
                lstSelectedControls.Clear()

                If ctlCurrent IsNot Nothing Then
                    'Restore standard cursor for deselected control
                    ctlCurrent.Cursor = Cursors.Arrow
                    ctlCurrent = Nothing
                End If
            End If

            'Get currently selected control
            ctlCurrent = CType(sender, Control)

            If TypeOf ctlCurrent Is Control Then
                'On propertygrids don't allow to select a sub-control
                If ctlCurrent.Parent.GetType.ToString = "System.Windows.Forms.PropertyGrid" Then
                    ctlCurrent = ctlCurrent.Parent
                End If

                'Add selected control to collection of selected controls if not already contained
                If Not lstSelectedControls.Contains(ctlCurrent) Then
                    Dim bolOK As Boolean = True

                    If lstSelectedControls.Count > 0 Then
                        bolOK = lstSelectedControls.Item(0).Parent.Equals(ctlCurrent.Parent)
                    End If

                    If bolOK Then
                        lstSelectedControls.Add(ctlCurrent)

                        'Assign sizing handles to control's container (or form on multiple selection)
                        For i As Integer = 0 To 7
                            lblHandle(i).Parent = ctlCurrent.Parent
                            lblHandle(i).BringToFront()
                        Next

                        'Reposition an show sizing handles
                        UpdateHandles(ctlCurrent, New EventArgs)

                        'Set cursor
                        ctlCurrent.Cursor = Cursors.SizeAll
                    Else
                        MsgBox("Please select only controls within the same container", MsgBoxStyle.OkOnly Or MsgBoxStyle.Exclamation, "Multiple selection")

                        ctlCurrent = lstSelectedControls.Item(lstSelectedControls.Count - 1)
                    End If
                End If
            End If

            
        Catch
        End Try
    End Sub

    Private Sub SelectControl(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        'Manages single or multiple control selection on right mouse click
        If e.Button = MouseButtons.Right Then
            Try
                'Check shift state and new selection
                If (Not My.Computer.Keyboard.ShiftKeyDown) AndAlso (Not lstSelectedControls.Contains(sender)) Then
                    'Single selection mode - remove all selected controls if shift is not down
                    lstSelectedControls.Clear()

                    If ctlCurrent IsNot Nothing Then
                        'Restore standard cursor for deselected control
                        ctlCurrent.Cursor = Cursors.Arrow
                        ctlCurrent = Nothing
                    End If
                End If

                'Get currently selected control
                ctlCurrent = CType(sender, Control)

                If TypeOf ctlCurrent Is Control Then
                    'On propertygrids don't allow to select a sub-control
                    If ctlCurrent.Parent.GetType.ToString = "System.Windows.Forms.PropertyGrid" Then
                        ctlCurrent = ctlCurrent.Parent
                    End If

                    'Add selected control to collection of selected controls if not already contained
                    If Not lstSelectedControls.Contains(ctlCurrent) Then
                        Dim bolOK As Boolean = True

                        If lstSelectedControls.Count > 0 Then
                            bolOK = lstSelectedControls.Item(0).Parent.Equals(ctlCurrent.Parent)
                        End If

                        If bolOK Then
                            lstSelectedControls.Add(ctlCurrent)

                            'Assign sizing handles to control's container (or form on multiple selection)
                            For i As Integer = 0 To 7
                                lblHandle(i).Parent = ctlCurrent.Parent
                                lblHandle(i).BringToFront()
                            Next

                            'Reposition an show sizing handles
                            UpdateHandles(ctlCurrent, New EventArgs)

                            'Set cursor
                            ctlCurrent.Cursor = Cursors.SizeAll
                        Else
                            MsgBox("Please select only controls within the same container", MsgBoxStyle.OkOnly Or MsgBoxStyle.Exclamation, "Multiple selection")

                            ctlCurrent = lstSelectedControls.Item(lstSelectedControls.Count - 1)
                        End If
                    End If
                End If
            Catch
            End Try
        End If
    End Sub

    Private Sub Control_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        'Starts the drag mode for all selected controls

        'If neccessary, select control first
        If (ctlCurrent Is Nothing) Or ((ctlCurrent IsNot Nothing) AndAlso (Not ctlCurrent.Equals(sender))) Then
            SelectControl(sender, New EventArgs)
        End If

        'If not selection denied
        If sender.Equals(ctlCurrent) Then
            'Start dragging
            bolDragging = True

            start_X = e.X
            start_Y = e.Y

            HideHandles()
        End If
    End Sub

    Private Sub Control_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
        'Performs dragging of all selected controls
        If bolDragging Then
            For Each ctl As Control In lstSelectedControls
                ctl.Location = New Point(ctl.Location.X + e.X - start_X, ctl.Location.Y + e.Y - start_Y)
                frmCurrent.Refresh()
            Next
        End If
    End Sub

    Private Sub Control_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs)
        'Ends the drag mode for all selected controls
        bolDragging = False

        'Check if Ctrl key down
        If My.Computer.Keyboard.CtrlKeyDown Then
            'Snap all selected controls to next grid point
            For Each ctl As Control In lstSelectedControls
                'Calculate left and top of final position
                Dim l As Integer = ctl.Location.X + e.X - start_X
                Dim t As Integer = ctl.Location.Y + e.Y - start_Y

                '1) Horizontal snap
                'Calculate distance to right border of control container
                Dim intDist As Integer = Math.Abs(ctl.Parent.DisplayRectangle.Right - (l + ctl.Width))

                'If distance is less than snap margin
                If (intDist < intSnapMargin) Then
                    'Snap control to right border of container
                    l = (ctl.Parent.DisplayRectangle.Right - ctl.Width)
                Else
                    'If distance to left border of container is less than snap margin
                    If Math.Abs(l) < intSnapMargin Then
                        'Snap control to left border of container
                        l = 0
                    Else
                        'Otherwise snap control to next imaginery vertical snap line
                        l = Math.Round(ctl.Left / intSnapMargin) * intSnapMargin
                    End If
                End If

                '2) Vertical snap
                'Calculate distance to bottom border of control container
                intDist = Math.Abs(ctl.Parent.DisplayRectangle.Bottom - (t + ctl.Height))

                'If distance is less than snap margin
                If (intDist < intSnapMargin) Then
                    'Snap control to bottom border of container
                    t = (ctl.Parent.DisplayRectangle.Bottom - ctl.Height)
                Else
                    'If distance to top border of container is less than snap margin
                    If Math.Abs(t) < intSnapMargin Then
                        'Snap control to top border of container
                        t = 0
                    Else
                        'Otherwise snap control to next imaginery horizontal snap line
                        t = Math.Round(ctl.Top / intSnapMargin) * intSnapMargin
                    End If
                End If

                'Set control location to snap point
                ctl.Location = New Point(l, t)
            Next
        End If

        'Reposition and show sizing handles
        UpdateHandles(ctlCurrent, New EventArgs)
    End Sub

    Private Sub Control_KeyDown(ByVal sender As Object, ByVal e As PreviewKeyDownEventArgs)
        'Move/size selected control(s) bei arrow keys

        'If one or more controls selected
        If lstSelectedControls.Count > 0 Then
            Select Case e.KeyCode
                Case Keys.Left
                    'If shift key down
                    If e.Shift Then
                        'Decrease width of all selected controls by 1 unit
                        For Each ctl As Control In lstSelectedControls
                            With ctl
                                .Size = New Size(.Size.Width - 1, .Size.Height)
                            End With
                        Next
                    Else
                        'Otherwise move all selected controls 1 unit to the left
                        For Each ctl As Control In lstSelectedControls
                            With ctl
                                .Location = New Point(.Location.X - 1, .Location.Y)
                            End With
                        Next
                    End If

                    RepositionHandles()
                Case Keys.Right
                    'If shift key down
                    If e.Shift Then
                        'Increase width of all selected controls by 1 unit
                        For Each ctl As Control In lstSelectedControls
                            With ctl
                                .Size = New Size(.Size.Width + 1, .Size.Height)
                            End With
                        Next
                    Else
                        'Otherwise move all selected controls 1 unit to the right
                        For Each ctl As Control In lstSelectedControls
                            With ctl
                                .Location = New Point(.Location.X + 1, .Location.Y)
                            End With
                        Next
                    End If

                    RepositionHandles()
                Case Keys.Up
                    'If shift key down
                    If e.Shift Then
                        'Decrease height of all selected controls by 1 unit
                        For Each ctl As Control In lstSelectedControls
                            With ctl
                                .Size = New Size(.Size.Width, .Size.Height - 1)
                            End With
                        Next
                    Else
                        'Otherwise move all selected controls 1 unit up
                        For Each ctl As Control In lstSelectedControls
                            With ctl
                                .Location = New Point(.Location.X, .Location.Y - 1)
                            End With
                        Next
                    End If

                    RepositionHandles()
                Case Keys.Down
                    'If shift key down
                    If e.Shift Then
                        'Increase height of all selected controls by 1 unit
                        For Each ctl As Control In lstSelectedControls
                            With ctl
                                .Size = New Size(.Size.Width, .Size.Height + 1)
                            End With
                        Next
                    Else
                        'Otherwise move all selected controls 1 unit down
                        For Each ctl As Control In lstSelectedControls
                            With ctl
                                .Location = New Point(.Location.X, .Location.Y + 1)
                            End With
                        Next
                    End If

                    RepositionHandles()
            End Select
        End If
    End Sub
#End Region

#Region " Handle methods "
    Private Sub UpdateHandles(ByVal sender As Object, ByVal e As EventArgs)
        'Position sizing handles around selected control(s)
        RepositionHandles()

        'Display sizing handles
        ShowHandles()
    End Sub

    Private Sub ShowHandles()
        'Displays the sizing handles depending on selected control(s)
        If lstSelectedControls.Count > 1 Then
            'Multiple selection - show all sizing handles
            For i As Integer = 0 To 7
                lblHandle(i).Visible = True
                lblHandle(i).BringToFront()
            Next
        Else
            'Single selection - if control selected
            If ctlCurrent IsNot Nothing Then
                'Check control type
                Select Case ctlCurrent.GetType.ToString
                    Case "System.Windows.Forms.TextBox"
                        Dim tempText As TextBox = ctlCurrent

                        If tempText.Multiline = True Then
                            'Multi-line text box - show all sizing handles
                            For i As Integer = 0 To 7
                                lblHandle(i).Visible = True
                                lblHandle(i).BringToFront()
                            Next
                        Else
                            'Single line text box - show horizontal sizing handles only
                            For i As Integer = 0 To 7
                                Select Case i
                                    Case 3, 7
                                        lblHandle(i).Visible = True
                                        lblHandle(i).BringToFront()
                                    Case Else
                                        lblHandle(i).Visible = False
                                End Select
                            Next
                        End If
                    Case "System.Windows.Forms.DateTimePicker"
                        'Show only horizontal sizing handles
                        For i As Integer = 0 To 7
                            Select Case i
                                Case 3, 7
                                    lblHandle(i).Visible = True
                                    lblHandle(i).BringToFront()
                                Case Else
                                    lblHandle(i).Visible = False
                            End Select
                        Next
                    Case "System.Windows.Forms.ComboBox"
                        Dim tempCombo As ComboBox = ctlCurrent

                        If tempCombo.DropDownStyle = ComboBoxStyle.Simple = True Then
                            'Static dropped down combobox - show all sizing handles
                            For i As Integer = 0 To 7
                                lblHandle(i).Visible = True
                                lblHandle(i).BringToFront()
                            Next
                        Else
                            'Single line combo box - show horizontal sizing handles only
                            For i As Integer = 0 To 7
                                Select Case i
                                    Case 3, 7
                                        lblHandle(i).Visible = True
                                        lblHandle(i).BringToFront()
                                    Case Else
                                        lblHandle(i).Visible = False
                                End Select
                            Next
                        End If
                    Case Else
                        'Standard control - assume that all sizing directions possible
                        For i As Integer = 0 To 7
                            lblHandle(i).Visible = True
                            lblHandle(i).BringToFront()
                        Next
                End Select
            End If
        End If
    End Sub

    Private Sub HideHandles()
        For i As Integer = 0 To 7
            lblHandle(i).Visible = False
        Next
    End Sub

    Private Sub RepositionHandles()
        Dim sX As Integer = Integer.MaxValue
        Dim sY As Integer = Integer.MaxValue
        Dim sW As Integer = 0
        Dim sH As Integer = 0
        Dim hB As Integer = HANDLESIZE / 2

        'On multiple selection mode
        If lstSelectedControls.Count > 1 Then
            'Find overall selection area (including all selected controls)
            For Each ctl As Control In lstSelectedControls
                If ctl.Bounds.Left < sX Then
                    sX = ctl.Left
                End If

                If ctl.Bounds.Top < sY Then
                    sY = ctl.Top
                End If

                If ctl.Bounds.Right > sW Then
                    sW = ctl.Bounds.Right
                End If

                If ctl.Bounds.Bottom > sH Then
                    sH = ctl.Bounds.Bottom
                End If
            Next

            'Calculate final left, top, width and height
            sX = sX - HANDLESIZE
            sY = sY - HANDLESIZE
            sW = sW - sX + HANDLESIZE
            sH = sH - sY + HANDLESIZE
        Else
            'Single selection mode - calculate left, top, width and height for current control
            sX = ctlCurrent.Left - HANDLESIZE
            sY = ctlCurrent.Top - HANDLESIZE
            sW = ctlCurrent.Width + HANDLESIZE
            sH = ctlCurrent.Height + HANDLESIZE
        End If

        'Populate array of horizontal position coordinates for all sizing handles in
        'the following order: left-top, middle-top, right-top, right-middle, 
        '                     right-bottom, middle-bottom, left-bottom, left-middle
        Dim arrPosX = New Integer() {sX + hB, sX + sW / 2, sX + sW - hB,
                                     sX + sW - hB, sX + sW - hB, sX + sW / 2, _
                                     sX + hB, sX + hB}

        'Populate array of vertical position coordinates for all sizing handles in
        'the same order
        Dim arrPosY = New Integer() {sY + hB, sY + hB, sY + hB, sY + sH / 2, _
                                     sY + sH - hB, sY + sH - hB, sY + sH - hB, _
                                     sY + sH / 2}

        'Reposition all handles
        For i As Integer = 0 To 7
            lblHandle(i).SetBounds(arrPosX(i), arrPosY(i), HANDLESIZE, HANDLESIZE)
            'Use black sizing handles on multiple selection, white sizing handles otherwise
            lblHandle(i).BackColor = IIf(lstSelectedControls.Count > 1, Color.Black, Color.White)
            lblHandle(i).BringToFront()
        Next
    End Sub
#End Region

#Region " Helper methods "
    Private Sub AddControls(ByVal ctlContainer As Object)
        'Loop through all form controls recursively
        For Each ctl As Control In ctlContainer.Controls
            'If control is not in exception list and not a sub-control of a combined control type
            If (Not lstExceptCtls.Contains(ctl)) AndAlso (ctl.GetType.ToString <> "System.Windows.Forms.ListViewGroup") AndAlso (ctl.GetType.ToString <> "System.Windows.Forms.ListViewItem") AndAlso (ctl.GetType.ToString <> "System.Windows.Forms.TreeNode") Then
                'Wrap control and add it to the list of allowed controls for design
                lstControls.Add(New ControlWrapper(ctl))

                'Hook control events used for design mode
                AddHandler ctl.Click, AddressOf SelectControl
                AddHandler ctl.MouseDown, AddressOf Me.Control_MouseDown
                AddHandler ctl.MouseMove, AddressOf Me.Control_MouseMove
                AddHandler ctl.MouseUp, AddressOf Me.Control_MouseUp
                AddHandler ctl.PreviewKeyDown, AddressOf Me.Control_KeyDown

                If Not ctl.Parent.Equals(frmCurrent) Then
                    'Also hook click event for all container controls
                    AddHandler ctl.Parent.Click, AddressOf Me.Parent_Click
                End If

                If ctl.GetType.ToString = "System.Windows.Forms.TextBox" Then
                    'On textboxes hook multi-line change event to update sizing handles in that case
                    AddHandler CType(ctl, System.Windows.Forms.TextBox).MultilineChanged, AddressOf UpdateHandles
                End If

                'Change control cursor and context menu (original values are automatically stored in wrappers)
                ctl.Cursor = Cursors.Arrow
            End If

            'If control is a container (but not a propertygrid)
            If (ctl.Controls.Count > 0) AndAlso (ctl.GetType.ToString <> "System.Windows.Forms.PropertyGrid") Then
                'Loop through its sub-controls too (recursion)
                AddControls(ctl)
            End If
        Next
    End Sub

    Private Sub Parent_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Parent container of a control clicked (deselection)
        Try
            'If current parent is the passed form itself
            If sender.Equals(frmCurrent) Then
                'Remove all selected controls from collection
                lstSelectedControls.Clear()
            End If
        Catch
        End Try

        HideHandles()
    End Sub
#End Region

#Region " Control wrapper class "
    'This class is used store the original settings of each control, that are replaced while in design mode
    Private Class ControlWrapper
        'Original settings
        Private Org_Control As Control = Nothing
        Private Org_Cursor As Cursor = Nothing
        Private Org_ContextMenuStrip As ContextMenuStrip = Nothing

        'cstor
        Public Sub New(ByVal ctl As Control)
            'Store original values
            Org_Control = ctl
            Org_Cursor = ctl.Cursor
            Org_ContextMenuStrip = ctl.ContextMenuStrip
        End Sub

        Public ReadOnly Property Control() As Control
            Get
                Return Org_Control
            End Get
        End Property

        Public ReadOnly Property Cursor() As Cursor
            Get
                Return Org_Cursor
            End Get
        End Property

        Public ReadOnly Property ContextMenuStrip() As ContextMenuStrip
            Get
                Return Org_ContextMenuStrip
            End Get
        End Property
    End Class
#End Region

End Class