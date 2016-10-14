Imports System.Collections.Generic
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Namespace Apress.ExternalWebParts
    Public Class ExternalPart
        Inherits WebPart
        Public Sub New()
            Me.ExportMode = WebPartExportMode.All
        End Sub

        Private TestLabel As Label
        Private TestTextBox As TextBox
        Private TestButton As Button
        Private TestList As ListBox

        Protected Overrides Sub CreateChildControls()
            TestLabel = New Label()
            TestTextBox = New TextBox()
            TestButton = New Button()
            TestList = New ListBox()

            Controls.Add(TestLabel)
            Controls.Add(TestTextBox)
            Controls.Add(TestButton)
            Controls.Add(TestList)

            AddHandler TestButton.Click, AddressOf TestButton_Click
        End Sub

        Private Sub TestButton_Click(ByVal sender As Object, ByVal e As EventArgs)
            TestList.Items.Add(TestTextBox.Text)
        End Sub

        Public Overrides Sub RenderControl(ByVal writer As HtmlTextWriter)
            TestLabel.Text = "Enter value:"
            TestLabel.RenderControl(writer)
            writer.WriteBreak()
            TestTextBox.RenderControl(writer)
            writer.WriteBreak()
            TestButton.Text = "Add"
            TestButton.RenderControl(writer)
            writer.WriteBreak()
            TestList.RenderControl(writer)
        End Sub
    End Class

End Namespace
