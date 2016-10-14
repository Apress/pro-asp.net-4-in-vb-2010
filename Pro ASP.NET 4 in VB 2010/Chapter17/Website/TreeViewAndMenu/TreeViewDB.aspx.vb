Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration

Partial Class TreeViewAndMenu_TreeViewDB
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim ds As DataSet = GetProductsAndCategories()

            ' Loop through the category records. 
            For Each row As DataRow In ds.Tables("Categories").Rows
                ' Use the constructor that requires just text 
                ' and a non-displayed value. 
                Dim nodeCategory As New TreeNode(
                    row("CategoryName").ToString(),
                    row("CategoryID").ToString()
                    )

                TreeView1.Nodes.Add(nodeCategory)

                ' Get the children (products) for this parent (category). 
                Dim childRows As DataRow() =
                    row.GetChildRows(ds.Relations(0))

                ' Loop through all the products in this category. 
                For Each childRow As DataRow In childRows
                    Dim nodeProduct As New TreeNode(
                        childRow("ProductName").ToString(),
                        childRow("ProductID").ToString()
                        )
                    nodeCategory.ChildNodes.Add(nodeProduct)
                Next

                ' Keep all categories collapsed (initially). 
                nodeCategory.Collapse()
            Next
        End If

    End Sub

    Private Function GetProductsAndCategories() As DataSet
        Dim connectionString As String =
            WebConfigurationManager.ConnectionStrings("Northwind").ConnectionString
        Dim con As New SqlConnection(connectionString)

        Dim sqlCat As String =
            "SELECT CategoryID, CategoryName FROM Categories"
        Dim sqlProd As String =
            "SELECT ProductID, ProductName, CategoryID FROM Products"

        Dim da As New SqlDataAdapter(sqlCat, con)
        Dim ds As New DataSet()
        Try
            con.Open()

            ' Fill the DataSet with the Categories table. 
            da.Fill(ds, "Categories")

            ' Change the command text and retrieve the Products table. 
            ' You could also use another DataAdapter object for this task. 
            da.SelectCommand.CommandText = sqlProd
            da.Fill(ds, "Products")
        Finally
            con.Close()
        End Try
        ' Define the relationship between Categories and Products. 
        Dim relat As New DataRelation(
            "CatProds",
            ds.Tables("Categories").Columns("CategoryID"),
            ds.Tables("Products").Columns("CategoryID")
            )

        ' Add the relationship to the DataSet. 
        ds.Relations.Add(relat)
        Return ds
    End Function

    Protected Sub TreeView1_SelectedNodeChanged(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles TreeView1.SelectedNodeChanged
        If TreeView1.SelectedNode Is Nothing Then
            Return
        End If
        If TreeView1.SelectedNode.Depth = 0 Then
            lblInfo.Text = "You selected Category ID: "
        ElseIf TreeView1.SelectedNode.Depth = 1 Then
            lblInfo.Text = "You selected Product ID: "
        End If
        lblInfo.Text &= TreeView1.SelectedNode.Value
    End Sub
End Class
