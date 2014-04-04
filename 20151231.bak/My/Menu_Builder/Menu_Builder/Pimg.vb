Public Class Pimg

    Dim img As New vImage

    Private Sub btnBackColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBackColor.Click
        With ColorDialog1
            .AllowFullOpen = True
            .AnyColor = True
            'TabOpen1 = True
            If .ShowDialog() = DialogResult.OK Then
                NewFrame.ActiveControl.BackColor = .Color
                btnBackColor.BackColor = .Color
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

    Private Sub btnBackgroundImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBackgroundImage.Click
        img = NewFrame.ActiveControl
        With OpenFileDialog1
            .CheckFileExists = True
            .Multiselect = False
            .Title = "Select a Image for background.."
            .FileName = ""
            .Filter = "Image Files(*.Bmp;*.Jpg;*.Gif)|*.Bmp;*.Jpg;*.Gif|All files (*.*)|*.*"
            'TabOpen1 = True
            If .ShowDialog = DialogResult.OK Then

                Try
                    img.BackgroundImage = Image.FromFile(.FileName)
                    txtBackgroundImage.Text = .FileName
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                End Try

            End If
        End With
    End Sub

    Private Sub btnCursor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCursor.Click
        img = NewFrame.ActiveControl
        With OpenFileDialog1
            .CheckFileExists = True
            .Multiselect = False
            .Title = "Select a cursor.."
            .FileName = ""
            .Filter = "Cursor Files(*.Cur)|*.Cur|All files (*.*)|*.*"
            'TabOpen1 = True
            If .ShowDialog = DialogResult.OK Then
                Try
                    img.Cursor = New Cursor(.FileName)
                    img.CursorFile = .FileName
                    txtCursor.Text = .FileName
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                End Try
            End If
        End With
    End Sub

    Private Sub btnImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImage.Click
        img = NewFrame.ActiveControl

        With OpenFileDialog1
            .CheckFileExists = True
            .Multiselect = False
            .Title = "Select a Image.."
            .FileName = ""
            .Filter = "Image Files(*.Bmp;*.Jpg;*.Gif)|*.Bmp;*.Jpg;*.Gif|All files (*.*)|*.*"
            'TabOpen1 = True
            If .ShowDialog = DialogResult.OK Then
                Try
                    img.Image = Image.FromFile(.FileName)
                    txtImage.Text = .FileName
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                End Try
            End If
        End With
    End Sub

    Private Sub cmbxBImageLayout_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbxBImageLayout.SelectedIndexChanged
        NewFrame.ActiveControl.BackgroundImageLayout = cmbxBImageLayout.SelectedIndex
    End Sub

    Private Sub cmbxCursor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbxCursor.SelectedIndexChanged
        NewFrame.ActiveControl.Cursor = SetCursor(cmbxCursor.SelectedIndex)
    End Sub

    Private Sub chkUseWaitCusor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUseWaitCusor.CheckedChanged
        NewFrame.ActiveControl.UseWaitCursor = chkUseWaitCusor.Checked
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

    Private Sub txtImageLocation_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtImageLocation.TextChanged
        img = NewFrame.ActiveControl
        Try
            img.ImageLocation = txtImageLocation.Text
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub cmbxSizeMode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbxSizeMode.SelectedIndexChanged
        img = NewFrame.ActiveControl
        img.SizeMode = cmbxSizeMode.SelectedIndex
    End Sub

    Private Sub chkWaitonLoad_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkWaitonLoad.CheckedChanged
        img = NewFrame.ActiveControl
        img.WaitOnLoad = chkWaitonLoad.Checked
    End Sub

End Class
