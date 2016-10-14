
Partial Class GridViewSort
    Inherits System.Web.UI.Page

    Protected Sub gridEmployees_DataBound(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles gridEmployees.DataBound
        ' Save selected index 
        If gridEmployees.SelectedIndex <> -1 Then
            ViewState("SelectedValue") = gridEmployees.SelectedValue.ToString()
        End If

    End Sub

    Protected Sub gridEmployees_SelectedIndexChanged(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles gridEmployees.SelectedIndexChanged
        Dim selectedValue As String = DirectCast(ViewState("SelectedValue"), String)
        If selectedValue Is Nothing Then
            Return
        End If

        ' Determine if the selected row is visible and re-select it 
        For Each row As GridViewRow In gridEmployees.Rows
            Dim keyValue As String =
                gridEmployees.DataKeys(row.RowIndex).Value.ToString()
            If keyValue = selectedValue Then
                gridEmployees.SelectedIndex = row.RowIndex
            End If
        Next
    End Sub
End Class
