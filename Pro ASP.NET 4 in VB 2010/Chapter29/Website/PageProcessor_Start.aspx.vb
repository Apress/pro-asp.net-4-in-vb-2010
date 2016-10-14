
Partial Class PageProcessor_Start
    Inherits System.Web.UI.Page

    Protected Sub cmdGo_Click(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles cmdGo.Click
        Server.Transfer("PageProcessor.aspx?Page=PageProcessor_Target.aspx")
    End Sub
End Class
