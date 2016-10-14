Imports System.Xml.Xsl
Imports System.Xml.XPath
Imports System.Xml
Imports System.IO
Partial Class XmlToHtml
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        Dim xslFile As String = Server.MapPath("DvdList.xsl")
        Dim xmlFile As String = Server.MapPath("DvdList.xml")
        Dim htmlFile As String = Server.MapPath("DvdList.htm")

        Dim transf As New XslCompiledTransform()
        transf.Load(xslFile)
        transf.Transform(xmlFile, htmlFile)

        ' Create an XPathDocument.
        Dim xdoc As New XPathDocument(New XmlTextReader(xmlFile))

        ' Create an XPathNavigator.
        Dim xnav As XPathNavigator = xdoc.CreateNavigator()

        ' Transform the XML.
        Dim ms As New MemoryStream()
        Dim args As New XsltArgumentList()
        transf.Transform(xnav, args, ms)

        ' Go to the content and write it.
        Dim r As New StreamReader(ms)
        ms.Position = 0
        Response.Write(r.ReadToEnd())
        r.Close()
    End Sub
End Class
