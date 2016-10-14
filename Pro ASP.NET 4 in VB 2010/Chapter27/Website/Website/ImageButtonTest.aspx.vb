
Partial Class ImageButtonTest
    Inherits System.Web.UI.Page

    Protected Sub CustomImageButton1_ImageClicked(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles CustomImageButton1.ImageClicked
        Dim count As Integer = 0
        If ViewState("count") IsNot Nothing Then
            count = CInt(ViewState("count"))
        End If
        count += 1
        Label1.Text = "You clicked the button " &
            count.ToString & " times."
        ViewState("count") = count
    End Sub
End Class
