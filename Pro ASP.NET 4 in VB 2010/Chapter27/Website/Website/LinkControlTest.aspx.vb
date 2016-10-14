Imports System.IO

Partial Class LinkControlTest
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Create the in-memory objects that will catch the rendered output.
        Dim writer As New StringWriter()
        Dim output As New HtmlTextWriter(writer)

        ' Render the control to an in-memory string.
        LinkWebControl1.RenderControl(output)

        ' Display the HTML (and encode it properly so that
        ' it appears as text in the browser).
        lblHtml.Text =
            "The HTML for LinkWebControl1 is<br /><blockquote>" &
            Server.HtmlEncode(writer.ToString()) & "</blockquote>"
        LinkControl1.RenderControl(output)
    End Sub
End Class
