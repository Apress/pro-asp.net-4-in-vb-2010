
Partial Class _Default
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        If Not Me.IsPostBack Then
            Dim Root As New MenuItem("Select Mode")
            For Each mode As WebPartDisplayMode In MyPartManager.DisplayModes
                If mode.IsEnabled(MyPartManager) Then
                    Root.ChildItems.Add(New MenuItem(mode.Name))
                End If
            Next
            PartsMenu.Items.Add(Root)
        End If
    End Sub

    Protected Sub PartsMenu_MenuItemClick(
        ByVal sender As Object,
        ByVal e As System.Web.UI.WebControls.MenuEventArgs
        ) Handles PartsMenu.MenuItemClick
        MyPartManager.DisplayMode =
            MyPartManager.DisplayModes(e.Item.Text)
    End Sub
End Class
