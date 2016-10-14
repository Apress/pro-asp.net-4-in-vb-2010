Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports System.Xml
Partial Class DataSetToXml
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        Dim connectionString As String =
            WebConfigurationManager.ConnectionStrings("Pubs").ConnectionString
        Dim SQL As String = "SELECT * FROM authors WHERE city='Oakland'"

        'Create the ADO.NET objects.
        Dim con As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(SQL, con)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim ds As New DataSet("AuthorsDataSet")

        'Retrive the data.
        con.Open()
        adapter.Fill(ds, "AuthorsTable")
        con.Close()

        'Create the XmlDataDocument that wraps this DataSet.

        Dim dataDoc As New XmlDataDocument(ds)

        'Dim dataDoc As New XmlDataDocument(ds)

        'Display the XML data (with the help of an XSLT) in the XML web control.
        XmlControl.XPathNavigator = dataDoc.CreateNavigator()
        XmlControl.TransformSource = "authors.xslt"
    End Sub
End Class
