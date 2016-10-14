Imports System.ComponentModel
Imports System.Drawing.Design
Imports System.Drawing
Imports System.Windows.Forms.Design
Imports System.Web.UI.WebControls

Namespace CustomServerControlsLibrary
    Public Class ColorTypeEditor
        Inherits UITypeEditor
        Public Overrides Function GetEditStyle(ByVal context As ITypeDescriptorContext) As System.Drawing.Design.UITypeEditorEditStyle
            ' This editor appears when you click a drop-down arrow.
            Return UITypeEditorEditStyle.DropDown
        End Function
        Public Overloads Overrides Function EditValue(ByVal context As ITypeDescriptorContext, ByVal provider As IServiceProvider, ByVal value As Object) As Object
            Dim srv As IWindowsFormsEditorService = Nothing

            ' Get the editor service from the provider, 
            ' which you need to perform the drop-down. 
            If provider IsNot Nothing Then
                srv = DirectCast(provider.GetService(GetType(IWindowsFormsEditorService)), IWindowsFormsEditorService)
            End If

            If srv IsNot Nothing Then
                ' Create an instance of the custom Windows Forms 
                ' color-picking control. 
                ' Pass the current value of the color. 
                Dim editor As New ColorTypeEditorControl(DirectCast(value, System.Drawing.Color), TryCast(context.Instance, WebControl))

                ' Show the control. 
                srv.DropDownControl(editor)

                ' Return the selected color information. 
                Return editor.SelectedColor
            Else
                ' Return the current value. 
                Return value
            End If
        End Function


        Public Overloads Overrides Function GetPaintValueSupported(ByVal context As ITypeDescriptorContext) As Boolean
            ' This type editor will generate a color box thumbnail. 
            Return True
        End Function


        Public Overloads Overrides Sub PaintValue(ByVal e As PaintValueEventArgs)
            Dim control As WebControl = TryCast(e.Context.Instance, WebControl)

            ' Fills the left rectangle with a color. 
            e.Graphics.FillRegion(New SolidBrush(control.BackColor), New Region(e.Bounds))
        End Sub

    End Class
End Namespace
