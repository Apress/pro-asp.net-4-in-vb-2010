Imports System.Data

Partial Class IncrementalDownloadGrid
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        If Not Page.IsPostBack Then
            ' Get data.
            Dim ds As New DataSet()
            ds.ReadXml(Server.MapPath("Books.xml"))
            DataGrid1.DataSource = ds.Tables("Book")
            DataGrid1.DataBind()
        End If
    End Sub
End Class
