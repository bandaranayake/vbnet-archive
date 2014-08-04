Public Class Form1

    Public Function ConvertToGrayscale(ByVal source As Bitmap) As Bitmap

        Dim bm As New Bitmap(source.Width, source.Height)

        Dim x, y As Integer

        For y = 0 To bm.Height - 1

            For x = 0 To bm.Width - 1

                Dim c As Color = source.GetPixel(x, y)
                Dim luma As Integer = CInt(c.R * 0.3 + c.G * 0.59 + c.B * 0.11)

                bm.SetPixel(x, y, Color.FromArgb(luma, luma, luma))

            Next
        Next

        Return bm

    End Function

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim bmp As New Bitmap("G:\a.png")
        ConvertToGrayscale(bmp).Save("G:\g.png")
    End Sub

End Class
