Public Class Form1

    Dim bmp As Bitmap
    
    Public Function ConvertC(ByVal source As Bitmap, ByVal i As Integer, ByVal percentage As Integer) As Bitmap
        Dim bm As New Bitmap(source.Width, source.Height)

        Dim x, y As Integer
        Dim l As Integer

        For y = 0 To bm.Height - 1

            For x = 0 To bm.Width - 1

                Dim c As Color = source.GetPixel(x, y)

                Select Case i
                    Case 0
                        bm.SetPixel(x, y, Color.FromArgb(c.R * percentage / 100, c.G, c.B))
                    Case 1
                        bm.SetPixel(x, y, Color.FromArgb(c.R, c.G * percentage / 100, c.B))
                    Case 2
                        bm.SetPixel(x, y, Color.FromArgb(c.R, c.G, c.B * percentage / 100))
                End Select
            Next

        Next

        Return bm

    End Function

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PictureBox1.BackgroundImage = bmp
    End Sub

    Private Sub TrackBar1_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar1.Scroll
        TextBox1.Text = TrackBar1.Value & "%"
        PictureBox2.BackgroundImage = ConvertC(bmp, 0, TrackBar1.Value)
    End Sub

    Private Sub TrackBar2_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar2.Scroll
        TextBox2.Text = TrackBar2.Value & "%"
        PictureBox2.BackgroundImage = ConvertC(bmp, 1, TrackBar2.Value)
    End Sub

    Private Sub TrackBar3_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar3.Scroll
        TextBox3.Text = TrackBar3.Value & "%"
        PictureBox2.BackgroundImage = ConvertC(bmp, 2, TrackBar3.Value)
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Dim fd As OpenFileDialog = New OpenFileDialog()
      
        fd.Title = "Open File Dialog"
        fd.InitialDirectory = "C:\"
        fd.Filter = "Image files|*.bmp;*.jpg;*.png; |All files| *.*"
        fd.FilterIndex = 2
        fd.RestoreDirectory = True

        If fd.ShowDialog() = DialogResult.OK Then
            bmp = New Bitmap(fd.FileName)
            PictureBox1.BackgroundImage = bmp
        End If
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        Dim saveFileDialog1 As New SaveFileDialog()
        saveFileDialog1.Filter = "Jpeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif|PNG Image|*.png"
        saveFileDialog1.Title = "Save the Image"

        If saveFileDialog1.ShowDialog() = DialogResult.OK Then
            Select Case saveFileDialog1.FilterIndex
                Case 1
                    PictureBox2.BackgroundImage.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Jpeg)
                Case 2
                    PictureBox2.BackgroundImage.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Bmp)
                Case 3
                    PictureBox2.BackgroundImage.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Gif)
                Case 4
                    PictureBox2.BackgroundImage.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Png)
            End Select

        End If

    End Sub

End Class
