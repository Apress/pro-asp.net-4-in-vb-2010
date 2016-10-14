Imports System.Web.Security

Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If User.Identity.IsAuthenticated Then
            Dim rp As RolePrincipal = DirectCast(User, RolePrincipal)
            Dim RoleInfo As New StringBuilder()
            RoleInfo.AppendFormat("<h2>Welcome {0}</h2>", rp.Identity.Name)
            RoleInfo.AppendFormat("<b>Provider:</b> {0}<BR>", rp.ProviderName)
            RoleInfo.AppendFormat("<b>Version:</b> {0}<BR>", rp.Version)
            RoleInfo.AppendFormat("<b>Expires at:</b> {0}<BR>", rp.ExpireDate)
            RoleInfo.Append("<b>Roles:</b> ")

            'for (int i = 0; i < roles.Length; i++)
            '{
            '    if (i > 0) RoleInfo.Append(", ");
            '    RoleInfo.Append(roles[i]);
            '}

            Dim roles As String() = rp.GetRoles()
            For i As Integer = 0 To roles.Length - 1
                If i > 0 Then
                    RoleInfo.Append(", ")
                End If
                RoleInfo.Append(roles(i))
            Next
            LabelRoleInformation.Text = RoleInfo.ToString()
        End If
    End Sub
End Class
