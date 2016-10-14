
Partial Class PageProcessor_Target
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        ' Simulate a slow page loading (wait 5 seconds).
        System.Threading.Thread.Sleep(5000)
    End Sub
End Class
