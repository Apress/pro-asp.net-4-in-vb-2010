Partial Public Class CrossPageSource
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        If Request.QueryString("err") IsNot Nothing Then
            Page.Validate()
        End If
    End Sub

    Public ReadOnly Property TextBoxContent() As String
        Get
            Return txt1.Text
        End Get
    End Property

    Protected Sub cmdTransfer_Click(
        ByVal sender As Object, ByVal e As EventArgs
        ) Handles cmdTransfer.Click
        Server.Transfer("CrossPageTarget.aspx", True)
    End Sub
End Class