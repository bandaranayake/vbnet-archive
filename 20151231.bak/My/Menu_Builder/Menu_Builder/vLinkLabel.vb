Imports System.ComponentModel

Public Class vLinkLabel
    Inherits LinkLabel

    Public MA As Boolean = False

    <Browsable(False)> _
    Public Property ToolbarColor() As Boolean
        Get
            Return MA
        End Get
        Set(ByVal Value As Boolean)
            MA = Value
        End Set
    End Property
End Class
