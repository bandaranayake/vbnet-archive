Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Threading

Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DoubleBuffered = True
        Dim c As New ControlDesigner(Me, New List(Of Control)({}), Color.White)
    End Sub

End Class

Public Class ShapeRectangle
    Inherits Control

    Public _selected As Boolean

    Sub New()
        BackColor = Color.White
        DoubleBuffered = True
        Font = New Font("Segoe UI", Font.Size)
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)
        Dim txtSize As SizeF = e.Graphics.MeasureString(Text, Font)

        e.Graphics.FillRectangle(New SolidBrush(BackColor), 0, 0, Width, Height)

        If _selected Then
            e.Graphics.DrawRectangle(New Pen(Color.DarkOrange, 2), 1, 1, Width - 2, Height - 2)
        Else
            e.Graphics.DrawRectangle(New Pen(Color.Green, 2), 1, 1, Width - 2, Height - 2)
        End If

        e.Graphics.DrawString(Text, Font, Brushes.Black, (Width - txtSize.Width) / 2, (Height - txtSize.Height) / 2)
    End Sub

    Protected Overrides Sub OnSizeChanged(ByVal e As System.EventArgs)
        MyBase.OnSizeChanged(e)
        Invalidate()
    End Sub

End Class

Public Class ShapeEllipse
    Inherits Control

    Public _selected As Boolean

    Sub New()
        SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        BackColor = Color.Black
        DoubleBuffered = True
        Font = New Font("Segoe UI", Font.Size)
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)
        Dim txtSize As SizeF = e.Graphics.MeasureString(Text, Font)

        e.Graphics.FillEllipse(New SolidBrush(Color.White), 0, 0, Width, Height)

        If _selected Then
            e.Graphics.DrawEllipse(New Pen(Color.DarkOrange, 2), 1, 1, Width - 2, Height - 2)
        Else
            e.Graphics.DrawEllipse(New Pen(Color.Green, 2), 1, 1, Width - 2, Height - 2)
        End If

        e.Graphics.DrawString(Text, Font, Brushes.Black, (Width - txtSize.Width) / 2, (Height - txtSize.Height) / 2)

    End Sub

    Protected Overrides Sub OnSizeChanged(ByVal e As System.EventArgs)
        MyBase.OnSizeChanged(e)
        Invalidate()
    End Sub

End Class


Public Class ControlDesigner

    Private lblHandle(7) As Control

    Private arrArrow() As Cursor = New Cursor() {Cursors.SizeNWSE, _
                                                Cursors.SizeNS, _
                                                Cursors.SizeNESW, _
                                                Cursors.SizeWE, _
                                                Cursors.SizeNWSE, _
                                                Cursors.SizeNS, _
                                                Cursors.SizeNESW, _
                                                Cursors.SizeWE}

    Private lstControls As List(Of Control) = Nothing
    Private lstExceptCtls As List(Of Control) = Nothing
    Private lstSelectedControls As List(Of Control) = Nothing
    Private ctlCurrent As Control = Nothing

    Private frmCurrent As Form = Nothing
    Private frmBackColor As Color = Nothing

    Private start_X As Integer
    Private start_Y As Integer

    Private bolDragging As Boolean

    Private Const HANDLESIZE As Integer = 8

    Private start_Left As Integer
    Private start_Top As Integer

    Private Const MINSIZE As Integer = 20

    Public Sub New(ByRef Form As Form, ByVal ExceptControls As List(Of Control), ByVal EditColor As Color, Optional ByVal SnapMargin As Integer = 8)
        frmCurrent = Form
        frmBackColor = frmCurrent.BackColor

        lstExceptCtls = ExceptControls              'contains the controls excepted from design
        lstControls = New List(Of Control)   'contains wrappers for the controls allowed to design
        lstSelectedControls = New List(Of Control)  'will contain the selected controls at any one time

        For i As Integer = 0 To 7
            lblHandle(i) = New Label

            With lblHandle(i)
                .TabIndex = i
                .BackColor = Color.DarkOrange
                .Cursor = arrArrow(i)
                .Text = ""
                .Visible = False
            End With

            AddHandler frmCurrent.Click, AddressOf Me.Parent_Click
            AddHandler lblHandle(i).MouseDown, AddressOf Me.Handle_MouseDown
            AddHandler lblHandle(i).MouseMove, AddressOf Me.Handle_MouseMove
            AddHandler lblHandle(i).MouseUp, AddressOf Me.Handle_MouseUp
            AddHandler lblHandle(i).MouseLeave, AddressOf Me.Handle_Leave
            AddHandler lblHandle(i).MouseEnter, AddressOf Me.Handle_MouseEnter
        Next

        AddControls(frmCurrent)

        frmCurrent.BackColor = EditColor
    End Sub

    Private Sub AddControls(ByVal ctlContainer As Object)
        For Each ctl As Control In ctlContainer.Controls

            If (Not lstExceptCtls.Contains(ctl)) Then
                lstControls.Add(ctl)

                AddHandler ctl.Click, AddressOf SelectControl
                AddHandler ctl.MouseDown, AddressOf Me.Control_MouseDown
                AddHandler ctl.MouseMove, AddressOf Me.Control_MouseMove
                AddHandler ctl.MouseUp, AddressOf Me.Control_MouseUp
                AddHandler ctl.PreviewKeyDown, AddressOf Me.Control_KeyDown

                ctl.Cursor = Cursors.Arrow
            End If

        Next
    End Sub

    Private Sub Parent_Click(ByVal sender As Object, ByVal e As EventArgs)
        Try
            If sender.Equals(frmCurrent) Then
                UnselectControl(lstSelectedControls)
                lstSelectedControls.Clear()
            End If
        Catch
        End Try

        HideHandles()
    End Sub

    Private Sub UnselectControl(ByVal ControlList As List(Of Control))
        For Each c As Object In ControlList
            c.Cursor = Cursors.Arrow
            c._selected = False
            c.Invalidate()
        Next
    End Sub

