<Serializable()> _
Public Class Address
    Public Property Name() As String
    Public Property Street() As String
    Public Property City() As String
    Public Property ZipCode() As String
    Public Property State() As String
    Public Property Country() As String
    Public Sub New(ByVal name__1 As String,
                   ByVal street__2 As String,
                   ByVal city__3 As String,
                   ByVal zipCode__4 As String,
                   ByVal state__5 As String,
                   ByVal country__6 As String
                   )
        Name = name__1
        Street = street__2
        City = city__3
        ZipCode = zipCode__4
        State = state__5
        Country = country__6
    End Sub

    Public Sub New()
    End Sub
End Class
