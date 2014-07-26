Public Class Form1

    Dim i As Integer = -1
    Dim Tiles As New List(Of Bitmap)
    Dim Walls As New List(Of Bitmap)
    Dim Floors As New List(Of Bitmap)
    Dim pt As Point

    Const v As Integer = 50

    Private Sub Form1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyData = Keys.Up Then
            i = 0
            pt = New Point(pt.X + 6.25, pt.Y - 4)
        ElseIf e.KeyData = Keys.Down Then
            i = 1
            pt = New Point(pt.X - 6.25, pt.Y + 4)
        ElseIf e.KeyData = Keys.Left Then
            i = 2
            pt = New Point(pt.X - 6.25, pt.Y - 4)
        ElseIf e.KeyData = Keys.Right Then
            i = 3
            pt = New Point(pt.X + 6.25, pt.Y + 4)
        Else
            Return
        End If

        Display.Invalidate()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For k = 0 To 3
            Tiles.Add(Bitmap.FromFile(Environment.CurrentDirectory & "\images\t" & k & ".png"))
        Next

        For k = 0 To 1
            Walls.Add(Bitmap.FromFile(Environment.CurrentDirectory & "\images\w" & k & ".png"))
        Next

        Floors.Add(Bitmap.FromFile(Environment.CurrentDirectory & "\images\f0.png"))

        pt = New Point(6.25, 4)
    End Sub

    Private Sub DrawBack(ByVal e As System.Windows.Forms.PaintEventArgs)

        Dim rs, rd As Rectangle
        Dim x, y As Integer

        rd = New Rectangle(New Point(0, 0), New Point(v, v))

        For k = 0 To 10
            x = 25 + (k * 25)
            y = -52 + (k * 16)

            rs = New Rectangle(New Point(x, y), New Point(v, v))


            e.Graphics.DrawImage(Walls(0), rs, rd, GraphicsUnit.Pixel)
            e.Graphics.DrawRectangle(New Pen(Brushes.Red, 1), rs)

            x = -21 + (k * 25)

            rs = New Rectangle(New Point(x, y), New Point(v, v))

            e.Graphics.DrawImage(Floors(0), rs, rd, GraphicsUnit.Pixel)
            e.Graphics.DrawRectangle(New Pen(Brushes.Blue, 1), rs)
        Next
    End Sub

    Private Sub PictureBox1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Display.Paint
        If i >= 0 Then
            DrawBack(e)
            e.Graphics.DrawImage(Tiles(i), pt)
        End If
    End Sub

    Private Sub Display_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Display.MouseMove
        Me.Text = e.Location.ToString
    End Sub

End Class