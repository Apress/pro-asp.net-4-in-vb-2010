<%@ WebHandler Language="VB" Class="HttpExtensions.SimpleHandler" %>
Imports System
Imports System.Web
Namespace HttpExtensions
    Public Class SimpleHandler
        Implements IHttpHandler
        Public Sub ProcessRequest(ByVal context As System.Web.HttpContext) Implements _
                System.Web.IHttpHandler.ProcessRequest
            Dim response As HttpResponse = context.Response
            response.Write("<html><body><h1>Rendered by the SimpleHandler")
            response.Write("</h1></body></html>")
        End Sub

        Public ReadOnly Property IsReusable() As Boolean _
                Implements System.Web.IHttpHandler.IsReusable
            Get
                Return True
            End Get
        End Property
    End Class
End Namespace

