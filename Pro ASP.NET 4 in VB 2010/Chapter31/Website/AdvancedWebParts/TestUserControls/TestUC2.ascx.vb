
Partial Class TestUserControls_TestUC2
    Inherits System.Web.UI.UserControl

    Protected Sub AddCommand_Click(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles AddCommand.Click
        ResultsText.Text =
            (Int32.Parse(FirstValue.Text) + Int32.Parse(SecondValue.Text)).ToString()
    End Sub

    Protected Sub SubCommand_Click(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles SubCommand.Click
        ResultsText.Text =
            (Int32.Parse(FirstValue.Text) - Int32.Parse(SecondValue.Text)).ToString()
    End Sub
End Class
