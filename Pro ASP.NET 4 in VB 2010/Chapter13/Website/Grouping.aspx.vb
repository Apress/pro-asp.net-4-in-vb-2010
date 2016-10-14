Imports System.Collections.Generic
Imports DatabaseComponent
Partial Public Class Grouping
    Inherits System.Web.UI.Page
    Private dbEmployee As New EmployeeDB()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Dim employees As List(Of EmployeeDetails) = dbEmployee.GetEmployees()

        Dim matches =
            From employee In employees
            Group employee By employee.TitleOfCourtesy
            Into g = Group
            Select New With {
                Key .Title = TitleOfCourtesy
                }

        'Dim matches =
        '    From employee In employees
        '    Group employee By employee.TitleOfCourtesy
        '    Into g = Group
        '    Select New With {
        '        Key .Title = TitleOfCourtesy, Key .Employees = g.Count()
        '        }

        gridEmployees.DataSource = matches
        gridEmployees.DataBind()
    End Sub
End Class