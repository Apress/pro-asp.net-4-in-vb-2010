
Partial Class TitledTextBoxTest
    Inherits System.Web.UI.Page

    Protected Sub TitledTextBox1_TextChanged(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles TitledTextBox1.TextChanged
        Label1.Text = "<br />The answer is: Apress!"
        TitledTextBox1.Text = "Apress Rocks!!"
    End Sub
End Class
