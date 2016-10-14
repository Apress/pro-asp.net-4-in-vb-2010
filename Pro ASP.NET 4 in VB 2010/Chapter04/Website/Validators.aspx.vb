Partial Class Validators
    Inherits System.Web.UI.Page

    Protected Sub Submit_Click(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Submit.Click
        If Page.IsValid Then
            Result.Text =
                "Thanks for sending your data"
        Else
            Result.Text =
                "There are some errors, please correct them and re-send the form."
        End If

    End Sub
    Protected Sub OptionsChanged(
        ByVal sender As Object, ByVal e As EventArgs)
        ' Examine all the validators on the back. 
        For Each validator As BaseValidator In Page.Validators
            ' Turn the validators on or off, depending on the value 
            ' of the "Validators enabled" check box (chkEnableValidators). 
            validator.Enabled = chkEnableValidators.Checked

            ' Turn client-side validation on or off, depending on the value 
            ' of the "Client-side validation enabled" check box 
            ' (chkEnableClientSide). 
            validator.EnableClientScript = chkEnableClientSide.Checked
        Next

        ' Configure the validation summary based on the final two check boxes. 
        Summary.ShowMessageBox = chkShowMsgBox.Checked
        Summary.ShowSummary = chkShowSummary.Checked
    End Sub

    Protected Sub ValidateEmpID2_ServerValidate(
        ByVal source As Object,
        ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs
        ) Handles ValidateEmpID2.ServerValidate
        Try
            args.IsValid = (Integer.Parse(args.Value) Mod 5 = 0)
        Catch
            args.IsValid = False
        End Try
    End Sub

    Protected Sub Button1_Click(
    ByVal sender As Object, ByVal e As System.EventArgs
    ) Handles Button1.Click
        ' Validate the page.
        Me.Validate()

        If Not Me.IsValid Then
            Dim errorMessage As String = "<b>Mistakes found:</b><br />"
            ' Create a variable to represent the input control.
            Dim ctrlInput As TextBox
            ' Search through the validation controls.
            For Each ctrl As BaseValidator In Me.Validators
                If Not ctrl.IsValid Then
                    errorMessage &= ctrl.ErrorMessage & "<br />"
                    ctrlInput =
                        DirectCast(Me.FindControl(ctrl.ControlToValidate), TextBox)
                    errorMessage &= " * Problem is with this input: "
                    errorMessage &= ctrlInput.Text & "<br />"
                End If
            Next
            lblMessage.Text = errorMessage
        End If
    End Sub

End Class
