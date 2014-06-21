Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim wsh As Object = CreateObject("WScript.Shell")

        wsh = CreateObject("WScript.Shell")

        Dim MyShortcut, DesktopPath

        ' Read desktop path using WshSpecialFolders object

        DesktopPath = wsh.SpecialFolders("Desktop")

        ' Create a shortcut object on the desktop

        MyShortcut = wsh.CreateShortcut(DesktopPath & "\name of shortcut.lnk")

        ' Set shortcut object properties and save it

        MyShortcut.TargetPath = wsh.ExpandEnvironmentStrings("G:\isuru")

        MyShortcut.WorkingDirectory = wsh.ExpandEnvironmentStrings("G:\")

        MyShortcut.WindowStyle = 4

        'Use this next line to assign a icon other then the default icon for the exe

        'MyShortcut.IconLocation = WSHShell.ExpandEnvironmentStrings("path to a file with an embeded icon", icon index number)

        'Save the shortcut

        MyShortcut.Save()
    End Sub
End Class
