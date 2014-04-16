' Copyright © Microsoft Corporation.  All Rights Reserved.
' This code released under the terms of the 
' Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)
'
Partial Public Class Pbtn
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Pbtn))
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.cmbxRightToLeft = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
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
        Me.chkUseWaitCusor = New System.Windows.Forms.CheckBox()
        Me.chkUseVisualStyle = New System.Windows.Forms.CheckBox()
        Me.chkUseMnemonic = New System.Windows.Forms.CheckBox()
        Me.cmbxTextImageRelation = New System.Windows.Forms.ComboBox()
        Me.cmbxTextAlign = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cmbxImageAlign = New System.Windows.Forms.ComboBox()
        Me.btnImage = New System.Windows.Forms.Button()
        Me.txtImage = New System.Windows.Forms.TextBox()
        Me.btnForeColor = New System.Windows.Forms.Button()
        Me.btnFont = New System.Windows.Forms.Button()
        Me.txtFont = New System.Windows.Forms.TextBox()
        Me.cmbxFlatStyle = New System.Windows.Forms.ComboBox()
        Me.btnFlatApperance = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnCursor = New System.Windows.Forms.Button()
        Me.txtCursor = New System.Windows.Forms.TextBox()
        Me.chkCursorFrmFile = New System.Windows.Forms.CheckBox()
        Me.cmbxCursor = New System.Windows.Forms.ComboBox()
        Me.cmbxBImageLayout = New System.Windows.Forms.ComboBox()
        Me.btnBackgroundImage = New System.Windows.Forms.Button()
        Me.txtBackgroundImage = New System.Windows.Forms.TextBox()
        Me.txtText = New System.Windows.Forms.TextBox()
        Me.btnBackColor = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
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
        Me.TabPage2.Controls.Add(Me.cmbxRightToLeft)
        Me.TabPage2.Controls.Add(Me.Label20)
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
        Me.TabPage2.Size = New System.Drawing.Size(190, 868)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Layout"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'cmbxRightToLeft
        '
        Me.cmbxRightToLeft.FormattingEnabled = True
        Me.cmbxRightToLeft.Items.AddRange(New Object() {"No", "Yes", "Inherit"})
        Me.cmbxRightToLeft.Location = New System.Drawing.Point(12, 435)
        Me.cmbxRightToLeft.Name = "cmbxRightToLeft"
        Me.cmbxRightToLeft.Size = New System.Drawing.Size(163, 21)
        Me.cmbxRightToLeft.TabIndex = 30
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(9, 419)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(71, 13)
        Me.Label20.TabIndex = 29
        Me.Label20.Text = "Right to Left :"
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
        Me.TabPage1.Controls.Add(Me.chkUseWaitCusor)
        Me.TabPage1.Controls.Add(Me.chkUseVisualStyle)
        Me.TabPage1.Controls.Add(Me.chkUseMnemonic)
        Me.TabPage1.Controls.Add(Me.cmbxTextImageRelation)
        Me.TabPage1.Controls.Add(Me.cmbxTextAlign)
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Controls.Add(Me.Label12)
        Me.TabPage1.Controls.Add(Me.cmbxImageAlign)
        Me.TabPage1.Controls.Add(Me.btnImage)
        Me.TabPage1.Controls.Add(Me.txtImage)
        Me.TabPage1.Controls.Add(Me.btnForeColor)
        Me.TabPage1.Controls.Add(Me.btnFont)
        Me.TabPage1.Controls.Add(Me.txtFont)
        Me.TabPage1.Controls.Add(Me.cmbxFlatStyle)
        Me.TabPage1.Controls.Add(Me.btnFlatApperance)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.btnCursor)
        Me.TabPage1.Controls.Add(Me.txtCursor)
        Me.TabPage1.Controls.Add(Me.chkCursorFrmFile)
        Me.TabPage1.Controls.Add(Me.cmbxCursor)
        Me.TabPage1.Controls.Add(Me.cmbxBImageLayout)
        Me.TabPage1.Controls.Add(Me.btnBackgroundImage)
        Me.TabPage1.Controls.Add(Me.txtBackgroundImage)
        Me.TabPage1.Controls.Add(Me.txtText)
        Me.TabPage1.Controls.Add(Me.btnBackColor)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(190, 868)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Apperance"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'chkUseWaitCusor
        '
        Me.chkUseWaitCusor.AutoSize = True
        Me.chkUseWaitCusor.Location = New System.Drawing.Point(11, 842)
        Me.chkUseWaitCusor.Name = "chkUseWaitCusor"
        Me.chkUseWaitCusor.Size = New System.Drawing.Size(103, 17)
        Me.chkUseWaitCusor.TabIndex = 36
        Me.chkUseWaitCusor.Text = "Use Wait Cursor"
        Me.chkUseWaitCusor.UseVisualStyleBackColor = True
        '
        'chkUseVisualStyle
        '
        Me.chkUseVisualStyle.AutoSize = True
        Me.chkUseVisualStyle.Location = New System.Drawing.Point(11, 811)
        Me.chkUseVisualStyle.Name = "chkUseVisualStyle"
        Me.chkUseVisualStyle.Size = New System.Drawing.Size(154, 17)
        Me.chkUseVisualStyle.TabIndex = 35
        Me.chkUseVisualStyle.Text = "UseVisual Style Back Color"
        Me.chkUseVisualStyle.UseVisualStyleBackColor = True
        '
        'chkUseMnemonic
        '
        Me.chkUseMnemonic.AutoSize = True
        Me.chkUseMnemonic.Location = New System.Drawing.Point(11, 777)
        Me.chkUseMnemonic.Name = "chkUseMnemonic"
        Me.chkUseMnemonic.Size = New System.Drawing.Size(97, 17)
        Me.chkUseMnemonic.TabIndex = 34
        Me.chkUseMnemonic.Text = "Use Mnemonic"
        Me.chkUseMnemonic.UseVisualStyleBackColor = True
        '
        'cmbxTextImageRelation
        '
        Me.cmbxTextImageRelation.FormattingEnabled = True
        Me.cmbxTextImageRelation.Items.AddRange(New Object() {"Overlay", "ImageBeforeText", "TextBeforeImage", "ImageAboveText", "TextAboveImage"})
        Me.cmbxTextImageRelation.Location = New System.Drawing.Point(11, 738)
        Me.cmbxTextImageRelation.Name = "cmbxTextImageRelation"
        Me.cmbxTextImageRelation.Size = New System.Drawing.Size(166, 21)
        Me.cmbxTextImageRelation.TabIndex = 33
        '
        'cmbxTextAlign
        '
        Me.cmbxTextAlign.FormattingEnabled = True
        Me.cmbxTextAlign.Items.AddRange(New Object() {"TopLeft", "TopCenter", "TopRight", "MiddleLeft", "MiddleCenter", "MiddleRight", "BottomLeft", "BottomCenter", "BottomRight"})
        Me.cmbxTextAlign.Location = New System.Drawing.Point(11, 686)
        Me.cmbxTextAlign.Name = "cmbxTextAlign"
        Me.cmbxTextAlign.Size = New System.Drawing.Size(166, 21)
        Me.cmbxTextAlign.TabIndex = 32
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(8, 722)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(108, 13)
        Me.Label13.TabIndex = 31
        Me.Label13.Text = "Text Image Relation :"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(8, 670)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(60, 13)
        Me.Label12.TabIndex = 30
        Me.Label12.Text = "Text Align :"
        '
        'cmbxImageAlign
        '
        Me.cmbxImageAlign.FormattingEnabled = True
        Me.cmbxImageAlign.Items.AddRange(New Object() {"TopLeft", "TopCenter", "TopRight", "MiddleLeft", "MiddleCenter", "MiddleRight", "BottomLeft", "BottomCenter", "BottomRight"})
        Me.cmbxImageAlign.Location = New System.Drawing.Point(11, 634)
        Me.cmbxImageAlign.Name = "cmbxImageAlign"
        Me.cmbxImageAlign.Size = New System.Drawing.Size(166, 21)
        Me.cmbxImageAlign.TabIndex = 29
        '
        'btnImage
        '
        Me.btnImage.Location = New System.Drawing.Point(156, 582)
        Me.btnImage.Name = "btnImage"
        Me.btnImage.Size = New System.Drawing.Size(25, 20)
        Me.btnImage.TabIndex = 28
        Me.btnImage.Text = ".."
        Me.btnImage.UseVisualStyleBackColor = True
        '
        'txtImage
        '
        Me.txtImage.Location = New System.Drawing.Point(11, 582)
        Me.txtImage.Name = "txtImage"
        Me.txtImage.Size = New System.Drawing.Size(142, 20)
        Me.txtImage.TabIndex = 27
        '
        'btnForeColor
        '
        Me.btnForeColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnForeColor.Location = New System.Drawing.Point(11, 530)
        Me.btnForeColor.Name = "btnForeColor"
        Me.btnForeColor.Size = New System.Drawing.Size(166, 20)
        Me.btnForeColor.TabIndex = 26
        Me.btnForeColor.UseVisualStyleBackColor = True
        '
        'btnFont
        '
        Me.btnFont.Location = New System.Drawing.Point(156, 478)
        Me.btnFont.Name = "btnFont"
        Me.btnFont.Size = New System.Drawing.Size(25, 20)
        Me.btnFont.TabIndex = 25
        Me.btnFont.Text = ".."
        Me.btnFont.UseVisualStyleBackColor = True
        '
        'txtFont
        '
        Me.txtFont.Location = New System.Drawing.Point(11, 478)
        Me.txtFont.Name = "txtFont"
        Me.txtFont.Size = New System.Drawing.Size(142, 20)
        Me.txtFont.TabIndex = 24
        '
        'cmbxFlatStyle
        '
        Me.cmbxFlatStyle.FormattingEnabled = True
        Me.cmbxFlatStyle.Items.AddRange(New Object() {"Flat", "Popup", "Standard", "System"})
        Me.cmbxFlatStyle.Location = New System.Drawing.Point(11, 426)
        Me.cmbxFlatStyle.Name = "cmbxFlatStyle"
        Me.cmbxFlatStyle.Size = New System.Drawing.Size(166, 21)
        Me.cmbxFlatStyle.TabIndex = 23
        '
        'btnFlatApperance
        '
        Me.btnFlatApperance.Location = New System.Drawing.Point(11, 374)
        Me.btnFlatApperance.Name = "btnFlatApperance"
        Me.btnFlatApperance.Size = New System.Drawing.Size(166, 23)
        Me.btnFlatApperance.TabIndex = 22
        Me.btnFlatApperance.Text = "Set .."
        Me.btnFlatApperance.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(8, 618)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(68, 13)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "Image Align :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(8, 566)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(42, 13)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "Image :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(8, 514)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(61, 13)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "Fore Color :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 462)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(34, 13)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Font :"
        '
        'btnCursor
        '
        Me.btnCursor.Enabled = False
        Me.btnCursor.Location = New System.Drawing.Point(156, 320)
        Me.btnCursor.Name = "btnCursor"
        Me.btnCursor.Size = New System.Drawing.Size(25, 20)
        Me.btnCursor.TabIndex = 17
        Me.btnCursor.Text = ".."
        Me.btnCursor.UseVisualStyleBackColor = True
        '
        'txtCursor
        '
        Me.txtCursor.Enabled = False
        Me.txtCursor.Location = New System.Drawing.Point(11, 320)
        Me.txtCursor.Name = "txtCursor"
        Me.txtCursor.Size = New System.Drawing.Size(142, 20)
        Me.txtCursor.TabIndex = 16
        '
        'chkCursorFrmFile
        '
        Me.chkCursorFrmFile.AutoSize = True
        Me.chkCursorFrmFile.Location = New System.Drawing.Point(20, 297)
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
        Me.cmbxCursor.Location = New System.Drawing.Point(11, 261)
        Me.cmbxCursor.Name = "cmbxCursor"
        Me.cmbxCursor.Size = New System.Drawing.Size(166, 21)
        Me.cmbxCursor.TabIndex = 13
        '
        'cmbxBImageLayout
        '
        Me.cmbxBImageLayout.FormattingEnabled = True
        Me.cmbxBImageLayout.Items.AddRange(New Object() {"None", "Tile", "Center", "Stretch", "Zoom"})
        Me.cmbxBImageLayout.Location = New System.Drawing.Point(11, 203)
        Me.cmbxBImageLayout.Name = "cmbxBImageLayout"
        Me.cmbxBImageLayout.Size = New System.Drawing.Size(166, 21)
        Me.cmbxBImageLayout.TabIndex = 12
        '
        'btnBackgroundImage
        '
        Me.btnBackgroundImage.Location = New System.Drawing.Point(156, 146)
        Me.btnBackgroundImage.Name = "btnBackgroundImage"
        Me.btnBackgroundImage.Size = New System.Drawing.Size(25, 20)
        Me.btnBackgroundImage.TabIndex = 11
        Me.btnBackgroundImage.Text = ".."
        Me.btnBackgroundImage.UseVisualStyleBackColor = True
        '
        'txtBackgroundImage
        '
        Me.txtBackgroundImage.Location = New System.Drawing.Point(11, 146)
        Me.txtBackgroundImage.Name = "txtBackgroundImage"
        Me.txtBackgroundImage.Size = New System.Drawing.Size(142, 20)
        Me.txtBackgroundImage.TabIndex = 10
        '
        'txtText
        '
        Me.txtText.Location = New System.Drawing.Point(11, 36)
        Me.txtText.Name = "txtText"
        Me.txtText.Size = New System.Drawing.Size(166, 20)
        Me.txtText.TabIndex = 8
        '
        'btnBackColor
        '
        Me.btnBackColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBackColor.Location = New System.Drawing.Point(11, 87)
        Me.btnBackColor.Name = "btnBackColor"
        Me.btnBackColor.Size = New System.Drawing.Size(166, 20)
        Me.btnBackColor.TabIndex = 9
        Me.btnBackColor.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(8, 410)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 13)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Flat Style :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(8, 358)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(85, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Flat Apperance :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 245)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Cursor"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 187)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(138, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Background Image Layout :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 130)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(103, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Background Image :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Background Color :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Text :"
        '
        'TabCntrl
        '
        Me.TabCntrl.Controls.Add(Me.TabPage1)
        Me.TabCntrl.Controls.Add(Me.TabPage2)
        Me.TabCntrl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabCntrl.Location = New System.Drawing.Point(0, 19)
        Me.TabCntrl.Name = "TabCntrl"
        Me.TabCntrl.SelectedIndex = 0
        Me.TabCntrl.Size = New System.Drawing.Size(198, 894)
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
        Me.lblHead.TabIndex = 22
        Me.lblHead.Text = "Properties [Button]:"
        Me.lblHead.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Pbtn
        '
        Me.Controls.Add(Me.TabCntrl)
        Me.Controls.Add(Me.lblHead)
        Me.Name = "Pbtn"
        Me.Size = New System.Drawing.Size(198, 913)
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
    Friend WithEvents txtText As System.Windows.Forms.TextBox
    Friend WithEvents btnBackColor As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TabCntrl As System.Windows.Forms.TabControl
    Friend WithEvents btnCursor As System.Windows.Forms.Button
    Friend WithEvents txtCursor As System.Windows.Forms.TextBox
    Friend WithEvents chkCursorFrmFile As System.Windows.Forms.CheckBox
    Friend WithEvents cmbxCursor As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnForeColor As System.Windows.Forms.Button
    Friend WithEvents btnFont As System.Windows.Forms.Button
    Friend WithEvents txtFont As System.Windows.Forms.TextBox
    Friend WithEvents cmbxFlatStyle As System.Windows.Forms.ComboBox
    Friend WithEvents btnFlatApperance As System.Windows.Forms.Button
    Friend WithEvents cmbxImageAlign As System.Windows.Forms.ComboBox
    Friend WithEvents btnImage As System.Windows.Forms.Button
    Friend WithEvents txtImage As System.Windows.Forms.TextBox
    Friend WithEvents cmbxTextImageRelation As System.Windows.Forms.ComboBox
    Friend WithEvents cmbxTextAlign As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents chkUseWaitCusor As System.Windows.Forms.CheckBox
    Friend WithEvents chkUseVisualStyle As System.Windows.Forms.CheckBox
    Friend WithEvents chkUseMnemonic As System.Windows.Forms.CheckBox
    Friend WithEvents chkTabStop As System.Windows.Forms.CheckBox
    Friend WithEvents chkAutoSize As System.Windows.Forms.CheckBox
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
    Friend WithEvents cmbxRightToLeft As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents lblHead As System.Windows.Forms.Label

