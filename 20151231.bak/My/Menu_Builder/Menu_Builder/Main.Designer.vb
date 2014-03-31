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
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.SelectedControl = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.FileMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ButtonsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LabelsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LinkLabelsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.AllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.UnselectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PropertiesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FormPropertiesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InsertToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ButttonToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LabelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LinkLabelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FormatMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.ArrangeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VerticallyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HorizontallyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WindowsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WinKeeper = New System.Windows.Forms.ToolStrip()
        Me.PropertiesDisplay = New System.Windows.Forms.ToolStripButton()
        Me.ToolboxDisplay = New System.Windows.Forms.ToolStripButton()
        Me.ToolBox = New System.Windows.Forms.ToolStrip()
        Me.ToolButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolLabel = New System.Windows.Forms.ToolStripButton()
        Me.ToolLinkLabel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolArrow = New System.Windows.Forms.ToolStripButton()
        Me.ControlNameFind = New System.Windows.Forms.Timer(Me.components)
        Me.StatusStrip.SuspendLayout()
        Me.MenuStrip.SuspendLayout()
        Me.WinKeeper.SuspendLayout()
        Me.ToolBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip
        '
        Me.StatusStrip.BackColor = System.Drawing.SystemColors.Control
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LocXY, Me.dvd1, Me.ControlSize, Me.ToolStripStatusLabel1, Me.SelectedControl})
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
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(22, 17)
        Me.ToolStripStatusLabel1.Text = "  |  "
        '
        'SelectedControl
        '
        Me.SelectedControl.Name = "SelectedControl"
        Me.SelectedControl.Size = New System.Drawing.Size(56, 17)
        Me.SelectedControl.Text = "#######"
        '
        'MenuStrip
        '
        Me.MenuStrip.BackColor = System.Drawing.SystemColors.Control
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileMenu, Me.EditMenu, Me.ViewToolStripMenuItem, Me.InsertToolStripMenuItem, Me.FormatMenu, Me.WindowsToolStripMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(984, 24)
        Me.MenuStrip.TabIndex = 6
        Me.MenuStrip.Text = "MenuStrip"
        '
        'FileMenu
        '
        Me.FileMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.FileMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.CloseToolStripMenuItem, Me.ToolStripSeparator5, Me.ExitToolStripMenuItem})
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
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.NewToolStripMenuItem.Text = "&New"
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.CloseToolStripMenuItem.Text = "Close"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(138, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'EditMenu
        '
        Me.EditMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.EditMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SelectAllToolStripMenuItem, Me.RemoveAllToolStripMenuItem, Me.ToolStripSeparator2, Me.UnselectAllToolStripMenuItem})
        Me.EditMenu.Name = "EditMenu"
        Me.EditMenu.Size = New System.Drawing.Size(39, 20)
        Me.EditMenu.Text = "&Edit"
        '
        'SelectAllToolStripMenuItem
        '
        Me.SelectAllToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ButtonsToolStripMenuItem, Me.LabelsToolStripMenuItem, Me.LinkLabelsToolStripMenuItem, Me.ToolStripSeparator10, Me.AllToolStripMenuItem})
        Me.SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem"
        Me.SelectAllToolStripMenuItem.ShowShortcutKeys = False
        Me.SelectAllToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.SelectAllToolStripMenuItem.Text = "Select &All"
        '
        'ButtonsToolStripMenuItem
        '
        Me.ButtonsToolStripMenuItem.Name = "ButtonsToolStripMenuItem"
        Me.ButtonsToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
                    Or System.Windows.Forms.Keys.B), System.Windows.Forms.Keys)
        Me.ButtonsToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.ButtonsToolStripMenuItem.Text = "Buttons"
        '
        'LabelsToolStripMenuItem
        '
        Me.LabelsToolStripMenuItem.Name = "LabelsToolStripMenuItem"
        Me.LabelsToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
                    Or System.Windows.Forms.Keys.L), System.Windows.Forms.Keys)
        Me.LabelsToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.LabelsToolStripMenuItem.Text = "Labels"
        '
        'LinkLabelsToolStripMenuItem
        '
        Me.LinkLabelsToolStripMenuItem.Name = "LinkLabelsToolStripMenuItem"
        Me.LinkLabelsToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
                    Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.LinkLabelsToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.LinkLabelsToolStripMenuItem.Text = "LinkLabels"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(201, 6)
        '
        'AllToolStripMenuItem
        '
        Me.AllToolStripMenuItem.Name = "AllToolStripMenuItem"
        Me.AllToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.AllToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.AllToolStripMenuItem.Text = "All"
        '
        'RemoveAllToolStripMenuItem
        '
        Me.RemoveAllToolStripMenuItem.Name = "RemoveAllToolStripMenuItem"
        Me.RemoveAllToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.RemoveAllToolStripMenuItem.Text = "&Remove All"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(133, 6)
        '
        'UnselectAllToolStripMenuItem
        '
        Me.UnselectAllToolStripMenuItem.Name = "UnselectAllToolStripMenuItem"
        Me.UnselectAllToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.UnselectAllToolStripMenuItem.Text = "&Unselect All"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PropertiesToolStripMenuItem, Me.FormPropertiesToolStripMenuItem, Me.ToolStripSeparator6, Me.ExportToolStripMenuItem})
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.ViewToolStripMenuItem.Text = "&View"
        '
        'PropertiesToolStripMenuItem
        '
        Me.PropertiesToolStripMenuItem.Name = "PropertiesToolStripMenuItem"
        Me.PropertiesToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.PropertiesToolStripMenuItem.Text = "&Properties"
        '
        'FormPropertiesToolStripMenuItem
        '
        Me.FormPropertiesToolStripMenuItem.Name = "FormPropertiesToolStripMenuItem"
        Me.FormPropertiesToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.FormPropertiesToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.FormPropertiesToolStripMenuItem.Text = "Fo&rm Properties"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(196, 6)
        '
        'ExportToolStripMenuItem
        '
        Me.ExportToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black
        Me.ExportToolStripMenuItem.Name = "ExportToolStripMenuItem"
        Me.ExportToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.ExportToolStripMenuItem.Text = "Export Pre&view"
        '
        'InsertToolStripMenuItem
        '
        Me.InsertToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ButttonToolStripMenuItem, Me.LabelToolStripMenuItem, Me.LinkLabelToolStripMenuItem})
        Me.InsertToolStripMenuItem.Name = "InsertToolStripMenuItem"
        Me.InsertToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
        Me.InsertToolStripMenuItem.Text = "&Insert"
        '
        'ButttonToolStripMenuItem
        '
        Me.ButttonToolStripMenuItem.Name = "ButttonToolStripMenuItem"
        Me.ButttonToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ButttonToolStripMenuItem.Text = "&Buttton"
        '
        'LabelToolStripMenuItem
        '
        Me.LabelToolStripMenuItem.Name = "LabelToolStripMenuItem"
        Me.LabelToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.LabelToolStripMenuItem.Text = "&Label"
        '
        'LinkLabelToolStripMenuItem
        '
        Me.LinkLabelToolStripMenuItem.Name = "LinkLabelToolStripMenuItem"
        Me.LinkLabelToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.LinkLabelToolStripMenuItem.Text = "L&ink Label"
        '
        'FormatMenu
        '
        Me.FormatMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.FormatMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArrangeToolStripMenuItem})
        Me.FormatMenu.Name = "FormatMenu"
        Me.FormatMenu.Size = New System.Drawing.Size(57, 20)
        Me.FormatMenu.Text = "&Format"
        '
        'ArrangeToolStripMenuItem
        '
        Me.ArrangeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.VerticallyToolStripMenuItem, Me.HorizontallyToolStripMenuItem})
        Me.ArrangeToolStripMenuItem.Name = "ArrangeToolStripMenuItem"
        Me.ArrangeToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ArrangeToolStripMenuItem.Text = "Arrange"
        '
        'VerticallyToolStripMenuItem
        '
        Me.VerticallyToolStripMenuItem.Name = "VerticallyToolStripMenuItem"
        Me.VerticallyToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
        Me.VerticallyToolStripMenuItem.Text = "&Vertically"
        '
        'HorizontallyToolStripMenuItem
        '
        Me.HorizontallyToolStripMenuItem.Name = "HorizontallyToolStripMenuItem"
        Me.HorizontallyToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
        Me.HorizontallyToolStripMenuItem.Text = "&Horizontally"
        '
        'WindowsToolStripMenuItem
        '
        Me.WindowsToolStripMenuItem.Name = "WindowsToolStripMenuItem"
        Me.WindowsToolStripMenuItem.Size = New System.Drawing.Size(68, 20)
        Me.WindowsToolStripMenuItem.Text = "Windows"
        '
        'WinKeeper
        '
        Me.WinKeeper.CanOverflow = False
        Me.WinKeeper.Dock = System.Windows.Forms.DockStyle.Right
        Me.WinKeeper.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.WinKeeper.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PropertiesDisplay, Me.ToolboxDisplay})
        Me.WinKeeper.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow
        Me.WinKeeper.Location = New System.Drawing.Point(960, 24)
        Me.WinKeeper.Name = "WinKeeper"
        Me.WinKeeper.Size = New System.Drawing.Size(24, 666)
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
        Me.ToolBox.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolButton, Me.ToolLabel, Me.ToolLinkLabel, Me.ToolStripSeparator9, Me.ToolArrow})
        Me.ToolBox.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow
        Me.ToolBox.Location = New System.Drawing.Point(862, 24)
        Me.ToolBox.Name = "ToolBox"
        Me.ToolBox.Size = New System.Drawing.Size(98, 666)
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
        'ToolArrow
        '
        Me.ToolArrow.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolArrow.Image = CType(resources.GetObject("ToolArrow.Image"), System.Drawing.Image)
        Me.ToolArrow.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolArrow.Name = "ToolArrow"
        Me.ToolArrow.Size = New System.Drawing.Size(96, 20)
        Me.ToolArrow.Text = "Arrow"
        '
        'ControlNameFind
        '
        Me.ControlNameFind.Enabled = True
        Me.ControlNameFind.Interval = 300
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 712)
        Me.Controls.Add(Me.ToolBox)
        Me.Controls.Add(Me.WinKeeper)
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.StatusStrip)
        Me.IsMdiContainer = True
        Me.Name = "Main"
        Me.Text = "close err"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.WinKeeper.ResumeLayout(False)
        Me.WinKeeper.PerformLayout()
        Me.ToolBox.ResumeLayout(False)
        Me.ToolBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents FileMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelectAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ControlSize As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents WinKeeper As System.Windows.Forms.ToolStrip
    Friend WithEvents PropertiesDisplay As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolboxDisplay As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolBox As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ControlNameFind As System.Windows.Forms.Timer
    Friend WithEvents ToolLabel As System.Windows.Forms.ToolStripButton
    Friend WithEvents LocXY As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolLinkLabel As System.Windows.Forms.ToolStripButton
    Friend WithEvents dvd1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SelectedControl As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolArrow As System.Windows.Forms.ToolStripButton
    Friend WithEvents FormatMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ArrangeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VerticallyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HorizontallyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RemoveAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ButtonsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LabelsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LinkLabelsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PropertiesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InsertToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FormPropertiesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ButttonToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LabelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LinkLabelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UnselectAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WindowsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
