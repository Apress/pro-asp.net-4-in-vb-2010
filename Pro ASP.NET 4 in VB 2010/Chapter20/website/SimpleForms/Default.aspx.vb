Imports System.IO
Imports System.Web.Security
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim htmlString As New StringBuilder()
        ' Has the request been authenticated?
        If Request.IsAuthenticated Then
            ' Display generic identity information.
            ' This is always available, regardless of the type of
            ' authentication.
            htmlString.Append("<h3>Generic User Information</h3>")
            htmlString.Append("<b>name: </b>")
            htmlString.Append(User.Identity.Name)
            htmlString.Append("<br><b>Authenticated With: </b>")
            htmlString.Append(User.Identity.AuthenticationType)
            htmlString.Append("<br><br>")
        End If
        ' Was forms authentication used?

        If TypeOf User.Identity Is FormsIdentity Then
            ' Get the ticket.
            Dim ticket As FormsAuthenticationTicket = (DirectCast(User.Identity, FormsIdentity)).Ticket
            htmlString.Append("<h3>Ticket User Information</h3>")
            htmlString.Append("<b>Name: </b>")
            htmlString.Append(ticket.Name)
            htmlString.Append("<br><b>Issued at: </b>")
            htmlString.Append(ticket.IssueDate)
            htmlString.Append("<br><b>Expires at: </b>")
            htmlString.Append(ticket.Expiration)
            htmlString.Append("<br><b>Cookie version: </b>")
            htmlString.Append(ticket.Version)

            ' Display the information.
            LegendInfo.Text = htmlString.ToString()
        End If
        
    End Sub

    Protected Sub SignOutAction_Click(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles SignOutAction.Click
        FormsAuthentication.SignOut()
        FormsAuthentication.RedirectToLoginPage()
    End Sub
End Class
