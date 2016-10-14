Partial Class SelectableListControls
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        If Not Page.IsPostBack Then
            For i As Integer = 3 To 5
                Listbox1.Items.Add("Option " & i.ToString())
                DropdownList1.Items.Add("Option " & i.ToString())
                CheckboxList1.Items.Add("Option " & i.ToString())
                RadiobuttonList1.Items.Add("Option " & i.ToString())
            Next
        End If
    End Sub

    Protected Sub Button1_Click(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Button1.Click

        Response.Write("<b>Selected items for Listbox1:</b><br/>")
        For Each li As ListItem In Listbox1.Items
            If li.Selected Then
                Response.Write("- " & li.Text + "<br/>")
            End If
        Next

        Response.Write("<b>Selected item for DropdownList1:</b><br/>")
        Response.Write("- " & DropdownList1.SelectedItem.Text & "<br/>")

        Response.Write("<b>Selected items for CheckboxList1:</b><br/>")
        For Each li As ListItem In CheckboxList1.Items
            If li.Selected Then
                Response.Write("- " & li.Text + "<br/>")
            End If
        Next

        Response.Write("<b>Selected item for RadiobuttonList1:</b><br/>")
        Response.Write("- " & RadiobuttonList1.SelectedItem.Text & "<br/>")
    End Sub

End Class
