Imports System.Web.UI
Imports System.Text

Namespace CustomServerControlsLibrary
    Public Class PopUp
        Inherits Control
        Public Property PopUnder() As Boolean
            Get
                Return CBool(ViewState("PopUnder"))
            End Get
            Set(ByVal value As Boolean)
                ViewState("PopUnder") = value
            End Set
        End Property

        Public Property Url() As String
            Get
                Return DirectCast(ViewState("Url"), String)
            End Get
            Set(ByVal value As String)
                ViewState("Url") = value
            End Set
        End Property

        Public Property WindowHeight() As Integer
            Get
                Return CInt(ViewState("WindowHeight"))
            End Get
            Set(ByVal value As Integer)
                If value < 1 Then
                    Throw New ArgumentException(
                        "WindowHeight must be greater than 0"
                        )
                End If
                ViewState("WindowHeight") = value
            End Set
        End Property

        Public Property WindowWidth() As Integer
            Get
                Return CInt(ViewState("WindowWidth"))
            End Get
            Set(ByVal value As Integer)
                If value < 1 Then
                    Throw New ArgumentException(
                        "WindowWidth must be greater than 0"
                        )
                End If
                ViewState("WindowWidth") = value
            End Set
        End Property

        Public Property Resizable() As Boolean
            Get
                Return CBool(ViewState("Resizable"))
            End Get
            Set(ByVal value As Boolean)
                ViewState("Resizable") = value
            End Set
        End Property

        Public Property Scrollbars() As Boolean
            Get
                Return CBool(ViewState("Scrollbars"))
            End Get
            Set(ByVal value As Boolean)
                ViewState("Scrollbars") = value
            End Set
        End Property

        ' Constructor sets default values.
        Public Sub New()
            PopUnder = True
            Url = "about:blank"
            WindowHeight = 300
            WindowWidth = 300
            Resizable = False
            Scrollbars = False
        End Sub
        Protected Overrides Sub Render(ByVal writer As HtmlTextWriter)
            If Page.Request.Browser.EcmaScriptVersion.Major >= 1 Then
                Dim javaScriptString As New StringBuilder()
                javaScriptString.Append(
                    "<script type='text/javascript'>"
                    )
                javaScriptString.Append(
                    vbLf & "<!-- "
                    )
                javaScriptString.Append(
                    vbLf & "window.open('"
                    )
                javaScriptString.Append(
                    Url & "', '" & ID
                    )
                javaScriptString.Append(
                    "','toolbar=0,"
                    )
                javaScriptString.Append(
                    "height=" & WindowHeight & ","
                    )
                javaScriptString.Append(
                    "width=" & WindowWidth & ","
                    )
                javaScriptString.Append(
                    "resizable=" &
                    Convert.ToInt16(Resizable).ToString() & ","
                    )
                javaScriptString.Append(
                    "scrollbars=" &
                    Convert.ToInt16(Scrollbars).ToString()
                    )
                javaScriptString.Append(
                    "');" & vbLf
                    )
                If PopUnder Then
                    javaScriptString.Append("window.focus();")
                End If
                javaScriptString.Append(vbLf & "-->" & vbLf)
                javaScriptString.Append("</script>" & vbLf)
                writer.Write(javaScriptString.ToString())
            Else
                writer.Write(
                    "<!-- This browser does not support JavaScript -->"
                    )
            End If
        End Sub

    End Class
End Namespace
