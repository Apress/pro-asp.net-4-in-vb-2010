Imports System.Drawing
Namespace CustomControls
    Public Class GradientLabel
        Inherits Control

        Public Sub New()
            Text = ""
            TextColor = Color.White
            GradientColorStart = Color.Blue
            GradientColorEnd = Color.DarkBlue
            TextSize = 14
        End Sub

        Public Property Text() As String
            Get
                Return DirectCast(ViewState("Text"), String)
            End Get
            Set(ByVal value As String)
                ViewState("Text") = value
            End Set
        End Property

        Public Property TextSize() As Integer
            Get
                Return CInt(ViewState("TextSize"))
            End Get
            Set(ByVal value As Integer)
                ViewState("TextSize") = value
            End Set
        End Property

        Public Property GradientColorStart() As Color
            Get
                Return DirectCast(ViewState("ColorStart"), Color)
            End Get
            Set(ByVal value As Color)
                ViewState("ColorStart") = value
            End Set
        End Property

        Public Property GradientColorEnd() As Color
            Get
                Return DirectCast(ViewState("ColorEnd"), Color)
            End Get
            Set(ByVal value As Color)
                ViewState("ColorEnd") = value
            End Set
        End Property

        Public Property TextColor() As Color
            Get
                Return DirectCast(ViewState("TextColor"), Color)
            End Get
            Set(ByVal value As Color)
                ViewState("TextColor") = value
            End Set
        End Property

        Protected Overrides Sub Render(ByVal writer As HtmlTextWriter)
            Dim context As HttpContext = HttpContext.Current
            writer.Write("<img src='" & "GradientLabel.aspx?" &
                         "Text=" & context.Server.UrlEncode(Text) &
                         "&TextSize=" & TextSize.ToString() &
                         "&TextColor=" & TextColor.ToArgb() &
                         "&GradientColorStart=" &
                         GradientColorStart.ToArgb() &
                         "&GradientColorEnd=" &
                         GradientColorEnd.ToArgb() & "'>")
        End Sub
    End Class
End Namespace

