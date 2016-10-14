
Partial Class ScriptInjectionAttack
    Inherits System.Web.UI.Page

    Protected Sub cmdSubmit_Click(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles cmdSubmit.Click
        lblInfo.Text = txtInput.Text
        'lblInfo.Text = "You entered: " & Server.HtmlEncode(txtInput.Text)
    End Sub
End Class
