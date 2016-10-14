Partial Class Login2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        If Not Me.IsPostBack Then
            ViewState("LoginErrors") = 0
        End If
    End Sub

    Protected Sub LoginCtrl_LoginError(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles LoginCtrl.LoginError
        ' Increase the number of invalid logins
        Dim ErrorCount As Integer = CInt(ViewState("LoginErrors") + 1)
        ViewState("LoginErrors") = ErrorCount

        ' Now validate the number of errors
        If ErrorCount > 3 And LoginCtrl.PasswordRecoveryUrl IsNot String.Empty Then
            Response.Redirect(LoginCtrl.PasswordRecoveryUrl)
        End If
    End Sub

    Protected Sub OtherLoginCtrl_Authenticate(
        ByVal sender As Object, ByVal e As System.Web.UI.WebControls.AuthenticateEventArgs
        ) Handles OtherLoginCtrl.Authenticate
        Dim AccessKeyText As TextBox = DirectCast(
            OtherLoginCtrl.FindControl("AccessKey"), TextBox
            )

        If System.Web.Security.Membership.ValidateUser(
            AccessKeyText.Text, OtherLoginCtrl.UserName
            ) Then
            e.Authenticated = True
        Else
            e.Authenticated = False
        End If
    End Sub
End Class