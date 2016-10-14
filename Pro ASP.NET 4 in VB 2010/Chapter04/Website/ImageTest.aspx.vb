Partial Class ImageTest
    Inherits System.Web.UI.Page

    Protected Sub ImageButton1_Click(
    ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs
    ) Handles ImageButton1.Click
        lblResult.Text =
            "You clicked at (" & e.X.ToString() &
            ", " & e.Y.ToString() & "). "
        ' Check if the clicked point falls in the rectangle described
        ' by the points (20,20) and (275,100), which is the button surface.
        If (e.Y < 100) AndAlso (e.Y > 20) AndAlso _
        (e.X > 20) AndAlso (e.X < 275) Then
            lblResult.Text &= "You clicked on the button surface."
        Else
            lblResult.Text &= "You clicked the button border."
        End If
    End Sub
End Class
