
Partial Class SqlDataSourceParameters2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        If Not Page.IsPostBack Then
            ' Trigger the sourceEmployeeCities query and bind the results.
            lstCities.DataSource =
                sourceEmployeeCities.Select(DataSourceSelectArguments.Empty)
            lstCities.DataBind()
            ' Add the two new items and select the first.
            lstCities.Items.Insert(0, "(Choose a City)")
            lstCities.Items.Insert(1, "(All Cities)")
            lstCities.SelectedIndex = 0
        End If
    End Sub

    Protected Sub sourceEmployees_Selecting(
        ByVal sender As Object, ByVal e As SqlDataSourceSelectingEventArgs
        ) Handles sourceEmployees.Selecting
        If DirectCast(e.Command.Parameters("@City").Value, String) =
            "(Choose a City)" Then
            ' Do nothing.
            e.Cancel = True
        ElseIf DirectCast(e.Command.Parameters("@City").Value, String) =
            "(All Cities)" Then
            ' Manually change the command.
            e.Command.CommandText = "SELECT * FROM Employees"
        End If
    End Sub
End Class
