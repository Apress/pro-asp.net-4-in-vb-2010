Imports CustomerTableAdapters
Imports Apress.WebParts.Samples

Public Class CustomerEditor
    Inherits EditorPart

    Public Sub New()
        AddHandler Me.Init, AddressOf CustomerEditor_Init
    End Sub

    Public Overrides Sub SyncChanges()
        ' Make sure that all controls are available
        EnsureChildControls()

        ' Get the property from the WebPart
        Dim part As CustomerNotesPart =
            DirectCast(WebPartToEdit, CustomerNotesPart)
        If part IsNot Nothing Then
            CustomersList.SelectedValue = part.Customer
        End If
    End Sub


    Public Overrides Function ApplyChanges() As Boolean
        ' Make sure that all controls are available
        EnsureChildControls()

        ' Get the property from the WebPart
        Dim part As CustomerNotesPart =
            DirectCast(WebPartToEdit, CustomerNotesPart)
        If part IsNot Nothing Then
            If CustomersList.SelectedIndex >= 0 Then
                part.Customer = CustomersList.SelectedValue
            Else
                part.Customer = String.Empty
            End If
        Else
            Return False
        End If

        Return True
    End Function

    Private CustomersList As ListBox

    Protected Overrides Sub CreateChildControls()
        CustomersList = New ListBox()
        CustomersList.Rows = 4
        Controls.Add(CustomersList)
    End Sub

    Private Sub CustomerEditor_Init(
        ByVal sender As Object, ByVal e As EventArgs
        )
        EnsureChildControls()

        ' Adapter requires importing the CustomersSetTableAdapters namespace
        Dim adapter As New CustomerTableAdapter()
        CustomersList.DataSource = adapter.GetData()
        CustomersList.DataTextField = "CompanyName"
        CustomersList.DataValueField = "CustomerID"
        CustomersList.DataBind()

        ' Add an "empty" item to the list at the first position
        ' so that the user has the option to select "no specific" customer
        ' to be displayed in the results list. That means when the user
        ' selects this empty entry, all customers should be displayed in
        ' the GridView for the customers
        CustomersList.Items.Insert(0, "")
    End Sub

End Class

