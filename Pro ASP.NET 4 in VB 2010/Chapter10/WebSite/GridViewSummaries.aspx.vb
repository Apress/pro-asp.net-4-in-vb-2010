
Partial Class GridViewSummaries
    Inherits System.Web.UI.Page

    Protected Sub gridSummary_DataBound(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles gridSummary.DataBound
        Dim valueInStock As Decimal = 0

        ' The Rows collection only includes rows on the current page 
        ' (not "virtual" rows). 
        For Each row As GridViewRow In gridSummary.Rows
            Dim price As Decimal = [Decimal].Parse(row.Cells(2).Text.Substring(2))
            Dim unitsInStock As Integer = Int32.Parse(row.Cells(3).Text)
            valueInStock += price * unitsInStock
        Next

        Dim footer As GridViewRow = gridSummary.FooterRow

        ' Set the first cell to span over the entire row. 
        footer.Cells(0).ColumnSpan = 3
        footer.Cells(0).HorizontalAlign = HorizontalAlign.Center

        ' Remove the unneeded cells. 
        footer.Cells.RemoveAt(2)
        footer.Cells.RemoveAt(1)

        ' Add the text. 
        footer.Cells(0).Text =
            "Total value in stock (on this page): " & valueInStock.ToString("C")
    End Sub
End Class
