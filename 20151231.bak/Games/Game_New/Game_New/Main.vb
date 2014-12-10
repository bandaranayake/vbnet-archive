Imports System.IO

Public Class Main

    Private player As New List(Of Bitmap)
    Private floors As New List(Of Bitmap)

    Private clientWidth As Integer
    Private clientHeight As Integer

    Private backBuffer As Image
    Private gfx As Graphics
    Private pt As Point

    Private Character_ As Integer = 3

    Private Level As Integer

    Private isLoading As Integer = False

    Private block As Array = Array.CreateInstance(GetType(Integer), 21, 18)
    Private block_Visible As Array = Array.CreateInstance(GetType(Boolean), 21, 18)

    Private Barriers As Integer() = ({0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 13})

    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clientWidth = display.ClientSize.Width
        clientHeight = display.ClientSize.Height

        For k = 0 To 14
            floors.Add(Bitmap.FromFile(Environment.CurrentDirectory & "\res\f" & k & ".png"))
        Next

        For k = 0 To 3
            player.Add(Bitmap.FromFile(Environment.CurrentDirectory & "\res\p" & k & ".png"))
        Next

        backBuffer = New Bitmap(clientWidth, clientHeight)
        gfx = Graphics.FromImage(backBuffer)

        display.Cursor = New Cursor(My.Computer.FileSystem.CurrentDirectory + "\None.cur")
        Level = 1
        GetLevel(Level)
        GamePlaying = True
    End Sub

    Private Sub Main_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        GameLoop()
    End Sub

    Private Sub Main_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        GamePlaying = False
    End Sub

    Private Sub GetLevel(ByVal NextLevel As Integer)
        Dim binReader As New BinaryReader( _
  File.Open(My.Computer.FileSystem.CurrentDirectory & "\levels\lvl" & NextLevel & ".txt", FileMode.Open))
        binReader.BaseStream.Seek(0, SeekOrigin.Begin)

        For y = 0 To 17
            For x = 0 To 20
                block.SetValue(binReader.ReadInt32, x, y)
            Next
        Next

        pt = New Point(binReader.ReadInt32 * 32, binReader.ReadInt32 * 32)
    End Sub

    Private Sub GameLoop()
        Do While GamePlaying = True
            RenderScene()
            Application.DoEvents()
        Loop
    End Sub

    Private Sub RenderScene()
        If isLoading = False Then
            backBuffer = New Bitmap(clientWidth, clientHeight)
            gfx = Graphics.FromImage(backBuffer)
            display.Image = Nothing

            For y = 0 To 17
                For x = 0 To 20
                    If block_Visible.GetValue(x, y) = True Then
                        gfx.DrawImage(floors(block.GetValue(x, y)), New Point(x * 32, y * 32))
                    End If
                Next
            Next

            If Character_ >= 0 Then
                gfx.DrawImage(player(Character_), pt)
            End If

            display.Image = backBuffer
        End If
    End Sub

    Private Sub Main_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyData = Keys.Up Then
            Character_ = 0

            If pt.Y > 0 Then
                If CheckStep(0) > 0 Then
                    pt = New Point(pt.X, pt.Y - 4)
                End If
            End If

        End If

        If e.KeyData = Keys.Down Then
            Character_ = 1

            If pt.Y + 32 <= clientHeight Then
                If CheckStep(1) > 0 Then
                    pt = New Point(pt.X, pt.Y + 4)
                End If
            End If

        End If

        If e.KeyData = Keys.Left Then
            Character_ = 2

            If pt.X > 0 Then
                If CheckStep(2) > 0 Then
                    pt = New Point(pt.X - 4, pt.Y)
                End If
            End If

        End If

        If e.KeyData = Keys.Right Then
            Character_ = 3

            If pt.X + 32 <= clientWidth Then
                If CheckStep(3) > 0 Then
                    pt = New Point(pt.X + 4, pt.Y)
                End If
            End If

        End If

        If e.KeyData = Keys.Escape Then
            GamePlaying = False
            End
        End If

    End Sub

    Private Function CheckStep(ByVal d As Integer) As Integer
        Dim x, y, v1, v2 As Integer
        Dim b1, b2 As Boolean

        Select Case d

            Case 0
                If pt.Y Mod 32 = 0 Then
                    y = (pt.Y) / 32

                    If pt.X Mod 32 = 0 Then
                        x = pt.X / 32
                        v1 = block.GetValue(x, y - 1)
                        b1 = Barriers.Contains(v1)
                    Else
                        x = pt.X / 32 - ((pt.X Mod 32) / 32)
                        v1 = block.GetValue(x, y - 1)
                        v2 = block.GetValue(x + 1, y - 1)
                        b1 = Barriers.Contains(v1)
                        b2 = Barriers.Contains(v2)
                    End If
                End If
            Case 1
                If pt.Y Mod 32 = 0 Then
                    y = (pt.Y) / 32
                    If pt.X Mod 32 = 0 Then
                        x = pt.X / 32
                        v1 = block.GetValue(x, y + 1)
                        b1 = Barriers.Contains(v1)
                    Else
                        x = pt.X / 32 - ((pt.X Mod 32) / 32)
                        v1 = block.GetValue(x, y + 1)
                        v2 = block.GetValue(x + 1, y + 1)
                        b1 = Barriers.Contains(v1)
                        b2 = Barriers.Contains(v2)
                    End If
                End If
            Case 2
                If pt.X Mod 32 = 0 Then
                    x = (pt.X) / 32
                    If pt.Y Mod 32 = 0 Then
                        y = pt.Y / 32
                        v1 = block.GetValue(x - 1, y)
                        b1 = Barriers.Contains(v1)
                    Else
                        y = pt.Y / 32 - ((pt.Y Mod 32) / 32)
                        v1 = block.GetValue(x - 1, y)
                        v2 = block.GetValue(x - 1, y + 1)
                        b1 = Barriers.Contains(v1)
                        b2 = Barriers.Contains(v2)
                    End If
                End If
            Case 3
                If pt.X Mod 32 = 0 Then
                    x = (pt.X) / 32
                    If pt.Y Mod 32 = 0 Then
                        y = pt.Y / 32
                        v1 = block.GetValue(x + 1, y)
                        b1 = Barriers.Contains(v1)
                    Else
                        y = pt.Y / 32 - ((pt.Y Mod 32) / 32)
                        v1 = block.GetValue(x + 1, y)
                        v2 = block.GetValue(x + 1, y + 1)
                        b1 = Barriers.Contains(v1)
                        b2 = Barriers.Contains(v2)
                    End If
                End If
        End Select

        If b1 = True Or b2 = True Then
            Return 0
        End If

        Dim i1, i2 As Integer
        i1 = pt.X / 32
        i2 = pt.Y / 32

        block_Visible.SetValue(True, i1, i2)
       
        CheckProperty(v1)
        CheckProperty(v2)

        Return 1
    End Function

    Private Sub CheckProperty(ByVal value As Integer)
        isLoading = True
        If value = 12 Then
            Level = Level + 1
            GetLevel(Level)
            pt = New Point(32, 32)
        End If
        isLoading = False
    End Sub

End Class


Module Vars
    Public GamePlaying As Boolean = False
End Module