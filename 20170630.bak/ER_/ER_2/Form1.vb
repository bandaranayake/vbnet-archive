Public Class Form1

    Private objCD As ControlDesigner = Nothing
    Private bolDesignMode As Boolean = False

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        objCD = New ControlDesigner(Me, New List(Of Control)({Button1, Button2}), Color.LightYellow)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        objCD.Dispose()
        objCD = Nothing
    End Sub

End Class
