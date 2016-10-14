
Partial Class CreateUser
    Inherits System.Web.UI.Page
    Protected Sub RegisterUser_CreatedUser(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles RegisterUser.CreatedUser
        Dim _Age As Short
        Dim _Firstname As String, _Lastname As String

        ' Find the correct wizard step
        Dim wizardStep As WizardStepBase = Nothing
        For i As Integer = 0 To RegisterUser.WizardSteps.Count - 1
            If RegisterUser.WizardSteps(i).ID = "NameStep" Then
                wizardStep = RegisterUser.WizardSteps(i)
                Exit For
            End If
        Next

        If wizardStep IsNot Nothing Then
            _Firstname = DirectCast(
                wizardStep.FindControl("FirstnameText"), TextBox
                ).Text
            _Lastname = DirectCast(
                wizardStep.FindControl("LastnameText"), TextBox
                ).Text
            _Age = Short.Parse(
                DirectCast(wizardStep.FindControl("AgeText"), TextBox
                    ).Text)

            ' Store the information
            ' This is just simple code you need to replace with code
            ' for really storing the information
            System.Diagnostics.Debug.WriteLine(
                String.Format("{0} {1} {2}", _Firstname, _Lastname, _Age)
                )
        End If
    End Sub
End Class
