Imports System.Xml

Namespace SherlockLib
    ''' <summary> 
    ''' Summary description for Quotation. 
    ''' </summary> 
    Public Class Quotation
        Private qsource As String
        Private m_date As String
        Private quotation As String

        Public Sub New(ByVal quoteNode As XmlNode)
            If (quoteNode.SelectSingleNode("source")) IsNot Nothing Then
                qsource = quoteNode.SelectSingleNode("source").InnerText
            End If
            If (quoteNode.Attributes.GetNamedItem("date")) IsNot Nothing Then
                m_date = quoteNode.Attributes.GetNamedItem("date").Value
            End If
            quotation = quoteNode.FirstChild.InnerText
        End Sub

        Public Property Source() As String
            Get
                Return qsource
            End Get
            Set(ByVal value As String)
                qsource = value
            End Set
        End Property

        Public Property [Date]() As String
            Get
                Return m_date
            End Get
            Set(ByVal value As String)
                m_date = value
            End Set
        End Property

        Public Property QuotationText() As String
            Get
                Return quotation
            End Get
            Set(ByVal value As String)
                quotation = value
            End Set
        End Property
    End Class
End Namespace