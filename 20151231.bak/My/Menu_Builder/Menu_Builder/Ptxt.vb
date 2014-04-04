Imports System.IO

Public Class Ptxt

    Dim txt As New vTextBox

    Private Sub btnBackColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBackColor.Click, btnForeColor.Click
        txt = NewFrame.ActiveControl
        With ColorDialog1
            .AllowFullOpen = True
            .AnyColor = True
            'TabOpen1 = True
            If .ShowDialog() = DialogResult.OK Then
                If sender.Name = btnBackColor.Name Then
                    txt.BackColor = .Color
                Else
                    txt.ForeColor = .Color
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
        txt = NewFrame.ActiveControl
        With OpenFileDialog1
            .CheckFileExists = True
            .Multiselect = False
            .Title = "Select a cursor.."
            .FileName = ""
            .Filter = "Cursor Files(*.Cur)|*.Cur|All files (*.*)|*.*"
            'TabOpen1 = True
            If .ShowDialog = DialogResult.OK Then
                Try
                    txt.Cursor = New Cursor(.FileName)
                    txt.CursorFile = .FileName
                    txtCursor.Text = .FileName
                    txt.b1 = True
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                End Try
            End If
        End With
    End Sub

    Private Sub btnFont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFont.Click
        txt = NewFrame.ActiveControl
        With FontDialog1
            .Font = txtFont.Font
            .ShowColor = False
            Try
                If .ShowDialog() = DialogResult.OK Then

                    txt.Font = .Font
                    txtFont.Font = .Font
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

    Private Sub chkUseWaitCusor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUseWaitCusor.CheckedChanged
        NewFrame.ActiveControl.UseWaitCursor = chkUseWaitCusor.Checked
    End Sub

    Private Sub cmbxTextAlign_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbxTextAlign.SelectedIndexChanged
        txt = NewFrame.ActiveControl
        txt.TextAlign = cmbxTextAlign.SelectedIndex
    End Sub

    Private Sub chkTabStop_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTabStop.CheckedChanged
        NewFrame.ActiveControl.TabStop = chkTabStop.Checked
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

    Private Sub cmbxBorderStyle_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbxBorderStyle.SelectedIndexChanged
        txt = NewFrame.ActiveControl
        txt.BorderStyle = cmbxBorderStyle.SelectedIndex
    End Sub

    Private Sub chkMultiLine_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMultiLine.CheckedChanged
        txt = NewFrame.ActiveControl
        txt.Multiline = chkMultiLine.Checked
    End Sub

    Private Sub chkReadOnly_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkReadOnly.CheckedChanged
        txt = NewFrame.ActiveControl
        txt.ReadOnly = chkReadOnly.Checked
    End Sub

    Private Sub chkWordWrap_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkWordWrap.CheckedChanged
        txt = NewFrame.ActiveControl
        txt.WordWrap = chkWordWrap.Checked
    End Sub

End Class
