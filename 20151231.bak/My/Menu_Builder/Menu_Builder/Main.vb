Public Class Main

#Region "Variable Declarations..."
    Private CodeWin As New Form 'Code window
  
    Dim btnCanAdd As Boolean = False 'For adding btn
    Dim lblCanAdd As Boolean = False 'For adding lbl
    Dim lblLCanAdd As Boolean = False 'For adding link lbl

    Dim cDelete As Boolean = False 'To del contrl
    Dim cLoc As Boolean = False  'To change cntrl loc
    Dim cSize As Boolean = False 'To change cntrl size

     Dim prp As New PropertyGrid  'Properties panel

    Dim i, j, k As Integer 'count btns,lbls,link lbls
    Dim mouseOffset As Point 'For control to change it's location

    Dim btn As vButton 'Button
    Dim lbl As vLabel 'lbl
    Dim lblL As vLinkLabel 'link lbl

    Dim MultiAddCntrl As Boolean
    Dim frmProp As Boolean
    Dim multiSelect As Boolean
    Dim multiselectED As Boolean
#End Region

#Region "Windows Tab"

    'show\hide design window
    Private Sub DesignWindowToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DesignWindowToolStripMenuItem.Click
        If DesignWindowToolStripMenuItem.Checked = False Then
            DesignWin.Hide()
        ElseIf DesignWindowToolStripMenuItem.Checked = True Then
            DesignWin.Show()
        End If
    End Sub

    'show\hide code window
    Private Sub CodeWindowToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CodeWindowToolStripMenuItem.Click
        If CodeWindowToolStripMenuItem.Checked = False Then
            CodeWin.Hide()
        ElseIf CodeWindowToolStripMenuItem.Checked = True Then
            CodeWin.Show()
        End If
    End Sub

    'arrange all win-code,desing
    Private Sub ArrangeWindowsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ArrangeWindowsToolStripMenuItem.Click
        DesignWin.Location = New Point(0, 0)
        CodeWin.Location = New Point(DesignWin.Width + 5, 0)
    End Sub

    'hide all win-code,desing
    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseAllToolStripMenuItem.Click
        DesignWindowToolStripMenuItem.Checked = False
        DesignWin.Hide()
        CodeWindowToolStripMenuItem.Checked = False
        CodeWin.Hide()
    End Sub

    'show all win-code,desing
    Private Sub ShowStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowStripMenuItem.Click
        DesignWindowToolStripMenuItem.Checked = True
        DesignWin.Show()
        CodeWindowToolStripMenuItem.Checked = True
        CodeWin.Show()
    End Sub

    'New window
    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        DesignWindowToolStripMenuItem.Enabled = True

        PropertiesBox.Controls.Add(prp)

        DesignWin.MdiParent = Me
        DesignWin.Text = "Untitled"
        DesignWin.Icon = My.Resources.Design
        DesignWin.Location = New Point(0, 0)
        AddHandler DesignWin.FormClosing, AddressOf DesignClosing 'to hide when closing
        AddHandler DesignWin.MouseMove, AddressOf XY 'location
        AddHandler DesignWin.SizeChanged, AddressOf DSzChange 'size
        AddHandler DesignWin.MouseDown, AddressOf ContrlAdd 'add control  
        AddHandler DesignWin.KeyDown, AddressOf DKeyDown
        AddHandler DesignWin.KeyUp, AddressOf DKeyUp

        DesignWin.Show()

    End Sub

    'Mk checked or unchecked
    Private Sub DesignClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs)
        e.Cancel = True
        DesignWindowToolStripMenuItem.Checked = False
        DesignWin.Hide()
    End Sub

    'Mk checked or unchecked
    Private Sub CodeClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs)
        e.Cancel = True
        CodeWindowToolStripMenuItem.Checked = False
        CodeWin.Hide()
    End Sub

#End Region

