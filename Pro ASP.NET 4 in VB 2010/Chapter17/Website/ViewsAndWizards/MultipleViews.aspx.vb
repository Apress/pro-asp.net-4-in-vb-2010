
Partial Class ViewsAndWizards_MultipleViews
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        If Not Page.IsPostBack Then
            DropDownList1.DataSource = MultiView1.Views
            DropDownList1.DataTextField = "ID"
            DropDownList1.DataBind()
        End If
    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles DropDownList1.SelectedIndexChanged
        MultiView1.ActiveViewIndex = DropDownList1.SelectedIndex
    End Sub
End Class
