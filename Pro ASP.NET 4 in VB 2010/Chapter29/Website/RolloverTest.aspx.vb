
Partial Class RolloverTest
    Inherits System.Web.UI.Page

    Protected Sub RollOverButton1_ImageClicked(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles RollOverButton1.ImageClicked
        Response.Write("RollOverButton1 clicked.<br />")
    End Sub

    Protected Sub RollOverButton2_ImageClicked(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles RollOverButton2.ImageClicked
        Response.Write("RollOverButton2 clicked.<br />")
    End Sub
End Class
