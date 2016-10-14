Imports System.Xml

Partial Class WriteAndReadXml
    Inherits System.Web.UI.Page

    Private Sub WriteXML()
        Dim xmlFile As String = Server.MapPath("DvdList.xml")

        ' Create the writer. 
        Dim writer As New XmlTextWriter(xmlFile, Nothing)
        writer.Formatting = Formatting.Indented
        writer.Indentation = 3

        ' Start the document and write a comment. 
        writer.WriteStartDocument()
        writer.WriteComment("Created @ " + DateTime.Now.ToString())

        ' Write the <DvdList> element. 
        writer.WriteStartElement("DvdList")

        ' Write the <DVD> element for "The Matrix" 
        writer.WriteStartElement("DVD")
        ' Write a couple of attributes to the <DVD> element. 
        writer.WriteAttributeString("ID", "1")
        writer.WriteAttributeString("Category", "Science Fiction")
        ' Write some simple elements. 
        writer.WriteElementString("Title", "The Matrix")
        writer.WriteElementString("Director", "Larry Wachowski")
        writer.WriteElementString("Price", "18.74")
        ' Open the <Starring> element. 
        writer.WriteStartElement("Starring")
        ' Write two elements. 
        writer.WriteElementString("Star", "Keanu Reeves")
        writer.WriteElementString("Star", "Laurence Fishburne")
        ' Close the <Starring> element. 
        writer.WriteEndElement()
        ' Close the <DVD> element. 
        writer.WriteEndElement()

        ' Write the <DVD> element for "Forrest Gump" 
        writer.WriteStartElement("DVD")

        writer.WriteAttributeString("ID", "2")
        writer.WriteAttributeString("Category", "Drama")

        writer.WriteElementString("Title", "Forrest Gump")
        writer.WriteElementString("Director", "Robert Zemeckis")
        writer.WriteElementString("Price", "23.99")

        writer.WriteStartElement("Starring")

        writer.WriteElementString("Star", "Tom Hanks")
        writer.WriteElementString("Star", "Robin Wright")

        writer.WriteEndElement()
        ' close the <DVD> element 
        writer.WriteEndElement()

        ' Write the <DVD> element for "The Others" 
        writer.WriteStartElement("DVD")

        writer.WriteAttributeString("ID", "3")
        writer.WriteAttributeString("Category", "Horror")

        writer.WriteElementString("Title", "The Others")
        writer.WriteElementString("Director", "Alejandro Amenábar")
        writer.WriteElementString("Price", "22.49")

        writer.WriteStartElement("Starring")

        writer.WriteElementString("Star", "Nicole Kidman")
        writer.WriteElementString("Star", "Christopher Eccleston")

        writer.WriteEndElement()
        ' Close the <DVD> element. 
        writer.WriteEndElement()

        ' Write the <DVD> element for "Mulholland Drive" 
        writer.WriteStartElement("DVD")

        writer.WriteAttributeString("ID", "4")
        writer.WriteAttributeString("Category", "Mystery")

        writer.WriteElementString("Title", "Mulholland Drive")
        writer.WriteElementString("Director", "David Lynch")
        writer.WriteElementString("Price", "25.74")

        writer.WriteStartElement("Starring")

        writer.WriteElementString("Star", "Laura Harring")

        writer.WriteEndElement()
        ' close the <DVD> element. 
        writer.WriteEndElement()

        ' Write the <DVD> element for "A.I. Artificial Intelligence" 
        writer.WriteStartElement("DVD")

        writer.WriteAttributeString("ID", "5")
        writer.WriteAttributeString("Category", "Science Fiction")

        writer.WriteElementString("Title", "A.I. Artificial Intelligence")
        writer.WriteElementString("Director", "Steven Spielberg")
        writer.WriteElementString("Price", "23.99")

        writer.WriteStartElement("Starring")

        writer.WriteElementString("Star", "Haley Joel Osment")
        writer.WriteElementString("Star", "Jude Law")

        writer.WriteEndElement()
        ' Close the <DVD> element. 
        writer.WriteEndElement()


        ' Close the <DvdList> element. 
        writer.WriteEndElement()

        ' Close the writer. 
        writer.Close()
    End Sub
    Private Sub ReadXML()

        Dim xmlFile As String = Server.MapPath("DvdList.xml")

        ' Create the reader. 
        Dim reader As New XmlTextReader(xmlFile)
        Dim str As New StringBuilder()
        ' Cycle through all the nodes. 
        While reader.Read()
            Select Case reader.NodeType
                Case XmlNodeType.XmlDeclaration
                    str.Append("XML Declaration: <b>")
                    str.Append(reader.Name)
                    str.Append(" ")
                    str.Append(reader.Value)
                    str.Append("</b><br>")
                    Exit Select
                Case XmlNodeType.Element
                    str.Append("Element: <b>")
                    str.Append(reader.Name)
                    str.Append("</b><br>")
                    Exit Select
                Case XmlNodeType.Text
                    str.Append(" - Value: <b>")
                    str.Append(reader.Value)
                    str.Append("</b><br>")
                    Exit Select
                Case XmlNodeType.Comment
                    str.Append("Comment: <b>")
                    str.Append(reader.Value)
                    str.Append("</b><br>")
                    Exit Select
            End Select
            ' If the current node has attributes, 
            ' add them to the string. 
            If reader.AttributeCount > 0 Then
                While reader.MoveToNextAttribute()
                    str.Append(" - Attribute: <b>")
                    str.Append(reader.Name)
                    str.Append("</b> Value: <b>")
                    str.Append(reader.Value)
                    str.Append("</b><br>")
                End While
            End If
        End While

        ' Close the reader and show the text. 
        reader.Close()
        lblXml.Text = str.ToString()
    End Sub

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        WriteXML()
        ReadXML()
    End Sub
End Class
