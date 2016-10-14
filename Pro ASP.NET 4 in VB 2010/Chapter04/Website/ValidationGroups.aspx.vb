Partial Class ValidationGroups
    Inherits System.Web.UI.Page

    Protected Sub cmdValidateAll_Click(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles cmdValidateAll.Click
        Label1.Text = "Initial Page.IsValid State: " & Page.IsValid.ToString()
        Page.Validate("Group1")
        Label1.Text &= "<br />Group1 Valid: " & Page.IsValid.ToString()
        Page.Validate("Group2")
        Label1.Text &= "<br />Group1 and Group2 Valid: " & Page.IsValid.ToString()
    End Sub
End Class
