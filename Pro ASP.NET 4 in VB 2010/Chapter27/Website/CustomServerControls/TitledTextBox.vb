Imports System.ComponentModel
Imports System.Web.UI.WebControls
Imports System.Web.UI
Namespace CustomServerControlsLibrary
    <Designer(GetType(TitledTextBoxDesigner))> _
    Public Class TitledTextBox
        Inherits CompositeControl
        Public Sub New()
            MyBase.New()
            Title = ""
            Text = ""
        End Sub

        ' Track the constituent controls with member variables 
        ' so they are accessible in all methods. 
        Protected label As Label
        Protected textBox As TextBox

        Public Property Title() As String
            Get
                Return DirectCast(ViewState("Title"), String)
            End Get
            Set(ByVal value As String)
                ViewState("Title") = value
                'If Me.ChildControlsCreated Then
                '    Me.RecreateChildControls()
                'End If
            End Set
        End Property

        Public Property Text() As String
            Get
                Return DirectCast(ViewState("Text"), String)
            End Get
            Set(ByVal value As String)
                ViewState("Text") = value
                'If Me.ChildControlsCreated Then
                '    Me.RecreateChildControls()
                'End If
            End Set
        End Property

        Protected Overloads Overrides Sub CreateChildControls()
            ' Add the label. 
            label = New Label()
            label.EnableViewState = False
            label.Text = Title
            Controls.Add(label)

            ' Add a space. 
            Controls.Add(New LiteralControl("&nbsp;&nbsp;"))

            ' Add the text box. 
            textBox = New TextBox()
            textBox.EnableViewState = False
            textBox.Text = Text
            AddHandler textBox.TextChanged, AddressOf OnTextChanged
            Controls.Add(textBox)
        End Sub

        Public Event TextChanged As EventHandler

        Protected Overridable Sub OnTextChanged(
            ByVal sender As Object, ByVal e As EventArgs
            )
            RaiseEvent TextChanged(Me, e)
        End Sub










    End Class
End Namespace