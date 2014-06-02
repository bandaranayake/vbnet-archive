Public Class Form1
   Private Declare Function LockWindowUpdate Lib "user32" (ByVal hWnd As Integer) As Integer

    Private WhiteSpace As String = " "
    Private CommentS As String = "'"
    Private CommentE As String = ""
    Private StringS As String = """"
    Private StringE As String = """"

    'Dim ScriptKeyWords() As String = {"Lib", "And"}
    'Dim ScriptOperatorKeyWords() As String = {"="}
    'Dim CommentKeyWords() As String = {"rem"}
    'Dim CommentChar As String = "'"

    Private Sub rtb_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rtb.TextChanged
        Dim SelectionAt As Integer = rtb.SelectionStart
        LockWindowUpdate(rtb.Handle.ToInt32)

        rtb.SelectionStart = 0
        rtb.SelectionLength = rtb.TextLength
        rtb.SelectionColor = Color.Black
        rtb.SelectionFont = New Font("Microsoft Sans Serif", 18, FontStyle.Regular, GraphicsUnit.Point)

        '    Dim l As Integer = -1

        '    Set keyword colors
        '    For Each line In rtb.Lines
        '        line = line.ToLower
        '        l = l + 1

        '        Dim CommentIndex As Integer
        '        Dim tmp As Integer
        '        Dim StringS, StringE As Integer
        '        Dim CommentE As Boolean = False

        '        tmp = rtb.GetFirstCharIndexFromLine(l)
        '        CommentIndex = line.IndexOf(CommentChar)
        '        StringS = line.IndexOf("""")
        '        StringE = line.IndexOf("""", StringS + 1)

        '        If line.IndexOf("'", StringS + 1) > 0 Then
        '            If line.IndexOf("'", StringS + 1) < StringE Then
        '                CommentE = True
        '            Else
        '                CommentE = False
        '            End If
        '        End If

        '        For Each key In ScriptKeyWords

        '            If line = key.ToLower Then
        '                rtb.Select(tmp, key.Length)
        '                rtb.SelectionColor = Color.Blue
        '            End If

        '            If line.StartsWith(key.ToLower + " ") Then
        '                rtb.Select(tmp, key.Length)
        '                rtb.SelectionColor = Color.Blue
        '            End If

        '            If line.StartsWith(key.ToLower + "'") Then
        '                rtb.Select(tmp, key.Length)
        '                rtb.SelectionColor = Color.Blue
        '            End If

        '            If line.EndsWith(" " + key.ToLower) Then
        '                rtb.Select(tmp + line.Length - key.Length, key.Length)
        '                rtb.SelectionColor = Color.Blue
        '            End If


        '            If line.Contains(key.ToLower) Then
        '                Dim pos As Integer = 0

        '                Do While line.IndexOf(" " + key.ToLower + " ", pos) >= 0
        '                    pos = line.IndexOf(" " + key.ToLower + " ", pos)

        '                    rtb.Select(tmp + pos + 1, key.Length + 1)
        '                    If rtb.SelectedText = key.ToLower + " " Then
        '                        rtb.Select(tmp + pos + 1, key.Length)
        '                        rtb.SelectionColor = Color.Blue
        '                    End If

        '                    pos += 1
        '                Loop

        '                Do While line.IndexOf(" " + key.ToLower + "'", pos) >= 0
        '                    pos = line.IndexOf(" " + key.ToLower + "'", pos)

        '                    rtb.Select(tmp + pos + 1, key.Length + 1)
        '                    If rtb.SelectedText = key.ToLower + "'" Then
        '                        rtb.Select(tmp + pos + 1, key.Length)
        '                        rtb.SelectionColor = Color.Blue
        '                    End If

        '                    pos += 1
        '                Loop
        '            End If

        '        Next

        '        If Not StringS < 0 And Not StringE < 0 Then
        '            If CommentE = False Then
        '                rtb.Select(tmp + StringS, StringE - StringS + 1)
        '                rtb.SelectionColor = Color.Maroon
        '            End If
        '        End If

        '        set comment color
        '        For Each commentWord In CommentKeyWords
        '            If line = commentWord.ToLower Then
        '                rtb.Select(tmp, commentWord.Length)
        '                rtb.SelectionColor = Color.DarkGreen
        '            End If

        '            If line.StartsWith(commentWord.ToLower + " ") Or line.StartsWith(commentWord.ToLower + "'") Then
        '                rtb.Select(tmp, line.Length)
        '                rtb.SelectionColor = Color.DarkGreen
        '            End If

        '            If line.EndsWith(" " + commentWord.ToLower) Then
        '                rtb.Select(tmp + line.Length - commentWord.Length, commentWord.Length)
        '                rtb.SelectionColor = Color.DarkGreen
        '            End If

        '            If line.Contains(commentWord.ToLower) Then
        '                Dim pos As Integer = 0

        '                Do While line.IndexOf(" " + commentWord.ToLower + " ", pos) >= 0
        '                    pos = line.IndexOf(" " + commentWord.ToLower + " ", pos)

        '                    rtb.Select(tmp + pos + 1, commentWord.Length + 1)
        '                    If rtb.SelectedText = commentWord.ToLower + " " Then
        '                        rtb.Select(tmp + pos + 1, line.Length - pos - 1)
        '                        rtb.SelectionColor = Color.DarkGreen
        '                    End If

        '                    pos += 1
        '                Loop
        '            End If
        '        Next

        '        If CommentIndex = 0 Then
        '            rtb.Select(tmp, line.Length - CommentIndex)
        '            rtb.SelectionColor = Color.DarkGreen
        '        ElseIf CommentIndex > 0 Then
        '            rtb.Select(tmp + CommentIndex, line.Length - CommentIndex)
        '            rtb.SelectionColor = Color.DarkGreen
        '        End If

        '    Next

        LockWindowUpdate(0)
        rtb.SelectionStart = SelectionAt
        rtb.SelectionLength = 0
    End Sub

    Sub colorKeyword(ByVal rtb As RichTextBox, ByVal f As Font, ByVal c As Color, ByVal total As Integer, ByVal line As String, ByVal key As String)
        line = line.ToLower

        If line = key.ToLower Then
            rtb.Select(total, key.Length)
            rtb.SelectionColor = Color.Blue
        End If

        If line.StartsWith(key.ToLower + WhiteSpace) Then
            rtb.Select(total, key.Length)
            rtb.SelectionColor = Color.Blue
        End If

        If line.StartsWith(key.ToLower + CommentS) Then
            rtb.Select(total, key.Length)
            rtb.SelectionColor = Color.Blue
        End If

        If line.EndsWith(WhiteSpace + key.ToLower) Then
            rtb.Select(total + line.Length - key.Length, key.Length)
            rtb.SelectionColor = Color.Blue
        End If

        If line.Contains(key.ToLower) Then
            Dim pos As Integer = 0

            Do While line.IndexOf(WhiteSpace + key.ToLower + WhiteSpace, pos) >= 0
                pos = line.IndexOf(WhiteSpace + key.ToLower + WhiteSpace, pos)

                rtb.Select(total + pos + 1, key.Length + 1)
                If rtb.SelectedText = key.ToLower + WhiteSpace Then
                    rtb.Select(total + pos + 1, key.Length)
                    rtb.SelectionColor = Color.Blue
                End If

                pos += 1
            Loop

            Do While line.IndexOf(WhiteSpace + key.ToLower + CommentS, pos) >= 0
                pos = line.IndexOf(WhiteSpace + key.ToLower + CommentS, pos)

                rtb.Select(total + pos + 1, key.Length + 1)
                If rtb.SelectedText = key.ToLower + CommentS Then
                    rtb.Select(total + pos + 1, key.Length)
                    rtb.SelectionColor = Color.Blue
                End If

                pos += 1
            Loop
        End If

    End Sub

    Sub colorCouple(ByVal rtb As RichTextBox, ByVal f As Font, ByVal c As Color, ByVal total As Integer, ByVal line As String, ByVal s As String, ByVal e As String)
        line = line.ToLower


    End Sub

End Class
