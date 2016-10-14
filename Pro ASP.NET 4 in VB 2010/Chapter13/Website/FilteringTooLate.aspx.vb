Imports NorthwindModel
Imports System.Data.Objects

Partial Class FilteringTooLate
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        Dim db As New NorthwindEntities()

        Dim custs As IEnumerable(Of Customer) =
            From c In db.Customers Where c.Country = "UK"
            Select c
        Label1.Text = TryCast(custs, ObjectQuery).ToTraceString()
        Dim results As IEnumerable(Of Customer) =
            From c In custs
            Where c.City = "London"
            Select c
        'No results are available if this statement is uncommented
        'Label2.Text = TryCast(results, ObjectQuery).ToTraceString()
        GridView1.DataSource = results
        GridView1.DataBind()
    End Sub
End Class
