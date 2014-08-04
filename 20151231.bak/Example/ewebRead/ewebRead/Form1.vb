Imports System.IO
Imports System.Net

Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim myurl As String = "http://www.stackoverflow.com"
        'Dim wc As WebClient = New WebClient()
        'Dim reader As StreamReader = New StreamReader(wc.OpenRead(myurl))
        'Dim s As String = reader.ReadToEnd

        Dim k As New IO_Library

        k.ReadBinaryData("http://www.stackoverflow.com")


    End Sub

End Class

Public Class IO_Library

    Public Shared Function ReadBinaryData(ByVal path As String) As Byte()

        ' Open the binary file.
        Dim streamBinary As New FileStream(path, FileMode.Open)

        ' Create a binary stream reader object.
        Dim readerInput As BinaryReader = New BinaryReader(streamBinary)

        ' Determine the number of bytes to read.
        Dim lengthFile As Integer = FileSize(path)

        ' Read the data in a byte array buffer.
        Dim inputData As Byte() = readerInput.ReadBytes(lengthFile)

        ' Close the file.
        streamBinary.Close()
        readerInput.Close()

        Return inputData

    End Function 'ReadBinaryData’ 

    Public Shared Function FileSize(ByVal path As String) As Integer

        Dim info As New FileInfo(path)

        Return info.Length

    End Function 'FileSize’ 

End Class 'IO_Library’