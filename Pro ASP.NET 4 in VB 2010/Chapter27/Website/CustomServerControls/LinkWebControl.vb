Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace CustomServerControlsLibrary
    Public Class LinkWebControl
        Inherits WebControl
        Public Sub New()
            MyBase.New(HtmlTextWriterTag.A)
        End Sub

        Public Property Text() As String
            Get
                Return DirectCast(ViewState("Text"), String)
            End Get

            Set(ByVal value As String)
                ViewState("Text") = value
            End Set
        End Property

        Public Property HyperLink() As String
            Get
                Return DirectCast(ViewState("HyperLink"), String)
            End Get
            Set(ByVal value As String)
                If value.IndexOf("http://") = -1 Then
                    Throw New ApplicationException("Specify HTTP as the protocol.")
                Else
                    ViewState("HyperLink") = value
                End If
            End Set
        End Property

        Protected Overloads Overrides Sub OnInit(
            ByVal e As EventArgs
            )
            Page.RegisterRequiresViewStateEncryption()
            MyBase.OnInit(e)
            If ViewState("HyperLink") Is Nothing Then
                ViewState("HyperLink") =
                    "http://www.bing.com"
            End If

            If ViewState("Text") Is Nothing Then
                ViewState("Text") = "Click to search"
            End If
        End Sub

        Protected Overloads Overrides Sub AddAttributesToRender(
            ByVal output As HtmlTextWriter
            )
            output.AddAttribute(
                HtmlTextWriterAttribute.Href, HyperLink
                )
            MyBase.AddAttributesToRender(
                output
                )
        End Sub

        Protected Overloads Overrides Sub RenderContents(
            ByVal output As HtmlTextWriter
            )
            output.Write(Text)
            MyBase.RenderContents(output)
            ' Calls RenderChildren() 
        End Sub
    End Class

End Namespace