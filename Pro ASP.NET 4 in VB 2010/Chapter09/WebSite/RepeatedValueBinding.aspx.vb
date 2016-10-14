
Partial Class RepeatedValueBinding
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        If Not Page.IsPostBack Then
            ' create the data source 
            Dim ht As New Hashtable()
            ht.Add("Lasagna", "Key1")
            ht.Add("Spaghetti", "Key2")
            ht.Add("Pizza", "Key3")

            ' set the controls' DataSource property 
            Select1.DataSource = ht
            Select2.DataSource = ht
            Listbox1.DataSource = ht
            DropdownList1.DataSource = ht
            CheckList1.DataSource = ht
            OptionList1.DataSource = ht

            ' bind the data to all the control 
            Page.DataBind()
        End If

    End Sub

    Protected Sub cmdGetSelection_Click(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles cmdGetSelection.Click
        If Select1.SelectedIndex <> -1 Then
            Result.Text &= "- Item selected in Select1: " &
                Select1.Items(Select1.SelectedIndex).Text &
                " - " & Select1.Value & "<br>"
        End If

        If Select2.SelectedIndex <> -1 Then
            Result.Text &= "- Item selected in Select2: " &
                Select2.Items(Select2.SelectedIndex).Text &
                " - " & Select2.Value & "<br>"
        End If

        If Listbox1.SelectedIndex <> -1 Then
            Result.Text &= "- Item selected in Listbox1: " &
                Listbox1.SelectedItem.Text & " - " &
                Listbox1.SelectedItem.Value & "<br>"
        End If

        If DropdownList1.SelectedIndex <> -1 Then
            Result.Text &= "- Item selected in DropdownList1: " &
                DropdownList1.SelectedItem.Text & " - " &
                DropdownList1.SelectedItem.Value & "<br>"
        End If

        If OptionList1.SelectedIndex <> -1 Then
            Result.Text &= "- Item selected in OptionList1: " &
                OptionList1.SelectedItem.Text & " - " &
                OptionList1.SelectedItem.Value & "<br>"
        End If

        If CheckList1.SelectedIndex <> -1 Then
            Result.Text &= "- Items selected in CheckList1: "
            For Each li As ListItem In CheckList1.Items
                If li.Selected Then
                    Result.Text &= li.Text & " - " & li.Value & " "
                End If
            Next
        End If

    End Sub
End Class
