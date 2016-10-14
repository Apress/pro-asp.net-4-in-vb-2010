
Partial Class LinkTableHost
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        'AddHandler LinkTable1.LinkClicked, AddressOf Me.HandleLinkClick
        ' Set the title
        LinkTable1.Title = "A List of Links"

        ' Set the hyperlinked item list.
        Dim items As LinkTableItem() = New LinkTableItem(2) {}
        items(0) =
            New LinkTableItem("Apress", "http://www.apress.com")
        items(1) =
            New LinkTableItem("Microsoft", "http://www.microsoft.com")
        items(2) =
            New LinkTableItem("ProseTech", "http://www.prosetech.com")
        LinkTable1.Items = items
    End Sub

    Protected Sub HandleLinkClick(
        ByVal sender As Object, ByVal e As LinkTableEventArgs
        ) Handles LinkTable1.LinkClicked
        lblInfo.Text =
            "You clicked '" & e.SelectedItem.Text &
            "' but this page chose not to direct you to '" &
            e.SelectedItem.Url & "'."
        e.Cancel = True
    End Sub
End Class
