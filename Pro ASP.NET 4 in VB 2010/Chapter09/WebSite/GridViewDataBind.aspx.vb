Imports System.Data.SqlClient
Imports System.Data
Imports System.Configuration

Partial Class _GridViewDataBind
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        If Not Page.IsPostBack Then
            ' Create the command and the connection. 
            Dim connectionString As String =
                "Data Source=.\SQLExpress;" &
                "Initial Catalog=Northwind;Integrated Security=SSPI"
            Dim sql As String =
                "SELECT EmployeeID, FirstName, LastName, Title, City FROM Employees"
            Dim con As New SqlConnection(connectionString)
            Dim cmd As New SqlCommand(sql, con)

            Try
                ' Open the connection and get the DataReader. 
                con.Open()
                Dim reader As SqlDataReader = cmd.ExecuteReader()

                ' Bind the DataReader to the list. 
                grid.DataSource = reader
                grid.DataBind()
                reader.Close()
            Finally
                ' Close the connection. 
                con.Close()
            End Try
        End If

    End Sub
End Class
