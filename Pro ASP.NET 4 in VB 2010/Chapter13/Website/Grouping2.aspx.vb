Imports DatabaseComponent
Partial Public Class Grouping2
    Inherits System.Web.UI.Page
    Private dbProduct As New ProductDB()

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As EventArgs
        ) Handles Me.Load
        Dim products As List(Of ProductDetails) =
            dbProduct.GetProducts()
        Dim matches =
         From p In products _
         Group p By p.CategoryID Into g = Group
         Select New With {
             .Category = CategoryID,
             .MaximumPrice = g.Max(Function(p) p.UnitPrice),
             .MinimumPrice = g.Min(Function(p) p.UnitPrice),
             .AveragePrice = g.Average(Function(p) p.UnitPrice)
            }
        gridEmployees.DataSource = matches
        gridEmployees.DataBind()
    End Sub
End Class