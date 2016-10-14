
Partial Class ViewStateChunking
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        Dim rnd As New Random()
        Dim buffer As Byte() = New Byte(1049) {}
        rnd.NextBytes(buffer)
        ViewState("Data") = buffer
    End Sub
End Class
