
Partial Class CustomTextBoxTest
    Inherits System.Web.UI.Page

    Protected Sub CustomTextBox1_TextChanged(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles CustomTextBox1.TextChanged
        Label1.Text =
            "TextChanged event raised for CustomTextBox <br />" &
            "The new Text is: " & CustomTextBox1.Text
    End Sub
End Class
