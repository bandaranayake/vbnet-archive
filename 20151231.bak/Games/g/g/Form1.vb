Public Class Form1
    Dim timer As Stopwatch
    Dim backBuffer As Image
    Dim graphics As Graphics
    Dim clientWidth As Integer
    Dim clientHeight As Integer
    Dim interval As Long
    Dim startTick As Long
    Dim imageRect As Rectangle
    Dim direction As Point

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True
        Me.MaximizeBox = False
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
        timer = New Stopwatch()
        clientWidth = 320
        clientHeight = 320

        interval = 16
        Me.ClientSize = New Size(clientWidth, clientHeight)
        backBuffer = New Bitmap(clientWidth, clientHeight)
        graphics = graphics.FromImage(backBuffer)
        direction = New Point(2, 3)
        imageRect = New Rectangle(0, 0, 55, 55)
    End Sub

    Private Sub Form1_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        GameLoop()
    End Sub

    Private Sub GameLoop()
        timer.Start()
        Do While (Me.Created)
            startTick = timer.ElapsedMilliseconds
            GameLogic()
            RenderScene()
            Application.DoEvents()
            Do While timer.ElapsedMilliseconds - startTick < interval
            Loop
        Loop
    End Sub

    Private Sub GameLogic()
        imageRect.X += direction.X
        imageRect.Y += direction.Y

        If imageRect.X < 0 Then
            imageRect.X = 0
            direction.X *= -1
        End If

        If imageRect.Y < 0 Then
            imageRect.Y = 0
            direction.Y *= -1
        End If

        If imageRect.X + imageRect.Width > clientWidth Then
            imageRect.X = clientWidth - imageRect.Width
            direction.X *= -1
        End If

        If imageRect.Y + imageRect.Height > clientHeight Then
            imageRect.Y = clientHeight - imageRect.Height
            direction.Y *= -1
        End If

    End Sub

    Private Sub RenderScene()
        backBuffer = New Bitmap(clientWidth, clientHeight)
        graphics = graphics.FromImage(backBuffer)
        pbSurface.Image = Nothing

        graphics.FillPie(Brushes.Blue(), imageRect, 0, 360)

        pbSurface.Image = backBuffer
    End Sub

End Class
