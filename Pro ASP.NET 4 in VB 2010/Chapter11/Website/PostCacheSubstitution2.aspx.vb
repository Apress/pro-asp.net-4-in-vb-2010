Partial Public Class PostCacheSubstitution2
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As EventArgs
        ) Handles Me.Load
        Response.Write("This date is cached: ")
        Response.Write(DateTime.Now.ToString() & "<br />")
        Response.Write("This date is not: ")
        Response.WriteSubstitution(
            New HttpResponseSubstitutionCallback(AddressOf GetDate))
    End Sub

    Private Shared Function GetDate(ByVal context As HttpContext) As String
        Return "<b>" & DateTime.Now.ToString() & "</b>"
    End Function
End Class