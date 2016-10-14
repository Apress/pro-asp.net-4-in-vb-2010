
Partial Class MasterPages_DynamicContentPage
    Inherits System.Web.UI.Page

    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        Me.MasterPageFile = "TableMaster.master"
    End Sub
End Class
