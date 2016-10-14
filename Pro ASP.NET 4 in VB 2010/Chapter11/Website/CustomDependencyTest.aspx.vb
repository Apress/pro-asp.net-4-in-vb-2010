Imports System.Messaging

Partial Public Class CustomDependencyTest
    Inherits System.Web.UI.Page
    Protected Sub Page_PreRender(
        ByVal sender As Object, ByVal e As EventArgs
        )
        lblInfo.Text &= "<br>"
    End Sub

    Private queueName As String = ".\Private$\TestQueue"
    ' The leading . represents the current computer.
    ' The following Private$ indicates it's a private queue for this computer.
    ' The TestQueue is the queue name (you can modify this part).
    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As EventArgs
        )
        If Not Me.IsPostBack Then
            ' Set up the queue.
            Dim queue As MessageQueue
            If MessageQueue.Exists(queueName) Then
                queue = New MessageQueue(queueName)
            Else
                queue = MessageQueue.Create(".\Private$\TestQueue")
            End If
            lblInfo.Text += "Creating dependent item...<br />"
            Cache.Remove("Item")
            Dim dependency As New MessageQueueCacheDependency(queueName)
            Dim item As String = "Dependent cached item"
            lblInfo.Text += "Adding dependent item<br />"
            Cache.Insert("Item", item, dependency)
        End If
    End Sub

    Protected Sub cmdModfiy_Click(
        ByVal sender As Object, ByVal e As EventArgs
        )
        Dim queue As New MessageQueue(queueName)
        ' (You could send a custom object instead 
        ' of a string.) 
        queue.Send("Invalidate!")
        lblInfo.Text &= "Message sent<br/>"
    End Sub

    Protected Sub cmdGetItem_Click(
        ByVal sender As Object, ByVal e As EventArgs
        )
        If Cache("Item") Is Nothing Then
            lblInfo.Text &= "Cache item no longer exists.<br>"
        Else
            Dim cacheInfo As String = DirectCast(Cache("Item"), String)
            lblInfo.Text &=
                "Retrieved item with text: '" & cacheInfo & "'<br>"
        End If
    End Sub
End Class