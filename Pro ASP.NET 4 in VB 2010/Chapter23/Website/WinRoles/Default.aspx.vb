
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        If User IsNot Nothing And User.Identity.IsAuthenticated Then
            Dim rp As RolePrincipal = DirectCast(User, RolePrincipal)
            Dim Info As New StringBuilder()
            Info.AppendFormat("<h2>Welcome {0}!</h2>", User.Identity.Name)
            Info.AppendFormat("<b>Provider: </b>{0}<br>", rp.ProviderName)
            Info.AppendFormat("<b>Version: </b>{0}<br>", rp.Version)
            Info.AppendFormat("<b>Expiration: </b>{0}<br>", rp.ExpireDate)
            Info.AppendFormat("<b>Roles: </b><br>")
            Dim Roles As String() = rp.GetRoles()
            For Each role As String In Roles
                If Not Roles.Equals(String.Empty) Then
                    Info.AppendFormat("-) {0}<br>", role)
                End If
            Next
            LabelPrincipalInfo.Text = Info.ToString()
        End If
    End Sub
End Class
