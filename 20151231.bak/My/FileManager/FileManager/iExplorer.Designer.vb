<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class iExplorer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(iExplorer))
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblDateModified = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblSize = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblTotalSelected = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblTotalFD = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel5 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.list = New System.Windows.Forms.ListView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SelectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RenameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MoveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EjectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CreateNewFolderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CreateANewFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExploreWithExplorerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowPropertiesWToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowProperitesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShortcutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangeIconToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ShowHiddenFilesMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowIconsMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewByToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LargeIconToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SmallIconToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SortByToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VolumeLabelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TypeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SizeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LastWrittenTimeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AttributesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.BtnBack = New System.Windows.Forms.Button()
        Me.txtPath = New System.Windows.Forms.TextBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.btnSettings = New System.Windows.Forms.Button()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.StatusStrip1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(32, 32)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus, Me.ToolStripStatusLabel3, Me.lblDateModified, Me.ToolStripStatusLabel4, Me.lblSize, Me.ToolStripStatusLabel1, Me.lblTotalSelected, Me.ToolStripStatusLabel2, Me.lblTotalFD, Me.ToolStripStatusLabel5, Me.ProgressBar1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 656)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1020, 22)
        Me.StatusStrip1.TabIndex = 5
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = False
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(90, 17)
        Me.lblStatus.Text = "Ready"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(13, 17)
        Me.ToolStripStatusLabel3.Text = "| "
        '
        'lblDateModified
        '
        Me.lblDateModified.AutoSize = False
        Me.lblDateModified.Name = "lblDateModified"
        Me.lblDateModified.Size = New System.Drawing.Size(140, 17)
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(13, 17)
        Me.ToolStripStatusLabel4.Text = "| "
        '
        'lblSize
        '
        Me.lblSize.AutoSize = False
        Me.lblSize.Name = "lblSize"
        Me.lblSize.Size = New System.Drawing.Size(70, 17)
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(13, 17)
        Me.ToolStripStatusLabel1.Text = "| "
        '
        'lblTotalSelected
        '
        Me.lblTotalSelected.AutoSize = False
        Me.lblTotalSelected.Name = "lblTotalSelected"
        Me.lblTotalSelected.Size = New System.Drawing.Size(250, 17)
        Me.lblTotalSelected.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(13, 17)
        Me.ToolStripStatusLabel2.Text = "| "
        '
        'lblTotalFD
        '
        Me.lblTotalFD.AutoSize = False
        Me.lblTotalFD.Name = "lblTotalFD"
        Me.lblTotalFD.Size = New System.Drawing.Size(250, 17)
        Me.lblTotalFD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripStatusLabel5
        '
        Me.ToolStripStatusLabel5.Name = "ToolStripStatusLabel5"
        Me.ToolStripStatusLabel5.Size = New System.Drawing.Size(10, 17)
        Me.ToolStripStatusLabel5.Text = "|"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(120, 16)
        '
        'list
        '
        Me.list.AllowColumnReorder = True
        Me.list.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.list.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.list.ContextMenuStrip = Me.ContextMenuStrip1
        Me.list.Cursor = System.Windows.Forms.Cursors.Hand
        Me.list.Dock = System.Windows.Forms.DockStyle.Fill
        Me.list.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.list.ForeColor = System.Drawing.Color.Silver
        Me.list.FullRowSelect = True
        Me.list.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.list.LabelEdit = True
        Me.list.LargeImageList = Me.ImageList1
        Me.list.Location = New System.Drawing.Point(0, 32)
        Me.list.Name = "list"
        Me.list.ShowGroups = False
        Me.list.Size = New System.Drawing.Size(1020, 624)
        Me.list.SmallImageList = Me.ImageList1
        Me.list.TabIndex = 8
        Me.list.UseCompatibleStateImageBehavior = False
        Me.list.View = System.Windows.Forms.View.Details
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SelectAllToolStripMenuItem, Me.RefreshToolStripMenuItem, Me.ToolStripSeparator2, Me.OpenToolStripMenuItem, Me.EditToolStripMenuItem, Me.RenameToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.CopyToolStripMenuItem, Me.MoveToolStripMenuItem, Me.EjectToolStripMenuItem, Me.CreateNewFolderToolStripMenuItem, Me.CreateANewFileToolStripMenuItem, Me.ToolStripSeparator3, Me.ExploreWithExplorerToolStripMenuItem, Me.ShowPropertiesWToolStripMenuItem, Me.ShowProperitesToolStripMenuItem, Me.ShortcutToolStripMenuItem, Me.ChangeIconToolStripMenuItem, Me.ToolStripSeparator1, Me.ShowHiddenFilesMenuItem, Me.ShowIconsMenuItem, Me.ViewByToolStripMenuItem, Me.SortByToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(231, 462)
        '
        'SelectAllToolStripMenuItem
        '
        Me.SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem"
        Me.SelectAllToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.SelectAllToolStripMenuItem.Text = "Select All"
        '
        'RefreshToolStripMenuItem
        '
        Me.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem"
        Me.RefreshToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.RefreshToolStripMenuItem.Text = "Refresh"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(227, 6)
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.OpenToolStripMenuItem.Text = "Open"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'RenameToolStripMenuItem
        '
        Me.RenameToolStripMenuItem.Name = "RenameToolStripMenuItem"
        Me.RenameToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.RenameToolStripMenuItem.Text = "Rename"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.CopyToolStripMenuItem.Text = "Copy"
        '
        'MoveToolStripMenuItem
        '
        Me.MoveToolStripMenuItem.Name = "MoveToolStripMenuItem"
        Me.MoveToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.MoveToolStripMenuItem.Text = "Move"
        '
        'EjectToolStripMenuItem
        '
        Me.EjectToolStripMenuItem.Name = "EjectToolStripMenuItem"
        Me.EjectToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.EjectToolStripMenuItem.Text = "Eject"
        '
        'CreateNewFolderToolStripMenuItem
        '
        Me.CreateNewFolderToolStripMenuItem.Name = "CreateNewFolderToolStripMenuItem"
        Me.CreateNewFolderToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.CreateNewFolderToolStripMenuItem.Text = "Create a folder"
        '
        'CreateANewFileToolStripMenuItem
        '
        Me.CreateANewFileToolStripMenuItem.Name = "CreateANewFileToolStripMenuItem"
        Me.CreateANewFileToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.CreateANewFileToolStripMenuItem.Text = "Create a file"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(227, 6)
        '
        'ExploreWithExplorerToolStripMenuItem
        '
        Me.ExploreWithExplorerToolStripMenuItem.Name = "ExploreWithExplorerToolStripMenuItem"
        Me.ExploreWithExplorerToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.ExploreWithExplorerToolStripMenuItem.Text = "Explore with Explorer"
        '
        'ShowPropertiesWToolStripMenuItem
        '
        Me.ShowPropertiesWToolStripMenuItem.Name = "ShowPropertiesWToolStripMenuItem"
        Me.ShowPropertiesWToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.ShowPropertiesWToolStripMenuItem.Text = "Show Properties with Explorer"
        '
        'ShowProperitesToolStripMenuItem
        '
        Me.ShowProperitesToolStripMenuItem.Name = "ShowProperitesToolStripMenuItem"
        Me.ShowProperitesToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.ShowProperitesToolStripMenuItem.Text = "Show Properties"
        '
        'ShortcutToolStripMenuItem
        '
        Me.ShortcutToolStripMenuItem.Name = "ShortcutToolStripMenuItem"
        Me.ShortcutToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.ShortcutToolStripMenuItem.Text = "Create a shortcut"
        '
        'ChangeIconToolStripMenuItem
        '
        Me.ChangeIconToolStripMenuItem.Name = "ChangeIconToolStripMenuItem"
        Me.ChangeIconToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.ChangeIconToolStripMenuItem.Text = "Change Icon"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(227, 6)
        '
        'ShowHiddenFilesMenuItem
        '
        Me.ShowHiddenFilesMenuItem.Checked = True
        Me.ShowHiddenFilesMenuItem.CheckOnClick = True
        Me.ShowHiddenFilesMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ShowHiddenFilesMenuItem.Name = "ShowHiddenFilesMenuItem"
        Me.ShowHiddenFilesMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.ShowHiddenFilesMenuItem.Text = "Show hidden files"
        '
        'ShowIconsMenuItem
        '
        Me.ShowIconsMenuItem.Checked = True
        Me.ShowIconsMenuItem.CheckOnClick = True
        Me.ShowIconsMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ShowIconsMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ShowIconsMenuItem.Name = "ShowIconsMenuItem"
        Me.ShowIconsMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.ShowIconsMenuItem.Text = "Show Icons"
        '
        'ViewByToolStripMenuItem
        '
        Me.ViewByToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LargeIconToolStripMenuItem, Me.DetailsToolStripMenuItem, Me.SmallIconToolStripMenuItem, Me.ListToolStripMenuItem, Me.TileToolStripMenuItem})
        Me.ViewByToolStripMenuItem.Name = "ViewByToolStripMenuItem"
        Me.ViewByToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.ViewByToolStripMenuItem.Text = "View By"
        '
        'LargeIconToolStripMenuItem
        '
        Me.LargeIconToolStripMenuItem.CheckOnClick = True
        Me.LargeIconToolStripMenuItem.Name = "LargeIconToolStripMenuItem"
        Me.LargeIconToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.LargeIconToolStripMenuItem.Text = "Large Icon"
        '
        'DetailsToolStripMenuItem
        '
        Me.DetailsToolStripMenuItem.Checked = True
        Me.DetailsToolStripMenuItem.CheckOnClick = True
        Me.DetailsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.DetailsToolStripMenuItem.Name = "DetailsToolStripMenuItem"
        Me.DetailsToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.DetailsToolStripMenuItem.Text = "Details"
        '
        'SmallIconToolStripMenuItem
        '
        Me.SmallIconToolStripMenuItem.CheckOnClick = True
        Me.SmallIconToolStripMenuItem.Name = "SmallIconToolStripMenuItem"
        Me.SmallIconToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.SmallIconToolStripMenuItem.Text = "Small Icon"
        '
        'ListToolStripMenuItem
        '
        Me.ListToolStripMenuItem.CheckOnClick = True
        Me.ListToolStripMenuItem.Name = "ListToolStripMenuItem"
        Me.ListToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.ListToolStripMenuItem.Text = "List"
        '
        'TileToolStripMenuItem
        '
        Me.TileToolStripMenuItem.CheckOnClick = True
        Me.TileToolStripMenuItem.Name = "TileToolStripMenuItem"
        Me.TileToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.TileToolStripMenuItem.Text = "Tile"
        '
        'SortByToolStripMenuItem
        '
        Me.SortByToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NameToolStripMenuItem, Me.VolumeLabelToolStripMenuItem, Me.TypeToolStripMenuItem, Me.SizeToolStripMenuItem, Me.LastWrittenTimeToolStripMenuItem, Me.AttributesToolStripMenuItem})
        Me.SortByToolStripMenuItem.Name = "SortByToolStripMenuItem"
        Me.SortByToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.SortByToolStripMenuItem.Text = "Sort By"
        '
        'NameToolStripMenuItem
        '
        Me.NameToolStripMenuItem.Name = "NameToolStripMenuItem"
        Me.NameToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.NameToolStripMenuItem.Text = "Name"
        '
        'VolumeLabelToolStripMenuItem
        '
        Me.VolumeLabelToolStripMenuItem.Name = "VolumeLabelToolStripMenuItem"
        Me.VolumeLabelToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.VolumeLabelToolStripMenuItem.Text = "Volume Label"
        '
        'TypeToolStripMenuItem
        '
        Me.TypeToolStripMenuItem.Name = "TypeToolStripMenuItem"
        Me.TypeToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.TypeToolStripMenuItem.Text = "Type"
        '
        'SizeToolStripMenuItem
        '
        Me.SizeToolStripMenuItem.Name = "SizeToolStripMenuItem"
        Me.SizeToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.SizeToolStripMenuItem.Text = "Size"
        '
        'LastWrittenTimeToolStripMenuItem
        '
        Me.LastWrittenTimeToolStripMenuItem.Name = "LastWrittenTimeToolStripMenuItem"
        Me.LastWrittenTimeToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.LastWrittenTimeToolStripMenuItem.Text = "Last Written Time"
        '
        'AttributesToolStripMenuItem
        '
        Me.AttributesToolStripMenuItem.Name = "AttributesToolStripMenuItem"
        Me.AttributesToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.AttributesToolStripMenuItem.Text = "Attributes"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 33.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 144.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 58.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.BtnBack, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtPath, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ComboBox1, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnSettings, 3, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1020, 32)
        Me.TableLayoutPanel1.TabIndex = 9
        '
        'BtnBack
        '
        Me.BtnBack.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnBack.BackgroundImage = CType(resources.GetObject("BtnBack.BackgroundImage"), System.Drawing.Image)
        Me.BtnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BtnBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BtnBack.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBack.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnBack.Location = New System.Drawing.Point(4, 4)
        Me.BtnBack.Name = "BtnBack"
        Me.BtnBack.Size = New System.Drawing.Size(27, 24)
        Me.BtnBack.TabIndex = 14
        Me.BtnBack.UseVisualStyleBackColor = True
        '
        'txtPath
        '
        Me.txtPath.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPath.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.txtPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPath.ForeColor = System.Drawing.Color.Silver
        Me.txtPath.Location = New System.Drawing.Point(38, 5)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.Size = New System.Drawing.Size(774, 22)
        Me.txtPath.TabIndex = 11
        '
        'ComboBox1
        '
        Me.ComboBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.ComboBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.ForeColor = System.Drawing.Color.White
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Large Icon", "Details", "Small Icon", "List", "Tile"})
        Me.ComboBox1.Location = New System.Drawing.Point(819, 4)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(138, 21)
        Me.ComboBox1.TabIndex = 12
        '
        'btnSettings
        '
        Me.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSettings.Location = New System.Drawing.Point(964, 4)
        Me.btnSettings.Name = "btnSettings"
        Me.btnSettings.Size = New System.Drawing.Size(21, 23)
        Me.btnSettings.TabIndex = 13
        Me.btnSettings.Text = "Q"
        Me.btnSettings.UseVisualStyleBackColor = True
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(227, 6)
        '
        'iExplorer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1020, 678)
        Me.Controls.Add(Me.list)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.ForeColor = System.Drawing.Color.Silver
        Me.MinimumSize = New System.Drawing.Size(700, 420)
        Me.Name = "iExplorer"
        Me.Text = "Form1"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents list As System.Windows.Forms.ListView
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents txtPath As System.Windows.Forms.TextBox
    Friend WithEvents lblDateModified As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblSize As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel4 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents lblTotalFD As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel5 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblTotalSelected As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents btnSettings As System.Windows.Forms.Button
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ShowHiddenFilesMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowIconsMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RenameToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MoveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExploreWithExplorerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowPropertiesWToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowProperitesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShortcutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelectAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ChangeIconToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewByToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SortByToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CreateNewFolderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CreateANewFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EjectToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RefreshToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BtnBack As System.Windows.Forms.Button
    Friend WithEvents LargeIconToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DetailsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SmallIconToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NameToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VolumeLabelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TypeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SizeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LastWrittenTimeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AttributesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
