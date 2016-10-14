Imports System.Security.Principal
Imports System.Runtime.InteropServices

Partial Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As EventArgs
        ) Handles Me.Load
        If TypeOf User Is WindowsPrincipal Then
            ' First of all, output some user information 

            Dim principal As WindowsPrincipal = DirectCast(User, WindowsPrincipal)
            'lblInfo.Text &= "<br><b>Power user? </b>"
            'lblInfo.Text &=
            '    principal.IsInRole(WindowsBuiltInRole.PowerUser).ToString()

            Dim identity As WindowsIdentity =
                DirectCast(principal.Identity, WindowsIdentity)
            'lblInfo.Text &= "<br><b>Token: </b>"
            'lblInfo.Text &= identity.Token.ToString()
            'lblInfo.Text &= "<br><b>Guest? </b>"
            'lblInfo.Text &= identity.IsGuest.ToString()
            'lblInfo.Text &= "<br><b>System? </b>"
            'lblInfo.Text &= identity.IsSystem.ToString()

            ' Next get the roles for the user 
            lblInfo.Text &= "<hr/>"
            lblInfo.Text &= "<h2>Roles:</h2>"

            For Each SIDRef As IdentityReference In identity.Groups
                lblInfo.Text &= "<br/>---"

                Try
                    ' Get the system-code for the SID 
                    Dim sid As SecurityIdentifier =
                        DirectCast(SIDRef.Translate(
                                GetType(SecurityIdentifier)
                                ), SecurityIdentifier)
                    lblInfo.Text &= "<br><b>SID (code): </b></br>"
                    lblInfo.Text &= sid.Value
                Catch ex As Exception
                    lblInfo.Text &= "Unable to translate reference: " & SIDRef.Value
                End Try

                Try
                    ' Get the human-readable SID 
                    Dim account As NTAccount =
                        DirectCast(SIDRef.Translate(GetType(NTAccount)), NTAccount)
                    lblInfo.Text &= "<br><b>SID (human-readable): </b></br>"
                    lblInfo.Text &= account.Value
                Catch ex As Exception
                    lblInfo.Text &= "Unable to translate sid: " & ex.Message
                End Try
            Next
        End If
    End Sub
End Class