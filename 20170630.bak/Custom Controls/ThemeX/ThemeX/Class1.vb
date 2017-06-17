Imports System.Drawing.Text
Imports System.Drawing.Drawing2D
Imports System.ComponentModel

Enum MouseState As Byte
    None = 0
    Over = 1
    Down = 2
    Block = 3
    Hover = 4
End Enum

<DefaultEvent("Click")>
Public Class ButtonX
    Inherits Control

    
    Private State As MouseState = MouseState.None
    Private SColor As Color

    <Category("Appearance")>
   <DefaultValue(0)> _
    Public Property StripColor() As Color
        Get
            Return SColor
        End Get

        Set(ByVal C As Color)
            SColor = C
            Invalidate()
        End Set

    End Property

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
                ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer Or _
                ControlStyles.SupportsTransparentBackColor, True)
        DoubleBuffered = True
        Size = New Size(125, 50)
        SColor = Color.FromArgb(255, 58, 85, 142)
        BackColor = Color.FromArgb(255, 33, 33, 33)
        ForeColor = Color.FromArgb(242, 242, 242)
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim _Font As Font = New Font(FontFamily.GenericSansSerif, CSng(Me.Height / 5), FontStyle.Bold)
        Dim d As Integer = 22
        Dim bru As Brush

        If State = MouseState.Over Or State = MouseState.Down Then
            bru = New SolidBrush(SColor)
        Else
            bru = New SolidBrush(BackColor)
        End If


        Dim bru2 As Brush = New SolidBrush(SColor)

        Dim txtSize As SizeF = e.Graphics.MeasureString(Text, _Font)
        Dim B As New Bitmap(Width, Height)
        Dim G = Graphics.FromImage(B)

        With G
            .TextRenderingHint = TextRenderingHint.AntiAliasGridFit
            .SmoothingMode = SmoothingMode.HighQuality
            .PixelOffsetMode = PixelOffsetMode.HighQuality
            .Clear(Parent.BackColor)

            .FillPie(bru, 0, 0, d, d, 180, 90)
            .FillPie(bru, Width - d, 0, d, d, 270, 90)
            .FillPie(bru2, 0, Height - d, d, d, 90, 90)
            .FillPie(bru2, Width - d, Height - d, d, d, 0, 90)

            'Up
            .FillRectangle(bru, Convert.ToSingle(d / 2), 0, Width - d, Convert.ToSingle(d / 2))

            .FillRectangle(bru, 0, Convert.ToSingle(d / 2), Width, Convert.ToSingle((Height * 9.1 / 10) - d))
            .FillRectangle(bru2, 0, Convert.ToSingle((Height * 9 / 10) - (d / 2)), Width, Convert.ToSingle(Height / 10))

            'Down
            .FillRectangle(bru2, Convert.ToSingle(d / 2), Convert.ToSingle(Height - d / 2), Convert.ToSingle(Width - d), Convert.ToSingle(d / 2))

            .DrawString(Text, _Font, New SolidBrush(ForeColor), (Width - txtSize.Width) / 2, (Height - txtSize.Height - d) / 2)
        End With

        MyBase.OnPaint(e)
        e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic
        e.Graphics.DrawImageUnscaled(B, 0, 0)
        B.Dispose()
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        State = MouseState.Down
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As Windows.Forms.MouseEventArgs)
        MyBase.OnMouseMove(e)
        State = MouseState.Over
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As Windows.Forms.MouseEventArgs)
        MyBase.OnMouseUp(e)
        State = MouseState.Over
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseLeave(ByVal e As EventArgs)
        MyBase.OnMouseLeave(e)
        State = MouseState.None
        Invalidate()
    End Sub

End Class

<DefaultEvent("Paint")>
Public Class PanelX
    Inherits Panel

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
                ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer Or _
                ControlStyles.SupportsTransparentBackColor, True)
        DoubleBuffered = True
        Size = New Size(200, 150)
        BackColor = Color.FromArgb(255, 44, 47, 52)
        ForeColor = Color.White
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim d As Integer = 12
        Dim bru As Brush = New SolidBrush(BackColor)

        Dim B As New Bitmap(Width, Height)
        Dim G = Graphics.FromImage(B)

        With G
            .TextRenderingHint = TextRenderingHint.AntiAliasGridFit
            .SmoothingMode = SmoothingMode.HighQuality
            .PixelOffsetMode = PixelOffsetMode.HighQuality
            .Clear(Parent.BackColor)
            .FillPie(bru, 0, 0, d, d, 180, 90)
            .FillPie(bru, Width - d, 0, d, d, 270, 90)
            .FillPie(bru, 0, Height - d, d, d, 90, 90)
            .FillPie(bru, Width - d, Height - d, d, d, 0, 90)
            .FillRectangle(bru, CInt(d / 2), 0, Width - d, CInt(d / 2))
            .FillRectangle(bru, 0, CInt(d / 2), Width, CInt(Height - d))
            .FillRectangle(bru, CInt(d / 2), CInt(Height - d / 2), CInt(Width - d), CInt(d / 2))
        End With

        MyBase.OnPaint(e)
        e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic
        e.Graphics.DrawImageUnscaled(B, 0, 0)
        B.Dispose()
    End Sub

