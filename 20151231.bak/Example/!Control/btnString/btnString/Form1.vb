Public Class Form1

    Dim main As String = "Button1"
    Dim other() As String = ({"Button2", "Button3", "Button4", "Button5"})
    Dim loc As Point

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        For Each btn As Button In Me.Controls
            If btn.Name = main Then
                loc = btn.Location
            End If
        Next

        For Each btn As Button In Me.Controls
            For Each st As String In other
                If btn.Name = st Then
                    btn.Location = New Point(loc.X, btn.Location.Y)
                End If
            Next
        Next
    End Sub

End Class
