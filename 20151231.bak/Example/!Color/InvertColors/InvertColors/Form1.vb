Imports System.Drawing.Imaging

Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim bitmap1 As New Bitmap("G:\a.jpg")
        Dim bitmap2 As New Bitmap(bitmap1.Width * 2, bitmap1.Height)

        For i As Integer = 0 To bitmap1.Width - 1
            For j As Integer = 0 To bitmap1.Height - 1
                bitmap2.SetPixel(i, j, bitmap1.GetPixel(i, j))
                bitmap2.SetPixel(bitmap1.Width + i, j, InvertColor(bitmap1.GetPixel(i, j)))
            Next
        Next
        Me.BackgroundImage = bitmap2
    End Sub

    Private Function InvertColor(ByVal c As Color) As Color
        Dim r, g, b As Integer
        r = 255 - c.R
        g = 255 - c.G
        b = 255 - c.B

        Return Color.FromArgb(r, g, b)
    End Function

End Class
