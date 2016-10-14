Partial Class CalendarTest
    Inherits System.Web.UI.Page

    Protected Sub Calendar1_DayRender(
        ByVal sender As Object,
        ByVal e As System.Web.UI.WebControls.DayRenderEventArgs
        ) Handles Calendar1.DayRender
        If e.Day.IsWeekend Then
            e.Cell.BackColor = System.Drawing.Color.Green
            e.Cell.ForeColor = System.Drawing.Color.Yellow
            e.Day.IsSelectable = False
        End If
    End Sub

    Protected Sub Calendar1_SelectionChanged(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Calendar1.SelectionChanged
        lblDates.Text = "You selected these dates:<br />"
        For Each dt As DateTime In Calendar1.SelectedDates
            lblDates.Text &= dt.ToLongDateString() & "<br />"
        Next
    End Sub
End Class
