
Partial Class BrowserHistory
    Inherits System.Web.UI.Page

    Protected Sub Wizard1_ActiveStepChanged(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Wizard1.ActiveStepChanged
        ' Verify this is an asynchronous postback, and ensure that it's
        ' not a navigation attempt.
        If (ScriptManager1.IsInAsyncPostBack) AndAlso
            (Not ScriptManager1.IsNavigating) Then
            Dim currentStep As String = Wizard1.ActiveStepIndex.ToString()
            ScriptManager1.AddHistoryPoint(
                "Wizard1",
                Wizard1.ActiveStepIndex.ToString(),
                "Step " & (Wizard1.ActiveStepIndex + 1).ToString()
                )
        End If
    End Sub

    Protected Sub ScriptManager1_Navigate(
        ByVal sender As Object, ByVal e As System.Web.UI.HistoryEventArgs
        ) Handles ScriptManager1.Navigate
        If e.State("Wizard1") Is Nothing Then
            ' Restore default state of page (for example, for first page).
            Wizard1.ActiveStepIndex = 0
        Else
            Wizard1.ActiveStepIndex = Int32.Parse(e.State("Wizard1"))
        End If
        Page.Title = "Step " & (Wizard1.ActiveStepIndex + 1).ToString()
    End Sub
End Class
