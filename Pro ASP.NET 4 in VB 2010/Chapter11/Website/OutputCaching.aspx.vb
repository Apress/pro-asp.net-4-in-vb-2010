Partial Public Class OutputCaching
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As EventArgs
        ) Handles Me.Load
        lblDate.Text = "The time is now:<br>"
        lblDate.Text += DateTime.Now.ToString()
    End Sub
End Class