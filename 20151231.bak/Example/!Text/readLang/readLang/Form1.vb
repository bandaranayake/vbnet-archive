Imports System.IO

Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Using sr As StreamReader = New StreamReader("G:\a.txt") 'String reader
            Dim line As String 'A line
            Dim i As Integer 'Integer for counting
            Dim st(30) As String 'Each string

            Do ' Repetion
                line = sr.ReadLine() 'Read a line
                Try
                    If line.Length > 2 Then ' See the length (whether it is valid)
                        i = i + 1 'Counting
                        st(i) = line.Remove(0, line.IndexOf("=") + 1) 'Store the string in array
                    End If
                Catch
                End Try
            Loop Until line Is Nothing

            For a As Integer = 1 To 30
                MsgBox(st(a))
            Next

        End Using

    End Sub
End Class
