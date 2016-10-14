Imports System.Xml

Partial Class ReadXmlEfficient
    Inherits System.Web.UI.Page

    Private Sub ReadXML()
        Dim xmlFile As String = Server.MapPath("DvdList.xml")

        ' Create the reader.
        Dim reader As New XmlTextReader(xmlFile)

        Dim str As New StringBuilder()
        reader.ReadStartElement("DvdList")

        ' Read all the <DVD> elements.
        While reader.Read()
            If reader.Name = "DVD" And reader.NodeType = XmlNodeType.Element Then
                reader.ReadStartElement("DVD")
                str.Append("<ul><b>")
                str.Append(reader.ReadElementString("Title"))
                str.Append("<b><li>")
                str.Append(reader.ReadElementString("Director"))
                str.Append("</li><li>")
                str.Append(
                    String.Format(
                        "{0:C}", Decimal.Parse(
                            reader.ReadElementString("Price")
                            )
                        )
                    )
                str.Append("</li></ul>")
            End If
        End While

        ' Close the reader and show the text.
        reader.Close()
        lblXml.Text = str.ToString()
    End Sub

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        ReadXML()
    End Sub
End Class
