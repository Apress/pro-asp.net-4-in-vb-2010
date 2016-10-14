Imports System
Imports System.Web
Namespace HttpExtensions
    Public Class SimpleHandler
        Implements IHttpHandler
        Public Sub ProcessRequest(
            ByVal context As System.Web.HttpContext
            ) Implements System.Web.IHttpHandler.ProcessRequest
            Dim response As HttpResponse = context.Response
            response.Write("<html><body><h1>Rendered by the SimpleHandler")
            response.Write("</h1></body></html>")
        End Sub

        Public ReadOnly Property IsReusable(
            ) As Boolean Implements System.Web.IHttpHandler.IsReusable
            Get
                Return True
            End Get
        End Property
    End Class
End Namespace

