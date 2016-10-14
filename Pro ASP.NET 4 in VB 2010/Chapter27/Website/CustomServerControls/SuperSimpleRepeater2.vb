Imports System
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.ComponentModel

Namespace CustomServerControlsLibrary
    <Designer(GetType(SuperSimpleRepeaterDesigner))> _
    Public Class SuperSimpleRepeater2
        Inherits WebControl
        Implements INamingContainer
        Public Sub New()
            MyBase.New()
            RepeatCount = 1
        End Sub

        Public Property RepeatCount() As Integer
            Get
                Return CInt(ViewState("RepeatCount"))
            End Get
            Set(ByVal value As Integer)
                ViewState("RepeatCount") = value
            End Set
        End Property

        Private m_itemTemplate As ITemplate

        <PersistenceMode(PersistenceMode.InnerProperty)> _
        <TemplateContainer(GetType(SimpleRepeaterItem))> _
        Public Property ItemTemplate() As ITemplate
            Get
                Return m_itemTemplate
            End Get
            Set(ByVal value As ITemplate)
                m_itemTemplate = value
            End Set
        End Property

        Private m_alternatingItemTemplate As ITemplate

        <PersistenceMode(PersistenceMode.InnerProperty)> _
        <TemplateContainer(GetType(SimpleRepeaterItem))> _
        Public Property AlternatingItemTemplate() As ITemplate
            Get
                Return m_alternatingItemTemplate
            End Get
            Set(ByVal value As ITemplate)
                m_alternatingItemTemplate = value
            End Set
        End Property

        Private m_headerTemplate As ITemplate

        <PersistenceMode(PersistenceMode.InnerProperty)> _
        <TemplateContainer(GetType(SimpleRepeaterItem))> _
        Public Property HeaderTemplate() As ITemplate
            Get
                Return m_headerTemplate
            End Get
            Set(ByVal value As ITemplate)
                m_headerTemplate = value
            End Set
        End Property

        Private m_footerTemplate As ITemplate

        <PersistenceMode(PersistenceMode.InnerProperty)> _
        <TemplateContainer(GetType(SimpleRepeaterItem))> _
        Public Property FooterTemplate() As ITemplate
            Get
                Return m_footerTemplate
            End Get
            Set(ByVal value As ITemplate)
                m_footerTemplate = value
            End Set
        End Property


        Protected Overloads Overrides Sub CreateChildControls()
            Controls.Clear()

            If (RepeatCount > 0) AndAlso (m_itemTemplate IsNot Nothing) Then
                ' Start by outputing the header template (if supplied). 
                If m_headerTemplate IsNot Nothing Then
                    Dim headerContainer As New SimpleRepeaterItem(0, RepeatCount)
                    m_headerTemplate.InstantiateIn(headerContainer)
                    'headerContainer.DataBind(); 
                    Controls.Add(headerContainer)
                End If
                For i As Integer = 0 To RepeatCount - 1

                    ' Output the content the specified number of times. 
                    Dim container As New SimpleRepeaterItem(i + 1, RepeatCount)

                    If (i Mod 2 = 0) AndAlso (m_alternatingItemTemplate IsNot Nothing) Then
                        ' This is an alternating item and there is an alternating template. 
                        m_alternatingItemTemplate.InstantiateIn(container)
                    Else
                        m_itemTemplate.InstantiateIn(container)
                    End If
                    'container.DataBind(); 
                    Controls.Add(container)
                Next

                ' Once all of the items have been rendered, 
                ' add the footer template if specified. 
                If m_footerTemplate IsNot Nothing Then
                    Dim footerContainer As New SimpleRepeaterItem(RepeatCount, RepeatCount)
                    m_footerTemplate.InstantiateIn(footerContainer)
                    'footerContainer.DataBind(); 
                    Controls.Add(footerContainer)
                End If
            Else
                ' Show an error message. 
                Controls.Add(New LiteralControl("Specify the record count and an item template"))
            End If
        End Sub

        Public Overloads Overrides Sub DataBind()
            EnsureChildControls()
            MyBase.DataBind()
        End Sub



    End Class



    Public Class SimpleRepeaterItem
        Inherits WebControl
        Implements INamingContainer
        Private m_index As Integer
        Public ReadOnly Property Index() As Integer
            Get
                Return m_index
            End Get
        End Property

        Private m_total As Integer
        Public ReadOnly Property Total() As Integer
            Get
                Return m_total
            End Get
        End Property

        ' A constructor that allows you to set the index and total count 
        ' when you create an item. 
        Public Sub New(ByVal itemIndex As Integer, ByVal totalCount As Integer)
            m_index = itemIndex
            m_total = totalCount
        End Sub
    End Class
End Namespace