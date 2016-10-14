Partial Class EventTracker
    Inherits System.Web.UI.Page
    Protected Sub CtrlChanged(
        ByVal sender As Object, ByVal e As EventArgs)
        Dim ctrlName As String = DirectCast(sender, Control).ID
        lstEvents.Items.Add(ctrlName & " Changed")

        ' Select the last item to scroll the list so the most recent 
        ' entries are visible. 
        lstEvents.SelectedIndex = lstEvents.Items.Count - 1
    End Sub
End Class
