Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports CustomerTableAdapters
Imports System.Data

Namespace Apress.WebParts.Samples
    Public Class CustomerNotesPart
        Inherits WebPart
        Implements IWebEditable, INotesContract

        Private Function IWebEditable_CreateEditorParts() _
            As EditorPartCollection _
            Implements IWebEditable.CreateEditorParts

            ' Create editor parts
            Dim Editors As New List(Of EditorPart)()
            Dim Editor As New CustomerEditor()
            Editor.ID = Convert.ToString(Me.ID) & "_CustomerEditor_1"
            Editors.Add(Editor)
            Return New EditorPartCollection(Editors)
        End Function

        Private ReadOnly Property IWebEditable_WebBrowsableObject() _
            As Object Implements IWebEditable.WebBrowsableObject
            Get
                Return Me
            End Get
        End Property

        Public Property Notes() As String _
            Implements INotesContract.Notes
            Get
                EnsureChildControls()
                If CustomerNotesGrid.SelectedIndex >= 0 Then
                    Dim RowIndex As Integer =
                        CustomerNotesGrid.SelectedRow.DataItemIndex

                    Dim dt As DataTable =
                        DirectCast(CustomerNotesGrid.DataSource, DataTable)
                    Return dt.Rows(RowIndex)("NoteContent").ToString()
                Else
                    Return (String.Empty)
                End If
            End Get
            Set(ByVal value As String)
                EnsureChildControls()
                If CustomerNotesGrid.SelectedIndex >= 0 Then
                    ' Retrieve the selected row and upate the value
                    Dim RowIndex As Integer =
                        CustomerNotesGrid.SelectedRow.DataItemIndex

                    Dim dt As DataTable =
                        DirectCast(CustomerNotesGrid.DataSource, DataTable)
                    dt.Rows(RowIndex)("NoteContent") = value

                    ' Write changes back to the database                    
                    Dim adpater As New CustomerNotesTableAdapter()
                    adpater.Update(dt.Rows(RowIndex))

                    ' Update the grids content
                    BindGrid()
                End If
            End Set
        End Property
        Public ReadOnly Property SubmittedDate() As Date _
            Implements INotesContract.SubmittedDate
            Get
                EnsureChildControls()

                If CustomerNotesGrid.SelectedIndex >= 0 Then
                    Dim RowIndex As Integer =
                        CustomerNotesGrid.SelectedRow.DataItemIndex
                    Dim dt As DataTable =
                        DirectCast(CustomerNotesGrid.DataSource, DataTable)
                    Return DirectCast(dt.Rows(RowIndex)("NoteDate"), DateTime)
                Else
                    Return DateTime.MinValue
                End If
            End Get
        End Property

        <ConnectionProvider("Notes Text")> _
        Public Function GetNotesCommunicationPoint() As INotesContract
            Return DirectCast(Me, INotesContract)
        End Function

        Public Sub New()
            AddHandler Me.Init, AddressOf CustomerNotesPart_Init
            AddHandler Me.Load, AddressOf CustomerNotesPart_Load
            AddHandler Me.PreRender, AddressOf CustomerNotesPart_PreRender
        End Sub

        Private Sub CustomerNotesPart_Load(
            ByVal sender As Object, ByVal e As EventArgs
            )
            ' Initialize web part properties
            Me.Title = "Customer Notes"
            Me.TitleIconImageUrl = "NotesImage.jpg"
        End Sub
        Private Sub CustomerNotesPart_Init(
            ByVal sender As Object, ByVal e As EventArgs
            )
            ' Don't try to load data in Design mode
            If Not Me.DesignMode Then
                BindGrid()
            End If
        End Sub

        Private Sub BindGrid()
            EnsureChildControls()
            Dim adapter As New CustomerNotesTableAdapter()
            If Customer.Equals(String.Empty) Then
                CustomerNotesGrid.DataSource =
                    adapter.GetDataAll()
            Else
                CustomerNotesGrid.DataSource =
                    adapter.GetDataByCustomer(Customer)
            End If
        End Sub

        Private Sub CustomerNotesPart_PreRender(
            ByVal sender As Object, ByVal e As EventArgs
            )
            If Customer.Equals(String.Empty) Then
                InsertNewNote.Enabled = False
            Else
                InsertNewNote.Enabled = True
            End If
            CustomerNotesGrid.DataBind()
        End Sub

        Public Overrides Property AllowClose() As Boolean
            Get
                Return False
            End Get
            Set(ByVal value As Boolean)
                ' Don't want this to be set
            End Set
        End Property

        Private _Customer As String = String.Empty

        <WebBrowsable(True)>
        <Personalizable(PersonalizationScope.User)>
        Public Property Customer() As String
            Get
                Return _Customer
            End Get
            Set(ByVal value As String)
                _Customer = value

                If Not Me.DesignMode Then
                    EnsureChildControls()
                    CustomerNotesGrid.PageIndex = 0
                    CustomerNotesGrid.SelectedIndex = -1
                    BindGrid()
                End If
            End Set
        End Property

        Private NewNoteText As TextBox
        Private InsertNewNote As Button
        Private CustomerNotesGrid As GridView

        Protected Overrides Sub CreateChildControls()
            ' Create a text box for adding new notes
            NewNoteText = New TextBox()

            ' Create a button for submitting new notes
            InsertNewNote = New Button()
            InsertNewNote.Text = "Insert ..."
            AddHandler InsertNewNote.Click,
                AddressOf InsertNewNote_Click

            ' Create the grid for displaying customer notes
            CustomerNotesGrid = New GridView()
            CustomerNotesGrid.HeaderStyle.BackColor =
                System.Drawing.Color.LightBlue
            CustomerNotesGrid.RowStyle.BackColor =
                System.Drawing.Color.LightGreen
            CustomerNotesGrid.AlternatingRowStyle.BackColor =
                System.Drawing.Color.LightGray
            CustomerNotesGrid.AllowPaging = True
            CustomerNotesGrid.PageSize = 5
            AddHandler CustomerNotesGrid.PageIndexChanging,
                AddressOf CustomerNotesGrid_PageIndexChanging

            ' Add all controls to the controls collection
            Controls.Add(NewNoteText)
            Controls.Add(InsertNewNote)
            Controls.Add(CustomerNotesGrid)
        End Sub

        Private Sub CustomerNotesGrid_PageIndexChanging(
            ByVal sender As Object, ByVal e As GridViewPageEventArgs
            )
            CustomerNotesGrid.PageIndex = e.NewPageIndex
        End Sub

        Private Sub InsertNewNote_Click(
            ByVal sender As Object, ByVal e As EventArgs
            )
            Dim adapter As New CustomerNotesTableAdapter()

            ' Note that the NoteID is an identity column in the
            ' database and therefore is not required as a parameter
            ' in the method generated by the DataSet!
            adapter.Insert(Customer, DateTime.Now, NewNoteText.Text)

            ' Refresh the Grid with the new row as well
            BindGrid()
        End Sub

        Protected Overrides Sub RenderContents(
            ByVal writer As HtmlTextWriter
            )
            writer.Write("<table>")

            writer.Write("<tr>")
            writer.Write("<td>")
            NewNoteText.RenderControl(writer)
            InsertNewNote.RenderControl(writer)
            writer.Write("")
            writer.Write("</tr>")

            writer.Write("<tr>")
            writer.Write("<td>")
            CustomerNotesGrid.RenderControl(writer)
            writer.Write("")
            writer.Write("</tr>")

            writer.Write("")
        End Sub
    End Class
End Namespace
