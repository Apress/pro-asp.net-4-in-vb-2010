Imports System.Web.Configuration
Imports System.Data.SqlClient
Imports System.Data

Partial Class SimpleImageRender
    Inherits System.Web.UI.Page

    ' Version 1 - Without Sequential Access
    'Protected Sub Page_Load(
    '    ByVal sender As Object, ByVal e As System.EventArgs
    '    ) Handles Me.Load
    '    Dim connectionString As String =
    '            WebConfigurationManager.ConnectionStrings("Pubs").ConnectionString
    '    Dim con As New SqlConnection(connectionString)
    '    Dim SQL As String = "SELECT logo FROM pub_info WHERE pub_id='1389'"
    '    Dim cmd As New SqlCommand(SQL, con)

    '    Try
    '        con.Open()
    '        Dim r As SqlDataReader = cmd.ExecuteReader()
    '        If r.Read() Then
    '            Dim bytes As Byte() = DirectCast(r("logo"), Byte())
    '            Response.BinaryWrite(bytes)
    '        End If
    '        r.Close()
    '    Finally
    '        con.Close()
    '    End Try
    'End Sub

    ' Version 2 - Sequential Access


    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        Dim connectionString As String =
                WebConfigurationManager.ConnectionStrings("Pubs").ConnectionString
        Dim con As New SqlConnection(connectionString)
        Dim SQL As String = "SELECT logo FROM pub_info WHERE pub_id='1389'"
        Dim cmd As New SqlCommand(SQL, con)

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
                    Context.Response.BinaryWrite(bytes)
                    readFrom += bufferSize
                Loop While bytesRead = bufferSize
            End If
            r.Close()
        Finally
            con.Close()
        End Try
    End Sub
End Class
