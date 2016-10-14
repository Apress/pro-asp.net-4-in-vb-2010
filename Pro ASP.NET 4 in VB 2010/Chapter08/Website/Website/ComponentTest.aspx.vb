Imports DatabaseComponent.DatabaseComponent
Imports System.Text

Partial Class ComponentTest
    Inherits System.Web.UI.Page

    ' Create the database component. 
    Private db As New EmployeeDB


    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        WriteEmployeesList()

        Dim empID As Integer =
            db.InsertEmployee(
                New EmployeeDetails(0, "George", "Washington", "President"))
        HtmlContent.Text += "<br />Inserted 1 employee.<br />"

        WriteEmployeesList()

        db.DeleteEmployee(empID)
        HtmlContent.Text += "<br />Deleted 1 employee.<br />"

        WriteEmployeesList()

    End Sub
    Private Sub WriteEmployeesList()
        Dim htmlStr As New StringBuilder("")

        Dim numEmployees As Integer = db.CountEmployees()
        htmlStr.Append("<br>Total employees: <b>")
        htmlStr.Append(numEmployees.ToString())
        htmlStr.Append("</b><br />")

        Dim employees As List(Of EmployeeDetails) = db.GetEmployees()
        For Each emp As EmployeeDetails In employees
            htmlStr.Append("<li>")
            htmlStr.Append(emp.EmployeeID)
            htmlStr.Append(" ")
            htmlStr.Append(emp.TitleOfCourtesy)
            htmlStr.Append(" <b>")
            htmlStr.Append(emp.FirstName)
            htmlStr.Append("</b> ")
            htmlStr.Append(emp.LastName)
            htmlStr.Append("</li>")
        Next
        'htmlStr.Append("<br />")
        HtmlContent.Text &= htmlStr.ToString()
    End Sub

End Class
