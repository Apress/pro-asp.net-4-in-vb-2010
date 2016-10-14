
Partial Class ImageMap
    Inherits System.Web.UI.Page

    Protected Sub ImageMap1_Click(
        ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ImageMapEventArgs
        ) Handles ImageMap1.Click
        Label1.Text = "You clicked: " & e.PostBackValue
    End Sub
End Class
