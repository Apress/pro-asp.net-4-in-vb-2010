Imports System.Data
Imports DatabaseComponent
Partial Public Class LinqToDataSet
    Inherits System.Web.UI.Page
    Private db As New EmployeeDB()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Dim ds As DataSet = db.GetEmployeesDataSet()
        'Dim matches =
        '    From employee In ds.Tables("Employees").AsEnumerable()
        '    Where employee.Field(Of String)("LastName").StartsWith("D")
        '    Select New With {
        '        .First = employee.Field(Of String)("FirstName"),
        '        .Last = employee.Field(Of String)("LastName")
        '    }
        'gridEmployees.DataSource = matches

        Dim matches =
            From employee In ds.Tables("Employees").AsEnumerable()
            Where employee.Field(Of String)("LastName").StartsWith("D")
            Select employee
        gridEmployees.DataSource = matches.AsDataView()

        gridEmployees.DataBind()

    End Sub
End Class