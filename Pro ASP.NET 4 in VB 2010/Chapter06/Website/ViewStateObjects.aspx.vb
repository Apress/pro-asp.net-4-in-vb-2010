Imports System.Collections.Generic
Partial Class ViewStateObjects
    Inherits System.Web.UI.Page

    Protected Sub cmdSave_Click(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles cmdSave.Click
        ' Put the text in the Dictionary. 
        Dim textToSave = New Dictionary(Of String, String)()
        SaveAllText(Page.Controls, textToSave, True)

        ' Store the entire collection in view state. 
        ViewState("ControlText") = textToSave

    End Sub
    Private Sub SaveAllText(
        ByVal controls As ControlCollection,
        ByVal textToSave As Dictionary(Of String, String),
        ByVal saveNested As Boolean
        )
        For Each control As Control In controls
            If TypeOf control Is TextBox Then
                ' Add the text to the Dictionary. 
                textToSave.Add(control.ID, DirectCast(control, TextBox).Text)
            End If
            If (control.Controls IsNot Nothing) AndAlso saveNested Then
                SaveAllText(control.Controls, textToSave, True)
            End If
        Next
    End Sub

    Protected Sub cmdRestore_Click(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles cmdRestore.Click
        If ViewState("ControlText") IsNot Nothing Then
            ' Retrieve the Dictionary. 
            Dim savedText =
                DirectCast(ViewState("ControlText"), Dictionary(Of String, String))

            ' Display all the text by looping through the Dictionary. 
            lblResults.Text = ""
            For Each item As KeyValuePair(Of String, String) In savedText
                lblResults.Text &=
                DirectCast(item.Key, String) & " = " &
                DirectCast(item.Value, String) & "<br>"
            Next
        End If
    End Sub
End Class
