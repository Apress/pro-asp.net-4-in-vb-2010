Imports NorthwindModel
Partial Class SimpleLinqToEntitiesQuery
    Inherits System.Web.UI.Page
 
    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        Dim db As New NorthwindEntities()

        Dim results =
            From p In db.Products
            Where p.Discontinued = False
            Select New With {
                .ID = p.ProductID, .Name = p.ProductName
                }

        GridView1.DataSource = results
        GridView1.DataBind()
    End Sub
End Class
