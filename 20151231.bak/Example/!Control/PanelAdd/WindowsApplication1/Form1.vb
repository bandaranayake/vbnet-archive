Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim a As New FileChooser
        SplitContainer1.Panel1.Controls.Add(a)
    End Sub
End Class