#Region " Control events "

    Private Sub SelectControl(ByVal sender As Object, ByVal e As EventArgs)

        If (Not My.Computer.Keyboard.CtrlKeyDown) AndAlso (Not lstSelectedControls.Contains(sender)) Then
            UnselectControl(lstSelectedControls)
            lstSelectedControls.Clear()

            If ctlCurrent IsNot Nothing Then
                ctlCurrent.Cursor = Cursors.Arrow
            End If
        End If

        ctlCurrent = sender
        sender._selected = True
        sender.Invalidate()

        If Not lstSelectedControls.Contains(ctlCurrent) Then
            lstSelectedControls.Add(ctlCurrent)
            ctlCurrent.Cursor = Cursors.SizeAll
        End If

        ShowHandles()
    End Sub

    Private Sub Control_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        If (ctlCurrent Is Nothing) Or ((ctlCurrent IsNot Nothing) AndAlso (Not ctlCurrent.Equals(sender))) Then
            SelectControl(sender, New EventArgs)
        End If

        If sender.Equals(ctlCurrent) Then
            bolDragging = True

            start_X = e.X
            start_Y = e.Y

            HideHandles()
        End If
    End Sub

    Private Sub Control_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
        If bolDragging Then
            For Each ctl As Control In lstSelectedControls
                ctl.Location = New Point(ctl.Location.X + e.X - start_X, ctl.Location.Y + e.Y - start_Y)
                frmCurrent.Refresh()
            Next
        End If
    End Sub

    Private Sub Control_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs)
        bolDragging = False
        ShowHandles()
    End Sub

    Private Sub Control_KeyDown(ByVal sender As Object, ByVal e As PreviewKeyDownEventArgs)
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
                Case Keys.Delete
                    For Each ctl As Control In lstSelectedControls
                        With ctl
                            ctl.Parent.Controls.Remove(ctl)
                        End With
                    Next
                    lstSelectedControls.Clear()
                    HideHandles()
                Case Keys.Escape
                    UnselectControl(lstSelectedControls)
                    lstSelectedControls.Clear()
                    HideHandles()
            End Select
        End If
    End Sub
#End Region

    Private Sub HideHandles()
        For i As Integer = 0 To 7
            lblHandle(i).Visible = False
        Next
    End Sub

    Private Sub ShowHandles()
        RepositionHandles()

        For i As Integer = 0 To 7
            lblHandle(i).Parent = frmCurrent
            lblHandle(i).Visible = True
            lblHandle(i).BringToFront()
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


            sX = sX - HANDLESIZE
            sY = sY - HANDLESIZE
            sW = sW - sX 
            sH = sH - sY

        Else
            sX = ctlCurrent.Left - HANDLESIZE
            sY = ctlCurrent.Top - HANDLESIZE
            sW = ctlCurrent.Width + HANDLESIZE
            sH = ctlCurrent.Height + HANDLESIZE
        End If

        'left-top, middle-top, right-top, right-middle, right-bottom, middle-bottom, left-bottom, left-middle
        Dim arrPosX = New Integer() {sX + hB, sX + sW / 2, sX + sW - hB,
                                     sX + sW - hB, sX + sW - hB, sX + sW / 2, _
                                     sX + hB, sX + hB, _
                                     sY + hB, sY + hB, sY + hB, sY + sH / 2, _
                                     sY + sH - hB, sY + sH - hB, sY + sH - hB, _
                                     sY + sH / 2}


        For i As Integer = 0 To 7
            lblHandle(i).SetBounds(arrPosX(i), arrPosX(i + 8), HANDLESIZE, HANDLESIZE)
            lblHandle(i).BackColor = Color.DarkOrange
            lblHandle(i).BringToFront()
        Next

    End Sub

    Private Sub Handle_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        bolDragging = True

        start_Left = e.X
        start_Top = e.Y

        HideHandles()
    End Sub

    Private Sub Handle_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        sender.SetBounds(sender.Location.X - 1, sender.Location.Y - 1, HANDLESIZE + 2, HANDLESIZE + 2)
    End Sub

    Private Sub Handle_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        sender.SetBounds(sender.Location.X + 1, sender.Location.Y + 1, HANDLESIZE, HANDLESIZE)
    End Sub

    Private Sub Handle_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
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
        bolDragging = False

        ShowHandles()
    End Sub

End Class
