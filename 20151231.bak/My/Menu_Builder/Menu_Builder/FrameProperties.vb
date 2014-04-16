Imports System.IO
Imports System.Drawing.Imaging

Public Class FrameProperties

    Private Sub cmbxAutoSizeMode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbxAutoSizeMode.SelectedIndexChanged
        NewFrame.AutoSizeMode = cmbxAutoSizeMode.SelectedIndex
    End Sub

    Private Sub chkAutoSize_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutoSize.CheckedChanged
        NewFrame.AutoSize = chkAutoSize.Checked
    End Sub

    Private Sub chkAutoScroll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutoScroll.CheckedChanged
        NewFrame.AutoScroll = chkAutoScroll.Checked
    End Sub

    Private Sub cmbxBImageLayout_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbxBImageLayout.SelectedIndexChanged
        If BImageChanged = True Then
            NewFrame.BackgroundImageLayout = cmbxBImageLayout.SelectedIndex
        End If
    End Sub

    Private Sub btnBackgroundImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBackgroundImage.Click
        Dim bmp As Bitmap

        With OpenFileDialog1
            .CheckFileExists = True
            .Multiselect = False
            .Title = "Select a Image for background.."
            .FileName = ""
            .Filter = "Image Files(*.Bmp;*.Jpg;*.Gif)|*.Bmp;*.Jpg;*.Gif|All files (*.*)|*.*"
            If .ShowDialog = DialogResult.OK Then
                Try
                    NewFrame.BackgroundImage = Image.FromFile(.FileName)
                     txtBackgroundImage.Text = .FileName
                    BImageChanged = True

                    If Image.FromFile(.FileName).RawFormat.Guid = ImageFormat.Bmp.Guid Then
                        bmp = New Bitmap(.FileName)
                        NewFrame.BackColor = bmp.GetPixel(bmp.Width - 1, bmp.Height - 1)
                        btnBackColor.BackColor = NewFrame.BackColor
                    End If

                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                    txtBackgroundImage.Text = ""
                    BImageChanged = False
                End Try
            End If
        End With
    End Sub

    Private Sub btnBackColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBackColor.Click, btnForeColor.Click
        With ColorDialog1
            .AllowFullOpen = True
            .AnyColor = True
            If .ShowDialog() = DialogResult.OK Then
                If sender.Name = btnBackColor.Name Then
                    NewFrame.BackColor = .Color
                Else
                    NewFrame.ForeColor = .Color
                End If
                sender.BackColor = .Color
            End If
        End With
    End Sub

    Private Sub chkCntrlBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCntrlBox.CheckedChanged
        NewFrame.ControlBox = chkCntrlBox.Checked
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
        With OpenFileDialog1
            .CheckFileExists = True
            .Multiselect = False
            .Title = "Select a cursor.."
            .FileName = ""
            .Filter = "Cursor Files(*.Cur)|*.Cur|All files (*.*)|*.*"
            'TabOpen1 = True
            If .ShowDialog = DialogResult.OK Then
                Try
                    NewFrame.Cursor = New Cursor(.FileName)
                    NewFrame.CursorFile = .FileName
                    txtCursor.Text = .FileName
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                End Try
            End If
        End With
    End Sub

    Private Sub cmbxCursor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbxCursor.SelectedIndexChanged
        NewFrame.Cursor = SetCursor(cmbxCursor.SelectedIndex)
    End Sub

    Private Sub btnFont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFont.Click
        With FontDialog1
            .Font = txtFont.Font
            .ShowColor = False
            Try
                If .ShowDialog() = DialogResult.OK Then

                    NewFrame.Font = .Font
                    txtFont.Font = .Font
                    txtFont.Text = .Font.Name
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        End With
    End Sub

    Private Sub cmbxFormBStyle_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbxFormBStyle.SelectedIndexChanged
        NewFrame.FormBorderStyle = cmbxFormBStyle.SelectedIndex
    End Sub

    Private Sub btnIcon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIcon.Click
        With OpenFileDialog1
            .CheckFileExists = True
            .Multiselect = False
            .Title = "Select a Icon.."
            .FileName = ""
            .Filter = "Icon Files(*.ico)|*.ico|All files (*.*)|*.*"
            'TabOpen1 = True
            If .ShowDialog = DialogResult.OK Then
                Try
                    NewFrame.Icon = New Icon(.FileName)
                    NewFrame.IconFile = .FileName
                    txtIcon.Text = .FileName
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                End Try
            End If
        End With
    End Sub

    Private Sub chkMaxbx_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMaxbx.CheckedChanged
        NewFrame.MaximizeBox = chkMaxbx.Checked
    End Sub

    Private Sub btnMaxSize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMaxSize.Click
        Try
            NewFrame.MaximumSize = New Point(Val(txtMaxSizeW.Text), Val(txtMaxSizeH.Text))
            txtSizeW.Text = NewFrame.Size.Width
            txtSizeH.Text = NewFrame.Size.Height
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            txtMaxSizeW.Text = NewFrame.MaximumSize.Width
            txtMaxSizeH.Text = NewFrame.MaximumSize.Height
        End Try
    End Sub

    Private Sub chkMinBx_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMinBx.CheckedChanged
        NewFrame.MinimizeBox = chkMinBx.Checked
    End Sub

    Private Sub btnMinSize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMinSize.Click
        Try
            NewFrame.MinimumSize = New Point(Val(txtMinSizeW.Text), Val(txtMinSizeH.Text))
            txtSizeW.Text = NewFrame.Size.Width
            txtSizeH.Text = NewFrame.Size.Height
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            txtMinSizeW.Text = NewFrame.MinimumSize.Width
            txtMinSizeH.Text = NewFrame.MinimumSize.Height
        End Try
    End Sub

    Private Sub NumUpDownOpacity_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumUpDownOpacity.ValueChanged
        NewFrame.Opacity = NumUpDownOpacity.Value / 100
    End Sub

    Private Sub cmbxRightToLeft_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbxRightToLeft.SelectedIndexChanged
        NewFrame.RightToLeft = cmbxRightToLeft.SelectedIndex
    End Sub

    Private Sub chkRight2LeftLayout_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRight2LeftLayout.CheckedChanged
        NewFrame.RightToLeftLayout = chkRight2LeftLayout.Checked
    End Sub

    Private Sub chkShowIcon_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkShowIcon.CheckedChanged
        NewFrame.ShowIcon = chkShowIcon.Checked
    End Sub

    Private Sub chkShowInTaskbar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkShowInTaskbar.CheckedChanged
        NewFrame.ShowInTaskbar = chkShowInTaskbar.Checked
    End Sub

    Private Sub txtSizeW_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSizeW.TextChanged
        NewFrame.Width = Val(txtSizeW.Text)
    End Sub

    Private Sub txtSizeH_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSizeH.TextChanged
        NewFrame.Height = Val(txtSizeH.Text)
    End Sub

    Private Sub cmbxSizeGrpStyle_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbxSizeGrpStyle.SelectedIndexChanged
        NewFrame.SizeGripStyle = cmbxSizeGrpStyle.SelectedIndex
    End Sub

    Private Sub cmbxStartPosition_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbxStartPosition.SelectedIndexChanged
        NewFrame.StartPosition = cmbxStartPosition.SelectedIndex
    End Sub

    Private Sub txtText_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtText.TextChanged
        NewFrame.Text = txtText.Text
    End Sub

    Private Sub btnTransKey_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTransKey.Click
        With ColorDialog1
            .AllowFullOpen = True
            .AnyColor = True
            If .ShowDialog() = DialogResult.OK Then
                NewFrame.TransparencyKey = .Color
                sender.BackColor = .Color
            End If
        End With
    End Sub

    Private Sub cmbxWinState_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbxWinState.SelectedIndexChanged
        NewFrame.WindowState = cmbxWinState.SelectedIndex
    End Sub

    Private Sub chkTopmost_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTopmost.CheckedChanged
        NewFrame.TopMost = chkTopmost.Checked
    End Sub

    Private Sub chkTrans_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTrans.CheckedChanged
        btnTransKey.Enabled = chkTrans.Checked
        Trans = chkTrans.Checked
    End Sub

End Class
