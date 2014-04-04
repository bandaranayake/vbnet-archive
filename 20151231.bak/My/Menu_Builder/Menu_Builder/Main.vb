Imports System.IO
Imports System.Drawing.Imaging

Public Class Main

#Region "Variable Declarations..."

    Dim toolStripButton1, toolStripButton2, toolStripButton3 As ToolStripMenuItem
    Dim ContextMenuS As New ContextMenuStrip

    Dim btnCanAdd, lblCanAdd, lblLCanAdd, imgCanAdd, SPanCanAdd, TextCanAdd As Boolean

    Dim cDelete, cLoc, cSize As Boolean

    Dim i, j, k, l, m, n As Integer

    Dim mouseOffset As Point

    Dim btn As vButton
    Dim lbl As vLabel
    Dim lblL As vLinkLabel
    Dim img As vImage
    Dim Pan As vPanel
    Dim Tex As vTextBox

    Dim MultiAddCntrl, multiSelect, multiselectED As Boolean


    Dim p As Boolean

#End Region

    Dim prShowed As Boolean = False
    Dim acShowed As Boolean = False

    Dim FormDotXY As Integer = 8 '4

    Dim testForm As New Form

    Dim tmpC1, tmpC2 As Color

    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        If p = True Then
            NewFrame.Close()
            If NewFrame.IsDisposed = False Then
                GoTo en
            End If
        End If

        If (NewProject.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            NewFrame = New Frame

            clean()
            clean0()

            p = True
            Dim flag As Bitmap

            flag = New Bitmap(FormDotXY, FormDotXY)
            flag.SetPixel(0, 0, Color.Black)


            NewFrame.MdiParent = Me
            NewFrame.Text = "Menu Builder"
            NewFrame.Location = New Point(0, 0)
            NewFrame.AllowDrop = True
            NewFrame.MaximumSize = New Size(1036, 780)
            NewFrame.MinimumSize = New Size(132, 38)
            NewFrame.BackgroundImage = flag
            NewFrame.BackgroundImageLayout = ImageLayout.Tile
            NewFrame.Opacity = 1

            AddHandler NewFrame.MouseMove, AddressOf GetLocation
            AddHandler NewFrame.SizeChanged, AddressOf DSzChange
            AddHandler NewFrame.MouseDown, AddressOf ContrlAdd
            AddHandler NewFrame.KeyDown, AddressOf DKeyDown
            AddHandler NewFrame.KeyUp, AddressOf DKeyUp
            AddHandler NewFrame.FormClosing, AddressOf F_FormClosing
            AddHandler NewFrame.DragDrop, AddressOf D_DragDrop
            AddHandler NewFrame.DragEnter, AddressOf D_DragEnter
            AddHandler NewFrame.ControlRemoved, AddressOf F_ControlRemoved

            NewFrame.Show()

            lblProjectPath.Text = ProjectPath
        End If
en:
        lblStatus.Text = "New Project Created.."
    End Sub

    Dim Offset As Point
    Dim Testc As Control

#Region "Handlers"

    Public Sub ControlRemove(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ContextMenuS.SourceControl.Parent.Controls.Remove(ContextMenuS.SourceControl)
        clean()
        clean0()
        lblStatus.Text = "Control Removed"
    End Sub

    Private Sub cntrlDelete(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If multiSelect = True Then
            Using redPen As New Pen(Color.Red), _
          formGraphics As Graphics = sender.Parent.CreateGraphics()
                formGraphics.DrawRectangle(redPen, New Rectangle(sender.location.x - 1, sender.location.y - 1, sender.width + 1, sender.height + 1))
            End Using
            multiselectED = True
            sender.Tag = True
        Else
            NewFrame.ActiveControl = sender
            lblStatus.Text = "Active Control Changed.."
            If prShowed = True Then
                ShowProperties(NewFrame.ActiveControl)
            ElseIf acShowed = True Then
                ShowActions(NewFrame.ActiveControl)
            End If
        End If
    End Sub

    Private Sub CntrlLoc(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If cLoc = True Then
            clean()
            clean0()
            cLoc = False
        ElseIf cLoc = False Then
            clean()
            clean0()
            lblStatus.Text = "Change Control Location"
            NewFrame.Cursor = Cursors.SizeAll
            Me.Cursor = Cursors.SizeAll
            cLoc = True
        End If
    End Sub

    Private Sub CntrlSz(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If cSize = True Then
            clean()
            clean0()
            cSize = False
        ElseIf cSize = False Then
            clean()
            clean0()
            lblStatus.Text = "Change Control Size"
            NewFrame.Cursor = Cursors.PanSE
            Me.Cursor = Cursors.PanSE
            cSize = True
        End If
    End Sub

    Private Sub CntrlLocChange1MV(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If cLoc = True Then
            If e.Button = MouseButtons.Left Then
                Dim mousePos = Control.MousePosition
                mousePos.Offset(mouseOffset.X - 100, mouseOffset.Y - 185)
                sender.Location = mousePos
                lblXY.Text = sender.Location.X.ToString + "," + sender.Location.Y.ToString
                lblStatus.Text = "Control Location Changed"
            End If
        ElseIf cSize = True Then
            If e.Button = MouseButtons.Left Then
                Dim mousePos = Control.MousePosition
                mousePos.Offset(mouseOffset.X - 100, mouseOffset.Y - 200)
                sender.Size = mousePos
                lblSize.Text = sender.Width.ToString + " x " + sender.Height.ToString
                lblStatus.Text = "Control Size Changed"
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

    Private Sub DrpDwnItm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            NewFrame.ActiveControl = sender.Tag
            lblStatus.Text = "Active Control Changed.."
        Catch
        End Try
    End Sub

    Private Sub TestFrameMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            Dim mousePos = Control.MousePosition
            mousePos.Offset(mouseOffset.X, mouseOffset.Y)
            sender.Parent.Location = mousePos
        End If
    End Sub

    Private Sub TestFrameMouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Offset = New Point(-e.X, -e.Y)
    End Sub

#End Region

#Region "Conrols Add"

    Private Sub ContrlAdd(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        AddHandler ContextMenuS.Opening, AddressOf cms_Opening
        ContextMenuS.AutoSize = False
        ContextMenuS.Size = New Point(100, 70)
        ContextMenuS.ShowImageMargin = True

        Dim DrpDwnItem As New ToolStripMenuItem

        If btnCanAdd = True Then
            i = i + 1
            btn = New vButton
            btn.Name = "btn" + i.ToString
            btn.Text = "Button " + i.ToString
            btn.Size = New Point(75, 23)
            btn.Location = e.Location
            btn.ContextMenuStrip = ContextMenuS
            btn.Tag = False
            btn.UseVisualStyleBackColor = True
            AddHandler btn.Click, AddressOf cntrlDelete
            AddHandler btn.MouseMove, AddressOf CntrlLocChange1MV
            AddHandler btn.MouseDown, AddressOf CntrlLocChange2MD
            AddHandler btn.KeyDown, AddressOf DKeyDown
            AddHandler btn.KeyUp, AddressOf DKeyUp


            DrpDwnItem.Name = btn.Name + "Drp"
            DrpDwnItem.Text = btn.Text
            DrpDwnItem.Tag = btn
            AddHandler DrpDwnItem.Click, AddressOf DrpDwnItm_Click

            DropDownList.Items.Add(DrpDwnItem)
            DrpDwnControls.DropDown = DropDownList

            sender.Controls.Add(btn)
            lblSize.Text = btn.Width.ToString + " x " + btn.Height.ToString
            lblXY.Text = btn.Location.X.ToString + "," + btn.Location.Y.ToString

        ElseIf lblCanAdd = True Then

            j = j + 1
            lbl = New vLabel
            lbl.Name = "lbl" + j.ToString
            lbl.Text = "Label " + j.ToString
            lbl.BackColor = Color.YellowGreen
            lbl.Size = New Point(43, 13)
            lbl.Location = e.Location
            lbl.ContextMenuStrip = ContextMenuS
            lbl.Tag = False
            AddHandler lbl.Click, AddressOf cntrlDelete
            AddHandler lbl.MouseMove, AddressOf CntrlLocChange1MV
            AddHandler lbl.MouseDown, AddressOf CntrlLocChange2MD
            AddHandler lbl.KeyDown, AddressOf DKeyDown
            AddHandler lbl.KeyUp, AddressOf DKeyUp

            DrpDwnItem.Name = lbl.Name + "Drp"
            DrpDwnItem.Text = lbl.Text
            DrpDwnItem.Tag = lbl
            AddHandler DrpDwnItem.Click, AddressOf DrpDwnItm_Click

            DropDownList.Items.Add(DrpDwnItem)
            DrpDwnControls.DropDown = DropDownList

            sender.Controls.Add(lbl)
            lblSize.Text = lbl.Width.ToString + " x " + lbl.Height.ToString
            lblXY.Text = lbl.Location.X.ToString + "," + lbl.Location.Y.ToString

        ElseIf lblLCanAdd = True Then

            k = k + 1
            lblL = New vLinkLabel
            lblL.Name = "ink" + k.ToString
            lblL.Text = "Link Label " + k.ToString
            lblL.BackColor = Color.LightSkyBlue
            lblL.AutoSize = False
            lblL.Size = New Point(65, 13)
            lblL.Location = e.Location
            lblL.Tag = False
            lblL.ContextMenuStrip = ContextMenuS
            AddHandler lblL.Click, AddressOf cntrlDelete
            AddHandler lblL.MouseMove, AddressOf CntrlLocChange1MV
            AddHandler lblL.MouseDown, AddressOf CntrlLocChange2MD
            AddHandler lblL.KeyDown, AddressOf DKeyDown
            AddHandler lblL.KeyUp, AddressOf DKeyUp

            DrpDwnItem.Name = lblL.Name + "Drp"
            DrpDwnItem.Text = lblL.Text
            DrpDwnItem.Tag = lblL
            AddHandler DrpDwnItem.Click, AddressOf DrpDwnItm_Click

            DropDownList.Items.Add(DrpDwnItem)
            DrpDwnControls.DropDown = DropDownList

            sender.Controls.Add(lblL)
            lblSize.Text = lblL.Width.ToString + " x " + lblL.Height.ToString
            lblXY.Text = lblL.Location.X.ToString + "," + lblL.Location.Y.ToString

        ElseIf imgCanAdd = True Then
            l = l + 1
            img = New vImage
            img.Name = "img" + l.ToString
            img.Text = "Image " + l.ToString
            img.Size = New Point(80, 80)
            img.BackColor = SystemColors.Control
            img.Location = e.Location
            img.ContextMenuStrip = ContextMenuS
            img.Tag = False
            AddHandler img.Click, AddressOf cntrlDelete
            AddHandler img.MouseMove, AddressOf CntrlLocChange1MV
            AddHandler img.MouseDown, AddressOf CntrlLocChange2MD
            AddHandler img.KeyDown, AddressOf DKeyDown
            AddHandler img.KeyUp, AddressOf DKeyUp

            DrpDwnItem.Name = img.Name + "Drp"
            DrpDwnItem.Text = img.Text
            DrpDwnItem.Tag = img
            AddHandler DrpDwnItem.Click, AddressOf DrpDwnItm_Click

            DropDownList.Items.Add(DrpDwnItem)
            DrpDwnControls.DropDown = DropDownList

            sender.Controls.Add(img)
            lblSize.Text = img.Width.ToString + " x " + img.Height.ToString
            lblXY.Text = img.Location.X.ToString + "," + img.Location.Y.ToString

        ElseIf SPanCanAdd = True Then
            'If TypeOf sender Is Panel Then
            '    MsgBox("Container cannot be added into another container !", MsgBoxStyle.Information, "Error !")
            'Else
            m = m + 1
            Pan = New vPanel
            Pan.Name = "Pan" + m.ToString
            Pan.Text = "Panel " + m.ToString
            Pan.Size = New Point(150, 150)
            Pan.BackColor = SystemColors.Control
            Pan.Location = e.Location
            Pan.Tag = False

            AddHandler Pan.MouseDown, AddressOf ContrlAdd
            AddHandler Pan.MouseMove, AddressOf CntrlLocChange1MV
            AddHandler Pan.MouseDown, AddressOf CntrlLocChange2MD
            AddHandler Pan.KeyDown, AddressOf DKeyDown
            AddHandler Pan.KeyUp, AddressOf DKeyUp

            DrpDwnItem.Name = Pan.Name + "Drp"
            DrpDwnItem.Text = Pan.Text
            DrpDwnItem.Tag = Pan
            AddHandler DrpDwnItem.Click, AddressOf DrpDwnItm_Click

            DropDownList.Items.Add(DrpDwnItem)
            DrpDwnControls.DropDown = DropDownList

            sender.Controls.Add(Pan)

            lblSize.Text = Pan.Width.ToString + " x " + Pan.Height.ToString
            lblXY.Text = Pan.Location.X.ToString + "," + Pan.Location.Y.ToString

            'End If
        ElseIf TextCanAdd = True Then
            m = m + 1
            Tex = New vTextBox
            Tex.Name = "Txt" + m.ToString
            Tex.Text = "TextBox " + m.ToString
            Tex.Size = New Point(100, 20)
            Tex.BackColor = Color.White
            Tex.Location = e.Location
            Tex.Tag = False

            AddHandler Tex.Click, AddressOf cntrlDelete
            AddHandler Tex.MouseMove, AddressOf CntrlLocChange1MV
            AddHandler Tex.MouseDown, AddressOf CntrlLocChange2MD
            AddHandler Tex.KeyDown, AddressOf DKeyDown
            AddHandler Tex.KeyUp, AddressOf DKeyUp

            DrpDwnItem.Name = Tex.Name + "Drp"
            DrpDwnItem.Text = Tex.Text
            DrpDwnItem.Tag = Tex
            AddHandler DrpDwnItem.Click, AddressOf DrpDwnItm_Click

            DropDownList.Items.Add(DrpDwnItem)
            DrpDwnControls.DropDown = DropDownList

            sender.Controls.Add(Tex)

            lblSize.Text = Tex.Width.ToString + " x " + Tex.Height.ToString
            lblXY.Text = Tex.Location.X.ToString + "," + Tex.Location.Y.ToString
        Else
            clean()
            clean0()
            lblSize.Text = sender.Width.ToString + " x " + sender.Height.ToString
            lblStatus.Text = "Ready"
        End If

        If cLoc = True Then
            mouseOffset = New Point(-e.X, -e.Y)
        End If
en:
        If MultiAddCntrl = False Then
            clean()
            clean0()
        End If

        '''''''''''''''Panel'''''''''''''''''''
        If TypeOf sender Is Panel Then
            NewFrame.ActiveControl = sender
            lblStatus.Text = "Active control changed.."
            If prShowed = True Then
                ShowProperties(NewFrame.ActiveControl)
            ElseIf acShowed = True Then
                ShowActions(NewFrame.ActiveControl)
            End If
        End If
    End Sub

    Private Sub ToolButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolButton.Click, ButttonToolStripMenuItem.Click
        clean()
        clean0()
        lblStatus.Text = "Add button.."
        btnCanAdd = True
        NewFrame.Cursor = New Cursor(My.Computer.FileSystem.CurrentDirectory + "\Cursor\btnCursor.cur")
        Me.Cursor = New Cursor(My.Computer.FileSystem.CurrentDirectory + "\Cursor\btnCursor.cur")
    End Sub

    Private Sub ToolLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolLabel.Click, LabelToolStripMenuItem.Click
        clean()
        clean0()
        lblStatus.Text = "Add label.."
        lblCanAdd = True
        NewFrame.Cursor = New Cursor(My.Computer.FileSystem.CurrentDirectory + "\Cursor\lblCursor.cur")
        Me.Cursor = New Cursor(My.Computer.FileSystem.CurrentDirectory + "\Cursor\lblCursor.cur")
    End Sub

    Private Sub ToolLinkLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolLinkLabel.Click, LinkLabelToolStripMenuItem.Click
        clean()
        clean0()
        lblStatus.Text = "Add link label.."
        lblLCanAdd = True
        NewFrame.Cursor = New Cursor(My.Computer.FileSystem.CurrentDirectory + "\Cursor\llblCursor.cur")
        Me.Cursor = New Cursor(My.Computer.FileSystem.CurrentDirectory + "\Cursor\llblCursor.cur")
    End Sub

    Private Sub ToolImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolImage.Click, ImageToolStripMenuItem.Click
        clean()
        clean0()
        lblStatus.Text = "Add image.."
        imgCanAdd = True
        NewFrame.Cursor = New Cursor(My.Computer.FileSystem.CurrentDirectory + "\Cursor\imgCursor.cur")
        Me.Cursor = New Cursor(My.Computer.FileSystem.CurrentDirectory + "\Cursor\imgCursor.cur")
    End Sub

    Private Sub ToolArrow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolArrow.Click
        clean()
        clean0()
    End Sub

    Private Sub toolPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolPanel.Click, PanelToolStripMenuItem.Click
        clean()
        clean0()
        lblStatus.Text = "Add panel.."
        SPanCanAdd = True
        NewFrame.Cursor = New Cursor(My.Computer.FileSystem.CurrentDirectory + "\Cursor\SCursor.cur")
        Me.Cursor = New Cursor(My.Computer.FileSystem.CurrentDirectory + "\Cursor\SCursor.cur")
    End Sub

    Private Sub toolTextBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolTextBox.Click
        clean()
        clean0()
        lblStatus.Text = "Add Text Box.."
        TextCanAdd = True
        NewFrame.Cursor = New Cursor(My.Computer.FileSystem.CurrentDirectory + "\Cursor\llblCursor.cur")
        Me.Cursor = New Cursor(My.Computer.FileSystem.CurrentDirectory + "\Cursor\llblCursor.cur")
    End Sub

#End Region

#Region "Arrange-Select"

    'Arrange V
    Private Sub VerticallyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerticallyToolStripMenuItem.Click
        For Each c In NewFrame.Controls
            If c.Tag = True Then
                clean()
                c.Location = New Point(NewFrame.ActiveControl.Location.X, c.Location.Y)
                c.Tag = False
            End If
        Next
        clean0()
    End Sub

    'Arrange H
    Private Sub HorizontallyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HorizontallyToolStripMenuItem.Click
        For Each c In NewFrame.Controls
            If c.tag = True Then
                clean()
                c.Location = New Point(c.Location.X, NewFrame.ActiveControl.Location.Y)
                c.Tag = False
            End If
        Next
        clean0()
    End Sub

    'Remove all controls
    Private Sub RemoveAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveAllToolStripMenuItem.Click
        If MsgBox("Remove all controls ?", MsgBoxStyle.OkCancel + MsgBoxStyle.Exclamation, "Confirm") = MsgBoxResult.Ok Then
            clean()
            clean0()
            NewFrame.Controls.Clear()
            i = 0
            j = 0
            k = 0
            DropDownList.Items.Clear()
        End If
    End Sub

    'Select all controls
    Private Sub AllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AllToolStripMenuItem.Click
        clean()
        clean0()
        For Each c In NewFrame.Controls
            Using redPen As New Pen(Color.Red), _
       formGraphics As Graphics = NewFrame.CreateGraphics()
                formGraphics.DrawRectangle(redPen, New Rectangle(c.Location.X - 1, c.Location.Y - 1, c.Width + 1, c.Height + 1))
            End Using
            multiselectED = True
            c.Tag = True
        Next
    End Sub

    'Select all buttons
    Private Sub ButtonsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonsToolStripMenuItem.Click
        clean()
        clean0()
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
        clean()
        clean0()
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
        clean()
        clean0()
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

    'Select all images
    Private Sub ImagesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImagesToolStripMenuItem.Click
        clean()
        clean0()
        For Each c In NewFrame.Controls
            If TypeOf c Is PictureBox Then
                Using redPen As New Pen(Color.Red), _
     formGraphics As Graphics = NewFrame.CreateGraphics()
                    formGraphics.DrawRectangle(redPen, New Rectangle(c.Location.X - 1, c.Location.Y - 1, c.Width + 1, c.Height + 1))
                End Using
                multiselectED = True
                c.Tag = True
            End If
        Next
    End Sub

    Private Sub PanelsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PanelsToolStripMenuItem.Click
        clean()
        clean0()
        For Each c In NewFrame.Controls
            If TypeOf c Is Panel Then
                Using redPen As New Pen(Color.Red), _
formGraphics As Graphics = NewFrame.CreateGraphics()
                    formGraphics.DrawRectangle(redPen, New Rectangle(c.Location.X - 1, c.Location.Y - 1, c.Width + 1, c.Height + 1))
                End Using
                multiselectED = True
                c.Tag = True
            End If
        Next
    End Sub

    Private Sub UnselectAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnselectAllToolStripMenuItem.Click
        clean()
        clean0()
    End Sub

#End Region

#Region "Form Handlers"

    Private Sub D_DragDrop(ByVal sender As Object, _
      ByVal e As DragEventArgs)

        If e.Data.GetDataPresent(DataFormats.FileDrop) Then

            Dim files As String() = CType(e.Data.GetData(DataFormats.FileDrop), String())

            Try
                NewFrame.BackgroundImage = Image.FromFile(files(0))
                BImageChanged = True
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                BImageChanged = False
                Return
            End Try
        End If

        Me.Invalidate()
    End Sub

    Private Sub D_DragEnter(ByVal sender As Object, _
      ByVal e As DragEventArgs)

        If e.Data.GetDataPresent(DataFormats.Bitmap) _
           Or e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub F_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs)
        If MsgBox("?", MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel Then
            e.Cancel = True
        Else
            p = False
        End If
    End Sub

    Private Sub DSzChange(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If sender.WindowState = FormWindowState.Maximized Then
            sender.WindowState = FormWindowState.Normal
        ElseIf sender.WindowState = FormWindowState.Minimized Then
            sender.WindowState = FormWindowState.Normal
        End If
        lblSize.Text = NewFrame.Width.ToString + " x " + NewFrame.Height.ToString
    End Sub

    Private Sub DKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Delete Then
            If multiselectED = False Then

                Try
                    For Each c In NewFrame.ActiveControl.Controls
                        If DropDownList.Items.Contains(DropDownList.Items.Item(c.Name + "Drp")) = True Then
                            DropDownList.Items.Remove(DropDownList.Items.Item(c.Name + "Drp"))
                        End If
                    Next
                Catch
                End Try

                Try
                    DropDownList.Items.Remove(DropDownList.Items.Item(NewFrame.ActiveControl.Name + "Drp"))
                Catch
                End Try

                Try
                    sender.Parent.Controls.Remove(NewFrame.ActiveControl)
                Catch
                End Try

            ElseIf multiselectED = True Then
                Dim tArray As New ArrayList

                For Each c In NewFrame.Controls
                    If c.Tag = True Then
                        Try
                            DropDownList.Items.Remove(DropDownList.Items.Item(c.Name + "Drp"))
                        Catch
                        End Try
                        tArray.Add(c)
                    End If
                Next

                Try
                    For Each c In tArray
                        NewFrame.Controls.Remove(c)
                    Next
                Catch
                End Try


                Try

                    Dim tmpControl As Control
                    tmpControl = sender.Parent

                    For Each c In tmpControl.Controls
                        If c.Tag = True Then
                            Try
                                DropDownList.Items.Remove(DropDownList.Items.Item(c.Name + "Drp"))
                            Catch
                            End Try
                            tArray.Add(c)
                        End If
                    Next

                    For Each c In tArray
                        NewFrame.Controls.Remove(c)
                    Next

                Catch
                End Try

            End If

            clean()
            clean0()
        ElseIf e.KeyCode = Keys.Escape Then
            clean()
            clean0()
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
        lblXY.Text = e.X.ToString + "," + e.Y.ToString
    End Sub

    Private Sub F_ControlRemoved(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ControlEventArgs)
        DropDownList.Items.Remove(DropDownList.Items.Item(e.Control.Name + "Drp"))
    End Sub

#End Region

#Region "Functions"

    Private Sub clean()
        cLoc = False
        cDelete = False
        cSize = False
        lblCanAdd = False
        btnCanAdd = False
        lblLCanAdd = False
        imgCanAdd = False
        SPanCanAdd = False
        TextCanAdd = False
        MultiAddCntrl = False
        multiSelect = False
        multiselectED = False
        NewFrame.CreateGraphics().Clear(NewFrame.BackColor)
        lblStatus.Text = "Ready"

        Try
            If FrameProperties.chkCursorFrmFile.Checked = True Then
                NewFrame.Cursor = New Cursor(FrameProperties.txtCursor.Text)
            ElseIf FrameProperties.chkCursorFrmFile.Checked = False Then
                NewFrame.Cursor = SetCursor(FrameProperties.cmbxCursor.SelectedIndex)
            End If
        Catch ex As Exception
            NewFrame.Cursor = Cursors.Arrow
        End Try

        Me.Cursor = Cursors.Arrow
        NewFrame.Refresh()
    End Sub

    Private Sub clean0()
        For Each c In NewFrame.Controls
            c.Tag = False
        Next
    End Sub

    Private Sub ShowProperties(ByVal c As Control)
        If TypeOf c Is Button Then
            btn = New vButton
            btn = NewFrame.ActiveControl

            Dim bP As New Pbtn

            TabPanel1.Controls.Clear()
            bP.lblHead.Text = bP.lblHead.Text + " " + btn.Text
            bP.Dock = DockStyle.Fill
            bP.txtText.Text = btn.Text
            bP.btnBackColor.BackColor = btn.BackColor


            If btn.BackgroundImage IsNot Nothing Then
                bP.txtBackgroundImage.Text = "(Image)"
            End If

            bP.cmbxBImageLayout.SelectedIndex = btn.BackgroundImageLayout

            If GetCursor(btn.Cursor) = False Then
                bP.chkCursorFrmFile.Checked = True
                bP.cmbxCursor.Enabled = False
                bP.btnCursor.Enabled = True
                bP.txtCursor.Enabled = True
                bP.txtCursor.Text = btn.CursorFile
            Else
                bP.cmbxCursor.SelectedIndex = GetCursor(btn.Cursor)
            End If

            bP.cmbxFlatStyle.SelectedIndex = btn.FlatStyle
            bP.txtFont.Text = btn.Font.Name
            bP.txtFont.Font = btn.Font
            bP.btnForeColor.BackColor = btn.ForeColor
            bP.txtImage.Text = "(Image)"
            bP.cmbxImageAlign.SelectedIndex = GetImgAlign(btn.ImageAlign)
            bP.cmbxTextAlign.SelectedIndex = GetImgAlign(btn.TextAlign)

            If btn.TextImageRelation = TextImageRelation.Overlay Then
                bP.cmbxTextImageRelation.SelectedIndex = 0
            ElseIf btn.TextImageRelation = TextImageRelation.ImageBeforeText Then
                bP.cmbxTextImageRelation.SelectedIndex = 1
            ElseIf btn.TextImageRelation = TextImageRelation.TextBeforeImage Then
                bP.cmbxTextImageRelation.SelectedIndex = 2
            ElseIf btn.TextImageRelation = TextImageRelation.ImageAboveText Then
                bP.cmbxTextImageRelation.SelectedIndex = 3
            ElseIf btn.TextImageRelation = TextImageRelation.TextAboveImage Then
                bP.cmbxTextImageRelation.SelectedIndex = 4
            End If

            bP.chkUseMnemonic.Checked = btn.UseMnemonic
            bP.chkUseVisualStyle.Checked = btn.UseVisualStyleBackColor
            bP.chkUseWaitCusor.Checked = btn.UseWaitCursor

            bP.chkAutoSize.Checked = btn.AutoSize
            bP.cmbxRightToLeft.SelectedIndex = btn.RightToLeft
            bP.chkTabStop.Checked = btn.TabStop
            bP.txtTabIndex.Text = btn.TabIndex

            bP.txtLocationX.Text = btn.Location.X
            bP.txtLocationY.Text = btn.Location.Y
            bP.txtSizeW.Text = btn.Width
            bP.txtSizeH.Text = btn.Height
            bP.txtMaxSizeW.Text = btn.MaximumSize.Width
            bP.txtMaxSizeH.Text = btn.MaximumSize.Height
            bP.txtMinSizeW.Text = btn.MinimumSize.Width
            bP.txtMinSizeH.Text = btn.MinimumSize.Width
            bP.cmbxDock.SelectedIndex = btn.Dock

            TabPanel1.Controls.Add(bP)
            bP.TabPage1.AutoScroll = True
        ElseIf TypeOf c Is LinkLabel Then
            lblL = New vLinkLabel
            lblL = NewFrame.ActiveControl
            TabPanel1.Controls.Clear()

            Dim ip As New Pllbl
            ip.lblHead.Text = ip.lblHead.Text + " " + lblL.Text
            ip.Dock = DockStyle.Fill


            ip.txtText.Text = lblL.Text
            If GetCursor(lblL.Cursor) = False Then
                ip.chkCursorFrmFile.Checked = True
                ip.cmbxCursor.Enabled = False
                ip.btnCursor.Enabled = True
                ip.txtCursor.Enabled = True
                ip.txtCursor.Text = lblL.CursorFile
            Else
                ip.cmbxCursor.SelectedIndex = GetCursor(lblL.Cursor)
            End If

            ip.txtFont.Text = lblL.Font.Name
            ip.txtFont.Font = lblL.Font
            ip.txtImage.Text = "(Image)"
            ip.cmbxImageAlign.SelectedIndex = GetImgAlign(lblL.ImageAlign)
            ip.cmbxTextAlign.SelectedIndex = GetImgAlign(lblL.TextAlign)
            ip.btnActivelinkColor.BackColor = lblL.ForeColor
            ip.btnBackColor.BackColor = lblL.BackColor
            ip.btnLinkColor.BackColor = lblL.LinkColor
            ip.btnVisitedlinkColor.BackColor = lblL.VisitedLinkColor
            ip.btnActivelinkColor.BackColor = lblL.ActiveLinkColor
            ip.btnDisabledLinkColor.BackColor = lblL.DisabledLinkColor
            ip.cmbxLinkBehaviour.SelectedIndex = lblL.LinkBehavior
            ip.chkLinkVisited.Checked = lblL.LinkVisited
            ip.chkUseMnemonic.Checked = lblL.UseMnemonic
            ip.chkUseWaitCusor.Checked = lblL.UseWaitCursor
            ip.chkAutoSize.Checked = lblL.AutoSize
            ip.chkTabStop.Checked = lblL.TabStop
            ip.txtTabIndex.Text = lblL.TabIndex

            ip.txtLocationX.Text = lblL.Location.X
            ip.txtLocationY.Text = lblL.Location.Y
            ip.txtSizeW.Text = lblL.Width
            ip.txtSizeH.Text = lblL.Height
            ip.txtMaxSizeW.Text = lblL.MaximumSize.Width
            ip.txtMaxSizeH.Text = lblL.MaximumSize.Height
            ip.txtMinSizeW.Text = lblL.MinimumSize.Width
            ip.txtMinSizeH.Text = lblL.MinimumSize.Width
            ip.cmbxDock.SelectedIndex = lblL.Dock
            ip.cmbxRightToLeft.SelectedIndex = lblL.RightToLeft
            ip.txtLinkAreaS.Text = lblL.LinkArea.Start
            ip.txtLinkAreaE.Text = lblL.LinkArea.Length

            TabPanel1.Controls.Add(ip)
            ip.TabPage1.AutoScroll = True
        ElseIf TypeOf c Is Label Then
            lbl = New vLabel
            lbl = NewFrame.ActiveControl

            TabPanel1.Controls.Clear()

            Dim pl As New Plbl
            pl.lblHead.Text = pl.lblHead.Text + " " + lbl.Text
            pl.Dock = DockStyle.Fill

            pl.txtText.Text = lbl.Text
            pl.btnBackColor.BackColor = lbl.BackColor

            pl.cmbxBorderStyle.SelectedIndex = lbl.BorderStyle

            If GetCursor(lbl.Cursor) = False Then
                pl.chkCursorFrmFile.Checked = True
                pl.cmbxCursor.Enabled = False
                pl.btnCursor.Enabled = True
                pl.txtCursor.Enabled = True
                pl.txtCursor.Text = lbl.CursorFile
            Else
                pl.cmbxCursor.SelectedIndex = GetCursor(lbl.Cursor)
            End If

            pl.cmbxFlatStyle.SelectedIndex = lbl.FlatStyle
            pl.txtFont.Text = lbl.Font.Name
            pl.txtFont.Font = lbl.Font
            pl.btnForeColor.BackColor = lbl.ForeColor
            pl.txtImage.Text = "(Image)"
            pl.cmbxImageAlign.SelectedIndex = GetImgAlign(lbl.ImageAlign)
            pl.cmbxTextAlign.SelectedIndex = GetImgAlign(lbl.TextAlign)

            pl.chkUseMnemonic.Checked = lbl.UseMnemonic
            pl.chkUseWaitCusor.Checked = lbl.UseWaitCursor
            pl.chkAutoSize.Checked = lbl.AutoSize
            pl.cmbxRightToLeft.SelectedIndex = lbl.RightToLeft
            pl.txtTabIndex.Text = lbl.TabIndex

            pl.txtLocationX.Text = lbl.Location.X
            pl.txtLocationY.Text = lbl.Location.Y
            pl.txtSizeW.Text = lbl.Width
            pl.txtSizeH.Text = lbl.Height
            pl.txtMaxSizeW.Text = lbl.MaximumSize.Width
            pl.txtMaxSizeH.Text = lbl.MaximumSize.Height
            pl.txtMinSizeW.Text = lbl.MinimumSize.Width
            pl.txtMinSizeH.Text = lbl.MinimumSize.Width
            pl.cmbxDock.SelectedIndex = lbl.Dock


            TabPanel1.Controls.Add(pl)
            pl.TabPage1.AutoScroll = True

        ElseIf TypeOf c Is PictureBox Then
            TabPanel1.Controls.Clear()

            Dim pi As New Pimg
            pi.lblHead.Text = pi.lblHead.Text + " " + img.Text
            pi.Dock = DockStyle.Fill

            img = New vImage
            img = NewFrame.ActiveControl
            pi.btnBackColor.BackColor = img.BackColor

            If img.BackgroundImage IsNot Nothing Then
                pi.txtBackgroundImage.Text = "(Image)"
            End If

            pi.cmbxBImageLayout.SelectedIndex = img.BackgroundImageLayout

            If GetCursor(img.Cursor) = False Then
                pi.chkCursorFrmFile.Checked = True
                pi.cmbxCursor.Enabled = False
                pi.btnCursor.Enabled = True
                pi.txtCursor.Enabled = True
                pi.txtCursor.Text = img.CursorFile
            Else
                pi.cmbxCursor.SelectedIndex = GetCursor(img.Cursor)
            End If
            pi.txtImage.Text = "(Image)"
            pi.txtImageLocation.Text = img.ImageLocation
            pi.cmbxSizeMode.SelectedIndex = img.SizeMode
            pi.chkWaitonLoad.Checked = img.WaitOnLoad
            pi.chkUseWaitCusor.Checked = img.UseWaitCursor

            pi.txtLocationX.Text = img.Location.X
            pi.txtLocationY.Text = img.Location.Y
            pi.txtSizeW.Text = img.Width
            pi.txtSizeH.Text = img.Height
            pi.txtMaxSizeW.Text = img.MaximumSize.Width
            pi.txtMaxSizeH.Text = img.MaximumSize.Height
            pi.txtMinSizeW.Text = img.MinimumSize.Width
            pi.txtMinSizeH.Text = img.MinimumSize.Width
            pi.cmbxDock.SelectedIndex = img.Dock

            TabPanel1.Controls.Add(pi)
            pi.TabPage1.AutoScroll = True

        ElseIf TypeOf c Is Panel Then
            Pan = New vPanel
            Pan = NewFrame.ActiveControl
            TabPanel1.Controls.Clear()

            Dim rP As New Ppan
            rP.lblHead.Text = rP.lblHead.Text + " " + Pan.Text
            rP.Dock = DockStyle.Fill
            rP.btnBackColor.BackColor = Pan.BackColor

            If Pan.BackgroundImage IsNot Nothing Then
                rP.txtBackgroundImage.Text = "(Image)"
            End If

            rP.cmbxBImageLayout.SelectedIndex = Pan.BackgroundImageLayout

            If GetCursor(Pan.Cursor) = False Then
                rP.chkCursorFrmFile.Checked = True
                rP.cmbxCursor.Enabled = False
                rP.btnCursor.Enabled = True
                rP.txtCursor.Enabled = True
                rP.txtCursor.Text = Pan.CursorFile
            Else
                rP.cmbxCursor.SelectedIndex = GetCursor(Pan.Cursor)
            End If

            rP.chkUseWaitCusor.Checked = Pan.UseWaitCursor
            rP.cmbxBorderStyle.SelectedIndex = Pan.BorderStyle

            rP.chkAutoSize.Checked = Pan.AutoSize
            rP.chkTabStop.Checked = Pan.TabStop
            rP.txtTabIndex.Text = Pan.TabIndex

            rP.txtLocationX.Text = Pan.Location.X
            rP.txtLocationY.Text = Pan.Location.Y
            rP.txtSizeW.Text = Pan.Width
            rP.txtSizeH.Text = Pan.Height
            rP.txtMaxSizeW.Text = Pan.MaximumSize.Width
            rP.txtMaxSizeH.Text = Pan.MaximumSize.Height
            rP.txtMinSizeW.Text = Pan.MinimumSize.Width
            rP.txtMinSizeH.Text = Pan.MinimumSize.Width
            rP.cmbxDock.SelectedIndex = Pan.Dock

            For Each cn As Control In Pan.Controls
                Dim ds As New ListViewItem
                ds.Text = cn.Text
                ds.Tag = cn.Name
                rP.ListAll.Items.Add(ds)
            Next

            TabPanel1.Controls.Add(rP)
            rP.TabPage1.AutoScroll = True

        ElseIf TypeOf c Is TextBox Then
            Tex = New vTextBox
            Tex = NewFrame.ActiveControl
            TabPanel1.Controls.Clear()

            Dim tP As New Ptxt
            tP.lblHead.Text = tP.lblHead.Text + " " + Tex.Text
            tP.Dock = DockStyle.Fill

            tP.txtText.Text = Tex.Text
            tP.btnBackColor.BackColor = Tex.BackColor

            If GetCursor(Tex.Cursor) = False Then
                tP.chkCursorFrmFile.Checked = True
                tP.cmbxCursor.Enabled = False
                tP.btnCursor.Enabled = True
                tP.txtCursor.Enabled = True
                tP.txtCursor.Text = Tex.CursorFile
            Else
                tP.cmbxCursor.SelectedIndex = GetCursor(Tex.Cursor)
            End If
            tP.txtFont.Text = Tex.Font.Name
            tP.txtFont.Font = Tex.Font

            tP.btnForeColor.BackColor = Tex.ForeColor
            tP.cmbxTextAlign.SelectedIndex = Tex.TextAlign
            tP.cmbxRightToLeft.SelectedIndex = Tex.RightToLeft

            tP.chkUseWaitCusor.Checked = Tex.UseWaitCursor
            tP.cmbxBorderStyle.SelectedIndex = Tex.BorderStyle

            tP.chkTabStop.Checked = Tex.TabStop
            tP.txtTabIndex.Text = Tex.TabIndex
            tP.chkWordWrap.Checked = Tex.WordWrap
            tP.chkMultiLine.Checked = Tex.Multiline
            tP.chkReadOnly.Checked = Tex.ReadOnly

            tP.txtLocationX.Text = Tex.Location.X
            tP.txtLocationY.Text = Tex.Location.Y
            tP.txtSizeW.Text = Tex.Width
            tP.txtSizeH.Text = Tex.Height
            tP.txtMaxSizeW.Text = Tex.MaximumSize.Width
            tP.txtMaxSizeH.Text = Tex.MaximumSize.Height
            tP.txtMinSizeW.Text = Tex.MinimumSize.Width
            tP.txtMinSizeH.Text = Tex.MinimumSize.Width
            tP.cmbxDock.SelectedIndex = Tex.Dock

            TabPanel1.Controls.Add(tP)
            tP.TabPage1.AutoScroll = True

        Else
            TabPanel1.Controls.Clear()
        End If
    End Sub

    Private Sub ShowActions(ByVal c)
        TabPanel1.Controls.Clear()
        If Not c Is Nothing And Not TypeOf c Is TextBox Then
            Dim ActionPanel1 As New EventPanel
            ActionPanel1.Dock = DockStyle.Fill
            ActionPanel1.TabPage2.AutoScroll = True

            ActionPanel1.CheckBox2.Checked = c.bn(4)
            ActionPanel1.cmbxAction.SelectedIndex = c.int(0) 'Invokes cmbx_SelectedIndexChange Event
            ActionPanel1.cmbxPara1.SelectedIndex = c.int(1)
            ActionPanel1.chkPara1.Checked = c.bn(0)
            ActionPanel1.chkPara2.Checked = c.bn(1)
            ActionPanel1.txtPara1.Text = c.st(0)
            ActionPanel1.txtPara1.Text = c.st(1)
            ActionPanel1.CheckBox1.Checked = c.bn(2)
            ActionPanel1.CheckBox4.Checked = c.bn(3)

            If c.int(2) = Color.Transparent.ToArgb Then
                ActionPanel1.chT.Checked = True
                ActionPanel1.btnMouseOverBColor.BackColor = Color.Transparent
            Else
                ActionPanel1.btnMouseOverBColor.BackColor = Color.FromArgb(c.int(2))
            End If


            If c.int(3) = Color.Transparent.ToArgb Then
                ActionPanel1.chT2.Checked = True
                ActionPanel1.btnMouseDownBColor.BackColor = Color.Transparent
            Else
                ActionPanel1.btnMouseDownBColor.BackColor = Color.FromArgb(c.int(3))
            End If

            If c.int(4) = Color.Transparent.ToArgb Then
                ActionPanel1.chT3.Checked = True
                ActionPanel1.btnMouseOverFColor.BackColor = Color.Transparent
            Else
                ActionPanel1.btnMouseOverFColor.BackColor = Color.FromArgb(c.int(4))
            End If

            If c.int(5) = Color.Transparent.ToArgb Then
                ActionPanel1.chT4.Checked = True
                ActionPanel1.btnMouseDownFColor.BackColor = Color.Transparent
            Else
                ActionPanel1.btnMouseDownFColor.BackColor = Color.FromArgb(c.int(5))
            End If

            ActionPanel1.lblHead.Text = ActionPanel1.lblHead.Text + " " + c.Text
            TabPanel1.Controls.Add(ActionPanel1)
        End If
    End Sub

    Sub Save()
        '        lblStatus.Text = "Saving..."

        '        Dim binWriter As New BinaryWriter( _
        '   File.Open(ProjectPath + "\Project.amb", FileMode.Create))

        '        Dim tmpString As String

        '        binWriter.Write(ProjectName)
        '        binWriter.Write(NewFrame.AutoSizeMode)
        '        binWriter.Write(NewFrame.BackgroundImageLayout)
        '        binWriter.Write(NewFrame.FormBorderStyle)
        '        binWriter.Write(NewFrame.RightToLeft)
        '        binWriter.Write(NewFrame.SizeGripStyle)
        '        binWriter.Write(NewFrame.StartPosition)
        '        binWriter.Write(NewFrame.WindowState)

        '        binWriter.Write(NewFrame.AutoScroll)
        '        binWriter.Write(NewFrame.AutoSize)
        '        binWriter.Write(NewFrame.ControlBox)
        '        binWriter.Write(NewFrame.MaximizeBox)
        '        binWriter.Write(NewFrame.MinimizeBox)
        '        binWriter.Write(NewFrame.RightToLeftLayout)
        '        binWriter.Write(NewFrame.ShowIcon)
        '        binWriter.Write(NewFrame.ShowInTaskbar)
        '        binWriter.Write(NewFrame.TopMost)
        '        binWriter.Write(NewFrame.Opacity)
        '        binWriter.Write(NewFrame.BackColor.ToArgb)
        '        binWriter.Write(NewFrame.ForeColor.ToArgb)
        '        binWriter.Write(NewFrame.TransparencyKey.ToArgb)

        '        binWriter.Write(NewFrame.Text)
        '        binWriter.Write(NewFrame.Width)
        '        binWriter.Write(NewFrame.Height)
        '        binWriter.Write(NewFrame.MinimumSize.Width)
        '        binWriter.Write(NewFrame.MinimumSize.Height)
        '        binWriter.Write(NewFrame.MaximumSize.Width)
        '        binWriter.Write(NewFrame.MaximumSize.Height)

        '        binWriter.Write(NewFrame.Font.Name)
        '        binWriter.Write(NewFrame.Font.Size)
        '        binWriter.Write(NewFrame.Font.Style)
        '        binWriter.Write(NewFrame.Font.Unit)

        '        If GetCursor(NewFrame.Cursor) = False Then
        '            Try
        '                tmpString = GetRandomName()
        '                File.Copy(NewFrame.CursorFile, ProjectPath + "\" + tmpString)
        '                binWriter.Write(True)
        '                binWriter.Write(tmpString)
        '            Catch ex As Exception
        '                binWriter.Write(False)
        '                binWriter.Write(1)
        '            End Try
        '        Else
        '            binWriter.Write(False)
        '            binWriter.Write(GetCursor(NewFrame.Cursor))
        '        End If

        '        If BImageChanged = True Then
        '            Try
        '                tmpString = GetRandomName()
        '                NewFrame.BackgroundImage.Save(ProjectPath + "\" + tmpString, ImageFormat.Jpeg)
        '                binWriter.Write(True)
        '                binWriter.Write(tmpString)
        '            Catch ex As Exception
        '                binWriter.Write(False)
        '            End Try
        '        Else
        '            binWriter.Write(False)
        '        End If

        '        If IconChanged = True Then
        '            Try
        '                tmpString = GetRandomName()
        '                File.Copy(NewFrame.IconFile, ProjectPath + "\" + tmpString)
        '                binWriter.Write(True)
        '                binWriter.Write(tmpString)
        '            Catch ex As Exception
        '                binWriter.Write(False)
        '            End Try
        '        Else
        '            binWriter.Write(False)
        '        End If

        '        binWriter.Write(i)
        '        binWriter.Write(j)
        '        binWriter.Write(k)
        '        binWriter.Write(l)
        '        binWriter.Write(m)
        '        binWriter.Write(n)

        '        If NewFrame.Controls.Count > 0 Then
        '            binWriter.Write(True)
        '            WriteControls(NewFrame, ProjectPath + "\Controls.dat")
        '        Else
        '            binWriter.Write(False)
        '        End If

        '        binWriter.Dispose()
        '        lblStatus.Text = "Ready"
    End Sub

    Sub WriteControls(ByVal Contain As Control, ByVal Path As String)
        '        Dim binWriter As New BinaryWriter( _
        '  File.Open(Path, FileMode.OpenOrCreate))

        '        Dim tmpString As String

        '        binWriter.Write(Contain.Controls.Count)

        '        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '        '########################################################################
        '        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '        For Each c As Control In Contain.Controls
        '            If TypeOf c Is vButton Then
        '                btn = c
        '                binWriter.Write(0)

        '                binWriter.Write(btn.Text)
        '                binWriter.Write(btn.BackColor.ToArgb)
        '                binWriter.Write(btn.Name)
        '                binWriter.Write(btn.BackgroundImageLayout)
        '                binWriter.Write(btn.FlatAppearance.BorderColor.ToArgb)
        '                binWriter.Write(btn.FlatAppearance.BorderSize)
        '                binWriter.Write(btn.FlatAppearance.MouseDownBackColor.ToArgb)
        '                binWriter.Write(btn.FlatAppearance.MouseOverBackColor.ToArgb)
        '                binWriter.Write(btn.FlatStyle)
        '                binWriter.Write(btn.Font.Name)
        '                binWriter.Write(btn.Font.Size)
        '                binWriter.Write(btn.Font.Style)
        '                binWriter.Write(btn.Font.Unit)
        '                binWriter.Write(btn.ForeColor.ToArgb)
        '                binWriter.Write(btn.ImageAlign)
        '                binWriter.Write(btn.TextAlign)
        '                binWriter.Write(btn.TextImageRelation)
        '                binWriter.Write(btn.UseMnemonic)
        '                binWriter.Write(btn.UseVisualStyleBackColor)
        '                binWriter.Write(btn.UseWaitCursor)
        '                binWriter.Write(btn.AutoSize)
        '                binWriter.Write(btn.TabStop)
        '                binWriter.Write(btn.TabIndex)
        '                binWriter.Write(btn.Location.X)
        '                binWriter.Write(btn.Location.Y)
        '                binWriter.Write(btn.Width)
        '                binWriter.Write(btn.Height)
        '                binWriter.Write(btn.MinimumSize.Width)
        '                binWriter.Write(btn.MinimumSize.Height)
        '                binWriter.Write(btn.MaximumSize.Width)
        '                binWriter.Write(btn.MaximumSize.Height)
        '                binWriter.Write(btn.Dock)
        '                binWriter.Write(btn.RightToLeft)

        '                If File.Exists(btn.ActionFile) = True Then
        '                    binWriter.Write(True)
        '                    binWriter.Write(btn.ActionFile)
        '                Else
        '                    binWriter.Write(False)
        '                End If

        '                If btn.b1 = True Then
        '                    Try
        '                        tmpString = GetRandomName()
        '                        File.Copy(btn.CursorFile, ProjectPath + "\" + tmpString)
        '                        binWriter.Write(True)
        '                        binWriter.Write(tmpString)
        '                    Catch ex As Exception
        '                        binWriter.Write(False)
        '                        binWriter.Write(1)
        '                    End Try
        '                Else
        '                    binWriter.Write(False)
        '                    binWriter.Write(GetCursor(btn.Cursor))
        '                End If

        '                If Not btn.BackgroundImage Is Nothing Then
        '                    Try
        '                        tmpString = GetRandomName()
        '                        btn.BackgroundImage.Save(ProjectPath + "\" + tmpString, ImageFormat.Jpeg)
        '                        binWriter.Write(True)
        '                        binWriter.Write(tmpString)
        '                    Catch ex As Exception
        '                        binWriter.Write(False)
        '                    End Try
        '                Else
        '                    binWriter.Write(False)
        '                End If

        '                If Not btn.Image Is Nothing Then
        '                    Try
        '                        tmpString = GetRandomName()
        '                        btn.Image.Save(ProjectPath + "\" + tmpString, ImageFormat.Jpeg)
        '                        binWriter.Write(True)
        '                        binWriter.Write(tmpString)
        '                    Catch ex As Exception
        '                        binWriter.Write(False)
        '                    End Try
        '                Else
        '                    binWriter.Write(False)
        '                End If

        '            ElseIf TypeOf c Is vLinkLabel Then
        '                lblL = c
        '                binWriter.Write(1)

        '                binWriter.Write(lblL.Text)
        '                binWriter.Write(lblL.ImageAlign)
        '                binWriter.Write(lblL.Name)
        '                binWriter.Write(lblL.TextAlign)
        '                binWriter.Write(lblL.ForeColor.ToArgb)
        '                binWriter.Write(lblL.BackColor.ToArgb)
        '                binWriter.Write(lblL.ActiveLinkColor.ToArgb)
        '                binWriter.Write(lblL.VisitedLinkColor.ToArgb)
        '                binWriter.Write(lblL.LinkColor.ToArgb)
        '                binWriter.Write(lblL.DisabledLinkColor.ToArgb)
        '                binWriter.Write(lblL.LinkBehavior)
        '                binWriter.Write(lblL.LinkVisited)
        '                binWriter.Write(lblL.Font.Name)
        '                binWriter.Write(lblL.Font.Size)
        '                binWriter.Write(lblL.Font.Style)
        '                binWriter.Write(lblL.Font.Unit)
        '                binWriter.Write(lblL.UseMnemonic)
        '                binWriter.Write(lblL.UseWaitCursor)
        '                binWriter.Write(lblL.AutoSize)
        '                binWriter.Write(lblL.TabStop)
        '                binWriter.Write(lblL.TabIndex)
        '                binWriter.Write(lblL.Location.X)
        '                binWriter.Write(lblL.Location.Y)
        '                binWriter.Write(lblL.Width)
        '                binWriter.Write(lblL.Height)
        '                binWriter.Write(lblL.MaximumSize.Width)
        '                binWriter.Write(lblL.MaximumSize.Height)
        '                binWriter.Write(lblL.MinimumSize.Width)
        '                binWriter.Write(lblL.MinimumSize.Height)
        '                binWriter.Write(lblL.LinkArea.Start)
        '                binWriter.Write(lblL.LinkArea.Length)
        '                binWriter.Write(lblL.Dock)
        '                binWriter.Write(lblL.RightToLeft)

        '                If File.Exists(lblL.ActionFile) = True Then
        '                    binWriter.Write(True)
        '                    binWriter.Write(lblL.ActionFile)
        '                Else
        '                    binWriter.Write(False)
        '                End If

        '                If lblL.b1 = True Then
        '                    Try
        '                        tmpString = GetRandomName()
        '                        File.Copy(lblL.CursorFile, ProjectPath + "\" + tmpString)
        '                        binWriter.Write(True)
        '                        binWriter.Write(tmpString)
        '                    Catch ex As Exception
        '                        binWriter.Write(False)
        '                        binWriter.Write(1)
        '                    End Try
        '                Else
        '                    binWriter.Write(False)
        '                    binWriter.Write(GetCursor(lblL.Cursor))
        '                End If

        '                If Not lblL.Image Is Nothing Then
        '                    Try
        '                        tmpString = GetRandomName()
        '                        lblL.Image.Save(ProjectPath + "\" + tmpString, ImageFormat.Jpeg)
        '                        binWriter.Write(True)
        '                        binWriter.Write(tmpString)
        '                    Catch ex As Exception
        '                        binWriter.Write(False)
        '                    End Try
        '                Else
        '                    binWriter.Write(False)
        '                End If

        '            ElseIf TypeOf c Is vLabel Then
        '                lbl = c

        '                binWriter.Write(2)

        '                binWriter.Write(lbl.Text)
        '                binWriter.Write(lbl.BorderStyle)
        '                binWriter.Write(lbl.Name)
        '                binWriter.Write(lbl.Font.Name)
        '                binWriter.Write(lbl.Font.Size)
        '                binWriter.Write(lbl.Font.Style)
        '                binWriter.Write(lbl.Font.Unit)
        '                binWriter.Write(lbl.FlatStyle)
        '                binWriter.Write(lbl.ImageAlign)
        '                binWriter.Write(lbl.TextAlign)
        '                binWriter.Write(lbl.ForeColor.ToArgb)
        '                binWriter.Write(lbl.BackColor.ToArgb)
        '                binWriter.Write(lbl.UseMnemonic)
        '                binWriter.Write(lbl.UseWaitCursor)
        '                binWriter.Write(lbl.AutoSize)
        '                binWriter.Write(lbl.TabIndex)
        '                binWriter.Write(lbl.Location.X)
        '                binWriter.Write(lbl.Location.Y)
        '                binWriter.Write(lbl.Width)
        '                binWriter.Write(lbl.Height)
        '                binWriter.Write(lbl.MaximumSize.Width)
        '                binWriter.Write(lbl.MaximumSize.Height)
        '                binWriter.Write(lbl.MinimumSize.Width)
        '                binWriter.Write(lbl.MinimumSize.Height)
        '                binWriter.Write(lbl.Dock)
        '                binWriter.Write(lbl.RightToLeft)

        '                If File.Exists(lbl.ActionFile) = True Then
        '                    binWriter.Write(True)
        '                    binWriter.Write(lbl.ActionFile)
        '                Else
        '                    binWriter.Write(False)
        '                End If

        '                If lbl.b1 = True Then
        '                    Try
        '                        tmpString = GetRandomName()
        '                        File.Copy(lbl.CursorFile, ProjectPath + "\" + tmpString)
        '                        binWriter.Write(True)
        '                        binWriter.Write(tmpString)
        '                    Catch ex As Exception
        '                        binWriter.Write(False)
        '                        binWriter.Write(1)
        '                    End Try
        '                Else
        '                    binWriter.Write(False)
        '                    binWriter.Write(GetCursor(lbl.Cursor))
        '                End If

        '                If Not lbl.Image Is Nothing Then
        '                    Try
        '                        tmpString = GetRandomName()
        '                        lbl.Image.Save(ProjectPath + "\" + tmpString, ImageFormat.Jpeg)
        '                        binWriter.Write(True)
        '                        binWriter.Write(tmpString)
        '                    Catch ex As Exception
        '                        binWriter.Write(False)
        '                    End Try
        '                Else
        '                    binWriter.Write(False)
        '                End If

        '            ElseIf TypeOf c Is PictureBox Then
        '                img = c

        '                binWriter.Write(3)
        '                binWriter.Write(img.Name)
        '                binWriter.Write(img.BackColor.ToArgb)
        '                binWriter.Write(img.BackgroundImageLayout)
        '                If img.ImageLocation IsNot Nothing Then
        '                    binWriter.Write(True)
        '                    binWriter.Write(img.ImageLocation)
        '                Else
        '                    binWriter.Write(False)
        '                End If
        '                binWriter.Write(img.SizeMode)
        '                binWriter.Write(img.UseWaitCursor)
        '                binWriter.Write(img.WaitOnLoad)

        '                binWriter.Write(img.Location.X)
        '                binWriter.Write(img.Location.Y)
        '                binWriter.Write(img.Width)
        '                binWriter.Write(img.Height)
        '                binWriter.Write(img.MaximumSize.Width)
        '                binWriter.Write(img.MaximumSize.Height)
        '                binWriter.Write(img.MinimumSize.Width)
        '                binWriter.Write(img.MinimumSize.Height)
        '                binWriter.Write(img.Dock)

        '                If File.Exists(img.ActionFile) = True Then
        '                    binWriter.Write(True)
        '                    binWriter.Write(img.ActionFile)
        '                Else
        '                    binWriter.Write(False)
        '                End If

        '                If img.b1 = True Then
        '                    Try
        '                        tmpString = GetRandomName()
        '                        File.Copy(img.CursorFile, ProjectPath + "\" + tmpString)
        '                        binWriter.Write(True)
        '                        binWriter.Write(tmpString)
        '                    Catch ex As Exception
        '                        binWriter.Write(False)
        '                        binWriter.Write(1)
        '                    End Try
        '                Else
        '                    binWriter.Write(False)
        '                    binWriter.Write(GetCursor(img.Cursor))
        '                End If

        '                If Not img.BackgroundImage Is Nothing Then
        '                    Try
        '                        tmpString = GetRandomName()
        '                        img.BackgroundImage.Save(ProjectPath + "\" + tmpString, ImageFormat.Jpeg)
        '                        binWriter.Write(True)
        '                        binWriter.Write(tmpString)
        '                    Catch ex As Exception
        '                        binWriter.Write(False)
        '                    End Try
        '                Else
        '                    binWriter.Write(False)
        '                End If

        '                If Not img.Image Is Nothing Then
        '                    Try
        '                        tmpString = GetRandomName()
        '                        img.Image.Save(ProjectPath + "\" + tmpString, ImageFormat.Jpeg)
        '                        binWriter.Write(True)
        '                        binWriter.Write(tmpString)
        '                    Catch ex As Exception
        '                        binWriter.Write(False)
        '                    End Try
        '                Else
        '                    binWriter.Write(False)
        '                End If

        '            ElseIf TypeOf c Is Panel Then
        '                Pan = c

        '                binWriter.Write(4)
        '                binWriter.Write(Pan.Name)
        '                binWriter.Write(Pan.BackgroundImageLayout)
        '                binWriter.Write(Pan.BorderStyle)
        '                binWriter.Write(Pan.BackColor.ToArgb)
        '                binWriter.Write(Pan.UseWaitCursor)

        '                binWriter.Write(Pan.AutoSize)
        '                binWriter.Write(Pan.TabStop)
        '                binWriter.Write(Pan.TabIndex)
        '                binWriter.Write(Pan.Width)
        '                binWriter.Write(Pan.Height)
        '                binWriter.Write(Pan.Location.X)
        '                binWriter.Write(Pan.Location.Y)
        '                binWriter.Write(Pan.MaximumSize.Width)
        '                binWriter.Write(Pan.MaximumSize.Height)
        '                binWriter.Write(Pan.MinimumSize.Width)
        '                binWriter.Write(Pan.MinimumSize.Height)
        '                binWriter.Write(Pan.Dock)

        '                If File.Exists(Pan.ActionFile) = True Then
        '                    binWriter.Write(True)
        '                    binWriter.Write(Pan.ActionFile)
        '                Else
        '                    binWriter.Write(False)
        '                End If

        '                If Pan.b1 = True Then
        '                    Try
        '                        tmpString = GetRandomName()
        '                        File.Copy(Pan.CursorFile, ProjectPath + "\" + tmpString)
        '                        binWriter.Write(True)
        '                        binWriter.Write(tmpString)
        '                    Catch ex As Exception
        '                        binWriter.Write(False)
        '                        binWriter.Write(1)
        '                    End Try
        '                Else
        '                    binWriter.Write(False)
        '                    binWriter.Write(GetCursor(Pan.Cursor))
        '                End If

        '                If Not Pan.BackgroundImage Is Nothing Then
        '                    Try
        '                        tmpString = GetRandomName()
        '                        Pan.BackgroundImage.Save(ProjectPath + "\" + tmpString, ImageFormat.Jpeg)
        '                        binWriter.Write(True)
        '                        binWriter.Write(tmpString)
        '                    Catch ex As Exception
        '                        binWriter.Write(False)
        '                    End Try
        '                Else
        '                    binWriter.Write(False)
        '                End If

        '                If Pan.Controls.Count > 0 Then
        '                    binWriter.Write(True)
        '                    tmpString = GetRandomName()
        '                    WriteControls(Pan, ProjectPath + "\" + tmpString + ".dat")
        '                    binWriter.Write(tmpString)
        '                Else
        '                    binWriter.Write(False)
        '                End If

        '            End If
        '        Next
        'en:
        '        binWriter.Dispose()

    End Sub

    Sub ReadControls(ByVal Path As String, ByVal Contain As Control)
        '   ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '   '########################################################################
        '   ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '   Dim binReader As New BinaryReader( _
        'File.Open(Path, FileMode.Open))
        '   binReader.BaseStream.Seek(0, SeekOrigin.Begin)

        '   Dim tmpInteger, tmpInteger2 As Integer

        '   tmpInteger = binReader.ReadInt32

        '   For vt As Integer = 1 To tmpInteger
        '       tmpInteger2 = binReader.ReadInt32

        '       If tmpInteger2 = 0 Then
        '           btn = New vButton

        '           btn.Text = binReader.ReadString
        '           btn.BackColor = Color.FromArgb(binReader.ReadInt32)
        '           btn.Name = binReader.ReadString
        '           btn.BackgroundImageLayout = binReader.ReadInt32
        '           btn.FlatAppearance.BorderColor = Color.FromArgb(binReader.ReadInt32)
        '           btn.FlatAppearance.BorderSize = binReader.ReadInt32
        '           btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(binReader.ReadInt32)
        '           btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(binReader.ReadInt32)
        '           btn.FlatStyle = binReader.ReadInt32
        '           btn.Font = New Font(binReader.ReadString, binReader.ReadSingle, binReader.ReadInt32, binReader.ReadInt32)
        '           btn.ForeColor = Color.FromArgb(binReader.ReadInt32)
        '           btn.ImageAlign = SetImgAlign(binReader.ReadInt32)
        '           btn.TextAlign = SetImgAlign(binReader.ReadInt32)

        '           If binReader.ReadInt32 = 0 Then
        '               btn.TextImageRelation = TextImageRelation.Overlay
        '           ElseIf 1 Then
        '               btn.TextImageRelation = TextImageRelation.ImageBeforeText
        '           ElseIf 2 Then
        '               btn.TextImageRelation = TextImageRelation.TextBeforeImage
        '           ElseIf 3 Then
        '               btn.TextImageRelation = TextImageRelation.ImageAboveText
        '           ElseIf 4 Then
        '               btn.TextImageRelation = TextImageRelation.TextAboveImage
        '           End If

        '           btn.UseMnemonic = binReader.ReadBoolean
        '           btn.UseVisualStyleBackColor = binReader.ReadBoolean
        '           btn.UseWaitCursor = binReader.ReadBoolean
        '           btn.AutoSize = binReader.ReadBoolean
        '           btn.TabStop = binReader.ReadBoolean
        '           btn.TabIndex = binReader.ReadInt32
        '           btn.Location = New Size(binReader.ReadInt32, binReader.ReadInt32)
        '           btn.Width = binReader.ReadInt32
        '           btn.Height = binReader.ReadInt32
        '           btn.MinimumSize = New Size(binReader.ReadInt32, binReader.ReadInt32)
        '           btn.MaximumSize = New Size(binReader.ReadInt32, binReader.ReadInt32)
        '           btn.Dock = binReader.ReadInt32
        '           btn.RightToLeft = binReader.ReadInt32

        '           If binReader.ReadBoolean = True Then

        '           End If

        '           If binReader.ReadBoolean = True Then
        '               Try
        '                   btn.CursorFile = Path + binReader.ReadString
        '                   btn.Cursor = New Cursor(btn.CursorFile)
        '               Catch ex As Exception
        '                   MsgBox(ex.ToString, MsgBoxStyle.Critical, "Error !")
        '                   btn.Cursor = Cursors.Arrow
        '               End Try
        '           Else
        '               SetCursor(binReader.ReadInt32)
        '           End If

        '           If binReader.ReadBoolean = True Then
        '               Try
        '                   btn.BImage = Path + binReader.ReadString
        '                   btn.BackgroundImage = Image.FromFile(btn.BImage)
        '               Catch ex As Exception
        '                   MsgBox(ex.Message, MsgBoxStyle.Critical, "Error !")
        '               End Try
        '           End If

        '           If binReader.ReadBoolean = True Then
        '               Try
        '                   btn.ImageFile = Path + binReader.ReadString
        '                   btn.Image = Image.FromFile(btn.ImageFile)
        '               Catch ex As Exception
        '                   MsgBox(ex.Message, MsgBoxStyle.Critical, "Error !")
        '               End Try
        '           End If

        '           ''''''''''''''''''''''
        '           AddHandler ContextMenuS.Opening, AddressOf cms_Opening
        '           ContextMenuS.AutoSize = False
        '           ContextMenuS.Size = New Point(100, 70)
        '           ContextMenuS.ShowImageMargin = True
        '           Dim DrpDwnItem As New ToolStripMenuItem
        '           btn.ContextMenuStrip = ContextMenuS
        '           btn.Tag = False
        '           AddHandler btn.Click, AddressOf cntrlDelete
        '           AddHandler btn.MouseMove, AddressOf CntrlLocChange1MV
        '           AddHandler btn.MouseDown, AddressOf CntrlLocChange2MD
        '           AddHandler btn.KeyDown, AddressOf DKeyDown
        '           AddHandler btn.KeyUp, AddressOf DKeyUp
        '           DrpDwnItem.Name = btn.Name + "Drp"
        '           DrpDwnItem.Text = btn.Text
        '           DrpDwnItem.Tag = btn
        '           AddHandler DrpDwnItem.Click, AddressOf DrpDwnItm_Click
        '           DropDownList.Items.Add(DrpDwnItem)
        '           DrpDwnControls.DropDown = DropDownList
        '           Contain.Controls.Add(btn)
        '           '''''''''''''''''''''

        '       ElseIf tmpInteger2 = 1 Then
        '           lblL = New vLinkLabel

        '           lblL.Text = binReader.ReadString
        '           lblL.ImageAlign = SetImgAlign(binReader.ReadInt32)
        '           lblL.Name = binReader.ReadString
        '           lblL.TextAlign = SetImgAlign(binReader.ReadInt32)
        '           lblL.ForeColor = Color.FromArgb(binReader.ReadInt32)
        '           lblL.BackColor = Color.FromArgb(binReader.ReadInt32)
        '           lblL.ActiveLinkColor = Color.FromArgb(binReader.ReadInt32)
        '           lblL.VisitedLinkColor = Color.FromArgb(binReader.ReadInt32)
        '           lblL.LinkColor = Color.FromArgb(binReader.ReadInt32)
        '           lblL.DisabledLinkColor = Color.FromArgb(binReader.ReadInt32)
        '           lblL.LinkBehavior = binReader.ReadInt32
        '           lblL.LinkVisited = binReader.ReadBoolean
        '           lblL.Font = New Font(binReader.ReadString, binReader.ReadSingle, binReader.ReadInt32, binReader.ReadInt32)

        '           lblL.UseMnemonic = binReader.ReadBoolean
        '           lblL.UseWaitCursor = binReader.ReadBoolean
        '           lblL.AutoSize = binReader.ReadBoolean
        '           lblL.TabStop = binReader.ReadBoolean
        '           lblL.TabIndex = binReader.ReadInt32
        '           lblL.Location = New Size(binReader.ReadInt32, binReader.ReadInt32)
        '           lblL.Width = binReader.ReadInt32
        '           lblL.Height = binReader.ReadInt32
        '           lblL.MaximumSize = New Size(binReader.ReadInt32, binReader.ReadInt32)
        '           lblL.MinimumSize = New Size(binReader.ReadInt32, binReader.ReadInt32)
        '           lblL.LinkArea = New System.Windows.Forms.LinkArea(binReader.ReadInt32, binReader.ReadInt32)
        '           lblL.Dock = binReader.ReadInt32
        '           lblL.RightToLeft = binReader.ReadInt32

        '           lblL.chk1 = binReader.ReadBoolean
        '           lblL.chk2 = binReader.ReadBoolean
        '           lblL.Cmbx1 = binReader.ReadInt32
        '           lblL.Cmbx2 = binReader.ReadInt32
        '           lblL.Cmbx3 = binReader.ReadInt32
        '           lblL.text1 = binReader.ReadString
        '           lblL.text2 = binReader.ReadString


        '           If binReader.ReadBoolean = True Then
        '               Try
        '                   lblL.CursorFile = binReader.ReadString
        '                   lblL.Cursor = New Cursor(Path + lblL.CursorFile)
        '               Catch ex As Exception
        '                   MsgBox(ex.Message, MsgBoxStyle.Critical, "Error !")
        '                   lblL.Cursor = Cursors.Arrow
        '               End Try
        '           Else
        '               lblL.Cursor = SetCursor(binReader.ReadUInt32)
        '           End If

        '           If binReader.ReadBoolean = True Then
        '               Try
        '                   lblL.ImageFile = binReader.ReadString
        '                   lblL.Image = Image.FromFile(Path + lblL.ImageFile)
        '               Catch ex As Exception
        '                   MsgBox(ex.Message, MsgBoxStyle.Critical, "Error !")
        '               End Try
        '           End If


        '           ''''''''''''''''''''''
        '           AddHandler ContextMenuS.Opening, AddressOf cms_Opening
        '           ContextMenuS.AutoSize = False
        '           ContextMenuS.Size = New Point(100, 70)
        '           ContextMenuS.ShowImageMargin = True
        '           Dim DrpDwnItem As New ToolStripMenuItem
        '           lblL.ContextMenuStrip = ContextMenuS
        '           lblL.Tag = False
        '           AddHandler lblL.Click, AddressOf cntrlDelete
        '           AddHandler lblL.MouseMove, AddressOf CntrlLocChange1MV
        '           AddHandler lblL.MouseDown, AddressOf CntrlLocChange2MD
        '           AddHandler lblL.KeyDown, AddressOf DKeyDown
        '           AddHandler lblL.KeyUp, AddressOf DKeyUp
        '           DrpDwnItem.Name = lblL.Name + "Drp"
        '           DrpDwnItem.Text = lblL.Text
        '           DrpDwnItem.Tag = lblL
        '           AddHandler DrpDwnItem.Click, AddressOf DrpDwnItm_Click
        '           DropDownList.Items.Add(DrpDwnItem)
        '           DrpDwnControls.DropDown = DropDownList
        '           Contain.Controls.Add(lblL)
        '           '''''''''''''''''''''
        '       ElseIf tmpInteger2 = 2 Then
        '           lbl = New vLabel

        '           lbl.Text = binReader.ReadString
        '           lbl.BorderStyle = binReader.ReadInt32
        '           lbl.Name = binReader.ReadString
        '           lbl.Font = New Font(binReader.ReadString, binReader.ReadSingle, binReader.ReadInt32, binReader.ReadInt32)
        '           lbl.FlatStyle = binReader.ReadInt32
        '           lbl.ImageAlign = SetImgAlign(binReader.ReadInt32)
        '           lbl.TextAlign = SetImgAlign(binReader.ReadInt32)
        '           lbl.ForeColor = Color.FromArgb(binReader.ReadInt32)
        '           lbl.BackColor = Color.FromArgb(binReader.ReadInt32)
        '           lbl.UseMnemonic = binReader.ReadBoolean
        '           lbl.UseWaitCursor = binReader.ReadBoolean
        '           lbl.AutoSize = binReader.ReadBoolean
        '           lbl.TabIndex = binReader.ReadInt32
        '           lbl.Location = New Size(binReader.ReadInt32, binReader.ReadInt32)
        '           lbl.Width = binReader.ReadInt32
        '           lbl.Height = binReader.ReadInt32
        '           lbl.MaximumSize = New Size(binReader.ReadInt32, binReader.ReadInt32)
        '           lbl.MinimumSize = New Size(binReader.ReadInt32, binReader.ReadInt32)
        '           lbl.Dock = binReader.ReadInt32
        '           lbl.RightToLeft = binReader.ReadInt32

        '           lbl.chk1 = binReader.ReadBoolean
        '           lbl.chk2 = binReader.ReadBoolean
        '           lbl.Cmbx1 = binReader.ReadInt32
        '           lbl.Cmbx2 = binReader.ReadInt32
        '           lbl.Cmbx3 = binReader.ReadInt32
        '           lbl.text1 = binReader.ReadString
        '           lbl.text2 = binReader.ReadString

        '           If binReader.ReadBoolean = True Then
        '               Try
        '                   lbl.CursorFile = binReader.ReadString
        '                   lbl.Cursor = New Cursor(Path + lbl.CursorFile)
        '               Catch ex As Exception
        '                   MsgBox(ex.Message, MsgBoxStyle.Critical, "Error !")
        '               End Try
        '           Else
        '               lbl.Cursor = SetCursor(binReader.ReadInt32)
        '           End If

        '           If binReader.ReadBoolean = True Then
        '               Try
        '                   lbl.ImageFile = binReader.ReadString
        '                   lbl.Image = Image.FromFile(Path + lbl.ImageFile)
        '               Catch ex As Exception
        '                   MsgBox(ex.Message, MsgBoxStyle.Critical, "Error !")
        '               End Try
        '           End If

        '           ''''''''''''''''''''''
        '           AddHandler ContextMenuS.Opening, AddressOf cms_Opening
        '           ContextMenuS.AutoSize = False
        '           ContextMenuS.Size = New Point(100, 70)
        '           ContextMenuS.ShowImageMargin = True
        '           Dim DrpDwnItem As New ToolStripMenuItem
        '           lbl.ContextMenuStrip = ContextMenuS
        '           lbl.Tag = False
        '           AddHandler lbl.Click, AddressOf cntrlDelete
        '           AddHandler lbl.MouseMove, AddressOf CntrlLocChange1MV
        '           AddHandler lbl.MouseDown, AddressOf CntrlLocChange2MD
        '           AddHandler lbl.KeyDown, AddressOf DKeyDown
        '           AddHandler lbl.KeyUp, AddressOf DKeyUp
        '           DrpDwnItem.Name = lbl.Name + "Drp"
        '           DrpDwnItem.Text = lbl.Text
        '           DrpDwnItem.Tag = lbl
        '           AddHandler DrpDwnItem.Click, AddressOf DrpDwnItm_Click
        '           DropDownList.Items.Add(DrpDwnItem)
        '           DrpDwnControls.DropDown = DropDownList
        '           Contain.Controls.Add(lbl)
        '           '''''''''''''''''''''

        '       ElseIf tmpInteger2 = 3 Then
        '           img = New vImage

        '           img.Name = binReader.ReadString
        '           img.BackColor = Color.FromArgb(binReader.ReadInt32)
        '           img.BackgroundImageLayout = binReader.ReadInt32

        '           If binReader.ReadBoolean = True Then
        '               img.ImageLocation = binReader.ReadString
        '           Else

        '           End If

        '           img.SizeMode = binReader.ReadInt32

        '           img.UseWaitCursor = binReader.ReadBoolean
        '           img.WaitOnLoad = binReader.ReadBoolean

        '           img.Location = New Size(binReader.ReadInt32, binReader.ReadInt32)
        '           img.Width = binReader.ReadInt32
        '           img.Height = binReader.ReadInt32
        '           img.MaximumSize = New Size(binReader.ReadInt32, binReader.ReadInt32)
        '           img.MinimumSize = New Size(binReader.ReadInt32, binReader.ReadInt32)
        '           img.Dock = binReader.ReadInt32

        '           img.chk1 = binReader.ReadBoolean
        '           img.chk2 = binReader.ReadBoolean
        '           img.Cmbx1 = binReader.ReadInt32
        '           img.Cmbx2 = binReader.ReadInt32
        '           img.Cmbx3 = binReader.ReadInt32
        '           img.text1 = binReader.ReadString
        '           img.text2 = binReader.ReadString

        '           If binReader.ReadBoolean = True Then
        '               Try
        '                   img.CursorFile = binReader.ReadString
        '                   img.Cursor = New Cursor(Path + img.CursorFile)
        '               Catch ex As Exception
        '                   MsgBox(ex.Message, MsgBoxStyle.Critical, "Error !")
        '               End Try
        '           Else
        '               img.Cursor = SetCursor(binReader.ReadInt32)
        '           End If

        '           If binReader.ReadBoolean = True Then
        '               Try
        '                   img.BImage = binReader.ReadString
        '                   img.BackgroundImage = Image.FromFile(Path + img.BImage)
        '               Catch ex As Exception
        '                   MsgBox(ex.Message, MsgBoxStyle.Critical, "Error !")
        '               End Try
        '           End If

        '           If binReader.ReadBoolean = True Then
        '               Try
        '                   img.ImageFile = binReader.ReadString
        '                   img.Image = Image.FromFile(Path + img.ImageFile)
        '               Catch ex As Exception
        '                   MsgBox(ex.Message, MsgBoxStyle.Critical, "Error !")
        '               End Try
        '           End If

        '           ''''''''''''''''''''''
        '           AddHandler ContextMenuS.Opening, AddressOf cms_Opening
        '           ContextMenuS.AutoSize = False
        '           ContextMenuS.Size = New Point(100, 70)
        '           ContextMenuS.ShowImageMargin = True
        '           Dim DrpDwnItem As New ToolStripMenuItem
        '           img.ContextMenuStrip = ContextMenuS
        '           img.Tag = False
        '           AddHandler img.Click, AddressOf cntrlDelete
        '           AddHandler img.MouseMove, AddressOf CntrlLocChange1MV
        '           AddHandler img.MouseDown, AddressOf CntrlLocChange2MD
        '           AddHandler img.KeyDown, AddressOf DKeyDown
        '           AddHandler img.KeyUp, AddressOf DKeyUp
        '           DrpDwnItem.Name = img.Name + "Drp"
        '           DrpDwnItem.Text = img.Text
        '           DrpDwnItem.Tag = img
        '           AddHandler DrpDwnItem.Click, AddressOf DrpDwnItm_Click
        '           DropDownList.Items.Add(DrpDwnItem)
        '           DrpDwnControls.DropDown = DropDownList
        '           Contain.Controls.Add(img)
        '           '''''''''''''''''''''
        '       ElseIf tmpInteger2 = 4 Then
        '           Pan = New vPanel

        '           Pan.Name = binReader.ReadString
        '           Pan.BackgroundImageLayout = binReader.ReadInt32
        '           Pan.BorderStyle = binReader.ReadInt32
        '           Pan.BackColor = Color.FromArgb(binReader.ReadInt32)

        '           Pan.UseWaitCursor = binReader.ReadBoolean
        '           Pan.AutoSize = binReader.ReadBoolean
        '           Pan.TabStop = binReader.ReadBoolean
        '           Pan.TabIndex = binReader.ReadInt32
        '           Pan.Width = binReader.ReadInt32
        '           Pan.Height = binReader.ReadInt32
        '           Pan.Location = New Size(binReader.ReadInt32, binReader.ReadInt32)
        '           Pan.MaximumSize = New Size(binReader.ReadInt32, binReader.ReadInt32)
        '           Pan.MinimumSize = New Size(binReader.ReadInt32, binReader.ReadInt32)
        '           Pan.Dock = binReader.ReadInt32

        '           Pan.chk1 = binReader.ReadBoolean
        '           Pan.chk2 = binReader.ReadBoolean
        '           Pan.chk3 = binReader.ReadBoolean
        '           Pan.Cmbx1 = binReader.ReadInt32
        '           Pan.Cmbx2 = binReader.ReadInt32
        '           Pan.Cmbx3 = binReader.ReadInt32
        '           Pan.text1 = binReader.ReadString
        '           Pan.text2 = binReader.ReadString

        '           If binReader.ReadBoolean = True Then
        '               Try
        '                   Pan.CursorFile = binReader.ReadString
        '                   Pan.Cursor = New Cursor(Path + Pan.CursorFile)
        '               Catch ex As Exception
        '                   MsgBox(ex.Message, MsgBoxStyle.Critical, "Error !")
        '                   Pan.Cursor = Cursors.Arrow
        '               End Try
        '           Else
        '               Pan.Cursor = SetCursor(binReader.ReadInt32)
        '           End If

        '           If binReader.ReadBoolean = True Then
        '               Try

        '                   Pan.BackgroundImage = Image.FromFile(Path + binReader.ReadString)
        '               Catch ex As Exception
        '                   MsgBox(ex.Message, MsgBoxStyle.Critical, "Error !")
        '               End Try
        '           End If

        '           ''''''''''''''''''''''
        '           AddHandler ContextMenuS.Opening, AddressOf cms_Opening
        '           ContextMenuS.AutoSize = False
        '           ContextMenuS.Size = New Point(100, 70)
        '           ContextMenuS.ShowImageMargin = True
        '           Dim DrpDwnItem As New ToolStripMenuItem
        '           Pan.ContextMenuStrip = ContextMenuS
        '           Pan.Tag = False
        '           AddHandler Pan.MouseDown, AddressOf ContrlAdd
        '           AddHandler Pan.MouseMove, AddressOf CntrlLocChange1MV
        '           AddHandler Pan.MouseDown, AddressOf CntrlLocChange2MD
        '           AddHandler Pan.KeyDown, AddressOf DKeyDown
        '           AddHandler Pan.KeyUp, AddressOf DKeyUp
        '           DrpDwnItem.Name = Pan.Name + "Drp"
        '           DrpDwnItem.Text = Pan.Text
        '           DrpDwnItem.Tag = Pan
        '           AddHandler DrpDwnItem.Click, AddressOf DrpDwnItm_Click
        '           DropDownList.Items.Add(DrpDwnItem)
        '           DrpDwnControls.DropDown = DropDownList
        '           Contain.Controls.Add(Pan)
        '           '''''''''''''''''''''

        '           If binReader.ReadBoolean = True Then
        '               ReadControls(ProjectPath + binReader.ReadString + ".dat", Pan)
        '           End If
        '       End If
        '   Next
        '   binReader.Dispose()
    End Sub

#End Region

    Private Sub TestGetLocation(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Try
            If Testc.Location.X < e.X And Testc.Location.X + Testc.Width < e.X Then
                Testc.BackColor = tmpC1
                Testc.ForeColor = tmpC2
            ElseIf Testc.Location.Y < e.Y And Testc.Location.Y + Testc.Height < e.Y Then
                Testc.BackColor = tmpC1
                Testc.ForeColor = tmpC2
            ElseIf Testc.Location.X > e.X Or Testc.Location.Y > e.Y Then
                Testc.BackColor = tmpC1
                Testc.ForeColor = tmpC2
            End If
        Catch
        End Try
    End Sub

    Private Sub ExportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportToolStripMenuItem.Click
        clean()
        clean0()

        btnTabC.ForeColor = Color.Black
        TabPanel2.Visible = False
        Me.WindowState = FormWindowState.Maximized
        NewFrame.DesktopLocation = New Size(0, 0)

        Dim nm As String = Now.ToString.Replace("/", "-").Replace(" ", "_").Replace(":", "_")
        Dim memoryImage As Bitmap
        Dim myGraphics As Graphics = NewFrame.CreateGraphics()
        Dim s As Size = NewFrame.Size

        memoryImage = New Bitmap(s.Width, s.Height, myGraphics)
        Dim memoryGraphics As Graphics = Graphics.FromImage(memoryImage)
        memoryGraphics.CopyFromScreen(PointToScreen(NewFrame.DesktopLocation).X + 25, PointToScreen(NewFrame.DesktopLocation).Y + 85, 0, 0, s)

        memoryImage.Save(ProjectPath + "\" + nm + ".bmp", ImageFormat.Bmp)
        lblStatus.Text = "Preview Saved"
    End Sub

    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim flag As New Bitmap(10, 10)
        Dim x As Integer
        Dim y As Integer
        For x = 0 To flag.Height - 1
            For y = 0 To flag.Width - 1
                flag.SetPixel(x, y, Color.FromArgb(255, 255, 255))
            Next
        Next

        Me.BackgroundImage = flag
        lblStatus.Text = "Ready"
    End Sub

    Private Sub CntrlNameFinder_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CntrlNameFinder.Tick
        Try
            DrpDwnControls.Text = NewFrame.ActiveControl.Text
        Catch
            DrpDwnControls.Text = ""
        End Try
    End Sub

    Private Sub btnTabP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTabP.Click, PropertiesToolStripMenuItem.Click
        If acShowed = True Then
            btnTabP.ForeColor = Color.White
            btnTabA.ForeColor = Color.Black
            prShowed = True
            acShowed = False
            TabPanel1.Controls.Clear()
            TabPanel1.Width = 220
            lblStatus.Text = "Control Properties.."
            ShowProperties(NewFrame.ActiveControl)
            TabPanel1.Visible = True
            PropertiesToolStripMenuItem.Checked = True
            ActionsToolStripMenuItem.Checked = False
        ElseIf prShowed = True Then
            btnTabP.ForeColor = Color.Black
            btnTabA.ForeColor = Color.Black
            prShowed = False
            TabPanel1.Visible = False
            PropertiesToolStripMenuItem.Checked = False
        ElseIf prShowed = False Then
            btnTabP.ForeColor = Color.White
            btnTabA.ForeColor = Color.Black
            prShowed = True
            acShowed = False
            TabPanel1.Controls.Clear()
            TabPanel1.Width = 220
            lblStatus.Text = "Control Properties.."
            ShowProperties(NewFrame.ActiveControl)
            TabPanel1.Visible = True
            PropertiesToolStripMenuItem.Checked = True
            ActionsToolStripMenuItem.Checked = False
        End If
    End Sub

    Private Sub btnTabA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTabA.Click, ActionsToolStripMenuItem.Click
        If prShowed = True Then
            btnTabP.ForeColor = Color.Black
            btnTabA.ForeColor = Color.White
            acShowed = True
            prShowed = False
            TabPanel1.Controls.Clear()
            TabPanel1.Width = 246
            lblStatus.Text = "Control Actions.."
            ShowActions(NewFrame.ActiveControl)
            TabPanel1.Visible = True
            ActionsToolStripMenuItem.Checked = True
            PropertiesToolStripMenuItem.Checked = False
        ElseIf acShowed = True Then
            btnTabP.ForeColor = Color.Black
            btnTabA.ForeColor = Color.Black
            acShowed = False
            TabPanel1.Visible = False
            ActionsToolStripMenuItem.Checked = False
        ElseIf acShowed = False Then
            btnTabP.ForeColor = Color.Black
            btnTabA.ForeColor = Color.White
            acShowed = True
            prShowed = False
            TabPanel1.Controls.Clear()
            TabPanel1.Width = 246
            lblStatus.Text = "Control Actions.."
            ShowActions(NewFrame.ActiveControl)
            TabPanel1.Visible = True
            ActionsToolStripMenuItem.Checked = True
            PropertiesToolStripMenuItem.Checked = False
        End If
    End Sub

    Private Sub FormPropertiesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FormPropertiesToolStripMenuItem.Click
        clean()
        clean0()
        lblStatus.Text = "Frame Properties.."

        FrameProperties.cmbxAutoSizeMode.SelectedIndex = NewFrame.AutoSizeMode
        FrameProperties.cmbxBImageLayout.SelectedIndex = NewFrame.BackgroundImageLayout
        FrameProperties.cmbxFormBStyle.SelectedIndex = NewFrame.FormBorderStyle
        FrameProperties.cmbxRightToLeft.SelectedIndex = NewFrame.RightToLeft
        FrameProperties.cmbxSizeGrpStyle.SelectedIndex = NewFrame.SizeGripStyle
        FrameProperties.cmbxStartPosition.SelectedIndex = NewFrame.StartPosition
        FrameProperties.cmbxWinState.SelectedIndex = NewFrame.WindowState

        If GetCursor(NewFrame.Cursor) = False Then
            FrameProperties.chkCursorFrmFile.Checked = True
            FrameProperties.cmbxCursor.Enabled = False
            FrameProperties.btnCursor.Enabled = True
            FrameProperties.txtCursor.Enabled = True
            FrameProperties.txtCursor.Text = NewFrame.CursorFile
        Else
            FrameProperties.cmbxCursor.SelectedIndex = GetCursor(NewFrame.Cursor)
        End If

        FrameProperties.chkAutoScroll.Checked = NewFrame.AutoScroll
        FrameProperties.chkAutoSize.Checked = NewFrame.AutoSize
        FrameProperties.chkCntrlBox.Checked = NewFrame.ControlBox
        FrameProperties.chkMaxbx.Checked = NewFrame.MaximizeBox
        FrameProperties.chkMinBx.Checked = NewFrame.MinimizeBox
        FrameProperties.chkRight2LeftLayout.Checked = NewFrame.RightToLeftLayout
        FrameProperties.chkShowIcon.Checked = NewFrame.ShowIcon
        FrameProperties.chkShowInTaskbar.Checked = NewFrame.ShowInTaskbar
        FrameProperties.chkTopmost.Checked = NewFrame.TopMost

        FrameProperties.NumUpDownOpacity.Value = NewFrame.Opacity * 100

        FrameProperties.btnBackColor.BackColor = NewFrame.BackColor
        FrameProperties.btnForeColor.BackColor = NewFrame.ForeColor
        FrameProperties.btnTransKey.BackColor = NewFrame.TransparencyKey

        FrameProperties.txtText.Text = NewFrame.Text
        FrameProperties.txtSizeW.Text = NewFrame.Width
        FrameProperties.txtSizeH.Text = NewFrame.Height
        FrameProperties.txtMinSizeW.Text = NewFrame.MinimumSize.Width
        FrameProperties.txtMinSizeH.Text = NewFrame.MinimumSize.Height
        FrameProperties.txtMaxSizeW.Text = NewFrame.MaximumSize.Width
        FrameProperties.txtMaxSizeH.Text = NewFrame.MaximumSize.Height
        FrameProperties.txtIcon.Text = NewFrame.IconFile
        FrameProperties.txtFont.Text = NewFrame.Font.Name
        FrameProperties.txtFont.Font = NewFrame.Font
        FrameProperties.txtBackgroundImage.Text = "(Image)"


        FrameProperties.ShowDialog()
    End Sub

    Private Sub btnTabC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTabC.Click, ControlsToolStripMenuItem.Click
        If TabPanel2.Visible = False Then
            btnTabC.ForeColor = Color.White
            TabPanel2.Visible = True
            ControlsToolStripMenuItem.Checked = True
        ElseIf TabPanel2.Visible = True Then
            btnTabC.ForeColor = Color.Black
            TabPanel2.Visible = False
            ControlsToolStripMenuItem.Checked = False
        End If
    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        If p = True Then
            lblStatus.Text = "Saving.."
            Save()
        End If
    End Sub

    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            DrpDwnControls.DropDownItems.Clear()

            lblStatus.Text = "Opening..."

            Dim flag As Bitmap
            flag = New Bitmap(FormDotXY, FormDotXY)
            flag.SetPixel(0, 0, Color.Black)

            If p = True Then
                NewFrame.Close()
                If NewFrame.IsDisposed = False Then
                    GoTo en
                End If
            End If

            p = True
            NewFrame = New Frame
            AddHandler NewFrame.MouseMove, AddressOf GetLocation
            AddHandler NewFrame.SizeChanged, AddressOf DSzChange
            AddHandler NewFrame.MouseDown, AddressOf ContrlAdd
            AddHandler NewFrame.KeyDown, AddressOf DKeyDown
            AddHandler NewFrame.KeyUp, AddressOf DKeyUp
            AddHandler NewFrame.FormClosing, AddressOf F_FormClosing
            AddHandler NewFrame.DragDrop, AddressOf D_DragDrop
            AddHandler NewFrame.DragEnter, AddressOf D_DragEnter
            AddHandler NewFrame.ControlRemoved, AddressOf F_ControlRemoved

            Dim binReader As New BinaryReader( _
      File.Open(OpenFileDialog1.FileName, FileMode.Open))
            binReader.BaseStream.Seek(0, SeekOrigin.Begin)

            Dim fi As New FileInfo(OpenFileDialog1.FileName)

            ProjectPath = fi.DirectoryName

            NewFrame.AutoSizeMode = binReader.ReadInt32
            NewFrame.BackgroundImageLayout = binReader.ReadInt32
            NewFrame.FormBorderStyle = binReader.ReadInt32
            NewFrame.RightToLeft = binReader.ReadInt32
            NewFrame.SizeGripStyle = binReader.ReadInt32
            NewFrame.StartPosition = binReader.ReadInt32
            NewFrame.WindowState = binReader.ReadInt32

            NewFrame.AutoScroll = binReader.ReadBoolean
            NewFrame.AutoSize = binReader.ReadBoolean
            NewFrame.ControlBox = binReader.ReadBoolean
            NewFrame.MaximizeBox = binReader.ReadBoolean
            NewFrame.MinimizeBox = binReader.ReadBoolean
            NewFrame.RightToLeftLayout = binReader.ReadBoolean
            NewFrame.ShowIcon = binReader.ReadBoolean
            NewFrame.ShowInTaskbar = binReader.ReadBoolean
            NewFrame.TopMost = binReader.ReadBoolean
            NewFrame.Opacity = binReader.ReadDouble
            NewFrame.BackColor = Color.FromArgb(binReader.ReadInt32)
            NewFrame.ForeColor = Color.FromArgb(binReader.ReadInt32)
            NewFrame.TransparencyKey = Color.FromArgb(binReader.ReadInt32)

            NewFrame.Text = binReader.ReadString
            NewFrame.Width = binReader.ReadInt32
            NewFrame.Height = binReader.ReadInt32
            NewFrame.MinimumSize = New Size(binReader.ReadInt32, binReader.ReadInt32)
            NewFrame.MaximumSize = New Size(binReader.ReadInt32, binReader.ReadInt32)

            NewFrame.Font = New Font(binReader.ReadString, binReader.ReadSingle, binReader.ReadInt32, binReader.ReadInt32)

            If binReader.ReadBoolean = True Then
                Try
                    NewFrame.CursorFile = ProjectPath + "\" + binReader.ReadString
                    NewFrame.Cursor = New Cursor(NewFrame.CursorFile)
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error !")
                    NewFrame.Cursor = Cursors.Arrow
                End Try
            Else
                SetCursor(binReader.ReadInt32)
            End If

            If binReader.ReadBoolean = True Then
                Try
                    NewFrame.BackgroundImage = Image.FromFile(ProjectPath + binReader.ReadString)
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error !")
                    NewFrame.BackgroundImage = flag
                End Try
            Else
                NewFrame.BackgroundImage = flag
            End If

            If binReader.ReadBoolean = True Then
                Try
                    NewFrame.IconFile = ProjectPath + "\" + binReader.ReadString
                    NewFrame.Icon = New Icon(NewFrame.IconFile)
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error !")
                End Try
            End If

            i = binReader.ReadInt32
            j = binReader.ReadInt32
            k = binReader.ReadInt32
            l = binReader.ReadInt32
            m = binReader.ReadInt32
            n = binReader.ReadInt32


            If binReader.ReadBoolean = True Then
                binReader.Dispose()
                ReadControls(ProjectPath + "\" + "Controls.dat", NewFrame)
            End If

            NewFrame.Location = New Size(0, 0)
            NewFrame.MdiParent = Me
            NewFrame.Show()

            For Each c In NewFrame.Controls
                If TypeOf c Is Panel Then
                    c.SendtoBack()
                End If
            Next

            Try
                binReader.Dispose()
            Catch
            End Try
en:
            lblProjectPath.Text = ProjectPath
            lblStatus.Text = "Ready"

        End If

    End Sub

    Private Sub NewToolStripMenuItem_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.MouseHover, OpenToolStripMenuItem.MouseHover, NewToolStripMenuItem.MouseHover, MakeExeToolStripMenuItem.MouseHover
        If sender.ShortcutKeyDisplayString IsNot Nothing Then
            lblStatus.Text = sender.Text + "  [" + sender.ShortcutKeyDisplayString + "]"
        Else
            lblStatus.Text = sender.Text
        End If
    End Sub

    Private Sub SelectAllToolStripMenuItem_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PanelsToolStripMenuItem.MouseHover, SelectAllToolStripMenuItem.MouseHover, LinkLabelsToolStripMenuItem.MouseHover, LabelsToolStripMenuItem.MouseHover, ImagesToolStripMenuItem.MouseHover, ButtonsToolStripMenuItem.MouseHover, AllToolStripMenuItem.MouseHover
        If sender.ShortcutKeyDisplayString IsNot Nothing Then
            lblStatus.Text = sender.Text + "  [" + sender.ShortcutKeyDisplayString + "]"
        Else
            lblStatus.Text = sender.Text
        End If
    End Sub

    Private Sub RemoveAllToolStripMenuItem_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnselectAllToolStripMenuItem.MouseHover, RemoveAllToolStripMenuItem.MouseHover
        If sender.ShortcutKeyDisplayString IsNot Nothing Then
            lblStatus.Text = sender.Text + "  [" + sender.ShortcutKeyDisplayString + "]"
        Else
            lblStatus.Text = sender.Text
        End If
    End Sub

    Private Sub PropertiesToolStripMenuItem_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PropertiesToolStripMenuItem.MouseHover, FormPropertiesToolStripMenuItem.MouseHover, ExportToolStripMenuItem.MouseHover
        If sender.ShortcutKeyDisplayString IsNot Nothing Then
            lblStatus.Text = sender.Text + "  [" + sender.ShortcutKeyDisplayString + "]"
        Else
            lblStatus.Text = sender.Text
        End If
    End Sub

    Private Sub ButttonToolStripMenuItem_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PanelToolStripMenuItem.MouseHover, LinkLabelToolStripMenuItem.MouseHover, LabelToolStripMenuItem.MouseHover, ImageToolStripMenuItem.MouseHover, ButttonToolStripMenuItem.MouseHover
        If sender.ShortcutKeyDisplayString IsNot Nothing Then
            lblStatus.Text = sender.Text + "  [" + sender.ShortcutKeyDisplayString + "]"
        Else
            lblStatus.Text = sender.Text
        End If
    End Sub

    Private Sub TestNowToolStripMenuItem_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TestNowToolStripMenuItem.MouseHover
        If sender.ShortcutKeyDisplayString IsNot Nothing Then
            lblStatus.Text = sender.Text + "  [" + sender.ShortcutKeyDisplayString + "]"
        Else
            lblStatus.Text = sender.Text
        End If
    End Sub

    Private Sub HorizontallyToolStripMenuItem_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendToBackToolStripMenuItem.MouseHover, OrderToolStripMenuItem.MouseHover, BringToFrontToolStripMenuItem.MouseHover, VerticallyToolStripMenuItem.MouseHover, HorizontallyToolStripMenuItem.MouseHover
        If sender.ShortcutKeyDisplayString IsNot Nothing Then
            lblStatus.Text = sender.Text + "  [" + sender.ShortcutKeyDisplayString + "]"
        Else
            lblStatus.Text = sender.Text
        End If
    End Sub

    Private Sub HelpToolStripMenuItem1_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportABugToolStripMenuItem.MouseHover, HelpToolStripMenuItem1.MouseHover, EmailToUSToolStripMenuItem.MouseHover, AboutToolStripMenuItem.MouseHover
        If sender.ShortcutKeyDisplayString IsNot Nothing Then
            lblStatus.Text = sender.Text + "  [" + sender.ShortcutKeyDisplayString + "]"
        Else
            lblStatus.Text = sender.Text
        End If
    End Sub

    Private Sub FileToolStripMenuItem_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem4.MouseHover, ToolStripMenuItem3.MouseHover, TestToolStripMenuItem.MouseHover, HelpToolStripMenuItem.MouseHover, FormatToolStripMenuItem.MouseHover, FileToolStripMenuItem.MouseHover, EditToolStripMenuItem.MouseHover
        lblStatus.Text = sender.Text
    End Sub

    Private Sub BringToFrontToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BringToFrontToolStripMenuItem.Click
        Try
            NewFrame.ActiveControl.BringToFront()
        Catch
        End Try
    End Sub

    Private Sub SendToBackToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendToBackToolStripMenuItem.Click
        Try
            NewFrame.ActiveControl.SendToBack()
        Catch
        End Try
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Dispose()
    End Sub

#Region "Test$"

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim linesPerPage As Single = 0
        Dim yPos As Single = 0
        Dim count As Integer = 0
        Dim leftMargin As Single = e.MarginBounds.Left
        Dim topMargin As Single = e.MarginBounds.Top
        Dim line As String = Nothing

        ' Calculate the number of lines per page.
        linesPerPage = e.MarginBounds.Height / printFont.GetHeight(e.Graphics)

        ' Print each line of the file.
        While count < linesPerPage
            line = streamToPrint.ReadLine()
            If line Is Nothing Then
                Exit While
            End If
            yPos = topMargin + count * printFont.GetHeight(e.Graphics)
            e.Graphics.DrawString(line, printFont, Brushes.Black, leftMargin, yPos, New StringFormat())
            count += 1
        End While

        ' If more lines exist, print another page.
        If (line IsNot Nothing) Then
            e.HasMorePages = True
        Else
            e.HasMorePages = False
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Testc.BackColor = tmpC1
        Testc.ForeColor = tmpC2
        Timer1.Enabled = False
    End Sub

    Private Sub TestNowToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TestNowToolStripMenuItem.Click
        If p = True Then
            clean()
            clean0()

            lblStatus.Text = "Testing.."

            testForm = New Form

            testForm.AutoSizeMode = NewFrame.AutoSizeMode
            testForm.BackgroundImageLayout = NewFrame.BackgroundImageLayout
            testForm.FormBorderStyle = NewFrame.FormBorderStyle
            testForm.RightToLeft = NewFrame.RightToLeft
            testForm.SizeGripStyle = NewFrame.SizeGripStyle
            testForm.StartPosition = NewFrame.StartPosition
            testForm.WindowState = NewFrame.WindowState
            testForm.Cursor = NewFrame.Cursor

            testForm.AutoScroll = NewFrame.AutoScroll
            testForm.AutoSize = NewFrame.AutoSize
            testForm.ControlBox = NewFrame.ControlBox
            testForm.MaximizeBox = NewFrame.MaximizeBox
            testForm.MinimizeBox = NewFrame.MinimizeBox
            testForm.RightToLeftLayout = NewFrame.RightToLeftLayout
            testForm.ShowIcon = NewFrame.ShowIcon
            testForm.ShowInTaskbar = NewFrame.ShowInTaskbar
            testForm.TopMost = NewFrame.TopMost
            testForm.Opacity = NewFrame.Opacity
            testForm.BackColor = NewFrame.BackColor
            testForm.ForeColor = NewFrame.ForeColor
            testForm.TransparencyKey = NewFrame.TransparencyKey

            testForm.Text = NewFrame.Text
            testForm.Width = NewFrame.Width
            testForm.Height = NewFrame.Height
            testForm.MinimumSize = New Point(Val(NewFrame.MinimumSize.Width), Val(NewFrame.MinimumSize.Height))
            testForm.MaximumSize = New Point(Val(NewFrame.MaximumSize.Width), Val(NewFrame.MaximumSize.Height))
            testForm.Icon = NewFrame.Icon
            testForm.Font = NewFrame.Font

            If BImageChanged = True Then
                testForm.BackgroundImage = NewFrame.BackgroundImage
            End If

            For Each c As Control In NewFrame.Controls
                TestControls(c, testForm)
            Next

            AddHandler testForm.MouseMove, AddressOf TestGetLocation
            AddHandler testForm.KeyDown, AddressOf TestFrameESC
            AddHandler testForm.FormClosing, AddressOf TestFrameClosing

            Me.Hide()
            testForm.ShowDialog()
        End If
    End Sub

    Sub TestControls(ByVal c As Control, ByVal Contain As Control)
        If TypeOf c Is vButton Then
            Dim vBtn As New vButton
            btn = c

            vBtn.Text = btn.Text
            vBtn.BackColor = btn.BackColor
            vBtn.BackgroundImage = btn.BackgroundImage
            vBtn.BackgroundImageLayout = btn.BackgroundImageLayout
            vBtn.Cursor = btn.Cursor
            vBtn.FlatAppearance.BorderColor = btn.FlatAppearance.BorderColor
            vBtn.FlatAppearance.BorderSize = btn.FlatAppearance.BorderSize
            vBtn.FlatAppearance.MouseDownBackColor = btn.FlatAppearance.MouseDownBackColor
            vBtn.FlatAppearance.MouseOverBackColor = btn.FlatAppearance.MouseOverBackColor
            vBtn.FlatStyle = btn.FlatStyle
            vBtn.Font = btn.Font
            vBtn.ForeColor = btn.ForeColor
            vBtn.Image = btn.Image
            vBtn.ImageAlign = btn.ImageAlign
            vBtn.TextAlign = btn.TextAlign
            vBtn.TextImageRelation = btn.TextImageRelation
            vBtn.UseMnemonic = btn.UseMnemonic
            vBtn.UseVisualStyleBackColor = btn.UseVisualStyleBackColor
            vBtn.UseWaitCursor = btn.UseWaitCursor
            vBtn.AutoSize = btn.AutoSize
            vBtn.TabStop = btn.TabStop
            vBtn.TabIndex = btn.TabIndex
            vBtn.Location = btn.Location
            vBtn.Size = btn.Size
            vBtn.MinimumSize = btn.MinimumSize
            vBtn.MaximumSize = btn.MaximumSize
            vBtn.Dock = btn.Dock
            vBtn.RightToLeft = btn.RightToLeft

            vBtn.int(0) = btn.int(0)
            vBtn.int(1) = btn.int(1)
            vBtn.int(2) = btn.int(2)
            vBtn.int(3) = btn.int(3)
            vBtn.int(4) = btn.int(4)
            vBtn.int(5) = btn.int(5)

            vBtn.bn(0) = btn.bn(0)
            vBtn.bn(1) = btn.bn(1)
            vBtn.bn(2) = btn.bn(2)
            vBtn.bn(3) = btn.bn(3)
            vBtn.bn(4) = btn.bn(4)

            vBtn.st(0) = btn.st(0)
            vBtn.st(1) = btn.st(1)

            AddHandler vBtn.Click, AddressOf TestOnClick
            AddHandler vBtn.MouseHover, AddressOf TestOnMouseHover

            Contain.Controls.Add(vBtn)
        ElseIf TypeOf c Is vLinkLabel Then
            Dim vLbll As New vLinkLabel
            lblL = c

            vLbll.Text = lblL.Text
            vLbll.Cursor = lblL.Cursor
            vLbll.Font = lblL.Font
            vLbll.Image = lblL.Image
            vLbll.ImageAlign = lblL.ImageAlign
            vLbll.TextAlign = lblL.TextAlign
            vLbll.ForeColor = lblL.ForeColor
            vLbll.BackColor = lblL.BackColor
            vLbll.ActiveLinkColor = lblL.ActiveLinkColor
            vLbll.LinkVisited = lblL.LinkVisited
            vLbll.LinkColor = lblL.LinkColor
            vLbll.DisabledLinkColor = lblL.DisabledLinkColor
            vLbll.LinkBehavior = lblL.LinkBehavior
            vLbll.LinkVisited = lblL.LinkVisited
            vLbll.UseMnemonic = lblL.UseMnemonic
            vLbll.UseWaitCursor = lblL.UseWaitCursor
            vLbll.AutoSize = lblL.AutoSize
            vLbll.TabStop = lblL.TabStop
            vLbll.TabIndex = lblL.TabIndex
            vLbll.Location = lblL.Location
            vLbll.Size = lblL.Size
            vLbll.MaximumSize = lblL.MaximumSize
            vLbll.MinimumSize = lblL.MinimumSize
            vLbll.LinkArea = lblL.LinkArea
            vLbll.Dock = lblL.Dock
            vLbll.RightToLeft = lblL.RightToLeft

            vLbll.int(0) = lblL.int(0)
            vLbll.int(1) = lblL.int(1)
            vLbll.int(2) = lblL.int(2)
            vLbll.int(3) = lblL.int(3)
            vLbll.int(4) = lblL.int(4)
            vLbll.int(5) = lblL.int(5)

            vLbll.bn(0) = lblL.bn(0)
            vLbll.bn(1) = lblL.bn(1)
            vLbll.bn(2) = lblL.bn(2)
            vLbll.bn(3) = lblL.bn(3)
            vLbll.bn(4) = lblL.bn(4)

            vLbll.st(0) = lblL.st(0)
            vLbll.st(1) = lblL.st(1)

            AddHandler vLbll.Click, AddressOf TestOnClick
            AddHandler vLbll.MouseHover, AddressOf TestOnMouseHover

            Contain.Controls.Add(vLbll)
        ElseIf TypeOf c Is vLabel Then
            Dim vLbl As New vLabel
            lbl = c

            vLbl.Text = lbl.Text
            vLbl.BorderStyle = lbl.BorderStyle
            vLbl.Cursor = lbl.Cursor
            vLbl.Font = lbl.Font
            vLbl.FlatStyle = lbl.FlatStyle
            vLbl.Image = lbl.Image
            vLbl.ImageAlign = lbl.ImageAlign
            vLbl.TextAlign = lbl.TextAlign
            vLbl.ForeColor = lbl.ForeColor
            vLbl.BackColor = lbl.BackColor
            vLbl.UseMnemonic = lbl.UseMnemonic
            vLbl.UseWaitCursor = lbl.UseWaitCursor
            vLbl.AutoSize = lbl.AutoSize
            vLbl.TabIndex = lbl.TabIndex
            vLbl.Location = lbl.Location
            vLbl.Size = lbl.Size
            vLbl.MaximumSize = lbl.MaximumSize
            vLbl.MinimumSize = lbl.MinimumSize
            vLbl.Dock = lbl.Dock
            vLbl.RightToLeft = lbl.RightToLeft

            vLbl.int(0) = lbl.int(0)
            vLbl.int(1) = lbl.int(1)
            vLbl.int(2) = lbl.int(2)
            vLbl.int(3) = lbl.int(3)
            vLbl.int(4) = lbl.int(4)
            vLbl.int(5) = lbl.int(5)

            vLbl.bn(0) = lbl.bn(0)
            vLbl.bn(1) = lbl.bn(1)
            vLbl.bn(2) = lbl.bn(2)
            vLbl.bn(3) = lbl.bn(3)
            vLbl.bn(4) = lbl.bn(4)

            vLbl.st(0) = lbl.st(0)
            vLbl.st(1) = lbl.st(1)


            AddHandler vLbl.Click, AddressOf TestOnClick
            AddHandler vLbl.MouseHover, AddressOf TestOnMouseHover

            Contain.Controls.Add(vLbl)
        ElseIf TypeOf c Is PictureBox Then
            Dim vImg As New vImage
            img = c

            vImg.Cursor = img.Cursor
            vImg.BackColor = img.BackColor
            vImg.BackgroundImage = img.BackgroundImage
            vImg.BackgroundImageLayout = img.BackgroundImageLayout
            vImg.Image = img.Image
            vImg.ImageLocation = img.ImageLocation
            vImg.SizeMode = img.SizeMode
            vImg.UseWaitCursor = img.UseWaitCursor
            vImg.WaitOnLoad = img.WaitOnLoad

            vImg.Location = img.Location
            vImg.Size = img.Size
            vImg.MaximumSize = img.MaximumSize
            vImg.MinimumSize = img.MinimumSize
            vImg.Dock = img.Dock

            vImg.int(0) = img.int(0)
            vImg.int(1) = img.int(1)
            vImg.int(2) = img.int(2)
            vImg.int(3) = img.int(3)
            vImg.int(4) = img.int(4)
            vImg.int(5) = img.int(5)

            vImg.bn(0) = img.bn(0)
            vImg.bn(1) = img.bn(1)
            vImg.bn(2) = img.bn(2)
            vImg.bn(3) = img.bn(3)
            vImg.bn(4) = img.bn(4)

            vImg.st(0) = img.st(0)
            vImg.st(1) = img.st(1)

            AddHandler vImg.Click, AddressOf TestOnClick
            AddHandler vImg.MouseHover, AddressOf TestOnMouseHover

            Contain.Controls.Add(vImg)
        ElseIf TypeOf c Is Panel Then
            Dim vPan As New vPanel
            Pan = c

            vPan.BackgroundImage = Pan.BackgroundImage
            vPan.BackgroundImageLayout = Pan.BackgroundImageLayout
            vPan.BorderStyle = Pan.BorderStyle
            vPan.Cursor = Pan.Cursor
            vPan.BackColor = Pan.BackColor
            vPan.UseWaitCursor = Pan.UseWaitCursor

            vPan.AutoSize = Pan.AutoSize
            vPan.TabStop = Pan.TabStop
            vPan.TabIndex = Pan.TabIndex
            vPan.Location = Pan.Location
            vPan.Size = Pan.Size
            vPan.MaximumSize = Pan.MaximumSize
            vPan.MinimumSize = Pan.MinimumSize
            vPan.Dock = Pan.Dock

            vPan.int(0) = Pan.int(0)
            vPan.int(1) = Pan.int(1)
            vPan.int(2) = Pan.int(2)
            vPan.int(3) = Pan.int(3)
            vPan.int(4) = Pan.int(4)
            vPan.int(5) = Pan.int(5)

            vPan.bn(0) = Pan.bn(0)
            vPan.bn(1) = Pan.bn(1)
            vPan.bn(2) = Pan.bn(2)
            vPan.bn(3) = Pan.bn(3)
            vPan.bn(4) = Pan.bn(4)

            vPan.st(0) = Pan.st(0)
            vPan.st(1) = Pan.st(1)

            AddHandler vPan.Click, AddressOf TestOnClick
            AddHandler vPan.MouseHover, AddressOf TestOnMouseHover

            If Pan.bn(3) = True Then
                AddHandler vPan.MouseDown, AddressOf TestMouseDown
                AddHandler vPan.MouseMove, AddressOf TestMouseMove
            End If

            If Pan.Controls.Count > 0 Then
                For Each cn As Control In Pan.Controls
                    TestControls(cn, vPan)
                Next
            End If
            Contain.Controls.Add(vPan)
        ElseIf TypeOf c Is TextBox Then
            Dim vTex As New vTextBox
            Tex = c

            vTex.Text = Tex.Text
            vTex.BackColor = Tex.BackColor
            vTex.BorderStyle = Tex.BorderStyle
            vTex.Cursor = Tex.Cursor
            vTex.Font = Tex.Font
            vTex.ForeColor = Tex.ForeColor
            vTex.TextAlign = Tex.TextAlign
            vTex.Multiline = Tex.Multiline
            vTex.UseWaitCursor = Tex.UseWaitCursor
            vTex.ReadOnly = Tex.ReadOnly
            vTex.WordWrap = Tex.WordWrap

            vTex.TabStop = Tex.TabStop
            vTex.TabIndex = Tex.TabIndex
            vTex.Location = Tex.Location
            vTex.Size = Tex.Size
            vTex.MinimumSize = Tex.MinimumSize
            vTex.MaximumSize = Tex.MaximumSize
            vTex.Dock = Tex.Dock
            vTex.RightToLeft = Tex.RightToLeft
            Contain.Controls.Add(vTex)
        End If
    End Sub

    Private Sub TestFrameESC(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            sender.Close()
            Me.WindowState = FormWindowState.Maximized
            lblStatus.Text = "Testing Completed"
        End If
    End Sub

    Private Sub TestFrameClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs)
        lblStatus.Text = "Testing Completed"
        Me.Show()
    End Sub

    Dim printFont As Font
    Dim streamToPrint As StreamReader

    Private Sub TestOnClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim tmpSt As String = ""

        If sender.bn(4) = True Then
            If sender.BackColor = SystemColors.Control Then
                tmpC1 = Color.Transparent
            Else
                tmpC1 = sender.BackColor
            End If
            tmpC2 = sender.Forecolor
            sender.BackColor = Color.FromArgb(sender.int(3))
            sender.ForeColor = Color.FromArgb(sender.int(5))
            Testc = sender
            Timer1.Enabled = True
        End If

        If sender.int(0) = 1 Then

            Try
                If sender.bn(0) = False Then
                    If sender.st(1).length <= 1 Then
                        tmpSt = sender.st(0) + " " + sender.st(1)
                    Else
                        tmpSt = sender.st(0)
                    End If
                Else
                    If sender.st(1).length <= 1 Then
                        tmpSt = My.Computer.FileSystem.CurrentDirectory + "\" + sender.st(0) + " " + sender.st(1)
                    Else
                        tmpSt = My.Computer.FileSystem.CurrentDirectory + "\" + sender.st(0)
                    End If
                End If

                Shell(tmpSt, sender.int(1), sender.bn(1))
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error !")
            End Try

        ElseIf sender.int(0) = 2 Then

            Try
                If sender.bn(0) = False Then
                    tmpSt = sender.st(0)
                Else
                    tmpSt = My.Computer.FileSystem.CurrentDirectory + "\" + sender.st(0)
                End If

                Process.Start(tmpSt)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error !")
            End Try

        ElseIf sender.int(0) = 3 Then

            Try
                MsgBox(sender.st(0), sender.int(1), sender.st(1))
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error !")
            End Try

        ElseIf sender.int(0) = 4 Then

            Try
                Process.Start(sender.st(0))
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error !")
            End Try

        ElseIf sender.int(0) = 5 Then

            Try
                My.Computer.Network.DownloadFile(sender.st(0), sender.st(1))
                MessageBox.Show("Downloading Started", "Downloading..")
                Shell(sender.st(1))
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error !")
            End Try

        ElseIf sender.int(0) = 6 Then
            Try
                If sender.bn(0) = False Then
                    tmpSt = sender.st(0)
                Else
                    tmpSt = My.Computer.FileSystem.CurrentDirectory + "\" + sender.st(0)
                End If

                streamToPrint = New StreamReader(tmpSt)

                Try
                    printFont = New Font("Arial", 10)
                    PrintDocument1.Print()
                Finally
                    streamToPrint.Close()
                End Try
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error !")
            End Try
        ElseIf sender.int(0) = 7 Then
            Try
                If TypeOf sender Is LinkLabel Then
                    If sender.Int(1) = 0 Then
                        Clipboard.SetImage(sender.Image)
                    Else
                        Clipboard.SetText(sender.Text)
                    End If
                ElseIf TypeOf sender Is Panel Then
                    Clipboard.SetImage(sender.BackgroundImage)
                ElseIf TypeOf sender Is Label Then
                    If sender.Int(1) = 0 Then
                        Clipboard.SetImage(sender.Image)
                    Else
                        Clipboard.SetText(sender.Text)
                    End If
                ElseIf TypeOf sender Is TextBox Then
                    Clipboard.SetText(sender.Text)
                ElseIf TypeOf sender Is PictureBox Then
                    If sender.Int(1) = 0 Then
                        Clipboard.SetImage(sender.BackgroundImage)
                    Else
                        Clipboard.SetImage(sender.Image)
                    End If
                Else
                    If sender.Int(1) = 0 Then
                        Clipboard.SetImage(sender.BackgroundImage)
                    ElseIf sender.Int(1) = 1 Then
                        Clipboard.SetImage(sender.Image)
                    Else
                        Clipboard.SetText(sender.Text)
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error !")
            End Try
        ElseIf sender.int(0) = 8 Then
            testForm.WindowState = FormWindowState.Maximized
        ElseIf sender.int(0) = 9 Then
            testForm.WindowState = FormWindowState.Minimized
        ElseIf sender.int(0) = 10 Then
            testForm.Close()
        End If

        If sender.bn(2) = True Then
            testForm.Close()
        End If
    End Sub

    Private Sub TestOnMouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If sender.bn(4) = True Then
            If sender.BackColor = SystemColors.Control Then
                tmpC1 = Color.Transparent
            Else
                tmpC1 = sender.BackColor
            End If
            tmpC2 = sender.Forecolor
            sender.BackColor = Color.FromArgb(sender.int(2))
            sender.ForeColor = Color.FromArgb(sender.int(4))

            Testc = sender
        End If
    End Sub

    Dim mouseOffset2 As Point
    Private Sub TestMouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        mouseOffset2 = New Point(-e.X, -e.Y)
    End Sub

    Private Sub TestMouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            Dim mousePos = Control.MousePosition
            mousePos.Offset(mouseOffset2.X, mouseOffset2.Y)
            testForm.Location = mousePos
        End If
    End Sub

#End Region

End Class

'Add a cmd btn in cntxt mnu to show properties,send back,bring front