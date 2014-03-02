Imports System.Text
Imports System.IO

Public Class Form1

    Dim a1 As String = "{\rtf1\ansi\ansicpg1252\deff0\deflang2057{\fonttbl{\f0\fnil\fcharset0 Calibri;}}"
    Dim a2 As String = "{\colortbl ;\red255\green0\blue0;}"
    Dim b1 As String = "{\*\generator Msftedit 5.41.21.2510;}\viewkind4\uc1\pard\sa200\sl276\slmult1\cf1\lang9\f0\fs22 "
    Dim c As String = "\cf0 "
    Dim d As String = "\cf1\par"

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim sb As New StringBuilder()
        sb.AppendLine(a1)
        sb.AppendLine(a2)
        sb.AppendLine(b1 + "sa" + c + " " + "a" + d)

        'Dim source As String = "[stop]ONE[stop]TWO[stop]THREE[stop]"
        'Dim stringSeparators() As String = {"[stop]"}
        'Dim result() As String

        'result = source.Split(stringSeparators, _
        '                      StringSplitOptions.RemoveEmptyEntries)
        'For Each s As String In result
        '    Console.WriteLine("{0} ", s)
        'Next

        Using outfile As New StreamWriter("G:\a.rtf")
            outfile.Write(sb.ToString())
        End Using
        RichTextBox1.LoadFile("G:\a.rtf")

    End Sub
End Class