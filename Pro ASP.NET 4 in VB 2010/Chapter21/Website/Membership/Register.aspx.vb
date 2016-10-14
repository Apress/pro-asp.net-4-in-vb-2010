Imports System.Diagnostics

Partial Class Register
    Inherits System.Web.UI.Page

    Private _Age As Short
    Private _Firstname, _Lastname As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.IsPostBack Then
            _Age = -1
            _Firstname = _Lastname = String.Empty
        End If
    End Sub

    Protected Sub RegisterUser_CreatedUser(ByVal sender As Object, ByVal e As System.EventArgs) Handles RegisterUser.CreatedUser
        ' Find the correct wizard step
        Dim steps As WizardStepBase = Nothing
        For i As Integer = 0 To i < RegisterUser.WizardSteps.Count
            If RegisterUser.WizardSteps(i).ID = "NameStep" Then
                steps = RegisterUser.WizardSteps(i)
                Exit For
            End If
        Next

        If steps IsNot Nothing Then
            _Firstname = DirectCast(steps.FindControl("FirstnameText"), TextBox).Text
            _Lastname = DirectCast(steps.FindControl("LastnameText"), TextBox).Text
            _Age = Short.Parse(DirectCast(steps.FindControl("AgeTExt"), TextBox).Text)

            ' Store the information
            Debug.WriteLine(String.Format("{0} {1} {2}", _Firstname, _Lastname, _Age))
        End If
    End Sub
End Class
