Partial Public Class LinkTable
    Inherits System.Web.UI.UserControl
    Public Event LinkClicked As LinkClickedEventHandler

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

    Protected Sub gridLinkList_RowCommand(
        ByVal sender As Object, ByVal e As GridViewCommandEventArgs
        ) Handles gridLinkList.RowCommand
        ' Get the LinkButton object that was clicked. 
        Dim link As LinkButton = DirectCast(e.CommandSource, LinkButton)

        ' Construct the event arguments. 
        Dim item As New LinkTableItem(link.Text, link.CommandArgument)
        Dim args As New LinkTableEventArgs(item)

        ' Fire the event.
        RaiseEvent LinkClicked(Me, args)
        ' Navigate to the link if the event recipient didn't 
        ' cancel the operation. 
        If Not args.Cancel Then
            Response.Redirect(item.Url)
        End If
    End Sub
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
Public Class LinkTableEventArgs
    Inherits EventArgs
    Private m_selectedItem As LinkTableItem
    Public ReadOnly Property SelectedItem() As LinkTableItem
        Get
            Return m_selectedItem
        End Get
    End Property

    Public Property Cancel() As Boolean

    Public Sub New(ByVal item As LinkTableItem)
        m_selectedItem = item
    End Sub
End Class

Public Delegate Sub LinkClickedEventHandler(
    ByVal sender As Object, ByVal e As LinkTableEventArgs
    )