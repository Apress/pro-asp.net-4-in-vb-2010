Imports System.Linq
Imports System.Xml.Linq
'Imports System.Collections
Imports System.Collections.Generic
Imports System.Xml

Partial Class LinqToXmlQuery
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim xmlFile As String = Server.MapPath("DvdList2.xml")
        Dim doc As XDocument = XDocument.Load(xmlFile)

        'Dim matches As IEnumerable(Of XElement) =
        '    From DVD In doc.Descendants("DVD")
        '    Where CInt(DVD.Attribute("ID")) < 3
        '    Select DVD.Element("Title")

        Dim matches = From DVD In doc.Descendants("DVD") _
            Order By CDec(DVD.Element("Price")) Descending _
            Select Movie = DVD.Element("Title").Value, _
        Price = DVD.Element("Price").Value

        gridTitles.DataSource = matches
        gridTitles.DataBind()
    End Sub
End Class
