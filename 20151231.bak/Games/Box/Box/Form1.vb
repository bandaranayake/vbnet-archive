Public Class Form1
    Dim output As New Bitmap(300, 300)
    Dim gfx As Graphics = Graphics.FromImage(output)
    Dim SpriteX As Integer = 135
    Dim SpriteY As Integer = 135
    Dim moveU As Boolean = False
    Dim moveR As Boolean = False
    Dim moveD As Boolean = False
    Dim moveL As Boolean = False
    Dim moveStep As Integer = 4

    Sub refreshScreen() Handles Timer1.Tick
        gfx.FillRectangle(Brushes.White, 0, 0, 300, 300)
        gfx.FillRectangle(Brushes.Blue, SpriteX, SpriteY, 25, 25)
        display.Image = output

        If moveU = True And SpriteY > 0 Then
            SpriteY -= moveStep
        ElseIf SpriteY < 0 Then
            SpriteY = 0
        End If
        If moveR = True And SpriteX < 275 Then
            SpriteX += moveStep
        ElseIf SpriteX > 275 Then
            SpriteX = 275
        End If
        If moveD = True And SpriteY < 275 Then
            SpriteY += moveStep
        ElseIf SpriteY > 275 Then
            SpriteY = 275
        End If
        If moveL = True And SpriteX > 0 Then
            SpriteX -= moveStep
        ElseIf SpriteX < 0 Then
            SpriteX = 0
        End If
    End Sub

    Private Sub startMoving(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Up
                moveU = True
            Case Keys.Right
                moveR = True
            Case Keys.Down
                moveD = True
            Case Keys.Left
                moveL = True
        End Select
    End Sub

    Private Sub stopMoving(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        Select Case e.KeyCode
            Case Keys.Up
                moveU = False
            Case Keys.Right
                moveR = False
            Case Keys.Down
                moveD = False
            Case Keys.Left
                moveL = False
        End Select
    End Sub
End Class