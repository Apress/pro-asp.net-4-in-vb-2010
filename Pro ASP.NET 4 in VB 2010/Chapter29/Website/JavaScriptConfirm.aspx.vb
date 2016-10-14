
Partial Class JavaScriptConfirm
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        Dim script As String =
            "<script type='text/javascript' language='JavaScript'> " &
            "function confirmSubmit() {var doc = document.forms[0]; " &
            "var msg = 'Are you sure you want to submit this data?'; " &
            "return confirm(msg);} </script>"

        Page.ClientScript.RegisterClientScriptBlock(
            Me.[GetType](),
            "Confirm",
            script
            )

        form1.Attributes.Add("onsubmit", "return confirmSubmit();")
    End Sub
    Protected Sub cmdSubmit_ServerClick(
        ByVal sender As Object, ByVal e As EventArgs)
        Response.Write("Page Submitted")
    End Sub
End Class
