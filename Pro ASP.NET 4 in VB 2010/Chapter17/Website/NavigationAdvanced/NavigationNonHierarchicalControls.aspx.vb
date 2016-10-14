
Partial Class NavigationAdvanced_NavigationNonHierarchicalControls
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            lstChild.DataSource = SiteMap.CurrentNode.ParentNode.ChildNodes
            lstParent.DataSource = SiteMap.CurrentNode.ParentNode.ParentNode.ChildNodes
            lstChild.DataTextField = "Title"
            lstChild.DataValueField = "Url"
            lstParent.DataTextField = "Title"
            lstParent.DataValueField = "Url"
            Me.DataBind()
        End If
    End Sub
    Protected Sub Nav_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim ctrl As ListControl = DirectCast(sender, ListControl)
        Dim node As SiteMapNode = SiteMap.Provider.FindSiteMapNode(ctrl.SelectedValue)
        Response.Redirect(node.Url)
    End Sub
End Class
