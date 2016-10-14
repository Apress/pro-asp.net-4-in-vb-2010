Partial Class GetAllProfiles
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        GridView1.DataSource =
            ProfileManager.GetAllProfiles(
                ProfileAuthenticationOption.Authenticated
                )
        GridView1.DataBind()
    End Sub
End Class
