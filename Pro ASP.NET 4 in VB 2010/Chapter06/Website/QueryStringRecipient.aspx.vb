
Partial Class QueryStringRecipient
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        lblDate.Text = "The time is now:<br>" & DateTime.Now.ToString()
        Select Case Request.QueryString("Version")
            Case "cmdLarge"
                lblDate.Font.Size = FontUnit.XLarge
                Exit Select
            Case "cmdNormal"
                lblDate.Font.Size = FontUnit.Large
                Exit Select
            Case "cmdSmall"
                lblDate.Font.Size = FontUnit.Small
                Exit Select
        End Select
    End Sub
End Class
