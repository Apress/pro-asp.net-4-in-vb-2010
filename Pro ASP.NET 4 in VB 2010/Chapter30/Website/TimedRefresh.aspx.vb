
Partial Class TimedRefresh
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Label1.Text = DateTime.Now.ToLongTimeString()
        Label2.Text = DateTime.Now.ToLongTimeString()
    End Sub

    Protected Sub TimerControl1_Tick(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles TimerControl1.Tick
        Dim tickCount As Integer = 0
        ' Update the tick count and store it in view state.
        If ViewState("TickCount") IsNot Nothing Then
            tickCount = CInt(ViewState("TickCount"))
        End If
        tickCount += 1

        ViewState("TickCount") = tickCount
        ' Decide whether to disable the timer.
        If tickCount > 10 Then
            TimerControl1.Enabled = False
        End If
    End Sub
End Class
