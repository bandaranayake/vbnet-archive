Imports System.IO
Imports System.Text

Public Class Main
    Dim mouseOffset As Point
    Dim b As Boolean

    Private Sub Me_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles MyBase.MouseDown
        mouseOffset = New Point(-e.X, -e.Y)
    End Sub

    Private Sub Me_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles MyBase.MouseMove
        If e.Button = MouseButtons.Left Then
            Dim mousePos = Control.MousePosition
            mousePos.Offset(mouseOffset.X, mouseOffset.Y)
            Location = mousePos
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Dispose()
    End Sub

    Private Sub btnMinimize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMinimize.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btnTray_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTray.Click
        Me.Hide()
        NotifyIcon1.Visible = True
        NotifyIcon1.ShowBalloonTip(3)
    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        Me.Show()
        NotifyIcon1.Visible = False
    End Sub

    Private Sub GetDrives()
        list.Select()

        Dim drvs = System.IO.DriveInfo.GetDrives()
        Dim i As Integer = 0

        list.Items.Clear()


        For Each drv In drvs
            If drv.DriveType = DriveType.Removable Then
                i = i + 1

                Dim item As New ListViewItem(drv.Name)
                item.SubItems.Add(drv.VolumeLabel)
                item.SubItems.Add(size_(drv.TotalSize))
                item.SubItems.Add(size_(drv.TotalFreeSpace))
                item.ImageIndex = 0
                list.Items.Add(item)
            End If
        Next

        If i <= 0 Then
            lblStatus.Text = "No removable drives found !"
        Else
            lblStatus.Text = i.ToString + " removable drives found !"
        End If
    End Sub

    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GetDrives()
    End Sub

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

    Private Sub ExploreExplorerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExploreExplorerToolStripMenuItem.Click
        For Each item As ListViewItem In list.SelectedItems
            Process.Start(item.Text)
        Next
    End Sub

    Private Sub list_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles list.DoubleClick
        Explorer.p = list.FocusedItem.Text
        Explorer.Show()
        Me.Hide()
    End Sub

    Private Sub SaveDetailsToAFileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveDetailsToAFileToolStripMenuItem.Click
        For Each item As ListViewItem In list.SelectedItems
            Dim sb As New StringBuilder()
            sb.AppendLine("===========================================")
            sb.AppendLine("Drive:    " + item.SubItems.Item(0).Text)
            sb.AppendLine("Volume Label:    " + item.SubItems.Item(1).Text)
            sb.AppendLine("Total Size:    " + item.SubItems.Item(2).Text)
            sb.AppendLine("Available Free Size:    " + item.SubItems.Item(3).Text)
            sb.AppendLine("===========================================")

            Using outfile As New StreamWriter(item.Text + "Drive_Details.txt")
                outfile.Write(sb.ToString())
            End Using

        Next
    End Sub

    Private Sub ExploreToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExploreToolStripMenuItem.Click
        For Each item As ListViewItem In list.SelectedItems
            Explorer.p = item.Text
            Explorer.Show()
            Me.Hide()
        Next
    End Sub

    Private Sub list_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles list.MouseMove
        For Each item As ListViewItem In list.SelectedItems
            lblStatus.Text = " " + item.Text
        Next
    End Sub

    Private Sub PropertiesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PropertiesToolStripMenuItem.Click
        For Each item As ListViewItem In list.SelectedItems

            Dim drvs = System.IO.DriveInfo.GetDrives()

            For Each drv In drvs
                    If drv.Name = item.Text Then
                    Properties.drv = drv
                    Properties.ShowDialog()
                End If
            Next

        Next

    End Sub

End Class
