
Partial Class WaitIndicator
    Inherits System.Web.UI.Page

    Protected Sub cmdRefreshTime_Click(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles cmdRefreshTime.Click
        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(10))
        lblTime.Text = DateTime.Now.ToLongTimeString()
    End Sub
End Class
