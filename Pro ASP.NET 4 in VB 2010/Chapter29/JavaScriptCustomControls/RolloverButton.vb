Imports System.Web.UI.WebControls
Imports System.Web.UI
Namespace CustomServerControlsLibrary
    Public Class RollOverButton
        Inherits WebControl
        Implements IPostBackEventHandler
        Public Sub New()
            MyBase.New(HtmlTextWriterTag.Img)
            ImageUrl = ""
            MouseOverImageUrl = ""
        End Sub

        Public Property ImageUrl() As String
            Get
                Return DirectCast(ViewState("ImageUrl"), String)
            End Get
            Set(ByVal value As String)
                ViewState("ImageUrl") = value
            End Set
        End Property

        Public Property MouseOverImageUrl() As String
            Get
                Return DirectCast(
                    ViewState("MouseOverImageUrl"), String
                    )
            End Get
            Set(ByVal value As String)
                ViewState("MouseOverImageUrl") = value
            End Set
        End Property

        Protected Overrides Sub AddAttributesToRender(
            ByVal output As HtmlTextWriter
            )
            output.AddAttribute("id", ClientID)
            output.AddAttribute("src", ImageUrl)
            output.AddAttribute(
                "onclick",
                Page.ClientScript.GetPostBackEventReference(New PostBackOptions(Me))
                )

            output.AddAttribute(
                "onmouseover",
                "swapImg('" & Convert.ToString(Me.ClientID) &
                    "', '" & MouseOverImageUrl & "');"
                )
            output.AddAttribute(
                "onmouseout", "swapImg('" & Convert.ToString(Me.ClientID) &
                    "', '" & ImageUrl & "');"
                )
        End Sub

        Protected Overrides Sub OnPreRender(ByVal e As EventArgs)
            If Not Page.ClientScript.IsClientScriptBlockRegistered("swapImg") Then
                Dim script As String =
                    "<script type='text/javascript'> " &
                    "function swapImg(id, url) { " &
                    "var elm = document.getElementById(id); " &
                    "elm.src = url; }" & "</script> "

                Page.ClientScript.RegisterClientScriptBlock(Me.[GetType](), "swapImg", script)
            End If

            If Not Page.ClientScript.IsStartupScriptRegistered("preload" &
                Convert.ToString(Me.ClientID)) Then
                Dim script As String = "<script type='text/javascript'> " &
                    "var preloadedImage = new Image(); " &
                    "preloadedImage.src = '" & MouseOverImageUrl & "'; " & "</script> "

                Page.ClientScript.RegisterStartupScript(
                    Me.[GetType](),
                    "preload" & Convert.ToString(Me.ClientID), script
                    )
            End If

            MyBase.OnPreRender(e)
        End Sub

        Public Event ImageClicked As EventHandler

        Public Sub RaisePostBackEvent(ByVal eventArgument As String) _
            Implements IPostBackEventHandler.RaisePostBackEvent
            OnImageClicked(New EventArgs())
        End Sub

        Protected Overridable Sub OnImageClicked(ByVal e As EventArgs)
            ' Check for at least one listener and then raise the event.
            RaiseEvent ImageClicked(Me, e)
        End Sub
    End Class
End Namespace
