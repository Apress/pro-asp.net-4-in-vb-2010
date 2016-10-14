Imports DatabaseComponent
Imports System.Collections.Generic
Imports System.Linq

Partial Public Class Projection
    Inherits System.Web.UI.Page
    Private db As New EmployeeDB()
    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As EventArgs
        ) Handles Me.Load
        Dim employees As List(Of EmployeeDetails) = db.GetEmployees()

        ' Anonymous type. 
        'Dim matches = From employee In employees
        '              Select First = employee.FirstName, Last = employee.LastName

        ' Iterating Over Employee Matches
        'labelEmployees.Text = "<h3>Iterating Over Employee Matches</h3>"
        'For Each employee In matches
        '    labelEmployees.Text &= employee.First & " " & employee.Last & "<br />"
        'Next

        ' Change the type.
        'Dim matches As IEnumerable(Of EmployeeDetails) =
        '    From employee In employees
        '    Select New EmployeeDetails() With {
        '        .FirstName = employee.FirstName,
        '        .LastName = employee.LastName
        '    }

        ' Explicit syntax. 
        Dim matches As IEnumerable(Of EmployeeDetails)
        matches =
            From employee In employees
            Where TestEmployee(employee)
            Select employee

        gridEmployees.DataSource = matches
        gridEmployees.DataBind()

    End Sub
    Private Function TestEmployee(
        ByVal employee As EmployeeDetails
        ) As Boolean
        Return employee.LastName.StartsWith("D")
    End Function
End Class