Imports NorthwindModel
Imports System.Data.Objects

Partial Class CompiledLinqQuery
    Inherits System.Web.UI.Page
    Private MyCompiledQuery As Func(
        Of NorthwindEntities,
        String, 
        IQueryable(Of Customer)
        )
    Private db As NorthwindEntities


    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load

        MyCompiledQuery =
            CompiledQuery.Compile(
                Of NorthwindEntities,
                String, 
                IQueryable(Of Customer)
                )(Function(context, city) From c In context.Customers
                             Where c.City = city
                             Select c)

        db = New NorthwindEntities()

        GridView1.DataSource = MyCompiledQuery(db, "London")
        GridView1.DataBind()
    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(
        ByVal sender As Object, ByVal e As EventArgs
        ) Handles DropDownList1.SelectedIndexChanged
        GridView1.DataSource =
            MyCompiledQuery(db, DropDownList1.SelectedValue)
        GridView1.DataBind()
    End Sub
End Class
