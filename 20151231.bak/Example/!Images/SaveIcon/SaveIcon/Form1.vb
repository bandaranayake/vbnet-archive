Imports System.IO

Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim A As New FileStream("G:\a.ico", FileMode.Create)
        Me.Icon.Save(A)
    End Sub

End Class
