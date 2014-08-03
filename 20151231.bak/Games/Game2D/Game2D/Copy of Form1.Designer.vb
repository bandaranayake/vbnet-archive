<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.PanelLft = New System.Windows.Forms.Panel()
        Me.PanelDown = New System.Windows.Forms.Panel()
        Me.display = New System.Windows.Forms.PictureBox()
        Me.PanelBorder1 = New System.Windows.Forms.Panel()
        Me.PanelBorder2 = New System.Windows.Forms.Panel()
        Me.PanelBorder3 = New System.Windows.Forms.Panel()
        Me.PanelBorder4 = New System.Windows.Forms.Panel()
        CType(Me.display, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelLft
        '
        Me.PanelLft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelLft.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelLft.Location = New System.Drawing.Point(0, 0)
        Me.PanelLft.Name = "PanelLft"
        Me.PanelLft.Size = New System.Drawing.Size(250, 788)
        Me.PanelLft.TabIndex = 1
        '
        'PanelDown
        '
        Me.PanelDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelDown.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelDown.Location = New System.Drawing.Point(250, 688)
        Me.PanelDown.Name = "PanelDown"
        Me.PanelDown.Size = New System.Drawing.Size(794, 100)
        Me.PanelDown.TabIndex = 2
        '
        'display
        '
        Me.display.BackColor = System.Drawing.Color.Black
        Me.display.Dock = System.Windows.Forms.DockStyle.Fill
        Me.display.Location = New System.Drawing.Point(301, 46)
        Me.display.Name = "display"
        Me.display.Size = New System.Drawing.Size(692, 596)
        Me.display.TabIndex = 0
        Me.display.TabStop = False
        '
        'PanelBorder1
        '
        Me.PanelBorder1.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.PanelBorder1.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelBorder1.Location = New System.Drawing.Point(250, 46)
        Me.PanelBorder1.Name = "PanelBorder1"
        Me.PanelBorder1.Size = New System.Drawing.Size(51, 642)
        Me.PanelBorder1.TabIndex = 3
        '
        'PanelBorder2
        '
        Me.PanelBorder2.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.PanelBorder2.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelBorder2.Location = New System.Drawing.Point(993, 46)
        Me.PanelBorder2.Name = "PanelBorder2"
        Me.PanelBorder2.Size = New System.Drawing.Size(51, 642)
        Me.PanelBorder2.TabIndex = 4
        '
        'PanelBorder3
        '
        Me.PanelBorder3.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.PanelBorder3.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelBorder3.Location = New System.Drawing.Point(250, 0)
        Me.PanelBorder3.Name = "PanelBorder3"
        Me.PanelBorder3.Size = New System.Drawing.Size(794, 46)
        Me.PanelBorder3.TabIndex = 4
        '
        'PanelBorder4
        '
        Me.PanelBorder4.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.PanelBorder4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelBorder4.Location = New System.Drawing.Point(301, 642)
        Me.PanelBorder4.Name = "PanelBorder4"
        Me.PanelBorder4.Size = New System.Drawing.Size(692, 46)
        Me.PanelBorder4.TabIndex = 4
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(1044, 788)
        Me.Controls.Add(Me.display)
        Me.Controls.Add(Me.PanelBorder4)
        Me.Controls.Add(Me.PanelBorder1)
        Me.Controls.Add(Me.PanelBorder2)
        Me.Controls.Add(Me.PanelBorder3)
        Me.Controls.Add(Me.PanelDown)
        Me.Controls.Add(Me.PanelLft)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Form1"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.display, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents _fpstimer As System.Windows.Forms.Timer
    Friend WithEvents PanelLft As System.Windows.Forms.Panel
    Friend WithEvents PanelDown As System.Windows.Forms.Panel
    Friend WithEvents display As System.Windows.Forms.PictureBox
    Friend WithEvents PanelBorder1 As System.Windows.Forms.Panel
    Friend WithEvents PanelBorder2 As System.Windows.Forms.Panel
    Friend WithEvents PanelBorder3 As System.Windows.Forms.Panel
    Friend WithEvents PanelBorder4 As System.Windows.Forms.Panel

End Class
