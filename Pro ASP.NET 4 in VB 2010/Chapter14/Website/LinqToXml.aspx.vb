Imports System.Linq
Imports System.Xml.Linq
Imports System.Collections

Partial Class LinqToXml
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        WriteXml()
        ReadXml()
    End Sub

    Private Sub WriteXml()
        Dim doc As New XDocument(
            New XDeclaration("1.0", "utf-8", "yes"),
            New XComment("Created: " + DateTime.Now.ToString()),
        New XElement("DvdList",
        New XElement("DVD",
        New XAttribute("ID", "1"),
        New XAttribute("Category", "Science Fiction"),
        New XElement("Title", "The Matrix"),
        New XElement("Director", "Larry Wachowski"),
        New XElement("Price", "18.74"),
        New XElement("Starring",
            New XElement("Star", "Keanu Reeves"),
            New XElement("Star", "Laurence Fishburne")
        )
      ),
         New XElement("DVD",
                  New XAttribute("ID", "2"),
                  New XAttribute("Category", "Drama"),
                  New XElement("Title", "Forrest Gump"),
                  New XElement("Director", "Robert Zemeckis"),
                  New XElement("Price", "23.99"),
                  New XElement("Starring",
                      New XElement("Star", "Tom Hanks"),
                      New XElement("Star", "Robin Wright")
                  )
              ),
              New XElement("DVD",
                  New XAttribute("ID", "3"),
                  New XAttribute("Category", "Horror"),
                  New XElement("Title", "The Others"),
                  New XElement("Director", "Alejandro Amenábar"),
                  New XElement("Price", "22.49"),
                  New XElement("Starring",
                      New XElement("Star", "Nicole Kidman"),
                      New XElement("Star", "Christopher Eccleston")
                  )
              ),
              New XElement("DVD",
                  New XAttribute("ID", "4"),
                  New XAttribute("Category", "Mystery"),
                  New XElement("Title", "Mulholland Drive"),
                  New XElement("Director", "David Lynch"),
                  New XElement("Price", "25.74"),
                  New XElement("Starring",
                      New XElement("Star", "Laura Harring")
                  )
              ),
              New XElement("DVD",
                  New XAttribute("ID", "5"),
                  New XAttribute("Category", "Science Fiction"),
                  New XElement("Title", "A.I. Artificial Intelligence"),
                  New XElement("Director", "Steven Spielberg"),
                  New XElement("Price", "23.99"),
                  New XElement("Starring",
                      New XElement("Star", "Haley Joel Osment"),
                      New XElement("Star", "Jude Law")
                  )
              )
           )
        )
        doc.Save(Server.MapPath("DvdList2.xml"))
    End Sub

    Private Sub ReadXml()
        'Create the reader.
        Dim xmlFile As String = Server.MapPath("DvdList2.xml")
        Dim doc As XDocument = XDocument.Load(xmlFile)
        Dim str As New StringBuilder()
        For Each element As XElement In doc.Element("DvdList").Elements()
            str.Append("<ul><b>")
            str.Append(element.Element("Title"))
            str.Append("</b><li>")
            str.Append(element.Element("Director"))
            str.Append("</li><li>")
            str.Append(String.Format("{0:C}", element.Element("Price")))
            str.Append("</li><ul>")
        Next

        lblXml.Text = str.ToString()
    End Sub
End Class
