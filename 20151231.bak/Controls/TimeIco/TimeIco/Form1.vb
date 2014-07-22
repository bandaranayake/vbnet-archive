Imports System.IO

Public Class Form1

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim bm As New Bitmap(16, 16)

        Try

            Dim g As Graphics = Graphics.FromImage(bm)

            Try

                Dim f As Font = New Font("Arial", 10)

                Try

                    g.DrawString(DateTime.Now.TimeOfDay.Seconds.ToString(), f, Brushes.Black, 0, 0)

                    Me.Icon = Icon.FromHandle(bm.GetHicon())

                Finally

                    f.Dispose()

                End Try

            Finally

                g.Dispose()

            End Try

        Finally

            bm.Dispose()

        End Try
    End Sub

End Class
