Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports System.Web.Security
' <summary>
' Summary description for DatabaseCredentialStore
' </summary>
Namespace CredentialStoreNamespace
    Public Class DatabaseCredentialStore
        Implements ICredentialStore
        Private conn As SqlConnection

        Public Sub New()
            conn = New SqlConnection()
            conn.ConnectionString = WebConfigurationManager.ConnectionStrings("MyLoginDb").ConnectionString
        End Sub

        Public Function Authenticate(ByVal userName As String, ByVal userPassword As String) As Boolean Implements ICredentialStore.Authenticate
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
                cmd.CommandText = "SELECT UserName From MyUsers " + _
                                  "WHERE UserName=@usr AND UserPassword=@pwd"
                cmd.Parameters.AddWithValue("@usr", userName)
                cmd.Parameters.AddWithValue("@pwd", FormsAuthentication.HashPasswordForStoringInConfigFile(userPassword, "SHA1"))
                Dim Retuser As String = cmd.ExecuteScalar().ToString()
                If Retuser IsNot Nothing Then
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                ' Log the error but don't
                ' display any details to the user
                System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message)
                ' Login failed
                Return False
            Finally
                conn.Close()
            End Try

        End Function

        Public Sub CreateUser(ByVal userName As String, ByVal userPassword As String) Implements ICredentialStore.CreateUser
            conn.Open()
            Try
                Dim cmd As New SqlCommand()
                cmd.Connection = conn
                cmd.CommandText = "INSERT INTO MyUsers VALUES(@usr,@pwd)"
                cmd.Parameters.AddWithValue("@usr", userName)
                cmd.Parameters.AddWithValue("@pwd", FormsAuthentication.HashPasswordForStoringInConfigFile(userPassword, "SHA1"))
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                ' Log the error but don't
                ' display any details to the user
                System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message)
            Finally
                conn.Close()
            End Try
        End Sub
    End Class
End Namespace

