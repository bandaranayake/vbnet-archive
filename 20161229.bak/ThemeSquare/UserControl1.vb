Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.ComponentModel
Imports System.Drawing.Text
Imports System.Threading 

Enum MouseState
	None = 0
	Hover = 1
	Down = 2
	
	Over
	
End Enum

Class SquareButton
	Inherits Control
	
	Private MState As MouseState = MouseState.None
	
	Sub New()
		Size = New Size(100,60)
	End Sub
	
	Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
		MyBase.OnPaint(e)
		
		Dim x, y, h, w As Integer
		Dim mypen() As Pen = {New Pen(Color.FromArgb(70, 32, 102),2), New Pen(Color.FromArgb(255, 184, 95)), New Pen(Color.FromArgb(255, 122, 90),2), New Pen(Color.FromArgb(0, 170, 160))}
		Dim txtSize As SizeF
		txtSize = e.Graphics.MeasureString(Me.Text, Me.Font)
		
		h = (Me.Height / 2)
		w = Me.Width - 1
		x = 0
		y = ((Me.Height - h) / 2)-1
		
		For i As Integer= 1 To 4
			x=x+(i*Me.width/100)
			y=y-(i*Me.Height/42)
			w=w-(i*Me.width/50)
			h=h+(i*Me.Height/21)
			
			Select Case MState
				Case MouseState.Hover
					e.Graphics.DrawRectangle(mypen(4-i), New Rectangle(x, y, w, h))
				Case MouseState.Down
					e.Graphics.DrawRectangle(New pen(mypen(4-i).Color,3), New Rectangle(x, y, w, h))
				Case MouseState.None
					e.Graphics.DrawRectangle(mypen(i-1), New Rectangle(x, y, w, h))
			End Select
			
		Next
		
		
		Dim myBrush As Brush
		myBrush = New System.Drawing.SolidBrush(Color.FromArgb(70, 32, 102))
		e.Graphics.DrawString(Me.Text, Me.Font, myBrush, (Me.Size.Width + 6 - txtSize.Width) / 2, (Me.Size.Height - txtSize.Height) / 2)	
		
	End Sub
	
	Protected Overrides Sub OnMouseEnter(ByVal e As EventArgs)
		MyBase.OnMouseEnter(e)
		MState = MouseState.Hover
		Invalidate()
	End Sub
	
	Protected Overrides Sub OnMouseLeave(ByVal e As EventArgs)
		MyBase.OnMouseLeave(e)
		MState = MouseState.None
		Invalidate()
	End Sub
	
	Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
		MyBase.OnMouseDown(e)
		MState = MouseState.Down
		Invalidate()
	End Sub
	
	Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
		MyBase.OnMouseUp(e)
		MState = MouseState.Hover
		Invalidate()
	End Sub
	
End Class

