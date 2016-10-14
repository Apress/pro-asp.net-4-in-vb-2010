
Partial Class DynamicPanel
    Inherits System.Web.UI.Page

    Protected Sub Panel1_Refreshing(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Panel1.Refreshing
        Label1.Text = "This was refreshed without a postback at " &
            DateTime.Now.ToString()
    End Sub
End Class
