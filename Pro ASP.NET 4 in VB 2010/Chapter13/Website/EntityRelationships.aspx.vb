Imports NorthwindModel
'Imports System.Data.Objects

Partial Class EntityRelationships
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load

        Dim db As NorthwindEntities = New NorthwindEntities

        Dim result = From c In db.Customers
         Let o = (From q In c.Orders
             Where q.Employee.LastName <> "King"
             Select q)
         Where c.City = "London" AndAlso o.Count() > 5
         Select New With {
          .Name = c.CompanyName,
          .Contact = c.ContactName,
          .OrderCount = o.Count()
         }

        'Label1.Text = TryCast(result, ObjectQuery).ToTraceString()

        GridView1.DataSource = result
        GridView1.DataBind()
    End Sub

End Class