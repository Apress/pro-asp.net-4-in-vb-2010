
Partial Class SimpleTimeDisplay
    Inherits System.Web.UI.UserControl
    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        If Not Page.IsPostBack Then RefreshTime()
    End Sub
    Protected Sub lnkTime_Click(
        ByVal sender As Object, ByVal e As EventArgs
        ) Handles lnkTime.Click
        RefreshTime()
    End Sub
    Public Sub RefreshTime()
        lnkTime.Text = DateTime.Now.ToLongTimeString()
    End Sub
End Class
