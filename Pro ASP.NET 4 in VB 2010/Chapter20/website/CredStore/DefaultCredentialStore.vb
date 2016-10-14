Imports System.Data
Imports System.Configuration
Imports System.Web.Configuration
Imports System.Web.Security
' <summary>
' Summary description for DefaultCredentialStore
' </summary>
Namespace CredentialStoreNamespace
    Public Class WebConfigCredentialStore
        Implements ICredentialStore


        Public Function Authenticate(ByVal userName As String, ByVal userPassword As String) As Boolean Implements ICredentialStore.Authenticate
            Return FormsAuthentication.Authenticate(userName, userPassword)
        End Function

        Public Sub CreateUser(ByVal userName As String, ByVal userPassword As String) Implements ICredentialStore.CreateUser
            Dim MyConfig As Configuration = WebConfigurationManager.OpenWebConfiguration("~/")
            Dim SystemWeb As ConfigurationSectionGroup = MyConfig.SectionGroups("system.web")
            Dim AuthSec As AuthenticationSection = DirectCast(SystemWeb.Sections("authentication"), AuthenticationSection)
            AuthSec.Forms.Credentials.Users.Add(New FormsAuthenticationUser(userName, FormsAuthentication.HashPasswordForStoringInConfigFile(userPassword, "SHA1")))
            MyConfig.Save()
        End Sub
    End Class

End Namespace
