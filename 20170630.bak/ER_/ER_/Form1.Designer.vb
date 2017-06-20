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
        Me.components = New System.ComponentModel.Container()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Oo2 = New WindowsApplication1.oo()
        Me.Oo1 = New WindowsApplication1.oo()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'Oo2
        '
        Me.Oo2.BackColor = System.Drawing.Color.Transparent
        Me.Oo2.Location = New System.Drawing.Point(28, 68)
        Me.Oo2.Name = "Oo2"
        Me.Oo2.Size = New System.Drawing.Size(274, 189)
        Me.Oo2.TabIndex = 1
        Me.Oo2.Text = "Oo2"
        '
        'Oo1
        '
        Me.Oo1.BackColor = System.Drawing.Color.Transparent
        Me.Oo1.Location = New System.Drawing.Point(308, 100)
        Me.Oo1.Name = "Oo1"
        Me.Oo1.Size = New System.Drawing.Size(222, 274)
        Me.Oo1.TabIndex = 0
        Me.Oo1.Text = "Oo1"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(749, 459)
        Me.Controls.Add(Me.Oo2)
        Me.Controls.Add(Me.Oo1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Oo1 As WindowsApplication1.oo
    Friend WithEvents Oo2 As WindowsApplication1.oo

End Class
