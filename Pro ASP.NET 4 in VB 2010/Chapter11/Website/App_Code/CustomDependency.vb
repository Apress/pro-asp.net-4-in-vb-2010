Imports System.Messaging
Imports System.Threading
Public Class TimerTestCacheDependency
    Inherits CacheDependency
    Private timer As System.Threading.Timer
    Private pollTime As Integer = 5000
    Private count As Integer = 0

    Public Sub New()
        ' Check immediately and then wait the poll time 
        ' for each subsequent check (same as CacheDependency behavior). 
        timer =
            New System.Threading.Timer(New TimerCallback(AddressOf CheckDependencyCallback), Me, 0, pollTime)
    End Sub

    Private Sub CheckDependencyCallback(ByVal sender As Object)
        ' Check your resource here (the polling). 
        ' If it's changed, notify ASP.NET: 
        count += 1
        If count > 4 Then
            MyBase.NotifyDependencyChanged(Me, EventArgs.Empty)
            timer.Dispose()
        End If
    End Sub

    Protected Overloads Overrides Sub DependencyDispose()
        ' Clean up code goes here. 
        ' This is called after the dependency signals a change 
        ' (and therefore isn't needed anymore). 
        If timer IsNot Nothing Then
            timer.Dispose()
        End If
    End Sub
End Class

Public Class MessageQueueCacheDependency
    Inherits CacheDependency
    ' The queue to monitor. 
    Private queue As MessageQueue

    Public Sub New(ByVal queueName As String)
        queue = New MessageQueue(queueName)

        ' Wait for the queue message on another thread. 
        Dim callback As New WaitCallback(AddressOf WaitForMessage)
        ThreadPool.QueueUserWorkItem(callback)
    End Sub

    Private Sub WaitForMessage(ByVal state As Object)
        ' Check your resource here (the polling). 
        ' This blocks until a message is sent to the queue. 
        Dim msg As Message = queue.Receive()
        ' (If you're looking for something specific, you could 
        ' perform a loop and check the Message object here 
        ' before invalidating the cached item.) 
        MyBase.NotifyDependencyChanged(Me, EventArgs.Empty)
    End Sub
End Class