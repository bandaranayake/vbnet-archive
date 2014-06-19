Public Class Form1

    'this is declaration to open and close the cdrom tray
    Declare Function mciSendString Lib "winmm.dll" Alias "mciSendStringA" _
       (ByVal lpszCommand As String, ByVal lpszReturnString As String, _
       ByVal cchReturnLength As Long, ByVal hwndCallback As Long) As Long


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        mciSendString("set CDAudio door open", 0, 0, 0)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        mciSendString("set CDAudio door closed", 0, 0, 0)
    End Sub

   
End Class
