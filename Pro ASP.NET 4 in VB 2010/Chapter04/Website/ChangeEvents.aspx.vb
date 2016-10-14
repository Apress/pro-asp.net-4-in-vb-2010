Partial Class ChangeEvents
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        If Not Page.IsPostBack Then
            List1.Items.Add("Option 3")
            List1.Items.Add("Option 4")
            List1.Items.Add("Option 5")
        End If
        Response.Write("<ol>")
    End Sub

    Protected Sub Ctrl_ServerChange(
    ByVal sender As Object,
    ByVal e As System.EventArgs)
        Response.Write("<li>ServerChange detected for " &
            DirectCast(sender, Control).ID & "</li>")
    End Sub

    Protected Sub List1_ServerChange(
        ByVal sender As Object, ByVal e As System.EventArgs
        )
        Response.Write("<li>ServerChange detected for List1. " &
                       "The selected items are:</li><br/><ul>")
        For Each li As ListItem In List1.Items
            If li.Selected Then
                Response.Write("&nbsp;&nbsp;- " & li.Value & "<br/>")
            End If
        Next
        Response.Write("</ul>")
    End Sub

    Protected Sub Submit1_ServerClick(
        ByVal sender As Object, ByVal e As System.EventArgs
        )
        Response.Write("<li>ServerClick detected for Submit1.</li></ol>")
    End Sub
End Class
