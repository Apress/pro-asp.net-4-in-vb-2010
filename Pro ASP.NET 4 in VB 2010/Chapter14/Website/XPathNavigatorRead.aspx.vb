Imports System.Xml
Imports System.Xml.XPath
Imports System.Text
Imports System.Xml.Linq
Partial Class XPathNavigatorRead
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        Dim xmlFile As String = Server.MapPath("DvdList.xml")

        ' Load the XML file in an XmlDocument. 
        Dim doc As New XmlDocument()
        doc.Load(xmlFile)

        ' Create the navigator. 
        Dim xnav As XPathNavigator = doc.CreateNavigator()

        lblXml.Text = GetXNavDescr(xnav, 0)
    End Sub
    Private Function GetXNavDescr(
        ByVal xnav As XPathNavigator, ByVal level As Integer
        ) As String
        Dim indent As String = ""
        For i As Integer = 0 To level - 1
            indent += "&nbsp; &nbsp; &nbsp;"
        Next

        Dim str As New StringBuilder("")

        Select Case xnav.NodeType
            Case XPathNodeType.Root
                str.Append("<b>ROOT</b>")
                str.Append("<br>")
                Exit Select
            Case XPathNodeType.Element
                str.Append(indent)
                str.Append("Element: <b>")
                str.Append(xnav.Name)
                str.Append("</b><br>")
                Exit Select
            Case XPathNodeType.Text
                str.Append(indent)
                str.Append(" - Value: <b>")
                str.Append(xnav.Value)
                str.Append("</b><br>")
                Exit Select
            Case XPathNodeType.Comment
                str.Append(indent)
                str.Append("Comment: <b>")
                str.Append(xnav.Value)
                str.Append("</b><br>")
                Exit Select
        End Select

        If xnav.HasAttributes Then
            xnav.MoveToFirstAttribute()
            Do
                str.Append(indent)
                str.Append(" - Attribute: <b>")
                str.Append(xnav.Name)
                str.Append("</b> Value: <b>")
                str.Append(xnav.Value)
                str.Append("</b><br>")
            Loop While xnav.MoveToNextAttribute()

            ' Return to the parent. 
            xnav.MoveToParent()
        End If

        If xnav.HasChildren Then
            xnav.MoveToFirstChild()
            Do
                str.Append(GetXNavDescr(xnav, level + 1))
            Loop While xnav.MoveToNext()

            ' Return to the parent. 
            xnav.MoveToParent()
        End If

        Return str.ToString()
    End Function

End Class
