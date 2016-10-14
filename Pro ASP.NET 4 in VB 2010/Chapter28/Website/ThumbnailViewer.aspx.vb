Imports System.Drawing
Imports System.Drawing.Imaging

Partial Class ThumbnailViewer
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        If ([String].IsNullOrEmpty(Request.QueryString("X"))) OrElse
            ([String].IsNullOrEmpty(Request.QueryString("Y"))) OrElse
            ([String].IsNullOrEmpty(Request.QueryString("FilePath"))) Then
            ' There is missing data, so don't display anything.
            ' Other options include choosing reasonable defaults
            ' or returning an image with some static error text.
        Else
            Dim x As Integer = Int32.Parse(Request.QueryString("X"))
            Dim y As Integer = Int32.Parse(Request.QueryString("Y"))
            Dim file As String = Server.UrlDecode(Request.QueryString("FilePath"))

            ' Create the in-memory bitmap where you will draw the image.
            Dim image As New Bitmap(x, y)
            Dim g As Graphics = Graphics.FromImage(image)
            ' Load the file data.
            Dim thumbnail As System.Drawing.Image =
                System.Drawing.Image.FromFile(file)

            ' Draw the thumbnail.
            g.DrawImage(thumbnail, 0, 0, x, y)
            ' Render the image.
            image.Save(Response.OutputStream, ImageFormat.Jpeg)
            g.Dispose()
            image.Dispose()
        End If
    End Sub
End Class
