Imports System.Data
Imports System.Configuration

Partial Class ObjectDataSourceParameters
    Inherits System.Web.UI.Page

    Protected Sub sourceEmployee_Selecting(
        ByVal sender As Object,
        ByVal e As ObjectDataSourceSelectingEventArgs
        ) Handles sourceEmployee.Selecting
        If e.InputParameters("employeeID") Is Nothing Then
            e.Cancel = True
        End If
    End Sub
End Class
