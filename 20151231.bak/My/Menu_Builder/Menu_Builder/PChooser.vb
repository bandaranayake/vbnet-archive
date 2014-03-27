Public Class PChooser

    Public Sub Reset()
        Label1.ResetText()
        Label2.ResetText()
        Label3.ResetText()
        Label4.ResetText()
        Label5.ResetText()
        Label6.ResetText()
        Label7.ResetText()
        Label8.ResetText()
        Label9.ResetText()
        Label10.ResetText()
        Label11.ResetText()
        Label12.ResetText()
        Label13.ResetText()
        Label14.ResetText()
        Label15.ResetText()
        Label16.ResetText()
        Label17.ResetText()
        ComboBox1.Items.Clear()
        ComboBox2.Items.Clear()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If (ColorDialog1.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            Button1.BackColor = ColorDialog1.Color
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If (ColorDialog1.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            Button2.BackColor = ColorDialog1.Color
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedItem.ToString = ("From File..") Then
            With OpenFileDialog1
                .CheckFileExists = True
                .Filter = "cursor files (*.cur)|*.cur|All files (*.*)|*.*"
                .Multiselect = False
                .Title = "Select a cursor"
                If (.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                    ComboBox1.Items.Add(.FileName)
                    ComboBox1.SelectedItem = (.FileName)
                End If
            End With
        End If


    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        With OpenFileDialog1
            .CheckFileExists = True
            .Filter = "Image files(*.gif;*.jpg;*.jpeg;*.bmp;*.png;*.wmf)|*.gif;*.jpg;*.jpeg;*.bmp;*.png;*.wmf"
            .Multiselect = False
            .Title = "Select a image"
            If (.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                PictureBox1.Image = Image.FromFile(.FileName)
            End If
        End With
    End Sub

End Class
