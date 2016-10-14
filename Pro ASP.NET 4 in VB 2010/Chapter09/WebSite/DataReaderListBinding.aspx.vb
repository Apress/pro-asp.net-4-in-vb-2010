Imports System.Web.Configuration
Imports System.Data.SqlClient

Partial Class DataReaderListBinding
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(
    ByVal sender As Object, ByVal e As System.EventArgs
    ) Handles Me.Load
        If Not Page.IsPostBack Then
            ' Create the Command and the Connection.
            Dim connectionString As String =
                WebConfigurationManager.ConnectionStrings("Northwind").ConnectionString
            Dim sql As String = "SELECT EmployeeID, TitleOfCourtesy + ' ' + " &
              "FirstName + ' ' + LastName As FullName FROM Employees"
            Dim con As SqlConnection = New SqlConnection(connectionString)
            Dim cmd As SqlCommand = New SqlCommand(sql, con)

            Try
                ' Open the connection and get the DataReader.
                con.Open()
                Dim reader As SqlDataReader = cmd.ExecuteReader()
                ' Bind the DataReader to the list.
                lstNames.DataSource = reader
                lstNames.DataBind()
                reader.Close()
            Finally
                ' Close the connection.
                con.Close()
            End Try
        End If
    End Sub

    Protected Sub cmdGetSelection_Click(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles cmdGetSelection.Click
        Result.Text &= "<b>Selected employees:</b><ul>"
        For Each li As ListItem In lstNames.Items
            If li.Selected Then _
                Result.Text &=
                    String.Format("<li>({0}) {1}</li>", li.Value, li.Text)
        Next
        Result.Text &= "</ul>"
    End Sub
End Class
