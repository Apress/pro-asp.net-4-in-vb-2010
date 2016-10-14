
Partial Class UpdatePanelTest
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        Label1.Text = DateTime.Now.ToLongTimeString()
        Label2.Text = DateTime.Now.ToLongTimeString()
        Label3.Text = DateTime.Now.ToLongTimeString()
        If IsPostBack Then Throw New ApplicationException("This operation failed.")
    End Sub
End Class
