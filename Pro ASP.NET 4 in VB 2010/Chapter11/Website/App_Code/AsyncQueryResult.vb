Imports System.Data.SqlClient
Imports System.Data
Imports System.Threading

Public Class AsyncQueryResult
    Implements IAsyncResult
    Private m_operationException As Exception
    Public ReadOnly Property OperationException() As Exception
        Get
            Return m_operationException
        End Get
    End Property

    Private resultValue As DataTable
    Public ReadOnly Property Result() As DataTable
        Get
            If OperationException IsNot Nothing Then
                Throw OperationException
            End If

            If asyncQueryResult IsNot Nothing Then
                Try
                    Dim reader As SqlDataReader =
                        cmdQuery.EndExecuteReader(asyncQueryResult)
                    resultValue = New DataTable("Employees")
                    resultValue.Load(reader)
                    reader.Close()
                Finally
                    cmdQuery.Connection.Close()
                End Try
            End If
            Return resultValue
        End Get
    End Property

    ' Use these objects if the task is being performed 
    ' asynchronously with BeginExecuteReader(). 
    Private cmdQuery As SqlCommand
    Private asyncQueryResult As IAsyncResult
    Public asyncCallback As AsyncCallback
    ' Use in case of true asynchronous task with BeginExecuteReader. 
    Public Sub New(ByVal readerCommand As SqlCommand, ByVal asyncCall As AsyncCallback, ByVal asyncState As Object)
        state = asyncState
        cmdQuery = readerCommand
        Me.asyncCallback = asyncCall

        Try
            cmdQuery.Connection.Open()

            ' Hook to the BeginExecuteReader() callback, 
            ' so you can pass it along to the caller. 
            asyncQueryResult = cmdQuery.BeginExecuteReader(New System.AsyncCallback(AddressOf RaiseCallback), Nothing)

        Catch err As Exception
            ' Store the error and re-raise it when the 
            ' result is read. 
            cmdQuery.Connection.Close()
            asyncQueryResult = Nothing
            cmdQuery = Nothing
            m_operationException = err
        End Try
    End Sub

    Private Sub RaiseCallback(ByVal ar As IAsyncResult)
        If asyncCallback <> Nothing Then
            asyncCallback(Me)
        End If
    End Sub

    ' Use in the case of data being ready immediately. 
    Public Sub New(ByVal result As DataTable, ByVal asyncCall As AsyncCallback, ByVal asyncState As Object)
        state = asyncState
        Me.resultValue = result
        asyncCall(Me)
    End Sub

    ' Use in the case of error. 
    Public Sub New(ByVal operationException As Exception, ByVal asyncCal As AsyncCallback, ByVal asyncState As Object)
        state = asyncState
        Me.m_operationException = operationException

        ' Code that triggers the callback, if it's used. 
        asyncCal(Me)
    End Sub

    Private state As Object
    Private ReadOnly Property AsyncState() As Object Implements IAsyncResult.AsyncState
        Get
            Return state
        End Get
    End Property

    Private ReadOnly Property AsyncWaitHandle() As WaitHandle Implements IAsyncResult.AsyncWaitHandle
        Get
            If asyncQueryResult IsNot Nothing Then
                Return asyncQueryResult.AsyncWaitHandle
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private ReadOnly Property CompletedSynchronously() As Boolean Implements IAsyncResult.CompletedSynchronously
        Get
            If asyncQueryResult IsNot Nothing Then
                Return asyncQueryResult.CompletedSynchronously
            Else
                Return True
            End If
        End Get
    End Property

    Private ReadOnly Property IsCompleted() As Boolean Implements IAsyncResult.IsCompleted
        Get
            If asyncQueryResult IsNot Nothing Then
                Return asyncQueryResult.IsCompleted
            Else
                Return True
            End If
        End Get
    End Property
End Class