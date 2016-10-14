
Partial Class GridViewAdvancedTemplates
    Inherits System.Web.UI.Page

    Protected Function GetStatusPicture(
        ByVal dataItem As Object
        ) As String
        Dim units As Integer =
            Int32.Parse(DataBinder.Eval(dataItem, "UnitsInStock").ToString())
        If units = 0 Then
            Return "Cancel.gif"
        ElseIf units > 50 Then
            Return "OK.gif"
        Else
            Return "blank.gif"
        End If
    End Function

    Protected Sub GridView1_RowCommand(
        ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs
        ) Handles GridView1.RowCommand
        If e.CommandName = "StatusClick" Then
            lblInfo.Text = "You clicked product #" + e.CommandArgument
        End If
    End Sub
End Class
