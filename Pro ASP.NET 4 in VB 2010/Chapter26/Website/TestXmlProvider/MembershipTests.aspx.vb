﻿
Partial Class MembershipTests
    Inherits System.Web.UI.Page
    Private Sub WriteUsers(ByVal users As MembershipUserCollection)
        Dim Info As New StringBuilder()

        For Each SingleUser As MembershipUser In users
            Info.AppendFormat("{0} ({1})<BR>", SingleUser.UserName, SingleUser.Email)
        Next

        ResultsLabel.Text = Info.ToString()
    End Sub
    Private Sub WriteUserDetails(ByVal singleUser As MembershipUser)
        Dim Info As New StringBuilder()

        Info.AppendFormat("{0}<br>", singleUser.UserName)
        Info.AppendFormat("{0}<br>", singleUser.Email)
        Info.AppendFormat("{0}<br>", singleUser.CreationDate)
        Info.AppendFormat("{0}<br>", singleUser.Comment)

        ResultsLabel.Text = Info.ToString()
    End Sub

    Protected Sub DeleteUser_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DeleteUser.Click
        If Membership.DeleteUser(UserNameText.Text) Then
            ResultsLabel.Text = "Successfully deleted user!"
        Else
            ResultsLabel.Text = "Unable to delete user!"
        End If
    End Sub

    Protected Sub FindByName_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles FindByName.Click
        Dim Users As MembershipUserCollection = Membership.FindUsersByName(UserNameText.Text)
        WriteUsers(Users)
    End Sub

    Protected Sub FindByEmail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles FindByEmail.Click
        Dim Users As MembershipUserCollection = Membership.FindUsersByEmail(UserNameText.Text)
        WriteUsers(Users)
    End Sub

    Protected Sub GetAllUsers_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles GetAllUsers.Click
        Dim Users As MembershipUserCollection = Membership.GetAllUsers()
        WriteUsers(Users)
    End Sub

    Protected Sub GetUser_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles GetUser.Click
        WriteUserDetails(Membership.GetUser(UserNameText.Text))
    End Sub

    Protected Sub GetUserNameByEmail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles GetUserNameByEmail.Click
        ResultsLabel.Text = Membership.GetUserNameByEmail(UserNameText.Text)
    End Sub

    Protected Sub UpdateUser_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles UpdateUser.Click
        Dim SingleUser As MembershipUser = Membership.GetUser(UserNameText.Text)
        SingleUser.Comment = "Updated on " + DateTime.Now.ToString()
        Membership.UpdateUser(SingleUser)
    End Sub
End Class
