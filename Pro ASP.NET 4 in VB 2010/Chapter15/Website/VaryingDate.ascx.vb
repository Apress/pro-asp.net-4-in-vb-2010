
Partial Class VaryingDate
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        Select Case lstMode.SelectedIndex
            Case 0
                TimeMsg.Font.Size = FontUnit.Large
                Exit Select
            Case 1
                TimeMsg.Font.Size = FontUnit.Small
                Exit Select
            Case 2
                TimeMsg.Font.Size = FontUnit.Medium
                Exit Select
        End Select
        TimeMsg.Text = DateTime.Now.ToString("F")
    End Sub
End Class
