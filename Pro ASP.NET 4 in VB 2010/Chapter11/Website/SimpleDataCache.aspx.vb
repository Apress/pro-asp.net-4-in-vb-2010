Partial Public Class SimpleDataCache
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As EventArgs
        ) Handles Me.Load
        If Me.IsPostBack Then
            lblInfo.Text &= "Page posted back.<br />"
        Else
            lblInfo.Text &= "Page created.<br />"
        End If

        Dim testItem As System.Nullable(Of DateTime) =
            DirectCast(Cache("TestItem"), System.Nullable(Of DateTime))
        If testItem Is Nothing Then
            lblInfo.Text &= "Creating TestItem...<br />"
            testItem = DateTime.Now

            lblInfo.Text &= "Storing TestItem in cache "
            lblInfo.Text &= "for 30 seconds.<br />"
            Cache.Insert(
                "TestItem", testItem, Nothing, DateTime.Now.AddSeconds(30), TimeSpan.Zero
                )
        Else
            lblInfo.Text &= "Retrieving TestItem...<br />"
            lblInfo.Text &= "TestItem is '" & testItem.ToString()
            lblInfo.Text &= "'<br />"
        End If
        lblInfo.Text &= "Time is Now: " & Format(Now, "HH:MM:ss:ff")
        lblInfo.Text &= "<br />-------------<br />"
    End Sub

End Class