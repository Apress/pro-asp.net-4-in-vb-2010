
Partial Class _Default
    Inherits System.Web.UI.Page
    Protected Sub Page_Load( _
    ByVal sender As Object, ByVal e As System.EventArgs _
    ) Handles Me.Load
        Label1.Text = System.Environment.Version.Major.ToString()
    End Sub
End Class
