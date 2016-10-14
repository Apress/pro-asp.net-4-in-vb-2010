Imports System.Data.SqlClient
Imports System.Web.Configuration
Partial Class DataReaderMultiple
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        ' Create the Command and the Connection
        Dim connectionString As String =
            WebConfigurationManager.ConnectionStrings("Northwind").ConnectionString
        Dim con As New SqlConnection(connectionString)

        Dim sql As String = "SELECT TOP 5 EmployeeID, FirstName, LastName FROM Employees;" &
                            "SELECT TOP 5 ContactName, ContactTitle FROM Customers;" &
                            "SELECT TOP 5 SupplierID, CompanyName, ContactName FROM Suppliers"

        Dim cmd As New SqlCommand(sql, con)

        ' Open the Connection and get the DataReader
        con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()

        ' Cycle through records and all the rowsets,
        ' and build the Html String
        Dim htmlStr As New StringBuilder("")
        Dim i As Integer = 0
        Do
            htmlStr.Append("<h2>Rowset: ")
            htmlStr.Append(i.ToString())
            htmlStr.Append("</h2>")

            While reader.Read()
                htmlStr.Append("<li>")
                For field As Integer = 0 To reader.FieldCount - 1
                    ' Get all the fields in this row. 
                    htmlStr.Append(reader.GetName(field).ToString())
                    htmlStr.Append(": ")
                    htmlStr.Append(reader.GetValue(field).ToString())
                    htmlStr.Append("&nbsp;&nbsp;&nbsp;")
                Next
                htmlStr.Append("</li>")
            End While
            htmlStr.Append("<br><br>")
            i += 1
        Loop While reader.NextResult()

        ' Show the generated HTML code on the page.
        HtmlContent.Text = htmlStr.ToString()

    End Sub
End Class
