Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports System.Xml

Partial Class TreeViewAndMenu_TreeViewDB_XML
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        Dim connectionString As String =
            WebConfigurationManager.ConnectionStrings("Northwind").ConnectionString
        Dim con As New SqlConnection(connectionString)

        Dim sql As String =
            "SELECT C.CategoryName, C.CategoryID, P.ProductName, P.ProductID " &
            "FROM Products P INNER JOIN Categories C ON P.CategoryID = " &
            "C.CategoryID FOR XML AUTO, ELEMENTS"

        Dim cmd As New SqlCommand(sql, con)

        Dim xml As String = ""
        Try
            con.Open()

            Dim r As XmlReader = cmd.ExecuteXmlReader()
            r.Read()
            xml = "<root>" + r.ReadOuterXml() + "</root>"
        Finally
            con.Close()
        End Try
        sourceDbXml.Data = xml

    End Sub
End Class
