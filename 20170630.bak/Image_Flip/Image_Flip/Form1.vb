Imports System.Drawing.Imaging
Imports System.IO

Public Class Form1


    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        ListView1.Items.Clear()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        For Each item As ListViewItem In ListView1.SelectedItems
            ListView1.Items.Remove(item)
        Next
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Button1.Enabled = False
        Button2.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = False
        Button5.Enabled = True

        For Each item As ListViewItem In ListView1.Items
            On Error GoTo en

            Dim i, j As Integer

            Dim bmp As Bitmap = New Bitmap(item.Text)
            Dim xbmp As Bitmap = New Bitmap(bmp.Size.Width, bmp.Size.Height)

            For i = 0 To bmp.Width - 1
                For j = 0 To bmp.Height - 1
                    xbmp.SetPixel(bmp.Width - i - 1, j, bmp.GetPixel(i, j))
                Next
            Next

            xbmp.Save(item.SubItems(1).Text, GetFormat(item.Text))
            bmp.Dispose()
            item.SubItems(2).Text = "Completed"
            item.BackColor = Color.Green
en:
        Next

        For Each item As ListViewItem In ListView1.Items
            If item.BackColor <> Color.Green Then
                item.BackColor = Color.Red
                item.SubItems(2).Text = "Fail"
            End If
        Next

        Button1.Enabled = True
        Button2.Enabled = True
        Button3.Enabled = True
        Button4.Enabled = True
        Button5.Enabled = False
    End Sub

    Private Function GetFormat(ByVal ext As String) As ImageFormat
        Dim s As String = ext.Remove(0, ext.LastIndexOf(".") + 1)

        Select Case s
            Case "bmp"
                Return ImageFormat.Bmp
            Case "png"
                Return ImageFormat.Png
            Case "jpg"
                Return ImageFormat.Jpeg
            Case "jpeg"
                Return ImageFormat.Jpeg
            Case "gif"
                Return ImageFormat.Gif
            Case "ico"
                Return ImageFormat.Icon
            Case Else
                Return ImageFormat.Jpeg
        End Select
    End Function

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Button1.Enabled = True
        Button2.Enabled = True
        Button3.Enabled = True
        Button4.Enabled = True
        Button5.Enabled = False
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        With OpenFileDialog1.ShowDialog
            For Each s In OpenFileDialog1.FileNames
                Dim fi As FileInfo = New FileInfo(s)
                Dim item As New ListViewItem(fi.FullName)
                item.SubItems.Add(fi.FullName.Remove(fi.FullName.Length - fi.Extension.Length, fi.Extension.Length) + "_flip" + fi.Extension)
                item.SubItems.Add("")
                ListView1.Items.Add(item)
            Next
        End With
    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

    End Sub

End Class
