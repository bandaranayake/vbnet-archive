Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
Imports System.Drawing.Imaging
Imports System.ComponentModel
Imports System.ComponentModel.Design

Public Class Form1


    Private Sub Form1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Click
        'For Each c In Controls
        '    c._focused = False
        '    c.Invalidate()
        'Next
    End Sub

    Private Sub Form1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.ControlKey Then
            _multi = False
        End If
    End Sub

    Private Sub Form1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.ControlKey Then
            _multi = True
        End If
    End Sub

    Private Sub Form1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        Dim g As Graphics = e.Graphics
        g.Clear(BackColor)
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias

        Dim cX, cY As Integer

        With g


            For Each c As Object In Me.Controls
                cX = c.Location.X
                cY = c.Location.Y


                'If c._Edge = Edges.BottomLeft Then
                '    .FillPolygon(Brushes.DarkOrange, {New Point(Width - 13, Height - 13), New Point(Width - 13, Height - 30), New Point(Width - 30, Height - 13)})
                'Else
                '    .FillPolygon(Brushes.DarkOrange, {New Point(Width - 15, Height - 15), New Point(Width - 15, Height - 30), New Point(Width - 30, Height - 15)})
                'End If


                If c._Edge = Edges.Top Then
                    .FillRectangle(Brushes.DarkOrange, cX + CInt(c.Width / 2) - 7, cY - 13, 12, 12)
                Else
                    .FillRectangle(Brushes.DarkOrange, cX + CInt(c.Width / 2) - 6, cY - 11, 10, 10)
                End If

                'If c._Edge = Edges.Left Then
                '    .FillRectangle(Brushes.DarkOrange, 4, CInt(Height / 2 - 6), 12, 12)
                ' Else
                '    .FillRectangle(Brushes.DarkOrange, 5, CInt(Height / 2 - 5), 10, 10)
                'End If

                'If c._Edge = Edges.Bottom Then
                '    .FillRectangle(Brushes.DarkOrange, CInt(Width / 2 - 6), CInt(Height - 16), 12, 12)
                'Else
                '    .FillRectangle(Brushes.DarkOrange, CInt(Width / 2 - 5), CInt(Height - 15), 10, 10)
                'End If

                'If c._Edge = Edges.Right Then
                '    .FillRectangle(Brushes.DarkOrange, CInt(Width - 16), CInt(Height / 2 - 6), 12, 12)
                'Else
                '    .FillRectangle(Brushes.DarkOrange, CInt(Width - 15), CInt(Height / 2 - 5), 10, 10)
                'End If

            Next

        End With

    End Sub
  
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True
    End Sub


End Class

Public Enum Edges
    None
    Right
    Left
    Top
    Bottom
    BottomLeft
End Enum

