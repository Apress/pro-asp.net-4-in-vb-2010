Partial Public Class ProgrammaticOutputCaching
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As EventArgs
        ) Handles Me.Load
        ' Cache this page on the server. 
        Response.Cache.SetCacheability(HttpCacheability.[Public])

        ' Use the cached copy of this page for the next 60 seconds. 
        Response.Cache.SetExpires(DateTime.Now.AddSeconds(10))
        'Response.Cache.VaryByParams.IgnoreParams = true; 

        ' This additional line ensures that the browser can't 
        ' invalidate the page when the user clicks the Refresh button 
        ' (which some rogue browsers attempt to do). 
        Response.Cache.SetValidUntilExpires(True)

        lblDate.Text = "The time is now:<br>" + DateTime.Now.ToString()
    End Sub
End Class