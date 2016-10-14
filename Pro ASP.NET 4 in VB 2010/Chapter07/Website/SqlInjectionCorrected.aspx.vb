Imports System.Data.SqlClient
Imports System.Web.Configuration

Partial Class SqlInjectionCorrected
    Inherits System.Web.UI.Page

    Protected Sub cmdGetRecords_Click(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles cmdGetRecords.Click
        Dim connectionString As String =
            WebConfigurationManager.ConnectionStrings("Northwind").ConnectionString
        Dim con As New SqlConnection(connectionString)

        Dim sql As String =
            "SELECT Orders.CustomerID, Orders.OrderID, COUNT(UnitPrice) AS Items, " &
            "SUM(UnitPrice * Quantity) AS Total FROM Orders " &
            "INNER JOIN [Order Details] " &
            "ON Orders.OrderID = [Order Details].OrderID " &
            "WHERE Orders.CustomerID = @CustID " &
            "GROUP BY Orders.OrderID, Orders.CustomerID"
        Dim cmd As New SqlCommand(sql, con)
        cmd.Parameters.AddWithValue("@CustID", txtID.Text)
        con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        GridView1.DataSource = reader
        GridView1.DataBind()
        reader.Close()
        con.Close()
    End Sub
End Class
