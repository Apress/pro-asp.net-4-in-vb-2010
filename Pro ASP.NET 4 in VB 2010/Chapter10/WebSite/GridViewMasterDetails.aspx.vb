
Partial Class GridViewMasterDetails
    Inherits System.Web.UI.Page

    Protected Sub gridEmployees_SelectedIndexChanged(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles gridEmployees.SelectedIndexChanged
        Dim index As Integer = gridEmployees.SelectedIndex

        ' You can retrieve the key field from the SelectedDataKey property. 
        Dim ID As Integer = CInt(gridEmployees.SelectedDataKey.Values("EmployeeID"))

        ' You can retrieve other data directly from the Cells collection, 
        ' as long as you know the column offset. 
        Dim firstName As String = gridEmployees.SelectedRow.Cells(2).Text
        Dim lastName As String = gridEmployees.SelectedRow.Cells(3).Text

        lblRegionCaption.Text = "Regions that " & firstName & " " & lastName &
            " (employee " & ID.ToString() & ") is responsible for:"
    End Sub
End Class
