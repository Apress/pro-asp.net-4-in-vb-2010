
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub PostbackCommand_OnClick(ByVal sender As Object, ByVal e As EventArgs)
        ResultsLabel.Text = DateTime.Now.ToLongTimeString()
    End Sub
End Class
