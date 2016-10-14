Imports System.Security.Cryptography

Partial Class ByteArray
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim RandomValue As Byte() = New Byte(15) {}
        Dim RndGen As RandomNumberGenerator =
            RandomNumberGenerator.Create()
        RndGen.GetBytes(RandomValue)
        Label1.Text =
            Convert.ToBase64String(RandomValue)
    End Sub
End Class
