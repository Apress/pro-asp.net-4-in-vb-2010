
Partial Class NavigationAdvanced_NavigationList
    Inherits System.Web.UI.Page

    Protected Sub cmdUp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdUp.Click
        Response.Redirect(SiteMap.CurrentNode.ParentNode.Url)
    End Sub
End Class
