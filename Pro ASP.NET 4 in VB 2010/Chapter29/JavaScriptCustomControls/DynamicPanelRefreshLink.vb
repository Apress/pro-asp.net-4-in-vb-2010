Imports System.Web.UI.WebControls
Imports System.Web.UI
Namespace DynamicControls
    Public Class DynamicPanelRefreshLink
        Inherits LinkButton
        Public Sub New()
            PanelID = ""
        End Sub

        Public Property PanelID() As String
            Get
                Return DirectCast(ViewState("DynamicPanelID"), String)
            End Get
            Set(ByVal value As String)
                ViewState("DynamicPanelID") = value
            End Set
        End Property

        Protected Overrides Sub AddAttributesToRender(
            ByVal writer As HtmlTextWriter
            )
            If Not DesignMode Then
                Dim pnl As DynamicPanel =
                    DirectCast(Page.FindControl(PanelID), DynamicPanel)
                If pnl IsNot Nothing Then
                    writer.AddAttribute(
                        "onclick", pnl.GetCallbackScript(Me, "")
                        )
                    writer.AddAttribute(
                        "href", "#"
                        )
                End If
            End If
        End Sub
    End Class
End Namespace

