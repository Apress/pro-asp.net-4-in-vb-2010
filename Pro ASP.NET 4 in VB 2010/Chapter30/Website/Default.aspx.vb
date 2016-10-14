Imports System.Web.Configuration
Imports System.Data.SqlClient

Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim theNames As New List(Of String)
        Dim connectionString As String =
            WebConfigurationManager.ConnectionStrings("Northwind").ConnectionString
        Dim con As SqlConnection = New SqlConnection(connectionString)
        Dim sql As String = "SELECT * FROM Employees ORDER BY LastName"
        Dim cmd As SqlCommand = New SqlCommand(sql, con)
        con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        Do While reader.Read()
            theNames.Add(reader("LastName") & ", " & reader("FirstName"))
        Loop
        reader.Close()
        con.Close()

    End Sub
End Class
