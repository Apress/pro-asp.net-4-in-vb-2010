
Partial Class GetBookImage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        Dim findBook As New FindBook()
        Dim url As String =
            findBook.GetImageUrl(Request.QueryString("isbn"))
        Response.Redirect(url)
    End Sub
End Class
