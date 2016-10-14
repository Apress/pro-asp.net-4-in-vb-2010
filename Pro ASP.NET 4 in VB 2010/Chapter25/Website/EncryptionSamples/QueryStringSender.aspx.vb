
Partial Class QueryStringSender
    Inherits System.Web.UI.Page

    Protected Sub SendCommand_Click(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles SendCommand.Click
        Dim QueryString As New EncryptedQueryString()

        QueryString.Add("MyData", MyData.Text)
        QueryString.Add("MyTime", DateTime.Now.ToLongTimeString())
        QueryString.Add("MyDate", DateTime.Now.ToLongDateString())

        Response.Redirect("QueryStringRecipient.aspx?data=" &
                          QueryString.ToString())
    End Sub
End Class
