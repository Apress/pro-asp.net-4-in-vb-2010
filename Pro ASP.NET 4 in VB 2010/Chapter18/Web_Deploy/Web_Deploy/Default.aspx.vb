Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        Label1.Text = System.Environment.Version.Major.ToString()
    End Sub

End Class