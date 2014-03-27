Imports System.ComponentModel

Public Class vButton
    Inherits Button

     Public MA As Boolean
    Public c As Boolean

    Public cmd As String
    Public ad_er As Boolean
    Public ad_e As Boolean

    <BrowsableAttribute(False)> _
    Public Shadows Property AccessibleDescription As String

    <BrowsableAttribute(False)> _
    Public Shadows Property AccessibleName As String

    <BrowsableAttribute(False)> _
    Public Shadows Property AccessibleRole As AccessibleRole

    <BrowsableAttribute(False)> _
    Public Shadows Property AllowDrop As Boolean

    <BrowsableAttribute(False)> _
    Public Shadows Property Anchor As AnchorStyles

    <BrowsableAttribute(False)> _
    Public Shadows Property AutoEllipsis As Boolean

    <BrowsableAttribute(False)> _
    Public Shadows Property AutoSizeMode As AutoSizeMode

    <BrowsableAttribute(False)> _
    Public Shadows Property CausesValidation As Boolean

    '<Browsable(False)> _
    'Public Shadows Property ContextMenuStrip As ContextMenuStrip

    <BrowsableAttribute(False)> _
    Public Shadows Property DataBindings As ControlBindingsCollection

    <BrowsableAttribute(False)> _
    Public Shadows Property DialogResult As DialogResult

    <BrowsableAttribute(False)> _
    Public Shadows Property Enabled As Boolean

    <BrowsableAttribute(False)> _
    Public Shadows Property ImageIndex As Integer

    <BrowsableAttribute(False)> _
    Public Shadows Property ImageKey As String

    <BrowsableAttribute(False)> _
    Public Shadows Property ImageList As ImageList

    <BrowsableAttribute(False)> _
    Public Shadows Property Margin As Padding

    <BrowsableAttribute(False)> _
    Public Shadows Property Padding As Padding

    <BrowsableAttribute(False)> _
    Public Shadows Property Tag As Object

    <BrowsableAttribute(False)> _
    Public Shadows Property UseCompatibleTextRendering As Boolean

    <BrowsableAttribute(False)> _
    Public Shadows Property Visible As Boolean

End Class
