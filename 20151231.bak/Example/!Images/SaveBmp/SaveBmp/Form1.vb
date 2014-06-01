Imports System.IO

Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim bitmap1 As New Bitmap("G:\a.bmp")
        Dim fs As New FileStream("G:\a.bit", FileMode.CreateNew)

        Dim w As New BinaryWriter(fs)

        For i As Integer = 0 To 255
            For j As Integer = 0 To 255
                w.Write(bitmap1.GetPixel(i, j).ToArgb)
            Next
        Next

        w.Dispose()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim bitmap1 As New Bitmap(256, 256)

        Dim binReader As New BinaryReader( _
                 File.Open("G:\a.bit", FileMode.Open))
        binReader.BaseStream.Seek(0, SeekOrigin.Begin)

        For i As Integer = 0 To 255
            For j As Integer = 0 To 255
                bitmap1.SetPixel(i, j, Color.FromArgb(binReader.ReadInt32))
            Next
        Next
        Me.BackgroundImage = bitmap1
    End Sub

End Class
