Imports System.Xml

Partial Class Search
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        ' Load the XML file.
        Dim xmlFile As String = Server.MapPath("DvdList.xml")
        Dim doc As New XmlDocument()
        doc.Load(xmlFile)

        ' Find all the <Title> elements anywhere in the document.
        Dim str As New StringBuilder()
        Dim nodes As XmlNodeList = doc.GetElementsByTagName("Title")
        For Each node As XmlNode In nodes
            str.Append("Found: <b>")

            ' Show the text contained in this <Title> element.
            Dim name As String = node.ChildNodes(0).Value
            str.Append(name)
            str.Append("</b><br>")

            If name = "Forrest Gump" Then
                ' Find the stars for just this movie.
                ' First you need to get the parent node
                ' (which is the <DVD> element for the movie).
                Dim parent As XmlNode = node.ParentNode

                ' Then you need to search down the tree.
                Dim childNodes As XmlNodeList =
                    DirectCast(parent, XmlElement).GetElementsByTagName("Star")
                For Each childNode As XmlNode In childNodes
                    str.Append("&nbsp;&nbsp;  Found Star: ")
                    str.Append(childNode.ChildNodes(0).Value)
                    str.Append("<br>")
                Next
            End If
        Next

        lblXml.Text = str.ToString()
    End Sub
End Class
