Imports System
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.ComponentModel
Imports System.Web.UI.Design
Imports System.ComponentModel.Design

Namespace CustomServerControlsLibrary
    Public Class SuperSimpleRepeater
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
        Public Property ItemTemplate() As ITemplate
            Get
                Return m_itemTemplate
            End Get
            Set(ByVal value As ITemplate)
                m_itemTemplate = value
            End Set
        End Property

        Protected Overloads Overrides Sub CreateChildControls()
            'clear out the control colletion if there 
            'are any children we want to wipe them out 
            'before starting 
            Controls.Clear()

            'as long as we are repeating at least once 
            'and the template is defined, then loop and 
            'instantiate the template in a panel 
            If (RepeatCount > 0) AndAlso (m_itemTemplate IsNot Nothing) Then
                For i As Integer = 0 To RepeatCount - 1
                    Dim container As New Panel()
                    m_itemTemplate.InstantiateIn(container)
                    Controls.Add(container)
                Next
            Else
                'otherwise we output a message 
                Controls.Add(New LiteralControl("Specify the record count and an item template"))
            End If
        End Sub


    End Class

End Namespace