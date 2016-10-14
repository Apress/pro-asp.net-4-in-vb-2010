Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration

Partial Class DbLogin
    Inherits System.Web.UI.Page
    Public Function Myauthenticate(
        ByVal username As String, ByVal userPassword As String
        ) As Boolean
        Dim conn As New SqlConnection()
        conn.ConnectionString =
            WebConfigurationManager.ConnectionStrings("MyLoginDb").ConnectionString

        Try
            conn.Open()
        Catch ex As Exception

            ' Log the error but don't 
            ' display any details to the user
            System.Diagnostics.Debug.WriteLine("Exception: " & ex.Message)
            ' Login failed
            Return False
        End Try
        Try
            Dim cmd As New SqlCommand()
            cmd.Connection = conn
            cmd.CommandText = "SELECT UserName From MyUsers " & _
                              "WHERE UserName=@usr AND UserPassword=@pwd"
            cmd.Parameters.AddWithValue("@usr", username)
            cmd.Parameters.AddWithValue(
                "@pwd", userPassword
                )
            'FormsAuthentication.HashPasswordForStoringInConfigFile(
            '    userPassword, "SHA1"
            '    )
            '     )
            Dim Retuser As String = cmd.ExecuteScalar().ToString()
            If Retuser IsNot Nothing Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            ' Log the error but don't 
            ' display any details to the user
            System.Diagnostics.Debug.WriteLine("Exception: " & ex.Message)
            ' Login failed
            Return False
        Finally
            conn.Close()
        End Try

        Dim MyConfig As Configuration =
            WebConfigurationManager.OpenWebConfiguration("./")
        Dim SystemWeb As ConfigurationSectionGroup =
            MyConfig.SectionGroups("system.web")
        Dim AuthSec As AuthenticationSection =
            DirectCast(SystemWeb.Sections("authentication"), AuthenticationSection)
        AuthSec.Forms.Credentials.Users.Add(
            New FormsAuthenticationUser(UsernameText.Text, PasswordText.Text))

        MyConfig.Save()
    End Function

    Protected Sub LoginAction_Click(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles LoginAction.Click
        Page.Validate()
        If Not Page.IsValid Then Return
        If Me.Myauthenticate(UsernameText.Text, PasswordText.Text) Then
            FormsAuthentication.RedirectFromLoginPage(UsernameText.Text, False)
        Else
            LegendStatus.Text = "Invalid username or password!"
        End If
    End Sub
End Class
