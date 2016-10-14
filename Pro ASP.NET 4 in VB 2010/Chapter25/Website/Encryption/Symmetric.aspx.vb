Imports EncryptionUtility.APress.ProAspNet.Utility
Imports System.Security.Cryptography
Imports System.IO
Partial Class Symmetric
    Inherits System.Web.UI.Page
    Private KeyFileName As String
    Private AlgorithmName As String = "DES"

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        SymmetricEncryptionUtility.AlgorithmName = AlgorithmName
        KeyFileName = Server.MapPath("~/") & "\symmetric_key.config"
    End Sub

    Protected Sub GenerateKeyCommand_Click(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles GenerateKeyCommand.Click
        Try
            SymmetricEncryptionUtility.ProtectKey = EncryptKeyCheck.Checked
            SymmetricEncryptionUtility.GenerateKey(KeyFileName)
            Response.Write("Key generated successfully!")
        Catch
            Response.Write("Exception occured when encrypting key!")
        End Try
    End Sub

    Protected Sub EncryptCommand_Click(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles EncryptCommand.Click
        ' Check for encryption key 
        If Not File.Exists(KeyFileName) Then
            Response.Write("Missing encryption key. Please generate key!")
        End If

        Try
            Dim data As Byte() =
                SymmetricEncryptionUtility.EncryptData(
                    ClearDataText.Text, KeyFileName
                    )
            EncryptedDataText.Text = Convert.ToBase64String(data)
        Catch
            Response.Write("Unable to encrypt data!")
        End Try

    End Sub

    Protected Sub DecryptCommand_Click(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles DecryptCommand.Click
        ' Check for encryption key 
        If Not File.Exists(KeyFileName) Then
            Response.Write(
                "Missing encryption key. Please generate key!"
                )
        End If

        Try
            Dim data As Byte() =
                Convert.FromBase64String(EncryptedDataText.Text)
            ClearDataText.Text =
                SymmetricEncryptionUtility.DecryptData(data, KeyFileName)
        Catch
            Response.Write("Unable to decrypt data!")
        End Try

    End Sub

    Protected Sub ClearCommand_Click(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles ClearCommand.Click
        ClearDataText.Text = ""
        EncryptedDataText.Text = ""
    End Sub
End Class
