Imports System.Drawing.Drawing2D

Public Class Form1

    Dim originalPoint As Point
    Dim lastPoint As Point
    Dim mouseIsDown As Boolean

    Public Sub MyMouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles MyBase.MouseDown
        mouseIsDown = True
        originalPoint.X = e.X
        originalPoint.Y = e.Y
        lastPoint.X = -1
        lastPoint.Y = -1
    End Sub

    Private Sub MyDrawReversibleRectangle1(ByVal point1 As Point, ByVal point2 As Point)
        Dim rect As Rectangle

        point1 = PointToScreen(point1)
        point2 = PointToScreen(point2)

        If point1.X < point2.X Then
            rect.X = point1.X
            rect.Width = point2.X - point1.X
        Else
            rect.X = point2.X
            rect.Width = point1.X - point2.X
        End If

        If point1.Y < point2.Y Then
            rect.Y = point1.Y
            rect.Height = point2.Y - point1.Y
        Else
            rect.Y = point2.Y
            rect.Height = point1.Y - point2.Y
        End If

        ControlPaint.DrawReversibleFrame(rect, Color.Black, FrameStyle.Dashed)

    End Sub

    Private Sub MyDrawReversibleRectangle2(ByVal point1 As Point, ByVal point2 As Point)
        Me.CreateGraphics.Clear(Me.BackColor)

        Dim p1, p2 As Point

        If point1.X > point2.X Then
            p1 = point2
            p2 = point1
        Else
            p1 = point1
            p2 = point2
        End If

        For Each c In Me.Controls

            If c.Location.X > p1.X And c.Location.X < p2.X Then

                If c.Location.Y < p2.Y And c.Location.Y > p1.Y Then

                    Using redPen As New Pen(Color.Red), formGraphics As Graphics = Me.CreateGraphics()
                        formGraphics.DrawRectangle(redPen, New Rectangle(c.location.x - 1, c.location.y - 1, c.width + 1, c.height + 1))
                    End Using

                End If

            End If

        Next
    
    End Sub

    Public Sub MyMouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseUp

        mouseIsDown = False

        If lastPoint.X <> -1 Then
            Dim currentPoint As New Point(e.X, e.Y)
            MyDrawReversibleRectangle2(originalPoint, lastPoint)
        End If

        lastPoint.X = -1
        lastPoint.Y = -1
        originalPoint.X = -1
        originalPoint.Y = -1

    End Sub

    Public Sub MyMouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseMove

        Dim currentPoint As New Point(e.X, e.Y)

        If mouseIsDown Then

            If lastPoint.X <> -1 Then
                MyDrawReversibleRectangle1(originalPoint, lastPoint)
            End If

            lastPoint = currentPoint
            MyDrawReversibleRectangle1(originalPoint, currentPoint)
        End If

    End Sub

End Class
