Imports System.IO
Imports System.Xml.Schema
Imports System.Xml
Imports System.Configuration

Partial Class XmlValidation
    Inherits System.Web.UI.Page

    Private Sub MyValidateHandler(
        ByVal sender As Object, ByVal e As ValidationEventArgs
        )
        lblStatus.Text += "Error: " + e.Message + "<br>"
    End Sub

    Protected Sub cmdValidate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdValidate.Click
        Dim filePath As String = ""
        If optValid.Checked Then
            filePath = Server.MapPath("DvdList.xml")
        ElseIf optInvalidData.Checked Then
            filePath += Server.MapPath("DvdListInvalid.xml")
        End If

        lblStatus.Text = ""

        ' Set the validation settings. 
        Dim settings As New XmlReaderSettings()
        settings.Schemas.Add("", Server.MapPath("DvdList.xsd"))
        settings.ValidationType = ValidationType.Schema
        ' Connect to the method named MyValidateHandler.
        AddHandler settings.ValidationEventHandler,
            AddressOf Me.MyValidateHandler

        ' Open the XML file. 
        Dim fs As New FileStream(filePath, FileMode.Open, FileAccess.Read)

        ' Create the validating reader. 
        Dim r As XmlReader = XmlReader.Create(fs, settings)

        ' Read through the document. 
        ' Process document here. 
        ' If an error is found, an exception will be thrown. 
        While r.Read()
        End While

        r.Close()

        lblStatus.Text += "<br />Complete."
    End Sub
End Class
