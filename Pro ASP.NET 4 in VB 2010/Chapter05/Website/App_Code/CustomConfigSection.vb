Public Class OrderService
    Inherits ConfigurationSection
    <ConfigurationProperty("available", _
    IsRequired:=False, DefaultValue:=True)> _
    Public Property Available() As Boolean
        Get
            Return CBool(MyBase.Item("available"))
        End Get
        Set(ByVal value As Boolean)
            MyBase.Item("available") = value
        End Set
    End Property

    <ConfigurationProperty("pollTimeout", IsRequired:=True)> _
    Public Property PollTimeout() As TimeSpan
        Get
            Return DirectCast(MyBase.Item("pollTimeout"), TimeSpan)
        End Get
        Set(ByVal value As TimeSpan)
            MyBase.Item("pollTimeout") = value
        End Set
    End Property

    <ConfigurationProperty("thelocation", IsRequired:=True)> _
    Public Property Location() As Location
        Get
            Return DirectCast(MyBase.Item("thelocation"), Location)
        End Get
        Set(ByVal value As Location)
            MyBase.Item("thelocation") = value
        End Set
    End Property
End Class

Public Class Location
    Inherits ConfigurationElement
    <ConfigurationProperty("computer", IsRequired:=True)> _
    Public Property Computer() As String
        Get
            Return MyBase.Item("computer").ToString
        End Get
        Set(ByVal value As String)
            MyBase.Item("computer") = value
        End Set
    End Property

    <ConfigurationProperty("port", IsRequired:=True)> _
    Public Property Port() As Integer
        Get
            Return CInt(MyBase.Item("port"))
        End Get
        Set(ByVal value As Integer)
            MyBase.Item("port") = value
        End Set
    End Property

    <ConfigurationProperty("endpoint", IsRequired:=True)> _
    Public Property Endpoint() As String
        Get
            Return DirectCast(MyBase.Item("endpoint"), String)
        End Get
        Set(ByVal value As String)
            MyBase.Item("endpoint") = value
        End Set
    End Property
End Class
