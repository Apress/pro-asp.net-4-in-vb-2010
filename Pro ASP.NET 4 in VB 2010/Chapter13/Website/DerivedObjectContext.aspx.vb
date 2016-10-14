Imports NorthwindModel

Partial Class DerivedObjectContext
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        Dim db As New NorthwindEntities()

        GridView1.DataSource = db.Products
        GridView1.DataBind()

    End Sub
End Class