End Class

Public Class TextBoxX
    Inherits Control

#Region "Declarations"
    Private State As MouseState = MouseState.None
    Private WithEvents TB As Windows.Forms.TextBox
    Private _BaseColour As Color = Color.FromArgb(255, 33, 33, 33)
    Private _TextColour As Color = Color.FromArgb(242, 242, 242)
    Private _BorderColour As Color = Color.FromArgb(27, 183, 110)
    Private _TextAlign As HorizontalAlignment = HorizontalAlignment.Left
    Private _MaxLength As Integer = 32767
    Private _ReadOnly As Boolean
    Private _UseSystemPasswordChar As Boolean
    Private _Multiline As Boolean
    Private _Focused As Boolean
#End Region

#Region "TextBox Properties"

    Enum Styles
        Rounded
    End Enum

    <Category("Options")>
    Property TextAlign() As HorizontalAlignment
        Get
            Return _TextAlign
        End Get
        Set(ByVal value As HorizontalAlignment)
            _TextAlign = value
            If TB IsNot Nothing Then
                TB.TextAlign = value
            End If
        End Set
    End Property

    <Category("Options")>
    Property MaxLength() As Integer
        Get
            Return _MaxLength
        End Get
        Set(ByVal value As Integer)
            _MaxLength = value
            If TB IsNot Nothing Then
                TB.MaxLength = value
            End If
        End Set
    End Property

    <Category("Options")>
    Property [ReadOnly]() As Boolean
        Get
            Return _ReadOnly
        End Get
        Set(ByVal value As Boolean)
            _ReadOnly = value
            If TB IsNot Nothing Then
                TB.ReadOnly = value
            End If
        End Set
    End Property

    <Category("Options")>
    Property UseSystemPasswordChar() As Boolean
        Get
            Return _UseSystemPasswordChar
        End Get
        Set(ByVal value As Boolean)
            _UseSystemPasswordChar = value
            If TB IsNot Nothing Then
                TB.UseSystemPasswordChar = value
            End If
        End Set
    End Property

    <Category("Options")>
    Property Multiline() As Boolean
        Get
            Return _Multiline
        End Get
        Set(ByVal value As Boolean)
            _Multiline = value
            If TB IsNot Nothing Then
                TB.Multiline = value

                If value Then
                    TB.Height = Height - 11
                Else
                    Height = TB.Height + 11
                End If

            End If
        End Set
    End Property

    <Category("Options")>
    Overrides Property Text As String
        Get
            Return MyBase.Text
        End Get
        Set(ByVal value As String)
            MyBase.Text = value
            If TB IsNot Nothing Then
                TB.Text = value
            End If
        End Set
    End Property

    <Category("Options")>
    Overrides Property Font As Font
        Get
            Return MyBase.Font
        End Get
        Set(ByVal value As Font)
            MyBase.Font = value
            If TB IsNot Nothing Then
                TB.Font = value
                TB.Location = New Point(3, 5)
                TB.Width = Width - 6

                If Not _Multiline Then
                    Height = TB.Height + 11
                End If
            End If
        End Set
    End Property

    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()
        If Not Controls.Contains(TB) Then
            Controls.Add(TB)
        End If
    End Sub

    Private Sub OnBaseTextChanged(ByVal s As Object, ByVal e As EventArgs)
        Text = TB.Text
    End Sub

    Private Sub OnBaseKeyDown(ByVal s As Object, ByVal e As KeyEventArgs)
        If e.Control AndAlso e.KeyCode = Keys.A Then
            TB.SelectAll()
            e.SuppressKeyPress = True
        End If
        If e.Control AndAlso e.KeyCode = Keys.C Then
            TB.Copy()
            e.SuppressKeyPress = True
        End If
    End Sub

    Protected Overrides Sub OnResize(ByVal e As EventArgs)
        TB.Location = New Point(5, 5)
        TB.Width = Width - 10

        If _Multiline Then
            TB.Height = Height - 11
        Else
            Height = TB.Height + 11
        End If

        MyBase.OnResize(e)
    End Sub

    Public Sub SelectAll()
        TB.Focus()
        TB.SelectAll()
    End Sub


#End Region

