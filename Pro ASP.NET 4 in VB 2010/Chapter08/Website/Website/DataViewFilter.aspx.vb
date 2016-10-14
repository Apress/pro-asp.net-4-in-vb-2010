Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration

Partial Class DataViewFilter
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        ' Create the Connection, DataAdapter, and DataSet. 
        Dim connectionString As String =
            WebConfigurationManager.ConnectionStrings("Northwind").ConnectionString
        Dim con As New SqlConnection(connectionString)
        Dim sql As String =
            "SELECT ProductID, ProductName, UnitsInStock, UnitsOnOrder, Discontinued FROM Products"

        Dim da As New SqlDataAdapter(sql, con)
        Dim ds As New DataSet()

        ' Fill the DataSet 
        da.Fill(ds, "Products")

        ' Filter for the Chocolade product. 
        Dim view1 As New DataView(ds.Tables("Products"))
        view1.RowFilter = "ProductName = 'Chocolade'"
        Datagrid1.DataSource = view1

        ' Filter for products that aren't on order or in stock. 
        Dim view2 As New DataView(ds.Tables("Products"))
        view2.RowFilter = "UnitsInStock = 0 AND UnitsOnOrder = 0"
        Datagrid2.DataSource = view2

        ' Filter for products starting with the letter P. 
        Dim view3 As New DataView(ds.Tables("Products"))
        view3.RowFilter = "ProductName LIKE 'P%'"
        Datagrid3.DataSource = view3

        ' Bind all the data-bound controls on the page. 
        ' Alternatively, you could call the DataBind() method 
        ' of each grid separately 
        Me.DataBind()

        ' Get the children (products) for this parent (category).
        Dim matchRows As DataRow() = ds.Tables("Products").Select("Discontinued = 0")

    End Sub
End Class
