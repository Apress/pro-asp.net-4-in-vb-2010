Imports System.Web.Security
Partial Class CreateTest
    Inherits System.Web.UI.Page

    Protected Sub AddRoleCommand_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles AddRoleCommand.Click

        System.Web.Security.Roles.CreateRole(RoleNameText.Text)
    End Sub

    Protected Sub CreateUserWizard1_ContinueButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles CreateUserWizard1.ContinueButtonClick
        Response.Redirect("CreateTest.aspx")
    End Sub
End Class
