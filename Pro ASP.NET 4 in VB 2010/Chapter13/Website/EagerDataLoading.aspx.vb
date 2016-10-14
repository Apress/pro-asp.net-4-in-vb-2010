Imports NorthwindModel
Imports System.Data.Objects

Partial Class EagerDataLoading
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load

        Dim db As New NorthwindEntities()

        Dim custs As IEnumerable(Of Customer) =
            From c In db.Customers.Include("Orders")
            Where c.City = "London" AndAlso
                c.Country = "UK"
            Select c
        Label1.Text = TryCast(custs, ObjectQuery).ToTraceString()
        Dim names As New List(Of String)()

        For Each c As Customer In custs
            If c.Orders.Count() > 2 Then
                names.Add(c.CompanyName)
            End If
        Next

        GridView1.DataSource = names
        GridView1.DataBind()
    End Sub
End Class
