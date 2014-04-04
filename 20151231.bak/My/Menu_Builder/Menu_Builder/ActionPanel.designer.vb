' Copyright © Microsoft Corporation.  All Rights Reserved.
' This code released under the terms of the 
' Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)
'
Partial Public Class EventPanel
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EventPanel))
        Me.lblHead = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.cmbxPara1 = New System.Windows.Forms.ComboBox()
        Me.lblPara4 = New System.Windows.Forms.Label()
        Me.chkPara2 = New System.Windows.Forms.CheckBox()
        Me.chkPara1 = New System.Windows.Forms.CheckBox()
        Me.lblPara1 = New System.Windows.Forms.Label()
        Me.lblPara2 = New System.Windows.Forms.Label()
        Me.txtPara1 = New System.Windows.Forms.TextBox()
        Me.txtPara2 = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmbxAction = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chT4 = New System.Windows.Forms.CheckBox()
        Me.chT3 = New System.Windows.Forms.CheckBox()
        Me.chT2 = New System.Windows.Forms.CheckBox()
        Me.chT = New System.Windows.Forms.CheckBox()
        Me.btnMouseDownFColor = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnMouseOverFColor = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnMouseDownBColor = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnMouseOverBColor = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CheckBox4 = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.TabPage2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblHead
        '
        Me.lblHead.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblHead.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblHead.Image = CType(resources.GetObject("lblHead.Image"), System.Drawing.Image)
        Me.lblHead.Location = New System.Drawing.Point(0, 0)
        Me.lblHead.Name = "lblHead"
        Me.lblHead.Size = New System.Drawing.Size(225, 19)
        Me.lblHead.TabIndex = 21
        Me.lblHead.Text = "Actions:"
        Me.lblHead.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Panel3)
        Me.TabPage2.Controls.Add(Me.Panel1)
        Me.TabPage2.Controls.Add(Me.Panel2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(217, 725)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Actions"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.cmbxPara1)
        Me.Panel3.Controls.Add(Me.lblPara4)
        Me.Panel3.Controls.Add(Me.chkPara2)
        Me.Panel3.Controls.Add(Me.chkPara1)
        Me.Panel3.Controls.Add(Me.lblPara1)
        Me.Panel3.Controls.Add(Me.lblPara2)
        Me.Panel3.Controls.Add(Me.txtPara1)
        Me.Panel3.Controls.Add(Me.txtPara2)
        Me.Panel3.Location = New System.Drawing.Point(4, 72)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(208, 239)
        Me.Panel3.TabIndex = 28
        '
        'cmbxPara1
        '
        Me.cmbxPara1.Enabled = False
        Me.cmbxPara1.FormattingEnabled = True
        Me.cmbxPara1.Items.AddRange(New Object() {" "})
        Me.cmbxPara1.Location = New System.Drawing.Point(11, 136)
        Me.cmbxPara1.Name = "cmbxPara1"
        Me.cmbxPara1.Size = New System.Drawing.Size(188, 21)
        Me.cmbxPara1.TabIndex = 15
        '
        'lblPara4
        '
        Me.lblPara4.AutoSize = True
        Me.lblPara4.Enabled = False
        Me.lblPara4.Location = New System.Drawing.Point(6, 120)
        Me.lblPara4.Name = "lblPara4"
        Me.lblPara4.Size = New System.Drawing.Size(55, 13)
        Me.lblPara4.TabIndex = 14
        Me.lblPara4.Text = "Parameter"
        '
        'chkPara2
        '
        Me.chkPara2.AutoSize = True
        Me.chkPara2.Enabled = False
        Me.chkPara2.Location = New System.Drawing.Point(12, 207)
        Me.chkPara2.Name = "chkPara2"
        Me.chkPara2.Size = New System.Drawing.Size(74, 17)
        Me.chkPara2.TabIndex = 13
        Me.chkPara2.Text = "Parameter"
        Me.chkPara2.UseVisualStyleBackColor = True
        '
        'chkPara1
        '
        Me.chkPara1.AutoSize = True
        Me.chkPara1.Enabled = False
        Me.chkPara1.Location = New System.Drawing.Point(12, 175)
        Me.chkPara1.Name = "chkPara1"
        Me.chkPara1.Size = New System.Drawing.Size(74, 17)
        Me.chkPara1.TabIndex = 12
        Me.chkPara1.Text = "Parameter"
        Me.chkPara1.UseVisualStyleBackColor = True
        '
        'lblPara1
        '
        Me.lblPara1.AutoSize = True
        Me.lblPara1.Enabled = False
        Me.lblPara1.Location = New System.Drawing.Point(5, 7)
        Me.lblPara1.Name = "lblPara1"
        Me.lblPara1.Size = New System.Drawing.Size(55, 13)
        Me.lblPara1.TabIndex = 2
        Me.lblPara1.Text = "Parameter"
        '
        'lblPara2
        '
        Me.lblPara2.AutoSize = True
        Me.lblPara2.Enabled = False
        Me.lblPara2.Location = New System.Drawing.Point(5, 61)
        Me.lblPara2.Name = "lblPara2"
        Me.lblPara2.Size = New System.Drawing.Size(55, 13)
        Me.lblPara2.TabIndex = 3
        Me.lblPara2.Text = "Parameter"
        '
        'txtPara1
        '
        Me.txtPara1.Enabled = False
        Me.txtPara1.Location = New System.Drawing.Point(10, 23)
        Me.txtPara1.Name = "txtPara1"
        Me.txtPara1.Size = New System.Drawing.Size(188, 20)
        Me.txtPara1.TabIndex = 4
        '
        'txtPara2
        '
        Me.txtPara2.Enabled = False
        Me.txtPara2.Location = New System.Drawing.Point(10, 77)
        Me.txtPara2.Name = "txtPara2"
        Me.txtPara2.Size = New System.Drawing.Size(188, 20)
        Me.txtPara2.TabIndex = 5
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.cmbxAction)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(4, 6)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(208, 58)
        Me.Panel1.TabIndex = 26
        '
        'cmbxAction
        '
        Me.cmbxAction.FormattingEnabled = True
        Me.cmbxAction.Items.AddRange(New Object() {"None", "Run a Program", "Open a file\Explore a folder", "Show a message box", "Goto web", "Download a file & open it", "Print", "Copy to Clip Board", "Maximize", "Minimize", "Exit"})
        Me.cmbxAction.Location = New System.Drawing.Point(11, 25)
        Me.cmbxAction.Name = "cmbxAction"
        Me.cmbxAction.Size = New System.Drawing.Size(188, 21)
        Me.cmbxAction.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Action:"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.CheckBox2)
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Controls.Add(Me.CheckBox4)
        Me.Panel2.Controls.Add(Me.CheckBox1)
        Me.Panel2.Location = New System.Drawing.Point(4, 320)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(208, 399)
        Me.Panel2.TabIndex = 27
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(11, 16)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(97, 17)
        Me.CheckBox2.TabIndex = 28
        Me.CheckBox2.Text = "Set Apperance"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chT4)
        Me.GroupBox1.Controls.Add(Me.chT3)
        Me.GroupBox1.Controls.Add(Me.chT2)
        Me.GroupBox1.Controls.Add(Me.chT)
        Me.GroupBox1.Controls.Add(Me.btnMouseDownFColor)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.btnMouseOverFColor)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.btnMouseDownBColor)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.btnMouseOverBColor)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Location = New System.Drawing.Point(9, 43)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(187, 245)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Apperance"
        '
        'chT4
        '
        Me.chT4.AutoSize = True
        Me.chT4.Location = New System.Drawing.Point(109, 212)
        Me.chT4.Name = "chT4"
        Me.chT4.Size = New System.Drawing.Size(56, 17)
        Me.chT4.TabIndex = 27
        Me.chT4.Text = "Trans."
        Me.chT4.UseVisualStyleBackColor = True
        '
        'chT3
        '
        Me.chT3.AutoSize = True
        Me.chT3.Location = New System.Drawing.Point(109, 157)
        Me.chT3.Name = "chT3"
        Me.chT3.Size = New System.Drawing.Size(56, 17)
        Me.chT3.TabIndex = 26
        Me.chT3.Text = "Trans."
        Me.chT3.UseVisualStyleBackColor = True
        '
        'chT2
        '
        Me.chT2.AutoSize = True
        Me.chT2.Location = New System.Drawing.Point(109, 106)
        Me.chT2.Name = "chT2"
        Me.chT2.Size = New System.Drawing.Size(56, 17)
        Me.chT2.TabIndex = 25
        Me.chT2.Text = "Trans."
        Me.chT2.UseVisualStyleBackColor = True
        '
        'chT
        '
        Me.chT.AutoSize = True
        Me.chT.Location = New System.Drawing.Point(109, 51)
        Me.chT.Name = "chT"
        Me.chT.Size = New System.Drawing.Size(56, 17)
        Me.chT.TabIndex = 24
        Me.chT.Text = "Trans."
        Me.chT.UseVisualStyleBackColor = True
        '
        'btnMouseDownFColor
        '
        Me.btnMouseDownFColor.BackColor = System.Drawing.Color.Maroon
        Me.btnMouseDownFColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMouseDownFColor.Location = New System.Drawing.Point(11, 209)
        Me.btnMouseDownFColor.Name = "btnMouseDownFColor"
        Me.btnMouseDownFColor.Size = New System.Drawing.Size(92, 20)
        Me.btnMouseDownFColor.TabIndex = 21
        Me.btnMouseDownFColor.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(8, 193)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(124, 13)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "Mouse Down ForeColor :"
        '
        'btnMouseOverFColor
        '
        Me.btnMouseOverFColor.BackColor = System.Drawing.Color.Black
        Me.btnMouseOverFColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMouseOverFColor.Location = New System.Drawing.Point(11, 154)
        Me.btnMouseOverFColor.Name = "btnMouseOverFColor"
        Me.btnMouseOverFColor.Size = New System.Drawing.Size(92, 20)
        Me.btnMouseOverFColor.TabIndex = 19
        Me.btnMouseOverFColor.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(8, 138)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(125, 13)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Mouse Hover ForeColor :"
        '
        'btnMouseDownBColor
        '
        Me.btnMouseDownBColor.BackColor = System.Drawing.Color.Silver
        Me.btnMouseDownBColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMouseDownBColor.Location = New System.Drawing.Point(11, 103)
        Me.btnMouseDownBColor.Name = "btnMouseDownBColor"
        Me.btnMouseDownBColor.Size = New System.Drawing.Size(92, 20)
        Me.btnMouseDownBColor.TabIndex = 14
        Me.btnMouseDownBColor.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 87)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(128, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Mouse Down BackColor :"
        '
        'btnMouseOverBColor
        '
        Me.btnMouseOverBColor.BackColor = System.Drawing.Color.LightGray
        Me.btnMouseOverBColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMouseOverBColor.Location = New System.Drawing.Point(11, 48)
        Me.btnMouseOverBColor.Name = "btnMouseOverBColor"
        Me.btnMouseOverBColor.Size = New System.Drawing.Size(92, 20)
        Me.btnMouseOverBColor.TabIndex = 12
        Me.btnMouseOverBColor.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(129, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Mouse Hover BackColor :"
        '
        'CheckBox4
        '
        Me.CheckBox4.AutoSize = True
        Me.CheckBox4.Location = New System.Drawing.Point(10, 327)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Size = New System.Drawing.Size(102, 17)
        Me.CheckBox4.TabIndex = 21
        Me.CheckBox4.Text = "Set as title bar ?"
        Me.CheckBox4.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(10, 304)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(160, 17)
        Me.CheckBox1.TabIndex = 23
        Me.CheckBox1.Text = "Exit after action completed ?"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 19)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(225, 751)
        Me.TabControl1.TabIndex = 22
        '
        'EventPanel
        '
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.lblHead)
        Me.Name = "EventPanel"
        Me.Size = New System.Drawing.Size(225, 770)
        Me.TabPage2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblHead As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbxAction As System.Windows.Forms.ComboBox
    Friend WithEvents CheckBox4 As System.Windows.Forms.CheckBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnMouseDownFColor As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnMouseOverFColor As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnMouseDownBColor As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnMouseOverBColor As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents cmbxPara1 As System.Windows.Forms.ComboBox
    Friend WithEvents lblPara4 As System.Windows.Forms.Label
    Friend WithEvents chkPara2 As System.Windows.Forms.CheckBox
    Friend WithEvents chkPara1 As System.Windows.Forms.CheckBox
    Friend WithEvents lblPara1 As System.Windows.Forms.Label
    Friend WithEvents lblPara2 As System.Windows.Forms.Label
    Friend WithEvents txtPara1 As System.Windows.Forms.TextBox
    Friend WithEvents txtPara2 As System.Windows.Forms.TextBox
    Friend WithEvents chT4 As System.Windows.Forms.CheckBox
    Friend WithEvents chT3 As System.Windows.Forms.CheckBox
    Friend WithEvents chT2 As System.Windows.Forms.CheckBox
    Friend WithEvents chT As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox

End Class
