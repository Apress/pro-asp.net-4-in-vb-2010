Imports System.Security.Cryptography

Partial Class RandomNumber
    Inherits System.Web.UI.Page

    Protected Sub RandomNumberCommand_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RandomNumberCommand.Click
        Dim RandomValue As Byte() = New Byte(16) {}
        Dim RndGen As RandomNumberGenerator = RandomNumberGenerator.Create()
        RndGen.GetBytes(RandomValue)
        ResultLabel.Text = Convert.ToBase64String(RandomValue)
    End Sub
End Class
