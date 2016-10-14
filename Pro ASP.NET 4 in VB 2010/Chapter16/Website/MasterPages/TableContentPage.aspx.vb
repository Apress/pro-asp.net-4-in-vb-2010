
Partial Class MasterPages_TableContentPage
    Inherits System.Web.UI.Page

    Protected Sub cmdHide_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdHide.Click
        Dim master As MasterPages_TableMaster = DirectCast(Me.Master, MasterPages_TableMaster)
        master.ShowNavigationControls = False
    End Sub

    Protected Sub cmdShow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        Dim master As MasterPages_TableMaster = DirectCast(Me.Master, MasterPages_TableMaster)
        master.ShowNavigationControls = True
    End Sub
End Class