End Class

' Copyright © Microsoft Corporation.  All Rights Reserved.
' This code released under the terms of the 
' Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)
'
Partial Public Class Pimg
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Pimg))
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
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.chkWaitonLoad = New System.Windows.Forms.CheckBox()
        Me.cmbxSizeMode = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtImageLocation = New System.Windows.Forms.TextBox()
        Me.chkUseWaitCusor = New System.Windows.Forms.CheckBox()
        Me.btnImage = New System.Windows.Forms.Button()
        Me.txtImage = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
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
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(190, 874)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Layout"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'btnMinSize
        '
        Me.btnMinSize.Location = New System.Drawing.Point(126, 196)
        Me.btnMinSize.Name = "btnMinSize"
        Me.btnMinSize.Size = New System.Drawing.Size(52, 23)
        Me.btnMinSize.TabIndex = 28
        Me.btnMinSize.Text = "Update"
        Me.btnMinSize.UseVisualStyleBackColor = True
        '
        'btnMaxSize
        '
        Me.btnMaxSize.Location = New System.Drawing.Point(126, 142)
        Me.btnMaxSize.Name = "btnMaxSize"
        Me.btnMaxSize.Size = New System.Drawing.Size(52, 23)
        Me.btnMaxSize.TabIndex = 27
        Me.btnMaxSize.Text = "Update"
        Me.btnMaxSize.UseVisualStyleBackColor = True
        '
        'btnLocation
        '
        Me.btnLocation.Location = New System.Drawing.Point(126, 36)
        Me.btnLocation.Name = "btnLocation"
        Me.btnLocation.Size = New System.Drawing.Size(52, 23)
        Me.btnLocation.TabIndex = 25
        Me.btnLocation.Text = "Update"
        Me.btnLocation.UseVisualStyleBackColor = True
        '
        'txtMinSizeH
        '
        Me.txtMinSizeH.Location = New System.Drawing.Point(69, 198)
        Me.txtMinSizeH.Name = "txtMinSizeH"
        Me.txtMinSizeH.Size = New System.Drawing.Size(51, 20)
        Me.txtMinSizeH.TabIndex = 24
        '
        'txtMaxSizeH
        '
        Me.txtMaxSizeH.Location = New System.Drawing.Point(69, 144)
        Me.txtMaxSizeH.Name = "txtMaxSizeH"
        Me.txtMaxSizeH.Size = New System.Drawing.Size(51, 20)
        Me.txtMaxSizeH.TabIndex = 23
        '
        'txtSizeH
        '
        Me.txtSizeH.Location = New System.Drawing.Point(101, 90)
        Me.txtSizeH.Name = "txtSizeH"
        Me.txtSizeH.Size = New System.Drawing.Size(77, 20)
        Me.txtSizeH.TabIndex = 22
        '
        'txtLocationY
        '
        Me.txtLocationY.Location = New System.Drawing.Point(69, 36)
        Me.txtLocationY.Name = "txtLocationY"
        Me.txtLocationY.Size = New System.Drawing.Size(51, 20)
        Me.txtLocationY.TabIndex = 21
        '
        'cmbxDock
        '
        Me.cmbxDock.FormattingEnabled = True
        Me.cmbxDock.Items.AddRange(New Object() {"None", "Top", "Bottom", "Left", "Right", "Fill"})
        Me.cmbxDock.Location = New System.Drawing.Point(15, 256)
        Me.cmbxDock.Name = "cmbxDock"
        Me.cmbxDock.Size = New System.Drawing.Size(163, 21)
        Me.cmbxDock.TabIndex = 20
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(12, 240)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(39, 13)
        Me.Label19.TabIndex = 19
        Me.Label19.Text = "Dock :"
        '
        'txtMinSizeW
        '
        Me.txtMinSizeW.Location = New System.Drawing.Point(12, 198)
        Me.txtMinSizeW.Name = "txtMinSizeW"
        Me.txtMinSizeW.Size = New System.Drawing.Size(51, 20)
        Me.txtMinSizeW.TabIndex = 18
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(12, 182)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(77, 13)
        Me.Label17.TabIndex = 17
        Me.Label17.Text = "Minimum Size :"
        '
        'txtMaxSizeW
        '
        Me.txtMaxSizeW.Location = New System.Drawing.Point(12, 144)
        Me.txtMaxSizeW.Name = "txtMaxSizeW"
        Me.txtMaxSizeW.Size = New System.Drawing.Size(51, 20)
        Me.txtMaxSizeW.TabIndex = 16
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(9, 128)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(80, 13)
        Me.Label18.TabIndex = 15
        Me.Label18.Text = "Maximum Size :"
        '
        'txtSizeW
        '
        Me.txtSizeW.Location = New System.Drawing.Point(12, 90)
        Me.txtSizeW.Name = "txtSizeW"
        Me.txtSizeW.Size = New System.Drawing.Size(77, 20)
        Me.txtSizeW.TabIndex = 14
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(12, 74)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(33, 13)
        Me.Label16.TabIndex = 13
        Me.Label16.Text = "Size :"
        '
        'txtLocationX
        '
        Me.txtLocationX.Location = New System.Drawing.Point(12, 36)
        Me.txtLocationX.Name = "txtLocationX"
        Me.txtLocationX.Size = New System.Drawing.Size(51, 20)
        Me.txtLocationX.TabIndex = 12
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(9, 20)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(54, 13)
        Me.Label15.TabIndex = 11
        Me.Label15.Text = "Location :"
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.chkWaitonLoad)
        Me.TabPage1.Controls.Add(Me.cmbxSizeMode)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.txtImageLocation)
        Me.TabPage1.Controls.Add(Me.chkUseWaitCusor)
        Me.TabPage1.Controls.Add(Me.btnImage)
        Me.TabPage1.Controls.Add(Me.txtImage)
        Me.TabPage1.Controls.Add(Me.Label10)
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
        'chkWaitonLoad
        '
        Me.chkWaitonLoad.AutoSize = True
        Me.chkWaitonLoad.Location = New System.Drawing.Point(11, 513)
        Me.chkWaitonLoad.Name = "chkWaitonLoad"
        Me.chkWaitonLoad.Size = New System.Drawing.Size(90, 17)
        Me.chkWaitonLoad.TabIndex = 45
        Me.chkWaitonLoad.Text = "Wait on Load"
        Me.chkWaitonLoad.UseVisualStyleBackColor = True
        '
        'cmbxSizeMode
        '
        Me.cmbxSizeMode.FormattingEnabled = True
        Me.cmbxSizeMode.Items.AddRange(New Object() {"Normal", "StretchImage", "AutoSize", "CenterImage", "Zoom"})
        Me.cmbxSizeMode.Location = New System.Drawing.Point(11, 428)
        Me.cmbxSizeMode.Name = "cmbxSizeMode"
        Me.cmbxSizeMode.Size = New System.Drawing.Size(166, 21)
        Me.cmbxSizeMode.TabIndex = 44
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(8, 412)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 13)
        Me.Label7.TabIndex = 43
        Me.Label7.Text = "Size Mode :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 360)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(86, 13)
        Me.Label6.TabIndex = 42
        Me.Label6.Text = "Image Location :"
        '
        'txtImageLocation
        '
        Me.txtImageLocation.Location = New System.Drawing.Point(11, 376)
        Me.txtImageLocation.Name = "txtImageLocation"
        Me.txtImageLocation.Size = New System.Drawing.Size(166, 20)
        Me.txtImageLocation.TabIndex = 41
        '
        'chkUseWaitCusor
        '
        Me.chkUseWaitCusor.AutoSize = True
        Me.chkUseWaitCusor.Location = New System.Drawing.Point(11, 472)
        Me.chkUseWaitCusor.Name = "chkUseWaitCusor"
        Me.chkUseWaitCusor.Size = New System.Drawing.Size(103, 17)
        Me.chkUseWaitCusor.TabIndex = 36
        Me.chkUseWaitCusor.Text = "Use Wait Cursor"
        Me.chkUseWaitCusor.UseVisualStyleBackColor = True
        '
        'btnImage
        '
        Me.btnImage.Location = New System.Drawing.Point(156, 318)
        Me.btnImage.Name = "btnImage"
        Me.btnImage.Size = New System.Drawing.Size(25, 20)
        Me.btnImage.TabIndex = 28
        Me.btnImage.Text = ".."
        Me.btnImage.UseVisualStyleBackColor = True
        '
        'txtImage
        '
        Me.txtImage.Location = New System.Drawing.Point(11, 318)
        Me.txtImage.Name = "txtImage"
        Me.txtImage.Size = New System.Drawing.Size(142, 20)
        Me.txtImage.TabIndex = 27
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(8, 302)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(42, 13)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "Image :"
        '
        'btnCursor
        '
        Me.btnCursor.Enabled = False
        Me.btnCursor.Location = New System.Drawing.Point(156, 264)
        Me.btnCursor.Name = "btnCursor"
        Me.btnCursor.Size = New System.Drawing.Size(25, 20)
        Me.btnCursor.TabIndex = 17
        Me.btnCursor.Text = ".."
        Me.btnCursor.UseVisualStyleBackColor = True
        '
        'txtCursor
        '
        Me.txtCursor.Enabled = False
        Me.txtCursor.Location = New System.Drawing.Point(11, 264)
        Me.txtCursor.Name = "txtCursor"
        Me.txtCursor.Size = New System.Drawing.Size(142, 20)
        Me.txtCursor.TabIndex = 16
        '
        'chkCursorFrmFile
        '
        Me.chkCursorFrmFile.AutoSize = True
        Me.chkCursorFrmFile.Location = New System.Drawing.Point(20, 241)
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
        Me.cmbxCursor.Location = New System.Drawing.Point(11, 205)
        Me.cmbxCursor.Name = "cmbxCursor"
        Me.cmbxCursor.Size = New System.Drawing.Size(166, 21)
        Me.cmbxCursor.TabIndex = 13
        '
        'cmbxBImageLayout
        '
        Me.cmbxBImageLayout.FormattingEnabled = True
        Me.cmbxBImageLayout.Items.AddRange(New Object() {"None", "Tile", "Center", "Stretch", "Zoom"})
        Me.cmbxBImageLayout.Location = New System.Drawing.Point(11, 152)
        Me.cmbxBImageLayout.Name = "cmbxBImageLayout"
        Me.cmbxBImageLayout.Size = New System.Drawing.Size(166, 21)
        Me.cmbxBImageLayout.TabIndex = 12
        '
        'btnBackgroundImage
        '
        Me.btnBackgroundImage.Location = New System.Drawing.Point(156, 95)
        Me.btnBackgroundImage.Name = "btnBackgroundImage"
        Me.btnBackgroundImage.Size = New System.Drawing.Size(25, 20)
        Me.btnBackgroundImage.TabIndex = 11
        Me.btnBackgroundImage.Text = ".."
        Me.btnBackgroundImage.UseVisualStyleBackColor = True
        '
        'txtBackgroundImage
        '
        Me.txtBackgroundImage.Location = New System.Drawing.Point(11, 95)
        Me.txtBackgroundImage.Name = "txtBackgroundImage"
        Me.txtBackgroundImage.Size = New System.Drawing.Size(142, 20)
        Me.txtBackgroundImage.TabIndex = 10
        '
        'btnBackColor
        '
        Me.btnBackColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBackColor.Location = New System.Drawing.Point(11, 36)
        Me.btnBackColor.Name = "btnBackColor"
        Me.btnBackColor.Size = New System.Drawing.Size(166, 20)
        Me.btnBackColor.TabIndex = 9
        Me.btnBackColor.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 189)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Cursor"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 136)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(138, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Background Image Layout :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 79)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(103, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Background Image :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 20)
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
        Me.lblHead.Text = "Properties [Image]:"
        Me.lblHead.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Pimg
        '
        Me.Controls.Add(Me.TabCntrl)
        Me.Controls.Add(Me.lblHead)
        Me.Name = "Pimg"
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
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnImage As System.Windows.Forms.Button
    Friend WithEvents txtImage As System.Windows.Forms.TextBox
    Friend WithEvents chkUseWaitCusor As System.Windows.Forms.CheckBox
    Friend WithEvents txtSizeW As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtLocationX As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtMinSizeW As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtMaxSizeW As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cmbxDock As System.Windows.Forms.ComboBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents txtMinSizeH As System.Windows.Forms.TextBox
    Friend WithEvents txtMaxSizeH As System.Windows.Forms.TextBox
    Friend WithEvents txtSizeH As System.Windows.Forms.TextBox
    Friend WithEvents txtLocationY As System.Windows.Forms.TextBox
    Friend WithEvents btnLocation As System.Windows.Forms.Button
    Friend WithEvents btnMinSize As System.Windows.Forms.Button
    Friend WithEvents btnMaxSize As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtImageLocation As System.Windows.Forms.TextBox
    Friend WithEvents cmbxSizeMode As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents chkWaitonLoad As System.Windows.Forms.CheckBox
    Friend WithEvents lblHead As System.Windows.Forms.Label

End Class

