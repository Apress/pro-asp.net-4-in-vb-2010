
Partial Public Class Customers
    Inherits System.Web.UI.UserControl
    Implements IWebPart
#Region "IWebPart Members"

    Public Property CatalogIconImageUrl() As String _
        Implements IWebPart.CatalogIconImageUrl
    Public Property Description() As String _
        Implements IWebPart.Description
    Public ReadOnly Property Subtitle() As String _
        Implements IWebPart.Subtitle
        Get
            Return "Internal Customer List"
        End Get
    End Property
    Private _TitleIconImageUrl As String
    Public Property TitleIconImageUrl() As String _
        Implements IWebPart.TitleIconImageUrl
        Get
            If _TitleIconImageUrl Is Nothing Then
                Return "~/CustomersSmall.jpg"
            Else
                Return _TitleIconImageUrl
            End If
        End Get
        Set(ByVal value As String)
            _TitleIconImageUrl = value
        End Set
    End Property
    Public Property TitleUrl() As String _
        Implements IWebPart.TitleUrl
    Public Property Title() As String _
        Implements IWebPart.Title
        Get
            If ViewState("Title") Is Nothing Then
                Return String.Empty
            Else
                Return DirectCast(ViewState("Title"), String)
            End If
        End Get
        Set(ByVal value As String)
            ViewState("Title") = value
        End Set
    End Property
#End Region
End Class

