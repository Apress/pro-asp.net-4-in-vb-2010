Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration

Partial Class DataViewSort
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Create the Connection, DataAdapter, and DataSet. 
        Dim connectionString As String =
            WebConfigurationManager.ConnectionStrings("Northwind").ConnectionString
        Dim con As New SqlConnection(connectionString)
        Dim sql As String =
            "SELECT TOP 5 EmployeeID, TitleOfCourtesy, LastName, FirstName FROM Employees"

        Dim da As New SqlDataAdapter(sql, con)
        Dim ds As New DataSet()

        ' Fill the DataSet 
        da.Fill(ds, "Employees")

        ' Bind the original data to #1. 
        Datagrid1.DataSource = ds.Tables("Employees")

        ' Sort by last name and bind it to #2. 
        Dim view2 As New DataView(ds.Tables("Employees"))
        view2.Sort = "LastName"
        Datagrid2.DataSource = view2

        ' Sort by first name and bind it to #3. 
        Dim view3 As New DataView(ds.Tables("Employees"))
        view3.Sort = "FirstName"
        Datagrid3.DataSource = view3

        ' Bind all the data-bound controls on the page. 
        ' Alternatively, you could call the DataBind() method 
        ' of each grid separately 
        Me.DataBind()

    End Sub
End Class
