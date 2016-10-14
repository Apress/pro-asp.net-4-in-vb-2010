
Partial Class DynamicUserControls
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        Dim ctrlName As String = lstControls1.SelectedItem.Value
        If ctrlName.EndsWith(".ascx") Then
            PlaceHolder1.Controls.Add(Page.LoadControl(ctrlName))
        End If
        PanelLabel1.Text = "Loaded..." & ctrlName
    End Sub
End Class
