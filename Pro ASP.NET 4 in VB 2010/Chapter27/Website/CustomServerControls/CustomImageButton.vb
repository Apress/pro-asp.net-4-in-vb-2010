Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports CustomServerControlsLibrary


<Assembly: WebResource("CustomServerControlsLibrary.button1.jpg", "image/jpeg")> 
Namespace CustomServerControlsLibrary
    <DefaultEvent("ImageClicked")> _
    Public Class CustomImageButton
        Inherits WebControl
        Implements IPostBackEventHandler

        Public Sub New()
            MyBase.New(HtmlTextWriterTag.Img)
            ImageUrl = ""
        End Sub
        Public Property ImageUrl() As String
            Get
                Return DirectCast(ViewState("ImageUrl"), String)
            End Get
            Set(ByVal value As String)
                ViewState("ImageUrl") = value
            End Set
        End Property
        Protected Overloads Overrides Sub OnInit(ByVal e As EventArgs)
            ImageUrl =
                Page.ClientScript.GetWebResourceUrl(
                    GetType(CustomImageButton),
                    "CustomServerControlsLibrary.button1.jpg"
                    )
        End Sub

        Protected Overloads Overrides Sub AddAttributesToRender(
            ByVal output As HtmlTextWriter
            )
            output.AddAttribute("name", UniqueID)
            output.AddAttribute("src", ImageUrl)
            output.AddAttribute(
                "onClick",
                Page.ClientScript.GetPostBackEventReference(Me, String.Empty)
                )
        End Sub

        Public Event ImageClicked As EventHandler

        Public Sub RaisePostBackEvent(
            ByVal eventArgument As String
            ) Implements System.Web.UI.IPostBackEventHandler.RaisePostBackEvent
            OnImageClicked(New EventArgs())
        End Sub

        Protected Overridable Sub OnImageClicked(ByVal e As EventArgs)
            RaiseEvent ImageClicked(Me, e)
            ' Check for at least one listener and then raise the event. 
        End Sub
    End Class
End Namespace