Imports System.Data.SqlClient
Imports System.Web.Configuration
Partial Class TestConnection
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        ' Create the Connection object. 
        Dim connectionString As String =
            WebConfigurationManager.ConnectionStrings("Northwind").ConnectionString
        Dim con As New SqlConnection(connectionString)
        ' Try-Catch-Finally Syntax
        'Try
        '    ' Try to open the connection. 
        '    con.Open()
        '    lblInfo1.Text = "<b>Server Version:</b> " & con.ServerVersion
        '    lblInfo2.Text = "<b>Connection Is:</b> " & con.State.ToString()
        'Catch err As Exception
        '    ' Handle an error by displaying the information. 
        '    lblInfo3.Text = "Error reading the database. " & err.Message
        'Finally
        '    ' Either way, make sure the connection is properly closed. 
        '    ' Even if the connection wasn't opened successfully, 
        '    ' calling Close() won't cause an error. 
        '    con.Close()
        '    lblInfo4.Text = "<b>Now Connection Is:</b> " & con.State.ToString()
        'End Try
        ' Using Syntax
        Using con
            con.Open()
            lblInfo1.Text = "<b>Server Version:</b> " & con.ServerVersion
            lblInfo2.Text = "<b>Connection Is:</b> " & con.State.ToString()
        End Using
        lblInfo4.Text = "<b>Now Connection Is:</b> "
        lblInfo4.Text &= con.State.ToString()
    End Sub
End Class
