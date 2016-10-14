Imports System.IO
Imports CustomServerControlsLibrary
Partial Class XmlLabelTest
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim r As StreamReader = File.OpenText(Server.MapPath("DvdList.xml"))
        Dim text As String = r.ReadToEnd()
        r.Close()
        'StdLabel.Text = Server.HtmlEncode(text)
        RichLabel1.Text = text
    End Sub
End Class
