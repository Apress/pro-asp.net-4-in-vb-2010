Partial Class DynamicTable
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        ' Create a new HtmlTable object. 
        Dim table1 As New HtmlTable()

        ' Set the table's formatting-related properties. 
        table1.Border = 1
        table1.CellPadding = 3
        table1.CellSpacing = 3
        table1.BorderColor = "red"

        ' Start adding content to the table. 
        Dim row As HtmlTableRow
        Dim cell As HtmlTableCell
        For i As Integer = 1 To 5
            ' Create a new row and set its background color. 
            row = New HtmlTableRow()
            row.BgColor = (IIf(i Mod 2 = 0, "lightyellow", "lightcyan"))
            For j As Integer = 1 To 4

                ' Create a cell and set its text. 
                cell = New HtmlTableCell()
                cell.InnerHtml =
                    "Row: " & i.ToString() & "<br>Cell: " & j.ToString()

                ' Add the cell to the current row. 
                row.Cells.Add(cell)
            Next

            ' Add the row to the table. 
            table1.Rows.Add(row)
        Next

        ' Add the table to the page. 
        PlaceHolder1.Controls.Add(table1)

    End Sub
End Class
