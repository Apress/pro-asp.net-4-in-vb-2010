Imports System.Web.Configuration

Partial Class UseCustomSettings
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        Dim builder As New StringBuilder()
        Dim config As Configuration =
            WebConfigurationManager.OpenWebConfiguration(Request.ApplicationPath)
        Dim custSection As OrderService =
            DirectCast(config.GetSection("orderService"), OrderService)
        lblInfo.Text &=
            "Retrieved service information...<br />" &
            "<b>Location (computer):</b> " &
            custSection.Location.Computer &
            "<br /><b>Available:</b> " &
            custSection.Available.ToString() &
            "<br /><b>Timeout:</b> " &
            custSection.PollTimeout.ToString() &
            "<br /><br />"
    End Sub
End Class
