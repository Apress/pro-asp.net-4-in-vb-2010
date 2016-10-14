
Partial Class SqlDataSourceUpdateStoredProc
    Inherits System.Web.UI.Page

    Protected Sub sourceEmployees_Updating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceCommandEventArgs) Handles sourceEmployees.Updating
        e.Command.Parameters("@FirstName").Value = e.Command.Parameters("@FirstName").Value
        e.Command.Parameters("@LastName").Value = e.Command.Parameters("@LastName").Value
        'e.Command.Parameters.Remove(e.Command.Parameters("@FirstName"))
        'e.Command.Parameters.Remove(e.Command.Parameters("@LastName"))
    End Sub
End Class
