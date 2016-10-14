Imports System.Data.SqlClient
Imports System.Web.Configuration

Public Class WebForm1
    Inherits System.Web.UI.Page

    Private Function MyAuthenticate(
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
            System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message)
            ' Login failed 
            Return False
        End Try

        Try
            Dim cmd As New SqlCommand()
            cmd.Connection = conn
            cmd.CommandText = "SELECT UserName From MyUsers " &
                "WHERE UserName=@usr AND UserPassword=@pwd"
            cmd.Parameters.AddWithValue("@usr", username)
            cmd.Parameters.AddWithValue("@pwd", userPassword)

            Dim RetUser As String = DirectCast(cmd.ExecuteScalar(), String)
            If RetUser IsNot Nothing Then
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
    End Function

    Protected Sub LoginAction_Click(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles LoginAction.Click
        Page.Validate()
        If Not Page.IsValid Then
            Return
        End If

        If Me.MyAuthenticate(UsernameText.Text, PasswordText.Text) Then
            FormsAuthentication.RedirectFromLoginPage(UsernameText.Text, False)
        Else
            LegendStatus.Text = "Invalid username or password!"
        End If

    End Sub
End Class
