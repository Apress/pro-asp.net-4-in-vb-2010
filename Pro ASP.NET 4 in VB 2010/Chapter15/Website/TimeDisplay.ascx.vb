Partial Class TimeDisplay
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        If Not Page.IsPostBack Then
            RefreshTime()
        End If
    End Sub

    Private frmt As String = ""
    Public Property Format() As String
        Get
            Return frmt
        End Get
        Set(ByVal value As String)
            frmt = value
        End Set
    End Property

    Protected Sub lnkTime_Click(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles lnkTime.Click
        RefreshTime()
    End Sub

    Public Sub RefreshTime()
        If IsDBNull(frmt) Then
            lnkTime.Text = DateTime.Now.ToLongTimeString()
        Else
            'This will throw an exception for invalid format strings,
            'which is acceptable.
            lnkTime.Text = DateTime.Now.ToString(Format)
        End If
    End Sub
End Class
