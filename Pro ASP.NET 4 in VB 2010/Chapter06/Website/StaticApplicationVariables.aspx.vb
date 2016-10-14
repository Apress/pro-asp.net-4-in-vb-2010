Partial Class StaticApplicationVariables
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        Dim builder As New StringBuilder()
        For Each file As String In ASP.myGlobal.FileList
            builder.Append(file & "<br />")
        Next
        lblInfo.Text = builder.ToString()
    End Sub
End Class
