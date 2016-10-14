<%@ WebHandler Language="VB" Class="CalculatorCallbackHandler" %>

Imports System
Imports System.Web
Public Class CalculatorCallbackHandler : Implements IHttpHandler
    
   Public Sub ProcessRequest(ByVal context As HttpContext) _
      Implements IHttpHandler.ProcessRequest
      Dim response As HttpResponse = context.Response

      ' Write ordinary text.
      response.ContentType = "text/plain"

      ' Get the query string arguments.        
      Dim value1 As Single, value2 As Single
      If [Single].TryParse(context.Request.QueryString("value1"), value1) AndAlso
          [Single].TryParse(context.Request.QueryString("value2"), value2) Then
         response.Write(value1 + value2)
         response.Write(",")
         Dim now As DateTime = DateTime.Now
         response.Write(now.ToLongTimeString())
      Else
         ' Indicate an error.
         response.Write("-")
      End If
   End Sub
 
   Public ReadOnly Property IsReusable() As Boolean _
       Implements IHttpHandler.IsReusable
      Get
         Return True
      End Get
   End Property
End Class