<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnMinimize = New System.Windows.Forms.Button()
        Me.btnTray = New System.Windows.Forms.Button()
        Me.lblHead = New System.Windows.Forms.Label()
        Me.lblVer = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.list = New System.Windows.Forms.ListView()
        Me.CDrive = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CVolumeLabel = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CTotalSize = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CFreeSize = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExploreExplorerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveDetailsToAFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExploreToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PropertiesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.ExploreWithWindowsExplorerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExploreWithWindowsExplorerToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExploreWithWindowsExplorerToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.Transparent
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(58, 3)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(20, 20)
        Me.btnClose.TabIndex = 0
        Me.btnClose.Text = "X"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'btnMinimize
        '
        Me.btnMinimize.BackColor = System.Drawing.Color.Transparent
        Me.btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMinimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnMinimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMinimize.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMinimize.Location = New System.Drawing.Point(32, 3)
        Me.btnMinimize.Name = "btnMinimize"
        Me.btnMinimize.Size = New System.Drawing.Size(20, 20)
        Me.btnMinimize.TabIndex = 1
        Me.btnMinimize.Text = "─"
        Me.btnMinimize.UseVisualStyleBackColor = False
        '
        'btnTray
        '
        Me.btnTray.BackColor = System.Drawing.Color.Transparent
        Me.btnTray.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTray.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnTray.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnTray.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTray.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTray.Location = New System.Drawing.Point(6, 3)
        Me.btnTray.Name = "btnTray"
        Me.btnTray.Size = New System.Drawing.Size(20, 20)
        Me.btnTray.TabIndex = 2
        Me.btnTray.Text = "v"
        Me.btnTray.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnTray.UseVisualStyleBackColor = False
        '
        'lblHead
        '
        Me.lblHead.AutoSize = True
        Me.lblHead.BackColor = System.Drawing.Color.Transparent
        Me.lblHead.Font = New System.Drawing.Font("Palatino Linotype", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHead.ForeColor = System.Drawing.Color.Silver
        Me.lblHead.Location = New System.Drawing.Point(101, 18)
        Me.lblHead.Name = "lblHead"
        Me.lblHead.Size = New System.Drawing.Size(246, 26)
        Me.lblHead.TabIndex = 3
        Me.lblHead.Text = "Removable Driver Finder."
        '
        'lblVer
        '
        Me.lblVer.AutoSize = True
        Me.lblVer.BackColor = System.Drawing.Color.Transparent
        Me.lblVer.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVer.Location = New System.Drawing.Point(353, 28)
        Me.lblVer.Name = "lblVer"
        Me.lblVer.Size = New System.Drawing.Size(47, 15)
        Me.lblVer.TabIndex = 12
        Me.lblVer.Text = "v1.0.0.1"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(15, 13)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(80, 37)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 6
        Me.PictureBox1.TabStop = False
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.NotifyIcon1.BalloonTipText = "Click Me !"
        Me.NotifyIcon1.BalloonTipTitle = "Removable Driver Finder."
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "Removable Drives"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.Controls.Add(Me.btnTray)
        Me.Panel1.Controls.Add(Me.btnMinimize)
        Me.Panel1.Location = New System.Drawing.Point(712, 11)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(85, 28)
        Me.Panel1.TabIndex = 13
        '
        'list
        '
        Me.list.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.list.AllowColumnReorder = True
        Me.list.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.list.AutoArrange = False
        Me.list.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.list.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.list.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.CDrive, Me.CVolumeLabel, Me.CTotalSize, Me.CFreeSize})
        Me.list.ContextMenuStrip = Me.ContextMenuStrip1
        Me.list.Cursor = System.Windows.Forms.Cursors.Hand
        Me.list.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.list.ForeColor = System.Drawing.Color.Silver
        Me.list.FullRowSelect = True
        Me.list.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.list.HotTracking = True
        Me.list.HoverSelection = True
        Me.list.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.list.Location = New System.Drawing.Point(8, 67)
        Me.list.MultiSelect = False
        Me.list.Name = "list"
        Me.list.ShowGroups = False
        Me.list.Size = New System.Drawing.Size(790, 363)
        Me.list.SmallImageList = Me.ImageList1
        Me.list.TabIndex = 14
        Me.list.UseCompatibleStateImageBehavior = False
        Me.list.View = System.Windows.Forms.View.Details
        '
        'CDrive
        '
        Me.CDrive.Text = "Drive"
        Me.CDrive.Width = 185
        '
        'CVolumeLabel
        '
        Me.CVolumeLabel.Text = "Volume Label"
        Me.CVolumeLabel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.CVolumeLabel.Width = 200
        '
        'CTotalSize
        '
        Me.CTotalSize.Text = "Total Size"
        Me.CTotalSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.CTotalSize.Width = 200
        '
        'CFreeSize
        '
        Me.CFreeSize.Text = "Free Size"
        Me.CFreeSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.CFreeSize.Width = 200
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.AutoSize = False
        Me.ContextMenuStrip1.BackgroundImage = CType(resources.GetObject("ContextMenuStrip1.BackgroundImage"), System.Drawing.Image)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.ExploreExplorerToolStripMenuItem, Me.SaveDetailsToAFileToolStripMenuItem, Me.ToolStripSeparator1, Me.ExploreToolStripMenuItem, Me.PropertiesToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.ShowImageMargin = False
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(180, 110)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripSeparator2.ForeColor = System.Drawing.Color.Transparent
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(176, 6)
        '
        'ExploreExplorerToolStripMenuItem
        '
        Me.ExploreExplorerToolStripMenuItem.ForeColor = System.Drawing.Color.Silver
        Me.ExploreExplorerToolStripMenuItem.Name = "ExploreExplorerToolStripMenuItem"
        Me.ExploreExplorerToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.ExploreExplorerToolStripMenuItem.Text = "Explore with Windows Explorer"
        '
        'SaveDetailsToAFileToolStripMenuItem
        '
        Me.SaveDetailsToAFileToolStripMenuItem.ForeColor = System.Drawing.Color.Silver
        Me.SaveDetailsToAFileToolStripMenuItem.Name = "SaveDetailsToAFileToolStripMenuItem"
        Me.SaveDetailsToAFileToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.SaveDetailsToAFileToolStripMenuItem.Text = "Save Details to a file"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(176, 6)
        '
        'ExploreToolStripMenuItem
        '
        Me.ExploreToolStripMenuItem.ForeColor = System.Drawing.Color.Silver
        Me.ExploreToolStripMenuItem.Name = "ExploreToolStripMenuItem"
        Me.ExploreToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.ExploreToolStripMenuItem.Text = "Explore"
        '
        'PropertiesToolStripMenuItem
        '
        Me.PropertiesToolStripMenuItem.ForeColor = System.Drawing.Color.Silver
        Me.PropertiesToolStripMenuItem.Name = "PropertiesToolStripMenuItem"
        Me.PropertiesToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.PropertiesToolStripMenuItem.Text = "Properties"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "EmptyDrive.ico")
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.ForeColor = System.Drawing.Color.White
        Me.lblStatus.Location = New System.Drawing.Point(5, 438)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(38, 13)
        Me.lblStatus.TabIndex = 15
        Me.lblStatus.Text = "Ready"
        '
        'ExploreWithWindowsExplorerToolStripMenuItem
        '
        Me.ExploreWithWindowsExplorerToolStripMenuItem.Name = "ExploreWithWindowsExplorerToolStripMenuItem"
        Me.ExploreWithWindowsExplorerToolStripMenuItem.Size = New System.Drawing.Size(233, 22)
        Me.ExploreWithWindowsExplorerToolStripMenuItem.Text = "Explore with windows Explorer"
        '
        'ExploreWithWindowsExplorerToolStripMenuItem1
        '
        Me.ExploreWithWindowsExplorerToolStripMenuItem1.Name = "ExploreWithWindowsExplorerToolStripMenuItem1"
        Me.ExploreWithWindowsExplorerToolStripMenuItem1.Size = New System.Drawing.Size(235, 22)
        Me.ExploreWithWindowsExplorerToolStripMenuItem1.Text = "Explore with Windows Explorer"
        '
        'ExploreWithWindowsExplorerToolStripMenuItem2
        '
        Me.ExploreWithWindowsExplorerToolStripMenuItem2.Name = "ExploreWithWindowsExplorerToolStripMenuItem2"
        Me.ExploreWithWindowsExplorerToolStripMenuItem2.Size = New System.Drawing.Size(235, 22)
        Me.ExploreWithWindowsExplorerToolStripMenuItem2.Text = "Explore with Windows Explorer"
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(807, 460)
        Me.ControlBox = False
        Me.Controls.Add(Me.list)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lblHead)
        Me.Controls.Add(Me.lblVer)
        Me.ForeColor = System.Drawing.Color.Silver
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Main"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnTray As System.Windows.Forms.Button
    Friend WithEvents btnMinimize As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lblHead As System.Windows.Forms.Label
    Friend WithEvents lblVer As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents list As System.Windows.Forms.ListView
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents CDrive As System.Windows.Forms.ColumnHeader
    Friend WithEvents CVolumeLabel As System.Windows.Forms.ColumnHeader
    Friend WithEvents CTotalSize As System.Windows.Forms.ColumnHeader
    Friend WithEvents CFreeSize As System.Windows.Forms.ColumnHeader
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ExploreWithWindowsExplorerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExploreWithWindowsExplorerToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExploreWithWindowsExplorerToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExploreExplorerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveDetailsToAFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExploreToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PropertiesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
