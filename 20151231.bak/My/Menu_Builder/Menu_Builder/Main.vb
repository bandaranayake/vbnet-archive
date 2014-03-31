Imports System.Drawing.Imaging
Imports System.IO
Imports System.Text

Public Class Main

#Region "Variable Declarations..."

    Dim NewFrame As New Form

    Dim toolStripButton1, toolStripButton2, toolStripButton3 As ToolStripMenuItem
    Dim ContextMenuS As New ContextMenuStrip

    Dim btnCanAdd, lblCanAdd, lblLCanAdd As Boolean
    Dim cDelete, cLoc, cSize As Boolean

    Dim i, j, k As Integer
    Dim mouseOffset As Point

    Dim btn As Button
    Dim lbl As Label
    Dim lblL As LinkLabel

    Dim MultiAddCntrl, multiSelect, multiselectED As Boolean

    Dim linklabels As New LinkLabelArray
    Dim labels As New LabelArray
    Dim buttons As New ButtonArray

    Dim p As Boolean

#End Region

    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        If (NewProject.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            Dim winToolStripItem As New ToolStripMenuItem

            clean1()
            clean2()

            linklabels = New LinkLabelArray
            labels = New LabelArray
            buttons = New ButtonArray
            NewFrame.Controls.Clear()
            i = 0
            j = 0
            k = 0
            p = True

            NewFrame.MdiParent = Me
            NewFrame.Text = ProjectName
            NewFrame.Location = New Point(0, 0)


            AddHandler NewFrame.MouseMove, AddressOf GetLocation
            AddHandler NewFrame.SizeChanged, AddressOf DSzChange
            AddHandler NewFrame.MouseDown, AddressOf ContrlAdd
            AddHandler NewFrame.KeyDown, AddressOf DKeyDown
            AddHandler NewFrame.KeyUp, AddressOf DKeyUp

            NewFrame.Show()

            winToolStripItem.Text = NewFrame.Text
            winToolStripItem.CheckOnClick = True
            winToolStripItem.Checked = True
            winToolStripItem.CheckState = CheckState.Checked
            winToolStripItem.Tag = NewFrame
            AddHandler winToolStripItem.Click, AddressOf winToolStripItem_Click
            WindowsToolStripMenuItem.DropDownItems.Add(winToolStripItem)
        End If

    End Sub

#Region "Handlers"

    Private Sub winToolStripItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If sender.Checked = False Then
            sender.Tag.Hide()
        ElseIf sender.Checked = True Then
            sender.Tag.Show()
        End If
    End Sub

    Public Sub ControlRemove(ByVal sender As System.Object, ByVal e As System.EventArgs)
        NewFrame.Controls.Remove(ContextMenuS.SourceControl)
        clean1()
        clean2()
    End Sub

    Private Sub cntrlDelete(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If multiSelect = True Then
            Using redPen As New Pen(Color.Red), _
          formGraphics As Graphics = NewFrame.CreateGraphics()
                formGraphics.DrawRectangle(redPen, New Rectangle(sender.location.x - 1, sender.location.y - 1, sender.width + 1, sender.height + 1))
            End Using
            multiselectED = True
            sender.Tag = True
        Else
            NewFrame.ActiveControl = sender
        End If
    End Sub

    Private Sub CntrlLoc(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If cLoc = True Then
            clean1()
            clean2()
            cLoc = False
        ElseIf cLoc = False Then
            clean1()
            clean2()
            cLoc = True
        End If
    End Sub

    Private Sub CntrlSz(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If cSize = True Then
            clean1()
            clean2()
            cSize = False
        ElseIf cSize = False Then
            clean1()
            clean2()
            cSize = True
        End If
    End Sub

    Private Sub CntrlLocChange1MV(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If cLoc = True Then
            If e.Button = MouseButtons.Left Then
                Dim mousePos = Control.MousePosition
                mousePos.Offset(mouseOffset.X - 100, mouseOffset.Y - 185)
                sender.Location = mousePos
                LocXY.Text = sender.Location.ToString
            End If
        ElseIf cSize = True Then
            If e.Button = MouseButtons.Left Then
                Dim mousePos = Control.MousePosition
                mousePos.Offset(mouseOffset.X - 100, mouseOffset.Y - 200)
                sender.Size = mousePos
                ControlSize.Text = sender.Size.ToString
            End If
        End If
    End Sub

    Private Sub CntrlLocChange2MD(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        mouseOffset = New Point(-e.X, -e.Y)
    End Sub

    Sub cms_Opening(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        ContextMenuS.Items.Clear()

        toolStripButton1 = New ToolStripMenuItem
        toolStripButton2 = New ToolStripMenuItem
        toolStripButton3 = New ToolStripMenuItem

        Me.toolStripButton1.Name = "toolStripButton1"
        Me.toolStripButton1.Text = "&Delete"
        AddHandler toolStripButton1.Click, AddressOf ControlRemove

        Me.toolStripButton2.Name = "toolStripButton2"
        Me.toolStripButton2.Text = "&Size"
        Me.toolStripButton2.CheckOnClick = True
        Me.toolStripButton2.Checked = cSize
        AddHandler toolStripButton2.Click, AddressOf CntrlSz

        Me.toolStripButton3.Name = "toolStripButton3"
        Me.toolStripButton3.Text = "&Location"
        Me.toolStripButton3.CheckOnClick = True
        Me.toolStripButton3.Checked = cLoc
        AddHandler toolStripButton3.Click, AddressOf CntrlLoc

        ContextMenuS.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripButton1, Me.toolStripButton2, Me.toolStripButton3})

        e.Cancel = False
    End Sub

#End Region

#Region "Conrols Add"

    Private Sub ContrlAdd(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        AddHandler ContextMenuS.Opening, AddressOf cms_Opening
        ContextMenuS.AutoSize = False
        ContextMenuS.Size = New Point(100, 70)
        ContextMenuS.ShowImageMargin = True

        If btnCanAdd = True Then
            i = i + 1
            btn = New Button
            btn.Name = "btn" + i.ToString
            btn.Text = "Button " + i.ToString
            btn.Size = New Point(75, 23)
            btn.Location = e.Location
            btn.ContextMenuStrip = ContextMenuS
            btn.Tag = False
            buttons.SetIndex(btn, i)
            AddHandler btn.Click, AddressOf cntrlDelete
            AddHandler btn.MouseMove, AddressOf CntrlLocChange1MV
            AddHandler btn.MouseDown, AddressOf CntrlLocChange2MD
            AddHandler btn.KeyDown, AddressOf DKeyDown
            AddHandler btn.KeyUp, AddressOf DKeyUp

            NewFrame.Controls.Add(btn)
            ControlSize.Text = btn.Size.ToString

        ElseIf lblCanAdd = True Then

            j = j + 1
            lbl = New Label
            lbl.Name = "lbl" + j.ToString
            lbl.Text = "Label " + j.ToString
            lbl.BackColor = Color.YellowGreen
            lbl.Size = New Point(43, 13)
            lbl.Location = e.Location
            lbl.ContextMenuStrip = ContextMenuS
            lbl.Tag = False
            labels.SetIndex(lbl, j)
            AddHandler lbl.Click, AddressOf cntrlDelete
            AddHandler lbl.MouseMove, AddressOf CntrlLocChange1MV
            AddHandler lbl.MouseDown, AddressOf CntrlLocChange2MD
            AddHandler lbl.KeyDown, AddressOf DKeyDown
            AddHandler lbl.KeyUp, AddressOf DKeyUp

            NewFrame.Controls.Add(lbl)
            ControlSize.Text = lbl.Size.ToString

        ElseIf lblLCanAdd = True Then

            k = k + 1
            lblL = New LinkLabel
            lblL.Name = "ink" + k.ToString
            lblL.Text = "Link Label " + k.ToString
            lblL.BackColor = Color.LightSkyBlue
            lblL.AutoSize = False
            lblL.Size = New Point(65, 13)
            lblL.Location = e.Location
            lblL.Tag = False
            lblL.ContextMenuStrip = ContextMenuS
            linklabels.SetIndex(lblL, k)
            AddHandler lblL.Click, AddressOf cntrlDelete
            AddHandler lblL.MouseMove, AddressOf CntrlLocChange1MV
            AddHandler lblL.MouseDown, AddressOf CntrlLocChange2MD
            AddHandler lblL.KeyDown, AddressOf DKeyDown
            AddHandler lblL.KeyUp, AddressOf DKeyUp

            NewFrame.Controls.Add(lblL)
            ControlSize.Text = lblL.Size.ToString

        End If
        'change cntrl loc
        If cLoc = True Then
            mouseOffset = New Point(-e.X, -e.Y)
        End If
en:
        If MultiAddCntrl = False Then
            lblCanAdd = False
            lblLCanAdd = False
            btnCanAdd = False
        End If
    End Sub

    'Add a button
    Private Sub ToolButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolButton.Click, ButttonToolStripMenuItem.Click
        clean1()
        clean2()
        btnCanAdd = True
    End Sub

    'Add a label
    Private Sub ToolLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolLabel.Click, LabelToolStripMenuItem.Click
        clean1()
        clean2()
        lblCanAdd = True
    End Sub

    'Add a link label
    Private Sub ToolLinkLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolLinkLabel.Click, LinkLabelToolStripMenuItem.Click
        clean1()
        clean2()
        lblLCanAdd = True
    End Sub

    'Disable all
    Private Sub ToolArrow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolArrow.Click
        clean1()
        clean2()
    End Sub

#End Region

#Region "Arrange-Select"

    'Arrange V
    Private Sub VerticallyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerticallyToolStripMenuItem.Click
        For Each c In NewFrame.Controls
            If c.Tag = True Then
                clean1()
                c.Location = New Point(NewFrame.ActiveControl.Location.X, c.Location.Y)
                c.Tag = False
            End If
        Next
    End Sub

    'Arrange H
    Private Sub HorizontallyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HorizontallyToolStripMenuItem.Click
        For Each c In NewFrame.Controls
            If c.tag = True Then
                clean1()
                c.Location = New Point(c.Location.X, NewFrame.ActiveControl.Location.Y)
                c.Tag = False
            End If
        Next
    End Sub

    'Remove all controls
    Private Sub RemoveAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveAllToolStripMenuItem.Click
        clean1()
        clean2()
        linklabels = New LinkLabelArray
        labels = New LabelArray
        buttons = New ButtonArray
        NewFrame.Controls.Clear()
        i = 0
        j = 0
        k = 0
    End Sub

    'Select all controls
    Private Sub AllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AllToolStripMenuItem.Click
        clean1()
        clean2()

        For Each c In NewFrame.Controls
            If TypeOf c Is Button Then
                Using redPen As New Pen(Color.Red), _
       formGraphics As Graphics = NewFrame.CreateGraphics()
                    formGraphics.DrawRectangle(redPen, New Rectangle(c.Location.X - 1, c.Location.Y - 1, c.Width + 1, c.Height + 1))
                End Using
                multiselectED = True
                c.Tag = True
            ElseIf TypeOf c Is LinkLabel Then
                    Using redPen As New Pen(Color.Red), _
         formGraphics As Graphics = NewFrame.CreateGraphics()
                        formGraphics.DrawRectangle(redPen, New Rectangle(c.Location.X - 1, c.Location.Y - 1, c.Width + 1, c.Height + 1))
                    End Using
                    multiselectED = True
                    c.Tag = True
                ElseIf TypeOf c Is Label Then
                    Using redPen As New Pen(Color.Red), _
           formGraphics As Graphics = NewFrame.CreateGraphics()
                        formGraphics.DrawRectangle(redPen, New Rectangle(c.Location.X - 1, c.Location.Y - 1, c.Width + 1, c.Height + 1))
                    End Using
                    multiselectED = True
                    c.Tag = True
            End If
        Next
    End Sub

    'Select all buttons
    Private Sub ButtonsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonsToolStripMenuItem.Click
        clean1()
        clean2()
        For Each c In NewFrame.Controls
            If TypeOf c Is Button Then
                Using redPen As New Pen(Color.Red), _
       formGraphics As Graphics = NewFrame.CreateGraphics()
                    formGraphics.DrawRectangle(redPen, New Rectangle(c.Location.X - 1, c.Location.Y - 1, c.Width + 1, c.Height + 1))
                End Using
                multiselectED = True
                c.Tag = True
            End If
        Next
    End Sub

    'Select all labels
    Private Sub LabelsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelsToolStripMenuItem.Click
        clean1()
        clean2()
        For Each c In NewFrame.Controls
            If TypeOf c Is LinkLabel Then
            ElseIf TypeOf c Is Label Then
                Using redPen As New Pen(Color.Red), _
       formGraphics As Graphics = NewFrame.CreateGraphics()
                    formGraphics.DrawRectangle(redPen, New Rectangle(c.Location.X - 1, c.Location.Y - 1, c.Width + 1, c.Height + 1))
                End Using
                multiselectED = True
                c.Tag = True
            End If
        Next
    End Sub

    'Select all link labels
    Private Sub LinkLabelsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkLabelsToolStripMenuItem.Click
        clean1()
        clean2()
        For Each c In NewFrame.Controls
            If TypeOf c Is LinkLabel Then
                Using redPen As New Pen(Color.Red), _
     formGraphics As Graphics = NewFrame.CreateGraphics()
                    formGraphics.DrawRectangle(redPen, New Rectangle(c.Location.X - 1, c.Location.Y - 1, c.Width + 1, c.Height + 1))
                End Using
                multiselectED = True
                c.Tag = True
            End If
        Next
    End Sub

    'Unselect all
    Private Sub UnselectAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnselectAllToolStripMenuItem.Click
        clean1()
        clean2()
    End Sub

#End Region

#Region "Form Handlers"

    Private Sub DSzChange()
        If NewFrame.WindowState = FormWindowState.Maximized Then
            NewFrame.WindowState = FormWindowState.Normal
        End If
        SelectedControl.Text = NewFrame.Text
        ControlSize.Text = NewFrame.Size.ToString
    End Sub

    Private Sub DKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Delete Then

            If multiselectED = False Then
                NewFrame.Controls.Remove(NewFrame.ActiveControl)

            ElseIf multiselectED = True Then
                For Each c In NewFrame.Controls
                    If c.Tag = True Then
                        NewFrame.Controls.Remove(c)
                    End If
                Next
            End If

            clean1()
            clean2()

        ElseIf e.KeyCode = Keys.Escape Then
            clean1()
            clean2()
        ElseIf e.KeyCode = Keys.ControlKey Then
            MultiAddCntrl = True
            multiSelect = True
        End If
    End Sub

    Private Sub DKeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.ControlKey Then
            MultiAddCntrl = False
            multiSelect = False
        End If
    End Sub

    Private Sub GetLocation(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        LocXY.Text = e.Location.ToString
    End Sub

#End Region

#Region "Other"

    Private Sub ControlNameFind_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ControlNameFind.Tick
        Try
            SelectedControl.Text = NewFrame.ActiveControl.Text
        Catch
        End Try
    End Sub

    'set all to default
    Private Sub clean1()
        cLoc = False  'Disable loc
        cDelete = False  'Disable delete
        cSize = False 'Disable Sz
        lblCanAdd = False 'Disable adding lbl
        btnCanAdd = False 'Disable adding btn
        lblLCanAdd = False 'Disable adding link lbl
        MultiAddCntrl = False
        multiSelect = False
        multiselectED = False
        NewFrame.CreateGraphics().Clear(NewFrame.BackColor)

    End Sub

    'set all to default
    Private Sub clean2()
        For Each b In buttons
            b.Tag = False
        Next
        For Each l In labels
            l.Tag = False
        Next
        For Each n In linklabels
            n.Tag = False
        Next

    End Sub

    'Capture Screen
    Private Sub ExportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportToolStripMenuItem.Click
        Dim nm As String = Now.ToString.Replace("/", "-").Replace(" ", "_").Replace(":", "_")
        NewFrame.Location = New Point(0, 0)
        Dim memoryImage As Bitmap
        Dim myGraphics As Graphics = Me.CreateGraphics()
        Dim s As Size = NewFrame.Size
        memoryImage = New Bitmap(s.Width, s.Height, myGraphics)
        Dim memoryGraphics As Graphics = Graphics.FromImage(memoryImage)
        memoryGraphics.CopyFromScreen(NewFrame.Location.X, NewFrame.Location.Y + 72, 0, 0, s)
        memoryImage.Save("G:\" + nm + ".bmp", ImageFormat.Bmp)
    End Sub

#End Region

End Class
