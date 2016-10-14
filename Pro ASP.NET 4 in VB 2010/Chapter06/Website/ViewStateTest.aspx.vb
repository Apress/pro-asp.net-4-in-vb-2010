
Partial Class ViewStateTest
    Inherits System.Web.UI.Page
    Protected Sub cmdSave_Click(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles cmdSave.Click
        ' Save the current text. 
        SaveAllText(Page.Controls, True)
    End Sub
    Private Sub SaveAllText(
        ByVal controls As ControlCollection, ByVal saveNested As Boolean
        )
        For Each control As Control In controls
            If TypeOf control Is TextBox Then
                ' Store the text using the unique control ID. 
                ViewState(control.ID) =
                    DirectCast(control, TextBox).Text
            End If

            If (control.Controls IsNot Nothing) AndAlso saveNested Then
                SaveAllText(control.Controls, True)
            End If
        Next
    End Sub
    Protected Sub cmdRestore_Click(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles cmdRestore.Click
        ' Retrieve the last saved text. 
        RestoreAllText(Page.Controls, True)
    End Sub
    Private Sub RestoreAllText(
        ByVal controls As ControlCollection, ByVal saveNested As Boolean
        )
        For Each control As Control In controls
            If TypeOf control Is TextBox Then
                If ViewState(control.ID) IsNot Nothing Then
                    DirectCast(control, TextBox).Text =
                        DirectCast(ViewState(control.ID), String)
                End If
            End If

            If (control.Controls IsNot Nothing) AndAlso saveNested Then
                RestoreAllText(control.Controls, True)
            End If
        Next
    End Sub
End Class
