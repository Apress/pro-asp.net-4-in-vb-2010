
Partial Class GridViewFormattingEvents
    Inherits System.Web.UI.Page
    Protected Sub gridEmployees_RowDataBound(
        ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs
        ) Handles gridEmployees.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            ' Get the title of courtesy for the item that's being created. 
            Dim title As String =
                DirectCast(DataBinder.Eval(e.Row.DataItem, "TitleOfCourtesy"), String)
            ' If the title of courtesy is "Ms.", "Mrs.", or "Mr.", 
            ' change the item's colors. 
            If title = "Ms." OrElse title = "Mrs." Then
                e.Row.BackColor = System.Drawing.Color.LightPink
                e.Row.ForeColor = System.Drawing.Color.Maroon
            ElseIf title = "Mr." Then
                e.Row.BackColor = System.Drawing.Color.LightCyan
                e.Row.ForeColor = System.Drawing.Color.DarkBlue
            End If
        End If
    End Sub
End Class
