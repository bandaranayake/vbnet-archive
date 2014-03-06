Public Class Form1


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        RichTextBox1.Text = Replace(RichTextBox1.Text.ToUpper, " ", "_")
    End Sub
End Class
