Imports Microsoft.VisualBasic
Imports System
Imports System.Web
Imports System.Web.Configuration
Imports System.Data
Imports System.Data.SqlClient

Public Class ImageFromDB
    Implements IHttpHandler
    Public Sub ProcessRequest(
        ByVal context As HttpContext
        ) Implements System.Web.IHttpHandler.ProcessRequest
        Dim connectionString As String =
            WebConfigurationManager.ConnectionStrings("Pubs").ConnectionString

        ' Get the ID for this request. 
        Dim id As String = context.Request.QueryString("id")
        If id Is Nothing Then
            Throw New ApplicationException("Must specify ID.")
        End If

        ' Create a parameterized command for this record. 
        Dim con As New SqlConnection(connectionString)
        Dim SQL As String = "SELECT logo FROM pub_info WHERE pub_id=@ID"
        Dim cmd As New SqlCommand(SQL, con)
        cmd.Parameters.AddWithValue("@ID", id)

        Try
            con.Open()
            Dim r As SqlDataReader =
                cmd.ExecuteReader(CommandBehavior.SequentialAccess)

            If r.Read() Then
                Dim bufferSize As Integer = 100
                ' Size of the buffer. 
                Dim bytes As Byte() = New Byte(bufferSize - 1) {}
                ' The buffer. 
                Dim bytesRead As Long
                ' The # of bytes read. 
                Dim readFrom As Long = 0
                ' The starting index. 
                ' Read the field 100 bytes at a time. 
                Do
                    bytesRead = r.GetBytes(0, readFrom, bytes, 0, bufferSize)
                    context.Response.BinaryWrite(bytes)
                    readFrom += bufferSize
                Loop While bytesRead = bufferSize
            End If
            r.Close()
        Finally
            con.Close()
        End Try
    End Sub

    Public ReadOnly Property IsReusable() As Boolean
        Get
            Return True
        End Get
    End Property

    Public ReadOnly Property IsReusable1() As Boolean Implements System.Web.IHttpHandler.IsReusable
        Get
        End Get
    End Property
    'Implements System.Web.IHttpHandler.ProcessRequest
    Public Sub ProcessRequest1(
        ByVal context As System.Web.HttpContext
        )
    End Sub
End Class
