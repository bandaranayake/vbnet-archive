' Copyright © Microsoft Corporation.  All Rights Reserved.
' This code released under the terms of the 
' Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)
'
Partial Public Class Ppan
    Inherits System.Windows.Forms.UserControl

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Sub New()
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()
    End Sub

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Ppan))
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.btnMinSize = New System.Windows.Forms.Button()
        Me.btnMaxSize = New System.Windows.Forms.Button()
        Me.btnLocation = New System.Windows.Forms.Button()
        Me.txtMinSizeH = New System.Windows.Forms.TextBox()
        Me.txtMaxSizeH = New System.Windows.Forms.TextBox()
        Me.txtSizeH = New System.Windows.Forms.TextBox()
        Me.txtLocationY = New System.Windows.Forms.TextBox()
        Me.cmbxDock = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtMinSizeW = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtMaxSizeW = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtSizeW = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtLocationX = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtTabIndex = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.chkTabStop = New System.Windows.Forms.CheckBox()
        Me.chkAutoSize = New System.Windows.Forms.CheckBox()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.ListAll = New System.Windows.Forms.ListBox()
        Me.cmbxBorderStyle = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkUseWaitCusor = New System.Windows.Forms.CheckBox()
        Me.btnCursor = New System.Windows.Forms.Button()
        Me.txtCursor = New System.Windows.Forms.TextBox()
        Me.chkCursorFrmFile = New System.Windows.Forms.CheckBox()
        Me.cmbxCursor = New System.Windows.Forms.ComboBox()
        Me.cmbxBImageLayout = New System.Windows.Forms.ComboBox()
        Me.btnBackgroundImage = New System.Windows.Forms.Button()
        Me.txtBackgroundImage = New System.Windows.Forms.TextBox()
        Me.btnBackColor = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TabCntrl = New System.Windows.Forms.TabControl()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.FontDialog1 = New System.Windows.Forms.FontDialog()
        Me.lblHead = New System.Windows.Forms.Label()
        Me.TabPage2.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabCntrl.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.btnMinSize)
        Me.TabPage2.Controls.Add(Me.btnMaxSize)
        Me.TabPage2.Controls.Add(Me.btnLocation)
        Me.TabPage2.Controls.Add(Me.txtMinSizeH)
        Me.TabPage2.Controls.Add(Me.txtMaxSizeH)
        Me.TabPage2.Controls.Add(Me.txtSizeH)
        Me.TabPage2.Controls.Add(Me.txtLocationY)
        Me.TabPage2.Controls.Add(Me.cmbxDock)
        Me.TabPage2.Controls.Add(Me.Label19)
        Me.TabPage2.Controls.Add(Me.txtMinSizeW)
        Me.TabPage2.Controls.Add(Me.Label17)
        Me.TabPage2.Controls.Add(Me.txtMaxSizeW)
        Me.TabPage2.Controls.Add(Me.Label18)
        Me.TabPage2.Controls.Add(Me.txtSizeW)
        Me.TabPage2.Controls.Add(Me.Label16)
        Me.TabPage2.Controls.Add(Me.txtLocationX)
        Me.TabPage2.Controls.Add(Me.Label15)
        Me.TabPage2.Controls.Add(Me.txtTabIndex)
        Me.TabPage2.Controls.Add(Me.Label14)
        Me.TabPage2.Controls.Add(Me.chkTabStop)
        Me.TabPage2.Controls.Add(Me.chkAutoSize)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(190, 855)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Layout"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'btnMinSize
        '
        Me.btnMinSize.Location = New System.Drawing.Point(123, 317)
        Me.btnMinSize.Name = "btnMinSize"
        Me.btnMinSize.Size = New System.Drawing.Size(52, 23)
        Me.btnMinSize.TabIndex = 28
        Me.btnMinSize.Text = "Update"
        Me.btnMinSize.UseVisualStyleBackColor = True
        '
        'btnMaxSize
        '
        Me.btnMaxSize.Location = New System.Drawing.Point(123, 263)
        Me.btnMaxSize.Name = "btnMaxSize"
        Me.btnMaxSize.Size = New System.Drawing.Size(52, 23)
        Me.btnMaxSize.TabIndex = 27
        Me.btnMaxSize.Text = "Update"
        Me.btnMaxSize.UseVisualStyleBackColor = True
        '
        'btnLocation
        '
        Me.btnLocation.Location = New System.Drawing.Point(123, 157)
        Me.btnLocation.Name = "btnLocation"
        Me.btnLocation.Size = New System.Drawing.Size(52, 23)
        Me.btnLocation.TabIndex = 25
        Me.btnLocation.Text = "Update"
        Me.btnLocation.UseVisualStyleBackColor = True
        '
        'txtMinSizeH
        '
        Me.txtMinSizeH.Location = New System.Drawing.Point(66, 319)
        Me.txtMinSizeH.Name = "txtMinSizeH"
        Me.txtMinSizeH.Size = New System.Drawing.Size(51, 20)
        Me.txtMinSizeH.TabIndex = 24
        '
        'txtMaxSizeH
        '
        Me.txtMaxSizeH.Location = New System.Drawing.Point(66, 265)
        Me.txtMaxSizeH.Name = "txtMaxSizeH"
        Me.txtMaxSizeH.Size = New System.Drawing.Size(51, 20)
        Me.txtMaxSizeH.TabIndex = 23
        '
        'txtSizeH
        '
        Me.txtSizeH.Location = New System.Drawing.Point(98, 211)
        Me.txtSizeH.Name = "txtSizeH"
        Me.txtSizeH.Size = New System.Drawing.Size(77, 20)
        Me.txtSizeH.TabIndex = 22
        '
        'txtLocationY
        '
        Me.txtLocationY.Location = New System.Drawing.Point(66, 157)
        Me.txtLocationY.Name = "txtLocationY"
        Me.txtLocationY.Size = New System.Drawing.Size(51, 20)
        Me.txtLocationY.TabIndex = 21
        '
        'cmbxDock
        '
        Me.cmbxDock.FormattingEnabled = True
        Me.cmbxDock.Items.AddRange(New Object() {"None", "Top", "Bottom", "Left", "Right", "Fill"})
        Me.cmbxDock.Location = New System.Drawing.Point(12, 377)
        Me.cmbxDock.Name = "cmbxDock"
        Me.cmbxDock.Size = New System.Drawing.Size(163, 21)
        Me.cmbxDock.TabIndex = 20
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(9, 361)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(39, 13)
        Me.Label19.TabIndex = 19
        Me.Label19.Text = "Dock :"
        '
        'txtMinSizeW
        '
        Me.txtMinSizeW.Location = New System.Drawing.Point(9, 319)
        Me.txtMinSizeW.Name = "txtMinSizeW"
        Me.txtMinSizeW.Size = New System.Drawing.Size(51, 20)
        Me.txtMinSizeW.TabIndex = 18
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(9, 303)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(77, 13)
        Me.Label17.TabIndex = 17
        Me.Label17.Text = "Minimum Size :"
        '
        'txtMaxSizeW
        '
        Me.txtMaxSizeW.Location = New System.Drawing.Point(9, 265)
        Me.txtMaxSizeW.Name = "txtMaxSizeW"
        Me.txtMaxSizeW.Size = New System.Drawing.Size(51, 20)
        Me.txtMaxSizeW.TabIndex = 16
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(6, 249)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(80, 13)
        Me.Label18.TabIndex = 15
        Me.Label18.Text = "Maximum Size :"
        '
        'txtSizeW
        '
        Me.txtSizeW.Location = New System.Drawing.Point(9, 211)
        Me.txtSizeW.Name = "txtSizeW"
        Me.txtSizeW.Size = New System.Drawing.Size(77, 20)
        Me.txtSizeW.TabIndex = 14
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(9, 195)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(33, 13)
        Me.Label16.TabIndex = 13
        Me.Label16.Text = "Size :"
        '
        'txtLocationX
        '
        Me.txtLocationX.Location = New System.Drawing.Point(9, 157)
        Me.txtLocationX.Name = "txtLocationX"
        Me.txtLocationX.Size = New System.Drawing.Size(51, 20)
        Me.txtLocationX.TabIndex = 12
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(6, 141)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(54, 13)
        Me.Label15.TabIndex = 11
        Me.Label15.Text = "Location :"
        '
        'txtTabIndex
        '
        Me.txtTabIndex.Location = New System.Drawing.Point(9, 106)
        Me.txtTabIndex.Name = "txtTabIndex"
        Me.txtTabIndex.Size = New System.Drawing.Size(166, 20)
        Me.txtTabIndex.TabIndex = 10
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 90)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(61, 13)
        Me.Label14.TabIndex = 9
        Me.Label14.Text = "Tab Index :"
        '
        'chkTabStop
        '
        Me.chkTabStop.AutoSize = True
        Me.chkTabStop.Location = New System.Drawing.Point(9, 52)
        Me.chkTabStop.Name = "chkTabStop"
        Me.chkTabStop.Size = New System.Drawing.Size(70, 17)
        Me.chkTabStop.TabIndex = 2
        Me.chkTabStop.Text = "Tab Stop"
        Me.chkTabStop.UseVisualStyleBackColor = True
        '
        'chkAutoSize
        '
        Me.chkAutoSize.AutoSize = True
        Me.chkAutoSize.Location = New System.Drawing.Point(8, 20)
        Me.chkAutoSize.Name = "chkAutoSize"
        Me.chkAutoSize.Size = New System.Drawing.Size(71, 17)
        Me.chkAutoSize.TabIndex = 0
        Me.chkAutoSize.Text = "Auto Size"
        Me.chkAutoSize.UseVisualStyleBackColor = True
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.btnRemove)
        Me.TabPage1.Controls.Add(Me.ListAll)
        Me.TabPage1.Controls.Add(Me.cmbxBorderStyle)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.chkUseWaitCusor)
        Me.TabPage1.Controls.Add(Me.btnCursor)
        Me.TabPage1.Controls.Add(Me.txtCursor)
        Me.TabPage1.Controls.Add(Me.chkCursorFrmFile)
        Me.TabPage1.Controls.Add(Me.cmbxCursor)
        Me.TabPage1.Controls.Add(Me.cmbxBImageLayout)
        Me.TabPage1.Controls.Add(Me.btnBackgroundImage)
        Me.TabPage1.Controls.Add(Me.txtBackgroundImage)
        Me.TabPage1.Controls.Add(Me.btnBackColor)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(190, 855)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Apperance"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 397)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 13)
        Me.Label6.TabIndex = 43
        Me.Label6.Text = "Controls :"
        '
        'btnRemove
        '
        Me.btnRemove.Location = New System.Drawing.Point(11, 566)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(75, 23)
        Me.btnRemove.TabIndex = 42
        Me.btnRemove.Text = "Remove.."
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'ListAll
        '
        Me.ListAll.ForeColor = System.Drawing.Color.Black
        Me.ListAll.FormattingEnabled = True
        Me.ListAll.HorizontalScrollbar = True
        Me.ListAll.Location = New System.Drawing.Point(11, 413)
        Me.ListAll.Name = "ListAll"
        Me.ListAll.Size = New System.Drawing.Size(163, 147)
        Me.ListAll.TabIndex = 41
        '
        'cmbxBorderStyle
        '
        Me.cmbxBorderStyle.FormattingEnabled = True
        Me.cmbxBorderStyle.Items.AddRange(New Object() {"None", "FixedSingle", "Fixed3D"})
        Me.cmbxBorderStyle.Location = New System.Drawing.Point(11, 317)
        Me.cmbxBorderStyle.Name = "cmbxBorderStyle"
        Me.cmbxBorderStyle.Size = New System.Drawing.Size(166, 21)
        Me.cmbxBorderStyle.TabIndex = 40
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 301)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 39
        Me.Label1.Text = "Border Style :"
        '
        'chkUseWaitCusor
        '
        Me.chkUseWaitCusor.AutoSize = True
        Me.chkUseWaitCusor.Location = New System.Drawing.Point(11, 357)
        Me.chkUseWaitCusor.Name = "chkUseWaitCusor"
        Me.chkUseWaitCusor.Size = New System.Drawing.Size(103, 17)
        Me.chkUseWaitCusor.TabIndex = 36
        Me.chkUseWaitCusor.Text = "Use Wait Cursor"
        Me.chkUseWaitCusor.UseVisualStyleBackColor = True
        '
        'btnCursor
        '
        Me.btnCursor.Enabled = False
        Me.btnCursor.Location = New System.Drawing.Point(156, 268)
        Me.btnCursor.Name = "btnCursor"
        Me.btnCursor.Size = New System.Drawing.Size(25, 20)
        Me.btnCursor.TabIndex = 17
        Me.btnCursor.Text = ".."
        Me.btnCursor.UseVisualStyleBackColor = True
        '
        'txtCursor
        '
        Me.txtCursor.Enabled = False
        Me.txtCursor.Location = New System.Drawing.Point(11, 268)
        Me.txtCursor.Name = "txtCursor"
        Me.txtCursor.Size = New System.Drawing.Size(142, 20)
        Me.txtCursor.TabIndex = 16
        '
        'chkCursorFrmFile
        '
        Me.chkCursorFrmFile.AutoSize = True
        Me.chkCursorFrmFile.Location = New System.Drawing.Point(20, 245)
        Me.chkCursorFrmFile.Name = "chkCursorFrmFile"
        Me.chkCursorFrmFile.Size = New System.Drawing.Size(68, 17)
        Me.chkCursorFrmFile.TabIndex = 15
        Me.chkCursorFrmFile.Text = "From File"
        Me.chkCursorFrmFile.UseVisualStyleBackColor = True
        '
        'cmbxCursor
        '
        Me.cmbxCursor.FormattingEnabled = True
        Me.cmbxCursor.Items.AddRange(New Object() {"Cursors.AppStarting", "Cursors.Arrow", "Cursors.Cross", "Cursors.Default", "Cursors.Hand", "Cursors.Help", "Cursors.HSplit", "Cursors.IBeam", "Cursors.No", "Cursors.NoMove2D", "Cursors.NoMoveHoriz", "Cursors.NoMoveVert", "Cursors.PanEast", "Cursors.PanNE", "Cursors.PanNorth", "Cursors.PanNW", "Cursors.PanSE", "Cursors.PanSouth", "Cursors.PanSW", "Cursors.PanWest", "Cursors.SizeAll", "Cursors.SizeNESW", "Cursors.SizeNS", "Cursors.SizeNWSE", "Cursors.SizeWE", "Cursors.UpArrow", "Cursors.VSplit", "Cursors.WaitCursor"})
        Me.cmbxCursor.Location = New System.Drawing.Point(11, 209)
        Me.cmbxCursor.Name = "cmbxCursor"
        Me.cmbxCursor.Size = New System.Drawing.Size(166, 21)
        Me.cmbxCursor.TabIndex = 13
        '
        'cmbxBImageLayout
        '
        Me.cmbxBImageLayout.FormattingEnabled = True
        Me.cmbxBImageLayout.Items.AddRange(New Object() {"None", "Tile", "Center", "Stretch", "Zoom"})
        Me.cmbxBImageLayout.Location = New System.Drawing.Point(11, 151)
        Me.cmbxBImageLayout.Name = "cmbxBImageLayout"
        Me.cmbxBImageLayout.Size = New System.Drawing.Size(166, 21)
        Me.cmbxBImageLayout.TabIndex = 12
        '
        'btnBackgroundImage
        '
        Me.btnBackgroundImage.Location = New System.Drawing.Point(156, 94)
        Me.btnBackgroundImage.Name = "btnBackgroundImage"
        Me.btnBackgroundImage.Size = New System.Drawing.Size(25, 20)
        Me.btnBackgroundImage.TabIndex = 11
        Me.btnBackgroundImage.Text = ".."
        Me.btnBackgroundImage.UseVisualStyleBackColor = True
        '
        'txtBackgroundImage
        '
        Me.txtBackgroundImage.Location = New System.Drawing.Point(11, 94)
        Me.txtBackgroundImage.Name = "txtBackgroundImage"
        Me.txtBackgroundImage.Size = New System.Drawing.Size(142, 20)
        Me.txtBackgroundImage.TabIndex = 10
        '
        'btnBackColor
        '
        Me.btnBackColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBackColor.Location = New System.Drawing.Point(11, 35)
        Me.btnBackColor.Name = "btnBackColor"
        Me.btnBackColor.Size = New System.Drawing.Size(166, 20)
        Me.btnBackColor.TabIndex = 9
        Me.btnBackColor.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 193)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Cursor"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 135)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(138, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Background Image Layout :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 78)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(103, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Background Image :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Background Color :"
        '
        'TabCntrl
        '
        Me.TabCntrl.Controls.Add(Me.TabPage1)
        Me.TabCntrl.Controls.Add(Me.TabPage2)
        Me.TabCntrl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabCntrl.Location = New System.Drawing.Point(0, 19)
        Me.TabCntrl.Name = "TabCntrl"
        Me.TabCntrl.SelectedIndex = 0
        Me.TabCntrl.Size = New System.Drawing.Size(198, 881)
        Me.TabCntrl.TabIndex = 0
        '
        'lblHead
        '
        Me.lblHead.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblHead.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblHead.Image = CType(resources.GetObject("lblHead.Image"), System.Drawing.Image)
        Me.lblHead.Location = New System.Drawing.Point(0, 0)
        Me.lblHead.Name = "lblHead"
        Me.lblHead.Size = New System.Drawing.Size(198, 19)
        Me.lblHead.TabIndex = 23
        Me.lblHead.Text = "Properties [Panel]:"
        Me.lblHead.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Ppan
        '
        Me.Controls.Add(Me.TabCntrl)
        Me.Controls.Add(Me.lblHead)
        Me.Name = "Ppan"
        Me.Size = New System.Drawing.Size(198, 900)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabCntrl.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents cmbxBImageLayout As System.Windows.Forms.ComboBox
    Friend WithEvents btnBackgroundImage As System.Windows.Forms.Button
    Friend WithEvents txtBackgroundImage As System.Windows.Forms.TextBox
    Friend WithEvents btnBackColor As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TabCntrl As System.Windows.Forms.TabControl
    Friend WithEvents btnCursor As System.Windows.Forms.Button
    Friend WithEvents txtCursor As System.Windows.Forms.TextBox
    Friend WithEvents chkCursorFrmFile As System.Windows.Forms.CheckBox
    Friend WithEvents cmbxCursor As System.Windows.Forms.ComboBox
    Friend WithEvents chkUseWaitCusor As System.Windows.Forms.CheckBox
    Friend WithEvents txtSizeW As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtLocationX As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtTabIndex As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtMinSizeW As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtMaxSizeW As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cmbxDock As System.Windows.Forms.ComboBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents FontDialog1 As System.Windows.Forms.FontDialog
    Friend WithEvents txtMinSizeH As System.Windows.Forms.TextBox
    Friend WithEvents txtMaxSizeH As System.Windows.Forms.TextBox
    Friend WithEvents txtSizeH As System.Windows.Forms.TextBox
    Friend WithEvents txtLocationY As System.Windows.Forms.TextBox
    Friend WithEvents btnLocation As System.Windows.Forms.Button
    Friend WithEvents btnMinSize As System.Windows.Forms.Button
    Friend WithEvents btnMaxSize As System.Windows.Forms.Button
    Friend WithEvents chkTabStop As System.Windows.Forms.CheckBox
    Friend WithEvents chkAutoSize As System.Windows.Forms.CheckBox
    Friend WithEvents cmbxBorderStyle As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblHead As System.Windows.Forms.Label
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents ListAll As System.Windows.Forms.ListBox
    Friend WithEvents Label6 As System.Windows.Forms.Label

End Class
