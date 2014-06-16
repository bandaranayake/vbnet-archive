Imports System.IO
Imports System.Text

Public Class Explorer

    Public p As String

    Public Shared Function size_(ByVal in_fi As Double) As String
        If in_fi < 1024 Then
            Return in_fi.ToString + " bytes"
        ElseIf in_fi > 1024 * 1024 * 1024 Then
            Return Math.Round(in_fi / 1024 / 1024 / 1024).ToString + " GB"
        ElseIf in_fi > 1024 * 1024 Then
            Return Math.Round(in_fi / 1024 / 1024).ToString + " MB"
        Else
            Return Math.Round(in_fi / 1024).ToString + " KB"
        End If

    End Function

    Private Sub Explorer_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Main.Show()
    End Sub

    Public Sub Explore(ByVal path As String)
        Dim folderExists As Boolean
        folderExists = My.Computer.FileSystem.DirectoryExists(path)

        If folderExists = True Then
            txtPath.Text = path
            list.Items.Clear()

            If ImageList1.Images.Count > 2 Then
                ImageList1.Images.Clear()
            End If

            ImageList1.Images.Add(0, My.Resources.general_folder)
            ImageList1.Images.Add(1, My.Resources.file_other)

            Dim di As DirectoryInfo = New DirectoryInfo(path)
            Me.Text = di.Name

            list.BeginUpdate()

            list.SmallImageList = ImageList1
            list.View = View.Details

            For Each dir As DirectoryInfo In di.GetDirectories("*.*", SearchOption.TopDirectoryOnly)
                On Error Resume Next
                Dim item As New ListViewItem(dir.Name)
                item.SubItems.Add(dir.LastWriteTime.ToString)
                item.SubItems.Add("File folder")
                item.SubItems.Add("")
                item.SubItems.Add(dir.Attributes.ToString)
                item.ImageKey = ImageList1.Images.Keys(0)
                list.Items.Add(item)
            Next

            For Each fi As FileInfo In di.GetFiles("*.*", SearchOption.TopDirectoryOnly)
                On Error Resume Next
                Dim iconForFile As Icon = SystemIcons.WinLogo
                Dim item As New ListViewItem(fi.Name, 1)
                iconForFile = System.Drawing.Icon.ExtractAssociatedIcon(fi.FullName)

                If fi.Extension.ToUpper = ".EXE" Then
                    ImageList1.Images.Add(fi.FullName, iconForFile)
                ElseIf fi.Extension <> String.Empty Then
                    ImageList1.Images.Add(fi.Extension, iconForFile)
                End If

                item.SubItems.Add(fi.LastWriteTime.ToString)

                If fi.Extension.ToUpper = ".EXE" Then
                    If ImageList1.Images.Keys.Contains(fi.FullName) = False Then
                        iconForFile = System.Drawing.Icon.ExtractAssociatedIcon(fi.FullName)
                        ImageList1.Images.Add(fi.FullName, iconForFile)
                    End If
                ElseIf fi.Extension.ToUpper = ".ICO" Then
                    If ImageList1.Images.Keys.Contains(fi.FullName) = False Then
                        iconForFile = System.Drawing.Icon.ExtractAssociatedIcon(fi.FullName)
                        ImageList1.Images.Add(fi.FullName, iconForFile)
                    End If
                ElseIf fi.Extension <> String.Empty Then
                    If ImageList1.Images.Keys.Contains(fi.Extension) = False Then
                        iconForFile = System.Drawing.Icon.ExtractAssociatedIcon(fi.FullName)
                        ImageList1.Images.Add(fi.Extension, iconForFile)
                    End If
                End If

                item.SubItems.Add(size_(fi.Length))

                item.SubItems.Add(fi.Attributes.ToString)

                list.Items.Add(item)

                If fi.Extension.ToUpper = ".EXE" Then
                    item.ImageKey = fi.FullName
                ElseIf fi.Extension.ToUpper = ".ICO" Then
                    item.ImageKey = fi.FullName
                ElseIf fi.Extension = String.Empty Then
                    item.ImageIndex = 1
                Else
                    item.ImageKey = fi.Extension
                End If
              

            Next

            list.EndUpdate()
        Else
            Dim di As DirectoryInfo = New DirectoryInfo(txtPath.Text)
            txtPath.Text = txtPath.Text.Remove(txtPath.Text.Length - di.Name.Length - 1)
            MsgBox("No directory found !", MsgBoxStyle.OkOnly, "Error")
        End If

    End Sub

    Private Sub Explorer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Explore(p)
        list.Select()
    End Sub

    Private Sub txtPath_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPath.Enter
        list.Select()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If txtPath.Text.Length > 3 Then
            Dim di As DirectoryInfo = New DirectoryInfo(txtPath.Text)
            txtPath.Text = txtPath.Text.Remove(txtPath.Text.Length - di.Name.Length - 1)
            Explore(txtPath.Text)
        End If
    End Sub

    Private Sub list_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles list.DoubleClick
        For Each item As ListViewItem In list.SelectedItems

            If item.SubItems(2).Text.ToUpper = "FILE FOLDER" Then
                If txtPath.Text.EndsWith("\") Then
                    txtPath.Text = txtPath.Text + item.Text
                Else
                    txtPath.Text = txtPath.Text + "\" + item.Text
                End If
                Explore(txtPath.Text)
            Else
                Try
                    If txtPath.Text.EndsWith("\") Then
                        Process.Start(txtPath.Text + item.Text)
                        lblStatus.Text = txtPath.Text + item.Text
                    Else
                        Process.Start(txtPath.Text + "\" + item.Text)
                        lblStatus.Text = txtPath.Text + "\" + item.Text
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error")
                End Try
            End If
        Next
    End Sub

    Private Sub list_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles list.MouseMove
        For Each item As ListViewItem In list.SelectedItems
            lblStatus.Text = " " + item.Text
        Next
    End Sub

End Class
