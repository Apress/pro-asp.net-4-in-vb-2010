Imports System
Imports System.Web
Imports System.IO
Imports System.Globalization

Public Class ImageGuardHandler
    Implements IHttpHandler
    Public Sub ProcessRequest(ByVal context As System.Web.HttpContext) Implements _
                System.Web.IHttpHandler.ProcessRequest
        Dim response As HttpResponse = context.Response
        Dim request As HttpRequest = context.Request

        Dim imagePath As String = Nothing
        If request.UrlReferrer IsNot Nothing Then
            ' Perform a case-insensitive comparison. 
            If [String].Compare(request.Url.Host, request.UrlReferrer.Host,
                True, CultureInfo.InvariantCulture) = 0 Then
                ' The requesting host is correct. 
                ' Allow the image (if it exists). 
                imagePath = request.PhysicalPath
                If Not File.Exists(imagePath) Then
                    response.Status = "Image not found"
                    response.StatusCode = 404
                    Return
                End If
            End If
        End If

        If imagePath Is Nothing Then
            ' No valid image was allowed. 
            ' Use the warning image instead. 
            ' Rather than hard-code this image, you could 
            ' retrieve it from the web.config file 
            ' (using the <appSettings> section or a custom 
            ' section). 
            imagePath = context.Server.MapPath("~/Images/notAllowed.gif")
        End If

        ' Serve the image 
        ' Set the content type to the appropriate image type. 
        response.ContentType = "image/" &
            Path.GetExtension(imagePath).ToLower()
        response.WriteFile(imagePath)
    End Sub

    Public ReadOnly Property IsReusable(
            ) As Boolean Implements System.Web.IHttpHandler.IsReusable
        Get
            Return True
        End Get
    End Property
End Class