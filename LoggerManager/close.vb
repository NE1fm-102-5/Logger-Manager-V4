Option Strict Off
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Net
Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Text
Imports System.Net.Mail
Imports System.Diagnostics

Public Class passbox
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Label2.Text = ""
        TextBox1.Text = ""
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "N31ConsoleClose!" Then
            TextBox1.Text = ""
            Label2.Text = ""
            End
        ElseIf TextBox1.Text = "updatenow" Then
            Me.Hide()

            Try
                File.Delete("C:\NE1fmConsole\ConsoleUpdater.exe")
            Catch ex As Exception

            End Try
            Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create("https://dl.dropboxusercontent.com/s/oe4lzcotlbrktjd/version.txt?insert_anything_you_want")
            Dim response As System.Net.HttpWebResponse = request.GetResponse()
            Dim sr As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream())
            Dim newestversion As String = sr.ReadToEnd()
            Dim currentversion As String = Application.ProductVersion
            If newestversion.Contains(currentversion) Then
                'do nothing
            Else
                Dim link As String = "https://www.dropbox.com/s/1pyfy9dhe2puj75/ConsoleUpdater.exe?dl=1"
                Dim wc As New WebClient
                wc.DownloadFile(link, "C:\NE1fmConsole\ConsoleUpdater.exe")
                System.Threading.Thread.Sleep(5000)
                Process.Start("C:\NE1fmConsole\ConsoleUpdater.exe")
            End If

        ElseIf TextBox1.Text = "redownload" Then
            Me.Hide()
            Dim link As String = "https://www.dropbox.com/s/1pyfy9dhe2puj75/ConsoleUpdater.exe?dl=1"
            Dim wc As New WebClient
            wc.DownloadFile(link, "C:\NE1fmConsole\ConsoleUpdater.exe")
            System.Threading.Thread.Sleep(5000)
            Process.Start("C:\NE1fmConsole\ConsoleUpdater.exe")
        ElseIf TextBox1.Text = "N31OtsRemote!" Then
            Process.Start("C:\Program Files (x86)\Google\Chrome\Application\chrome.exe", "/incognito 192.168.1.115")
            Label2.Text = ""
            TextBox1.Text = ""
            Me.Hide()
        ElseIf TextBox1.Text = "N31SCinfo!" Then
            Process.Start("C:\Program Files (x86)\Google\Chrome\Application\chrome.exe", "/incognito http://s46.myradiostream.com:4350")
            Label2.Text = ""
            TextBox1.Text = ""
            Me.Hide()
        Else
            TextBox1.Text = ""
            Label2.Text = "Invalid"
        End If
    End Sub

    Private Sub passbox_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub
End Class