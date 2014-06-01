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
        Me.ImitationWindow1 = New WindowsApplication1.ImitationWindow()
        Me.SuspendLayout()
        '
        'ImitationWindow1
        '
        Me.ImitationWindow1.BackColor = System.Drawing.Color.Azure
        Me.ImitationWindow1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ImitationWindow1.Location = New System.Drawing.Point(79, 27)
        Me.ImitationWindow1.MinimumSize = New System.Drawing.Size(300, 200)
        Me.ImitationWindow1.Name = "ImitationWindow1"
        Me.ImitationWindow1.Size = New System.Drawing.Size(350, 300)
        Me.ImitationWindow1.TabIndex = 0
        Me.ImitationWindow1.Text = "ImitationWindow1"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(545, 403)
        Me.Controls.Add(Me.ImitationWindow1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ImitationWindow1 As WindowsApplication1.ImitationWindow
End Class
