
Partial Class MasterPages_Customizable1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        Dim master As MasterPages_CustomizableMasterPage =
            DirectCast(Me.Master, MasterPages_CustomizableMasterPage)
        master.BannerText = "Content Page #1"
    End Sub
End Class
