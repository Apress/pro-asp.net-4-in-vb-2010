
Partial Class TemplatesAndConcurrency
    Inherits System.Web.UI.Page

    Protected Sub DetailsView1_ItemUpdated(
        ByVal sender As Object, ByVal e As DetailsViewUpdatedEventArgs
        )
        If e.AffectedRows = 0 Then
            'lblStatus.Text = "No records were updated."
            e.KeepInEditMode = True
            ' Allow more editing. 
            detailsEditing.DataBind()
             ' Re-populate DetailsView with values entered by user 
            Dim t As TextBox
            t = DirectCast(detailsEditing.Rows(1).Cells(1).Controls(0), TextBox)
            t.Text = DirectCast(e.NewValues("CompanyName"), String)
            t = DirectCast(detailsEditing.Rows(2).Cells(1).Controls(0), TextBox)
            t.Text = DirectCast(e.NewValues("Phone"), String)
            ' Show the panel with errors. 
            ErrorPanel.Visible = True
        End If
    End Sub

    Protected Sub SqlDataSource2_Selecting(
        ByVal sender As Object, ByVal e As SqlDataSourceSelectingEventArgs
        )
        If Not ErrorPanel.Visible Then
            e.Cancel = True
        End If
    End Sub
End Class
