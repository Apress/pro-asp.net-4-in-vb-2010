Imports System.Data.SqlClient
Imports System.Web.Configuration
Partial Class DataReader
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        ' Create the command and the connection.
        Dim connectionString As String =
            WebConfigurationManager.ConnectionStrings("Northwind").ConnectionString
        Dim con As New SqlConnection(connectionString)
        Dim sql As String = "SELECT * FROM Employees"
        Dim cmd As New SqlCommand(sql, con)

        ' Open the Connection and get the DataReader.
        con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()

        ' Cycle through the records, and build the HTML string.
        Dim htmlStr As New StringBuilder("")
        While reader.Read()
            htmlStr.Append("<li>")
            htmlStr.Append(reader("TitleOfCourtesy"))
            htmlStr.Append(" <b>")
            htmlStr.Append(reader.GetString(1))
            htmlStr.Append("</b>, ")
            htmlStr.Append(reader.GetString(2))
            htmlStr.Append(" - employee from ")
            htmlStr.Append(reader.GetDateTime(6).ToString("d"))
            htmlStr.Append("</li>")
        End While

        ' Close the DataReader and the Connection.
        reader.Close()
        con.Close()

        ' Show the generated HTML code on the page.
        HtmlContent.Text = htmlStr.ToString()


    End Sub
End Class
