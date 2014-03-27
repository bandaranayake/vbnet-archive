Imports System.Drawing.Imaging
Imports System.IO
Imports System.Text

Public Class Main

#Region "Variable Declarations..."
    Dim toolStripButton1, toolStripButton2, toolStripButton3 As ToolStripMenuItem
    Private ContextMenuS As New ContextMenuStrip

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

    Dim linklabels As New LinkLabelArray
    Dim labels As New LabelArray
    Dim buttons As New ButtonArray

    Dim proName As String
    Dim proPath As String
    Dim p As Boolean
#End Region

#Region "Windows Tab"

    'New window
    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        If (Pwin.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            proName = Pwin.TextBox1.Text
            proPath = Pwin.TextBox2.Text + Pwin.TextBox1.Text
            clean1()
            clean2()

            linklabels = New LinkLabelArray
            labels = New LabelArray
            buttons = New ButtonArray
            DesignWin.Controls.Clear()
            i = 0
            j = 0
            k = 0
            p = True

            PropertiesBox.Controls.Add(prp)

            DesignWin.MdiParent = Me
            DesignWin.Text = proName
            DesignWin.Icon = My.Resources.Design
            DesignWin.Location = New Point(0, 0)
            'AddHandler DesignWin.FormClosing, AddressOf DesignClosing 'to hide when closing
            AddHandler DesignWin.MouseMove, AddressOf XY 'location
            AddHandler DesignWin.SizeChanged, AddressOf DSzChange 'size
            AddHandler DesignWin.MouseDown, AddressOf ContrlAdd 'add control  
            AddHandler DesignWin.KeyDown, AddressOf BKeyDown
            AddHandler DesignWin.KeyUp, AddressOf DKeyUp

            DesignWin.Show()
        End If

    End Sub

    'Ask for saving
    Private Sub DesignClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs)
        If p = True Then
            Dim aa As MsgBoxResult
            aa = MessageBox.Show("Do you want to save changes to " + """" + proName + """ ?", "Closing..", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation)
            If aa = MsgBoxResult.Yes Then
                save()
                DesignWin.Dispose()
                p = False
            ElseIf aa = MsgBoxResult.No Then
                DesignWin.Dispose()
                p = False
            Else
                e.Cancel = True
            End If
        End If
    End Sub

#End Region

#Region "Handlers"

    'coordinates
    Private Sub XY(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        LocXY.Text = e.Location.ToString
    End Sub

    'remove control
    Public Sub ControlRemove(ByVal sender As System.Object, ByVal e As System.EventArgs)
        DesignWin.Controls.Remove(ContextMenuS.SourceControl)
        clean1()
        clean2()
    End Sub

    'select controls
    Private Sub cntrlDelete(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If multiSelect = True Then
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

    'Change cntrl loc
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

    'change cntrl sz
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

    'key press
    Private Sub BKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Delete Then

            If multiselectED = False Then
                DesignWin.Controls.Remove(DesignWin.ActiveControl)

            ElseIf multiselectED = True Then
                For Each b In buttons
                    If b.MA = True Then
                        DesignWin.Controls.Remove(b)
                    End If
                Next
                For Each n In linklabels
                    If n.MA = True Then
                        DesignWin.Controls.Remove(n)
                    End If
                Next
                For Each l In labels
                    If l.MA = True Then
                        DesignWin.Controls.Remove(l)
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

    'key press
    Private Sub DKeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.ControlKey Then
            MultiAddCntrl = False
            multiSelect = False
        End If
    End Sub

    'right click menu
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

    'add control
    Private Sub ContrlAdd(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        AddHandler ContextMenuS.Opening, AddressOf cms_Opening
        ContextMenuS.AutoSize = False
        ContextMenuS.Size = New Point(100, 70)
        ContextMenuS.ShowImageMargin = True

        If btnCanAdd = True Then
            i = i + 1
            btn = New vButton
            btn.Name = "btn" + i.ToString
            btn.Text = "Button " + i.ToString
            btn.Size = New Point(75, 23)
            btn.Location = e.Location
            btn.ContextMenuStrip = ContextMenuS
            btn.MA = False
            buttons.SetIndex(btn, i)
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
            lbl.ContextMenuStrip = ContextMenuS
            lbl.MA = False
            labels.SetIndex(lbl, j)
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
            lblL.ContextMenuStrip = ContextMenuS
            linklabels.SetIndex(lblL, k)
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
        clean1()
        clean2()
        btnCanAdd = True 'Enable adding tools
    End Sub

    Private Sub ButttonToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButttonToolStripMenuItem.Click
        clean1()
        clean2()
        btnCanAdd = True 'Enable adding tools
    End Sub


    'Add a label
    Private Sub ToolLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolLabel.Click
        clean1()
        clean2()
        lblCanAdd = True
    End Sub

    Private Sub LabelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelToolStripMenuItem.Click
        clean1()
        clean2()
        lblCanAdd = True 'Enable adding tools
    End Sub


    'Add a link label
    Private Sub ToolLinkLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolLinkLabel.Click
        clean1()
        clean2()
        lblLCanAdd = True
    End Sub

    Private Sub LinkLabelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkLabelToolStripMenuItem.Click
        clean1()
        clean2()
        lblLCanAdd = True 'Enable adding tools
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
        For Each b In buttons
            If b.MA = True Then
                clean1()
                b.Location = New Point(DesignWin.ActiveControl.Location.X, b.Location.Y)
                b.MA = False
            End If
        Next

        For Each n In linklabels
            If n.MA = True Then
                clean1()
                n.Location = New Point(DesignWin.ActiveControl.Location.X, n.Location.Y)
                n.MA = False
            End If
        Next
        For Each l In labels
            If l.MA = True Then
                clean1()
                l.Location = New Point(DesignWin.ActiveControl.Location.X, l.Location.Y)
                l.MA = False
            End If
        Next
    End Sub

    'Arrange H
    Private Sub HorizontallyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HorizontallyToolStripMenuItem.Click
        For Each b In buttons
            If b.MA = True Then
                clean1()
                b.Location = New Point(b.Location.X, DesignWin.ActiveControl.Location.Y)
                b.MA = False
            End If
        Next

        For Each n In linklabels
            If n.MA = True Then
                clean1()
                n.Location = New Point(n.Location.X, DesignWin.ActiveControl.Location.Y)
                n.MA = False
            End If
        Next
        For Each l In labels
            If l.MA = True Then
                clean1()
                l.Location = New Point(l.Location.X, DesignWin.ActiveControl.Location.Y)
                l.MA = False
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
        DesignWin.Controls.Clear()
        i = 0
        j = 0
        k = 0
    End Sub

    'Select all controls
    Private Sub AllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AllToolStripMenuItem.Click
        clean1()
        clean2()
        For Each b In buttons
            Using redPen As New Pen(Color.Red), _
        formGraphics As Graphics = DesignWin.CreateGraphics()
                formGraphics.DrawRectangle(redPen, New Rectangle(b.Location.X - 1, b.Location.Y - 1, b.Width + 1, b.Height + 1))
            End Using
            multiselectED = True
            b.MA = True
        Next
        For Each l In labels
            Using redPen As New Pen(Color.Red), _
        formGraphics As Graphics = DesignWin.CreateGraphics()
                formGraphics.DrawRectangle(redPen, New Rectangle(l.Location.X - 1, l.Location.Y - 1, l.Width + 1, l.Height + 1))
            End Using
            multiselectED = True
            l.MA = True
        Next
        For Each n In linklabels
            Using redPen As New Pen(Color.Red), _
        formGraphics As Graphics = DesignWin.CreateGraphics()
                formGraphics.DrawRectangle(redPen, New Rectangle(n.Location.X - 1, n.Location.Y - 1, n.Width + 1, n.Height + 1))
            End Using
            multiselectED = True
            n.MA = True
        Next
    End Sub

    'Select all buttons
    Private Sub ButtonsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonsToolStripMenuItem.Click
        clean1()
        clean2()
        For Each b In buttons
            Using redPen As New Pen(Color.Red), _
        formGraphics As Graphics = DesignWin.CreateGraphics()
                formGraphics.DrawRectangle(redPen, New Rectangle(b.Location.X - 1, b.Location.Y - 1, b.Width + 1, b.Height + 1))
            End Using
            multiselectED = True
            b.MA = True
        Next
    End Sub

    'Select all labels
    Private Sub LabelsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelsToolStripMenuItem.Click
        clean1()
        clean2()
        For Each l In labels
            Using redPen As New Pen(Color.Red), _
        formGraphics As Graphics = DesignWin.CreateGraphics()
                formGraphics.DrawRectangle(redPen, New Rectangle(l.Location.X - 1, l.Location.Y - 1, l.Width + 1, l.Height + 1))
            End Using
            multiselectED = True
            l.MA = True
        Next
    End Sub

    'Select all link labels
    Private Sub LinkLabelsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkLabelsToolStripMenuItem.Click
        clean1()
        clean2()
        For Each n In linklabels
            Using redPen As New Pen(Color.Red), _
        formGraphics As Graphics = DesignWin.CreateGraphics()
                formGraphics.DrawRectangle(redPen, New Rectangle(n.Location.X - 1, n.Location.Y - 1, n.Width + 1, n.Height + 1))
            End Using
            multiselectED = True
            n.MA = True
        Next
    End Sub

    'Unselect all
    Private Sub UnselectAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnselectAllToolStripMenuItem.Click
        clean1()
        clean2()
    End Sub

#End Region

#Region "Other"

    'frm Size
    Private Sub DSzChange()
        'Stop being maximized
        If DesignWin.WindowState = FormWindowState.Maximized Then
            DesignWin.WindowState = FormWindowState.Normal
        End If
        SelectedControl.Text = DesignWin.Text
        ControlSize.Text = DesignWin.Size.ToString
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

    Dim t As String
    'Every tick -show active control
    Private Sub ControlNameFind_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ControlNameFind.Tick
        Try
            t = DesignWin.ActiveControl.Name
            SelectedControl.Text = DesignWin.ActiveControl.Text
        Catch
        End Try
    End Sub

    'to show properties of selected control when properties box is shown
    Private Sub PHide_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PHide.Tick
        Try
            If t <> DesignWin.ActiveControl.Name Then
                ShowProperties()
            End If
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
        DesignWin.CreateGraphics().Clear(DesignWin.BackColor)

    End Sub

    'set all to default
    Private Sub clean2()
        For Each b In buttons
            b.MA = False
        Next
        For Each l In labels
            l.MA = False
        Next
        For Each n In linklabels
            n.MA = False
        Next

    End Sub

    'Show properties
    Private Sub ShowProperties()
        prp.Height = PropertiesBox.Height
        prp.Width = PropertiesBox.Width
        If frmProp = True Then
            prp.SelectedObject = DesignWin
        Else
            prp.SelectedObject = DesignWin.ActiveControl
        End If
    End Sub

    'Capture Screen
    Private Sub ExportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportToolStripMenuItem.Click
        Dim nm As String = Now.ToString.Replace("/", "-").Replace(" ", "_").Replace(":", "_")
        DesignWin.Location = New Point(0, 0)
        Dim memoryImage As Bitmap
        Dim myGraphics As Graphics = Me.CreateGraphics()
        Dim s As Size = DesignWin.Size
        memoryImage = New Bitmap(s.Width, s.Height, myGraphics)
        Dim memoryGraphics As Graphics = Graphics.FromImage(memoryImage)
        memoryGraphics.CopyFromScreen(DesignWin.Location.X, DesignWin.Location.Y + 72, 0, 0, s)
        memoryImage.Save("G:\" + nm + ".bmp", ImageFormat.Bmp)
    End Sub

    'Show properties of frm in properties window
    Private Sub FormPropertiesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FormPropertiesToolStripMenuItem.Click
        frmProp = True
        clean1()
        clean2()
        ShowProperties()
        ToolBox.Visible = False
        PropertiesBox.Visible = True
    End Sub

    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If My.Computer.FileSystem.DirectoryExists(My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\Menu Builder\Projects\") = False Then
            Try
                My.Computer.FileSystem.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\Menu Builder\Projects\")
            Catch ex As Exception
                MsgBox(ex.Message)
                End
            End Try
        End If
    End Sub

    Private Sub AddCommandToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddCommandToolStripMenuItem.Click
        If TypeOf DesignWin.ActiveControl Is Button Then
            CmdWin.ListBox1.Items.Clear()

            btn = DesignWin.ActiveControl
            CmdWin.RadioButton1.Checked = btn.c
            CmdWin.chkWait.Checked = btn.ad_e
            CmdWin.chkErr.Checked = btn.ad_er

            Try
                Using sr As StreamReader = New StreamReader(proPath + "\" + btn.cmd)
                    Dim line As String
                    Do
                        line = sr.ReadLine()
                        CmdWin.ListBox1.Items.Add(line)
                    Loop Until line Is Nothing
                End Using
            Catch
            End Try


            If (CmdWin.ShowDialog = Windows.Forms.DialogResult.OK) Then
                btn.c = CmdWin.RadioButton1.Checked
                btn.ad_e = CmdWin.chkWait.CheckState
                btn.ad_er = CmdWin.chkErr.CheckState

                Dim sb As New StringBuilder()
                For Each item As String In CmdWin.ListBox1.Items
                    If item.Length > 0 Then
                        sb.AppendLine(item)
                    End If
                Next

                Using outfile As New StreamWriter(proPath + "\" + btn.Name + buttons.GetIndex(btn).ToString)
                    outfile.Write(sb.ToString())
                End Using
                btn.cmd = btn.Name + buttons.GetIndex(btn).ToString

                'buttons.Item(buttons.GetIndex(btn)).cmd = buttons.Item(buttons.GetIndex(btn)).Name + buttons.GetIndex(btn).ToString
            End If

        End If

    End Sub

    Private Sub PropertiesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PropertiesToolStripMenuItem.Click
        frmProp = False
        If PropertiesBox.Visible = True Then
            PropertiesBox.Visible = False
        ElseIf PropertiesBox.Visible = False Then
            ToolBox.Visible = False
            ShowProperties()
            PropertiesBox.Visible = True
        End If
    End Sub

#End Region

    'save the project
    'Private Sub save()
    '    Try
    '        Directory.CreateDirectory(proPath + "\Resources\images")
    '    Catch
    '    End Try

    '    For Each cn As Control In DesignWin.Controls
    '        If TypeOf cn Is Button Then

    '            btn = cn

    '            Dim binWriter As New BinaryWriter( _
    '        File.Open(proPath + "\" + btn.Name + ".p", FileMode.Create))

    '            Try
    '                binWriter.Write("mBP_b")
    '                binWriter.Write(btn.Name)
    '                binWriter.Write(btn.AutoSize)

    '                If GetColorType(btn.BackColor) = True Then
    '                    binWriter.Write(GetColorType(btn.BackColor))
    '                    binWriter.Write(btn.BackColor.ToKnownColor)
    '                Else
    '                    binWriter.Write(GetColorType(btn.BackColor))
    '                    binWriter.Write(btn.BackColor.ToArgb)
    '                End If

    '                binWriter.Write(btn.BackgroundImageLayout)
    '                binWriter.Write(GetCursor(btn.Cursor))
    '                binWriter.Write(btn.Dock)

    '                If GetColorType(btn.FlatAppearance.BorderColor) = True Then
    '                    binWriter.Write(GetColorType(btn.FlatAppearance.BorderColor))
    '                    binWriter.Write(btn.FlatAppearance.BorderColor.ToKnownColor)
    '                Else
    '                    binWriter.Write(GetColorType(btn.FlatAppearance.BorderColor))
    '                    binWriter.Write(btn.FlatAppearance.BorderColor.ToArgb)
    '                End If

    '                binWriter.Write(btn.FlatAppearance.BorderSize)

    '                If GetColorType(btn.FlatAppearance.CheckedBackColor) = True Then
    '                    binWriter.Write(GetColorType(btn.FlatAppearance.CheckedBackColor))
    '                    binWriter.Write(btn.FlatAppearance.CheckedBackColor.ToKnownColor)
    '                Else
    '                    binWriter.Write(GetColorType(btn.FlatAppearance.CheckedBackColor))
    '                    binWriter.Write(btn.FlatAppearance.CheckedBackColor.ToArgb)
    '                End If

    '                If GetColorType(btn.FlatAppearance.MouseDownBackColor) = True Then
    '                    binWriter.Write(GetColorType(btn.FlatAppearance.MouseDownBackColor))
    '                    binWriter.Write(btn.FlatAppearance.MouseDownBackColor.ToKnownColor)
    '                Else
    '                    binWriter.Write(GetColorType(btn.FlatAppearance.MouseDownBackColor))
    '                    binWriter.Write(btn.FlatAppearance.MouseDownBackColor.ToArgb)
    '                End If

    '                If GetColorType(btn.FlatAppearance.MouseOverBackColor) = True Then
    '                    binWriter.Write(GetColorType(btn.FlatAppearance.MouseOverBackColor))
    '                    binWriter.Write(btn.FlatAppearance.MouseOverBackColor.ToKnownColor)
    '                Else
    '                    binWriter.Write(GetColorType(btn.FlatAppearance.MouseOverBackColor))
    '                    binWriter.Write(btn.FlatAppearance.MouseOverBackColor.ToArgb)
    '                End If

    '                binWriter.Write(btn.FlatStyle)
    '                binWriter.Write(btn.Font.Name)
    '                binWriter.Write(btn.Font.Size)
    '                binWriter.Write(GetFontStyle(btn.Font.Style))

    '                If GetColorType(btn.ForeColor) = True Then
    '                    binWriter.Write(GetColorType(btn.ForeColor))
    '                    binWriter.Write(btn.ForeColor.ToKnownColor)
    '                Else
    '                    binWriter.Write(GetColorType(btn.ForeColor))
    '                    binWriter.Write(btn.ForeColor.ToArgb)
    '                End If

    '                binWriter.Write(btn.ImageAlign)
    '                binWriter.Write(btn.Location.X)
    '                binWriter.Write(btn.Location.Y)
    '                binWriter.Write(btn.MaximumSize.Height)
    '                binWriter.Write(btn.MaximumSize.Width)
    '                binWriter.Write(btn.MinimumSize.Height)
    '                binWriter.Write(btn.MinimumSize.Width)
    '                binWriter.Write(btn.RightToLeft)
    '                binWriter.Write(btn.Size.Height)
    '                binWriter.Write(btn.Size.Width)
    '                binWriter.Write(btn.TabIndex)
    '                binWriter.Write(btn.TabStop)
    '                binWriter.Write(btn.Text)
    '                binWriter.Write(btn.TextAlign)
    '                binWriter.Write(btn.TextImageRelation)
    '                binWriter.Write(btn.UseMnemonic)
    '                binWriter.Write(btn.UseVisualStyleBackColor)
    '                binWriter.Write(btn.UseWaitCursor)
    '                binWriter.Write(btn.Name + buttons.GetIndex(btn).ToString)
    '            Finally
    '                binWriter.Close()
    '            End Try

    '            If Not btn.BackgroundImage Is Nothing Then
    '                btn.BackgroundImage.Save(proPath + "\Resources\images\" + btn.Name + ".bimage", btn.BackgroundImage.RawFormat)
    '                '    sb.AppendLine("RESOURCE:" + proPath + "\Resources\images\" + btn.Name + ".bimage")
    '            End If
    '            If Not btn.Image Is Nothing Then
    '                btn.Image.Save(proPath + "\Resources\images\" + btn.Name + ".image", btn.Image.RawFormat)
    '                'sb.AppendLine("RESOURCE:" + proPath + "\Resources\images\" + btn.Name + ".image")
    '            End If

    '        ElseIf TypeOf cn Is LinkLabel Then

    '            lblL = cn

    '            'sb.AppendLine("PROPERTIES:" + proPath + "\" + lblL.Name + ".p")

    '            Dim binWriter As New BinaryWriter( _
    '        File.Open(proPath + "\" + lblL.Name + ".p", FileMode.Create))

    '            Try
    '                binWriter.Write("mBP_i")
    '                binWriter.Write(lblL.Name)

    '                If GetColorType(lblL.ActiveLinkColor) = True Then
    '                    binWriter.Write(GetColorType(lblL.ActiveLinkColor))
    '                    binWriter.Write(lblL.ActiveLinkColor.ToKnownColor)
    '                Else
    '                    binWriter.Write(GetColorType(lblL.ActiveLinkColor))
    '                    binWriter.Write(lblL.ActiveLinkColor.ToArgb)
    '                End If

    '                binWriter.Write(lblL.AutoSize)

    '                If GetColorType(lblL.BackColor) = True Then
    '                    binWriter.Write(GetColorType(lblL.BackColor))
    '                    binWriter.Write(lblL.BackColor.ToKnownColor)
    '                Else
    '                    binWriter.Write(GetColorType(lblL.BackColor))
    '                    binWriter.Write(lblL.BackColor.ToArgb)
    '                End If

    '                binWriter.Write(GetCursor(lblL.Cursor))

    '                If GetColorType(lblL.DisabledLinkColor) = True Then
    '                    binWriter.Write(GetColorType(lblL.DisabledLinkColor))
    '                    binWriter.Write(lblL.DisabledLinkColor.ToKnownColor)
    '                Else
    '                    binWriter.Write(GetColorType(lblL.DisabledLinkColor))
    '                    binWriter.Write(lblL.DisabledLinkColor.ToArgb)
    '                End If

    '                binWriter.Write(lblL.Dock)
    '                binWriter.Write(lblL.Font.Name)
    '                binWriter.Write(lblL.Font.Size)
    '                binWriter.Write(GetFontStyle(lblL.Font.Style))

    '                If GetColorType(lblL.ForeColor) = True Then
    '                    binWriter.Write(GetColorType(lblL.ForeColor))
    '                    binWriter.Write(lblL.ForeColor.ToKnownColor)
    '                Else
    '                    binWriter.Write(GetColorType(lblL.ForeColor))
    '                    binWriter.Write(lblL.ForeColor.ToArgb)
    '                End If

    '                binWriter.Write(lblL.ImageAlign)
    '                binWriter.Write(lblL.LinkArea.Start)
    '                binWriter.Write(lblL.LinkArea.Length)
    '                binWriter.Write(lblL.LinkBehavior)

    '                If GetColorType(lblL.LinkColor) = True Then
    '                    binWriter.Write(GetColorType(lblL.LinkColor))
    '                    binWriter.Write(lblL.LinkColor.ToKnownColor)
    '                Else
    '                    binWriter.Write(GetColorType(lblL.LinkColor))
    '                    binWriter.Write(lblL.LinkColor.ToArgb)
    '                End If

    '                binWriter.Write(lblL.LinkVisited)
    '                binWriter.Write(lblL.Location.X)
    '                binWriter.Write(lblL.Location.Y)
    '                binWriter.Write(lblL.MaximumSize.Height)
    '                binWriter.Write(lblL.MaximumSize.Width)
    '                binWriter.Write(lblL.MinimumSize.Height)
    '                binWriter.Write(lblL.MinimumSize.Width)
    '                binWriter.Write(lblL.RightToLeft)
    '                binWriter.Write(lblL.Size.Height)
    '                binWriter.Write(lblL.Size.Width)
    '                binWriter.Write(lblL.TabIndex)
    '                binWriter.Write(lblL.TabStop)
    '                binWriter.Write(lblL.Text)
    '                binWriter.Write(lblL.TextAlign)
    '                binWriter.Write(lblL.UseMnemonic)
    '                binWriter.Write(lblL.UseWaitCursor)
    '                binWriter.Write(lblL.VisitedLinkColor.ToArgb)
    '            Finally
    '                binWriter.Close()
    '            End Try

    '            If Not lblL.Image Is Nothing Then
    '                lblL.Image.Save(proPath + "\Resources\images\" + lblL.Name + ".image", lblL.Image.RawFormat)
    '                'sb.AppendLine("RESOURCE:" + proPath + "\Resources\images\" + lblL.Name + ".image")
    '            End If

    '        ElseIf TypeOf cn Is Label Then

    '            lbl = cn

    '            'sb.AppendLine("PROPERTIES:" + proPath + "\" + lbl.Name + ".p")

    '            Dim binWriter As New BinaryWriter( _
    '        File.Open(proPath + "\" + lbl.Name + ".p", FileMode.Create))

    '            Try
    '                binWriter.Write("mBP_l")
    '                binWriter.Write(lbl.Name)
    '                binWriter.Write(lbl.AutoSize)

    '                If GetColorType(lbl.BackColor) = True Then
    '                    binWriter.Write(GetColorType(lbl.BackColor))
    '                    binWriter.Write(lbl.BackColor.ToKnownColor)
    '                Else
    '                    binWriter.Write(GetColorType(lbl.BackColor))
    '                    binWriter.Write(lbl.BackColor.ToArgb)
    '                End If

    '                binWriter.Write(lbl.BorderStyle)
    '                binWriter.Write(GetCursor(lbl.Cursor))
    '                binWriter.Write(lbl.Dock)
    '                binWriter.Write(lbl.FlatStyle)
    '                binWriter.Write(lbl.Font.Name)
    '                binWriter.Write(lbl.Font.Size)
    '                binWriter.Write(GetFontStyle(lbl.Font.Style))

    '                If GetColorType(lbl.ForeColor) = True Then
    '                    binWriter.Write(GetColorType(lbl.ForeColor))
    '                    binWriter.Write(lbl.ForeColor.ToKnownColor)
    '                Else
    '                    binWriter.Write(GetColorType(lbl.ForeColor))
    '                    binWriter.Write(lbl.ForeColor.ToArgb)
    '                End If

    '                binWriter.Write(lbl.ImageAlign)
    '                binWriter.Write(lbl.Location.X)
    '                binWriter.Write(lbl.Location.Y)
    '                binWriter.Write(lbl.MaximumSize.Height)
    '                binWriter.Write(lbl.MaximumSize.Width)
    '                binWriter.Write(lbl.MinimumSize.Height)
    '                binWriter.Write(lbl.MinimumSize.Width)
    '                binWriter.Write(lbl.RightToLeft)
    '                binWriter.Write(lbl.Size.Height)
    '                binWriter.Write(lbl.Size.Width)
    '                binWriter.Write(lbl.TabIndex)
    '                binWriter.Write(lbl.Text)
    '                binWriter.Write(lbl.TextAlign)
    '                binWriter.Write(lbl.UseMnemonic)
    '                binWriter.Write(lbl.UseWaitCursor)
    '            Finally
    '                binWriter.Close()
    '            End Try

    '            If Not lbl.Image Is Nothing Then
    '                lbl.Image.Save(proPath + "\Resources\images\" + lbl.Name + ".image", lbl.Image.RawFormat)
    '                'sb.AppendLine("RESOURCE:" + proPath + "\Resources\images\" + lbl.Name + ".image")
    '            End If

    '        End If
    '    Next

    '    'sb.AppendLine("PROPERTIES:" + proPath + "\" + proName + ".p")

    '    Dim PWriter As New BinaryWriter( _
    'File.Open(proPath + "\" + proName + ".p", FileMode.Create))

    '    Try
    '        PWriter.Write("mBP_f")

    '        If GetColorType(DesignWin.BackColor) = True Then
    '            PWriter.Write(GetColorType(DesignWin.BackColor))
    '            PWriter.Write(DesignWin.BackColor.ToKnownColor)
    '        Else
    '            PWriter.Write(GetColorType(DesignWin.BackColor))
    '            PWriter.Write(DesignWin.BackColor.ToArgb)
    '        End If

    '        If Not DesignWin.BackgroundImage Is Nothing Then
    '            PWriter.Write(True)
    '            DesignWin.BackgroundImage.Save(proPath + "\Resources\images\" + proName + ".bimage", DesignWin.BackgroundImage.RawFormat)
    '            PWriter.Write(proPath + "\Resources\images\" + proName + ".bimage")
    '        Else
    '            PWriter.Write(False)
    '        End If

    '        PWriter.Write(DesignWin.BackgroundImageLayout)
    '        PWriter.Write(DesignWin.ControlBox)
    '        PWriter.Write(GetCursor(DesignWin.Cursor))
    '        PWriter.Write(DesignWin.Font.Name)
    '        PWriter.Write(DesignWin.Font.Size)
    '        PWriter.Write(GetFontStyle(DesignWin.Font.Style))

    '        If GetColorType(DesignWin.ForeColor) = True Then
    '            PWriter.Write(GetColorType(DesignWin.ForeColor))
    '            PWriter.Write(DesignWin.ForeColor.ToKnownColor)
    '        Else
    '            PWriter.Write(GetColorType(DesignWin.ForeColor))
    '            PWriter.Write(DesignWin.ForeColor.ToArgb)
    '        End If

    '        PWriter.Write(DesignWin.FormBorderStyle)
    '        PWriter.Write(DesignWin.MaximizeBox)
    '        PWriter.Write(DesignWin.MaximumSize.Height)
    '        PWriter.Write(DesignWin.MaximumSize.Width)
    '        PWriter.Write(DesignWin.MinimizeBox)
    '        PWriter.Write(DesignWin.MinimumSize.Height)
    '        PWriter.Write(DesignWin.MinimumSize.Width)
    '        PWriter.Write(DesignWin.Opacity)
    '        PWriter.Write(DesignWin.Padding.All)
    '        PWriter.Write(DesignWin.RightToLeft)
    '        PWriter.Write(DesignWin.RightToLeftLayout)
    '        PWriter.Write(DesignWin.ShowIcon)
    '        PWriter.Write(DesignWin.ShowInTaskbar)
    '        PWriter.Write(DesignWin.Size.Height)
    '        PWriter.Write(DesignWin.Size.Width)
    '        PWriter.Write(DesignWin.SizeGripStyle)
    '        PWriter.Write(DesignWin.StartPosition)
    '        PWriter.Write(DesignWin.Text)
    '        PWriter.Write(DesignWin.TopMost)

    '        If GetColorType(DesignWin.TransparencyKey) = True Then
    '            PWriter.Write(GetColorType(DesignWin.TransparencyKey))
    '            PWriter.Write(DesignWin.TransparencyKey.ToKnownColor)
    '        Else
    '            PWriter.Write(GetColorType(DesignWin.TransparencyKey))
    '            PWriter.Write(DesignWin.TransparencyKey.ToArgb)
    '        End If

    '        PWriter.Write(DesignWin.UseWaitCursor)
    '        PWriter.Write(DesignWin.WindowState)
    '        Dim asas As Stream = New FileStream(proPath + "\Resources\images\" + proName + ".ico", FileMode.Create)

    '        If Not DesignWin.Icon Is Nothing Then
    '            PWriter.Write(True)
    '            DesignWin.Icon.Save(asas)
    '            PWriter.Write(proPath + "\Resources\images\" + proName + ".ico")
    '        Else
    '            PWriter.Write(False)
    '        End If
    '    Finally
    '        PWriter.Close()
    '    End Try

    '    'Using outfile As New StreamWriter(proPath + "\" + proName + ".pro")
    '    '    outfile.Write(sb.ToString())
    '    'End Using

    'End Sub

    Private Sub save()
        'Create a directory to save all resources
        Try
            Directory.CreateDirectory(proPath + "\Resources")
        Catch
        End Try

        'To write solution
        Dim sb As New StringBuilder()

        'Save form properties
        sb.AppendLine(proPath + "\" + DesignWin.Text + ".p")

        Dim PWriter As New BinaryWriter( _
    File.Open(proPath + "\" + DesignWin.Text + ".p", FileMode.Create))

        Try
            PWriter.Write("AMB`")
            If GetColorType(DesignWin.BackColor) = True Then
                PWriter.Write(GetColorType(DesignWin.BackColor))
                PWriter.Write(DesignWin.BackColor.ToKnownColor)
            Else
                PWriter.Write(GetColorType(DesignWin.BackColor))
                PWriter.Write(DesignWin.BackColor.ToArgb)
            End If

            If Not DesignWin.BackgroundImage Is Nothing Then
                PWriter.Write(True)
                DesignWin.BackgroundImage.Save(proPath + "\Resources\images\" + proName + ".bimage", DesignWin.BackgroundImage.RawFormat)
                PWriter.Write(proPath + "\Resources\images\" + proName + ".bimage")
            Else
                PWriter.Write(False)
            End If

            PWriter.Write(DesignWin.BackgroundImageLayout)
            PWriter.Write(DesignWin.ControlBox)
            PWriter.Write(GetCursor(DesignWin.Cursor))
            PWriter.Write(DesignWin.Font.Name)
            PWriter.Write(DesignWin.Font.Size)
            PWriter.Write(GetFontStyle(DesignWin.Font.Style))

            If GetColorType(DesignWin.ForeColor) = True Then
                PWriter.Write(GetColorType(DesignWin.ForeColor))
                PWriter.Write(DesignWin.ForeColor.ToKnownColor)
            Else
                PWriter.Write(GetColorType(DesignWin.ForeColor))
                PWriter.Write(DesignWin.ForeColor.ToArgb)
            End If

            PWriter.Write(DesignWin.FormBorderStyle)
            PWriter.Write(DesignWin.MaximizeBox)
            PWriter.Write(DesignWin.MaximumSize.Height)
            PWriter.Write(DesignWin.MaximumSize.Width)
            PWriter.Write(DesignWin.MinimizeBox)
            PWriter.Write(DesignWin.MinimumSize.Height)
            PWriter.Write(DesignWin.MinimumSize.Width)
            PWriter.Write(DesignWin.Opacity)
            PWriter.Write(DesignWin.Padding.All)
            PWriter.Write(DesignWin.RightToLeft)
            PWriter.Write(DesignWin.RightToLeftLayout)
            PWriter.Write(DesignWin.ShowIcon)
            PWriter.Write(DesignWin.ShowInTaskbar)
            PWriter.Write(DesignWin.Size.Height)
            PWriter.Write(DesignWin.Size.Width)
            PWriter.Write(DesignWin.SizeGripStyle)
            PWriter.Write(DesignWin.StartPosition)
            PWriter.Write(DesignWin.Text)
            PWriter.Write(DesignWin.TopMost)

            If GetColorType(DesignWin.TransparencyKey) = True Then
                PWriter.Write(GetColorType(DesignWin.TransparencyKey))
                PWriter.Write(DesignWin.TransparencyKey.ToKnownColor)
            Else
                PWriter.Write(GetColorType(DesignWin.TransparencyKey))
                PWriter.Write(DesignWin.TransparencyKey.ToArgb)
            End If

            PWriter.Write(DesignWin.UseWaitCursor)
            PWriter.Write(DesignWin.WindowState)
            Dim asas As Stream = New FileStream(proPath + "\Resources\images\" + proName + ".ico", FileMode.Create)

            If Not DesignWin.Icon Is Nothing Then
                PWriter.Write(True)
                DesignWin.Icon.Save(asas)
                PWriter.Write(proPath + "\Resources\images\" + proName + ".ico")
            Else
                PWriter.Write(False)
            End If

            PWriter.Write(DesignWin.Controls.Count)

        Finally
            PWriter.Close()
        End Try


        'get all cntrls
        For Each cn As Control In DesignWin.Controls


            'Save btn properties
            If TypeOf cn Is Button Then
                btn = cn 'to get properties

                sb.AppendLine(proPath + "\" + btn.Name + ".p")

                Dim binWriter As New BinaryWriter( _
            File.Open(proPath + "\" + btn.Name + ".p", FileMode.Create))

                Try
                    PWriter.Write("AMB`")
                    binWriter.Write(btn.Name)
                    binWriter.Write(btn.AutoSize)

                    If GetColorType(btn.BackColor) = True Then
                        binWriter.Write(GetColorType(btn.BackColor))
                        binWriter.Write(btn.BackColor.ToKnownColor)
                    Else
                        binWriter.Write(GetColorType(btn.BackColor))
                        binWriter.Write(btn.BackColor.ToArgb)
                    End If

                    If Not btn.BackgroundImage Is Nothing Then
                        binWriter.Write(True)
                        btn.BackgroundImage.Save(proPath + "\Resources\images\" + btn.Name + ".bimage", btn.BackgroundImage.RawFormat)
                        binWriter.Write(proPath + "\Resources\images\" + btn.Name + ".bimage")
                    Else
                        binWriter.Write(False)
                    End If

                    binWriter.Write(btn.BackgroundImageLayout)
                    binWriter.Write(GetCursor(btn.Cursor))
                    binWriter.Write(btn.Dock)

                    If GetColorType(btn.FlatAppearance.BorderColor) = True Then
                        binWriter.Write(GetColorType(btn.FlatAppearance.BorderColor))
                        binWriter.Write(btn.FlatAppearance.BorderColor.ToKnownColor)
                    Else
                        binWriter.Write(GetColorType(btn.FlatAppearance.BorderColor))
                        binWriter.Write(btn.FlatAppearance.BorderColor.ToArgb)
                    End If

                    binWriter.Write(btn.FlatAppearance.BorderSize)

                    If GetColorType(btn.FlatAppearance.CheckedBackColor) = True Then
                        binWriter.Write(GetColorType(btn.FlatAppearance.CheckedBackColor))
                        binWriter.Write(btn.FlatAppearance.CheckedBackColor.ToKnownColor)
                    Else
                        binWriter.Write(GetColorType(btn.FlatAppearance.CheckedBackColor))
                        binWriter.Write(btn.FlatAppearance.CheckedBackColor.ToArgb)
                    End If

                    If GetColorType(btn.FlatAppearance.MouseDownBackColor) = True Then
                        binWriter.Write(GetColorType(btn.FlatAppearance.MouseDownBackColor))
                        binWriter.Write(btn.FlatAppearance.MouseDownBackColor.ToKnownColor)
                    Else
                        binWriter.Write(GetColorType(btn.FlatAppearance.MouseDownBackColor))
                        binWriter.Write(btn.FlatAppearance.MouseDownBackColor.ToArgb)
                    End If

                    If GetColorType(btn.FlatAppearance.MouseOverBackColor) = True Then
                        binWriter.Write(GetColorType(btn.FlatAppearance.MouseOverBackColor))
                        binWriter.Write(btn.FlatAppearance.MouseOverBackColor.ToKnownColor)
                    Else
                        binWriter.Write(GetColorType(btn.FlatAppearance.MouseOverBackColor))
                        binWriter.Write(btn.FlatAppearance.MouseOverBackColor.ToArgb)
                    End If

                    binWriter.Write(btn.FlatStyle)
                    binWriter.Write(btn.Font.Name)
                    binWriter.Write(btn.Font.Size)
                    binWriter.Write(GetFontStyle(btn.Font.Style))

                    If GetColorType(btn.ForeColor) = True Then
                        binWriter.Write(GetColorType(btn.ForeColor))
                        binWriter.Write(btn.ForeColor.ToKnownColor)
                    Else
                        binWriter.Write(GetColorType(btn.ForeColor))
                        binWriter.Write(btn.ForeColor.ToArgb)
                    End If

                    If Not btn.Image Is Nothing Then
                        binWriter.Write(True)
                        btn.Image.Save(proPath + "\Resources\images\" + btn.Name + ".image", btn.Image.RawFormat)
                        binWriter.Write(proPath + "\Resources\images\" + btn.Name + ".image")
                    End If

                    binWriter.Write(btn.ImageAlign)
                    binWriter.Write(btn.Location.X)
                    binWriter.Write(btn.Location.Y)
                    binWriter.Write(btn.MaximumSize.Height)
                    binWriter.Write(btn.MaximumSize.Width)
                    binWriter.Write(btn.MinimumSize.Height)
                    binWriter.Write(btn.MinimumSize.Width)
                    binWriter.Write(btn.RightToLeft)
                    binWriter.Write(btn.Size.Height)
                    binWriter.Write(btn.Size.Width)
                    binWriter.Write(btn.TabIndex)
                    binWriter.Write(btn.TabStop)
                    binWriter.Write(btn.Text)
                    binWriter.Write(btn.TextAlign)
                    binWriter.Write(btn.TextImageRelation)
                    binWriter.Write(btn.UseMnemonic)
                    binWriter.Write(btn.UseVisualStyleBackColor)
                    binWriter.Write(btn.UseWaitCursor)
                    binWriter.Write(btn.Name + buttons.GetIndex(btn).ToString)
                Finally
                    binWriter.Close()
                End Try


                'Save linklbl properties
            ElseIf TypeOf cn Is LinkLabel Then
                lblL = cn

                sb.AppendLine(proPath + "\" + lblL.Name + ".p")

                Dim binWriter As New BinaryWriter( _
            File.Open(proPath + "\" + lblL.Name + ".p", FileMode.Create))

                Try
                    PWriter.Write("AMB`")
                    binWriter.Write(lblL.Name)

                    If GetColorType(lblL.ActiveLinkColor) = True Then
                        binWriter.Write(GetColorType(lblL.ActiveLinkColor))
                        binWriter.Write(lblL.ActiveLinkColor.ToKnownColor)
                    Else
                        binWriter.Write(GetColorType(lblL.ActiveLinkColor))
                        binWriter.Write(lblL.ActiveLinkColor.ToArgb)
                    End If

                    binWriter.Write(lblL.AutoSize)

                    If GetColorType(lblL.BackColor) = True Then
                        binWriter.Write(GetColorType(lblL.BackColor))
                        binWriter.Write(lblL.BackColor.ToKnownColor)
                    Else
                        binWriter.Write(GetColorType(lblL.BackColor))
                        binWriter.Write(lblL.BackColor.ToArgb)
                    End If

                    binWriter.Write(GetCursor(lblL.Cursor))

                    If GetColorType(lblL.DisabledLinkColor) = True Then
                        binWriter.Write(GetColorType(lblL.DisabledLinkColor))
                        binWriter.Write(lblL.DisabledLinkColor.ToKnownColor)
                    Else
                        binWriter.Write(GetColorType(lblL.DisabledLinkColor))
                        binWriter.Write(lblL.DisabledLinkColor.ToArgb)
                    End If

                    binWriter.Write(lblL.Dock)
                    binWriter.Write(lblL.Font.Name)
                    binWriter.Write(lblL.Font.Size)
                    binWriter.Write(GetFontStyle(lblL.Font.Style))

                    If GetColorType(lblL.ForeColor) = True Then
                        binWriter.Write(GetColorType(lblL.ForeColor))
                        binWriter.Write(lblL.ForeColor.ToKnownColor)
                    Else
                        binWriter.Write(GetColorType(lblL.ForeColor))
                        binWriter.Write(lblL.ForeColor.ToArgb)
                    End If

                    If Not lblL.Image Is Nothing Then
                        binWriter.Write(True)
                        lblL.Image.Save(proPath + "\Resources\images\" + lblL.Name + ".image", lblL.Image.RawFormat)
                        binWriter.Write(proPath + "\Resources\images\" + lblL.Name + ".image")
                    Else
                        binWriter.Write(False)
                    End If

                    binWriter.Write(lblL.ImageAlign)
                    binWriter.Write(lblL.LinkArea.Start)
                    binWriter.Write(lblL.LinkArea.Length)
                    binWriter.Write(lblL.LinkBehavior)

                    If GetColorType(lblL.LinkColor) = True Then
                        binWriter.Write(GetColorType(lblL.LinkColor))
                        binWriter.Write(lblL.LinkColor.ToKnownColor)
                    Else
                        binWriter.Write(GetColorType(lblL.LinkColor))
                        binWriter.Write(lblL.LinkColor.ToArgb)
                    End If

                    binWriter.Write(lblL.LinkVisited)
                    binWriter.Write(lblL.Location.X)
                    binWriter.Write(lblL.Location.Y)
                    binWriter.Write(lblL.MaximumSize.Height)
                    binWriter.Write(lblL.MaximumSize.Width)
                    binWriter.Write(lblL.MinimumSize.Height)
                    binWriter.Write(lblL.MinimumSize.Width)
                    binWriter.Write(lblL.RightToLeft)
                    binWriter.Write(lblL.Size.Height)
                    binWriter.Write(lblL.Size.Width)
                    binWriter.Write(lblL.TabIndex)
                    binWriter.Write(lblL.TabStop)
                    binWriter.Write(lblL.Text)
                    binWriter.Write(lblL.TextAlign)
                    binWriter.Write(lblL.UseMnemonic)
                    binWriter.Write(lblL.UseWaitCursor)
                    binWriter.Write(lblL.VisitedLinkColor.ToArgb)
                Finally
                    binWriter.Close()
                End Try


                'Save lbl properties
            ElseIf TypeOf cn Is Label Then

                lbl = cn

                sb.AppendLine(proPath + "\" + lbl.Name + ".p")

                Dim binWriter As New BinaryWriter( _
            File.Open(proPath + "\" + lbl.Name + ".p", FileMode.Create))

                Try
                    PWriter.Write("AMB`")
                    binWriter.Write(lbl.Name)
                    binWriter.Write(lbl.AutoSize)

                    If GetColorType(lbl.BackColor) = True Then
                        binWriter.Write(GetColorType(lbl.BackColor))
                        binWriter.Write(lbl.BackColor.ToKnownColor)
                    Else
                        binWriter.Write(GetColorType(lbl.BackColor))
                        binWriter.Write(lbl.BackColor.ToArgb)
                    End If

                    binWriter.Write(lbl.BorderStyle)
                    binWriter.Write(GetCursor(lbl.Cursor))
                    binWriter.Write(lbl.Dock)
                    binWriter.Write(lbl.FlatStyle)
                    binWriter.Write(lbl.Font.Name)
                    binWriter.Write(lbl.Font.Size)
                    binWriter.Write(GetFontStyle(lbl.Font.Style))

                    If GetColorType(lbl.ForeColor) = True Then
                        binWriter.Write(GetColorType(lbl.ForeColor))
                        binWriter.Write(lbl.ForeColor.ToKnownColor)
                    Else
                        binWriter.Write(GetColorType(lbl.ForeColor))
                        binWriter.Write(lbl.ForeColor.ToArgb)
                    End If

                    If Not lbl.Image Is Nothing Then
                        binWriter.Write(True)
                        lbl.Image.Save(proPath + "\Resources\images\" + lbl.Name + ".image", lbl.Image.RawFormat)
                        binWriter.Write(proPath + "\Resources\images\" + lbl.Name + ".image")
                    Else
                        binWriter.Write(False)
                    End If

                    binWriter.Write(lbl.ImageAlign)
                    binWriter.Write(lbl.Location.X)
                    binWriter.Write(lbl.Location.Y)
                    binWriter.Write(lbl.MaximumSize.Height)
                    binWriter.Write(lbl.MaximumSize.Width)
                    binWriter.Write(lbl.MinimumSize.Height)
                    binWriter.Write(lbl.MinimumSize.Width)
                    binWriter.Write(lbl.RightToLeft)
                    binWriter.Write(lbl.Size.Height)
                    binWriter.Write(lbl.Size.Width)
                    binWriter.Write(lbl.TabIndex)
                    binWriter.Write(lbl.Text)
                    binWriter.Write(lbl.TextAlign)
                    binWriter.Write(lbl.UseMnemonic)
                    binWriter.Write(lbl.UseWaitCursor)
                Finally
                    binWriter.Close()
                End Try
            End If
        Next

        Using outfile As New StreamWriter(proPath + "\" + proName + ".ARmPro")
            outfile.Write(sb.ToString())
        End Using

    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        save()
    End Sub

    Private Function GetCursor(ByVal cur As Cursor) As Integer
        Select Case cur
            Case Cursors.AppStarting
                Return 0
            Case Cursors.Arrow
                Return 1
            Case Cursors.Cross
                Return 2
            Case Cursors.Default
                Return 3
            Case Cursors.Hand
                Return 4
            Case Cursors.Help
                Return 5
            Case Cursors.HSplit
                Return 6
            Case Cursors.IBeam
                Return 7
            Case Cursors.No
                Return 8
            Case Cursors.NoMove2D
                Return 9
            Case Cursors.NoMoveHoriz
                Return 10
            Case Cursors.NoMoveVert
                Return 11
            Case Cursors.PanEast
                Return 12
            Case Cursors.PanNE
                Return 13
            Case Cursors.PanNorth
                Return 14
            Case Cursors.PanNW
                Return 15
            Case Cursors.PanSE
                Return 16
            Case Cursors.PanSouth
                Return 17
            Case Cursors.PanSW
                Return 18
            Case Cursors.PanWest
                Return 19
            Case Cursors.SizeAll
                Return 20
            Case Cursors.SizeNESW
                Return 21
            Case Cursors.SizeNS
                Return 22
            Case Cursors.SizeNWSE
                Return 23
            Case Cursors.SizeWE
                Return 24
            Case Cursors.UpArrow
                Return 25
            Case Cursors.VSplit
                Return 26
            Case Cursors.WaitCursor
                Return 27
        End Select
        Return 3
    End Function

    Private Function GetFontStyle(ByVal fnt As FontStyle) As Integer
        Select Case fnt
            Case FontStyle.Bold
                Return 0
            Case FontStyle.Italic
                Return 1
            Case FontStyle.Regular
                Return 2
            Case FontStyle.Strikeout
                Return 3
            Case FontStyle.Underline
                Return 4
        End Select
        Return 2
    End Function

    Private Function GetColorType(ByVal clr As Color) As Boolean
        If clr.IsNamedColor Then
            Return True 'clr.ToKnownColor()
        Else
            Return False ' clr.ToArgb()
        End If
    End Function

    Private Function SetCursor(ByVal cur As Integer) As Cursor
        Select Case cur
            Case 0
                Return Cursors.AppStarting
            Case 1
                Return Cursors.Arrow
            Case 2
                Return Cursors.Cross
            Case 3
                Return Cursors.Default
            Case 4
                Return Cursors.Hand
            Case 5
                Return Cursors.Help
            Case 6
                Return Cursors.HSplit
            Case 7
                Return Cursors.IBeam
            Case 8
                Return Cursors.No
            Case 9
                Return Cursors.NoMove2D
            Case 10
                Return Cursors.NoMoveHoriz
            Case 11
                Return Cursors.NoMoveVert
            Case 12
                Return Cursors.PanEast
            Case 13
                Return Cursors.PanNE
            Case 14
                Return Cursors.PanNorth
            Case 15
                Return Cursors.PanNW
            Case 16
                Return Cursors.PanSE
            Case 17
                Return Cursors.PanSouth
            Case 18
                Return Cursors.PanSW
            Case 19
                Return Cursors.PanWest
            Case 20
                Return Cursors.SizeAll
            Case 21
                Return Cursors.SizeNESW
            Case 22
                Return Cursors.SizeNS
            Case 23
                Return Cursors.SizeNWSE
            Case 24
                Return Cursors.SizeWE
            Case 25
                Return Cursors.UpArrow
            Case 26
                Return Cursors.VSplit
            Case 27
                Return Cursors.WaitCursor
        End Select
        Return Cursors.Default
    End Function

    Private Function SetFontStyle(ByVal fnt As Integer) As FontStyle
        Select Case fnt
            Case 0
                Return FontStyle.Bold
            Case 1
                Return FontStyle.Italic
            Case 2
                Return FontStyle.Regular
            Case 3
                Return FontStyle.Strikeout
            Case 4
                Return FontStyle.Underline
        End Select
        Return FontStyle.Regular
    End Function

    ''open the project
    'Private Sub open()
    '    Using sr As StreamReader = New StreamReader("C:\Users\Damith\Documents\Menu Builder\Projects\a\a.pro")
    '        Dim line As String
    '        proName = sr.ReadLine()
    '        formMake()
    '        Do
    '            line = sr.ReadLine()
    '            If line.StartsWith("PROPERTIES") = True Then

    '            End If

    '        Loop Until line Is Nothing
    '    End Using
    'End Sub

    'Private Sub formMake()
    '    clean1()
    '    clean2()
    '    linklabels = New LinkLabelArray
    '    labels = New LabelArray
    '    buttons = New ButtonArray
    '    DesignWin.Controls.Clear()
    '    i = 0
    '    j = 0
    '    k = 0
    '    p = True
    '    PropertiesBox.Controls.Add(prp)

    '    DesignWin.MdiParent = Me
    '    DesignWin.Text = proName

    '    Dim binReader As New BinaryReader( _
    '        File.Open("C:\Users\Damith\Documents\Menu Builder\Projects\a\" + proName + ".p", FileMode.Open))
    '    binReader.BaseStream.Seek(0, SeekOrigin.Begin)

    '    binReader.ReadString()

    '    If binReader.ReadBoolean = True Then
    '        DesignWin.BackColor = Color.FromKnownColor(binReader.ReadInt32())
    '    Else
    '        DesignWin.BackColor = Color.FromArgb(binReader.ReadInt32())
    '    End If

    '    If binReader.ReadBoolean = True Then
    '        DesignWin.BackgroundImage = Image.FromFile(binReader.ReadString)
    '    End If

    '    DesignWin.BackgroundImageLayout = binReader.ReadInt32()
    '    DesignWin.ControlBox = binReader.ReadBoolean()
    '    DesignWin.Cursor = SetCursor(binReader.ReadInt32())
    '    DesignWin.Font = New Font(binReader.ReadString, binReader.ReadSingle, SetFontStyle(binReader.ReadInt32()))

    '    If binReader.ReadBoolean = True Then
    '        DesignWin.ForeColor = Color.FromKnownColor(binReader.ReadInt32())
    '    Else
    '        DesignWin.ForeColor = Color.FromArgb(binReader.ReadInt32())
    '    End If

    '    DesignWin.FormBorderStyle = binReader.ReadInt32
    '    DesignWin.MaximizeBox = binReader.ReadBoolean()
    '    DesignWin.MaximumSize = New Point(binReader.ReadInt32, binReader.ReadInt32)
    '    DesignWin.MinimizeBox = binReader.ReadBoolean()
    '    DesignWin.MinimumSize = New Point(binReader.ReadInt32, binReader.ReadInt32)
    '    DesignWin.Opacity = binReader.ReadDouble()
    '    DesignWin.Padding = New System.Windows.Forms.Padding(binReader.ReadInt32())
    '    DesignWin.RightToLeft = binReader.ReadInt32()
    '    DesignWin.RightToLeftLayout = binReader.ReadBoolean()
    '    DesignWin.ShowIcon = binReader.ReadBoolean()
    '    DesignWin.ShowInTaskbar = binReader.ReadBoolean()
    '    DesignWin.Size = New Point(binReader.ReadInt32(), binReader.ReadInt32())
    '    DesignWin.SizeGripStyle = binReader.ReadInt32()
    '    DesignWin.StartPosition = binReader.ReadInt32()
    '    DesignWin.Text = binReader.ReadString()
    '    DesignWin.TopMost = binReader.ReadBoolean()

    '    If binReader.ReadBoolean = True Then
    '        DesignWin.TransparencyKey = Color.FromKnownColor(binReader.ReadInt32())
    '    Else
    '        DesignWin.TransparencyKey = Color.FromArgb(binReader.ReadInt32())
    '    End If

    '    DesignWin.UseWaitCursor = binReader.ReadBoolean()
    '    DesignWin.WindowState = binReader.ReadInt32()

    '    If binReader.ReadBoolean = True Then
    '        DesignWin.Icon = New Icon(binReader.ReadString)
    '    End If

    '    DesignWin.Show()
    '    binReader.Dispose()

    'End Sub

    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click
        'open()
    End Sub

End Class

'p
'bimage
'image
'ico
'pro
