
Partial Class TreeViewAndMenu_MenuTemplates
    Inherits System.Web.UI.Page

    Private matchingDescription As String = ""

    Protected Function GetDescriptionFromTitle(
        ByVal title As String
        ) As String
        ' This assumes there's only one node with this tile. 
        Dim node As SiteMapNode = SiteMap.RootNode
        SearchNodes(node, title)
        Return matchingDescription
    End Function
    Private Sub SearchNodes(
        ByVal node As SiteMapNode,
        ByVal title As String
        )
        If node.Title = title Then
            matchingDescription = node.Description
            Return
        Else
            For Each child As SiteMapNode In node.ChildNodes
                ' Perform recursive search. 
                SearchNodes(child, title)
            Next
        End If
    End Sub
End Class
