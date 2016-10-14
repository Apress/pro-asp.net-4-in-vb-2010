Imports System.Web.UI.WebControls
Imports System.Web.UI
Imports System.IO
Namespace DynamicControls
    Public Class DynamicPanel
        Inherits Panel
        Implements ICallbackEventHandler
        Implements ICallbackContainer
        Protected Overrides Sub OnInit(ByVal e As EventArgs)
            MyBase.OnInit(e)
            Dim script As String =
                "<script type='text/javascript'>" & vbNewLine &
                "       function RefreshPanel(result, context)" &
                vbNewLine & "       {" & vbNewLine &
                "         if (result != '')" & vbNewLine &
                "         {" & vbNewLine &
                "           var separator = result.indexOf('_'); " &
                vbNewLine &
                "           var elementName = result.substr(0, separator);" &
                vbNewLine &
                "           var panel = document.getElementById(elementName);" &
                vbNewLine &
                "           panel.innerHTML = result.substr(separator+1);" &
                vbNewLine & "         }" & vbNewLine & "       }" & vbNewLine &
                "    </script>"

            Page.ClientScript.RegisterClientScriptBlock(
                Me.[GetType](),
                "RefreshPanel",
                script
                )
        End Sub

        Public Event Refreshing As EventHandler

        Public Sub RaiseCallbackEvent(ByVal eventArgument As String) _
            Implements ICallbackEventHandler.RaiseCallbackEvent
            ' Fire an event to notify the client a refresh has been requested.
            RaiseEvent Refreshing(Me, EventArgs.Empty)
        End Sub

        Public Function GetCallbackResult() As String _
            Implements ICallbackEventHandler.GetCallbackResult
            EnsureChildControls()

            Using sw As New StringWriter()
                Using writer As New HtmlTextWriter(sw)
                    writer.Write(Me.ClientID & "_")
                    Me.RenderContents(writer)
                End Using
                Return sw.ToString()
            End Using
        End Function

        Public Function GetCallbackScript(ByVal buttonControl As  _
            IButtonControl, ByVal argument As String) As String _
            Implements ICallbackContainer.GetCallbackScript
            Return Page.ClientScript.GetCallbackEventReference(
                Me,
                "",
                "RefreshPanel",
                "null",
                True
                )
        End Function
    End Class
End Namespace

