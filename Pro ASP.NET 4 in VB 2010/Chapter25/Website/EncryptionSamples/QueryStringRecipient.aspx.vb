
Partial Class QueryStringRecipient
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        ' Deserialize the encrypted query string
        Dim QueryString As New EncryptedQueryString(
            Request.QueryString("data")
            )

        ' Write information to the screen
        Dim Info As New StringBuilder()
        For Each key As String In QueryString.Keys
            Info.AppendFormat("{0} = {1}<br>", key, QueryString(key))
        Next
        QueryStringLabel.Text = Info.ToString()
    End Sub
End Class
