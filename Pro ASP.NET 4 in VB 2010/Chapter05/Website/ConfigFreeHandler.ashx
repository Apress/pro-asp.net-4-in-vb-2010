<%@ WebHandler Language="VB" Class="ConfigFreeHandler" %>

Imports System
Imports System.Web

Public Class ConfigFreeHandler : Implements IHttpHandler
    
    Public Sub ProcessRequest(
        ByVal context As HttpContext
        ) Implements IHttpHandler.ProcessRequest
        Dim response As HttpResponse = context.Response
        response.Write("<html><body><h1>Rendered by the ConfigFreeHandler")
        response.Write("</h1></body></html>")
    End Sub
 
    Public ReadOnly Property IsReusable(
        ) As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class