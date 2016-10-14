Imports System.Security.Principal
Imports System.Threading

Public Class Impersonate
    Inherits System.Web.UI.Page
    Private Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        If TypeOf User Is WindowsPrincipal Then
            DisplayIdentity()

            ' Impersonate the IIS identity.
            Dim id As WindowsIdentity
            id = DirectCast(User.Identity, WindowsIdentity)
            Dim impersonateContext As WindowsImpersonationContext
            impersonateContext = id.Impersonate()
            DisplayIdentity()

            ' Revert to the original ID as shown here.
            impersonateContext.Undo()
            DisplayIdentity()
        Else
            ' User isn't Windows authenticated.
            ' Throw an error or take other steps.
        End If
    End Sub

    Private Sub DisplayIdentity()
        ' Get the identity under which the code is currently executing.
        Dim identity As WindowsIdentity = WindowsIdentity.GetCurrent()
        lblInfo.Text &= "Executing as: " & identity.Name & "<br>"
    End Sub

End Class