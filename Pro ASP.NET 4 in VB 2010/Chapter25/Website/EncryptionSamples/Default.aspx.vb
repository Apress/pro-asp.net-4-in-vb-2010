Imports EncryptionUtility.APress.ProAspNet.Utility
Imports System.Data.SqlClient
Imports System.Web.Security
Imports System.Data
Imports System.Security.Cryptography

Partial Class _Default
    Inherits System.Web.UI.Page
    ' Private member of our current page representing the Connection
    ' to our custom database configured in the previous web.config
    Private DemoDb As SqlConnection

    ' We need some TextBox controls that we find in the 
    ' LoginView control template through FindControl() because
    ' they are only contained in a template of the LoginView
    Private CreditCardText As TextBox
    Private StreetText As TextBox
    Private ZipCodeText As TextBox
    Private CityText As TextBox

    ' Used for storing the encryption key based on the code
    ' introduced previously with our SymmetricEncryptionUtility class
    Private EncryptionKeyFile As String

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        ' Configure Encryption Utility 
        EncryptionKeyFile = Server.MapPath("key.config")
        SymmetricEncryptionUtility.AlgorithmName = "DES"
        If Not System.IO.File.Exists(EncryptionKeyFile) Then
            SymmetricEncryptionUtility.GenerateKey(EncryptionKeyFile)
        End If

        ' Create the connection 
        DemoDb =
            New SqlConnection(
                ConfigurationManager.ConnectionStrings("DemoSql").ConnectionString
                )
        ' Associate with Textfields 
        CreditCardText =
            DirectCast(
                MainLoginView.FindControl("CreditCardText"), TextBox
                )
        StreetText =
            DirectCast(
                MainLoginView.FindControl("StreetText"), TextBox
                )
        ZipCodeText =
            DirectCast(
                MainLoginView.FindControl("ZipCodeText"), TextBox
                )
        CityText =
            DirectCast(
                MainLoginView.FindControl("CityText"), TextBox
                )
    End Sub

    Protected Sub SaveCommand_Click(
        ByVal sender As Object, ByVal e As EventArgs
        )
        Try
            DemoDb.Open()
        Catch ex As Exception
            ' Log the error but don't 
            ' display any details to the user 
            System.Diagnostics.Debug.WriteLine("Exception: " & ex.Message)
            ' Access to DB failed 
            Response.Write("Saving data failed!")
            Return
        End Try

        Try
            Dim SqlText As String =
                "UPDATE ShopInfo " & "SET Street=@street, ZipCode=@zip, " &
                "City=@city, CreditCard=@card " & "WHERE UserId=@key"

            Dim Cmd As New SqlCommand(SqlText, DemoDb)

            ' Add simple values 
            Cmd.Parameters.AddWithValue("@street", StreetText.Text)
            Cmd.Parameters.AddWithValue("@zip", ZipCodeText.Text)
            Cmd.Parameters.AddWithValue("@city", CityText.Text)
            Cmd.Parameters.AddWithValue("@key", Membership.GetUser().ProviderUserKey)

            ' Now add the encrypted value 
            Dim EncryptedData As Byte() =
                SymmetricEncryptionUtility.EncryptData(
                    CreditCardText.Text,
                    EncryptionKeyFile
                    )
            Cmd.Parameters.AddWithValue("@card", EncryptedData)

            ' Execute the command 
            Dim results As Integer = Cmd.ExecuteNonQuery()
            If results = 0 Then
                Cmd.CommandText =
                    "INSERT INTO ShopInfo VALUES(@key, @city, @zip, @street, @card)"
                Cmd.ExecuteNonQuery()
            End If
        Finally
            DemoDb.Close()
        End Try
    End Sub
    Protected Sub LoadCommand_Click(
        ByVal sender As Object, ByVal e As EventArgs
        )
        Try
            DemoDb.Open()
        Catch ex As Exception
            ' Log the error but don't 
            ' display any details to the user 
            System.Diagnostics.Debug.WriteLine("Exception: " & ex.Message)
            ' Access to DB failed 
            Response.Write("Loading data failed!")
            Return
        End Try

        Try
            Dim SqlText As String =
                "SELECT * FROM ShopInfo WHERE UserId=@key"
            Dim Cmd As New SqlCommand(SqlText, DemoDb)
            Cmd.Parameters.AddWithValue(
                "@key", Membership.GetUser().ProviderUserKey
                )
            Using Reader As SqlDataReader = Cmd.ExecuteReader()
                If Reader.Read() Then
                    ' Cleartext Data 
                    StreetText.Text = Reader("Street").ToString()
                    ZipCodeText.Text = Reader("ZipCode").ToString()
                    CityText.Text = Reader("City").ToString()

                    ' Encrypted Data 
                    Dim SecretCard As Byte() =
                        DirectCast(Reader("CreditCard"), Byte())
                    CreditCardText.Text =
                        SymmetricEncryptionUtility.DecryptData(
                            SecretCard, EncryptionKeyFile
                            )
                End If
            End Using
        Finally
            DemoDb.Close()
        End Try
    End Sub
End Class
