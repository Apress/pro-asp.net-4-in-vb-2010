
Partial Class RolesTest
    Inherits System.Web.UI.Page
    Private Sub WriteResults(ByVal Results As String())
        Dim Info As New StringBuilder()
        For Each Result As String In Results
            Info.AppendFormat("{0}<br>", Result)
        Next
        ResultsLabel.Text = Info.ToString()
    End Sub

    Protected Sub DeleteRole_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DeleteRole.Click
        If Roles.DeleteRole(RoleNameText.Text) Then
            ResultsLabel.Text = "Role deleted successfully!"
        Else
            ResultsLabel.Text = "Unable to delete roles!"
        End If
    End Sub

    Protected Sub FindUsersInRole_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles FindUsersInRole.Click
        ResultsLabel.Text = ""
        WriteResults(Roles.FindUsersInRole(RoleNameText.Text, UserNameText.Text))
    End Sub

    Protected Sub GetAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles GetAll.Click
        WriteResults(Roles.GetAllRoles())
    End Sub

    Protected Sub GetRolesForUser_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles GetRolesForUser.Click
        WriteResults(Roles.GetRolesForUser(UserNameText.Text))
    End Sub

    Protected Sub GetUsersInRole_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles GetUsersInRole.Click
        WriteResults(Roles.GetUsersInRole(RoleNameText.Text))
    End Sub

    Protected Sub IsUserInRole_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles IsUserInRole.Click
        If Roles.IsUserInRole(UserNameText.Text, RoleNameText.Text) Then
            ResultsLabel.Text = "Yes"
        Else
            ResultsLabel.Text = "No"
        End If
    End Sub

    Protected Sub AddUserToRole_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles AddUserToRole.Click
        Roles.AddUserToRole(UserNameText.Text, RoleNameText.Text)
    End Sub

    Protected Sub RemoveUserFromRole_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RemoveUserFromRole.Click
        Roles.RemoveUserFromRole(UserNameText.Text, RoleNameText.Text)
    End Sub
End Class
