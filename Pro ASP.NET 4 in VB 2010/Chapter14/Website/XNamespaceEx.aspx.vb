Imports System.Xml.Linq

Partial Class XNamespaceEx
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        Dim ns As XNamespace = "http://www.somecompany.com/DVDList"
        Dim doc As New XDocument(
            New XDeclaration("1.0", "utf-8", "yes"),
            New XComment("Created: " + DateTime.Now.ToString()),
            New XElement(ns + "DvdList",
                New XElement(ns + "DVD",
                New XAttribute("ID", "1"),
                New XAttribute("Category", "Science Fiction"),
                New XElement(ns + "Title", "The Matrix"),
                New XElement(ns + "Director", "Larry Wachowski"),
                New XElement(ns + "Price", "18.74"),
                New XElement(ns + "Starring",
                    New XElement(ns + "Star", "Keanu Reeves"),
                    New XElement(ns + "Star", "Laurence Fishburne")
                    ),
                New XElement(ns + "DVD",
                New XAttribute("ID", "2"),
                New XAttribute("Category", "Drama"),
                New XElement(ns + "Title", "Forrest Gump"),
                New XElement(ns + "Director", "Robert Zemeckis"),
                New XElement(ns + "Price", "23.99"),
                New XElement(ns + "Starring",
                    New XElement(ns + "Star", "Tom Hanks"),
                    New XElement(ns + "Star", "Robin Wright")
                    )
                )
            )
        )
    )
        'Place a breakpoint on End Sub and run the code in debug 
        'then display the value of doc using the XML Visualizer
    End Sub
End Class
