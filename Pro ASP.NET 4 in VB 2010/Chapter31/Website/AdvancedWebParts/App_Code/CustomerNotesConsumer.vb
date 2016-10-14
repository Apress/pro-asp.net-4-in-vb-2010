
Namespace Apress.WebParts.Samples
Public Class CustomerNotesConsumer
        Inherits WebPart

        Private NotesTextLabel As Label
        Private NotesContentText As TextBox
        Private UpdateNotesContent As Button

        Protected Overrides Sub CreateChildControls()
            NotesTextLabel = New Label()
            NotesTextLabel.Text = DateTime.Now.ToString()

            NotesContentText = New TextBox()
            NotesContentText.TextMode = TextBoxMode.MultiLine
            NotesContentText.Rows = 5
            NotesContentText.Columns = 20

            UpdateNotesContent = New Button()
            UpdateNotesContent.Text = "Update"
            AddHandler UpdateNotesContent.Click,
                AddressOf UpdateNotesContent_Click

            Controls.Add(NotesTextLabel)
            Controls.Add(NotesContentText)
            Controls.Add(UpdateNotesContent)
        End Sub

        Private UpdateFormTextBox As Boolean = False

        Private Sub UpdateNotesContent_Click(
            ByVal sender As Object, ByVal e As EventArgs
            )
            UpdateFormTextBox = True
        End Sub

        Protected Overrides Sub OnPreRender(ByVal e As EventArgs)
            ' Don't forget to call base implementation
            MyBase.OnPreRender(e)

            ' Initialize control
            If _NotesProvider IsNot Nothing Then
                If UpdateFormTextBox Then
                    _NotesProvider.Notes =
                        NotesContentText.Text
                Else
                    NotesContentText.Text =
                        _NotesProvider.Notes
                End If
                Me.Title = "Update Customer Notes"
                NotesTextLabel.Text = _NotesProvider.SubmittedDate.ToShortDateString()
            End If
        End Sub

        Private _NotesProvider As INotesContract = Nothing

        <ConnectionConsumer("Customer Notes")> _
        Public Sub InitializeProvider(ByVal provider As INotesContract)
            _NotesProvider = provider
            If UpdateFormTextBox Then
                _NotesProvider.Notes =
                    NotesContentText.Text
            End If
        End Sub

        ' Custom Verbs
        Public Overrides ReadOnly Property Verbs() As WebPartVerbCollection
            Get
                Dim RefreshVerb As New WebPartVerb("Refresh",
                    New WebPartEventHandler(AddressOf RefreshVerb_Click))
                RefreshVerb.Text = "Refresh Now"
                Dim NewVerbs As WebPartVerb() = New WebPartVerb() {RefreshVerb}

                Dim vc As New WebPartVerbCollection(MyBase.Verbs, NewVerbs)
                Return vc
            End Get
        End Property

        Protected Sub RefreshVerb_Click(ByVal sender As Object, ByVal e As WebPartEventArgs)
            UpdateFormTextBox = True
        End Sub

    End Class

End Namespace
