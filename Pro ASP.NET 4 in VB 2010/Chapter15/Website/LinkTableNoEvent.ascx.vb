Partial Public Class LinkTableNoEvent
    Inherits System.Web.UI.UserControl
    Public Property Title() As String
        Get
            Return lblTitle.Text
        End Get
        Set(ByVal value As String)
            lblTitle.Text = value
        End Set
    End Property

    Private m_items As LinkTableItem()
    Public Property Items() As LinkTableItem()
        Get
            Return m_items
        End Get
        Set(ByVal value As LinkTableItem())
            m_items = value

            ' Refresh the grid. 
            gridLinkList.DataSource = m_items
            gridLinkList.DataBind()
        End Set
    End Property
End Class

Public Class LinkTableItem
    Public Property Text() As String
    Public Property Url() As String
    ' Default constructor. 
    Public Sub New()
    End Sub

    Public Sub New(
        ByVal text As String,
        ByVal url As String
        )
        Me.Text = text
        Me.Url = url
    End Sub
End Class
