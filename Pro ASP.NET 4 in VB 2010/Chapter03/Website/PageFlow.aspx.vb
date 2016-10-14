
Partial Class PageFlow
    Inherits System.Web.UI.Page
    'Public lblInfo As Label

    Private Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs)
        lblInfo.Text &= "Page.Init event handled.<br/>"
    End Sub

    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        lblInfo.Text &= "Page.Load event handled.<br/>"
        If Page.IsPostBack Then
            lblInfo.Text &= "<b>This is not the first time you've seen this page.</b><br/>"
        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        lblInfo.Text &= "Button1.Click event handled.<br/>"
    End Sub

    Private Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs)
        lblInfo.Text &= "Page.PreRender event handled.<br/>"
    End Sub

    Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs)
        ' This text never appears because the HTML is already 
        ' rendered for the page at this point. 
        lblInfo.Text &= "Page.Unload event handled.<br/>"
    End Sub
End Class
