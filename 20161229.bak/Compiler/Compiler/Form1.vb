Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim a As New EthernalCompiler
        a.Source = "a.vb"
        a.Compile("a.exe")
    End Sub
End Class
