
Partial Class WebServiceCallback
    Inherits System.Web.UI.Page
    Protected Sub cmdOK_Click(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles cmdOK.Click
        lblInfo.Text = "You selected territory ID #" &
            Request.Form("lstTerritories")
        lstRegions.SelectedIndex = 0
    End Sub
End Class
