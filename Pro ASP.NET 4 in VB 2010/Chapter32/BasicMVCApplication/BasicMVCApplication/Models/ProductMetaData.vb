Imports System.ComponentModel.DataAnnotations
Namespace BasicMVCApplication.Models
    <MetadataType(GetType(ProductMetaData))>
    Public Class ProductMetaData
        <Range(1, 50)>
        Public Property UnitsInStock() As Object
    End Class
End Namespace
