Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace DatabaseComponent
    Public Class ProductDetails
        Private productID_Renamed As Integer
        Public Property ProductID() As Integer
            Get
                Return productID_Renamed
            End Get
            Set(ByVal value As Integer)
                productID_Renamed = value
            End Set
        End Property

        Private categoryID_Renamed As Integer
        Public Property CategoryID() As Integer
            Get
                Return categoryID_Renamed
            End Get
            Set(ByVal value As Integer)
                categoryID_Renamed = value
            End Set
        End Property

        Private productName_Renamed As String
        Public Property ProductName() As String
            Get
                Return productName_Renamed
            End Get
            Set(ByVal value As String)
                productName_Renamed = value
            End Set
        End Property

        Private unitPrice_Renamed As Decimal
        Public Property UnitPrice() As Decimal
            Get
                Return unitPrice_Renamed
            End Get
            Set(ByVal value As Decimal)
                unitPrice_Renamed = value
            End Set
        End Property

        Public Sub New()
        End Sub

        Public Sub New(ByVal productID As Integer, ByVal productName As String, ByVal unitPrice As Decimal, ByVal categoryID As Integer)
            Me.ProductID = productID
            Me.ProductName = productName
            Me.UnitPrice = unitPrice
            Me.CategoryID = categoryID
        End Sub
    End Class
End Namespace