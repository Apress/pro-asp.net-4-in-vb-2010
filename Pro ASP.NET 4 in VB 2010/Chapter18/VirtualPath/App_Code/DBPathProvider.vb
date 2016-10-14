Imports System.Web.Hosting
Imports System.Data.SqlClient
Imports System.IO

Public Class DBPathProvider
    Inherits VirtualPathProvider

    Public Shared Sub AppInitialize()
        HostingEnvironment.RegisterVirtualPathProvider(New DBPathProvider())
    End Sub

    Public Overrides Function FileExists(ByVal virtualPath As String) As Boolean
        Dim contents As String = Me.GetFileFromDB(virtualPath)
        If contents.Equals(String.Empty) Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Overrides Function GetFile(ByVal virtualPath As String) As VirtualFile
        Dim contents As String = Me.GetFileFromDB(virtualPath)
        If contents.Equals(String.Empty) Then
            Return Previous.GetFile(virtualPath)
        Else
            Return New DBVirtualFile(virtualPath, contents)
        End If
    End Function

    Private Function GetFileFromDB(ByVal virtualPath As String) As String
        Dim contents As String
        Dim fileName As String =
            virtualPath.Substring(virtualPath.IndexOf("/"c, 1) + 1)

        ' Read the file from the database
        Dim conn As New SqlConnection()
        conn.ConnectionString =
            "Data Source=.\SQLEXPRESS;" &
            "AttachDbFileName=|DataDirectory|AspNetContents.mdf;" &
            "Integrated Security=True;User Instance=True"
        conn.Open()

        Try
            Dim cmd As New SqlCommand(
                "SELECT FileContents FROM AspContent " &
                "WHERE FileName=@fn", conn
                )
            cmd.Parameters.AddWithValue("@fn", fileName)
            contents = TryCast(cmd.ExecuteScalar(), String)
            If contents Is Nothing Then
                contents = String.Empty
            End If
        Catch
            contents = String.Empty
        Finally
            conn.Close()
        End Try

        Return contents
    End Function

    Public Class DBVirtualFile
        Inherits VirtualFile

        Private _FileContent As String

        Public Sub New(
            ByVal virtualPath As String, ByVal fileContent As String
            )
            MyBase.New(virtualPath)
            _FileContent = fileContent
        End Sub

        Public Overrides Function Open() As Stream
            Dim stream As Stream = New MemoryStream()
            Dim writer As New StreamWriter(stream, Encoding.Unicode)

            writer.Write(_FileContent)
            writer.Flush()
            stream.Seek(0, SeekOrigin.Begin)
            Return stream
        End Function
    End Class

End Class

