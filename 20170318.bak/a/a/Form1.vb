Imports OpenQA.Selenium
Imports OpenQA.Selenium.Chrome
Imports OpenQA.Selenium.Support.Events
Imports System.IO
Imports System.Threading

Public Class Form1

    Dim proxylist() As String '= {"36.81.184.237", "104.199.137.99", "104.198.188.187", "104.196.162.219", "104.196.185.234", "104.199.75.158", "104.196.71.199", "104.198.22.87", "104.196.183.60", "104.198.39.66", "35.185.10.39", "35.185.38.0", "35.185.29.130"}
    Dim i As Integer

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        i = -1
        For x As Integer = 0 To proxylist.Length - 1
            Dim t As Thread = New Thread(AddressOf vie) With {.IsBackground = True, .Name = "a" + i.ToString}
            t.Start()
            Thread.Sleep(10000)
            If x Mod 2 = 0 And x <> 0 Then
                Thread.Sleep(((Val(TextBox2.Text)) + 5) * 1000)
            End If
        Next

    End Sub

    Private Function getproxy() As String
        i = i + 1
        Return proxylist(i)
    End Function

    Private Sub vie()
        Dim service As ChromeDriverService = ChromeDriverService.CreateDefaultService
        Dim driver1 As ChromeDriver = Nothing
        Dim driver As EventFiringWebDriver
        Dim chromeOptions As New OpenQA.Selenium.Chrome.ChromeOptions()
        chromeOptions.AddExcludedArgument("ignore-certifcate-errors")
        chromeOptions.AddArgument("test-type")
        chromeOptions.AddArguments("--proxy-server=" + getproxy())
        service.HideCommandPromptWindow = True
        driver1 = New ChromeDriver(service, chromeOptions)
        driver = New EventFiringWebDriver(driver1)
        driver.Manage().Window().Maximize()

        driver.Navigate().GoToUrl("https://www.youtube.com/watch?v=VsTPdOiVdYE")
        Thread.Sleep(15000)
        driver.Quit()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        proxylist = File.ReadAllLines(My.Computer.FileSystem.CurrentDirectory + "\a.txt")
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim processList() As Process

        processList = Process.GetProcessesByName("chromedriver")
            For Each proc As Process In processList

            proc.Kill()

        Next

    End Sub
End Class
