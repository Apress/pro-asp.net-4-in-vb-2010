Public Class myObjectDataSource
    Public Class DataItem
        Public Property Name() As String
        Public Property Popularity() As Double
    End Class

    Public Function GetData() As DataItem()
        Return New DataItem() {
            New DataItem() With {.Name = "Cheesecake", .Popularity = 30},
            New DataItem() With {.Name = "Ice Cream", .Popularity = 30},
            New DataItem() With {.Name = "Fudge", .Popularity = 20},
            New DataItem() With {.Name = "Milkshake", .Popularity = 20}
        }
    End Function
End Class
