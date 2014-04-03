Public Class Form1
    Private fruitContextMenuStrip As New ContextMenuStrip

    Dim toolStripButton1, toolStripButton2 As New ToolStripButton

    Sub cms_Opening(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        fruitContextMenuStrip.Items.Clear()

        Me.toolStripButton1.Name = "toolStripButton1"
        Me.toolStripButton1.Text = "&New"
        AddHandler toolStripButton1.Click, AddressOf toolStripButton1_Click

        Me.toolStripButton2.Name = "toolStripButton2"
        Me.toolStripButton2.Text = "&Open"
        AddHandler toolStripButton2.Click, AddressOf toolStripButton2_Click

        fruitContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripButton1, Me.toolStripButton2})

        e.Cancel = False
    End Sub

    Private Sub toolStripButton1_Click(ByVal sender As Object, ByVal e As EventArgs)
        MessageBox.Show("You have mail.")
    End Sub

    Private Sub toolStripButton2_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Add the response to the Click event here.
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddHandler fruitContextMenuStrip.Opening, AddressOf cms_Opening

        Dim b As New Button()
        b.Location = New System.Drawing.Point(60, 60)
        Me.Controls.Add(b)
        b.ContextMenuStrip = fruitContextMenuStrip

        Dim c As New Button
        b.Location = New System.Drawing.Point(100, 100)
        Me.Controls.Add(c)
        c.ContextMenuStrip = fruitContextMenuStrip
    End Sub

End Class