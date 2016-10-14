
Partial Class Frame1
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Button1.Click
        Dim url As String = "http://www.bing.com"
        Dim frameScript As String =
            "<script type='text/javascript'>" &
            "window.parent.content.location='" &
            url & "';</script>"
        Page.ClientScript.RegisterStartupScript(
            Me.[GetType](), "FrameScript", frameScript)
    End Sub
End Class
