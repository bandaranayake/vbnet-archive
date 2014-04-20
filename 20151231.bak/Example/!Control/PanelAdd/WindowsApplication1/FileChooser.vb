Public Class FileChooser

    Private Shared defaultPath As String

    Public ReadOnly Property Filename() As String
        Get
            Return Me.FileTextBox.Text
        End Get
    End Property

    Public Property InitialDirectory() As String
        Get
            If defaultPath Is Nothing Then
                defaultPath = My.Computer.FileSystem.CurrentDirectory
            End If
            Return defaultPath
        End Get
        Set(ByVal value As String)
            defaultPath = value
        End Set
    End Property

    Public Sub Reset()
        Me.FileTextBox.Text = String.Empty
    End Sub

    Private Sub FileBrowseButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FileBrowseButton.Click
        Dim fileDialog As New OpenFileDialog()
        fileDialog.InitialDirectory = Me.InitialDirectory
        If (fileDialog.ShowDialog() = DialogResult.OK) Then
            Me.FileTextBox.Text = fileDialog.FileName
            Me.InitialDirectory = System.IO.Path.GetDirectoryName(Filename)
        End If
    End Sub

End Class
