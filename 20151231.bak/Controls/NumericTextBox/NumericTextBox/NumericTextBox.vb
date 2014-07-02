Public Class NumericTextBox

    Private Sub NumericTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.TextChanged
        Dim tmp As String = ""
        Dim i As Integer = 0

        For Each C As Char In Me.Text
            If i = 0 Then
                If Me.Text.StartsWith("-") = True And Me.MinVal < 0 Then
                    tmp = "-" + tmp
                End If
            End If

            If Char.IsDigit(C) Then
                tmp = tmp + C
            End If
            i = i + 1
        Next

        If Val(tmp) > Me.MaxVal Then
            tmp = Me.MaxVal
        ElseIf Val(tmp) < MinVal Then
            tmp = Me.MinVal
        End If

        Me.Text = tmp
    End Sub

End Class
