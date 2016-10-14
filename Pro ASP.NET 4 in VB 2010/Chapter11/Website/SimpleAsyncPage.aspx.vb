Imports System.Diagnostics

Partial Public Class SimpleAsyncPage
    Inherits System.Web.UI.Page
    Private pageID As String

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As EventArgs
        ) Handles Me.Load
        ' Get a random identifier for page. 
        Dim rnd As New Random()
        pageID = [String].Format("#{0} ", rnd.[Next](0, 100))
        Page.AddOnPreRenderCompleteAsync(
            New BeginEventHandler(AddressOf BeginTask),
            New EndEventHandler(AddressOf EndTask)
            )
        Debug.WriteLine(pageID & "Page_Load ended: " &
            System.Threading.Thread.CurrentThread.ManagedThreadId)
    End Sub

    Protected Sub Page_UnLoad(
        ByVal sender As Object, ByVal e As EventArgs
        )
        Debug.WriteLine(pageID & "Page_UnLoad: " &
            System.Threading.Thread.CurrentThread.ManagedThreadId)
    End Sub

    Private start As System.Threading.ThreadStart

    Private Function BeginTask(
        ByVal sender As Object,
        ByVal e As EventArgs,
        ByVal cb As AsyncCallback,
        ByVal state As Object
        ) As IAsyncResult
        Debug.WriteLine(pageID & "Begin Task: " &
            System.Threading.Thread.CurrentThread.ManagedThreadId)

        start = New System.Threading.ThreadStart(AddressOf DoSomethingSlow)
        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(10))
        Return start.BeginInvoke(cb, state)
    End Function

    Private Sub DoSomethingSlow()
        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(30))
        Debug.WriteLine(pageID & "In Task: " &
            System.Threading.Thread.CurrentThread.ManagedThreadId)
    End Sub

    Private Sub EndTask(ByVal ar As IAsyncResult)
        Debug.WriteLine(pageID & "End Task: " &
            System.Threading.Thread.CurrentThread.ManagedThreadId)
        start.EndInvoke(ar)
    End Sub
End Class