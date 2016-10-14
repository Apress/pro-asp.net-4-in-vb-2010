
Partial Class ObjectDataSourceInsert
    Inherits System.Web.UI.Page


  
    Protected Sub sourceEmployees_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles sourceEmployees.Inserted
        If e.Exception Is Nothing Then
            lblConfirmation.Text = "Inserted record " + e.ReturnValue.ToString() + "."
        Else
            lblConfirmation.Text = "Error - Did you supply all the required values?"
            e.ExceptionHandled = True
        End If
    End Sub

    
End Class
