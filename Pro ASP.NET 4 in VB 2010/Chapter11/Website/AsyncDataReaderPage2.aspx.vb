Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports System.Data

Partial Public Class AsyncDataReaderPage2
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As EventArgs
        ) Handles Me.Load
        Dim task As New PageAsyncTask(
            AddressOf BeginTask,
            AddressOf EndTask, Nothing, Nothing
        )
        Page.RegisterAsyncTask(task)
    End Sub

    ' The ADO.NET objects need to be accessible in several different 
    ' event handlers, so they must be declared as member variables. 
    Private con As SqlConnection
    Private cmd As SqlCommand
    Private reader As SqlDataReader

    Private Function BeginTask(
        ByVal sender As Object,
        ByVal e As EventArgs,
        ByVal cb As AsyncCallback,
        ByVal state As Object
        ) As IAsyncResult
        ' Create the command. 
        Dim connectionString As String =
            WebConfigurationManager.ConnectionStrings("NorthwindAsync").ConnectionString
        con = New SqlConnection(connectionString)
        cmd = New SqlCommand("SELECT * FROM Employees", con)

        ' Attempt to open the connection. 
        ' This part is not asynchronous yet. 
        Try
            con.Open()
        Catch err As Exception
            Return New CompletedSyncResult(err, cb, state)
            con.Close()
        End Try

        ' Run the query asynchronously. 
        ' This method returns immediately, and provides ASP.NET 
        ' with the IAsyncResult object it needs to track progress. 
        Return cmd.BeginExecuteReader(cb, state)
    End Function

    ' This method fires when IAsyncResult indicates the task is complete. 
    Private Sub EndTask(
        ByVal ar As IAsyncResult
        )

        If TypeOf ar Is CompletedSyncResult Then
            lblError.Text = "A connection error occurred.<br />"
            lblError.Text &=
                 DirectCast(ar, CompletedSyncResult).OperationException.Message
            Return
        End If

        ' You can now retrieve the DataReader.
        Try
            reader = cmd.EndExecuteReader(ar)
        Catch ex As SqlException
            lblError.Text = "The query failed."
        End Try
    End Sub

    ' Perform the data binding in the next stage of the page lifecycle. 
    Protected Sub Page_PreRenderComplete(
        ByVal sender As Object, ByVal e As EventArgs
        ) Handles Me.PreRenderComplete
        grid.DataSource = reader
        grid.DataBind()
        con.Close()
    End Sub

    ' Make sure the connection is closed in the event of an error. 
    Public Overrides Sub Dispose()
        If con IsNot Nothing Then
            con.Close()
        End If
        MyBase.Dispose()
    End Sub


    Public Sub Timeout(ByVal result As IAsyncResult)
        If con IsNot Nothing AndAlso
            con.State <> ConnectionState.Closed Then
            con.Close()
        End If
        lblError.Text = "Task timed out."
    End Sub
End Class