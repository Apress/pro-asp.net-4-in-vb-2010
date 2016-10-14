Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports System.Xml

Partial Class XmlQuery
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        Dim connectionString As String =
            WebConfigurationManager.ConnectionStrings("Northwind").ConnectionString

        ' Define the command. 
        Dim customerQuery As String =
            "SELECT FirstName, LastName FROM Employees FOR XML AUTO, ELEMENTS"
        Dim con As New SqlConnection(connectionString)
        Dim com As New SqlCommand(customerQuery, con)

        ' Execute the command. 
        Dim str As New StringBuilder()
        Try
            con.Open()
            Dim reader As XmlReader = com.ExecuteXmlReader()

            While reader.Read()
                ' Process each employee. 
                If (reader.Name = "Employees") AndAlso
                    (reader.NodeType = XmlNodeType.Element) Then
                    reader.ReadStartElement("Employees")
                    str.Append(reader.ReadElementString("FirstName"))
                    str.Append(" ")
                    str.Append(reader.ReadElementString("LastName"))
                    str.Append("<br>")
                    reader.ReadEndElement()
                End If
            End While
            reader.Close()
        Finally
            con.Close()
        End Try
        lblXml.Text = str.ToString()
    End Sub
End Class
