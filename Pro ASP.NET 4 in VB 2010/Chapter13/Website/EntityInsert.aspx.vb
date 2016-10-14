Imports NorthwindModel
Partial Class EntityInsert
    Inherits System.Web.UI.Page
    Private db As New NorthwindEntities

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        Dim cust As New Customer() With {
            .CustomerID = "LAWN",
            .CompanyName = "Lawn Wranglers",
            .ContactName = "Mr. Abe Henry",
            .ContactTitle = "Owner",
            .Address = "1017 Maple Leaf Way",
            .City = "Ft. Worth",
            .Region = "TX",
            .PostalCode = "76104",
            .Country = "USA",
            .Phone = "(800) MOW-LAWN",
            .Fax = "(800) MOW-LAWO"
        }
        db.Customers.AddObject(cust)
        db.SaveChanges()

        ' To verify that the insert took place

        GridView1.DataSource = db.Customers
        GridView1.DataBind()
    End Sub
End Class
