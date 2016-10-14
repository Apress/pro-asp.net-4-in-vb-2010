Imports System.IO
Imports System.Collections

Namespace HttpExtensions
    Public Class SourceHandler
        Implements IHttpHandler
        Public Sub ProcessRequest(
            ByVal context As System.Web.HttpContext
            ) Implements System.Web.IHttpHandler.ProcessRequest
            ' Make the HTTP context objects easily available. 
            Dim response As HttpResponse = context.Response
            Dim request As HttpRequest = context.Request
            Dim server As HttpServerUtility = context.Server

            response.Write("<html><body>")

            ' Get the name of the requested file. 
            Dim file_Name As String = request.QueryString("file")
            Try
                ' Open the file and display its contents, one line at a time. 
                response.Write("<b>Listing " & file_Name & "</b><br>")
                Dim r As StreamReader =
                    File.OpenText(server.MapPath(Path.Combine("./", file_Name)))
                Dim line As String = ""
                While line IsNot Nothing
                    line = r.ReadLine()

                    If line IsNot Nothing Then
                        ' Make sure tags and other special characters are 
                        ' replaced by their corresponding HTML entities, so they 
                        ' can be displayed appropriately. 
                        line = server.HtmlEncode(line)

                        ' Replace spaces and tabs with non-breaking spaces 
                        ' to preserve whitespace. 
                        line =
                            line.Replace(" ", "&nbsp;")
                        line =
                            line.Replace("" & Chr(9) & "",
                            "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")

                        ' A more sophisticated source viewer might apply color-coding. 
                        response.Write(line & "<br>")
                    End If
                End While
                r.Close()
            Catch err As ApplicationException
                response.Write(err.Message)
            End Try
            response.Write("</html></body>")
        End Sub

        Public ReadOnly Property IsReusable(
            ) As Boolean Implements System.Web.IHttpHandler.IsReusable
            Get
                Return True
            End Get
        End Property
    End Class
End Namespace