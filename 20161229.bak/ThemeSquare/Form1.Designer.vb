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
    	Me.squareX1 = New WindowsApplication1.SquareX()
    	Me.squareButton1 = New WindowsApplication1.SquareButton()
    	Me.SuspendLayout
    	'
    	'squareX1
    	'
    	Me.squareX1.Location = New System.Drawing.Point(267, 50)
    	Me.squareX1.Name = "squareX1"
    	Me.squareX1.Size = New System.Drawing.Size(100, 100)
    	Me.squareX1.TabIndex = 0
    	Me.squareX1.Text = "squareX1"
    	'
    	'squareButton1
    	'
    	Me.squareButton1.Location = New System.Drawing.Point(246, 66)
    	Me.squareButton1.Name = "squareButton1"
    	Me.squareButton1.Size = New System.Drawing.Size(100, 60)
    	Me.squareButton1.TabIndex = 1
    	Me.squareButton1.Text = "squareButton1"
    	'
    	'Form1
    	'
    	Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
    	Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    	Me.ClientSize = New System.Drawing.Size(591, 481)
    	Me.Controls.Add(Me.squareButton1)
    	Me.Controls.Add(Me.squareX1)
    	Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
    	Me.Name = "Form1"
    	Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    	Me.Text = "Form1"
    	Me.TransparencyKey = System.Drawing.Color.Fuchsia
    	Me.ResumeLayout(false)
    End Sub
    Private squareButton1 As WindowsApplication1.SquareButton
    Private squareX1 As WindowsApplication1.SquareX
End Class
