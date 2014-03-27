Public Class Main

#Region "Variable Declarations..."
    Private CodeWin As New Form 'Code window
    Private DesignWin As New Form 'Design window

    Dim btnCanAdd As Boolean = False 'For adding btn
    Dim lblCanAdd As Boolean = False 'For adding lbl
    Dim lblLCanAdd As Boolean = False 'For adding link lbl

    Dim cDelete As Boolean = False 'To del contrl
    Dim cLoc As Boolean = False  'To change cntrl loc
    Dim cSize As Boolean = False 'To change cntrl size

    Dim DropDownList As New ToolStripDropDown '(dropdown)btn to select each control
    Dim prp As New PChooser 'Properties panel

    Dim i, j, k As Integer 'count btns,lbls,link lbls
    Dim mouseOffset As Point 'For control to change it's location

    Dim btn(50) As Button 'Button
    Dim btnID(50) As ToolStripMenuItem 'btn to select each control

    Dim lbl(50) As Label 'lbl
    Dim lblID(50) As ToolStripMenuItem 'btn to select each control

    Dim lblL(10) As LinkLabel 'link lbl
    Dim lblLID(10) As ToolStripMenuItem 'btn to select each control

    Dim MultiAddCntrl As Boolean
    Dim frmProp As Boolean

    'for new properties
    Dim txtm As New MaskedTextBox
    Dim cmx As New ComboBox
    Dim chk As New CheckBox
