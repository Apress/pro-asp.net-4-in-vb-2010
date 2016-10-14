Partial Class AdTest
    Inherits System.Web.UI.Page

    Protected Sub AdRotator1_AdCreated(
        ByVal sender As Object,
        ByVal e As System.Web.UI.WebControls.AdCreatedEventArgs
        ) Handles AdRotator1.AdCreated
        ' Synchronize the Hyperlink control. 
        lnkBanner.NavigateUrl = e.NavigateUrl
        ' Synchronize the text of the link. 
        lnkBanner.Text = "Click here for information about our sponsor: "
        lnkBanner.Text += e.AlternateText
    End Sub
End Class
