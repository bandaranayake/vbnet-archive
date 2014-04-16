Public Class Pllbl

    Dim llbl As New vLinkLabel

    Private Sub btnBackColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBackColor.Click, btnForeColor.Click, btnVisitedlinkColor.Click, btnDisabledLinkColor.Click, btnActivelinkColor.Click, btnLinkColor.Click
        llbl = NewFrame.ActiveControl
        With ColorDialog1
            .AllowFullOpen = True
            .AnyColor = True
            'TabOpen1 = True
            If .ShowDialog() = DialogResult.OK Then
                If sender.Name = btnBackColor.Name Then
                    llbl.BackColor = .Color
                ElseIf sender.Name = btnForeColor.Name Then
                    llbl.ForeColor = .Color
                ElseIf sender.Name = btnActivelinkColor.Name Then
                    llbl.ActiveLinkColor = .Color
                ElseIf sender.Name = btnVisitedlinkColor.Name Then
                    llbl.VisitedLinkColor = .Color
                ElseIf sender.Name = btnlinkColor.Name Then
                    llbl.LinkColor = .Color
                ElseIf sender.Name = btnDisabledLinkColor.Name Then
                    llbl.DisabledLinkColor = .Color
                End If
                sender.BackColor = .Color
            End If
        End With
    End Sub

    Private Sub chkCursorFrmFile_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCursorFrmFile.CheckedChanged
        If chkCursorFrmFile.Checked = True Then
            cmbxCursor.Enabled = False
            btnCursor.Enabled = True
            txtCursor.Enabled = True
        ElseIf chkCursorFrmFile.Checked = False Then
            cmbxCursor.Enabled = True
            btnCursor.Enabled = False
            txtCursor.Enabled = False
        End If
    End Sub

    Private Sub btnCursor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCursor.Click
        llbl = NewFrame.ActiveControl
        With OpenFileDialog1
            .CheckFileExists = True
            .Multiselect = False
            .Title = "Select a cursor.."
            .FileName = ""
            .Filter = "Cursor Files(*.Cur)|*.Cur|All files (*.*)|*.*"
            'TabOpen1 = True
            If .ShowDialog = DialogResult.OK Then
                Try
                    llbl.Cursor = New Cursor(.FileName)
                    llbl.CursorFile = .FileName
                    txtCursor.Text = .FileName
                    llbl.b1 = True
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                End Try
            End If
        End With
    End Sub

    Private Sub btnImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImage.Click
        llbl = NewFrame.ActiveControl

        With OpenFileDialog1
            .CheckFileExists = True
            .Multiselect = False
            .Title = "Select a Image.."
            .FileName = ""
            .Filter = "Image Files(*.Bmp;*.Jpg;*.Gif)|*.Bmp;*.Jpg;*.Gif|All files (*.*)|*.*"
            'TabOpen1 = True
            If .ShowDialog = DialogResult.OK Then
                Try
                    llbl.Image = Image.FromFile(.FileName)
                     txtImage.Text = .FileName
                    Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                End Try
            End If
        End With
    End Sub

    Private Sub btnFont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFont.Click
        With FontDialog1
            .Font = txtFont.Font
            .ShowColor = False
            Try
                If .ShowDialog() = DialogResult.OK Then
                    NewFrame.ActiveControl.Font = .Font
                    txtFont.Text = .Font.Name
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        End With
    End Sub

    Private Sub txtText_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtText.TextChanged
        NewFrame.ActiveControl.Text = txtText.Text
    End Sub

    Private Sub cmbxCursor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbxCursor.SelectedIndexChanged
        NewFrame.ActiveControl.Cursor = SetCursor(cmbxCursor.SelectedIndex)
    End Sub

    Private Sub chkUseMnemonic_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUseMnemonic.CheckedChanged
        llbl = NewFrame.ActiveControl
        llbl.UseMnemonic = chkUseMnemonic.Checked
    End Sub

    Private Sub chkUseWaitCusor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUseWaitCusor.CheckedChanged
        NewFrame.ActiveControl.UseWaitCursor = chkUseWaitCusor.Checked
    End Sub

    Private Sub cmbxImageAlign_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbxImageAlign.SelectedIndexChanged
        llbl = NewFrame.ActiveControl
        llbl.ImageAlign = SetImgAlign(cmbxImageAlign.SelectedIndex)
    End Sub

    Private Sub cmbxTextAlign_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbxTextAlign.SelectedIndexChanged
        llbl = NewFrame.ActiveControl
        llbl.TextAlign = SetImgAlign(cmbxTextAlign.SelectedIndex)
    End Sub

    Private Sub chkAutoSize_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutoSize.CheckedChanged
        NewFrame.ActiveControl.AutoSize = chkAutoSize.Checked
    End Sub

    Private Sub txtTabIndex_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTabIndex.TextChanged
        Try
            NewFrame.ActiveControl.TabIndex = Val(txtTabIndex.Text)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            txtTabIndex.Text = NewFrame.ActiveControl.TabIndex
        End Try
    End Sub

    Private Sub btnMinSize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMinSize.Click
        Try
            NewFrame.ActiveControl.MinimumSize = New Point(Val(txtMinSizeW.Text), Val(txtMinSizeH.Text))
            txtSizeW.Text = NewFrame.ActiveControl.Size.Width
            txtSizeH.Text = NewFrame.ActiveControl.Size.Height
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            txtMinSizeW.Text = NewFrame.ActiveControl.MinimumSize.Width
            txtMinSizeH.Text = NewFrame.ActiveControl.MinimumSize.Height
        End Try
    End Sub

    Private Sub btnMaxSize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMaxSize.Click
        Try
            NewFrame.ActiveControl.MaximumSize = New Point(Val(txtMaxSizeW.Text), Val(txtMaxSizeH.Text))
            txtSizeW.Text = NewFrame.ActiveControl.Size.Width
            txtSizeH.Text = NewFrame.ActiveControl.Size.Height
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            txtMaxSizeW.Text = NewFrame.ActiveControl.MaximumSize.Width
            txtMaxSizeH.Text = NewFrame.ActiveControl.MaximumSize.Height
        End Try
    End Sub

    Private Sub btnLocation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLocation.Click
        Try
            NewFrame.ActiveControl.Location = New Point(Val(txtLocationX.Text), Val(txtLocationY.Text))
        Catch ex As Exception
            txtLocationX.Text = NewFrame.ActiveControl.Location.X
            txtLocationY.Text = NewFrame.ActiveControl.Location.Y
        End Try
    End Sub

    Private Sub cmbxDock_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbxDock.SelectedIndexChanged
        NewFrame.ActiveControl.Dock = cmbxDock.SelectedIndex
    End Sub

    Private Sub txtSizeW_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSizeW.TextChanged
        NewFrame.ActiveControl.Width = Val(txtSizeW.Text)
    End Sub

    Private Sub txtSizeH_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSizeH.TextChanged
        NewFrame.ActiveControl.Height = Val(txtSizeH.Text)
    End Sub

    Private Sub cmbxRightToLeft_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbxRightToLeft.SelectedIndexChanged
        NewFrame.ActiveControl.RightToLeft = cmbxRightToLeft.SelectedIndex
    End Sub

    Private Sub cmbxLinkBehaviour_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbxLinkBehaviour.SelectedIndexChanged
        llbl = NewFrame.ActiveControl
        llbl.LinkBehavior = cmbxLinkBehaviour.SelectedIndex
    End Sub

    Private Sub btnLinkArea_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLinkArea.Click
        llbl = NewFrame.ActiveControl
        llbl.LinkArea = New System.Windows.Forms.LinkArea(Val(txtLinkAreaS.Text), Val(txtLinkAreaE.Text))
    End Sub

    Private Sub chkLinkVisited_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkLinkVisited.CheckedChanged
        llbl = NewFrame.ActiveControl
        llbl.LinkVisited = chkLinkVisited.Checked
    End Sub

End Class
