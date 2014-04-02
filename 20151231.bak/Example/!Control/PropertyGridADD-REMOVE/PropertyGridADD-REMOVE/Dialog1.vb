Imports System.ComponentModel

Public Class Dialog1
    Inherits Windows.Forms.Form

    Private _toolbarColor As Color = SystemColors.Control

    '<CategoryAttribute("Global Settings")> _
    'Public Property ToolbarColor() As Color
    '    Get
    '        Return _toolbarColor
    '    End Get
    '    Set(ByVal Value As Color)
    '        _toolbarColor = Value
    '    End Set
    'End Property

    <BrowsableAttribute(False)> _
    Public Overrides Property Forecolor As Color
        Get
        End Get
        Set(ByVal value As Color)
        End Set
    End Property


    Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'Dialog1
        '
        Me.ClientSize = New System.Drawing.Size(284, 262)
        Me.Name = "Dialog1"
        Me.ResumeLayout(False)

    End Sub
End Class
