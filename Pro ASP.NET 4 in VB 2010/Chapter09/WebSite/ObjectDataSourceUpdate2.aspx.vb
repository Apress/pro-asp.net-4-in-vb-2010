
Partial Class ObjectDataSourceUpdate2
    Inherits System.Web.UI.Page

    Protected Sub sourceEmployees_Updating(
        ByVal sender As Object, ByVal e As ObjectDataSourceMethodEventArgs
        ) Handles sourceEmployees.Updating
        e.InputParameters("id") = e.InputParameters("EmployeeID")
        e.InputParameters.Remove("EmployeeID")
        sourceEmployees.UpdateMethod = "UpdateEmployee"
    End Sub
End Class
