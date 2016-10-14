Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary

Partial Class UserLoggerSerialization
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

    Protected Sub cmdDelete_Click(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles cmdDelete.Click
        If ViewState("LogFile") IsNot Nothing Then
            File.Delete(DirectCast(ViewState("LogFile"), String))
            ViewState("LogFile") = Nothing
        End If
    End Sub

    Protected Sub cmdRead_Click(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles cmdRead.Click
        Dim log As New StringBuilder()
        Dim fileName As String = ViewState("LogFile")
        Using fs As New FileStream(fileName, FileMode.Open)
            ' Create a formatter.
            Dim formatter As New BinaryFormatter()

            ' Get all the serialized objects.
            While fs.Position < fs.Length
                ' Deserialize the object from the file.
                Dim entry As LogEntry =
                    DirectCast(formatter.Deserialize(fs), LogEntry)
                ' Display its information.
                log.Append(entry.DateValue.ToString())
                log.Append("<br/>")
                log.Append(entry.Message)
                log.Append("<br /><br />")
            End While
        End Using
        lblInfo.Text = log.ToString()
    End Sub
    Private Function GetFileName() As String
        ' Create a unique filename. 
        Dim fileName As String =
            "Log\user." + Guid.NewGuid().ToString()

        ' Put the file in the current web application path. 
        Return Path.Combine(Request.PhysicalApplicationPath, fileName)
    End Function

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
        Dim fileName As String =
            DirectCast(ViewState("LogFile"), String)
        Using fs As New FileStream(fileName, mode)
            ' Create a LogEntry object. 
            Dim entry As New LogEntry(message)

            ' Create a formatter. 
            Dim formatter As New BinaryFormatter()
            'SoapFormatter formatter = new SoapFormatter(); 

            ' Serialize the object to a file. 
            formatter.Serialize(fs, entry)

            ' Serialize to a memory stream so you can display it. 
            Dim ms As New MemoryStream()
            formatter.Serialize(ms, entry)

            ' Read it back and write it to the Debug window. 
            Dim r As New StreamReader(ms, System.Text.Encoding.ASCII)
            ms.Position = 0
            Dim x As String = r.ReadToEnd()
            r.Close()
            ms.Close()
        End Using
    End Sub

End Class
<Serializable()>
Public Class LogEntry
    Private m_message As String
    Private m_date As DateTime

    Public Property Message() As String
        Get
            Return m_message
        End Get
        Set(ByVal value As String)
            m_message = value
        End Set
    End Property
    Public Property DateValue() As DateTime
        Get
            Return m_date
        End Get
        Set(ByVal value As DateTime)
            m_date = value
        End Set
    End Property

    Public Sub New(ByVal message As String)
        Me.m_message = message
        Me.m_date = DateTime.Now
    End Sub
End Class


