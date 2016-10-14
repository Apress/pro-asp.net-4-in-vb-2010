Imports System.Xml
Partial Class XPathSearch
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        ' Load the XML file. 
        Dim xmlFile As String = Server.MapPath("DvdList.xml")
        Dim doc As New XmlDocument()
        doc.Load(xmlFile)

        ' Retrieve the title of every science fiction move. 
        Dim nodes As XmlNodeList =
            doc.SelectNodes(
                "/DvdList/DVD/Title[../@Category='Science Fiction']"
                )

        ' Display the titles. 
        Dim str As New StringBuilder()
        For Each node As XmlNode In nodes
            str.Append("Found: <b>")

            ' Show the text contained in this <Title> element. 
            str.Append(node.ChildNodes(0).Value)
            str.Append("</b><br>")
        Next
        lblXml.Text = str.ToString()
    End Sub
End Class
