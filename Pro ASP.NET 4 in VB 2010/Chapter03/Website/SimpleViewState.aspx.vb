Partial Class SimpleViewState
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) 'Handles Button1.Click
        ' Uncomment either the string assignment or the Request assignment statement to test
        Dim viewStateString As String =
            "/wEPDwUKLTE2MjY5MTY1NQ9kFgICAw9kFgICAQ8PFgIeBFRleHQFDEhlbGxvIFdvcmxkIWRkZPsbiNOyNAufEt7OvNIbVYcGWHqf"
        viewStateString = Request("__VIEWSTATE")
        ' viewStateString contains the view state information. 
        ' Convert the Base64 string to an ordinary array of bytes 
        ' representing ASCII characters. 
        Dim stringBytes As Byte() = Convert.FromBase64String(viewStateString)
        ' Deserialize and display the string. 
        Dim decodedViewState As String = System.Text.Encoding.ASCII.GetString(stringBytes)
        Label1.Text = decodedViewState
    End Sub
End Class
