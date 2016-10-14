Imports DatabaseComponent
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration
Partial Class StronglyTypedTest
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Create the Connection, DataAdapter, and DataSet. 
        Dim connectionString As String =
            WebConfigurationManager.ConnectionStrings("Northwind").ConnectionString
        Dim con As New SqlConnection(connectionString)
        Dim sqlProducts As String = "SELECT * FROM Products"
        Dim sqlCategories As String = "SELECT * FROM Categories"

        ' Create the strongly typed DataSet. 
        Dim ds As New NorthwindDataSet()

        ' Fill the DataSet. 
        Dim da As New SqlDataAdapter(sqlCategories, con)
        da.Fill(ds.Categories)
        da.SelectCommand.CommandText = sqlProducts
        da.Fill(ds.Products)

        ' Build the HTML string. 
        Dim htmlStr As New StringBuilder("")
        For Each row As NorthwindDataSet.CategoriesRow In ds.Categories
            htmlStr.Append("<b>")
            htmlStr.Append(row.CategoryName)
            htmlStr.Append("</b><br /><i>")
            htmlStr.Append(row.Description)
            htmlStr.Append("</i><br />")

            ' Get the related product rows. 
            ' Note that this code uses the helper method GetProductsRows() 
            ' instead of the generic GetChildRows(). 
            ' The advantage is you don't need to specify the relationship name. 
            Dim products As NorthwindDataSet.ProductsRow() = row.GetProductsRows()
            For Each child As NorthwindDataSet.ProductsRow In products
                htmlStr.Append("<li>")
                htmlStr.Append(child.ProductName)
                htmlStr.Append("</li>")
            Next
            htmlStr.Append("<br /><br />")
        Next

        ' Show the generated HTML. 
        HtmlContent.Text = htmlStr.ToString()

    End Sub
End Class
