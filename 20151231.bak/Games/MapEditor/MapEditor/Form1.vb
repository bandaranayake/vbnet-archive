Imports System.IO

Public Class Form1

    Private backBuffer As Image
    Private gfx As Graphics
    Private block As Array = Array.CreateInstance(GetType(Integer), 21, 18)

    Private tiles As New List(Of Bitmap)
    Private canAdd As Boolean = False
    Private AccessPointAdd As Boolean = False
    Private CtrlPressed As Boolean = False
    Private i As Integer = -1

    Private AccessPointX As Integer = 0
    Private AccessPointY As Integer = 0

    Private Sub PictureBox1_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Editor.MouseClick
        If canAdd Then
            Dim remainder As Double
            Dim x, y As Integer

            remainder = (e.Location.X Mod 32) / 32
            x = (e.Location.X / 32) - remainder

            remainder = (e.Location.Y Mod 32) / 32
            y = (e.Location.Y / 32) - remainder

            block.SetValue(i, x, y)

            If CtrlPressed = False Then
                For Each c In GroupBox1.Controls
                    If TypeOf c Is Button Then
                        c.FlatAppearance.BorderColor = Color.Black
                    End If
                Next

                canAdd = False
                Me.Cursor = Cursors.Arrow
            End If

        End If

        If AccessPointAdd Then
            Dim remainder As Double
            Dim x, y As Integer

            remainder = (e.Location.X Mod 32) / 32
            x = (e.Location.X / 32) - remainder

            remainder = (e.Location.Y Mod 32) / 32
            y = (e.Location.Y / 32) - remainder

            AccessPointX = x
            AccessPointY = y

            AccessPointAdd = False
            Me.Cursor = Cursors.Arrow
        End If

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim c As Control
        Dim btn As Button

        For v = 0 To 14
            tiles.Add(New Bitmap(My.Computer.FileSystem.CurrentDirectory + "\data\f" & v & ".png"))

            For Each c In GroupBox1.Controls
                If TypeOf c Is Button Then
                    If c.Name = "btn" & v Then
                        btn = c
                        btn.Tag = v
                        AddHandler btn.Click, AddressOf btn_MouseClick
                    End If
                End If
            Next

        Next

        For x = 0 To 20
            For y = 0 To 17
                block.SetValue(11, x, y)
            Next
        Next

    End Sub

    Private Sub Form1_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Render()
    End Sub

    Private Sub Render()
        Do While (Me.Created)
            setImage()
            Application.DoEvents()
        Loop
    End Sub

    Private Sub setImage()
        backBuffer = New Bitmap(Editor.ClientSize.Width, Editor.ClientSize.Height)
        gfx = Graphics.FromImage(backBuffer)
        Editor.Image = Nothing

        Dim t1, t2 As Integer

        For x = 0 To 20
            For y = 0 To 17
                t1 = x * 32
                t2 = y * 32

                gfx.DrawImage(tiles(block.GetValue(x, y)), New Point(t1, t2))
            Next
        Next


        gfx.DrawImage(Image.FromFile(My.Computer.FileSystem.CurrentDirectory + "\data\p.png"), New Point(AccessPointX * 32, AccessPointY * 32))

        For x = 0 To 672 Step 32
            gfx.DrawLine(New Pen(Brushes.Red, 1), New Point(x, 0), New Point(x, backBuffer.Height))
        Next

        For y = 0 To 576 Step 32
            gfx.DrawLine(New Pen(Brushes.Red, 1), New Point(0, y), New Point(backBuffer.Width, y))
        Next


        Editor.Image = backBuffer
    End Sub

    Private Sub btn_MouseClick(ByVal sender As Button, ByVal e As System.Windows.Forms.MouseEventArgs)
        For Each c In GroupBox1.Controls
            If TypeOf c Is Button Then
                c.FlatAppearance.BorderColor = Color.Black
            End If
        Next

        Me.Cursor = Cursors.Cross
        canAdd = True
        i = sender.Tag
        sender.FlatAppearance.BorderColor = Color.Gold

        AddHandler sender.KeyDown, AddressOf _KeyDown
        AddHandler sender.KeyUp, AddressOf _KeyUp

    End Sub

    Private Sub _KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.ControlKey Then
            CtrlPressed = True
        End If
    End Sub

    Private Sub _KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.ControlKey Then
            CtrlPressed = False
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim binWriter As New BinaryWriter( _
    File.Open("C:\Users\Isuru\Documents\Visual Studio 2010\Projects\Games\Game2D\Game2D\bin\Debug\levels\lvl" & txtLevel.Text & ".txt", FileMode.Create))
        Try
            For y = 0 To 17
                For x = 0 To 20
                    binWriter.Write(block.GetValue(x, y))
                Next
            Next
            binWriter.Write(AccessPointX)
            binWriter.Write(AccessPointY)

        Finally
            binWriter.Close()
        End Try

    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        End
    End Sub

    Private Sub btnAccessPoint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccessPoint.Click
        AccessPointAdd = True
        Me.Cursor = Cursors.Cross
    End Sub

    Private Sub btnFill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFill.Click
        If RbtnNull.Checked Then
            For x = 0 To 20
                For y = 0 To 17
                    block.SetValue(0, x, y)
                Next
            Next
        Else
            For x = 0 To 20
                For y = 0 To 17
                    block.SetValue(11, x, y)
                Next
            Next
        End If
    End Sub

End Class
