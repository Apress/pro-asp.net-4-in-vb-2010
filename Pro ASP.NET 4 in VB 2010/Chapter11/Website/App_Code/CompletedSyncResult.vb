Imports System.Data
Imports System.Threading
Public Class CompletedSyncResult
    Implements IAsyncResult
    ' Track the offending error.
    Public Property OperationException() As Exception
    ' Maintain all the details for the asynchronous operation.
    Public Sub New(
        ByVal theOperationException As Exception,
        ByVal asyncCallback As AsyncCallback,
        ByVal asyncState As Object
        )
        state = asyncState
        OperationException = theOperationException
        ' Code that triggers the callback, if it's used.
        If asyncCallback IsNot Nothing Then
            asyncCallback(Me)
        End If
    End Sub

    ' Implement the IAsyncState interface.
    ' Use hard-coded values that indicate the task is always considered complete.
    Private state As Object
    Private ReadOnly Property IAsyncResult_AsyncState() As Object _
        Implements IAsyncResult.AsyncState
        Get
            Return state
        End Get
    End Property

    Private ReadOnly Property IAsyncResult_AsyncWaitHandle() As WaitHandle _
        Implements IAsyncResult.AsyncWaitHandle
        Get
            Return Nothing
        End Get
    End Property

    Private ReadOnly Property IAsyncResult_CompletedSynchronously() As Boolean _
        Implements IAsyncResult.CompletedSynchronously
        Get
            Return True
        End Get
    End Property

    Private ReadOnly Property IAsyncResult_IsCompleted() As Boolean _
        Implements IAsyncResult.IsCompleted
        Get
            Return True
        End Get
    End Property
End Class
