
Partial Class NavigationAdvanced_Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        If Request.QueryString("category") <> Nothing Then
            lblQuery.Text =
                "Category = " & Request.QueryString("category")
        End If
    End Sub
End Class
