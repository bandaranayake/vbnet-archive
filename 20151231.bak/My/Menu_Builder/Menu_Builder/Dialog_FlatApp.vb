Imports System.Windows.Forms

Public Class Dialog_FlatApp

    Dim btn As New vButton

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorderColor.Click, btnMouseDC.Click, btnMouseOC.Click
        btn = NewFrame.ActiveControl

        With ColorDialog1
            .AllowFullOpen = True
            .AnyColor = True
            'TabOpen1 = True
            If .ShowDialog() = DialogResult.OK Then
                If sender.Name = btnBorderColor.Name Then
                    btn.FlatAppearance.BorderColor = .Color
                ElseIf sender.Name = btnMouseDC.Name Then
                    btn.FlatAppearance.MouseDownBackColor = .Color
                Else
                    btn.FlatAppearance.MouseOverBackColor = .Color
                End If
                sender.BackColor = .Color
            End If
        End With
    End Sub

    Private Sub NBorderSize_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NBorderSize.ValueChanged
        btn = NewFrame.ActiveControl
        btn.FlatAppearance.BorderSize = NBorderSize.Value
    End Sub

    Private Sub Dialog_FlatApp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btn = NewFrame.ActiveControl
        NBorderSize.Value = btn.FlatAppearance.BorderSize
        btnBorderColor.BackColor = btn.FlatAppearance.BorderColor
        btnMouseDC.BackColor = btn.FlatAppearance.MouseDownBackColor
        btnMouseOC.BackColor = btn.FlatAppearance.MouseOverBackColor
    End Sub

End Class
