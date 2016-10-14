
Partial Class ControlTree
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(
        ByVal sender As Object,
        ByVal e As System.EventArgs
        ) Handles Me.Load
        ' Start examining all the controls. 
        DisplayControl(Page.Controls, 0)

        'Add the closing horizontal line. 
        Response.Write("<hr />")
    End Sub

    Private Sub DisplayControl(
        ByVal controls As ControlCollection,
        ByVal depth As Integer)

        For Each control As Control In controls
            ' Use the depth parameter to indent the control tree. 
            Response.Write(New String("-"c, depth * 4) & "> ")
            ' Display this control. 
            Response.Write(control.[GetType]().ToString() &
                " - <b>" & control.ID & "</b><br />")
            'If TypeOf control Is LiteralControl Then
            '    ' Display the literal content (whitespace and all). 
            '    Dim text As String =
            '        DirectCast(control, LiteralControl).Text
            '    Response.Write("*** Text: " &
            '        Server.HtmlEncode(text) & "<br />")
            'End If
            If control.Controls IsNot Nothing Then
                DisplayControl(control.Controls, depth + 1)
            End If
        Next
    End Sub
End Class
