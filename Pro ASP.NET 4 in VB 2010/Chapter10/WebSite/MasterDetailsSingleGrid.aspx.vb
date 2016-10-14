
Partial Class MasterDetailsSingleGrid
    Inherits System.Web.UI.Page

    Protected Sub gridMaster_RowDataBound(
        ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs
        ) Handles gridMaster.RowDataBound
        ' Look for GridView items. 
        If e.Row.RowType = DataControlRowType.DataRow Then
            ' Retrieve the GridView control in the second column. 
            Dim gridChild As GridView = DirectCast(e.Row.Cells(1).Controls(1), GridView)

            sourceProducts.SelectParameters(0).DefaultValue =
                gridMaster.DataKeys(e.Row.DataItemIndex).Value.ToString()
            Dim data As Object = sourceProducts.[Select](DataSourceSelectArguments.Empty)

            ' Bind the grid. 
            gridChild.DataSource = data
            gridChild.DataBind()
        End If
    End Sub
End Class
