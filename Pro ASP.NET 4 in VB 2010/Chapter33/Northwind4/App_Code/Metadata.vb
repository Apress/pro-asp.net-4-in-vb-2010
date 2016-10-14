Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations

<MetadataType(GetType(Order_DetailMetadata))>
Partial Public Class Order_Detail
End Class

<DisplayName("Order Details")>
Public Class Order_DetailMetadata
End Class

<MetadataType(GetType(ProductMetadata))>
Partial Public Class Product
    Private Sub OnUnitsInStockChanging(ByVal value As System.Nullable(Of Short))
        If value Mod 2 = 1 Then
            Throw New ValidationException("Stock level must be an even number")
        End If
    End Sub
End Class

Public Class ProductMetadata

    <DisplayName("In Stock")>
    <Required(ErrorMessage:="You must enter how many items we have in stock")>
    <Range(0, 100)>
    Public Property UnitsInStock() As Object

    <DisplayName("Price")>
    Public Property UnitPrice() As Object

    <ScaffoldColumn(False)> _
    Public Property SupplierID() As Object

End Class

<MetadataType(GetType(CustomerMetadata))> _
Partial Public Class Customer
End Class

<ScaffoldTable(False)>
Public Class CustomerMetadata
End Class
<MetadataType(GetType(OrderMetadata))>
Partial Public Class Order
End Class

Public Class OrderMetadata

    <DisplayFormat(DataFormatString:="{0:yy-MM-dd}")>
    Public Property OrderDate() As Object

    <DisplayFormat(DataFormatString:="{0:yy-MM-dd}")>
    Public Property RequiredDate() As Object

    <DisplayFormat(DataFormatString:="{0:yy-MM-dd}")>
    Public Property ShippedDate() As Object

    <UIHint("REDText")>
    Public Property ShipName() As Object
End Class


