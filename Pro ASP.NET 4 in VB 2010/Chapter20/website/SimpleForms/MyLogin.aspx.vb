
Partial Class MyLogin
    Inherits System.Web.UI.Page

    Protected Sub LoginAction_Click(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles LoginAction.Click
        Page.Validate()
        If Not Page.IsValid Then
            Return
        End If

        If FormsAuthentication.Authenticate(UsernameText.Text, PasswordText.Text) Then
            ' Create the ticket, add the cookie to the response 
            ' and redirect to the originally requested page 
            FormsAuthentication.RedirectFromLoginPage(UsernameText.Text, False)
        Else
            ' Username and password are not correct 
            LegendStatus.Text = "Invalid username or password!"
        End If
    End Sub
End Class
