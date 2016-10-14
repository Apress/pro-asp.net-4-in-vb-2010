Imports System.Xml

Partial Class XmlDOM
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        Dim xmlFile As String = Server.MapPath("DvdList.xml")

        ' Load the XML file in an XmlDocument.
        Dim doc As New XmlDocument()
        doc.Load(xmlFile)

        ' Write the description text.
        lblXml.Text = GetChildNodesDescr(doc.ChildNodes, 0)
    End Sub

    Private Function GetChildNodesDescr(
        ByVal nodeList As XmlNodeList,
        ByVal level As Integer
        ) As String
        Dim indent As String = ""
        For i As Integer = 0 To level - 1
            indent += "&nbsp; &nbsp; &nbsp;"
        Next

        Dim str As New StringBuilder("")
        For Each node As XmlNode In nodeList
            Select Case node.NodeType
                Case XmlNodeType.XmlDeclaration
                    str.Append("XML Declaration: <b>")
                    str.Append(node.Name)
                    str.Append(" ")
                    str.Append(node.Value)
                    str.Append("</b><br>")
                    Exit Select
                Case XmlNodeType.Element

                    str.Append(indent)
                    str.Append("Element: <b>")
                    str.Append(node.Name)
                    str.Append("</b><br>")
                    Exit Select
                Case XmlNodeType.Text

                    str.Append(indent)
                    str.Append(" - Value: <b>")
                    str.Append(node.Value)
                    str.Append("</b><br>")
                    Exit Select
                Case XmlNodeType.Comment

                    str.Append(indent)
                    str.Append("Comment: <b>")
                    str.Append(node.Value)
                    str.Append("</b><br>")
                    Exit Select
            End Select

            If node.Attributes IsNot Nothing Then
                For Each attrib As XmlAttribute In node.Attributes
                    str.Append(indent)
                    str.Append(" - Attribute: <b>")
                    str.Append(attrib.Name)
                    str.Append("</b> Value: <b>")
                    str.Append(attrib.Value)
                    str.Append("</b><br>")
                Next
            End If

            If node.HasChildNodes Then
                str.Append(GetChildNodesDescr(node.ChildNodes, level + 1))
            End If
        Next

        Return str.ToString()
    End Function
    
End Class
