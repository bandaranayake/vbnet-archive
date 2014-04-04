Imports System.IO

Module GVandF
    Public ProjectPath As String
    Public BImageChanged As Boolean
    Public NewFrame As New Frame
    Public DropDownList As New ToolStripDropDown

    Public Function GetCursor(ByVal cur As Cursor) As Integer
        Select Case cur
            Case Cursors.AppStarting
                Return 0
            Case Cursors.Arrow
                Return 1
            Case Cursors.Cross
                Return 2
            Case Cursors.Default
                Return 3
            Case Cursors.Hand
                Return 4
            Case Cursors.Help
                Return 5
            Case Cursors.HSplit
                Return 6
            Case Cursors.IBeam
                Return 7
            Case Cursors.No
                Return 8
            Case Cursors.NoMove2D
                Return 9
            Case Cursors.NoMoveHoriz
                Return 10
            Case Cursors.NoMoveVert
                Return 11
            Case Cursors.PanEast
                Return 12
            Case Cursors.PanNE
                Return 13
            Case Cursors.PanNorth
                Return 14
            Case Cursors.PanNW
                Return 15
            Case Cursors.PanSE
                Return 16
            Case Cursors.PanSouth
                Return 17
            Case Cursors.PanSW
                Return 18
            Case Cursors.PanWest
                Return 19
            Case Cursors.SizeAll
                Return 20
            Case Cursors.SizeNESW
                Return 21
            Case Cursors.SizeNS
                Return 22
            Case Cursors.SizeNWSE
                Return 23
            Case Cursors.SizeWE
                Return 24
            Case Cursors.UpArrow
                Return 25
            Case Cursors.VSplit
                Return 26
            Case Cursors.WaitCursor
                Return 27
            Case Else
                Return False
        End Select
        Return 3
    End Function

    Public Function SetCursor(ByVal cur As Integer) As Cursor
        Select Case cur
            Case 0
                Return Cursors.AppStarting
            Case 1
                Return Cursors.Arrow
            Case 2
                Return Cursors.Cross
            Case 3
                Return Cursors.Default
            Case 4
                Return Cursors.Hand
            Case 5
                Return Cursors.Help
            Case 6
                Return Cursors.HSplit
            Case 7
                Return Cursors.IBeam
            Case 8
                Return Cursors.No
            Case 9
                Return Cursors.NoMove2D
            Case 10
                Return Cursors.NoMoveHoriz
            Case 11
                Return Cursors.NoMoveVert
            Case 12
                Return Cursors.PanEast
            Case 13
                Return Cursors.PanNE
            Case 14
                Return Cursors.PanNorth
            Case 15
                Return Cursors.PanNW
            Case 16
                Return Cursors.PanSE
            Case 17
                Return Cursors.PanSouth
            Case 18
                Return Cursors.PanSW
            Case 19
                Return Cursors.PanWest
            Case 20
                Return Cursors.SizeAll
            Case 21
                Return Cursors.SizeNESW
            Case 22
                Return Cursors.SizeNS
            Case 23
                Return Cursors.SizeNWSE
            Case 24
                Return Cursors.SizeWE
            Case 25
                Return Cursors.UpArrow
            Case 26
                Return Cursors.VSplit
            Case 27
                Return Cursors.WaitCursor
        End Select
        Return Cursors.Arrow
    End Function

    Public Function GetImgAlign(ByVal aln As ContentAlignment) As Integer
        Select Case aln
            Case ContentAlignment.TopLeft
                Return 0
            Case ContentAlignment.TopCenter
                Return 1
            Case ContentAlignment.TopRight
                Return 2
            Case ContentAlignment.MiddleLeft
                Return 3
            Case ContentAlignment.MiddleCenter
                Return 4
            Case ContentAlignment.MiddleRight
                Return 5
            Case ContentAlignment.BottomLeft
                Return 6
            Case ContentAlignment.BottomCenter
                Return 7
            Case ContentAlignment.BottomRight
                Return 8
        End Select
        Return 4
    End Function

    Public Function SetImgAlign(ByVal aln As Integer) As ContentAlignment
        Select Case aln
            Case 0
                Return ContentAlignment.TopLeft
            Case 1
                Return ContentAlignment.TopCenter
            Case 2
                Return ContentAlignment.TopRight
            Case 3
                Return ContentAlignment.MiddleLeft
            Case 4
                Return ContentAlignment.MiddleCenter
            Case 5
                Return ContentAlignment.MiddleRight
            Case 6
                Return ContentAlignment.BottomLeft
            Case 7
                Return ContentAlignment.BottomCenter
            Case 8
                Return ContentAlignment.BottomRight
        End Select
        Return ContentAlignment.MiddleCenter
    End Function

    Public Function GetRandomName() As String
kk:
        Dim fileName As String
        fileName = Now.ToString.Replace("/", "").Replace(" ", "").Replace(":", "").Replace("PM", "11").Replace("AM", "00")
        fileName = fileName & Now.Millisecond.ToString
        If File.Exists(ProjectPath + "\" + fileName) = True Then
            GoTo kk
        End If

        Return fileName
    End Function

    Public Function Read4Me(ByVal path As String, ByVal position As Integer, ByVal length As Integer) As Byte()
        Dim binReader = New BinaryReader( _
             File.Open(path, FileMode.Open))
        Try
            binReader.BaseStream.Seek(position, SeekOrigin.Begin)
            Return binReader.ReadBytes(length)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error !")
        End Try
        binReader.Dispose()
        Return Nothing
    End Function

End Module
