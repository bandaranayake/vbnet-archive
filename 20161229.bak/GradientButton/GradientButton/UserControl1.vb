Imports System.Drawing.Drawing2D

Public Class GradientButton
    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim txtSize As SizeF
        txtSize = e.Graphics.MeasureString(Me.Text, Me.Font)


        FillRoundedRectangle(e.Graphics, New Rectangle(0, 0, Me.Size.Width, Me.Size.Height), 12, New SolidBrush(Color.FromArgb(102, 126, 150)))
        FillRoundedRectangle(e.Graphics, New Rectangle(5, 5, Me.Size.Width - 10, Me.Size.Height - 10), 12, New SolidBrush(Color.FromArgb(112, 146, 190)))

        Dim gradientRectangle As RectangleF
        Dim myBrush As Brush
        gradientRectangle = New RectangleF(New PointF(0, 0), txtSize)

        myBrush = New LinearGradientBrush(gradientRectangle, Color.Gold, Color.Red, 3)

        e.Graphics.DrawString(Me.Text, Me.Font, myBrush, (Me.Size.Width + 6 - txtSize.Width) / 2, (Me.Size.Height - txtSize.Height) / 2)

        'e.Graphics.DrawString(Me.Text, Me.Font, Brushes.White, (Me.Width / 2) - txtSize.Width, (Me.Height / 2) - txtSize.Height)
    End Sub

    Public Sub FillRoundedRectangle(ByVal g As Drawing.Graphics, ByVal r As Rectangle, ByVal d As Integer, ByVal b As Brush)
        Dim mode As Drawing2D.SmoothingMode = g.SmoothingMode
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed
        g.FillPie(b, r.X, r.Y, d, d, 180, 90)
        g.FillPie(b, r.X + r.Width - d, r.Y, d, d, 270, 90)
        g.FillPie(b, r.X, r.Y + r.Height - d, d, d, 90, 90)
        g.FillPie(b, r.X + r.Width - d, r.Y + r.Height - d, d, d, 0, 90)
        g.FillRectangle(b, CInt(r.X + d / 2), r.Y, r.Width - d, CInt(d / 2))
        g.FillRectangle(b, r.X, CInt(r.Y + d / 2), r.Width, CInt(r.Height - d))
        g.FillRectangle(b, CInt(r.X + d / 2), CInt(r.Y + r.Height - d / 2), CInt(r.Width - d), CInt(d / 2))
        g.SmoothingMode = mode
    End Sub
End Class
