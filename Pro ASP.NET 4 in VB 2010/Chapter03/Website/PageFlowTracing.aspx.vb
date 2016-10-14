
Partial Class PageFlowTracing
    Inherits System.Web.UI.Page

    Private Sub Page_Init(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Init
        lblInfo.Text &= "Page.Init event handled.<br/>"
    End Sub

    Private Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        lblInfo.Text &= "Page.Load event handled.<br/>"
        If Page.IsPostBack Then
            lblInfo.Text &= "<b>This is the second time you've seen this page.</b><br/>"
        End If
    End Sub

    Protected Sub Button1_Click(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Button1.Click
        ' You can supply just a message, or include a category label, 
        ' as shown here. 
        Trace.Write("Button1_Click", "About to update the label.")
        lblInfo.Text &= "Button1.Click event handled.<br />"
        Trace.Write("Button1_Click", "Label updated.")
    End Sub

    Protected Sub Page_PreRender(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.PreRender
        lblInfo.Text &= "Page.PreRender event handled.<br/>"
    End Sub

    Protected Sub Page_Unload(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Unload
        ' This text never appears because the HTML is already 
        ' rendered for the page at this point. 
        lblInfo.Text &= "Page.Unload event handled.<br/>"
    End Sub
End Class
