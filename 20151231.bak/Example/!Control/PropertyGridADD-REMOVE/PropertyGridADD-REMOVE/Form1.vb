Public Class Form1

    Private g As New PropertyGrid
    Private a As New Dialog1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim b As New Button
        a.Controls.Add(b)
        g.SelectedObject = a
        g.Dock = DockStyle.Fill
        Me.Controls.Add(g)
    End Sub

End Class
