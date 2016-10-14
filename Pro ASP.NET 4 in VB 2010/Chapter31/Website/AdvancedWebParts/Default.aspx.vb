Imports Apress.WebParts.Samples

Partial Class _Default
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load

        If Not Me.IsPostBack Then
            Dim i As Integer = 1
            For Each part As WebPart In MyPartManager.WebParts
                If TypeOf part Is GenericWebPart Then
                    part.Title = String.Format("Web Part Number {0}", i)
                    i += 1
                End If
            Next
        End If

        If Not Me.IsPostBack Then
            MyCalendar.SelectedDate = DateTime.Now.AddDays(7)
        End If

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

    Protected Sub MyCustomers_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        )
        Dim part As GenericWebPart =
            DirectCast(MyPartManager.Parent, GenericWebPart)
        part.Title = "Customers"
        part.TitleUrl = "http://www.apress.com"
        part.CatalogIconImageUrl = "CustomersSmall.jpg"
        part.Description = "Displays all customers in the database!"
    End Sub
End Class
