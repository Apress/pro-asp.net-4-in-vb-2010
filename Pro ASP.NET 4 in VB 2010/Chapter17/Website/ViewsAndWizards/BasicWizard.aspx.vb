
Partial Class ViewsAndWizards_BasicWizard
    Inherits System.Web.UI.Page

    Protected Sub Wizard1_FinishButtonClick(
        ByVal sender As Object,
        ByVal e As System.Web.UI.WebControls.WizardNavigationEventArgs
        ) Handles Wizard1.FinishButtonClick
        Dim sb As New StringBuilder()
        sb.Append("<b>You chose: <br />")
        sb.Append("Programming Language: ")
        sb.Append(lstLanguage.Text)
        sb.Append("<br />Total Employees: ")
        sb.Append(txtEmpCount.Text)
        sb.Append("<br />Total Locations: ")
        sb.Append(txtLocCount.Text)
        sb.Append("<br />Licenses Required: ")
        For Each item As ListItem In lstTools.Items
            If item.Selected Then
                sb.Append(item.Text)
                sb.Append(" ")
            End If
        Next
        sb.Append("</b>")
        lblSummary.Text = sb.ToString()
    End Sub
End Class
