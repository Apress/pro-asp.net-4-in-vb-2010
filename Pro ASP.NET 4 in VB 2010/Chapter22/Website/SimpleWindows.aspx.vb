Imports System.Security.Principal
Partial Public Class SimpleWindows
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As EventArgs
        ) Handles Me.Load
        If Request.IsAuthenticated Then
            ' Display generic identity information. 
            lblInfo.Text = "<b>Name: </b>" & User.Identity.Name
            lblInfo.Text &= "<br><b>Authenticated With: </b>"
            lblInfo.Text &= User.Identity.AuthenticationType

            If TypeOf User Is WindowsPrincipal Then
                Dim principal As WindowsPrincipal =
                    DirectCast(User, WindowsPrincipal)
                lblInfo.Text &= "<br><b>Power user? </b>"
                lblInfo.Text &= principal.IsInRole(
                 WindowsBuiltInRole.PowerUser).ToString()

                Dim identity As WindowsIdentity =
                    TryCast(principal.Identity, WindowsIdentity)
                lblInfo.Text &= "<br><b>Token: </b>"
                lblInfo.Text &= identity.Token.ToString()
                lblInfo.Text &= "<br><b>Guest? </b>"
                lblInfo.Text &= identity.IsGuest.ToString()
                lblInfo.Text &= "<br><b>System? </b>"
                lblInfo.Text &= identity.IsSystem.ToString()

            End If
        End If
    End Sub

End Class