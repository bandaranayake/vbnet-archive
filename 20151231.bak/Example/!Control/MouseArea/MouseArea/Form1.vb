Public Class Form1


    Private Sub Button1_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button1.MouseClick
        Button1.BackColor = Color.Gray
        Timer1.Tag = Button1
        Timer1.Enabled = True
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Tag.BackColor = Color.Transparent
        Timer1.Enabled = False
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        If Timer2.Tag.Location.X < PointToClient(MousePosition).X And Timer2.Tag.Location.X + Timer2.Tag.Width < PointToClient(MousePosition).X Then
            Timer2.Tag.BackColor = Color.Transparent
            Timer2.Enabled = False
        ElseIf Timer2.Tag.Location.Y < PointToClient(MousePosition).Y And Timer2.Tag.Location.Y + Timer2.Tag.Height < PointToClient(MousePosition).Y Then
            Timer2.Tag.BackColor = Color.Transparent
            Timer2.Enabled = False
        ElseIf Timer2.Tag.Location.X > PointToClient(MousePosition).X Or Timer2.Tag.Location.Y > PointToClient(MousePosition).Y Then
            Timer2.Tag.BackColor = Color.Transparent
            Timer2.Enabled = False
        End If
    End Sub

    Private Sub Button1_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.MouseHover
        Button1.BackColor = Color.Silver
        Timer2.Tag = Button1
        Timer2.Enabled = True
    End Sub

End Class
