#Region "Using directives"
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Forms.Design
Imports System.ComponentModel.Design

#End Region

Namespace CustomServerControlsLibrary
    Public Class TitledTextBoxDesigner
        Inherits System.Web.UI.Design.ControlDesigner
        Private m_actionLists As DesignerActionListCollection

        Public Overloads Overrides ReadOnly Property ActionLists() As DesignerActionListCollection
            Get
                If m_actionLists Is Nothing Then
                    m_actionLists = New DesignerActionListCollection()
                    m_actionLists.Add(New TitledTextBoxActionList(DirectCast(Component, TitledTextBox)))
                End If
                Return m_actionLists
            End Get
        End Property
    End Class
End Namespace