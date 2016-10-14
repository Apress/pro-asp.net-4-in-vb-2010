Partial Class DynamicButton
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(
       ByVal sender As Object, ByVal e As System.EventArgs
       ) Handles Me.Load
        ' Create a new button object. 
        Dim newButton As New Button()
        ' Assign some text and an ID so you can retrieve it later. 
        newButton.Text = "* Dynamic Button *"
        newButton.ID = "newButton"
        ' Attach an event handler to the Button.Click event. 
        AddHandler newButton.Click, AddressOf Me.Button_Click
        ' Uncomment either the Panel or Placeholder Add method
        ' Add the button to a Panel.
        'Panel1.Controls.Add(newButton)
        ' Add the button to a PlaceHolder. 
        PlaceHolder1.Controls.Add(newButton)
        ' Attach an event handler to the resetButton.Click event.
        Dim resetButton As New Button
        resetButton.Text = "* Reset Label *"
        resetButton.ID = "resetButton"
        AddHandler resetButton.Click, AddressOf Me.reset_Click
        Panel1.Controls.Add(resetButton)
    End Sub
    Protected Sub Button_Click(
        ByVal sender As Object, ByVal e As System.EventArgs)
        Label1.Text = "You clicked the dynamic button."
    End Sub
    Protected Sub removeButton_Click(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles removeButton.Click
        ' Search for the button, no matter what level it's at. 
        Dim foundButton As Button =
            DirectCast(Page.FindControl("newButton"), Button)
        ' Remove the button. 
        If foundButton IsNot Nothing Then
            foundButton.Parent.Controls.Remove(foundButton)
        End If
    End Sub
    Protected Sub reset_Click(
        ByVal sender As Object, ByVal e As System.EventArgs
        )
        Label1.Text = "(No Value)"
    End Sub

    Protected Sub createButton_Click(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles createButton.Click
        ' This triggers a postback where the button is automatically created 
    End Sub
End Class
