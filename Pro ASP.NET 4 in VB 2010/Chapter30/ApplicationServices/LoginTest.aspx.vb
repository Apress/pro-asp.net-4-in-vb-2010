
Partial Class LoginTest
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        If Not Page.IsPostBack Then
            ' Create test user.
            If Membership.GetUser("test") Is Nothing Then
                Dim status As MembershipCreateStatus
                Membership.CreateUser(
                    "test",
                    "test99!",
                    "",
                    "Why should you not panic?",
                    "This is only a test.",
                    True,
                 status)
                If status <> MembershipCreateStatus.Success Then
                    lblInfo.InnerHtml =
                        "Attempt to create user ""test"" failed with " &
                        status.ToString()
                    Return
                End If

                ' Place test user in role. 
                If Not Roles.RoleExists("Administrator") Then
                    Roles.CreateRole("Administrator")
                End If
                Roles.AddUserToRole("test", "Administrator")

                ' Assign profile values.
                Dim theProfile As ProfileCommon = Profile.GetProfile("test")
                theProfile.FirstName = "George"
                theProfile.LastName = "OftheJungle"
                theProfile.CustomerCode = "Whatever"
                theProfile.Save()
            End If
        End If
    End Sub
End Class
