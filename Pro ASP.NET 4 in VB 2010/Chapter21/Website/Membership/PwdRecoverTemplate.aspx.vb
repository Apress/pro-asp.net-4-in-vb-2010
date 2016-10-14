
Partial Class PwdRecoverTemplate
    Inherits System.Web.UI.Page

    Protected Sub PasswordTemplateCtrl_SendingMail(
        ByVal sender As Object,
        ByVal e As System.Web.UI.WebControls.MailMessageEventArgs
        ) Handles PasswordTemplateCtrl.SendingMail
        Dim lbl As Label =
            DirectCast(
                PasswordTemplateCtrl.SuccessTemplateContainer.FindControl(
                    "EmailLabel"
                    ), 
                Label
                )
        lbl.Text = e.Message.To(0).Address
    End Sub
End Class
