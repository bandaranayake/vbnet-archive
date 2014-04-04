Imports System.IO

Public Class EventPanel

    Public c = NewFrame.ActiveControl

    Private Sub cmbxAction_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbxAction.SelectedIndexChanged
        If cmbxAction.SelectedIndex = 0 Then
            Reset()
        ElseIf cmbxAction.SelectedIndex = 1 Then
            Reset()
            cmbxPara1.Items.Clear()

            lblPara1.Text = "Program :"
            lblPara2.Text = "Command line arguments :"
            lblPara4.Text = "Application start style :"

            cmbxPara1.Items.AddRange({AppWinStyle.Hide, AppWinStyle.NormalFocus, AppWinStyle.MinimizedFocus, AppWinStyle.MaximizedFocus, AppWinStyle.NormalNoFocus, AppWinStyle.MinimizedNoFocus})
            cmbxPara1.SelectedIndex = 1

            chkPara1.Text = "Stored on cd drive ?"
            chkPara2.Text = "Wait till program ends ?"

            lblPara1.Enabled = True
            lblPara2.Enabled = True
            lblPara4.Enabled = True
            txtPara1.Enabled = True
            txtPara2.Enabled = True
            cmbxPara1.Enabled = True
            chkPara1.Enabled = True
            chkPara2.Enabled = True
        ElseIf cmbxAction.SelectedIndex = 2 Then
            Reset()
            lblPara1.Text = "Document :"
            CheckBox1.Text = "Stored on cd drive ?"

            lblPara1.Enabled = True
            txtPara1.Enabled = True
            CheckBox1.Enabled = True
        ElseIf cmbxAction.SelectedIndex = 3 Then
            Reset()
            cmbxPara1.Items.Clear()

            lblPara1.Text = "Message to display :"
            lblPara2.Text = "Message Title :"
            lblPara4.Text = "Message Style :"

            cmbxPara1.Items.AddRange({MsgBoxStyle.Critical, MsgBoxStyle.Exclamation, MsgBoxStyle.Information, MsgBoxStyle.OkOnly})
            cmbxPara1.SelectedIndex = 2

            lblPara1.Enabled = True
            lblPara2.Enabled = True
            lblPara4.Enabled = True
            txtPara1.Enabled = True
            txtPara2.Enabled = True
            cmbxPara1.Enabled = True
        ElseIf cmbxAction.SelectedIndex = 4 Then
            Reset()
            lblPara1.Text = "Web address :"
            lblPara1.Enabled = True
            txtPara1.Enabled = True
        ElseIf cmbxAction.SelectedIndex = 5 Then
            Reset()

            lblPara1.Text = "Web address :"
            lblPara2.Text = "Download as :"

            lblPara1.Enabled = True
            lblPara2.Enabled = True
            txtPara1.Enabled = True
            txtPara2.Enabled = True

        ElseIf cmbxAction.SelectedIndex = 6 Then
            Reset()
            lblPara1.Text = "Document :"
            CheckBox1.Text = "Stored on cd drive ?"

            lblPara1.Enabled = True
            txtPara1.Enabled = True
            CheckBox1.Enabled = True
        ElseIf cmbxAction.SelectedIndex = 7 Then
            Reset()
            cmbxPara1.Items.Clear()

           lblPara4.Text = "Control Content   :"

            If TypeOf NewFrame.ActiveControl Is LinkLabel Then
                cmbxPara1.Items.AddRange({"Image", "Text"})
            ElseIf TypeOf NewFrame.ActiveControl Is Panel Then
                cmbxPara1.Items.AddRange({"Background Image"})
            ElseIf TypeOf NewFrame.ActiveControl Is Label Then
                cmbxPara1.Items.AddRange({"Image", "Text"})
            ElseIf TypeOf NewFrame.ActiveControl Is TextBox Then
                cmbxPara1.Items.AddRange({"Text"})
            ElseIf TypeOf NewFrame.ActiveControl Is PictureBox Then
                cmbxPara1.Items.AddRange({"Background Image", "Image"})
            Else
                cmbxPara1.Items.AddRange({"Background Image", "Image", "Text"})
            End If

            lblPara4.Enabled = True
            cmbxPara1.Enabled = True
            cmbxPara1.SelectedIndex = 1
        Else
            Reset()
        End If
        c.int(0) = cmbxAction.SelectedIndex
    End Sub

    Sub Reset()
        txtPara1.Text = ""
        txtPara2.Text = ""
    
        chkPara1.Text = "Parameter"
        chkPara2.Text = "Parameter"

        lblPara1.Text = "Parameter"
        lblPara2.Text = "Parameter"
        lblPara4.Text = "Parameter"

        cmbxPara1.Items.Clear()
        cmbxPara1.Items.Add("")

        txtPara1.Enabled = False
        txtPara2.Enabled = False
  
        chkPara1.Enabled = False
        chkPara2.Enabled = False

        lblPara1.Enabled = False
        lblPara2.Enabled = False
         lblPara4.Enabled = False

        cmbxPara1.Enabled = False
        cmbxPara1.Items.Clear()
        cmbxPara1.Items.Add("")
        cmbxPara1.SelectedIndex = 0
    End Sub

    Private Sub btnMouseDownFColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMouseDownFColor.Click
        With ColorDialog1
            .AllowFullOpen = True
            .AnyColor = True
            If .ShowDialog() = DialogResult.OK Then
                sender.BackColor = .Color
                chT4.Checked = False
                c.int(5) = .Color.ToArgb
            End If
        End With
    End Sub

    Private Sub btnMouseDownBColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMouseDownBColor.Click
        With ColorDialog1
            .AllowFullOpen = True
            .AnyColor = True
            If .ShowDialog() = DialogResult.OK Then
               sender.BackColor = .Color
                chT2.Checked = False
                c.int(3) = .Color.ToArgb
            End If
        End With
    End Sub

    Private Sub btnMouseOverFColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMouseOverFColor.Click
        With ColorDialog1
            .AllowFullOpen = True
            .AnyColor = True
            If .ShowDialog() = DialogResult.OK Then
                sender.BackColor = .Color
                chT3.Checked = False
                c.int(4) = .Color.ToArgb
            End If
        End With
    End Sub

    Private Sub btnMouseOverBColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMouseOverBColor.Click
        With ColorDialog1
            .AllowFullOpen = True
            .AnyColor = True
            If .ShowDialog() = DialogResult.OK Then
                 sender.BackColor = .Color
                chT.Checked = False
                c.int(2) = .Color.ToArgb
            End If
        End With
    End Sub

    Private Sub txtPara2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPara2.TextChanged
        c.st(1) = txtPara2.Text
    End Sub

    Private Sub txtPara1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPara1.TextChanged
        c.st(0) = txtPara1.Text
    End Sub

    Private Sub cmbxPara1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbxPara1.SelectedIndexChanged
        c.int(1) = cmbxPara1.SelectedIndex
    End Sub

    Private Sub chkPara1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPara1.CheckedChanged
        c.bn(0) = chkPara1.Checked
    End Sub

    Private Sub chkPara2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPara2.CheckedChanged
        c.bn(1) = chkPara2.Checked
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        c.bn(2) = CheckBox1.Checked
    End Sub

    Private Sub CheckBox4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox4.CheckedChanged
        c.bn(3) = CheckBox4.Checked
    End Sub

    Private Sub chT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chT.CheckedChanged
        If chT.Checked = True Then
            c.int(2) = Color.Transparent.ToArgb
        Else
            c.int(2) = btnMouseOverBColor.BackColor.ToArgb
        End If
    End Sub

    Private Sub chT2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chT2.CheckedChanged
        If chT2.Checked = True Then
            c.int(3) = Color.Transparent.ToArgb
        Else
            c.int(3) = btnMouseDownBColor.BackColor.ToArgb
        End If
    End Sub

    Private Sub chT3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chT3.CheckedChanged
        If chT3.Checked = True Then
            c.int(4) = Color.Transparent.ToArgb
        Else
            c.int(4) = btnMouseOverFColor.BackColor.ToArgb
        End If
    End Sub

    Private Sub chT4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chT4.CheckedChanged
        If chT4.Checked = True Then
            c.int(5) = Color.Transparent.ToArgb
        Else
            c.int(5) = btnMouseDownFColor.BackColor.ToArgb
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        c.bn(4) = CheckBox2.Checked
        GroupBox1.Enabled = CheckBox2.Checked
    End Sub

End Class