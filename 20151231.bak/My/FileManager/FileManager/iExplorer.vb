Imports System.IO
Imports System.Runtime.InteropServices

Public Class iExplorer
    Dim OnComputer As Boolean
    Dim p, s As String
    Dim ShowIcons As Boolean = True
    Dim ShowHidden As Boolean = True

    Declare Function mciSendString Lib "winmm.dll" Alias "mciSendStringA" _
    (ByVal lpszCommand As String, ByVal lpszReturnString As String, _
    ByVal cchReturnLength As Long, ByVal hwndCallback As Long) As Long

#Region "ContextMenu"

    Private Sub ContextMenuStrip1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        Dim item As ListViewItem = list.FocusedItem
        ResetContextMenu()

        If Not item Is Nothing Then
            If OnComputer = True Then
                EditToolStripMenuItem.Visible = False
                RenameToolStripMenuItem.Visible = False
                DeleteToolStripMenuItem.Visible = False
                MoveToolStripMenuItem.Visible = False
                EjectToolStripMenuItem.Visible = False
                CreateANewFileToolStripMenuItem.Visible = False
                CreateNewFolderToolStripMenuItem.Visible = False
                SizeToolStripMenuItem.Visible = False
                LastWrittenTimeToolStripMenuItem.Visible = False
                AttributesToolStripMenuItem.Visible = False

                If item.SubItems(2).Text = "CDRom" Then
                    EjectToolStripMenuItem.Visible = True
                End If
            Else
                VolumeLabelToolStripMenuItem.Visible = False
                EjectToolStripMenuItem.Visible = False
            End If
        Else
            SelectAllToolStripMenuItem.Visible = False
            OpenToolStripMenuItem.Visible = False
            EditToolStripMenuItem.Visible = False
            RenameToolStripMenuItem.Visible = False
            DeleteToolStripMenuItem.Visible = False
            CopyToolStripMenuItem.Visible = False
            MoveToolStripMenuItem.Visible = False
            EjectToolStripMenuItem.Visible = False
            ExploreWithExplorerToolStripMenuItem.Visible = False
            ShowProperitesToolStripMenuItem.Visible = False
            ShowPropertiesWToolStripMenuItem.Visible = False
            ShortcutToolStripMenuItem.Visible = False
            ChangeIconToolStripMenuItem.Visible = False
            ToolStripSeparator2.Visible = False
            ToolStripSeparator3.Visible = False
            VolumeLabelToolStripMenuItem.Visible = False

            If OnComputer = True Then
                SizeToolStripMenuItem.Visible = False
                LastWrittenTimeToolStripMenuItem.Visible = False
                AttributesToolStripMenuItem.Visible = False
                VolumeLabelToolStripMenuItem.Visible = True
                CreateANewFileToolStripMenuItem.Visible = False
                CreateNewFolderToolStripMenuItem.Visible = False
            End If

        End If

    End Sub

    Private Sub ShowIconsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowIconsMenuItem.Click
        ShowIcons = ShowIconsMenuItem.Checked
        If OnComputer = True Then
            GetDrives()
        Else
            Set4Explore()
            Explore(p)
        End If
    End Sub

    Private Sub ShowHiddenFilesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowHiddenFilesMenuItem.Click
        ShowHidden = ShowHiddenFilesMenuItem.Checked
        If OnComputer = False Then
            Set4Explore()
            Explore(p)
        End If
    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectAllToolStripMenuItem.Click
        For Each item As ListViewItem In list.Items
            item.Selected = True
        Next
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshToolStripMenuItem.Click
        If OnComputer = True Then
            GetDrives()
        Else
            Explore(p)
        End If
    End Sub

    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click
        GoForward()
    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        Dim item As ListViewItem = list.FocusedItem
        If Not item Is Nothing Then
            If item.SubItems(2).Text.ToUpper <> "FILE FOLDER" And OnComputer = False Then
                If txtPath.Text.EndsWith("\") Then
                    txtPath.Text = txtPath.Text
                Else
                    txtPath.Text = txtPath.Text + "\"
                End If

                Dim sp As ProcessStartInfo = New ProcessStartInfo()
                sp.CreateNoWindow = True
                sp.FileName = "notepad.exe"
                sp.Arguments = txtPath.Text + item.Text
                Process.Start(sp)
            End If
        End If
    End Sub

    Private Sub RenameToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RenameToolStripMenuItem.Click
        Dim item As ListViewItem = list.FocusedItem
        item.BeginEdit()
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        For Each item As ListViewItem In list.SelectedItems

            If item Is Nothing Then
                Exit Sub
            End If

            If txtPath.Text.EndsWith("\") Then
                txtPath.Text = txtPath.Text
            Else
                txtPath.Text = txtPath.Text + "\"
            End If

            If item.SubItems(2).Text.ToUpper = "FILE FOLDER" Then
                Dim di As New DirectoryInfo(txtPath.Text + item.Text)

                If di.Exists = True Then
                    Try
                        My.Computer.FileSystem.DeleteDirectory(di.FullName, FileIO.UIOption.AllDialogs, FileIO.RecycleOption.SendToRecycleBin, FileIO.UICancelOption.DoNothing)
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                    End Try
                End If

            Else
                Dim fi As New FileInfo(txtPath.Text + item.Text)

                If fi.Exists = True Then
                    Try
                        My.Computer.FileSystem.DeleteFile(fi.FullName, FileIO.UIOption.AllDialogs, FileIO.RecycleOption.SendToRecycleBin, FileIO.UICancelOption.DoNothing)
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                    End Try
                End If
            End If

        Next
        Explore(txtPath.Text)
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyToolStripMenuItem.Click
        For Each item As ListViewItem In list.SelectedItems
            If item Is Nothing Then
                Exit Sub
            End If

            If txtPath.Text.EndsWith("\") Then
                txtPath.Text = txtPath.Text
            Else
                txtPath.Text = txtPath.Text + "\"
            End If

            If item.SubItems(2).Text.ToUpper = "FILE FOLDER" Then
                Dim di As New DirectoryInfo(txtPath.Text + item.Text)

                If di.Exists = True Then
                    Try
                        Dialog_Func.Label1.Text = "Copy to:"
                        Dialog_Func.Label2.Text = di.FullName
                        Dialog_Func.txtPath.Text = ""

                        If Dialog_Func.ShowDialog = Windows.Forms.DialogResult.OK Then
                            My.Computer.FileSystem.CopyDirectory(di.FullName, Dialog_Func.txtPath.Text + di.Name, FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)
                        End If

                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                    End Try
                End If

            Else

                Dim fi As New FileInfo(txtPath.Text + item.Text)

                If fi.Exists = True Then
                    Try
                        Dialog_Func.Label1.Text = "Copy to:"
                        Dialog_Func.Label2.Text = fi.FullName
                        Dialog_Func.txtPath.Text = ""

                        If Dialog_Func.ShowDialog = Windows.Forms.DialogResult.OK Then
                            My.Computer.FileSystem.CopyFile(fi.FullName, Dialog_Func.txtPath.Text + fi.Name, FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)
                        End If
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                    End Try
                End If

            End If

        Next

        Explore(txtPath.Text)

    End Sub

    Private Sub MoveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MoveToolStripMenuItem.Click
        For Each item As ListViewItem In list.SelectedItems
            If item Is Nothing Then
                Exit Sub
            End If

            If txtPath.Text.EndsWith("\") Then
                txtPath.Text = txtPath.Text
            Else
                txtPath.Text = txtPath.Text + "\"
            End If

            If item.SubItems(2).Text.ToUpper = "FILE FOLDER" Then
                Dim di As New DirectoryInfo(txtPath.Text + item.Text)

                If di.Exists = True Then
                    Try
                        Dialog_Func.Label1.Text = "Move to:"
                        Dialog_Func.Label2.Text = di.FullName
                        Dialog_Func.txtPath.Text = ""

                        If Dialog_Func.ShowDialog = Windows.Forms.DialogResult.OK Then
                            My.Computer.FileSystem.MoveDirectory(di.FullName, Dialog_Func.txtPath.Text + di.Name, FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)
                        End If

                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                    End Try
                End If

            Else

                Dim fi As New FileInfo(txtPath.Text + item.Text)

                If fi.Exists = True Then
                    Try
                        Dialog_Func.Label1.Text = "Move to:"
                        Dialog_Func.Label2.Text = fi.FullName
                        Dialog_Func.txtPath.Text = ""

                        If Dialog_Func.ShowDialog = Windows.Forms.DialogResult.OK Then
                            My.Computer.FileSystem.MoveFile(fi.FullName, Dialog_Func.txtPath.Text + fi.Name, FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)
                        End If
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                    End Try
                End If

            End If

        Next

        Explore(txtPath.Text)
    End Sub

    Private Sub EjectToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EjectToolStripMenuItem.Click
        mciSendString("set CDAudio door open", 0, 0, 0)
    End Sub

    Private Sub CreateNewFolderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateNewFolderToolStripMenuItem.Click
        If txtPath.Text.EndsWith("\") Then
            txtPath.Text = txtPath.Text
        Else
            txtPath.Text = txtPath.Text + "\"
        End If

        Try
            Directory.CreateDirectory(txtPath.Text + "New Directory")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

        Explore(txtPath.Text)
    End Sub

    Private Sub CreateANewFileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateANewFileToolStripMenuItem.Click
        If txtPath.Text.EndsWith("\") Then
            txtPath.Text = txtPath.Text
        Else
            txtPath.Text = txtPath.Text + "\"
        End If

        Try
            File.Create(txtPath.Text + "New File")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

        Explore(txtPath.Text)
    End Sub

    Private Sub ExploreWithExplorerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExploreWithExplorerToolStripMenuItem.Click
        Dim item As ListViewItem = list.FocusedItem

        If Not item Is Nothing Then
            If txtPath.Text.EndsWith("\") Then
                txtPath.Text = txtPath.Text
            Else
                txtPath.Text = txtPath.Text + "\"
            End If

            If OnComputer = False Then
                Dim sp As ProcessStartInfo = New ProcessStartInfo()
                sp.CreateNoWindow = True
                sp.FileName = "explorer.exe"
                sp.Arguments = "/e," + txtPath.Text + item.Text
                Process.Start(sp)
            Else
                Dim sp As ProcessStartInfo = New ProcessStartInfo()
                sp.CreateNoWindow = True
                sp.FileName = "explorer.exe"
                sp.Arguments = "/e," + item.Text
                Process.Start(sp)
            End If
        End If

    End Sub

    Private Sub ShowPropertiesWToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowPropertiesWToolStripMenuItem.Click
        Dim item As ListViewItem = list.FocusedItem

        If Not item Is Nothing Then
            If txtPath.Text.EndsWith("\") Then
                txtPath.Text = txtPath.Text
            Else
                txtPath.Text = txtPath.Text + "\"
            End If

            If OnComputer = False Then
                Dim sei As New SHELLEXECUTEINFO
                sei.cbSize = Marshal.SizeOf(sei)
                sei.lpVerb = "properties"
                sei.lpFile = txtPath.Text + item.Text
                sei.nShow = SW_SHOW
                sei.fMask = SEE_MASK_INVOKEIDLIST
                If Not ShellExecuteEx(sei) Then
                    Dim ex As New System.ComponentModel.Win32Exception(System.Runtime.InteropServices.Marshal.GetLastWin32Error())
                    MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Else
                Dim sei As New SHELLEXECUTEINFO
                sei.cbSize = Marshal.SizeOf(sei)
                sei.lpVerb = "properties"
                sei.lpFile = item.Text
                sei.nShow = SW_SHOW
                sei.fMask = SEE_MASK_INVOKEIDLIST
                If Not ShellExecuteEx(sei) Then
                    Dim ex As New System.ComponentModel.Win32Exception(System.Runtime.InteropServices.Marshal.GetLastWin32Error())
                    MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            End If

        End If
    End Sub

    Private Sub VolumeLabelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VolumeLabelToolStripMenuItem.Click
        list.ListViewItemSorter = New ListViewStringComparer(1)
    End Sub

    Private Sub SizeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SizeToolStripMenuItem.Click
        list.ListViewItemSorter = New ListViewNumberComparer(1)
    End Sub

    Private Sub LastWrittenTimeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LastWrittenTimeToolStripMenuItem.Click
        list.ListViewItemSorter = New ListViewDateComparer(3)

    End Sub

    Private Sub AttributesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AttributesToolStripMenuItem.Click
        list.ListViewItemSorter = New ListViewStringComparer(4)
    End Sub

    Private Sub NameToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NameToolStripMenuItem.Click
        list.ListViewItemSorter = New ListViewStringComparer(0)
    End Sub

    Private Sub TypeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TypeToolStripMenuItem.Click
        list.ListViewItemSorter = New ListViewStringComparer(2)
    End Sub

#End Region

#Region "Viewer"

    Private Sub list_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles list.MouseClick
        If OnComputer = False Then
            Dim item As ListViewItem = list.FocusedItem
            If Not item Is Nothing Then
                lblDateModified.Text = item.SubItems(3).Text
                lblSize.Text = size_(Val(item.SubItems(1).Text))
            End If
        End If
    End Sub

    Private Sub list_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles list.KeyDown
        If (e.KeyCode = Keys.Return) Then
            GoForward()
        ElseIf (e.KeyCode = Keys.Back) Then
            GoBack()
        End If
    End Sub

    Private Sub list_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles list.SelectedIndexChanged
        Dim tf, td, t As Integer
        Dim sz As Double

        If OnComputer = True Then
            For Each item As ListViewItem In list.SelectedItems
                t = t + 1
            Next
            If t = 1 Then
                lblTotalSelected.Text = "Selected " + t.ToString + " drive"
            ElseIf t = 0 Then
                lblTotalSelected.Text = ""
            Else
                lblTotalSelected.Text = "Selected " + t.ToString + " drives"
            End If
        Else
            For Each item As ListViewItem In list.SelectedItems
                If item.SubItems(2).Text.ToUpper = "FILE FOLDER" Then
                    td = td + 1
                Else
                    tf = tf + 1
                    sz = sz + item.SubItems(1).Text
                End If
            Next

            If tf > 1 Then
                If td > 1 Then
                    lblTotalSelected.Text = "Selected " + td.ToString + " folders and " + sz.ToString + " bytes in " + tf.ToString + " files"
                ElseIf td = 1 Then
                    lblTotalSelected.Text = "Selected " + td.ToString + " folder and " + sz.ToString + " bytes in " + tf.ToString + " files"
                Else
                    lblTotalSelected.Text = "Selected " + sz.ToString + " bytes in " + tf.ToString + " files"
                End If
            ElseIf tf = 1 Then
                If td > 1 Then
                    lblTotalSelected.Text = "Selected " + td.ToString + " folders and " + sz.ToString + " bytes in " + tf.ToString + " file"
                ElseIf td = 1 Then
                    lblTotalSelected.Text = "Selected " + td.ToString + " folder and " + sz.ToString + " bytes in " + tf.ToString + " file"
                Else
                    lblTotalSelected.Text = "Selected " + sz.ToString + " bytes in " + tf.ToString + " file"
                End If
            Else
                If td > 1 Then
                    lblTotalSelected.Text = "Selected " + td.ToString + " folders"
                ElseIf td = 1 Then
                    lblTotalSelected.Text = "Selected " + td.ToString + " folder"
                End If
            End If

        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ImageList1.Images.Add(0, My.Resources.dvddrive)
        ImageList1.Images.Add(1, My.Resources.EmptyDrive)
        ImageList1.Images.Add(2, My.Resources.Hard_Drive)
        ImageList1.Images.Add(3, My.Resources.UnknownDrive)
        ImageList1.Images.Add(4, My.Resources.folder_open)
        ImageList1.Images.Add(5, My.Resources.Generic_Document)
        txtPath.Text = "Computer"
        ComboBox1.SelectedIndex = list.View
        list.Select()
        GetDrives()
        OnComputer = True
    End Sub

    Private Sub list_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles list.DoubleClick
        GoForward()
    End Sub

    Private Sub list_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles list.ColumnClick
        If OnComputer = False Then
            If e.Column = 3 Then
                list.ListViewItemSorter = New ListViewDateComparer(e.Column)
            ElseIf e.Column = 1 Then
                list.ListViewItemSorter = New ListViewNumberComparer(e.Column)
            Else
                list.ListViewItemSorter = New ListViewStringComparer(e.Column)
            End If
        Else
            If e.Column <> 3 And e.Column <> 4 Then
                list.ListViewItemSorter = New ListViewStringComparer(e.Column)
            End If
        End If
    End Sub

    Private Sub BtnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBack.Click
        GoBack()
    End Sub

    Private Sub txtPath_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPath.Leave
        txtPath.Text = p
    End Sub

    Private Sub txtPath_KeyDown(ByVal sender As System.Object, ByVal e As KeyEventArgs) Handles txtPath.KeyDown
        If (e.KeyCode = Keys.Return) Then
            If OnComputer = False Then
                Explore(txtPath.Text)
                list.Select()
            ElseIf OnComputer = True And txtPath.Text.ToUpper <> "COMPUTER" Then
                OnComputer = False
                Set4Explore()
                Explore(txtPath.Text)
                list.Select()
            End If
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        list.View = ComboBox1.SelectedIndex

        LargeIconToolStripMenuItem.Checked = False
        DetailsToolStripMenuItem.Checked = False
        SmallIconToolStripMenuItem.Checked = False
        ListToolStripMenuItem.Checked = False
        TileToolStripMenuItem.Checked = False

        If ComboBox1.SelectedIndex = 0 Then
            LargeIconToolStripMenuItem.Checked = True
        ElseIf ComboBox1.SelectedIndex = 1 Then
            DetailsToolStripMenuItem.Checked = True
        ElseIf ComboBox1.SelectedIndex = 2 Then
            SmallIconToolStripMenuItem.Checked = True
        ElseIf ComboBox1.SelectedIndex = 3 Then
            ListToolStripMenuItem.Checked = True
        ElseIf ComboBox1.SelectedIndex = 4 Then
            TileToolStripMenuItem.Checked = True
        End If
    End Sub

    Private Sub list_AfterLabelEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LabelEditEventArgs) Handles list.AfterLabelEdit
        Dim item As ListViewItem = list.Items(e.Item)

        If txtPath.Text.EndsWith("\") Then
            txtPath.Text = txtPath.Text
        Else
            txtPath.Text = txtPath.Text + "\"
        End If

        If item.SubItems(2).Text.ToUpper = "FILE FOLDER" Then
            Dim di As New DirectoryInfo(txtPath.Text + s)

            If di.FullName = e.Label Or e.Label Is Nothing Then
                Exit Sub
            End If

            If di.Exists = True Then
                Try
                    My.Computer.FileSystem.RenameDirectory(di.FullName, e.Label)
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                    e.CancelEdit = True
                End Try
            Else
                e.CancelEdit = True
            End If

        Else
            Dim fi As New FileInfo(txtPath.Text + s)

            If fi.FullName = e.Label Or e.Label Is Nothing Then
                Exit Sub
            End If

            If fi.Exists = True Then
                Try
                    My.Computer.FileSystem.RenameFile(fi.FullName, e.Label)
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                    e.CancelEdit = True
                End Try
            Else
                e.CancelEdit = True
            End If
        End If

        Explore(txtPath.Text)
    End Sub

    Private Sub list_BeforeLabelEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LabelEditEventArgs) Handles list.BeforeLabelEdit
        Dim item As ListViewItem = list.Items(e.Item)
        s = item.Text
    End Sub

    Private Sub View_AllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TileToolStripMenuItem.Click, SmallIconToolStripMenuItem.Click, ListToolStripMenuItem.Click, LargeIconToolStripMenuItem.Click, DetailsToolStripMenuItem.Click
        LargeIconToolStripMenuItem.Checked = False
        DetailsToolStripMenuItem.Checked = False
        SmallIconToolStripMenuItem.Checked = False
        ListToolStripMenuItem.Checked = False
        TileToolStripMenuItem.Checked = False

        sender.Checked = True

        If sender.Text = "Tile" Then
            list.View = View.Tile
            ComboBox1.SelectedIndex = 4
        ElseIf sender.Text = "Details" Then
            list.View = View.Details
            ComboBox1.SelectedIndex = 1
        ElseIf sender.Text = "Large Icon" Then
            list.View = View.LargeIcon
            ComboBox1.SelectedIndex = 0
        ElseIf sender.Text = "Small Icon" Then
            list.View = View.SmallIcon
            ComboBox1.SelectedIndex = 2
        ElseIf sender.Text = "List" Then
            list.View = View.List
            ComboBox1.SelectedIndex = 3
        End If
    End Sub

#End Region

#Region "Funcs"

    Private Sub GoBack()
        If txtPath.Text.Length > 3 And txtPath.Text <> "Computer" Then
            Dim di As DirectoryInfo = New DirectoryInfo(txtPath.Text)

            If txtPath.Text.EndsWith("\") Then
                If txtPath.Text.Length - di.Name.Length = 3 Then
                    txtPath.Text = txtPath.Text.Remove(txtPath.Text.Length - di.Name.Length)
                Else
                    txtPath.Text = txtPath.Text.Remove(txtPath.Text.Length - di.Name.Length - 1)
                End If
            Else
                txtPath.Text = txtPath.Text.Remove(txtPath.Text.Length - di.Name.Length)
            End If

            Explore(txtPath.Text)
        Else
            OnComputer = True
            txtPath.Text = "Computer"
            GetDrives()
        End If
    End Sub

    Private Sub GoForward()
        If OnComputer = True Then
            Dim item As ListViewItem = list.FocusedItem
            If Not item Is Nothing Then
                Dim drv As New DriveInfo(item.Text)

                If drv.DriveType = DriveType.CDRom Then
                    If drv.IsReady = False Then
                        mciSendString("set CDAudio door open", 0, 0, 0)
                        txtPath.Text = list.FocusedItem.Text
                        Set4Explore()
                        OnComputer = False
                    Else
                        txtPath.Text = item.Text
                        Set4Explore()
                        OnComputer = False
                        Explore(txtPath.Text)
                    End If
                Else
                    If drv.IsReady = True Then
                        txtPath.Text = item.Text
                        Set4Explore()
                        OnComputer = False
                        Explore(txtPath.Text)
                    Else
                        txtPath.Text = item.Text
                        Set4Explore()
                        OnComputer = False
                    End If
                End If
            End If
        Else
            Dim item As ListViewItem = list.FocusedItem

            If Not item Is Nothing Then
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
                        Else
                            Process.Start(txtPath.Text + "\" + item.Text)
                        End If
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "Error")
                    End Try
                End If
            End If
        End If
    End Sub

    Private Sub Set4Explore()
        list.Items.Clear()
        list.Columns.Clear()
        list.Columns.Add("Name")
        list.Columns.Add("Size")
        list.Columns.Add("Type")
        list.Columns.Add("Last Written Time")
        list.Columns.Add("Attributes")
        list.AutoResizeColumns(ColumnHeaderAutoResizeStyle.None)

        list.Columns(0).Width = 250
        list.Columns(1).Width = 200
        list.Columns(2).Width = 100
        list.Columns(3).Width = 200
        list.Columns(4).Width = 250

        list.Columns(0).TextAlign = HorizontalAlignment.Left
        list.Columns(1).TextAlign = HorizontalAlignment.Right
        list.Columns(2).TextAlign = HorizontalAlignment.Left
        list.Columns(3).TextAlign = HorizontalAlignment.Left
        list.Columns(4).TextAlign = HorizontalAlignment.Left

        list.AutoArrange = True
    End Sub

    Private Sub Explore(ByVal path As String)
        Dim folderExists As Boolean
        folderExists = My.Computer.FileSystem.DirectoryExists(path)

        If folderExists = True Then
            '''''''''''''S.Reset
            lblDateModified.Text = ""
            lblSize.Text = ""
            lblTotalFD.Text = ""

            If ImageList1.Images.Count > 6 Then
                ImageList1.Images.Clear()
            End If

            ImageList1.Images.Add(0, My.Resources.dvddrive)
            ImageList1.Images.Add(1, My.Resources.EmptyDrive)
            ImageList1.Images.Add(2, My.Resources.Hard_Drive)
            ImageList1.Images.Add(3, My.Resources.UnknownDrive)
            ImageList1.Images.Add(4, My.Resources.folder_open)
            ImageList1.Images.Add(5, My.Resources.Generic_Document)

            txtPath.Text = path
            p = path

            list.Items.Clear()
            '''''''''''''E.Reset

            Dim di As DirectoryInfo = New DirectoryInfo(path)
            Dim i, tf, td As Integer
            Dim sz As Long

            Me.Text = di.Name
            list.BeginUpdate()

            Try
                ProgressBar1.Maximum = di.GetFiles("*.*", SearchOption.TopDirectoryOnly).Count
            Catch
            End Try

            Try
                ProgressBar1.Maximum = ProgressBar1.Maximum + di.GetDirectories("*.*", SearchOption.TopDirectoryOnly).Count()
            Catch
            End Try

            Try
                For Each dir As DirectoryInfo In di.GetDirectories("*.*", SearchOption.TopDirectoryOnly)
                    i = i + 1
                    ProgressBar1.Value = i
                    If CheckAttributes(dir.Attributes) = True Then

                        If ShowHidden = False Then
                            If dir.Attributes.ToString.Contains(FileAttributes.Hidden.ToString) Then
                                GoTo t
                            End If
                        End If

                        Dim item As New ListViewItem(dir.Name)
                        item.SubItems.Add(0)
                        item.SubItems.Add("File folder")
                        item.SubItems.Add(dir.LastWriteTime.ToString)
                        item.SubItems.Add(dir.Attributes.ToString)

                        If ShowIcons = True Then
                            If GetFolderIcon(dir) Is Nothing Then
                                item.ImageKey = ImageList1.Images.Keys(4)
                            Else
                                ImageList1.Images.Add(dir.FullName, GetFolderIcon(dir))
                                item.ImageKey = dir.FullName
                            End If
                        End If

                        td = td + 1
                        list.Items.Add(item)
                    End If
t:
                Next

                For Each fi As FileInfo In di.GetFiles("*.*", SearchOption.TopDirectoryOnly)
                    i = i + 1
                    ProgressBar1.Value = i
                    If CheckAttributes(fi.Attributes) = True Then

                        If ShowHidden = False Then
                            If fi.Attributes.ToString.Contains(FileAttributes.Hidden.ToString) Then
                                GoTo tt
                            End If
                        End If

                        Dim iconForFile As Icon = SystemIcons.WinLogo
                        Dim item As New ListViewItem(fi.Name, 1)

                        If ShowIcons = True Then
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
                        End If

                        ''''''Size
                        sz = sz + fi.Length
                        item.SubItems.Add(fi.Length)

                        ''''''Type
                        If fi.Extension.Length <> 0 Then
                            item.SubItems.Add(fi.Extension.Remove(0, 1))
                        Else
                            item.SubItems.Add("")
                        End If

                        ''''''Date
                        item.SubItems.Add(fi.LastWriteTime.ToString)
                        ''''''Attributes
                        item.SubItems.Add(fi.Attributes.ToString)

                        If ShowIcons = True Then
                            If fi.Extension.ToUpper = ".EXE" Then
                                item.ImageKey = fi.FullName
                            ElseIf fi.Extension.ToUpper = ".ICO" Then
                                item.ImageKey = fi.FullName
                            ElseIf fi.Extension = String.Empty Then
                                item.ImageIndex = 5
                            Else
                                item.ImageKey = fi.Extension
                            End If
                        Else
                            item.ImageKey = "nul"
                        End If

                        tf = tf + 1
                        list.Items.Add(item)
                    End If
tt:
                Next

                If tf > 1 Then
                    If td > 1 Then
                        lblTotalFD.Text = "Total " + td.ToString + " folders and " + sz.ToString + " bytes in " + tf.ToString + " files"
                    ElseIf td = 1 Then
                        lblTotalFD.Text = "Total " + td.ToString + " folder and " + sz.ToString + " bytes in " + tf.ToString + " files"
                    Else
                        lblTotalFD.Text = "Total " + sz.ToString + " bytes in " + tf.ToString + " files"
                    End If
                ElseIf tf = 1 Then
                    If td > 1 Then
                        lblTotalFD.Text = "Total " + td.ToString + " folders and " + sz.ToString + " bytes in " + tf.ToString + " file"
                    ElseIf td = 1 Then
                        lblTotalFD.Text = "Total " + td.ToString + " folder and " + sz.ToString + " bytes in " + tf.ToString + " file"
                    Else
                        lblTotalFD.Text = "Total " + sz.ToString + " bytes in " + tf.ToString + " file"
                    End If
                Else
                    If td > 1 Then
                        lblTotalFD.Text = "Total " + td.ToString + " folders"
                    ElseIf td = 1 Then
                        lblTotalFD.Text = "Total " + td.ToString + " folder"
                    End If
                End If

            Catch ex As Exception
                MsgBox("Access denied !", MsgBoxStyle.OkOnly, "Error")
                lblTotalFD.Text = ""
            End Try

            list.EndUpdate()
        Else
            txtPath.Text = p
            lblTotalFD.Text = ""
            MsgBox("No directory found !", MsgBoxStyle.OkOnly, "Error")
            ProgressBar1.Value = 0
        End If

    End Sub

    Private Sub GetDrives()

        Dim drvs = System.IO.DriveInfo.GetDrives()
        Dim i As Integer = 0

        list.Items.Clear()
        list.Columns.Clear()
        list.Columns.Add("Name                                      ")
        list.Columns.Add("Volume Label                                                   ")
        list.Columns.Add("Type                                              ")
        list.Columns.Add("Total Size                                                ")
        list.Columns.Add("Total Free Size                                           ")
        list.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)

        list.AutoArrange = True

        For Each drv In drvs
            Dim item As New ListViewItem(drv.Name)
            i = i + 1
            If drv.DriveType = IO.DriveType.Fixed Then
                item.SubItems.Add(drv.VolumeLabel)
                item.SubItems.Add(drv.DriveType.ToString)
                item.SubItems.Add(size_(drv.TotalSize))
                item.SubItems.Add(size_(drv.TotalFreeSpace))
                If ShowIcons = True Then
                    item.ImageIndex = 2
                End If
                list.Items.Add(item)
            ElseIf drv.DriveType = IO.DriveType.Removable Then
                item.SubItems.Add(drv.DriveType.ToString)
                item.SubItems.Add(drv.VolumeLabel)
                item.SubItems.Add(size_(drv.TotalSize))
                item.SubItems.Add(size_(drv.TotalFreeSpace))
                If ShowIcons = True Then
                    item.ImageIndex = 1
                End If
                list.Items.Add(item)
            ElseIf drv.DriveType = IO.DriveType.CDRom Then
                If drv.IsReady = False Then
                    item.SubItems.Add("")
                    item.SubItems.Add(drv.DriveType.ToString)
                    item.SubItems.Add("")
                    item.SubItems.Add("")
                    If ShowIcons = True Then
                        item.ImageIndex = 0
                    End If
                    list.Items.Add(item)
                Else
                    item.SubItems.Add(drv.DriveType.ToString)
                    item.SubItems.Add(drv.VolumeLabel)
                    item.SubItems.Add(size_(drv.TotalSize))
                    item.SubItems.Add(size_(drv.TotalFreeSpace))
                    If ShowIcons = True Then
                        item.ImageIndex = 1
                    End If
                    list.Items.Add(item)
                End If
            ElseIf drv.DriveType = IO.DriveType.Unknown Then
                item.SubItems.Add("")
                item.SubItems.Add(drv.DriveType.ToString)
                item.SubItems.Add("")
                item.SubItems.Add("")
                If ShowIcons = True Then
                    item.ImageIndex = 3
                End If
                list.Items.Add(item)
            End If
        Next
    End Sub

    Private Function CheckAttributes(ByVal Attrib As FileAttributes) As Boolean
        If Attrib.ToString.Contains(FileAttributes.System.ToString) And Attrib.ToString.Contains(FileAttributes.Hidden.ToString) Then
            Return False
        End If
        Return True
    End Function

    Private Function GetFolderIcon(ByVal di As DirectoryInfo) As Icon
        Try
            For Each fi As FileInfo In di.GetFiles("desktop.ini", SearchOption.TopDirectoryOnly)
                Using sr As StreamReader = New StreamReader(fi.FullName)
                    Dim line As String = sr.ReadLine

                    Do Until line Is Nothing
                        line = sr.ReadLine

                        If line.ToLower.StartsWith("iconresource=") Then
                            Dim f As FileInfo
                            Dim iconForFile As Icon

                            line = line.Remove(line.IndexOf(","), line.Length - line.IndexOf(","))

                            f = New FileInfo(line.Remove(0, 13))

                            If f.Exists = True Then
                                iconForFile = System.Drawing.Icon.ExtractAssociatedIcon(f.FullName)
                                Return iconForFile
                            End If

                        End If
                    Loop
                End Using

            Next
        Catch
        End Try
        Return Nothing
    End Function

    Private Function size_(ByVal in_fi As Double) As String
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

    Private Sub ResetContextMenu()
        SelectAllToolStripMenuItem.Visible = True
        OpenToolStripMenuItem.Visible = True
        EditToolStripMenuItem.Visible = True
        RenameToolStripMenuItem.Visible = True
        DeleteToolStripMenuItem.Visible = True
        CopyToolStripMenuItem.Visible = True
        MoveToolStripMenuItem.Visible = True
        EjectToolStripMenuItem.Visible = True
        CreateANewFileToolStripMenuItem.Visible = True
        CreateNewFolderToolStripMenuItem.Visible = True
        ExploreWithExplorerToolStripMenuItem.Visible = True
        ShowProperitesToolStripMenuItem.Visible = True
        ShowPropertiesWToolStripMenuItem.Visible = True
        ShortcutToolStripMenuItem.Visible = True
        ChangeIconToolStripMenuItem.Visible = True
        ShowHiddenFilesMenuItem.Visible = True
        ShowIconsMenuItem.Visible = True
        ViewByToolStripMenuItem.Visible = True
        SortByToolStripMenuItem.Visible = True
        ToolStripSeparator2.Visible = True
        ToolStripSeparator3.Visible = True
        ToolStripSeparator1.Visible = True
        NameToolStripMenuItem.Visible = True
        VolumeLabelToolStripMenuItem.Visible = True
        TypeToolStripMenuItem.Visible = True
        SizeToolStripMenuItem.Visible = True
        LastWrittenTimeToolStripMenuItem.Visible = True
        AttributesToolStripMenuItem.Visible = True
    End Sub

#End Region

#Region "Dll Import"

    Public Structure SHELLEXECUTEINFO
        Public cbSize As Integer
        Public fMask As Integer
        Public hwnd As IntPtr
        <MarshalAs(UnmanagedType.LPTStr)> Public lpVerb As String
        <MarshalAs(UnmanagedType.LPTStr)> Public lpFile As String
        <MarshalAs(UnmanagedType.LPTStr)> Public lpParameters As String
        <MarshalAs(UnmanagedType.LPTStr)> Public lpDirectory As String
        Dim nShow As Integer
        Dim hInstApp As IntPtr
        Dim lpIDList As IntPtr
        <MarshalAs(UnmanagedType.LPTStr)> Public lpClass As String
        Public hkeyClass As IntPtr
        Public dwHotKey As Integer
        Public hIcon As IntPtr
        Public hProcess As IntPtr
    End Structure

    Private Const SEE_MASK_INVOKEIDLIST = &HC
    Private Const SEE_MASK_NOCLOSEPROCESS = &H40
    Private Const SEE_MASK_FLAG_NO_UI = &H400
    Public Const SW_SHOW As Short = 5

    <DllImport("Shell32", CharSet:=CharSet.Auto, SetLastError:=True)> _
    Public Shared Function ShellExecuteEx(ByRef lpExecInfo As SHELLEXECUTEINFO) As Boolean
    End Function

#End Region

    Private Sub ShortcutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShortcutToolStripMenuItem.Click
        'Dim wsh As Object = CreateObject("WScript.Shell")
        'Dim MyShortcut

        'MyShortcut = wsh.CreateShortcut(DesktopPath & "\name of shortcut.lnk")
        'MyShortcut.TargetPath = wsh.ExpandEnvironmentStrings("G:\isuru")
        'MyShortcut.WorkingDirectory = wsh.ExpandEnvironmentStrings("G:\")
        'MyShortcut.WindowStyle = 4

        'MyShortcut.Save()
    End Sub

End Class

#Region "Sort"

Class ListViewStringComparer
    Implements IComparer

    Private col As Integer

    Public Sub New()
        col = 0
    End Sub

    Public Sub New(ByVal column As Integer)
        col = column
    End Sub

    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer _
       Implements IComparer.Compare

        Return [String].Compare(CType(x, ListViewItem).SubItems(col).Text, CType(y, ListViewItem).SubItems(col).Text)

    End Function

End Class

Class ListViewDateComparer
    Implements IComparer

    Private col As Integer

    Public Sub New()
        col = 0
    End Sub

    Public Sub New(ByVal column As Integer)
        col = column
    End Sub

    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer _
       Implements IComparer.Compare

        Return [Date].Compare(CType(x, ListViewItem).SubItems(col).Text, CType(y, ListViewItem).SubItems(col).Text)

    End Function

End Class

Class ListViewNumberComparer
    Implements IComparer

    Private col As Integer

    Public Sub New()
        col = 0
    End Sub

    Public Sub New(ByVal column As Integer)
        col = column
    End Sub

    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer _
       Implements IComparer.Compare

        Return [Decimal].Compare(CType(x, ListViewItem).SubItems(col).Text, CType(y, ListViewItem).SubItems(col).Text)

    End Function

End Class

#End Region