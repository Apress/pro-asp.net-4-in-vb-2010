Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration

Partial Class DataSetRelationships
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Create the Connection, DataAdapter, and DataSet. 
        Dim connectionString As String =
            WebConfigurationManager.ConnectionStrings("Northwind").ConnectionString
        Dim con As New SqlConnection(connectionString)

        Dim sqlCat As String = "SELECT CategoryID, CategoryName FROM Categories"
        Dim sqlProd As String = "SELECT ProductName, CategoryID FROM Products"

        Dim da As New SqlDataAdapter(sqlCat, con)
        Dim ds As New DataSet()

        Try
            con.Open()

            ' Fill the DataSet with the Categories table. 
            da.Fill(ds, "Categories")

            ' Change the command text and retrieve the Products table. 
            ' You could also use another DataAdapter object for this task. 
            da.SelectCommand.CommandText = sqlProd
            da.Fill(ds, "Products")
        Finally
            con.Close()
        End Try

        ' Define the relationship between Categories and Products. 
        Dim relat As New DataRelation(
            "CatProds", ds.Tables(
                "Categories").Columns(
                "CategoryID"),
            ds.Tables(
                "Products").Columns(
                "CategoryID"))
        ' Add the relationship to the DataSet. 
        ds.Relations.Add(relat)

        ' Loop through the category records and build the HTML string. 
        Dim htmlStr As New StringBuilder("")
        For Each row As DataRow In ds.Tables("Categories").Rows
            htmlStr.Append("<b>")
            htmlStr.Append(row("CategoryName").ToString())
            htmlStr.Append("</b><ul>")

            ' Get the children (products) for this parent (category). 
            Dim childRows As DataRow() = row.GetChildRows(relat)
            ' Loop through all the products in this category. 
            For Each childRow As DataRow In childRows
                htmlStr.Append("<li>")
                htmlStr.Append(childRow("ProductName").ToString())
                htmlStr.Append("</li>")
            Next
            htmlStr.Append("</ul>")
        Next

        ' Show the generated HTML code. 
        HtmlContent.Text = htmlStr.ToString()

    End Sub
End Class
