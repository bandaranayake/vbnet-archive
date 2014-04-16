Public Class Ppan

    Public pnl As New vPanel

    Private Sub btnBackColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBackColor.Click
        With ColorDialog1
            .AllowFullOpen = True
            .AnyColor = True
            'TabOpen1 = True
            If .ShowDialog() = DialogResult.OK Then
                pnl.BackColor = .Color
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

    Private Sub btnBackgroundImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBackgroundImage.Click
        With OpenFileDialog1
            .CheckFileExists = True
            .Multiselect = False
            .Title = "Select a Image for background.."
            .FileName = ""
            .Filter = "Image Files(*.Bmp;*.Jpg;*.Gif)|*.Bmp;*.Jpg;*.Gif|All files (*.*)|*.*"
            'TabOpen1 = True
            If .ShowDialog = DialogResult.OK Then

                Try
                    pnl.BackgroundImage = Image.FromFile(.FileName)
                    txtBackgroundImage.Text = .FileName
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                End Try

            End If
        End With
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
                    pnl.Cursor = New Cursor(.FileName)
                    pnl.CursorFile = .FileName
                    txtCursor.Text = .FileName
                    pnl.b1 = True
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                End Try
            End If
        End With
    End Sub

    Private Sub cmbxBImageLayout_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbxBImageLayout.SelectedIndexChanged
        pnl.BackgroundImageLayout = cmbxBImageLayout.SelectedIndex
    End Sub

    Private Sub cmbxCursor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbxCursor.SelectedIndexChanged
        pnl.Cursor = SetCursor(cmbxCursor.SelectedIndex)
    End Sub

    Private Sub chkUseWaitCusor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUseWaitCusor.CheckedChanged
        pnl.UseWaitCursor = chkUseWaitCusor.Checked
    End Sub

    Private Sub chkAutoSize_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutoSize.CheckedChanged
        pnl.AutoSize = chkAutoSize.Checked
    End Sub

    Private Sub chkTabStop_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTabStop.CheckedChanged
        pnl.TabStop = chkTabStop.Checked
    End Sub

    Private Sub txtTabIndex_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTabIndex.TextChanged
        Try
            pnl.TabIndex = Val(txtTabIndex.Text)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            txtTabIndex.Text = pnl.TabIndex
        End Try
    End Sub

    Private Sub btnMinSize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMinSize.Click
        Try
            pnl.MinimumSize = New Point(Val(txtMinSizeW.Text), Val(txtMinSizeH.Text))
            txtSizeW.Text = pnl.Size.Width
            txtSizeH.Text = pnl.Size.Height
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            txtMinSizeW.Text = pnl.MinimumSize.Width
            txtMinSizeH.Text = pnl.MinimumSize.Height
        End Try
    End Sub

    Private Sub btnMaxSize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMaxSize.Click
        Try
            pnl.MaximumSize = New Point(Val(txtMaxSizeW.Text), Val(txtMaxSizeH.Text))
            txtSizeW.Text = pnl.Size.Width
            txtSizeH.Text = pnl.Size.Height
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            txtMaxSizeW.Text = pnl.MaximumSize.Width
            txtMaxSizeH.Text = pnl.MaximumSize.Height
        End Try
    End Sub

    Private Sub btnLocation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLocation.Click
        Try
            pnl.Location = New Point(Val(txtLocationX.Text), Val(txtLocationY.Text))
        Catch ex As Exception
            txtLocationX.Text = pnl.Location.X
            txtLocationY.Text = pnl.Location.Y
        End Try
    End Sub

    Private Sub cmbxDock_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbxDock.SelectedIndexChanged
        pnl.Dock = cmbxDock.SelectedIndex
    End Sub

    Private Sub txtSizeW_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSizeW.TextChanged
        pnl.Width = Val(txtSizeW.Text)
    End Sub

    Private Sub txtSizeH_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSizeH.TextChanged
        pnl.Height = Val(txtSizeH.Text)
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        Try
            pnl.Controls.Remove(pnl.Controls.Item(ListAll.SelectedItem.Tag))
            DropDownList.Items.Remove(DropDownList.Items.Item(ListAll.SelectedItem.Tag + "Drp"))
            ListAll.Items.Remove(ListAll.SelectedItem)
        Catch
        End Try
    End Sub

    Private Sub cmbxBorderStyle_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbxBorderStyle.SelectedIndexChanged
        pnl.BorderStyle = cmbxBorderStyle.SelectedIndex
    End Sub

End Class
