Imports CredStore
Imports System.Reflection
Imports System.Web.Configuration
Imports System.Web.Security

Partial Class GenericLogin
    Inherits System.Web.UI.Page
    Private Function CreateStore() As ICredentialStore
        ' Read the configuration string of the format 
        ' assemblyname, namespace.classname 
        Dim ConfigEntry As String =
            WebConfigurationManager.AppSettings("CredentialStoreClass")
        Dim ConfigParts As String() = ConfigEntry.Split(New Char() {","c})

        ' Load the assembly with the implementations 
        Dim CurrentAsm As Assembly = Assembly.Load(ConfigParts(0).Trim())
        Dim Store As ICredentialStore = DirectCast(
                CurrentAsm.CreateInstance(
                    ConfigParts(0).Trim() & "." & ConfigParts(1).Trim()
                                          ), ICredentialStore)
        If Store Is Nothing Then
            Throw New Exception("Invalid credential store configuration!")
        Else
            Return Store
        End If
    End Function

    Protected Sub LoginAction_Click(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles LoginAction.Click
        Page.Validate()
        If Not Page.IsValid Then
            Return
        End If

        Dim CredStore As ICredentialStore = Me.CreateStore()

        If CredStore.Authenticate(UsernameText.Text, PasswordText.Text) Then
            FormsAuthentication.RedirectFromLoginPage(UsernameText.Text, False)
        Else
            LegendStatus.Text = "Invalid username or password!"
        End If
    End Sub

    Protected Sub RegisterAction_Click(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles RegisterAction.Click
        Page.Validate()
        If Not Page.IsValid Then
            Return
        End If

        Dim CredStore As ICredentialStore = Me.CreateStore()
        CredStore.CreateUser(UsernameText.Text, PasswordText.Text)
        LegendStatus.Text = "User created successfully, you can log in now!"
    End Sub
End Class
