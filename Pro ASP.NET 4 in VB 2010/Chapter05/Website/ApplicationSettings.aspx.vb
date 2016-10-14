Imports System.Web.Configuration

Partial Class Welcome_aspx
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        Dim config As Configuration =
            WebConfigurationManager.OpenWebConfiguration(Request.ApplicationPath)
        lblSiteName.Text = config.AppSettings.Settings("websiteName").Value
        lblWelcome.Text = config.AppSettings.Settings("welcomeMessage").Value
        If (config.AppSettings.Settings("welcomeMessage").Value.Length > 15) Then
            config.AppSettings.Settings("welcomeMessage").Value = "Welcome, again."
        Else
            config.AppSettings.Settings("welcomeMessage").Value = "Welcome, friend."
        End If
        config.Save()
    End Sub
End Class
