
Partial Class SingleValueBinding
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        Me.DataBind()
    End Sub

    Protected Function GetFilePath() As String
        Return "apress.gif"
    End Function

    Protected ReadOnly Property FilePath() As String
        Get
            Return "apress.gif"
        End Get
    End Property

End Class
