Imports System.Windows.Forms
Imports System.IO

Public Class NewProject

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Dim special As New System.Text.RegularExpressions.Regex("[^a-zA-Z0-9]")

        ' Get project name & project path
        ProjectName = txtProjectName.Text
        If txtProjectPath.Text.EndsWith("\") = False Then
            ProjectPath = txtProjectPath.Text + "\"
        Else
            ProjectPath = txtProjectPath.Text
        End If

        If special.Matches(txtProjectName.Text).Count > 0 Then
            txtProjectName.Text = ""
            MsgBox("Project name cannot contain any Special characters,unicodes and reserved names", MsgBoxStyle.Critical, "Error")
        ElseIf My.Computer.FileSystem.DirectoryExists(ProjectPath) = False Then
            txtProjectPath.Text = ""
            MsgBox("Specified project path is invalid !", MsgBoxStyle.Critical, "Error")
        ElseIf txtProjectName.Text.Length < 0 Then
            MsgBox("Invalid Project Name", MsgBoxStyle.Critical, "Error")
        Else
            Try
                Directory.CreateDirectory(ProjectPath + ProjectName)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                txtProjectName.Text = ""
                txtProjectPath.Text = ""
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

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        Dim folderBrowserDialog As New FolderBrowserDialog
        With folderBrowserDialog
            .Description = "Select a location.."
            .RootFolder = Environment.SpecialFolder.MyComputer
            .ShowNewFolderButton = True
            If (.ShowDialog()) = Windows.Forms.DialogResult.OK Then
                txtProjectPath.Text = .SelectedPath
                txtProjectName.Select()
            End If
        End With
    End Sub

    Private Sub NewProject_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtProjectName.Text = ""
        txtProjectPath.Text = ""
        txtProjectPath.Select()
    End Sub

End Class
