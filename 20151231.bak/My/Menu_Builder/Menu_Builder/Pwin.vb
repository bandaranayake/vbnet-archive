Imports System.Windows.Forms

Public Class Pwin

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Dim special As New System.Text.RegularExpressions.Regex("[^a-zA-Z0-9]")

        If TextBox2.Text.EndsWith("\") = False Then
            TextBox1.Text = TextBox1.Text + "\"
        End If

        If My.Computer.FileSystem.DirectoryExists(TextBox2.Text + TextBox1.Text) = True Then
            TextBox1.Text = ""
            MsgBox("Specified name cannot be used because another project already exsits !", MsgBoxStyle.Critical, "Error")
            GoTo a
        End If
        If special.Matches(TextBox1.Text).Count > 0 Then
            TextBox1.Text = ""
            MsgBox("Project name cannot contain Special characters,unicodes and reserved names", MsgBoxStyle.Critical, "Error")
            GoTo a
        Else
            Try
                My.Computer.FileSystem.CreateDirectory(TextBox2.Text + TextBox1.Text)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                GoTo a
            End Try

            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        End If
a:

    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        With FolderBrowserDialog1
            .ShowDialog()
            TextBox2.Text = .SelectedPath
        End With
    End Sub

    Private Sub Pwin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox2.Text = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\Menu Builder\Projects\"
    End Sub

End Class
