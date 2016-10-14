Imports System.IO
Partial Class UserLogger
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        If Not Page.IsPostBack Then
            Log("Page loaded for the first time.")
        Else
            Log("Page posted back.")
        End If
    End Sub

    Protected Sub cmdRead_Click(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles cmdRead.Click
        Dim log As StringBuilder = New StringBuilder()
        Dim fileName As String = ViewState("LogFile").ToString()
        Using fs As New FileStream(fileName, FileMode.Open)
            Dim r As New StreamReader(fs)

            ' Read line by line (allows you to add
            ' line breaks to the web page).
            Dim line As String
            Do
                line = r.ReadLine()
                If line <> Nothing Then
                    log.Append(line + "<br>")
                End If
            Loop While line IsNot Nothing
            r.Close()
        End Using
        lblInfo.Text = log.ToString()
    End Sub

    Protected Sub cmdDelete_Click(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles cmdDelete.Click
        If ViewState("LogFile") IsNot Nothing Then
            File.Delete(ViewState("LogFile").ToString())
            ViewState("LogFile") = Nothing
        End If
    End Sub

    Private Sub Log(ByVal message As String)
        ' Check for the file.
        Dim mode As FileMode
        If ViewState("LogFile") Is Nothing Then
            ' First, create a unique user-specific file name.
            ViewState("LogFile") = GetFileName()

            ' The log file must be created.
            mode = FileMode.Create
        Else
            ' Add to the existing file.
            mode = FileMode.Append
        End If
        ' Write the message.
        ' A using block ensures the file is automatically closed,
        ' even in the case of error.
        Dim fileName As String = ViewState("LogFile")

        Using fs As New FileStream(fileName, mode)
            Dim w As New StreamWriter(fs)
            w.WriteLine(DateTime.Now)
            w.WriteLine(message)
            w.WriteLine()
            w.Close()
        End Using
    End Sub

    Private Function GetFileName() As String
        ' Create a unique filename.
        Dim fileName As String = "Log\user." &
            Guid.NewGuid().ToString()

        ' Put the file in the current web application path.
        Return Path.Combine(
            Request.PhysicalApplicationPath, fileName
            )
    End Function
End Class
