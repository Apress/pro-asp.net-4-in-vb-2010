Imports System.Xml.Serialization
Imports System.Xml
Imports System.Text

Namespace APress.ProAspNet.Providers.Store
    Public Class RoleStore
        'Inherits SimpleRole
        Private _Serializer As XmlSerializer
        Private _FileName As String
        Private _Roles As List(Of SimpleRole)

#Region "Singleton Implementation"

        Private Shared _RegisteredStores As Dictionary(Of String, RoleStore)

        Public Shared Function GetStore(
            ByVal fileName As String
            ) As RoleStore
            ' Create the registered stores 
            If _RegisteredStores Is Nothing Then
                _RegisteredStores =
                    New Dictionary(Of String, RoleStore)()
            End If

            ' Now return the approprate store 
            If Not _RegisteredStores.ContainsKey(fileName) Then
                _RegisteredStores.Add(
                    fileName, New RoleStore(fileName)
                    )
            End If

            Return _RegisteredStores(fileName)
        End Function

        Private Sub New(ByVal fileName As String)
            _Roles = New List(Of SimpleRole)()
            _FileName = fileName
            _Serializer =
                New XmlSerializer(GetType(List(Of SimpleRole)))

            LoadStore(_FileName)
        End Sub

#End Region

#Region "Private Helper Methods"

        Private Sub LoadStore(ByVal fileName As String)
            Try
                If System.IO.File.Exists(fileName) Then
                    Using reader As New XmlTextReader(fileName)
                        _Roles = DirectCast(_Serializer.Deserialize(reader), List(Of SimpleRole))
                    End Using
                End If
            Catch ex As Exception
                Throw New Exception(String.Format("Unable to load file {0}", fileName), ex)
            End Try
        End Sub

        Private Sub SaveStore(ByVal fileName As String)
            Try
                If System.IO.File.Exists(fileName) Then
                    System.IO.File.Delete(fileName)
                End If

                Using writer As New XmlTextWriter(fileName, Encoding.UTF8)
                    _Serializer.Serialize(writer, _Roles)
                End Using
            Catch ex As Exception
                Throw New Exception(String.Format("Unable to save file {0}", fileName), ex)
            End Try
        End Sub

#End Region

        Public ReadOnly Property Roles() As List(Of SimpleRole)
            Get
                Return _Roles
            End Get
        End Property

        Public Sub Save()
            SaveStore(_FileName)
        End Sub

        Public Function GetRolesForUser(
            ByVal userName As String
            ) As List(Of SimpleRole)
            Dim Results As New List(Of SimpleRole)()
            For Each r As SimpleRole In Roles
                If r.AssignedUsers.Contains(userName) Then
                    Results.Add(r)
                End If
            Next
            Return Results
        End Function

        Public Function GetUsersInRole(
            ByVal roleName As String
            ) As String()
            Dim Role As SimpleRole = GetRole(roleName)
            If Role IsNot Nothing Then
                Dim Results As String() =
                    New String(Role.AssignedUsers.Count - 1) {}
                Role.AssignedUsers.CopyTo(Results, 0)
                Return Results
            Else
                Throw New Exception(
                    String.Format(
                        "Role with name {0} does not exist!", roleName
                        )
                    )
            End If
        End Function
        Public Function GetRole(ByVal roleName As String) As SimpleRole
            Return Roles.Find(
                Function(role As SimpleRole) role.RoleName.Equals(
                    roleName, StringComparison.OrdinalIgnoreCase))
        End Function

    End Class
End Namespace
