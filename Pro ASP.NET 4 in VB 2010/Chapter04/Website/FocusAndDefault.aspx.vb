Partial Class FocusAndDefault
    Inherits System.Web.UI.Page

    Protected Sub cmdSubmit_Click(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles cmdSubmit.Click
        Label1.Text = "Clicked Submit."
    End Sub

    Protected Sub cmdSetFocus1_Click(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles cmdSetFocus1.Click
        TextBox1.Focus()
    End Sub

    Protected Sub cmdSetFocus2_Click(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles cmdSetFocus2.Click
        TextBox2.Focus()
    End Sub

    Protected Sub cmdDefaultButton_Click(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles cmdDefaultButton.Click
        Label1.Text = "Clicked Default."
    End Sub
End Class
