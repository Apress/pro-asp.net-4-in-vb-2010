Imports NorthwindModel
Imports System.Data.Objects

Partial Class ExplicitDataLoading
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load

        Dim db As New NorthwindEntities()

        db.ContextOptions.LazyLoadingEnabled = False
        Dim custs As IEnumerable(Of Customer) =
            From c In db.Customers
            Where c.Country = "UK"
            Select c

        For Each c As Customer In custs
            If c.City = "London" Then
                c.Orders.Load()
            End If
        Next

        Dim orders As New List(Of Order)()

        For Each c As Customer In custs
            If c.Orders.IsLoaded Then
                orders.Add(c.Orders.First())
            End If
        Next

        GridView1.DataSource = orders
        GridView1.DataBind()
    End Sub
End Class