#End Region

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
        JToolStripMenuItem.Enabled = True

        DesignWin.MdiParent = Me
        DesignWin.Text = "Design Window " + "-Untitled"
        DesignWin.MaximizeBox = False
        DesignWin.Icon = My.Resources.Design
        DesignWin.Location = New Point(0, 0)
        DesignWin.Opacity = 1
        AddHandler DesignWin.FormClosing, AddressOf DesignClosing 'to hide when closing
        AddHandler DesignWin.MouseMove, AddressOf XY 'location
        AddHandler DesignWin.SizeChanged, AddressOf DSzChange 'size
        AddHandler DesignWin.MouseDown, AddressOf ContrlAdd 'add control  
        DesignWin.Show()

    End Sub

    'add control
    Private Sub ContrlAdd(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If btnCanAdd = True Then
            If i >= 50 Then
                GoTo en
            End If
            i = i + 1
            btn(i) = New Button
            btn(i).Name = "btn" + i.ToString
            btn(i).Text = "Button " + i.ToString
            btn(i).Size = New Point(75, 23)
            btn(i).Location = e.Location
            AddHandler btn(i).Click, AddressOf cntrlDelete 'cntrl delete
            AddHandler btn(i).MouseMove, AddressOf CntrlLocChange1MV 'Change location,sz
            AddHandler btn(i).MouseDown, AddressOf CntrlLocChange2MD 'Change location,sz

            DesignWin.Controls.Add(btn(i))
            ControlSize.Text = btn(i).Size.ToString

            btnID(i) = New ToolStripMenuItem
            AddHandler btnID(i).Click, AddressOf Scnt 'select the specific control
            btnID(i).Text = btn(i).Text
            btnID(i).Name = "a" + btn(i).Name
            DropDownList.Items.Add(btnID(i))
            CntrlAdded_Selected.DropDown = DropDownList

        ElseIf lblCanAdd = True Then
            If j >= 50 Then
                GoTo en
            End If
            j = j + 1
            lbl(j) = New Label
            lbl(j).Name = "lbl" + j.ToString
            lbl(j).Text = "Label " + j.ToString
            lbl(j).BackColor = Color.YellowGreen
            lbl(j).Size = New Point(43, 13)
            lbl(j).Location = e.Location
            AddHandler lbl(j).Click, AddressOf cntrlDelete 'cntrl delete
            AddHandler lbl(j).MouseMove, AddressOf CntrlLocChange1MV 'Change location,sz
            AddHandler lbl(j).MouseDown, AddressOf CntrlLocChange2MD 'Change location,sz

            DesignWin.Controls.Add(lbl(j))
            ControlSize.Text = lbl(j).Size.ToString

            lblID(j) = New ToolStripMenuItem
            AddHandler lblID(j).Click, AddressOf Scnt 'select the specific control
            lblID(j).Text = lbl(j).Text
            lblID(j).Name = "a" + lbl(j).Name
            DropDownList.Items.Add(lblID(j))
            CntrlAdded_Selected.DropDown = DropDownList
        ElseIf lblLCanAdd = True Then
            If k >= 10 Then
                GoTo en
            End If
            k = k + 1
            lblL(k) = New LinkLabel
            lblL(k).Name = "ink" + k.ToString 'l removed &link=&label
            lblL(k).Text = "Link Label " + k.ToString
            lblL(k).BackColor = Color.LightSkyBlue
            lblL(k).AutoSize = False
            lblL(k).Size = New Point(65, 13)
            lblL(k).Location = e.Location
            AddHandler lblL(k).Click, AddressOf cntrlDelete 'cntrl delete
            AddHandler lblL(k).MouseMove, AddressOf CntrlLocChange1MV 'Change location,sz
            AddHandler lblL(k).MouseDown, AddressOf CntrlLocChange2MD 'Change location,sz

            DesignWin.Controls.Add(lblL(k))
            ControlSize.Text = lblL(k).Size.ToString

            lblLID(k) = New ToolStripMenuItem
            AddHandler lblLID(k).Click, AddressOf Scnt 'select the specific control
            lblLID(k).Text = lblL(k).Text
            lblLID(k).Name = "a" + lblL(k).Name
            DropDownList.Items.Add(lblLID(k))
            CntrlAdded_Selected.DropDown = DropDownList
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
        ControlsAvailable.Text = (50 - i).ToString + " Buttons," + (50 - j).ToString + " Labels & " + (10 - k).ToString + " can be added.."
    End Sub

    'coordinates
    Private Sub XY(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        LocXY.Text = e.Location.ToString
    End Sub

    'remove cntrl
    Private Sub cntrlDelete(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If cDelete = True Then
            DesignWin.Controls.Remove(sender)
            If TypeOf sender Is Button Then
                DropDownList.Items.Remove(btnID(Convert.ToUInt16(sender.Name.Remove(0, 3))))
            ElseIf TypeOf sender Is LinkLabel Then
                DropDownList.Items.Remove(lblLID(Convert.ToUInt16(sender.Name.Remove(0, 3))))
            ElseIf TypeOf sender Is Label Then
                DropDownList.Items.Remove(lblID(Convert.ToUInt16(sender.Name.Remove(0, 3))))
            End If
        Else
            DesignWin.ActiveControl = sender
        End If
    End Sub

    'select contol when item(on list) is clicked
    Private Sub Scnt(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If sender.Name.StartsWith("ab") Then
            btn(Convert.ToUInt16(sender.Name.Remove(0, 4))).Select()
        ElseIf sender.Name.StartsWith("al") Then
            lbl(Convert.ToUInt16(sender.Name.Remove(0, 4))).Select()
            CntrlAdded_Selected.Text = sender.Text
        ElseIf sender.Name.StartsWith("ai") Then
            lblL(Convert.ToUInt16(sender.Name.Remove(0, 4))).Select()
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

    'frm Size
    Private Sub DSzChange()
        CntrlAdded_Selected.Text = DesignWin.Text
        ControlSize.Text = DesignWin.Size.ToString
    End Sub

    'Properties
    Private Sub ShowProperties()
        PropertiesBox.Controls.Add(prp)

        With prp
            .Label1.Text = "Control Type"
            .Label2.Text = "Text"
            .Label3.Text = "Width"
            .Label4.Text = "Height"
            .Label5.Text = "BackColor"
            .Label6.Text = "ForeColor"
            .Label7.Text = "Cursor"
            .Label8.Text = "Background Image"
            .Label9.Text = "Image Layout"

            .ComboBox1.Items.AddRange({Cursors.AppStarting, Cursors.Arrow, Cursors.Cross, _
                                 Cursors.Default, Cursors.Hand, Cursors.Help, _
                                 Cursors.HSplit, Cursors.IBeam, Cursors.No, _
                                 Cursors.NoMove2D, Cursors.NoMoveHoriz, Cursors.NoMoveVert, _
                                 Cursors.PanEast, Cursors.PanNE, Cursors.PanNorth, _
                                 Cursors.PanNW, Cursors.PanSE, Cursors.PanSouth, _
                                 Cursors.PanSW, Cursors.PanWest, Cursors.SizeAll, _
                                 Cursors.SizeNESW, Cursors.SizeNS, Cursors.SizeNWSE, _
                                 Cursors.SizeWE, Cursors.UpArrow, Cursors.VSplit, Cursors.WaitCursor, "From File.."})

            If frmProp = True Then
Aa:

                .Label10.Text = "Opacity"
                .Label11.Text = "Start Position"
                .Label12.Text = "Show on taskbar"
                .ComboBox2.Items.AddRange({ImageLayout.Center, ImageLayout.None, ImageLayout.Stretch, ImageLayout.Tile, ImageLayout.Zoom})

                cmx.Items.Clear()
                txtm.Mask = "000"
                txtm.Width = 140
                cmx.Items.AddRange({FormStartPosition.CenterParent, FormStartPosition.CenterScreen, FormStartPosition.Manual, FormStartPosition.WindowsDefaultBounds, FormStartPosition.WindowsDefaultLocation})
                cmx.Width = 140
                prp.TableLayout.Controls.Add(txtm)
                prp.TableLayout.Controls.Add(cmx)
                prp.TableLayout.Controls.Add(chk)

                .Label16.Text = "Form"
                .TextBox1.Text = DesignWin.Text.Remove(0, 15)
                .TextBox2.Text = DesignWin.Width.ToString
                .TextBox3.Text = DesignWin.Height.ToString
                .Button1.BackColor = DesignWin.BackColor
                .Button2.BackColor = DesignWin.ForeColor
                .ComboBox1.SelectedItem = DesignWin.Cursor
                .PictureBox1.Image = DesignWin.BackgroundImage
                .ComboBox2.SelectedItem = DesignWin.BackgroundImageLayout
                txtm.Text = DesignWin.Opacity * 100
                cmx.SelectedItem = DesignWin.StartPosition
                chk.Checked = DesignWin.ShowInTaskbar

            ElseIf TypeOf DesignWin.ActiveControl Is Button Then

            ElseIf TypeOf DesignWin.ActiveControl Is Label Then

            ElseIf TypeOf DesignWin.ActiveControl Is LinkLabel Then

            Else
                GoTo Aa
            End If
        End With
        frmProp = False
    End Sub

    'Main loads-Code window show
    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ControlsAvailable.Text = (50 - i).ToString + " Buttons," + (50 - j).ToString + " Labels & " + (10 - k).ToString + " can be added.."
        CodeWin.MdiParent = Me
        CodeWin.Text = "Code Window"
        CodeWin.MaximizeBox = False
        CodeWin.Icon = My.Resources.Code
        CodeWin.Location = New Point(0, 0)
        CodeWin.Size = New Point(400, 500)
        AddHandler CodeWin.FormClosing, AddressOf CodeClosing 'Hide when closing
        CodeWin.WindowState = FormWindowState.Minimized
        CodeWin.Show()

        JToolStripMenuItem.Enabled = False
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
            JToolStripMenuItem.Checked = False
            PanelArrange.Visible = False
            prp.Reset()
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
            JToolStripMenuItem.Checked = False
            PanelArrange.Visible = False
            ToolBox.Visible = True
        End If
    End Sub

    'Show properties of frm in properties window
    Private Sub ShowFrmP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowFrmP.Click
        frmProp = True
        clean()
        prp.Reset()
        ShowProperties()
        ToolBox.Visible = False
        PropertiesBox.Visible = True
    End Sub

    'Every tick -show active control
    Private Sub ControlNameFind_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ControlNameFind.Tick
        Try
            CntrlAdded_Selected.Text = DesignWin.ActiveControl.Text
        Catch
        End Try
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

    'Remove controls
    Private Sub ControlRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ControlRemove.Click
        clean()
        cDelete = True 'Enable delete
    End Sub

    'Remove all controls
    Private Sub ControlRemoveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ControlRemoveAll.Click
        DesignWin.Controls.Clear()
        DropDownList.Items.Clear()
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

    'set all to default
    Private Sub clean()
        cLoc = False  'Disable loc
        cDelete = False  'Disable delete
        cSize = False 'Disable Sz
        lblCanAdd = False 'Disable adding lbl
        btnCanAdd = False 'Disable adding btn
        lblLCanAdd = False 'Disable adding link lbl
        'MultiAddCntrl = False 'Disable multi adding
    End Sub

    Private Sub JToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JToolStripMenuItem.Click
        If JToolStripMenuItem.Checked = False Then
            PanelArrange.Visible = False
        ElseIf JToolStripMenuItem.Checked = True Then
            PropertiesBox.Visible = False
            ToolBox.Visible = False
            PanelArrange.Visible = True
            ListAll.Items.Clear()
            ListSpecified.Items.Clear()
            CbxMainCntrl.Items.Clear()
            For Each cntrl As Control In DesignWin.Controls
                If cntrl.Name.Length < 5 Then
                    ListAll.Items.Add(cntrl.Text + " #" + cntrl.Name + " ")
                    CbxMainCntrl.Items.Add(cntrl.Text + " #" + cntrl.Name + " ")

                Else
                    ListAll.Items.Add(cntrl.Text + " #" + cntrl.Name)
                    CbxMainCntrl.Items.Add(cntrl.Text + " #" + cntrl.Name)
                End If
            Next
        End If
    End Sub

    Private Sub RadioButtonh_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If RadioButtonh.Checked = True Then
            RadioButtonv.Checked = False
        Else
            RadioButtonv.Checked = True
        End If
    End Sub

    Private Sub RadioButtonv_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If RadioButtonv.Checked = True Then
            RadioButtonh.Checked = False
        Else
            RadioButtonh.Checked = True
        End If
    End Sub

    Private Sub CbxMainCntrl_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbxMainCntrl.SelectedIndexChanged
        ListAll.Items.Clear()
        ListSpecified.Items.Clear()
        For Each cntrl As Control In DesignWin.Controls
            If cntrl.Name.Length < 5 Then
                ListAll.Items.Add(cntrl.Text + " #" + cntrl.Name + " ")
            Else
                ListAll.Items.Add(cntrl.Text + " #" + cntrl.Name)
            End If
        Next
        Try
            ListAll.Items.Remove(CbxMainCntrl.SelectedItem)
        Catch
        End Try
        Try
            ListSpecified.Items.Remove(CbxMainCntrl.SelectedItem)
        Catch
        End Try
    End Sub

    Private Sub btnArrangeThem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArrangeThem.Click
        If CbxMainCntrl.SelectedIndex = -1 Then
            MsgBox("Select the independent control", MsgBoxStyle.OkOnly)
            CbxMainCntrl.DroppedDown = True
        ElseIf ListSpecified.Items.Count < 1 Then
            MsgBox("Select controls", MsgBoxStyle.OkOnly)
        Else
            Try
                ListAll.Items.Remove(CbxMainCntrl.SelectedItem)
            Catch
            End Try
            Try
                ListSpecified.Items.Remove(CbxMainCntrl.SelectedItem)
            Catch
            End Try

            Dim x, y, t As Integer
            x = 0
            y = 0
            Dim tmp As Point
            tmp = New Point(0, 0)

            t = Convert.ToUInt16((CbxMainCntrl.SelectedItem.Remove(0, CbxMainCntrl.SelectedItem.Length - 2)))
            If CbxMainCntrl.SelectedItem.Remove(0, CbxMainCntrl.SelectedItem.Length - 6).StartsWith("#b") Then
                tmp = btn(t).Location
            ElseIf CbxMainCntrl.SelectedItem.Remove(0, CbxMainCntrl.SelectedItem.Length - 6).StartsWith("#l") Then
                tmp = lbl(t).Location
            ElseIf CbxMainCntrl.SelectedItem.Remove(0, CbxMainCntrl.SelectedItem.Length - 6).StartsWith("#i") Then
                tmp = lblL(t).Location
            End If
            x = tmp.X
            y = tmp.Y


            For Each item As String In ListSpecified.Items
                t = Convert.ToUInt16((item.Remove(0, item.Length - 2)))

                If item.Remove(0, item.Length - 6).StartsWith("#b") Then
                    If RadioButtonv.Checked = True Then
                        btn(t).Location = New Point(tmp.X, btn(t).Location.Y)
                    Else
                        btn(t).Location = New Point(btn(t).Location.X, tmp.Y)
                    End If
                    x = x + btn(t).Width
                    y = y + btn(t).Height

                ElseIf item.Remove(0, item.Length - 6).StartsWith("#l") Then

                    If RadioButtonv.Checked = True Then
                        lbl(t).Location = New Point(tmp.X, lbl(t).Location.Y)
                    Else
                        lbl(t).Location = New Point(lbl(t).Location.X, tmp.Y)
                    End If
                    x = x + lbl(t).Width
                    y = y + lbl(t).Height
                ElseIf item.Remove(0, item.Length - 6).StartsWith("#i") Then
                  
                    If RadioButtonv.Checked = True Then
                        lblL(t).Location = New Point(tmp.X, lblL(t).Location.Y)
                    Else
                        lblL(t).Location = New Point(btn(t).Location.X, tmp.Y)
                    End If
                    x = x + lblL(t).Width
                    y = y + lblL(t).Height
                End If

            Next

            MsgBox(x.ToString + "  " + y.ToString)

        End If
    End Sub

    Private Sub btnCntrlReload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCntrlReload.Click
        ListAll.Items.Clear()
        ListSpecified.Items.Clear()
        CbxMainCntrl.Items.Clear()
        For Each cntrl As Control In DesignWin.Controls
            If cntrl.Name.Length <= 5 Then
                ListAll.Items.Add(cntrl.Text + " #" + cntrl.Name + " ")
                CbxMainCntrl.Items.Add(cntrl.Text + " #" + cntrl.Name + " ")

            Else
                ListAll.Items.Add(cntrl.Text + " #" + cntrl.Name)
                CbxMainCntrl.Items.Add(cntrl.Text + " #" + cntrl.Name)
            End If
        Next
        CbxMainCntrl.SelectedIndex = -1
    End Sub

    Private Sub btnRemoveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveAll.Click
        Try
            ListAll.Items.AddRange(ListSpecified.Items)
            ListSpecified.Items.Clear()
        Catch
        End Try
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        Try
            ListAll.Items.Add(ListSpecified.SelectedItem)
            ListSpecified.Items.Remove(ListSpecified.SelectedItem)
        Catch
        End Try
    End Sub

    Private Sub btnAddAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddAll.Click
        Try
            ListSpecified.Items.AddRange(ListAll.Items)
            ListAll.Items.Clear()
        Catch
        End Try
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            ListSpecified.Items.Add(ListAll.SelectedItem)
            ListAll.Items.Remove(ListAll.SelectedItem)
        Catch
        End Try
    End Sub

    Private Sub btnMultiAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMultiAdd.Click
        If MultiAddCntrl = True Then
            btnMultiAdd.Text = "Multi add-False"
            MultiAddCntrl = False
        ElseIf MultiAddCntrl = False Then
            btnMultiAdd.Text = "Multi add-True"
            MultiAddCntrl = True
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        DesignWin.Text = "Design Window -" + prp.TextBox1.Text
        DesignWin.Width = prp.TextBox2.Text
        DesignWin.Height = prp.TextBox3.Text
        DesignWin.BackColor = prp.Button1.BackColor
        DesignWin.ForeColor = prp.Button2.BackColor
        Try
            DesignWin.Cursor = prp.ComboBox1.SelectedItem
        Catch
            DesignWin.Cursor = New Cursor(prp.ComboBox1.SelectedItem.ToString)
        End Try
        DesignWin.BackgroundImage = prp.PictureBox1.Image
        DesignWin.BackgroundImageLayout = prp.ComboBox2.SelectedItem
        DesignWin.Opacity = Val(txtm.Text) / 100
        DesignWin.StartPosition = cmx.SelectedItem
        DesignWin.ShowInTaskbar = chk.Checked
    End Sub

End Class
