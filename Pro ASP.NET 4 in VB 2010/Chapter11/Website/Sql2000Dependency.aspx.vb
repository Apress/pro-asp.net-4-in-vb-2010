Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.Configuration

Partial Public Class Sql2005Dependency
    Inherits System.Web.UI.Page
    Protected Sub Page_PreRender(
        ByVal sender As Object, ByVal e As EventArgs
        )
        lblInfo.Text &= "<br />"
    End Sub

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As EventArgs
        ) Handles Me.Load
        If Not Me.IsPostBack Then
            ' If cache monitoring is already switched on, reset it. 
            ' Otherwise, this has no effect. 
            SqlDependency.[Stop](connectionString)

            ' Must be called at least once for application to set 
            ' up listener. 
            SqlDependency.Start(connectionString)

            ' (In a real application, you'd call Start() and Stop() 
            ' in the global.asax file. They're included in the page code 
            ' here to keep all the code together.) 

            lblInfo.Text &= "Creating dependent item...<br />"
            Cache.Remove("Customers")

            Dim dt As DataTable = GetTable()
            lblInfo.Text &= "Adding dependent item<br />"
            Cache.Insert("Customers", dt, dependency)
        End If
    End Sub

    Private dependency As SqlCacheDependency
    Private connectionString As String =
        WebConfigurationManager.ConnectionStrings("Northwind").ConnectionString
    Private Function GetTable() As DataTable
        Dim con As New SqlConnection(connectionString)
        Dim sql As String = "SELECT ContactName FROM dbo.Customers"
        Dim da As New SqlDataAdapter(sql, con)

        ' Create a dependency for the Employees table. 
        dependency = New SqlCacheDependency(da.SelectCommand)

        Dim ds As New DataSet()
        da.Fill(ds, "Customers")
        Return ds.Tables(0)
    End Function

    Protected Sub cmdModfiy_Click(
        ByVal sender As Object, ByVal e As EventArgs
        )
        Dim con As New SqlConnection(connectionString)
        ' Even a change that really does do anything is still a change. 
        Dim sql As String =
            "UPDATE dbo.Customers SET ContactName='Maria Anders' WHERE CustomerID='ALFKI'"
        Dim cmd As New SqlCommand(sql, con)
        Try
            con.Open()
            Dim A As Integer = cmd.ExecuteNonQuery()
            A &= 1
        Finally
            con.Close()
        End Try
        lblInfo.Text &=
            "Update completed (no need to wait, because polling is not used).<br />"
    End Sub
    Protected Sub cmdGetItem_Click(
        ByVal sender As Object, ByVal e As EventArgs
        )
        If Cache("Customers") Is Nothing Then
            lblInfo.Text &= "Cache item no longer exits.<br />"
        Else
            lblInfo.Text &= "Item is still present.<br />"
        End If
    End Sub

End Class