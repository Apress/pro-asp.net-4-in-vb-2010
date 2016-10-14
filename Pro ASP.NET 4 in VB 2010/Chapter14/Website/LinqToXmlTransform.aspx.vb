Imports System.Linq
Imports System.Xml.Linq
Imports System.Collections.Generic

Partial Class LinqToXmlTransform
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        Dim xmlFile As String = Server.MapPath("DvdList2.xml")
        Dim doc As XDocument = XDocument.Load(xmlFile)

        Dim newDoc As New XDocument(
            New XDeclaration("1.0", "utf-8", "yes"),
            New XElement(
                "Movies", From DVD In doc.Descendants("DVD")
                Where (CInt(DVD.Attribute("ID")) < 3
                       )
                Select New XElement() {
                    New XElement(
                        "Movie",
                        New XAttribute(
                            "Name",
                            CStr(DVD.Element("Title"))
                        ), DVD.Descendants("Star")
                    )
                }
            )
        )
        lblXml.Text = Server.HtmlEncode(newDoc.ToString())
    End Sub
End Class
