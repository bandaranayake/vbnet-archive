Imports System.IO
Imports System.Text

Public Class Properties

    Public drv As DriveInfo

    Private Sub Properties_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblFree1.Text = drv.AvailableFreeSpace.ToString + " bytes"
        lblUsed1.Text = (drv.TotalSize - drv.AvailableFreeSpace).ToString + " bytes"

        lblFree2.Text = size_(drv.AvailableFreeSpace)
        lblUsed2.Text = size_(drv.TotalSize - drv.AvailableFreeSpace)

        lblTotal.Text = "Total Capacity:     " + drv.TotalSize.ToString + " bytes"
        lblDrive.Text = drv.VolumeLabel + " [" + drv.Name + "]"

        Panel1.Select()
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

    Private Sub btnU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnU.Click
        If (ColorDialog1.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            btnU.BackColor = ColorDialog1.Color
        End If
        Panel1.Refresh()
    End Sub

    Private Sub btnF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF.Click
        If (ColorDialog1.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            btnF.BackColor = ColorDialog1.Color
        End If
        Panel1.Refresh()
    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        e.Graphics.Clear(Color.Transparent)

        Using brush As New SolidBrush(btnF.BackColor)
            e.Graphics.FillPie(brush,
                            New Rectangle(New Point(10, 10), New Point(180, 180)),
                            0,
                            drv.AvailableFreeSpace * 360 / (drv.AvailableFreeSpace + (drv.TotalSize - drv.AvailableFreeSpace)))
        End Using

        Using brush As New SolidBrush(btnU.BackColor)
            e.Graphics.FillPie(brush,
                            New Rectangle(New Point(10, 10), New Point(180, 180)),
                                drv.AvailableFreeSpace * 360 / (drv.AvailableFreeSpace + (drv.TotalSize - drv.AvailableFreeSpace)),
                            (drv.TotalSize - drv.AvailableFreeSpace) * 360 / (drv.AvailableFreeSpace + (drv.TotalSize - drv.AvailableFreeSpace)))
        End Using
    End Sub

End Class
