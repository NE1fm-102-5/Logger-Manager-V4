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

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Minimized
        Button2.Select()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        NotifyIcon1.Visible = False
    End Sub

    Private Sub Form1_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        NotifyIcon1.Visible = False
    End Sub

    Private Sub starttime_Tick(sender As Object, e As EventArgs) Handles starttime.Tick
        Me.Visible = False
        NotifyIcon1.Visible = True
        starttime.Enabled = False
    End Sub

    Private Sub NotifyIcon1_Click(sender As Object, e As EventArgs) Handles NotifyIcon1.Click
        Me.Visible = True
        Me.WindowState = FormWindowState.Normal
        Me.BringToFront()
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True
        Me.Visible = False
        NotifyIcon1.Visible = True
    End Sub

    Private Sub logtime_Tick(sender As Object, e As EventArgs) Handles logtime.Tick
        Try
            If My.Computer.FileSystem.FileExists("C:\NE1fmConsole\LoggerPC.txt") Then
                Dim p1() As Process
                p1 = Process.GetProcessesByName("ALFiler")
                If p1.Count > 0 Then
                    'Already Running
                Else
                    Try
                        Process.Start("C:\Logger\ALFiler.exe")
                    Catch ex As Exception
                    End Try
                End If
                Dim p2() As Process
                p2 = Process.GetProcessesByName("ALRec")
                If p2.Count > 0 Then
                    'Already Running
                Else
                    Try
                        Process.Start("C:\Logger\ALRec.exe")
                    Catch ex As Exception
                    End Try
                End If
                Dim p3() As Process
                p3 = Process.GetProcessesByName("butt")
                If p3.Count > 0 Then
                    'Already Running
                Else
                    Try
                        Process.Start("C:\Users\logger\AppData\Local\butt-0.1.16\butt.exe")
                    Catch ex As Exception
                    End Try
                End If
                Dim p4() As Process
                p4 = Process.GetProcessesByName("piraside")
                If p4.Count > 0 Then
                    'Already Running
                Else
                    Try
                        Process.Start("C:\Program Files (x86)\Pira CZ Silence Detector\piraside.exe")
                    Catch ex As Exception
                    End Try
                End If
                Dim p5() As Process
                p5 = Process.GetProcessesByName("Now Playing Tool for OtsAV")
                If p5.Count > 0 Then
                    'Already Running
                Else
                    Try
                        Process.Start("C:\Program Files\Now Playing Tool for OtsAV\Now Playing Tool for OtsAV.exe")
                    Catch ex As Exception
                    End Try
                End If
                Dim p6() As Process
                p6 = Process.GetProcessesByName("Stats Tool For OtsAV")
                If p6.Count > 0 Then
                    'Already Running
                Else
                    Try
                        Process.Start("C:\Program Files\Stats Tool for OtsAV\Stats Tool for OtsAV.exe")
                    Catch ex As Exception
                    End Try
                End If
            Else
                'Do Nothing
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub songtimer_Tick(sender As Object, e As EventArgs) Handles songtimer.Tick
        Try
            If My.Computer.FileSystem.FileExists("C:\NE1fmConsole\OfficePC.txt") Then
                Try
                    Dim npo As String = My.Computer.FileSystem.ReadAllText("\\NE1-LOGGER\Logger\LoggerNowPlaying\nowplaying.txt")
                    If Len(npo) > 25 Then
                        Label2.Text = npo + "  :::  "
                    Else
                        Label2.Text = npo
                    End If
                Catch ex As Exception
                End Try
            ElseIf My.Computer.FileSystem.FileExists("C:\NE1fmConsole\LoggerPC.txt") Then
                Dim npo As String = My.Computer.FileSystem.ReadAllText("C:\Logger\LoggerNowPlaying\nowplaying.txt")
                If Len(npo) > 25 Then
                    Label2.Text = npo + "  :::  "
                Else
                    Label2.Text = npo
                End If
            Else
                Label2.Text = "Unconfigured Environment"
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub songtimer2_Tick(sender As Object, e As EventArgs) Handles songtimer2.Tick
        Try
            If My.Computer.FileSystem.FileExists("C:\NE1fmConsole\OfficePC.txt") Then
                Try
                    Dim npmod As DateTime
                    npmod = File.GetLastWriteTime("\\NE1-LOGGER\Logger\LoggerNowPlaying\nowplaying.txt")
                    Dim timenow As DateTime
                    timenow = Date.Now
                    Dim difftime As Integer
                    difftime = DateDiff(DateInterval.Minute, timenow, npmod)

                    If difftime < -5 Then
                        Label2.Text = "UNKNOWN"
                    ElseIf Len(Label2.Text) > 25 Then
                        Label2.Text = Microsoft.VisualBasic.Right(Label2.Text, Len(Label2.Text) - 1) + Microsoft.VisualBasic.Left(Label2.Text, 1)
                    Else
                        'Label2.Text = My.Computer.FileSystem.ReadAllText("C:\LoggerNowPlaying\nowplaying.txt")
                    End If
                Catch ex As Exception
                End Try
            ElseIf My.Computer.FileSystem.FileExists("C:\NE1fmConsole\LoggerPC.txt") Then
                Dim npmod As DateTime
                npmod = File.GetLastWriteTime("C:\Logger\LoggerNowPlaying\nowplaying.txt")
                Dim timenow As DateTime
                timenow = Date.Now
                Dim difftime As Integer
                difftime = DateDiff(DateInterval.Minute, timenow, npmod)

                If difftime < -5 Then
                    Label2.Text = "UNKNOWN"
                ElseIf Len(Label2.Text) > 25 Then
                    Label2.Text = Microsoft.VisualBasic.Right(Label2.Text, Len(Label2.Text) - 1) + Microsoft.VisualBasic.Left(Label2.Text, 1)
                Else
                    'Label2.Text = My.Computer.FileSystem.ReadAllText("C:\LoggerNowPlaying\nowplaying.txt")
                End If
            Else
                Label2.Text = "Unconfigured Environment"
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub startstream_Tick(sender As Object, e As EventArgs) Handles startstream.Tick
        Try
            Dim webstatus As New WebClient()
            Dim statusresponse As String = webstatus.DownloadString("http://scripts.myradiostream.com/s46/4350/status.js")
            Dim status_start As String
            Dim status_end As String
            status_start = Replace(statusresponse, "document.write('", "")
            status_end = Replace(status_start, "');", "")
            If status_end = "Online" Then
                Dim weblisten As New WebClient()
                Dim listenresponse As String = weblisten.DownloadString("http://scripts.myradiostream.com/s46/4350/listeners.js")
                Dim list_start As String
                Dim list_end As String
                Dim list_rem As String
                list_start = Replace(listenresponse, "document.write('", "")
                list_end = Replace(list_start, "');", "")
                list_rem = Replace(list_end, "<html><body>", "")
                Label22.Text = "Online" & " with " & list_rem & " listeners"
                Label22.ForeColor = Color.Green()
            End If
            If status_end = "Offline (No Server Connection)" Then
                Label22.Text = "Offline - Server Down"
                Label22.ForeColor = Color.Red()
            End If
            If status_end = "Offline (No Source)" Then
                Label22.Text = "Offline - Not Streaming"
                Label22.ForeColor = Color.DarkOrange()
            End If
        Catch ex As Exception
        End Try

        Dim lognumber As String
        Dim cachelognumber As String
        Dim logname As String
        Dim cachelogname As String
        Dim cachelognameogg As String
        Dim cachelognametmp As String
        Dim logpath As String
        Dim cachelogpath As String
        Dim cachelogpatha As String
        Dim cachelogpathb As String
        Dim hournow As Integer
        hournow = Format(Now, "HH")
        Dim minutenow As String
        minutenow = Format(Now, "mm")
        Dim twohourago As Integer
        twohourago = hournow - 2
        Dim twohoursago As String
        twohoursago = twohourago
        lognumber = Format(Now, "yyyyMMddHH")
        cachelognumber = Format(Now, "yyyyMMddHHmm")
        logname = lognumber + "0000.ogg"
        cachelognametmp = cachelognumber + "00.tmp"
        cachelognameogg = cachelognumber + "00.ogg"

        If My.Computer.FileSystem.FileExists("C:\NE1fmConsole\OfficePC.txt") Then
            Try
                logpath = "\\NE1-LOGGER\Logger\Store\" + logname
                cachelogpatha = "\\NE1-LOGGER\Logger\Cache\" + cachelognametmp
                cachelogpathb = "\\NE1-LOGGER\Logger\Cache\" + cachelognameogg
                If My.Computer.FileSystem.FileExists(logpath) Then
                    Label27.Text = "Recording"
                    Label27.ForeColor = Color.Green()
                    Label7.Visible = True
                    Label8.Visible = False
                ElseIf My.Computer.FileSystem.FileExists(cachelogpatha) Or My.Computer.FileSystem.FileExists(cachelogpathb) Then
                    Label27.Text = "Recording In Minutes"
                    Label27.ForeColor = Color.DarkOrange()
                    Label7.Visible = False
                    Label8.Visible = True
                Else
                    Label27.Text = "Not Recording"
                    Label27.ForeColor = Color.Red()
                    Label7.Visible = False
                    Label8.Visible = True
                End If
            Catch ex As Exception
            End Try
        ElseIf My.Computer.FileSystem.FileExists("C:\NE1fmConsole\LoggerPC.txt") Then
            logpath = "C:\Logger\Store\" + logname
            cachelogpatha = "C:\Logger\Cache\" + cachelognametmp
            cachelogpathb = "C:\Logger\Cache\" + cachelognameogg
            If My.Computer.FileSystem.FileExists(logpath) Then
                Label27.Text = "Recording"
                Label27.ForeColor = Color.Green()
                Label7.Visible = True
                Label8.Visible = False
            ElseIf My.Computer.FileSystem.FileExists(cachelogpatha) Or My.Computer.FileSystem.FileExists(cachelogpathb) Then
                Label27.Text = "Recording In Minutes"
                Label27.ForeColor = Color.DarkOrange()
                Label7.Visible = False
                Label8.Visible = True
            Else
                Label27.Text = "Not Recording"
                Label27.ForeColor = Color.Red()
                Label7.Visible = False
                Label8.Visible = True
            End If
        Else
            Label27.Text = "Unconfigured Environment"
            Label27.ForeColor = Color.DarkBlue
            Label7.Visible = True
            Label8.Visible = False
        End If



        If My.Computer.FileSystem.FileExists("C:\NE1fmConsole\LoggerPC.txt") Then
            Dim p1() As Process
            p1 = Process.GetProcessesByName("ALFiler")
            If p1.Count > 0 Then
                'Already Running
            Else
                Try
                    Process.Start("C:\Logger\ALFiler.exe")
                Catch ex As Exception
                End Try
            End If
            Dim p2() As Process
            p2 = Process.GetProcessesByName("ALRec")
            If p2.Count > 0 Then
                'Already Running
            Else
                Try
                    Process.Start("C:\Logger\ALRec.exe")
                Catch ex As Exception
                End Try
            End If
            Dim p3() As Process
            p3 = Process.GetProcessesByName("butt")
            If p3.Count > 0 Then
                'Already Running
            Else
                Try
                    Process.Start("C:\Users\logger\AppData\Local\butt-0.1.16\butt.exe")
                Catch ex As Exception
                End Try
            End If
            Dim p4() As Process
            p4 = Process.GetProcessesByName("piraside")
            If p4.Count > 0 Then
                'Already Running
            Else
                Try
                    Process.Start("C:\Program Files (x86)\Pira CZ Silence Detector\piraside.exe")
                Catch ex As Exception
                End Try
            End If
            Dim p5() As Process
            p5 = Process.GetProcessesByName("Now Playing Tool for OtsAV")
            If p5.Count > 0 Then
                'Already Running
            Else
                Try
                    Process.Start("C:\Program Files\Now Playing Tool for OtsAV\Now Playing Tool for OtsAV.exe")
                Catch ex As Exception
                End Try
            End If
            Dim p6() As Process
            p6 = Process.GetProcessesByName("Stats Tool For OtsAV")
            If p6.Count > 0 Then
                'Already Running
            Else
                Try
                    Process.Start("C:\Program Files\Stats Tool for OtsAV\Stats Tool for OtsAV.exe")
                Catch ex As Exception
                End Try
            End If
        ElseIf My.Computer.FileSystem.FileExists("C:\NE1fmConsole\OfficePC.txt") Then
            'Do Nothing
        Else
            'Do Nothing
        End If

        startstream.Enabled = False
        contstream.Enabled = True
    End Sub

    Private Sub contstream_Tick(sender As Object, e As EventArgs) Handles contstream.Tick
        Try
            Dim webstatus As New WebClient()
            Dim statusresponse As String = webstatus.DownloadString("http://scripts.myradiostream.com/s46/4350/status.js")
            Dim status_start As String
            Dim status_end As String
            status_start = Replace(statusresponse, "document.write('", "")
            status_end = Replace(status_start, "');", "")
            If status_end = "Online" Then
                Dim weblisten As New WebClient()
                Dim listenresponse As String = weblisten.DownloadString("http://scripts.myradiostream.com/s46/4350/listeners.js")
                Dim list_start As String
                Dim list_end As String
                Dim list_rem As String
                list_start = Replace(listenresponse, "document.write('", "")
                list_end = Replace(list_start, "');", "")
                list_rem = Replace(list_end, "<html><body>", "")
                Label22.Text = "Online" & " with " & list_rem & " listeners"
                Label22.ForeColor = Color.Green()
            End If
            If status_end = "Offline (No Server Connection)" Then
                Label22.Text = "Offline - Server Down"
                Label22.ForeColor = Color.Red()
            End If
            If status_end = "Offline (No Source)" Then
                Label22.Text = "Offline - Not Streaming"
                Label22.ForeColor = Color.DarkOrange()
            End If
        Catch ex As Exception
        End Try

        Dim lognumber As String
        Dim cachelognumber As String
        Dim logname As String
        Dim cachelogname As String
        Dim cachelognameogg As String
        Dim cachelognametmp As String
        Dim logpath As String
        Dim cachelogpath As String
        Dim cachelogpatha As String
        Dim cachelogpathb As String
        Dim hournow As Integer
        hournow = Format(Now, "HH")
        Dim minutenow As String
        minutenow = Format(Now, "mm")
        Dim twohourago As Integer
        twohourago = hournow - 2
        Dim twohoursago As String
        twohoursago = twohourago
        lognumber = Format(Now, "yyyyMMddHH")
        cachelognumber = Format(Now, "yyyyMMddHHmm")
        logname = lognumber + "0000.ogg"
        cachelognametmp = cachelognumber + "00.tmp"
        cachelognameogg = cachelognumber + "00.ogg"

        If My.Computer.FileSystem.FileExists("C:\NE1fmConsole\OfficePC.txt") Then
            Try
                logpath = "\\NE1-LOGGER\Logger\Store\" + logname
                cachelogpatha = "\\NE1-LOGGER\Logger\Cache\" + cachelognametmp
                cachelogpathb = "\\NE1-LOGGER\Logger\Cache\" + cachelognameogg
                If My.Computer.FileSystem.FileExists(logpath) Then
                    Label27.Text = "Recording"
                    Label27.ForeColor = Color.Green()
                    Label7.Visible = True
                    Label8.Visible = False
                ElseIf My.Computer.FileSystem.FileExists(cachelogpatha) Or My.Computer.FileSystem.FileExists(cachelogpathb) Then
                    Label27.Text = "Recording In Minutes"
                    Label27.ForeColor = Color.DarkOrange()
                    Label7.Visible = False
                    Label8.Visible = True
                Else
                    Label27.Text = "Not Recording"
                    Label27.ForeColor = Color.Red()
                    Label7.Visible = False
                    Label8.Visible = True
                End If
            Catch ex As Exception
            End Try
        ElseIf My.Computer.FileSystem.FileExists("C:\NE1fmConsole\LoggerPC.txt") Then
            logpath = "C:\Logger\Store\" + logname
            cachelogpatha = "C:\Logger\Cache\" + cachelognametmp
            cachelogpathb = "C:\Logger\Cache\" + cachelognameogg
            If My.Computer.FileSystem.FileExists(logpath) Then
                Label27.Text = "Recording"
                Label27.ForeColor = Color.Green()
                Label7.Visible = True
                Label8.Visible = False
            ElseIf My.Computer.FileSystem.FileExists(cachelogpatha) Or My.Computer.FileSystem.FileExists(cachelogpathb) Then
                Label27.Text = "Recording In Minutes"
                Label27.ForeColor = Color.DarkOrange()
                Label7.Visible = False
                Label8.Visible = True
            Else
                Label27.Text = "Not Recording"
                Label27.ForeColor = Color.Red()
                Label7.Visible = False
                Label8.Visible = True
            End If
        Else
            Label27.Text = "Test Environment"
            Label27.ForeColor = Color.DarkBlue
            Label7.Visible = True
            Label8.Visible = False
        End If

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        passbox.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Visible = False
        NotifyIcon1.Visible = True
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Interval = 600000

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
    End Sub
End Class
