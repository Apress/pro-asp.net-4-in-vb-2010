
Partial Class NavigationCustomProvider_Software
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblHead.Text = SiteMap.CurrentNode.Title
    End Sub
End Class
