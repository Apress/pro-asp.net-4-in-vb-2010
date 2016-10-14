Partial Class NorthwindDataSet
    Partial Class ProductsDataTable

        Private Sub ProductsDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.ProductIDColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class

End Class