<DefaultEvent("CheckedChanged")>
Class SquareCheckBox
	Inherits Control
	
	Event CheckedChanged(ByVal sender As Object)
	Private MState As MouseState = MouseState.None
	Private Checked_ As Boolean
	
	Protected Overrides Sub OnMouseEnter(ByVal e As EventArgs)
		MyBase.OnMouseEnter(e)
		MState = MouseState.Hover
		Invalidate()
	End Sub
	
	Protected Overrides Sub OnMouseLeave(ByVal e As EventArgs)
		MyBase.OnMouseLeave(e)
		MState = MouseState.None
		Invalidate()
	End Sub
	
	Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
		MyBase.OnMouseDown(e)
		MState = MouseState.Down
		Invalidate()
	End Sub
	
	Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
		MyBase.OnMouseUp(e)
		MState = MouseState.Hover
		Invalidate()
	End Sub
	
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
	
	Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
		MyBase.OnPaint(e)
		
		Dim txtSize As SizeF
		txtSize = e.Graphics.MeasureString(Me.Text, Me.Font)
		
		
		Select Case MState
			Case MouseState.Hover
				e.Graphics.DrawRectangle(New Pen(Color.FromArgb(255, 122, 90)), New Rectangle(0, 4, 16, 8))
				e.Graphics.DrawRectangle(New Pen(Color.FromArgb(0, 170, 160)), New Rectangle(2, 2, 12, 12))
				e.Graphics.DrawRectangle(New Pen(Color.FromArgb(70, 32, 102)), New Rectangle(4, 0, 8, 16))
			Case else
				e.Graphics.DrawRectangle(New Pen(Color.FromArgb(70, 32, 102)), New Rectangle(0, 4, 16, 8))
				e.Graphics.DrawRectangle(New Pen(Color.FromArgb(255, 122, 90)), New Rectangle(2, 2, 12, 12))
				e.Graphics.DrawRectangle(New Pen(Color.FromArgb(0, 170, 160)), New Rectangle(4, 0, 8, 16))
		End Select
		
		If Checked Then
			e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(0, 170, 160)), New Rectangle(6,6, 5, 5))
		End If
		
		Me.Size = New Point(txtSize.ToSize.Width + 20,txtSize.Height +4)
		
		e.Graphics.DrawString(Me.Text, Me.Font , New SolidBrush(Color.FromArgb(70, 32, 102)), New Point(20, 1))
	End Sub
	
End Class

Class SquarePanel
	Inherits ContainerControl
	
	Sub New()
		Size = New Size(200, 100)
	End Sub
	
	Protected Overrides Sub OnPaint(e As PaintEventArgs)
		MyBase.OnPaint(e)
		
		e.Graphics.DrawRectangle(New Pen(Color.FromArgb(255, 122, 90)), New Rectangle(0,0,Me.Width-1, me.height-1))
		e.Graphics.DrawRectangle(New Pen(Color.FromArgb(70, 32, 102)), New Rectangle(Me.Width/100,me.height/100,Me.Width*98/100 , me.height*98/100))
		e.Graphics.DrawRectangle(New Pen(Color.FromArgb(255, 184, 95)), New Rectangle(Me.Width/50,me.height/50,Me.Width*48/50 , me.height*48/50))
		
	End Sub
	
End Class


Class SquareX
	Inherits Control
	
	Private MState As MouseState = MouseState.None
	
	Protected Overrides Sub OnClick(ByVal e As EventArgs)
		MyBase.OnClick(e)
		MState = MouseState.Hover
		Invalidate()
	End Sub
	
	Sub New()
		Size = New Size(100, 100)
	End Sub
	
	Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
		MyBase.OnPaint(e)
		
		If 	MState = MouseState.Hover Then
			
			With e.Graphics
				.TextRenderingHint = TextRenderingHint.AntiAliasGridFit
				.SmoothingMode = SmoothingMode.HighQuality
				.PixelOffsetMode = PixelOffsetMode.HighQuality
				.Clear(BackColor)
			End With
			
			e.Graphics.FillPie(Brushes.Black, New Rectangle(1, 1, Me.Width-2, Me.Height-2),100-1, 270-1)
			e.Graphics.FillPie(New SolidBrush(Me.BackColor), New Rectangle(8, 8,  Me.Width-16, Me.Height-16), 0, 360)
			
			
			For i As Integer = 99 To 200
				e.Graphics.FillPie(New SolidBrush(Color.FromArgb(0, 160, 199)), New Rectangle(1, 1, Me.Width-2, Me.Height-2), 100-1, i)
				e.Graphics.FillPie(New SolidBrush(Me.BackColor), New Rectangle(8, 8,  Me.Width-16, Me.Height-16), 0, 360)
				e.Graphics.DrawString((i - 99), Me.Font, Brushes.White, New Point(Width / 2, Height / 2 - 1), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
				Application.DoEvents()
				
				Thread.Sleep(25)
			Next
			
		End If
		
	End Sub
	
	
End Class