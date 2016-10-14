Imports System
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.ComponentModel

Namespace CustomServerControlsLibrary
    <ParseChildren(True)> _
    Public Class SimpleStyledRepeater
        Inherits WebControl
        Implements INamingContainer
        Public Sub New()
            MyBase.New()

            ' Note that in order to reduce page size, this 
            ' control doesn't store style information in view state. 
            ' That means if you change styles programmatically, 
            ' the changes will be lost after each postback. 
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

        Private m_itemStyle As Style
        Private m_alternatingItemStyle As Style
        Private m_headerStyle As Style
        Private m_footerStyle As Style

        <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
        <NotifyParentProperty(True)> _
        <PersistenceMode(PersistenceMode.InnerProperty)> _
        Public ReadOnly Property ItemStyle() As Style
            Get
                If m_itemStyle Is Nothing Then
                    m_itemStyle = New Style()
                    If IsTrackingViewState Then
                        DirectCast(m_itemStyle, IStateManager).TrackViewState()
                    End If
                End If
                Return m_itemStyle
            End Get
        End Property

        <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
        <NotifyParentProperty(True)> _
        <PersistenceMode(PersistenceMode.InnerProperty)> _
        Public ReadOnly Property AlternatingItemStyle() As Style
            Get
                If m_alternatingItemStyle Is Nothing Then
                    m_alternatingItemStyle = New Style()
                    If IsTrackingViewState Then
                        DirectCast(m_alternatingItemStyle, IStateManager).TrackViewState()
                    End If
                End If
                Return m_alternatingItemStyle
            End Get
        End Property

        <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
        <NotifyParentProperty(True)> _
        <PersistenceMode(PersistenceMode.InnerProperty)> _
        Public ReadOnly Property HeaderStyle() As Style
            Get
                If m_headerStyle Is Nothing Then
                    m_headerStyle = New Style()
                    If IsTrackingViewState Then
                        DirectCast(m_headerStyle, IStateManager).TrackViewState()
                    End If
                End If
                Return m_headerStyle
            End Get
        End Property

        <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
        <NotifyParentProperty(True)> _
        <PersistenceMode(PersistenceMode.InnerProperty)> _
        Public ReadOnly Property FooterStyle() As Style
            Get
                If m_footerStyle Is Nothing Then
                    m_footerStyle = New Style()
                    If IsTrackingViewState Then
                        DirectCast(m_footerStyle, IStateManager).TrackViewState()
                    End If
                End If
                Return m_footerStyle
            End Get
        End Property

        Protected Overloads Overrides Sub CreateChildControls()
            Controls.Clear()

            If (RepeatCount > 0) AndAlso (m_itemTemplate IsNot Nothing) Then
                ' Start by outputing the header template (if supplied). 
                If m_headerTemplate IsNot Nothing Then
                    Dim headerContainer As New SimpleRepeaterItem(0, RepeatCount)
                    m_headerTemplate.InstantiateIn(headerContainer)
                    Controls.Add(headerContainer)

                    If m_headerStyle IsNot Nothing Then
                        headerContainer.ApplyStyle(m_headerStyle)
                    End If
                End If
                For i As Integer = 0 To RepeatCount - 1

                    ' Output the content the specified number of times. 
                    Dim container As New SimpleRepeaterItem(i + 1, RepeatCount)

                    ' Create a style for alternate items. 
                    Dim altStyle As New Style()
                    altStyle.MergeWith(m_itemStyle)
                    altStyle.CopyFrom(m_alternatingItemStyle)

                    If (i Mod 2 = 0) AndAlso (m_alternatingItemTemplate IsNot Nothing) Then
                        ' This is an alternating item and there is an alternating template. 
                        m_alternatingItemTemplate.InstantiateIn(container)
                        container.ApplyStyle(altStyle)
                    Else
                        m_itemTemplate.InstantiateIn(container)
                        If m_itemStyle IsNot Nothing Then
                            container.ApplyStyle(m_itemStyle)
                        End If
                    End If

                    Controls.Add(container)
                Next

                ' Once all of the items have been rendered, 
                ' add the footer template if specified. 
                If m_footerTemplate IsNot Nothing Then
                    Dim footerContainer As New SimpleRepeaterItem(RepeatCount, RepeatCount)
                    m_footerTemplate.InstantiateIn(footerContainer)
                    Controls.Add(footerContainer)
                    If m_footerStyle IsNot Nothing Then
                        footerContainer.ApplyStyle(m_footerStyle)
                    End If
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

End Namespace