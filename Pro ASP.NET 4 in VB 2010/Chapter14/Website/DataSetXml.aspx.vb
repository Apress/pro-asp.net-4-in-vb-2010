Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration

Partial Class DataSetXml
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Create the connection, Dataadapter and DataSet.
        Dim connectionString As String = WebConfigurationManager.ConnectionStrings("NorthWind").ConnectionString
        Dim sql As String = "SELECT TOP 5 EmployeeID, TitleOfCourtesy, LastName, FirstName FROM Employees"
        Dim conn As New SqlConnection(connectionString)
        Dim da As New SqlDataAdapter(sql, conn)
        Dim ds As New DataSet()

        'Fill the DataSet as fill the first grid.
        da.Fill(ds, "Employees")
        Datagrid1.DataSource = ds.Tables("Employees")
        Datagrid1.DataBind()

        'Generate the XML file.
        Dim xmlFile As String = Server.MapPath("Employees.xml")
        ds.WriteXml(xmlFile, XmlWriteMode.WriteSchema)

        'Load the XML file.
        Dim dsXml As New DataSet()
        dsXml.ReadXml(xmlFile)

        'Fill the second grid.
        Datagrid2.DataSource = dsXml.Tables("Employees")
        Datagrid2.DataBind()
    End Sub
End Class
