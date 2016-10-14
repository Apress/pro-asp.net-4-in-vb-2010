Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports DatabaseComponent.DatabaseComponent
Partial Class _CalculatedColumn
    Inherits System.Web.UI.Page
    Private db As New EmployeeDB
    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        ' Create the Connection, DataAdapter, and DataSet. 
        Dim connectionString As String =
            WebConfigurationManager.ConnectionStrings("Northwind").ConnectionString
        Dim con As New SqlConnection(connectionString)

        Dim sqlCat As String =
            "SELECT CategoryID, CategoryName FROM Categories"
        Dim sqlProd As String =
            "SELECT ProductName, CategoryID, UnitPrice FROM Products"

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
            "CatProds",
            ds.Tables(
                "Categories").Columns(
                "CategoryID"),
            ds.Tables(
                "Products").Columns(
                "CategoryID"))
        ' Add the relationship to the DataSet. 
        ds.Relations.Add(relat)

        ' Create the calculated columns. 
        Dim count As New DataColumn("Products (#)", GetType(Integer),
                                    "COUNT(Child(CatProds).CategoryID)")
        Dim max As New DataColumn("Most Expensive Product", GetType(Decimal),
                                  "MAX(Child(CatProds).UnitPrice)")
        Dim min As New DataColumn("Least Expensive Product", GetType(Decimal),
                                  "MIN(Child(CatProds).UnitPrice)")

        ' Add the columns. 
        ds.Tables("Categories").Columns.Add(count)
        ds.Tables("Categories").Columns.Add(max)
        ds.Tables("Categories").Columns.Add(min)

        ' Show the data. 
        GridView1.DataSource = ds.Tables("Categories")
        GridView1.DataBind()

    End Sub
End Class
