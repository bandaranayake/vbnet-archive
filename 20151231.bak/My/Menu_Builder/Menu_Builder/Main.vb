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
            CmdWin.Hide()
        ElseIf CodeWindowToolStripMenuItem.Checked = True Then
            CmdWin.Show()
        End If
    End Sub

    'arrange all win-code,desing
    Private Sub ArrangeWindowsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ArrangeWindowsToolStripMenuItem.Click
        DesignWin.Location = New Point(0, 0)
        CmdWin.Location = New Point(DesignWin.Width + 5, 0)
    End Sub

    'hide all win-code,desing
    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseAllToolStripMenuItem.Click
        DesignWindowToolStripMenuItem.Checked = False
        DesignWin.Hide()
        CodeWindowToolStripMenuItem.Checked = False
        CmdWin.Hide()
    End Sub

    'show all win-code,desing
    Private Sub ShowStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowStripMenuItem.Click
        DesignWindowToolStripMenuItem.Checked = True
        DesignWin.Show()
        CodeWindowToolStripMenuItem.Checked = True
        CmdWin.Show()
    End Sub

    'New window
    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        If (Pwin.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            proName = Pwin.TextBox1.Text

            clean1()
            clean2()

            linklabels = New LinkLabelArray
            labels = New LabelArray
            buttons = New ButtonArray
            DesignWin.Controls.Clear()
            i = 0
            j = 0
            k = 0

            DesignWindowToolStripMenuItem.Enabled = True

            PropertiesBox.Controls.Add(prp)

            DesignWin.MdiParent = Me
            DesignWin.Text = proName
            DesignWin.Icon = My.Resources.Design
            DesignWin.Location = New Point(0, 0)
            AddHandler DesignWin.FormClosing, AddressOf DesignClosing 'to hide when closing
            AddHandler DesignWin.MouseMove, AddressOf XY 'location
            AddHandler DesignWin.SizeChanged, AddressOf DSzChange 'size
            AddHandler DesignWin.MouseDown, AddressOf ContrlAdd 'add control  
            AddHandler DesignWin.KeyDown, AddressOf BKeyDown
            AddHandler DesignWin.KeyUp, AddressOf DKeyUp

            DesignWin.Show()
        End If

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
        CmdWin.Hide()
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

    Private Sub DKeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.ControlKey Then
            MultiAddCntrl = False
            multiSelect = False
        End If
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

    'Add a label
    Private Sub ToolLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolLabel.Click
        clean1()
        clean2()
        lblCanAdd = True
    End Sub

    'Add a link label
    Private Sub ToolLinkLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolLinkLabel.Click
        clean1()
        clean2()
        lblLCanAdd = True
    End Sub

    Private Sub ToolArrow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolArrow.Click
        clean1()
        clean2()
    End Sub

#End Region

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

    Private Sub ShowProperties()
        prp.Height = PropertiesBox.Height
        prp.Width = PropertiesBox.Width
        If frmProp = True Then
            prp.SelectedObject = DesignWin
        Else
            prp.SelectedObject = DesignWin.ActiveControl
        End If
    End Sub

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
    Private Sub SelectAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectAllToolStripMenuItem.Click
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

    Private Sub AddCommandToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CmdWin.MdiParent = Me
        CmdWin.Icon = My.Resources.Code
        CmdWin.Location = New Point(0, 0)
        AddHandler CmdWin.FormClosing, AddressOf CodeClosing 'Hide when closing
        CmdWin.Show()

        DesignWindowToolStripMenuItem.Enabled = False
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

    Private Sub AddCommandToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddCommandToolStripMenuItem.Click
        If TypeOf DesignWin.ActiveControl Is Button Then
            CmdWin.ListBox1.Items.Clear()

            btn = DesignWin.ActiveControl
            CmdWin.RadioButton1.Checked = buttons.Item(buttons.GetIndex(btn)).c
            CmdWin.chkWait.Checked = buttons.Item(buttons.GetIndex(btn)).ad_e
            CmdWin.chkErr.Checked = buttons.Item(buttons.GetIndex(btn)).ad_er

            Try
                Using sr As StreamReader = New StreamReader(Pwin.TextBox2.Text + Pwin.TextBox1.Text + "\" + buttons.Item(buttons.GetIndex(btn)).cmd + ".tmp")
                    Dim line As String
                    Do
                        line = sr.ReadLine()
                        CmdWin.ListBox1.Items.Add(line)
                    Loop Until line Is Nothing
                End Using
            Catch 
            End Try


            If (CmdWin.ShowDialog = Windows.Forms.DialogResult.OK) Then
                buttons.Item(buttons.GetIndex(btn)).c = CmdWin.RadioButton1.Checked
                buttons.Item(buttons.GetIndex(btn)).ad_e = CmdWin.chkWait.CheckState
                buttons.Item(buttons.GetIndex(btn)).ad_er = CmdWin.chkErr.CheckState

                Dim sb As New StringBuilder()
                For Each item As String In CmdWin.ListBox1.Items
                    If item.Length > 0 Then
                        sb.AppendLine(item)
                    End If
                Next

                Using outfile As New StreamWriter(Pwin.TextBox2.Text + Pwin.TextBox1.Text + "\" + buttons.Item(buttons.GetIndex(btn)).Name + buttons.GetIndex(btn).ToString + ".tmp")
                    outfile.Write(sb.ToString())
                End Using

                buttons.Item(buttons.GetIndex(btn)).cmd = buttons.Item(buttons.GetIndex(btn)).Name + buttons.GetIndex(btn).ToString
            End If

        End If

    End Sub

End Class
