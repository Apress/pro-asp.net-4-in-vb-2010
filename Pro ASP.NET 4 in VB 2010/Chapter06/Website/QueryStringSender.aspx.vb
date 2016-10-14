
Partial Class QueryStringSender
    Inherits System.Web.UI.Page

    Protected Sub cmd_Click(
        ByVal sender As Object, ByVal e As EventArgs
            ) Handles cmdNormal.Click, cmdSmall.Click, cmdLarge.Click
        Response.Redirect("QueryStringRecipient.aspx" &
            "?Version=" & DirectCast(sender, Control).ID)
    End Sub
End Class
