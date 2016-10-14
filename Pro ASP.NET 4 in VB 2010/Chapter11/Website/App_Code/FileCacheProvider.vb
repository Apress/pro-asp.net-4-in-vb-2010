Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary

Public Class FileCacheProvider
    Inherits OutputCacheProvider
    ' The location where cached files will be placed.
    Public Property CachePath As String

    Public Overrides Function [Add](ByVal key As String,
        ByVal entry As Object,
        ByVal utcExpiry As DateTime
        ) As Object
        ' Transform the key to a unique filename.
        Dim path As String = ConvertKeyToPath(key)
        ' Set it only if it is not already cached.
        If Not File.Exists(path) Then [Set](key, entry, utcExpiry)
        Return entry
    End Function
    Public Overrides Sub [Set](
        ByVal key As String,
        ByVal entry As Object,
        ByVal utcExpiry As DateTime
        )
        Dim item As CacheItem = New CacheItem()
        item.theCacheItem(entry, utcExpiry)
        Dim path As String = ConvertKeyToPath(key)
        ' Overwrite it, even if it already exists.
        Using theFile As FileStream = File.OpenWrite(path)
            Dim formatter As New BinaryFormatter()
            formatter.Serialize(theFile, item)
        End Using
    End Sub
    Public Overrides Function [Get](ByVal key As String
        ) As Object
        Dim path As String = ConvertKeyToPath(key)
        If Not File.Exists(path) Then Return Nothing
        Dim item As CacheItem = Nothing
        Using theFile As FileStream = File.OpenRead(path)
            Dim formatter As New BinaryFormatter()
            item = DirectCast(formatter.Deserialize(theFile), CacheItem)
        End Using
        ' Remove expired items.
        If item.ExpiryDate <= DateTime.Now.ToUniversalTime() Then
            Remove(key)
            Return Nothing
        End If
        Return item.Item
    End Function
    Public Overrides Sub [Remove](ByVal key As String)
        Dim path As String = ConvertKeyToPath(key)
        If File.Exists(path) Then File.Delete(path)
    End Sub

    Private Function ConvertKeyToPath(ByVal key As String) As String
        ' Flatten it to a single file name, with no path information.
        Dim file As String = key.Replace("/", "-")
        ' Add .txt extension so it's not confused with a real ASP.NET file.
        file &= ".txt"
        Return Path.Combine(CachePath, file)
    End Function
    Public Overrides Sub Initialize(
        ByVal name As String, ByVal attributes As NameValueCollection
        )
        MyBase.Initialize(name, attributes)
        ' Retrieve the web.config settings.
        CachePath =
            HttpContext.Current.Server.MapPath(attributes("cachePath"))
    End Sub
End Class
<Serializable()> Public Class CacheItem
    Public ExpiryDate As DateTime
    Public Item As Object

    Public Sub theCacheItem(
        ByVal theItem As Object, ByVal theExpiryDate As DateTime
        )
        ExpiryDate = theExpiryDate
        Item = theItem
    End Sub
End Class
