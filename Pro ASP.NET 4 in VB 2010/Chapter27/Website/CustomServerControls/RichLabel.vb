Imports System.ComponentModel
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Drawing.Design
Imports System.Text.RegularExpressions
Imports System.Globalization

Namespace CustomServerControlsLibrary
    <DefaultProperty("RichText")> _
    <ToolboxData("<{0}:RichLabel runat=server><Format HighlightTag=b Type=Html /></{0}:RichLabel>")> _
    Public Class RichLabel
        Inherits WebControl
        Public Sub New()
            MyBase.New()
            Text = ""
            Format = New RichLabelFormattingOptions(RichLabelTextType.Xml, "b")
        End Sub

        <Editor(GetType(ColorTypeEditor), GetType(UITypeEditor))> _
        Public Overloads Overrides Property BackColor() As Color
            Get
                Return MyBase.BackColor
            End Get
            Set(ByVal value As Color)
                MyBase.BackColor = value
            End Set
        End Property


        Protected Overloads Overrides Sub RenderContents(ByVal output As HtmlTextWriter)
            Dim convertedText As String = ""
            Select Case Format.Type
                Case RichLabelTextType.Xml
                    convertedText =
                        RichLabel.ConvertXmlTextToHtmlText(Text, Format.HighlightTag)
                    Exit Select
                Case RichLabelTextType.Html
                    convertedText = Text
                    Exit Select
            End Select
            output.Write(convertedText)
        End Sub

        <Category("Appearance")> _
        <Description("The content that will be displayed.")> _
        Public Property Text() As String
            Get
                Return DirectCast(ViewState("Text"), String)
            End Get
            Set(ByVal value As String)
                ViewState("Text") = value
            End Set
        End Property

        <Category("Appearance")> _
        <Description("Options for configuring how text is rendered.")> _
        <TypeConverter(GetType(RichLabelFormattingOptionsConverter))> _
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
        <PersistenceMode(PersistenceMode.InnerProperty)> _
        Public Property Format() As RichLabelFormattingOptions
            Get
                Return DirectCast(ViewState("Format"), RichLabelFormattingOptions)
            End Get
            Set(ByVal value As RichLabelFormattingOptions)
                ViewState("Format") = value
            End Set
        End Property

        ' This is a shared method, just in case you want to use it 
        ' idependent of any control object. 
        Public Shared Function ConvertXmlTextToHtmlText(
            ByVal inputText As String, ByVal highlightTag As String
            ) As String
            If inputText = "" Then
                Return ""
            Else
                ' Replace all start and end tags. 
                Dim startPattern As String = "<([^>]+)>"
                Dim regEx As New Regex(startPattern)
                Dim outputText As String =
                    regEx.Replace(inputText,
                                  "&lt;<" & highlightTag &
                                  ">$1&gt;</" & highlightTag & ">")
                outputText =
                    outputText.Replace(" ", "&nbsp;")
                outputText =
                    outputText.Replace("" & Chr(13) & "" &
                                       Chr(10) & "", "<br />")
                Return outputText
            End If
        End Function
    End Class

    Public Class RichLabelFormattingOptionsConverter
        Inherits ExpandableObjectConverter
        Private Overloads Function ToString(ByVal value As Object) As String
            Dim format As RichLabelFormattingOptions = DirectCast(value, RichLabelFormattingOptions)
            Return [String].Format("{0}, <{1}>", format.Type, format.HighlightTag)
        End Function

        Private Function FromString(ByVal value As Object) As RichLabelFormattingOptions
            Dim values As String() = DirectCast(value, String).Split(","c)
            If values.Length <> 2 Then
                Throw New ArgumentException("Could not convert the value")
            End If

            Try
                Dim type As RichLabelTextType = DirectCast([Enum].Parse(GetType(RichLabelTextType), values(0), True), RichLabelTextType)
                Dim tag As String = values(1).Trim(New Char() {" "c, "<"c, ">"c})
                Return New RichLabelFormattingOptions(type, tag)
            Catch
                Throw New ArgumentException("Could not convert the value")
            End Try
        End Function

        Public Overloads Overrides Function CanConvertFrom(ByVal context As ITypeDescriptorContext, ByVal sourceType As Type) As Boolean
            If sourceType Is GetType(String) Then
                Return True
            Else
                Return MyBase.CanConvertFrom(context, sourceType)
            End If
        End Function

        Public Overloads Overrides Function ConvertFrom(ByVal context As ITypeDescriptorContext, ByVal culture As CultureInfo, ByVal value As Object) As Object
            If TypeOf value Is String Then
                Return FromString(value)
            Else
                Return MyBase.ConvertFrom(context, culture, value)
            End If
        End Function

        Public Overloads Overrides Function CanConvertTo(ByVal context As ITypeDescriptorContext, ByVal destinationType As Type) As Boolean
            If destinationType Is GetType(String) Then
                Return True
            Else
                Return MyBase.CanConvertTo(context, destinationType)
            End If
        End Function

        Public Overloads Overrides Function ConvertTo(ByVal context As ITypeDescriptorContext, ByVal culture As CultureInfo, ByVal value As Object, ByVal destinationType As Type) As Object
            If destinationType Is GetType(String) Then
                Return ToString(value)
            Else
                Return MyBase.ConvertTo(context, culture, value, destinationType)
            End If
        End Function

    End Class


    Public Enum RichLabelTextType
        Xml
        Html
    End Enum

    <Serializable()> _
    Public Class RichLabelFormattingOptions
        Private m_type As RichLabelTextType

        <RefreshProperties(RefreshProperties.Repaint)> _
        <NotifyParentProperty(True)> _
        <Description("Type of content supplied in the text property")> _
        Public Property Type() As RichLabelTextType
            Get
                Return m_type
            End Get
            Set(ByVal value As RichLabelTextType)
                m_type = value
            End Set
        End Property

        Private m_highlightTag As String

        <RefreshProperties(RefreshProperties.Repaint)> _
        <NotifyParentProperty(True)> _
        <Description("The HTML tag you want to use to mark up highlighted portions.")> _
        Public Property HighlightTag() As String
            Get
                Return m_highlightTag
            End Get
            Set(ByVal value As String)
                m_highlightTag = value
            End Set
        End Property

        Public Sub New(ByVal type As RichLabelTextType, ByVal highlightTag As String)
            Me.m_highlightTag = highlightTag
            Me.m_type = type
        End Sub

        Public Sub New()
        End Sub
    End Class
End Namespace