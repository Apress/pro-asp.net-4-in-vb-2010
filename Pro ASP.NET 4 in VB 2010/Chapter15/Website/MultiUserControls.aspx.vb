<PartialCaching(10)>
Partial Class MultiUserControls
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        LoadControls(div1)
        LoadControls(div2)
        LoadControls(div3)
    End Sub

    Private Sub LoadControls(ByVal container As Control)
        Dim list As DropDownList = Nothing
        Dim ph As PlaceHolder = Nothing
        Dim lbl As Label = Nothing

        ' Find the controls for this panel.
        For Each ctrl As Control In container.Controls
            If TypeOf ctrl Is DropDownList Then
                list = DirectCast(ctrl, DropDownList)
            ElseIf TypeOf ctrl Is PlaceHolder Then
                ph = DirectCast(ctrl, PlaceHolder)
            ElseIf TypeOf ctrl Is Label Then
                lbl = DirectCast(ctrl, Label)
            End If
        Next

        'Load the dynamic content into this panel.
        Dim ctrlName As String = list.SelectedItem.Value
        If ctrlName.EndsWith(".ascx") Then
            ph.Controls.Add(Page.LoadControl(ctrlName))
        End If
        lbl.Text = "Loaded..." & ctrlName
    End Sub
End Class
