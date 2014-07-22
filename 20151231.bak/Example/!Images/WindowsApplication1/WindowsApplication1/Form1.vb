Public Class Form1
    Dim s, n As Date

    Private Function CheckColor(ByVal c As Color, ByVal M As Color) As Boolean
        Dim cR As Integer = c.R
        Dim cG As Integer = c.G
        Dim cB As Integer = c.B

        Dim mR As Integer = M.R
        Dim mG As Integer = M.G
        Dim mB As Integer = M.B

        If mR > mG Then
            If mR > mB Then
                Return (cG + 20 > mG And cG - 20 < mG) And (cB + 20 > mB And cB - 20 < mB)
            Else
                Return (cR + 20 > mR And cR - 20 < mR) And (cG + 20 > mG And cG - 20 > mG)
            End If
        Else
            If mG > mB Then
                Return (cR + 20 > mR And cR - 20 < mR) And (cB + 20 > mB And cB - 20 < mB)
            Else
                Return (cR + 20 > mR And cR - 20 < mR) And (cG + 20 > mG And cG - 20 < mG)
            End If
        End If

        Return False
    End Function

    Private Function CheckColor2(ByVal c As Color) As Boolean
        Dim cR As Integer = c.R
        Dim cG As Integer = c.G
        Dim cB As Integer = c.B

        Dim i As Integer = 0

        If cR > 64 Then
            i = i + 1
        Else
            i = i - 1
        End If

        If cG > 64 Then
            i = i + 1
        Else
            i = i - 1
        End If

        If cB > 64 Then
            i = i + 1
        Else
            i = i - 1
        End If

        If i <= 1 Then
            Return True
        Else
            Return False
        End If

        Return False
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then

            Dim bmp As New Bitmap(OpenFileDialog1.FileName)
            Dim tempbmp As New Bitmap(OpenFileDialog1.FileName)
            Dim v As Integer

            ProgressBar1.Maximum = tempbmp.Width * tempbmp.Height * 2

            For i As Integer = 0 To tempbmp.Width - 1

                For j As Integer = 0 To tempbmp.Height - 1

                    If j + 1 < tempbmp.Height Then
                        If CheckColor(tempbmp.GetPixel(i, j + 1), tempbmp.GetPixel(i, j)) = False Then
                            bmp.SetPixel(i, j, Color.Black)
                        Else
                            bmp.SetPixel(i, j, SystemColors.ActiveCaption)
                        End If
                    End If

                    v = v + 1
                    ProgressBar1.Value = v
                Next

                For j As Integer = 0 To tempbmp.Height - 1
                    If i + 1 < tempbmp.Width Then
                        If CheckColor(tempbmp.GetPixel(i + 1, j), tempbmp.GetPixel(i, j)) = False Then
                            bmp.SetPixel(i, j, Color.Black)
                        Else
                            bmp.SetPixel(i, j, SystemColors.ActiveCaption)
                        End If
                    End If

                    v = v + 1
                    ProgressBar1.Value = v
                Next

            Next

            PictureBox1.BackgroundImage = bmp
            bmp.Save("G:\E_1-All.bmp")
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then

            Dim bmp As New Bitmap(OpenFileDialog1.FileName)
            Dim tempbmp As New Bitmap(OpenFileDialog1.FileName)
            Dim v As Integer

            ProgressBar1.Maximum = tempbmp.Width * tempbmp.Height

            For i As Integer = 0 To tempbmp.Width - 1

                For j As Integer = 0 To tempbmp.Height - 1

                    If j + 1 < tempbmp.Height Then
                        If CheckColor(tempbmp.GetPixel(i, j + 1), tempbmp.GetPixel(i, j)) = False Then
                            bmp.SetPixel(i, j, Color.Black)
                        Else
                            bmp.SetPixel(i, j, SystemColors.ActiveCaption)
                        End If
                    End If

                    v = v + 1
                    ProgressBar1.Value = v
                Next

            Next

            PictureBox1.BackgroundImage = bmp

            bmp.Save("G:\E_1-h.bmp")
        End If

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then

            Dim bmp As New Bitmap(OpenFileDialog1.FileName)
            Dim tempbmp As New Bitmap(OpenFileDialog1.FileName)
            Dim v As Integer

            ProgressBar1.Maximum = tempbmp.Width * tempbmp.Height

            For i As Integer = 0 To tempbmp.Width - 1
                For j As Integer = 0 To tempbmp.Height - 1
                    If i + 1 < tempbmp.Width Then
                        If CheckColor(tempbmp.GetPixel(i + 1, j), tempbmp.GetPixel(i, j)) = False Then
                            bmp.SetPixel(i, j, Color.Black)
                        Else
                            bmp.SetPixel(i, j, SystemColors.ActiveCaption)
                        End If
                    End If

                    v = v + 1
                    ProgressBar1.Value = v
                Next
            Next

            PictureBox1.BackgroundImage = bmp

            bmp.Save("G:\E_1-w.bmp")
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then

            Dim bmp As New Bitmap(OpenFileDialog1.FileName)
            Dim tempbmp As New Bitmap(OpenFileDialog1.FileName)
            Dim v As Integer

            ProgressBar1.Maximum = tempbmp.Width * tempbmp.Height

            For i As Integer = 0 To tempbmp.Width - 1
                For j As Integer = 0 To tempbmp.Height - 1

                    If CheckColor2(tempbmp.GetPixel(i, j)) = True Then
                        bmp.SetPixel(i, j, Color.Black)
                    Else
                        bmp.SetPixel(i, j, SystemColors.ActiveCaption)
                    End If

                    v = v + 1
                    ProgressBar1.Value = v
                Next
            Next


            PictureBox1.BackgroundImage = bmp

            bmp.Save("G:\E_2.bmp")
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then

            s = Now

            Dim tempbmp As New Bitmap(OpenFileDialog1.FileName)
            Dim bmp As New Bitmap(tempbmp.Width, tempbmp.Height)
            Dim v As Integer
            ProgressBar1.Maximum = tempbmp.Width * tempbmp.Height

            For i As Integer = 0 To tempbmp.Width - 1
                For j As Integer = 0 To tempbmp.Height - 1
                    bmp.SetPixel(i, j, SystemColors.ActiveCaption)

                    If j + 1 < tempbmp.Height Then
                        If CheckColor(tempbmp.GetPixel(i, j + 1), tempbmp.GetPixel(i, j)) = False Then
                            bmp.SetPixel(i, j, Color.Black)
                        End If
                    End If

                    If i + 1 < tempbmp.Width Then
                        If CheckColor(tempbmp.GetPixel(i + 1, j), tempbmp.GetPixel(i, j)) = False Then
                            bmp.SetPixel(i, j, Color.Black)
                        End If
                    End If

                    If CheckColor2(tempbmp.GetPixel(i, j)) = True Then
                        bmp.SetPixel(i, j, Color.Black)
                    End If

                    v = v + 1
                    ProgressBar1.Value = v
                Next
            Next

            PictureBox1.BackgroundImage = bmp

            bmp.Save("G:\E_All.bmp")
            n = Now
            MsgBox((n - s).ToString)
        End If
    End Sub

End Class