Public Class oo
    Inherits Control

    Public _focused As Boolean
    Public _Edge As Edges = Edges.None
    Private _MouseDown As Boolean
    Public _connect As Boolean

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        MyBase.OnMouseDown(e)

        If Me.Enabled AndAlso Not Me.Focused Then
            Me.Focus()
        End If

        _MouseDown = True

        If _focused = False Then
            If _multi = False Then
                For Each c In Parent.Controls
                    c._focused = False
                    c.Invalidate()
                Next
            End If

            _focused = True
        Else
            If _multi = True Then
                _focused = False
            End If

        End If


        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        _MouseDown = False
        _Edge = Edges.None
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        Parent.Invalidate()
        If _MouseDown And _Edge = Edges.None Then
            Cursor = Cursors.SizeAll
            Dim mousePos = Point.Add(e.Location, Location)
            mousePos = Point.Subtract(mousePos, New Point(5 + Width / 2, 5 + Height / 2))
            Location = mousePos
        ElseIf _MouseDown And _Edge <> Edges.None Then
            If _focused = True Then
                SuspendLayout()

                Select Case _Edge
                    Case Edges.Left
                        SetBounds(Left + e.X, Top, Width - e.X, Height)
                    Case Edges.Right
                        SetBounds(Left, Top, e.X, Height)
                    Case Edges.Top
                        SetBounds(Left, Top + e.Y, Width, Height - e.Y)
                    Case Edges.Bottom
                        SetBounds(Left, Top, Width, e.Y)
                    Case Edges.BottomLeft
                        SetBounds(Left, Top, e.X, e.Y)
                End Select
                If Width < 80 Then
                    Width = 80
                End If
                If Height < 80 Then
                    Height = 80
                End If
                ResumeLayout()
            End If
        Else
            Select Case True
                Case (e.Y >= Height - 30 And e.Y <= Height - 10) And (e.X >= Width - 30 And e.X <= Width - 10)
                    Cursor = Cursors.PanSE
                    _Edge = Edges.BottomLeft
                Case (e.X <= 11 And e.X >= 9)
                    Cursor = Cursors.SizeWE
                    _Edge = Edges.Left
                Case (e.X >= Width - 11 And e.X <= Width - 9)
                    Cursor = Cursors.SizeWE
                    _Edge = Edges.Right
                Case (e.Y <= 11 And e.Y >= 9)
                    Cursor = Cursors.SizeNS
                    _Edge = Edges.Top
                Case e.Y >= Height And e.Y <= Height
                    Cursor = Cursors.SizeNS
                    _Edge = Edges.Bottom
                Case Else
                    Cursor = Cursors.Default
                    _Edge = Edges.None
            End Select
        End If

        Invalidate()
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

            '.FillRectangle(Brushes.White, 0, 0, Width, Height)
         
            If _focused = True Then
                .DrawRectangle(New Pen(Color.DarkOrange, 1), 0, 0, Width, Height)

                '        If _connect = True Then
                '            .FillEllipse(Brushes.White, 1, 1, 6, 6)
                '            .DrawEllipse(Pens.Black, 1, 1, 6, 6)

                '            .FillEllipse(Brushes.White, CInt(Width / 2 - 3), 1, 6, 6)
                '            .DrawEllipse(Pens.Black, CInt(Width / 2 - 3), 1, 6, 6)

                '            .FillEllipse(Brushes.White, CInt(Width - 7), 1, 6, 6)
                '            .DrawEllipse(Pens.Black, CInt(Width - 7), 1, 6, 6)

                '            .FillEllipse(Brushes.White, 1, CInt(Height / 2 - 3), 6, 6)
                '            .DrawEllipse(Pens.Black, 1, CInt(Height / 2 - 3), 6, 6)

                '            .FillEllipse(Brushes.White, 1, CInt(Height - 7), 6, 6)
                '            .DrawEllipse(Pens.Black, 1, CInt(Height - 7), 6, 6)

                '            .FillEllipse(Brushes.White, CInt(Width / 2 - 3), CInt(Height - 7), 6, 6)
                '            .DrawEllipse(Pens.Black, CInt(Width / 2 - 3), CInt(Height - 7), 6, 6)

                '            .FillEllipse(Brushes.White, CInt(Width - 7), CInt(Height / 2 - 3), 6, 6)
                '            .DrawEllipse(Pens.Black, CInt(Width - 7), CInt(Height / 2 - 3), 6, 6)
                '        Else
                '          
            Else
                .DrawRectangle(New Pen(Color.FromArgb(117, 193, 155), 1), 0, 0, Width, Height)
            End If



        End With

        MyBase.OnPaint(e)
        G.Dispose()
        e.Graphics.InterpolationMode = 7
        e.Graphics.DrawImageUnscaled(B, 0, 0)
        B.Dispose()
    End Sub

    Protected Overrides Sub OnLocationChanged(ByVal e As System.EventArgs)
        MyBase.OnLocationChanged(e)
    End Sub

    Protected Overrides Sub OnKeyDown(ByVal e As System.Windows.Forms.KeyEventArgs)
        MyBase.OnKeyDown(e)
        If e.KeyCode = Keys.ControlKey Then
            _multi = True
        End If
    End Sub

    Protected Overrides Sub OnKeyUp(ByVal e As System.Windows.Forms.KeyEventArgs)
        MyBase.OnKeyUp(e)
        If e.KeyCode = Keys.ControlKey Then
            _multi = False
        End If
    End Sub

    Private Function PointIsInPolygon(ByVal target_point As Point) As Boolean
        Dim path As New GraphicsPath()

        path.AddEllipse(1, 1, 6, 6)
        path.AddEllipse(CInt(Width / 2 - 3), 1, 6, 6)
        path.AddEllipse(CInt(Width - 7), 1, 6, 6)
        path.AddEllipse(1, CInt(Height / 2 - 3), 6, 6)
        path.AddEllipse(CInt(Width - 7), CInt(Height - 7), 6, 6)
        path.AddEllipse(1, CInt(Height - 7), 6, 6)
        path.AddEllipse(CInt(Width / 2 - 3), CInt(Height - 7), 6, 6)
        path.AddEllipse(CInt(Width - 7), CInt(Height / 2 - 3), 6, 6)

        Return path.IsVisible(target_point)
    End Function

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
                 ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer Or _
                 ControlStyles.SupportsTransparentBackColor, True)
        DoubleBuffered = True
        BackColor = Color.Transparent
        _focused = False
    End Sub

End Class