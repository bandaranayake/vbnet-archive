Public Class Form1
    Private picture As Image
    Private st As String

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        MyBase.OnPaint(e)
        If Me.picture IsNot Nothing Then
            Me.BackgroundImage = (Me.picture)
            Me.BackgroundImageLayout = ImageLayout.Zoom
        End If
    End Sub

    Private Sub Form1_DragDrop(ByVal sender As Object, _
      ByVal e As DragEventArgs) Handles MyBase.DragDrop

        If e.Data.GetDataPresent(DataFormats.FileDrop) Then

            Dim files As String() = CType(e.Data.GetData(DataFormats.FileDrop), String())

            Try
                Me.picture = Image.FromFile(files(0))
                st = files(0)
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                Return
            End Try
        End If

        Me.Invalidate()
    End Sub

    Private Sub Form1_DragEnter(ByVal sender As Object, _
      ByVal e As DragEventArgs) Handles MyBase.DragEnter

        If e.Data.GetDataPresent(DataFormats.Bitmap) _
           Or e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        MsgBox(st)
    End Sub

End Class
