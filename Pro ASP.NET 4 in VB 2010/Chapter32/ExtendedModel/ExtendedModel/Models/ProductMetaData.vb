Imports System.ComponentModel.DataAnnotations

<MetadataType(GetType(Product.ProductMetaData))>
Partial Public Class Product

    Public Class ProductMetaData
        <Range(1, 50)>
        <OddOrEven(
            OddOrEvenAttribute.Mode.Even,
            ErrorMessage:="Units In Stock must be even"
            )>
        Public Property UnitsInStock() As Object
    End Class
End Class








