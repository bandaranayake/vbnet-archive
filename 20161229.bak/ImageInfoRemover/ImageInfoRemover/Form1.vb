Imports System.IO

Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim di As DirectoryInfo = New DirectoryInfo("E:\")
        Dim bmp, rebmp As Bitmap
      
        For Each fi As FileInfo In di.GetFiles("*.jpg", SearchOption.TopDirectoryOnly)
            bmp = New Bitmap(fi.FullName)
            rebmp = New Bitmap(bmp.Width, bmp.Height)

            For x As Integer = 0 To bmp.Width - 1
                For y As Integer = 0 To bmp.Height - 1
                    rebmp.SetPixel(x, y, bmp.GetPixel(x, y))
                Next
            Next

            rebmp.Save(di.FullName + "\" + "~" + fi.Name + ".jpg", Imaging.ImageFormat.Jpeg)
        Next

    End Sub

End Class