#Region "Handlers"

    'coordinates
    Private Sub XY(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        LocXY.Text = e.Location.ToString
    End Sub

    Private Sub cntrlDelete(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If cDelete = True Then
            DesignWin.Controls.Remove(sender)
        ElseIf multiSelect = True Then
            Using redPen As New Pen(Color.Red), _
          formGraphics As Graphics = DesignWin.CreateGraphics()
                formGraphics.DrawRectangle(redPen, New Rectangle(sender.location.x - 1, sender.location.y - 1, sender.width + 1, sender.height + 1))
            End Using
            multiselectED = True
            sender.MA = True
        Else
            DesignWin.ActiveControl = sender
        End If
    End Sub

    'change cntrl loc,sz
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

    'change cntrl loc,sz
    Private Sub CntrlLocChange2MD(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        mouseOffset = New Point(-e.X, -e.Y)
    End Sub

    Private Sub BKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Delete Then

            If multiselectED = False Then
                DesignWin.Controls.Remove(DesignWin.ActiveControl)

            ElseIf multiselectED = True Then

                For Each C As vButton In DesignWin.Controls
                    If C.MA = True Then
                        MsgBox(C.Text + "#" + C.MA.ToString)
                        DesignWin.Controls.Remove(C)
                    End If
                Next

                'For Each l As vLabel In DesignWin.Controls
                '    On Error Resume Next
                '    If l.MA = True Then
                '        DesignWin.Controls.Remove(l)
                '    Else
                '        DesignWin.Controls.Remove(DesignWin.ActiveControl)
                '    End If
                'Next

                'For Each i As vLinkLabel In DesignWin.Controls
                '    On Error Resume Next
                '    If i.MA = True Then
                '        DesignWin.Controls.Remove(i)
                '    Else
                '        DesignWin.Controls.Remove(DesignWin.ActiveControl)
                '    End If
                'Next
            End If

            clean()
        ElseIf e.KeyCode = Keys.Escape Then
            clean()
        ElseIf e.KeyCode = Keys.ControlKey Then
            MultiAddCntrl = True
            multiSelect = True
        End If
    End Sub

    Private Sub DKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            clean()
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

#End Region

    'frm Size
    Private Sub DSzChange()
        'Stop being maximized
        If DesignWin.WindowState = FormWindowState.Maximized Then
            DesignWin.WindowState = FormWindowState.Normal
        End If
        SelectedControl.Text = DesignWin.Text
        ControlSize.Text = DesignWin.Size.ToString
    End Sub

    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CodeWin.MdiParent = Me
        CodeWin.Text = "Code Window"
        CodeWin.MaximizeBox = False
        CodeWin.Icon = My.Resources.Code
        CodeWin.Location = New Point(0, 0)
        CodeWin.Size = New Point(400, 500)
        AddHandler CodeWin.FormClosing, AddressOf CodeClosing 'Hide when closing
        CodeWin.WindowState = FormWindowState.Minimized
        CodeWin.Show()

        DesignWindowToolStripMenuItem.Enabled = False
    End Sub

    'Main window size is propotional to Code window size
    Private Sub Main_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        CodeWin.Size = New Point(Me.Width / 3, Me.Height - Me.Height / 4)
    End Sub

    'Show\Hide properties window on click, remove properties & add new
    Private Sub PropertiesDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PropertiesDisplay.Click
        frmProp = False
        If PropertiesBox.Visible = True Then
            PropertiesBox.Visible = False
        ElseIf PropertiesBox.Visible = False Then
            ToolBox.Visible = False
            ShowProperties()
            PropertiesBox.Visible = True
        End If
    End Sub

    'Show\Hide tool window
    Private Sub ToolboxDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolboxDisplay.Click
        If ToolBox.Visible = True Then
            ToolBox.Visible = False
        ElseIf ToolBox.Visible = False Then
            PropertiesBox.Visible = False
            ToolBox.Visible = True
        End If
    End Sub

    'Show properties of frm in properties window
    Private Sub ShowFrmP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowFrmP.Click
        frmProp = True
        clean()
        ShowProperties()
        ToolBox.Visible = False
        PropertiesBox.Visible = True
    End Sub

    'Every tick -show active control
    Private Sub ControlNameFind_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ControlNameFind.Tick
        Try
            SelectedControl.Text = DesignWin.ActiveControl.Text
        Catch
        End Try
    End Sub

#Region "Conrols Add"

    'add control
    Private Sub ContrlAdd(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If btnCanAdd = True Then

            i = i + 1
            btn = New vButton
            btn.Name = "btn" + i.ToString
            btn.Text = "Button " + i.ToString
            btn.Size = New Point(75, 23)
            btn.Location = e.Location
            btn.MA = False
            AddHandler btn.Click, AddressOf cntrlDelete 'cntrl delete
            AddHandler btn.MouseMove, AddressOf CntrlLocChange1MV 'Change location,sz
            AddHandler btn.MouseDown, AddressOf CntrlLocChange2MD 'Change location,sz
            AddHandler btn.KeyDown, AddressOf BKeyDown
            AddHandler btn.KeyUp, AddressOf DKeyUp

            DesignWin.Controls.Add(btn)
            ControlSize.Text = btn.Size.ToString

        ElseIf lblCanAdd = True Then
          
            j = j + 1
            lbl = New vLabel
            lbl.Name = "lbl" + j.ToString
            lbl.Text = "Label " + j.ToString
            lbl.BackColor = Color.YellowGreen
            lbl.Size = New Point(43, 13)
            lbl.Location = e.Location
            lbl.MA = False
            AddHandler lbl.Click, AddressOf cntrlDelete 'cntrl delete
            AddHandler lbl.MouseMove, AddressOf CntrlLocChange1MV 'Change location,sz
            AddHandler lbl.MouseDown, AddressOf CntrlLocChange2MD 'Change location,sz
            AddHandler lbl.KeyDown, AddressOf BKeyDown 'cntrl delete
            AddHandler lbl.KeyUp, AddressOf DKeyUp

            DesignWin.Controls.Add(lbl)
            ControlSize.Text = lbl.Size.ToString

        ElseIf lblLCanAdd = True Then
          
            k = k + 1
            lblL = New vLinkLabel
            lblL.Name = "ink" + k.ToString 'l removed &link=&label
            lblL.Text = "Link Label " + k.ToString
            lblL.BackColor = Color.LightSkyBlue
            lblL.AutoSize = False
            lblL.Size = New Point(65, 13)
            lblL.Location = e.Location
            lblL.MA = False
            AddHandler lblL.Click, AddressOf cntrlDelete 'cntrl delete
            AddHandler lblL.MouseMove, AddressOf CntrlLocChange1MV 'Change location,sz
            AddHandler lblL.MouseDown, AddressOf CntrlLocChange2MD 'Change location,sz
            AddHandler lblL.KeyDown, AddressOf BKeyDown 'cntrl delete
            AddHandler lblL.KeyUp, AddressOf DKeyUp

            DesignWin.Controls.Add(lblL)
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
    Private Sub ToolButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolButton.Click
        clean()
        btnCanAdd = True 'Enable adding tools
    End Sub

    'Add a label
    Private Sub ToolLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolLabel.Click
        clean()
        lblCanAdd = True
    End Sub

    'Add a link label
    Private Sub ToolLinkLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolLinkLabel.Click
        clean()
        lblLCanAdd = True
    End Sub

#End Region

#Region "Control-Ed.Re.Lo.Sz."

    'Remove controls
    Private Sub ControlRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ControlRemove.Click
        clean()
        cDelete = True 'Enable delete
    End Sub

    'Remove all controls
    Private Sub ControlRemoveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ControlRemoveAll.Click
        DesignWin.Controls.Clear()
        'DropDownList.Items.Clear()
        i = 0
        j = 0
        k = 0
    End Sub

    'Change cntrl loc
    Private Sub ControlLocChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ControlLocChange.Click
        clean()
        cLoc = True
    End Sub

    'Change cntrl sz
    Private Sub ControlSzChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ControlSzChange.Click
        clean()
        cSize = True  'Enable Sz
    End Sub

    'Arrow
    Private Sub CntrlArrow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CntrlArrow.Click
        clean()
    End Sub

#End Region

    'set all to default
    Private Sub clean()
        cLoc = False  'Disable loc
        cDelete = False  'Disable delete
        cSize = False 'Disable Sz
        lblCanAdd = False 'Disable adding lbl
        btnCanAdd = False 'Disable adding btn
        lblLCanAdd = False 'Disable adding link lbl
        MultiAddCntrl = False
        multiSelect = False
        multiselectED = False
        DesignWin.CreateGraphics().Clear(DesignWin.BackColor)
    End Sub

    Private Sub ShowProperties()
        prp.Height = PropertiesBox.Height
        prp.Width = PropertiesBox.Width
        If frmProp = True Then
            prp.SelectedObject = DesignWin
        Else
            prp.SelectedObject = DesignWin.ActiveControl
        End If
    End Sub

End Class