#Region "Colour Properties"

    <Category("Colours")>
    Public Property BackgroundColor As Color
        Get
            Return _BaseColour
        End Get
        Set(ByVal value As Color)
            _BaseColour = value
        End Set
    End Property

    <Category("Colours")>
    Public Property TextColor As Color
        Get
            Return _TextColour
        End Get
        Set(ByVal value As Color)
            _TextColour = value
        End Set
    End Property

    <Category("Colours")>
    Public Property BorderColor As Color
        Get
            Return _BorderColour
        End Get
        Set(ByVal value As Color)
            _BorderColour = value
        End Set
    End Property

#End Region

#Region "Mouse States"

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        State = MouseState.Down : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        State = MouseState.Over : TB.Focus() : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseLeave(ByVal e As EventArgs)
        MyBase.OnMouseLeave(e)
        State = MouseState.None : Invalidate()
    End Sub

#End Region

    Protected Overrides Sub OnEnter(ByVal e As System.EventArgs)
        MyBase.OnEnter(e)
        _Focused = True
        Me.Invalidate()
    End Sub

    Protected Overrides Sub OnLeave(ByVal e As System.EventArgs)
        MyBase.OnLeave(e)
        _Focused = False
        Me.Invalidate()
    End Sub

#Region "Draw Control"
    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
                 ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer Or _
                 ControlStyles.SupportsTransparentBackColor, True)
        DoubleBuffered = True
        BackColor = Color.Transparent
        TB = New Windows.Forms.TextBox
        TB.Height = 190
        TB.Font = New Font("Segoe UI", 10)
        TB.Text = Text
        TB.BackColor = Color.FromArgb(255, 33, 33, 33)
        TB.ForeColor = Color.FromArgb(242, 242, 242)
        TB.MaxLength = _MaxLength
        TB.Multiline = False
        TB.ReadOnly = _ReadOnly
        TB.UseSystemPasswordChar = _UseSystemPasswordChar
        TB.BorderStyle = BorderStyle.None
        TB.Location = New Point(5, 5)
        TB.Width = Width - 35
        AddHandler TB.TextChanged, AddressOf OnBaseTextChanged
        AddHandler TB.KeyDown, AddressOf OnBaseKeyDown
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim B As New Bitmap(Width, Height)
        Dim G = Graphics.FromImage(B)
        Dim d As Integer = 12
        With G
            .TextRenderingHint = TextRenderingHint.ClearTypeGridFit
            .SmoothingMode = SmoothingMode.HighQuality
            .PixelOffsetMode = PixelOffsetMode.HighQuality
            .Clear(BackColor)
            TB.BackColor = _BaseColour
            TB.ForeColor = _TextColour
            Dim brush1 As Brush = New SolidBrush(_BaseColour)
            Dim pen1 As Pen

            .FillPie(brush1, 0, 0, d, d, 180, 90)
            .FillPie(brush1, Width - d, 0, d, d, 270, 90)
            .FillPie(brush1, 0, Height - d, d, d, 90, 90)
            .FillPie(brush1, Width - d, Height - d, d, d, 0, 90)
            .FillRectangle(brush1, CInt(d / 2), 0, Width - d, CInt(d / 2))
            .FillRectangle(brush1, 0, CInt(d / 2), Width, CInt(Height - d))
            .FillRectangle(brush1, CInt(d / 2), CInt(Height - d / 2), CInt(Width - d), CInt(d / 2))


            If _Focused = True Then
                pen1 = New Pen(_BorderColour, 2)
            Else
                pen1 = New Pen(_BaseColour, 2)
            End If

            .DrawArc(pen1, 0, 0, d, d, 180, 90)
            .DrawLine(pen1, CInt(d / 2), 0, CInt(Width - d / 2), 0)
            .DrawArc(pen1, Width - d, 0, d, d, 270, 90)
            .DrawLine(pen1, 0, CInt(d / 2), 0, CInt(Height - d / 2))
            .DrawLine(pen1, CInt(Width), CInt(d / 2), CInt(Width), CInt(Height - d / 2))
            .DrawLine(pen1, CInt(d / 2), CInt(Height), CInt(Width - d / 2), CInt(Height))
            .DrawArc(pen1, 0, Height - d, d, d, 90, 90)
            .DrawArc(pen1, Width - d, Height - d, d, d, 0, 90)



        End With
        MyBase.OnPaint(e)
        G.Dispose()
        e.Graphics.InterpolationMode = 7
        e.Graphics.DrawImageUnscaled(B, 0, 0)
        B.Dispose()
    End Sub

#End Region

End Class

Public Class CheckBoxX
    Inherits Control

#Region "Declarations"
    Private State As MouseState = MouseState.None
    Private Checked_ As Boolean = False
    Private color1_, color2_ As Color
    Event CheckedChanged(ByVal sender As Object)
