Imports System.IO

Partial Class ThumbnailsInDirectory
    Inherits System.Web.UI.Page

    Protected Sub cmdShow_Click(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Button1.Click
        ' Get a string array with all the image files.
        Dim dir As New DirectoryInfo(txtDir.Text)
        gridThumbs.DataSource = dir.GetFiles()

        ' Bind the string array.
        gridThumbs.DataBind()
    End Sub
    Protected Function GetImageUrl(
        ByVal path As Object
        ) As String
        Return "ThumbnailViewer.aspx?x=50&y=50&FilePath=" &
            Server.UrlEncode(DirectCast(path, String))
    End Function
End Class
