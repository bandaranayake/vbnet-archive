Imports System.IO

Public Class Form1

    Public Function Effect1(ByVal source As Bitmap) As Bitmap
        Dim bm As New Bitmap(source.Width, source.Height)

        Dim x

        Dim y

        For y = 0 To bm.Height - 1

            For x = 0 To bm.Width - 1

                Dim c As Color = source.GetPixel(x, y)

                Dim r, g, b As Integer

                If c.R > 220 Then
                    r = 220
                ElseIf c.R < 100 Then
                    r = 100
                Else
                    r = c.R
                End If

                If c.B > 220 Then
                    b = 220
                ElseIf c.B < 100 Then
                    b = 100
                Else
                    b = c.B
                End If

                If c.G < 100 Then
                    g = 100
                ElseIf c.G > 200 Then
                    r = c.R
                    b = c.B
                    g = c.G
                Else
                    g = c.G
                End If

                bm.SetPixel(x, y, Color.FromArgb(r, g, b))
            Next

        Next

        Return bm

    End Function

    Public Function Effect2(ByVal source As Bitmap) As Bitmap
        Dim bm As New Bitmap(source.Width, source.Height)

        Dim x

        Dim y

        For y = 0 To bm.Height - 1

            For x = 0 To bm.Width - 1

                Dim c As Color = source.GetPixel(x, y)

                Dim r, g, b As Integer
                r = c.R
                g = c.G
                b = c.B

                If c.R < 100 Then
                    r = 100
                ElseIf c.R > 220 Then
                    r = 220
                End If

                If c.G < 100 Then
                    g = 100
                ElseIf c.G > 220 Then
                    g = 220
                End If

                If c.B < 100 Then
                    b = 100
                ElseIf c.B > 220 Then
                    b = 220
                End If

                bm.SetPixel(x, y, Color.FromArgb(r, g, b))
            Next

        Next

        Return bm

    End Function

    Public Function Effect3(ByVal source1 As Bitmap, ByVal source2 As Bitmap) As Bitmap
        Dim bm As New Bitmap(source1.Width, source2.Height)

        Dim x As Integer
        Dim y As Integer
        Dim b As Boolean = True

        For y = 0 To bm.Height - 1
            b = Not b

            For x = 0 To bm.Width - 1

                Dim c1 As Color = source1.GetPixel(x, y)
                Dim c2 As Color = source2.GetPixel(x, y)

                If b = True Then
                    If x Mod 2 = 0 Then
                        bm.SetPixel(x, y, c2)
                    Else
                        bm.SetPixel(x, y, c1)
                    End If
                Else
                    If x Mod 2 = 0 Then
                        bm.SetPixel(x, y, c1)
                    Else
                        bm.SetPixel(x, y, c2)
                    End If
                End If

            Next

        Next

        Return bm
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim bmp As New Bitmap("E:\Isuru\Working\a.jpg")

        Effect1(bmp).Save("E:\Isuru\Working\g9.jpg")

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim bmp As New Bitmap("E:\Isuru\Working\a.jpg")


        Effect2(bmp).Save("E:\Isuru\Working\g98.jpg")


    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
       
    End Sub
End Class
