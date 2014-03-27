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
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.LocXY = New System.Windows.Forms.ToolStripStatusLabel()
        Me.dvd1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ControlSize = New System.Windows.Forms.ToolStripStatusLabel()
        Me.dvd2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ControlsAvailable = New System.Windows.Forms.ToolStripStatusLabel()
        Me.dvd3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.CntrlAdded_Selected = New System.Windows.Forms.ToolStripDropDownButton()
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.FileMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.PrintPreviewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.UndoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RedoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.CutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.SelectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolBarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusBarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.JToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WindowsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ArrangeWindowsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.DesignWindowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CodeWindowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IndexToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SearchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolBar = New System.Windows.Forms.ToolStrip()
        Me.CntrlArrow = New System.Windows.Forms.ToolStripButton()
        Me.ControlRemove = New System.Windows.Forms.ToolStripButton()
        Me.ControlRemoveAll = New System.Windows.Forms.ToolStripButton()
        Me.ControlLocChange = New System.Windows.Forms.ToolStripButton()
        Me.ControlSzChange = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ShowFrmP = New System.Windows.Forms.ToolStripButton()
        Me.WinKeeper = New System.Windows.Forms.ToolStrip()
        Me.PropertiesDisplay = New System.Windows.Forms.ToolStripButton()
        Me.ToolboxDisplay = New System.Windows.Forms.ToolStripButton()
        Me.ToolBox = New System.Windows.Forms.ToolStrip()
        Me.ToolButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolLabel = New System.Windows.Forms.ToolStripButton()
        Me.ToolLinkLabel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnMultiAdd = New System.Windows.Forms.ToolStripButton()
        Me.ControlNameFind = New System.Windows.Forms.Timer(Me.components)
        Me.PropertiesBox = New System.Windows.Forms.FlowLayoutPanel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.PanelArrange = New System.Windows.Forms.Panel()
        Me.btnArrangeThem = New System.Windows.Forms.Button()
        Me.btnCntrlReload = New System.Windows.Forms.Button()
        Me.lblMainCntrl = New System.Windows.Forms.Label()
        Me.CbxMainCntrl = New System.Windows.Forms.ComboBox()
        Me.lblspecified = New System.Windows.Forms.Label()
        Me.lblAll = New System.Windows.Forms.Label()
        Me.btnRemoveAll = New System.Windows.Forms.Button()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.btnAddAll = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.ListSpecified = New System.Windows.Forms.ListBox()
        Me.RadioButtonv = New System.Windows.Forms.RadioButton()
        Me.RadioButtonh = New System.Windows.Forms.RadioButton()
        Me.ListAll = New System.Windows.Forms.ListBox()
        Me.StatusStrip.SuspendLayout()
        Me.MenuStrip.SuspendLayout()
        Me.ToolBar.SuspendLayout()
        Me.WinKeeper.SuspendLayout()
        Me.ToolBox.SuspendLayout()
        Me.PropertiesBox.SuspendLayout()
        Me.PanelArrange.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LocXY, Me.dvd1, Me.ControlSize, Me.dvd2, Me.ControlsAvailable, Me.dvd3, Me.CntrlAdded_Selected})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 690)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(984, 22)
        Me.StatusStrip.TabIndex = 1
        Me.StatusStrip.Text = "StatusStrip1"
        '
        'LocXY
        '
        Me.LocXY.AutoSize = False
        Me.LocXY.Name = "LocXY"
        Me.LocXY.Size = New System.Drawing.Size(100, 17)
        '
        'dvd1
        '
        Me.dvd1.Name = "dvd1"
        Me.dvd1.Size = New System.Drawing.Size(22, 17)
        Me.dvd1.Text = "  |  "
        '
        'ControlSize
        '
        Me.ControlSize.AutoSize = False
        Me.ControlSize.Name = "ControlSize"
        Me.ControlSize.Size = New System.Drawing.Size(140, 17)
        '
        'dvd2
        '
        Me.dvd2.Name = "dvd2"
        Me.dvd2.Size = New System.Drawing.Size(22, 17)
        Me.dvd2.Text = "  |  "
        '
        'ControlsAvailable
        '
        Me.ControlsAvailable.AutoSize = False
        Me.ControlsAvailable.Name = "ControlsAvailable"
        Me.ControlsAvailable.Size = New System.Drawing.Size(210, 17)
        '
        'dvd3
        '
        Me.dvd3.Name = "dvd3"
        Me.dvd3.Size = New System.Drawing.Size(22, 17)
        Me.dvd3.Text = "  |  "
        '
        'CntrlAdded_Selected
        '
        Me.CntrlAdded_Selected.Image = CType(resources.GetObject("CntrlAdded_Selected.Image"), System.Drawing.Image)
        Me.CntrlAdded_Selected.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CntrlAdded_Selected.Name = "CntrlAdded_Selected"
        Me.CntrlAdded_Selected.Size = New System.Drawing.Size(29, 20)
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileMenu, Me.EditMenu, Me.ViewMenu, Me.ToolsMenu, Me.WindowsToolStripMenuItem, Me.HelpMenu})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(984, 24)
        Me.MenuStrip.TabIndex = 6
        Me.MenuStrip.Text = "MenuStrip"
        '
        'FileMenu
        '
        Me.FileMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.OpenToolStripMenuItem, Me.ToolStripSeparator3, Me.SaveToolStripMenuItem, Me.SaveAsToolStripMenuItem, Me.ToolStripSeparator4, Me.PrintPreviewToolStripMenuItem, Me.ToolStripSeparator5, Me.ExitToolStripMenuItem})
        Me.FileMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder
        Me.FileMenu.Name = "FileMenu"
        Me.FileMenu.Size = New System.Drawing.Size(37, 20)
        Me.FileMenu.Text = "&File"
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Image = CType(resources.GetObject("NewToolStripMenuItem.Image"), System.Drawing.Image)
        Me.NewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.NewToolStripMenuItem.Text = "&New"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Image = CType(resources.GetObject("OpenToolStripMenuItem.Image"), System.Drawing.Image)
        Me.OpenToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.OpenToolStripMenuItem.Text = "&Open"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(143, 6)
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Image = CType(resources.GetObject("SaveToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SaveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.SaveToolStripMenuItem.Text = "&Save"
        '
        'SaveAsToolStripMenuItem
        '
        Me.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem"
        Me.SaveAsToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.SaveAsToolStripMenuItem.Text = "Save &As"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(143, 6)
        '
        'PrintPreviewToolStripMenuItem
        '
        Me.PrintPreviewToolStripMenuItem.Image = CType(resources.GetObject("PrintPreviewToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PrintPreviewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black
        Me.PrintPreviewToolStripMenuItem.Name = "PrintPreviewToolStripMenuItem"
        Me.PrintPreviewToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.PrintPreviewToolStripMenuItem.Text = "Print Pre&view"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(143, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'EditMenu
        '
        Me.EditMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UndoToolStripMenuItem, Me.RedoToolStripMenuItem, Me.ToolStripSeparator6, Me.CutToolStripMenuItem, Me.CopyToolStripMenuItem, Me.PasteToolStripMenuItem, Me.ToolStripSeparator7, Me.SelectAllToolStripMenuItem})
        Me.EditMenu.Name = "EditMenu"
        Me.EditMenu.Size = New System.Drawing.Size(39, 20)
        Me.EditMenu.Text = "&Edit"
        '
        'UndoToolStripMenuItem
        '
        Me.UndoToolStripMenuItem.Image = CType(resources.GetObject("UndoToolStripMenuItem.Image"), System.Drawing.Image)
        Me.UndoToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black
        Me.UndoToolStripMenuItem.Name = "UndoToolStripMenuItem"
        Me.UndoToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Z), System.Windows.Forms.Keys)
        Me.UndoToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.UndoToolStripMenuItem.Text = "&Undo"
        '
        'RedoToolStripMenuItem
        '
        Me.RedoToolStripMenuItem.Image = CType(resources.GetObject("RedoToolStripMenuItem.Image"), System.Drawing.Image)
        Me.RedoToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black
        Me.RedoToolStripMenuItem.Name = "RedoToolStripMenuItem"
        Me.RedoToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Y), System.Windows.Forms.Keys)
        Me.RedoToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.RedoToolStripMenuItem.Text = "&Redo"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(161, 6)
        '
        'CutToolStripMenuItem
        '
        Me.CutToolStripMenuItem.Image = CType(resources.GetObject("CutToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black
        Me.CutToolStripMenuItem.Name = "CutToolStripMenuItem"
        Me.CutToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.CutToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.CutToolStripMenuItem.Text = "Cu&t"
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Image = CType(resources.GetObject("CopyToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CopyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.CopyToolStripMenuItem.Text = "&Copy"
        '
        'PasteToolStripMenuItem
        '
        Me.PasteToolStripMenuItem.Image = CType(resources.GetObject("PasteToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PasteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black
        Me.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem"
        Me.PasteToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
        Me.PasteToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.PasteToolStripMenuItem.Text = "&Paste"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(161, 6)
        '
        'SelectAllToolStripMenuItem
        '
        Me.SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem"
        Me.SelectAllToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.SelectAllToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.SelectAllToolStripMenuItem.Text = "Select &All"
        '
        'ViewMenu
        '
        Me.ViewMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolBarToolStripMenuItem, Me.StatusBarToolStripMenuItem})
        Me.ViewMenu.Name = "ViewMenu"
        Me.ViewMenu.Size = New System.Drawing.Size(44, 20)
        Me.ViewMenu.Text = "&View"
        '
        'ToolBarToolStripMenuItem
        '
        Me.ToolBarToolStripMenuItem.Checked = True
        Me.ToolBarToolStripMenuItem.CheckOnClick = True
        Me.ToolBarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ToolBarToolStripMenuItem.Name = "ToolBarToolStripMenuItem"
        Me.ToolBarToolStripMenuItem.Size = New System.Drawing.Size(126, 22)
        Me.ToolBarToolStripMenuItem.Text = "&Toolbar"
        '
        'StatusBarToolStripMenuItem
        '
        Me.StatusBarToolStripMenuItem.Checked = True
        Me.StatusBarToolStripMenuItem.CheckOnClick = True
        Me.StatusBarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.StatusBarToolStripMenuItem.Name = "StatusBarToolStripMenuItem"
        Me.StatusBarToolStripMenuItem.Size = New System.Drawing.Size(126, 22)
        Me.StatusBarToolStripMenuItem.Text = "&Status Bar"
        '
        'ToolsMenu
        '
        Me.ToolsMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OptionsToolStripMenuItem, Me.JToolStripMenuItem})
        Me.ToolsMenu.Name = "ToolsMenu"
        Me.ToolsMenu.Size = New System.Drawing.Size(48, 20)
        Me.ToolsMenu.Text = "&Tools"
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.OptionsToolStripMenuItem.Text = "&Options"
        '
        'JToolStripMenuItem
        '
        Me.JToolStripMenuItem.CheckOnClick = True
        Me.JToolStripMenuItem.Name = "JToolStripMenuItem"
        Me.JToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.JToolStripMenuItem.Text = "j"
        '
        'WindowsToolStripMenuItem
        '
        Me.WindowsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArrangeWindowsToolStripMenuItem, Me.ShowStripMenuItem, Me.CloseAllToolStripMenuItem, Me.ToolStripSeparator1, Me.DesignWindowToolStripMenuItem, Me.CodeWindowToolStripMenuItem})
        Me.WindowsToolStripMenuItem.Name = "WindowsToolStripMenuItem"
        Me.WindowsToolStripMenuItem.Size = New System.Drawing.Size(68, 20)
        Me.WindowsToolStripMenuItem.Text = "&Windows"
        '
        'ArrangeWindowsToolStripMenuItem
        '
        Me.ArrangeWindowsToolStripMenuItem.Name = "ArrangeWindowsToolStripMenuItem"
        Me.ArrangeWindowsToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.ArrangeWindowsToolStripMenuItem.Text = "&Arrange Windows"
        '
        'ShowStripMenuItem
        '
        Me.ShowStripMenuItem.Name = "ShowStripMenuItem"
        Me.ShowStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.ShowStripMenuItem.Text = "&Show all"
        '
        'CloseAllToolStripMenuItem
        '
        Me.CloseAllToolStripMenuItem.Name = "CloseAllToolStripMenuItem"
        Me.CloseAllToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.CloseAllToolStripMenuItem.Text = "&Close all"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(165, 6)
        '
        'DesignWindowToolStripMenuItem
        '
        Me.DesignWindowToolStripMenuItem.Checked = True
        Me.DesignWindowToolStripMenuItem.CheckOnClick = True
        Me.DesignWindowToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.DesignWindowToolStripMenuItem.Name = "DesignWindowToolStripMenuItem"
        Me.DesignWindowToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.DesignWindowToolStripMenuItem.Text = "&Design Window"
        '
        'CodeWindowToolStripMenuItem
        '
        Me.CodeWindowToolStripMenuItem.Checked = True
        Me.CodeWindowToolStripMenuItem.CheckOnClick = True
        Me.CodeWindowToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CodeWindowToolStripMenuItem.Name = "CodeWindowToolStripMenuItem"
        Me.CodeWindowToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.CodeWindowToolStripMenuItem.Text = "&Code Window"
        '
        'HelpMenu
        '
        Me.HelpMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ContentsToolStripMenuItem, Me.IndexToolStripMenuItem, Me.SearchToolStripMenuItem, Me.ToolStripSeparator8, Me.AboutToolStripMenuItem})
        Me.HelpMenu.Name = "HelpMenu"
        Me.HelpMenu.Size = New System.Drawing.Size(44, 20)
        Me.HelpMenu.Text = "&Help"
        '
        'ContentsToolStripMenuItem
        '
        Me.ContentsToolStripMenuItem.Name = "ContentsToolStripMenuItem"
        Me.ContentsToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F1), System.Windows.Forms.Keys)
        Me.ContentsToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.ContentsToolStripMenuItem.Text = "&Contents"
        '
        'IndexToolStripMenuItem
        '
        Me.IndexToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black
        Me.IndexToolStripMenuItem.Name = "IndexToolStripMenuItem"
        Me.IndexToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.IndexToolStripMenuItem.Text = "&Index"
        '
        'SearchToolStripMenuItem
        '
        Me.SearchToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black
        Me.SearchToolStripMenuItem.Name = "SearchToolStripMenuItem"
        Me.SearchToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.SearchToolStripMenuItem.Text = "&Search"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(165, 6)
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.AboutToolStripMenuItem.Text = "&About ..."
        '
        'ToolBar
        '
        Me.ToolBar.AutoSize = False
        Me.ToolBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CntrlArrow, Me.ControlRemove, Me.ControlRemoveAll, Me.ControlLocChange, Me.ControlSzChange, Me.ToolStripSeparator2, Me.ShowFrmP})
        Me.ToolBar.Location = New System.Drawing.Point(0, 24)
        Me.ToolBar.Name = "ToolBar"
        Me.ToolBar.Size = New System.Drawing.Size(984, 24)
        Me.ToolBar.TabIndex = 7
        Me.ToolBar.Text = "ToolStrip1"
        '
        'CntrlArrow
        '
        Me.CntrlArrow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CntrlArrow.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CntrlArrow.Name = "CntrlArrow"
        Me.CntrlArrow.Size = New System.Drawing.Size(23, 21)
        Me.CntrlArrow.Text = "ToolStripButton1"
        '
        'ControlRemove
        '
        Me.ControlRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ControlRemove.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ControlRemove.Name = "ControlRemove"
        Me.ControlRemove.Size = New System.Drawing.Size(23, 21)
        '
        'ControlRemoveAll
        '
        Me.ControlRemoveAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ControlRemoveAll.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ControlRemoveAll.Name = "ControlRemoveAll"
        Me.ControlRemoveAll.Size = New System.Drawing.Size(23, 21)
        Me.ControlRemoveAll.Text = "ToolStripButton1"
        '
        'ControlLocChange
        '
        Me.ControlLocChange.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ControlLocChange.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ControlLocChange.Name = "ControlLocChange"
        Me.ControlLocChange.Size = New System.Drawing.Size(23, 21)
        '
        'ControlSzChange
        '
        Me.ControlSzChange.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ControlSzChange.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ControlSzChange.Name = "ControlSzChange"
        Me.ControlSzChange.Size = New System.Drawing.Size(23, 21)
        Me.ControlSzChange.Text = "ToolStripButton1"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 24)
        '
        'ShowFrmP
        '
        Me.ShowFrmP.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ShowFrmP.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ShowFrmP.Name = "ShowFrmP"
        Me.ShowFrmP.Size = New System.Drawing.Size(23, 21)
        Me.ShowFrmP.Text = "ToolStripButton1"
        '
        'WinKeeper
        '
        Me.WinKeeper.CanOverflow = False
        Me.WinKeeper.Dock = System.Windows.Forms.DockStyle.Right
        Me.WinKeeper.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.WinKeeper.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PropertiesDisplay, Me.ToolboxDisplay})
        Me.WinKeeper.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow
        Me.WinKeeper.Location = New System.Drawing.Point(960, 48)
        Me.WinKeeper.Name = "WinKeeper"
        Me.WinKeeper.Size = New System.Drawing.Size(24, 642)
        Me.WinKeeper.TabIndex = 14
        Me.WinKeeper.TextDirection = System.Windows.Forms.ToolStripTextDirection.Vertical90
        '
        'PropertiesDisplay
        '
        Me.PropertiesDisplay.Image = CType(resources.GetObject("PropertiesDisplay.Image"), System.Drawing.Image)
        Me.PropertiesDisplay.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PropertiesDisplay.Name = "PropertiesDisplay"
        Me.PropertiesDisplay.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never
        Me.PropertiesDisplay.Size = New System.Drawing.Size(21, 80)
        Me.PropertiesDisplay.Text = "Properties"
        Me.PropertiesDisplay.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolboxDisplay
        '
        Me.ToolboxDisplay.Image = CType(resources.GetObject("ToolboxDisplay.Image"), System.Drawing.Image)
        Me.ToolboxDisplay.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolboxDisplay.Name = "ToolboxDisplay"
        Me.ToolboxDisplay.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never
        Me.ToolboxDisplay.Size = New System.Drawing.Size(21, 70)
        Me.ToolboxDisplay.Text = "ToolBox"
        Me.ToolboxDisplay.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolBox
        '
        Me.ToolBox.AutoSize = False
        Me.ToolBox.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ToolBox.Dock = System.Windows.Forms.DockStyle.Right
        Me.ToolBox.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolBox.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolButton, Me.ToolLabel, Me.ToolLinkLabel, Me.ToolStripSeparator9, Me.btnMultiAdd})
        Me.ToolBox.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow
        Me.ToolBox.Location = New System.Drawing.Point(702, 48)
        Me.ToolBox.Name = "ToolBox"
        Me.ToolBox.Size = New System.Drawing.Size(98, 642)
        Me.ToolBox.TabIndex = 23
        Me.ToolBox.Visible = False
        '
        'ToolButton
        '
        Me.ToolButton.Image = CType(resources.GetObject("ToolButton.Image"), System.Drawing.Image)
        Me.ToolButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolButton.Name = "ToolButton"
        Me.ToolButton.Size = New System.Drawing.Size(96, 20)
        Me.ToolButton.Text = " Button"
        '
        'ToolLabel
        '
        Me.ToolLabel.Image = CType(resources.GetObject("ToolLabel.Image"), System.Drawing.Image)
        Me.ToolLabel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolLabel.Name = "ToolLabel"
        Me.ToolLabel.Size = New System.Drawing.Size(96, 20)
        Me.ToolLabel.Text = " Label"
        '
        'ToolLinkLabel
        '
        Me.ToolLinkLabel.Image = CType(resources.GetObject("ToolLinkLabel.Image"), System.Drawing.Image)
        Me.ToolLinkLabel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolLinkLabel.Name = "ToolLinkLabel"
        Me.ToolLinkLabel.Size = New System.Drawing.Size(96, 20)
        Me.ToolLinkLabel.Text = "Link Label"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(96, 6)
        '
        'btnMultiAdd
        '
        Me.btnMultiAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnMultiAdd.Image = CType(resources.GetObject("btnMultiAdd.Image"), System.Drawing.Image)
        Me.btnMultiAdd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnMultiAdd.Name = "btnMultiAdd"
        Me.btnMultiAdd.Size = New System.Drawing.Size(96, 19)
        Me.btnMultiAdd.Text = "Multi add-False"
        '
        'ControlNameFind
        '
        Me.ControlNameFind.Enabled = True
        Me.ControlNameFind.Interval = 1500
        '
        'PropertiesBox
        '
        Me.PropertiesBox.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.PropertiesBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PropertiesBox.Controls.Add(Me.Button1)
        Me.PropertiesBox.Dock = System.Windows.Forms.DockStyle.Right
        Me.PropertiesBox.Location = New System.Drawing.Point(685, 48)
        Me.PropertiesBox.Name = "PropertiesBox"
        Me.PropertiesBox.Size = New System.Drawing.Size(275, 642)
        Me.PropertiesBox.TabIndex = 17
        Me.PropertiesBox.Visible = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(3, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'PanelArrange
        '
        Me.PanelArrange.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelArrange.Controls.Add(Me.btnArrangeThem)
        Me.PanelArrange.Controls.Add(Me.btnCntrlReload)
        Me.PanelArrange.Controls.Add(Me.lblMainCntrl)
        Me.PanelArrange.Controls.Add(Me.CbxMainCntrl)
        Me.PanelArrange.Controls.Add(Me.lblspecified)
        Me.PanelArrange.Controls.Add(Me.lblAll)
        Me.PanelArrange.Controls.Add(Me.btnRemoveAll)
        Me.PanelArrange.Controls.Add(Me.btnRemove)
        Me.PanelArrange.Controls.Add(Me.btnAddAll)
        Me.PanelArrange.Controls.Add(Me.btnAdd)
        Me.PanelArrange.Controls.Add(Me.ListSpecified)
        Me.PanelArrange.Controls.Add(Me.RadioButtonv)
        Me.PanelArrange.Controls.Add(Me.RadioButtonh)
        Me.PanelArrange.Controls.Add(Me.ListAll)
        Me.PanelArrange.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelArrange.Location = New System.Drawing.Point(546, 48)
        Me.PanelArrange.Name = "PanelArrange"
        Me.PanelArrange.Size = New System.Drawing.Size(139, 642)
        Me.PanelArrange.TabIndex = 27
        Me.PanelArrange.Visible = False
        '
        'btnArrangeThem
        '
        Me.btnArrangeThem.Location = New System.Drawing.Point(30, 612)
        Me.btnArrangeThem.Name = "btnArrangeThem"
        Me.btnArrangeThem.Size = New System.Drawing.Size(93, 23)
        Me.btnArrangeThem.TabIndex = 28
        Me.btnArrangeThem.Text = "Arrange controls"
        Me.btnArrangeThem.UseVisualStyleBackColor = True
        '
        'btnCntrlReload
        '
        Me.btnCntrlReload.Location = New System.Drawing.Point(30, 583)
        Me.btnCntrlReload.Name = "btnCntrlReload"
        Me.btnCntrlReload.Size = New System.Drawing.Size(93, 23)
        Me.btnCntrlReload.TabIndex = 27
        Me.btnCntrlReload.Text = "Reload controls"
        Me.btnCntrlReload.UseVisualStyleBackColor = True
        '
        'lblMainCntrl
        '
        Me.lblMainCntrl.AutoSize = True
        Me.lblMainCntrl.Location = New System.Drawing.Point(8, 17)
        Me.lblMainCntrl.Name = "lblMainCntrl"
        Me.lblMainCntrl.Size = New System.Drawing.Size(109, 13)
        Me.lblMainCntrl.TabIndex = 26
        Me.lblMainCntrl.Text = "Independent Control :"
        '
        'CbxMainCntrl
        '
        Me.CbxMainCntrl.FormattingEnabled = True
        Me.CbxMainCntrl.Location = New System.Drawing.Point(12, 41)
        Me.CbxMainCntrl.Name = "CbxMainCntrl"
        Me.CbxMainCntrl.Size = New System.Drawing.Size(119, 21)
        Me.CbxMainCntrl.TabIndex = 25
        '
        'lblspecified
        '
        Me.lblspecified.AutoSize = True
        Me.lblspecified.Location = New System.Drawing.Point(23, 344)
        Me.lblspecified.Name = "lblspecified"
        Me.lblspecified.Size = New System.Drawing.Size(84, 13)
        Me.lblspecified.TabIndex = 24
        Me.lblspecified.Text = "To be Arranged:"
        '
        'lblAll
        '
        Me.lblAll.AutoSize = True
        Me.lblAll.Location = New System.Drawing.Point(27, 122)
        Me.lblAll.Name = "lblAll"
        Me.lblAll.Size = New System.Drawing.Size(62, 13)
        Me.lblAll.TabIndex = 23
        Me.lblAll.Text = "All Controls:"
        '
        'btnRemoveAll
        '
        Me.btnRemoveAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRemoveAll.Location = New System.Drawing.Point(71, 523)
        Me.btnRemoveAll.Name = "btnRemoveAll"
        Me.btnRemoveAll.Size = New System.Drawing.Size(39, 29)
        Me.btnRemoveAll.TabIndex = 22
        Me.btnRemoveAll.Text = "<<"
        Me.btnRemoveAll.UseVisualStyleBackColor = True
        '
        'btnRemove
        '
        Me.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRemove.Location = New System.Drawing.Point(26, 523)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(39, 29)
        Me.btnRemove.TabIndex = 21
        Me.btnRemove.Text = "<"
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'btnAddAll
        '
        Me.btnAddAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddAll.Location = New System.Drawing.Point(73, 301)
        Me.btnAddAll.Name = "btnAddAll"
        Me.btnAddAll.Size = New System.Drawing.Size(39, 29)
        Me.btnAddAll.TabIndex = 20
        Me.btnAddAll.Text = ">>"
        Me.btnAddAll.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.Location = New System.Drawing.Point(28, 301)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(39, 29)
        Me.btnAdd.TabIndex = 19
        Me.btnAdd.Text = ">"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'ListSpecified
        '
        Me.ListSpecified.FormattingEnabled = True
        Me.ListSpecified.HorizontalScrollbar = True
        Me.ListSpecified.Location = New System.Drawing.Point(26, 367)
        Me.ListSpecified.Name = "ListSpecified"
        Me.ListSpecified.Size = New System.Drawing.Size(100, 147)
        Me.ListSpecified.TabIndex = 18
        '
        'RadioButtonv
        '
        Me.RadioButtonv.AutoSize = True
        Me.RadioButtonv.Location = New System.Drawing.Point(17, 92)
        Me.RadioButtonv.Name = "RadioButtonv"
        Me.RadioButtonv.Size = New System.Drawing.Size(60, 17)
        Me.RadioButtonv.TabIndex = 17
        Me.RadioButtonv.Text = "Vertical"
        Me.RadioButtonv.UseVisualStyleBackColor = True
        '
        'RadioButtonh
        '
        Me.RadioButtonh.AutoSize = True
        Me.RadioButtonh.Checked = True
        Me.RadioButtonh.Location = New System.Drawing.Point(17, 68)
        Me.RadioButtonh.Name = "RadioButtonh"
        Me.RadioButtonh.Size = New System.Drawing.Size(72, 17)
        Me.RadioButtonh.TabIndex = 16
        Me.RadioButtonh.TabStop = True
        Me.RadioButtonh.Text = "Horizontal"
        Me.RadioButtonh.UseVisualStyleBackColor = True
        '
        'ListAll
        '
        Me.ListAll.ForeColor = System.Drawing.Color.Black
        Me.ListAll.FormattingEnabled = True
        Me.ListAll.HorizontalScrollbar = True
        Me.ListAll.Location = New System.Drawing.Point(26, 145)
        Me.ListAll.Name = "ListAll"
        Me.ListAll.Size = New System.Drawing.Size(100, 147)
        Me.ListAll.TabIndex = 15
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 712)
        Me.Controls.Add(Me.PanelArrange)
        Me.Controls.Add(Me.ToolBox)
        Me.Controls.Add(Me.PropertiesBox)
        Me.Controls.Add(Me.WinKeeper)
        Me.Controls.Add(Me.ToolBar)
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.StatusStrip)
        Me.IsMdiContainer = True
        Me.Name = "Main"
        Me.Text = "#Menu Builder"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.ToolBar.ResumeLayout(False)
        Me.ToolBar.PerformLayout()
        Me.WinKeeper.ResumeLayout(False)
        Me.WinKeeper.PerformLayout()
        Me.ToolBox.ResumeLayout(False)
        Me.ToolBox.PerformLayout()
        Me.PropertiesBox.ResumeLayout(False)
        Me.PanelArrange.ResumeLayout(False)
        Me.PanelArrange.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents FileMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveAsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PrintPreviewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UndoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RedoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PasteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SelectAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolBarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusBarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolsMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContentsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IndexToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SearchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolBar As System.Windows.Forms.ToolStrip
    Friend WithEvents WindowsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ArrangeWindowsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DesignWindowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CodeWindowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ControlSize As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents WinKeeper As System.Windows.Forms.ToolStrip
    Friend WithEvents PropertiesDisplay As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolboxDisplay As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolBox As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ControlNameFind As System.Windows.Forms.Timer
    Friend WithEvents ShowFrmP As System.Windows.Forms.ToolStripButton
    Friend WithEvents ControlRemove As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ControlRemoveAll As System.Windows.Forms.ToolStripButton
    Friend WithEvents ControlLocChange As System.Windows.Forms.ToolStripButton
    Friend WithEvents ControlSzChange As System.Windows.Forms.ToolStripButton
    Friend WithEvents CntrlArrow As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolLabel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ControlsAvailable As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents LocXY As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolLinkLabel As System.Windows.Forms.ToolStripButton
    Friend WithEvents dvd1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents dvd2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents dvd3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents PropertiesBox As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents JToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PanelArrange As System.Windows.Forms.Panel
    Friend WithEvents btnArrangeThem As System.Windows.Forms.Button
    Friend WithEvents btnCntrlReload As System.Windows.Forms.Button
    Friend WithEvents lblMainCntrl As System.Windows.Forms.Label
    Friend WithEvents CbxMainCntrl As System.Windows.Forms.ComboBox
    Friend WithEvents lblspecified As System.Windows.Forms.Label
    Friend WithEvents lblAll As System.Windows.Forms.Label
    Friend WithEvents btnRemoveAll As System.Windows.Forms.Button
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents btnAddAll As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents ListSpecified As System.Windows.Forms.ListBox
    Friend WithEvents RadioButtonv As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonh As System.Windows.Forms.RadioButton
    Friend WithEvents ListAll As System.Windows.Forms.ListBox
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnMultiAdd As System.Windows.Forms.ToolStripButton
    Friend WithEvents CntrlAdded_Selected As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents Button1 As System.Windows.Forms.Button

End Class
