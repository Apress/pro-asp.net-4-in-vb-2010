Imports System.Diagnostics

Partial Class CreateUser
    Inherits System.Web.UI.Page

    Protected Sub ActionAddUser_Click(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles ActionAddUser.Click
        Try
            Dim Status As MembershipCreateStatus
            Membership.CreateUser(
                UserNameText.Text, PasswordText.Text,
                UserEmailText.Text, PwdQuestionText.Text,
                PwdAnswerText.Text, True, Status
                )
            StatusLabel.Text = "User created successfully!"
        Catch ex As Exception
            Debug.WriteLine("Exception: " & ex.Message)
            StatusLabel.Text = "Unable to create user!"
        End Try

        If Membership.ValidateUser(UserNameText.Text, PasswordText.Text) Then
            FormsAuthentication.RedirectFromLoginPage(UserNameText.Text, False)
        Else
            ' Invalid user name or password processing
        End If
    End Sub
End Class
