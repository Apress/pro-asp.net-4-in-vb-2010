
Partial Class SqlDataSourceSimple
    Inherits System.Web.UI.Page

    Protected Sub sourceEmployees_Selected(
        ByVal sender As Object,
        ByVal e As System.Web.UI.WebControls.SqlDataSourceStatusEventArgs
        ) Handles sourceEmployees.Selected
        If e.Exception IsNot Nothing Then
            ' Mask the error with a generic message (for security purposes.) 
            lblError.Text = "An exception occured performing the query."

            ' Consider the error handled. 
            e.ExceptionHandled = True
        End If
    End Sub
End Class
