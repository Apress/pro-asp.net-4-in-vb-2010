
Partial Class SimpleJavaScript
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        TextBox1.Attributes.Add(
            "onmouseover",
            "alert('Your mouse is hovering on TextBox1.');"
            )
        TextBox2.Attributes.Add(
            "onmouseover",
            "alert('Your mouse is hovering on TextBox2.');"
            )
    End Sub
End Class
