Partial Public Class ItemRemovedCallbackTest
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As EventArgs
        ) Handles Me.Load
        If Not Me.IsPostBack Then
            lblInfo.Text &= "Creating items...<br />"
            Dim itemA As String = "item A"
            Dim itemB As String = "item B"
            Cache.Insert("itemA", itemA, Nothing, DateTime.Now.AddMinutes(60),
                         TimeSpan.Zero, CacheItemPriority.[Default],
                         New CacheItemRemovedCallback(AddressOf ItemRemovedCallback))
            Cache.Insert("itemB", itemB, Nothing, DateTime.Now.AddMinutes(60),
                         TimeSpan.Zero, CacheItemPriority.[Default],
                         New CacheItemRemovedCallback(AddressOf ItemRemovedCallback))
        End If
    End Sub
    Protected Sub cmdCheck_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim itemList As String = ""
        For Each item As DictionaryEntry In Cache
            itemList &= item.Key.ToString() & " "
        Next
        lblInfo.Text &= "<br />Found: " & itemList & "<br />"
    End Sub
    Protected Sub cmdRemove_Click(
        ByVal sender As Object, ByVal e As EventArgs
        )
        lblInfo.Text &= "<br />Removing itemA.<br />"
        Cache.Remove("itemA")
    End Sub

    Private Sub ItemRemovedCallback(
        ByVal key As String, ByVal value As Object,
        ByVal reason As CacheItemRemovedReason
        )
        ' This fires after the request has ended, when the 
        ' item is removed. 

        ' If either item has been removed, make sure 
        ' the other item is also removed. 
        If key = "itemA" OrElse key = "itemB" Then
            Cache.Remove("itemA")
            Cache.Remove("itemB")
        End If
    End Sub
End Class