Imports System.Web.Security
Imports System.Collections.Specialized
Imports System.Text.RegularExpressions
Imports System.Configuration.Provider
Imports APress.ProAspNet.Providers.APress.ProAspNet.Providers.Store
Namespace APress.ProAspNet.Providers
    Public Class XmlRoleProvider
        Inherits RoleProvider
        Private _FileName As String
        Private _ApplicationName As String
        Private _CurrentStore As RoleStore = Nothing

        Public Overrides Sub Initialize(
            ByVal name As String,
            ByVal config As System.Collections.Specialized.NameValueCollection
            )
            If config Is Nothing Then
                Throw New ArgumentNullException("config")
            End If
            If String.IsNullOrEmpty(name) Then
                name = "XmlRoleProvider"
            End If
            If String.IsNullOrEmpty(config("description")) Then
                config.Remove("description")
                config.Add("description", "XML Role Provider")
            End If

            ' Base initialization
            MyBase.Initialize(name, config)

            ' Initialize properties
            _ApplicationName = "DefaultApp"
            For Each key As String In config.Keys
                If key.ToLower() = "applicationname" Then
                    ApplicationName = config(key)
                ElseIf key.ToLower() = "filename" Then
                    _FileName = config(key)
                End If
            Next
        End Sub
        Private ReadOnly Property CurrentStore() As RoleStore
            Get
                If _CurrentStore Is Nothing Then
                    _CurrentStore = RoleStore.GetStore(_FileName)
                End If
                Return _CurrentStore
            End Get
        End Property

#Region "Properties"
        Public Overrides Property ApplicationName() As String
            Get
                Return _ApplicationName
            End Get
            Set(ByVal value As String)
                _ApplicationName = value
                _CurrentStore = Nothing

            End Set
        End Property
#End Region

#Region "Methods"
        Public Overrides Sub AddUsersToRoles(
            ByVal usernames() As String,
            ByVal roleNames() As String
            )
            Try
                ' Get the roles to be modified
                For Each roleName As String In roleNames
                    Dim role As SimpleRole =
                        CurrentStore.GetRole(roleName)
                    If role IsNot Nothing Then
                        For Each userName In usernames
                            If Not role.AssignedUsers.Contains(userName) Then
                                role.AssignedUsers.Add(userName)
                            End If
                        Next
                    End If
                Next
                CurrentStore.Save()
            Catch ex As Exception
                ' If an exception is raised while saving the storage
                ' or while serializing contents we just forward it to the
                ' caller. It would be cleaner to work with custom exception
                ' classes here and pass more detailed information to the caller
                ' but we leave as is for simplicity.
                Throw
            End Try
        End Sub

        Public Overrides Sub CreateRole(ByVal roleName As String)
            Try
                Dim NewRole As New SimpleRole()
                NewRole.RoleName = roleName
                NewRole.AssignedUsers = New StringCollection()

                CurrentStore.Roles.Add(NewRole)
                CurrentStore.Save()
            Catch ex As Exception
                ' If an exception is raised while saving the storage
                ' or while serializing contents we just forward it to the
                ' caller. It would be cleaner to work with custom exception
                ' classes here and pass more detailed information to the caller
                ' but we leave as is for simplicity.
                Throw
            End Try
        End Sub

        Public Overrides Function DeleteRole(
            ByVal roleName As String,
            ByVal throwOnPopulatedRole As Boolean
            ) As Boolean
            Try

                Dim Role As SimpleRole =
                    CurrentStore.GetRole(roleName)
                If Role IsNot Nothing Then
                    CurrentStore.Roles.Remove(Role)
                    CurrentStore.Save()
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                Throw
            End Try
        End Function

        Public Overrides Function FindUsersInRole(
            ByVal roleName As String,
            ByVal usernameToMatch As String
            ) As String()
            Try
                Dim Results As New List(Of String)
                Dim Expression As New Regex(
                    usernameToMatch.Replace("%", "\w*")
                    )
                Dim Role As SimpleRole =
                    CurrentStore.GetRole(roleName)
                If Role IsNot Nothing Then
                    For Each userName As String In Role.AssignedUsers
                        If Expression.IsMatch(userName) Then
                            Results.Add(userName)
                        End If
                    Next
                Else
                    Throw New ProviderException("Role does not exist!")
                End If
                Return Results.ToArray()
            Catch ex As Exception
                Throw
            End Try
        End Function

        Public Overrides Function GetAllRoles(
            ) As String()
            Try
                Dim Results As String() =
                    New String(CurrentStore.Roles.Count - 1) {}
                For i As Integer = 0 To Results.Length - 1
                    Results(i) = CurrentStore.Roles(i).RoleName
                Next
                Return Results
            Catch ex As Exception
                Throw
            End Try
        End Function

        Public Overrides Function GetRolesForUser(
            ByVal username As String
            ) As String()
            Try
                Dim RolesForUser As List(Of SimpleRole) =
                    CurrentStore.GetRolesForUser(username)
                Dim Results As String() =
                    New String(RolesForUser.Count - 1) {}
                For i As Integer = 0 To Results.Length - 1
                    Results(i) = RolesForUser(i).RoleName
                Next
                Return Results
            Catch ex As Exception
                Throw
            End Try
        End Function

        Public Overrides Function GetUsersInRole(
            ByVal roleName As String
            ) As String()
            Try
                Return CurrentStore.GetUsersInRole(roleName)
            Catch ex As Exception
                Throw
            End Try
        End Function

        Public Overrides Function IsUserInRole(
            ByVal username As String,
            ByVal roleName As String
            ) As Boolean
            Try
                Dim Role As SimpleRole = CurrentStore.GetRole(roleName)
                If Role IsNot Nothing Then
                    Return Role.AssignedUsers.Contains(username)
                Else
                    Throw New ProviderException("Role does not exist!")
                End If
            Catch ex As Exception
                Throw
            End Try
        End Function

        Public Overrides Sub RemoveUsersFromRoles(
            ByVal usernames() As String,
            ByVal roleNames() As String
            )
            Try
                ' Get the roles to be modified
                Dim TargetRoles As New List(Of SimpleRole)
                For Each roleName As String In roleNames
                    Dim Role As SimpleRole = CurrentStore.GetRole(roleName)
                    If Role IsNot Nothing Then
                        For Each userName As String In usernames
                            If Role.AssignedUsers.Contains(userName) Then
                                Role.AssignedUsers.Remove(userName)
                            End If
                        Next
                    End If
                Next
                CurrentStore.Save()
            Catch ex As Exception
                ' If an exception is raised while saving the storage
                ' or while serializing contents we just forward it to the
                ' caller. It would be cleaner to work with custom exception
                ' classes here and pass more detailed information to the caller
                ' but we leave as is for simplicity.
                Throw
            End Try
        End Sub

        Public Overrides Function RoleExists(
            ByVal roleName As String
            ) As Boolean
            Try
                If CurrentStore.GetRole(roleName) IsNot Nothing Then
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                Throw
            End Try
        End Function
#End Region
    End Class

End Namespace
