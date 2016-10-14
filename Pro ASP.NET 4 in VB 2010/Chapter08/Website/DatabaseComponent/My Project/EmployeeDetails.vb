Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace DatabaseComponent
    Public Class EmployeeDetails
        Private m_employeeID As Integer
        Private m_firstName As String
        Private m_lastName As String
        Private m_titleOfCourtesy As String

        Public Property EmployeeID() As Integer
            Get
                Return m_employeeID
            End Get
            Set(ByVal value As Integer)
                m_employeeID = value
            End Set
        End Property
        Public Property FirstName() As String
            Get
                Return m_firstName
            End Get
            Set(ByVal value As String)
                m_firstName = value
            End Set
        End Property
        Public Property LastName() As String
            Get
                Return m_lastName
            End Get
            Set(ByVal value As String)
                m_lastName = value
            End Set
        End Property
        Public Property TitleOfCourtesy() As String
            Get
                Return m_titleOfCourtesy
            End Get
            Set(ByVal value As String)
                m_titleOfCourtesy = value
            End Set
        End Property

        Public Sub New(
            ByVal employeeID As Integer,
            ByVal firstName As String,
            ByVal lastName As String,
            ByVal titleOfCourtesy As String
            )
            Me.m_employeeID = employeeID
            Me.m_firstName = firstName
            Me.m_lastName = lastName
            Me.m_titleOfCourtesy = titleOfCourtesy
        End Sub

        Public Sub New()
        End Sub
    End Class
End Namespace
