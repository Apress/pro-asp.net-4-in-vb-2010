
Imports DatabaseComponent
Imports System.Collections.Generic
Imports System.Linq

Partial Public Class IterativeVsDeclarative
    Inherits System.Web.UI.Page
    Private db As New EmployeeDB()

    Protected Sub cmdForeach_Click(
        ByVal sender As Object, ByVal e As EventArgs
        ) Handles cmdForeach.Click
        ' Get the full collection of employees from a helper method. 
        Dim employees As List(Of EmployeeDetails) = db.GetEmployees()

        ' Find the matching employees. 
        Dim matches As New List(Of EmployeeDetails)()
        For Each employee As EmployeeDetails In employees
            If employee.LastName.StartsWith("D") Then
                matches.Add(employee)
            End If
        Next

        gridEmployees.DataSource = matches
        gridEmployees.DataBind()
    End Sub

    Protected Sub cmdLinq_Click(
        ByVal sender As Object, ByVal e As EventArgs
        ) Handles cmdLinq.Click
        Dim employees As List(Of EmployeeDetails) = db.GetEmployees()

        ' Implicit syntax. 
        Dim matches As IEnumerable(Of EmployeeDetails) =
            From employee In employees
            Where employee.LastName.StartsWith("D")
            Select employee
        gridEmployees.DataSource = matches
        gridEmployees.DataBind()
    End Sub
End Class