#End Region

#Region "Mouse States"

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        State = MouseState.Down : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        State = MouseState.Over : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseLeave(ByVal e As EventArgs)
        MyBase.OnMouseLeave(e)
        State = MouseState.None : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseEnter(ByVal e As EventArgs)
        MyBase.OnMouseEnter(e)
        State = MouseState.Hover
        Invalidate()
    End Sub
#End Region

    Public Property Checked() As Boolean
        Get
            Return Checked_
        End Get
        Set(ByVal value As Boolean)
            Checked_ = value
            RaiseEvent CheckedChanged(Me)
            Invalidate()
        End Set
    End Property

    Protected Overrides Sub OnClick(ByVal e As EventArgs)
        MyBase.OnClick(e)
        If Not Checked_ Then
            Checked = True
        Else
            Checked = False
        End If
    End Sub

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
                ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer Or _
                ControlStyles.SupportsTransparentBackColor, True)
        DoubleBuffered = True
        Size = New Size(18, 18)
        color1_ = Color.FromArgb(96, 137, 229)
        color2_ = Color.FromArgb(76, 112, 176)
        BackColor = Color.FromArgb(255, 44, 47, 52)
        ForeColor = Color.White
    End Sub

    <Category("Colours")>
    Public Property Color1 As Color
        Get
            Return color1_
        End Get
        Set(ByVal value As Color)
            color1_ = value
        End Set
    End Property

    <Category("Colours")>
    Public Property Color2 As Color
        Get
            Return color2_
        End Get
        Set(ByVal value As Color)
            color2_ = value
        End Set
    End Property

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim p As Pen 
        Dim tria() As Point
        Dim d As Integer = 6
        Dim B As New Bitmap(Width, Height)
        Dim G = Graphics.FromImage(B)
        Dim x As Integer = 4
        Dim txtSize As SizeF = e.Graphics.MeasureString(Me.Text, Me.Font)

        Me.Size = New Point(txtSize.ToSize.Width + 18, txtSize.Height + 4)

        With G
            .TextRenderingHint = TextRenderingHint.AntiAliasGridFit
            .SmoothingMode = SmoothingMode.HighQuality
            .PixelOffsetMode = PixelOffsetMode.HighQuality
            .Clear(Parent.BackColor)


            If State = MouseState.Hover Or State = MouseState.Down Then
                x = 3
            Else
                x = 4
            End If

            p = New Pen(Color.FromArgb(173, 173, 173), 1)
            Dim r As Rectangle = New Rectangle(1, 1, 16, 16)

            .DrawArc(p, r.X, r.Y, d, d, 180, 90)
            .DrawLine(p, CInt(r.X + d / 2), r.Y, CInt(r.X + r.Width - d / 2), r.Y)
            .DrawArc(p, r.X + r.Width - d, r.Y, d, d, 270, 90)
            .DrawLine(p, r.X, CInt(r.Y + d / 2), r.X, CInt(r.Y + r.Height - d / 2))
            .DrawLine(p, CInt(r.X + r.Width), CInt(r.Y + d / 2), CInt(r.X + r.Width), CInt(r.Y + r.Height - d / 2))
            .DrawLine(p, CInt(r.X + d / 2), CInt(r.Y + r.Height), CInt(r.X + r.Width - d / 2), CInt(r.Y + r.Height))
            .DrawArc(p, r.X, r.Y + r.Height - d, d, d, 90, 90)
            .DrawArc(p, r.X + r.Width - d, r.Y + r.Height - d, d, d, 0, 90)

            If Checked_ = True Then
                tria = {New Point(x, x), New Point(18 - x, x), New Point(x, Height - x)}
                .FillPolygon(New SolidBrush(color1_), tria)
                tria = {New Point(18 - x, x), New Point(18 - x, Height - x), New Point(x, Height - x)}
                .FillPolygon(New SolidBrush(Color2), tria)
            Else
                If State = MouseState.Hover Then
                    tria = {New Point(x, x), New Point(18 - x, x), New Point(x, Height - x)}
                    .FillPolygon(New SolidBrush(color1_), tria)
                    tria = {New Point(18 - x, x), New Point(18 - x, Height - x), New Point(x, Height - x)}
                    .FillPolygon(New SolidBrush(Color2), tria)
                End If
            End If

            .DrawString(Text, Me.Font, New SolidBrush(Color.FromArgb(242, 242, 242)), New Point(21, (Height - txtSize.Height) / 2))
        End With

        MyBase.OnPaint(e)
        e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic
        e.Graphics.DrawImageUnscaled(B, 0, 0)
        B.Dispose()
    End Sub

End Class

