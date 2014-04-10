Imports System.IO

Module Module1

    Sub Main()

        Dim b1(), b2(), b3() As Byte
        Dim fileName As String = "E:\a.txt"
        Dim fileNameL As String = "E:\a.l.txt"
        Dim fileNameU As String = "E:\a.u.txt"

        Dim i, j, k, l As Integer

        i = FileLen(fileName)

        Dim binReader As New BinaryReader( _
     File.Open(fileName, FileMode.Open))

        j = Math.Round(i / 3)
        k = Math.Round((i - j) / 2)
        l = i - j - k

        ReDim b1(j)
        ReDim b2(k)
        ReDim b3(l)

        binReader.BaseStream.Seek(0, SeekOrigin.Begin)
        b1 = binReader.ReadBytes(j)

        binReader.BaseStream.Seek(j, SeekOrigin.Begin)
        b2 = binReader.ReadBytes(k)

        binReader.BaseStream.Seek(j + k, SeekOrigin.Begin)
        b3 = binReader.ReadBytes(l)

        Dim binWriter As New BinaryWriter( _
            File.Open(fileNameL, FileMode.Create))
        binWriter.Write(b2)
        binWriter.Write(b3)
        binWriter.Write(b1)
        binWriter.Dispose()

        binReader.Dispose()




        Dim bReader As New BinaryReader( _
   File.Open(fileNameL, FileMode.Open))

        bReader.BaseStream.Seek(0, SeekOrigin.Begin)
        b2 = bReader.ReadBytes(k)

        bReader.BaseStream.Seek(k, SeekOrigin.Begin)
        b3 = bReader.ReadBytes(l)

        bReader.BaseStream.Seek(k + l, SeekOrigin.Begin)
        b1 = bReader.ReadBytes(j)

        Dim bWriter As New BinaryWriter( _
            File.Open(fileNameU, FileMode.Create))
        bWriter.Write(b1)
        bWriter.Write(b2)
        bWriter.Write(b3)

        bReader.Close()

    End Sub

End Module
