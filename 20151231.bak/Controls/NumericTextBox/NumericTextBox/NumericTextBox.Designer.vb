Imports System.ComponentModel

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NumericTextBox
    Inherits System.Windows.Forms.TextBox

    ' Creates the private variable that will store the value of your property.
    Private MaxVal As Integer = 100
    Private MinVal As Integer = 0

    ' Declares the property.
    <Description("Specifies the maximum numeric value that can be entered into the edit control.")> _
    <Category("Behavior")> _
    <DefaultValue(100)> _
    Property MaximumValue() As Integer
        ' Sets the method for retrieving the value of your property.
        Get
            Return MaxVal
        End Get
        ' Sets the method for setting the value of your property.
        Set(ByVal Value As Integer)
            If Value <= MinVal Then
                MsgBox("MaximumValue cannot be smaller than the MinimumValue.", MsgBoxStyle.Exclamation, "Properties Window")
                MaxVal = 100
            ElseIf Value = MinVal Then
                MsgBox("MaximumValue cannot be equal to MinimumValue.", MsgBoxStyle.Exclamation, "Properties Window")
                MinVal = 0
            Else
                MaxVal = Value
            End If
        End Set
    End Property

    ' Declares the property.
    <Description("Specifies the minimum numeric value that can be entered into the edit control.")> _
    <Category("Behavior")>
    <DefaultValue(0)> _
    Property MinimumValue() As Integer
        ' Sets the method for retrieving the value of your property.
        Get
            Return MinVal
        End Get
        ' Sets the method for setting the value of your property.
        Set(ByVal Value As Integer)
            If MaxVal < Value Then
                MsgBox("MinimumValue cannot be greater than  the MaximumValue.", MsgBoxStyle.Exclamation, "Properties Window")
                MinVal = 0
            ElseIf MaxVal = Value Then
                MsgBox("MinimumValue cannot be equal to MaximumValue.", MsgBoxStyle.Exclamation, "Properties Window")
                MinVal = 0
            Else
                MinVal = Value
            End If
        End Set
    End Property

    'UserControl overrides dispose to clean up the component list.
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
        components = New System.ComponentModel.Container()
    End Sub

End Class
