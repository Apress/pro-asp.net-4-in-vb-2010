Imports System.Web.Configuration

Partial Class EncryptConfig
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        Dim config As Configuration =
            WebConfigurationManager.OpenWebConfiguration(Request.ApplicationPath)
        Dim appSettings As ConfigurationSection = config.GetSection("appSettings")

        If appSettings.SectionInformation.IsProtected Then
            appSettings.SectionInformation.UnprotectSection()
            lblInfo.Text = "The appSettings section has now been unencrypted - "
        Else
            appSettings.SectionInformation.ProtectSection("DataProtectionConfigurationProvider")
            lblInfo.Text = "The appSettings section is protected with encryption -"
        End If
        config.Save()
        lblInfo.Text &= " web.config file saved."
    End Sub
End Class
