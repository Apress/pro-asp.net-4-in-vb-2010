
Partial Class ImageHandlerTest
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtUrl.Text = Request.Url.Scheme + "://" &
            Request.Url.Authority &
            Request.Url.Segments(0).ToString() &
            Request.Url.Segments(1).ToString() &
            "Images/360.gif"
    End Sub
End Class
