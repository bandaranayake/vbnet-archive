Imports System.Text.RegularExpressions
Imports System.IO

Public Class Form1


    Private Sub Form1_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Dim pattern As String = "<media (.|)*?>"
        Dim s As String = File.ReadAllText("C:\Users\Isuru\Music\Playlists\a.wpl")
        Dim fi As FileInfo
        Dim i As Integer = 0

        For Each m As Match In Regex.Matches(s, pattern)
            i = i + 1
            fi = New FileInfo(m.Groups(0).Value.Split("""")(1).Replace("&amp;", "&").Replace("&apos;", "'"))
            File.Copy(fi.FullName, "E:\x\" + fi.Name)
            Me.Text = i

        Next
    End Sub
End Class
