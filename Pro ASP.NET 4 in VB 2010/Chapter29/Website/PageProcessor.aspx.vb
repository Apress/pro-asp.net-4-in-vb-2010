
Partial Class PageProcessor
    Inherits System.Web.UI.Page
    Protected PageToLoad As String
    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        PageToLoad = Request.QueryString("Page")
    End Sub
End Class
