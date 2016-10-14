Imports System.Xml
Imports System.Xml.Serialization
Imports System.Text

Namespace APress.ProAspNet.Providers.Store
    Public Class UserStore
        'Inherits SimpleUser
        Private _FileName As String
        Private _Users As List(Of SimpleUser)
        Private _Serializer As XmlSerializer

#Region "Singleton implementation"

        Private Shared _RegisteredStores As Dictionary(Of String, UserStore)

        Private Sub New(ByVal fileName As String)
            _FileName = fileName
            _Users = New List(Of SimpleUser)()
            _Serializer = New XmlSerializer(GetType(List(Of SimpleUser)))

            LoadStore(_FileName)
        End Sub

        Public Shared Function GetStore(ByVal fileName As String) As UserStore
            ' Create the registered stores 
            If _RegisteredStores Is Nothing Then
                _RegisteredStores = New Dictionary(Of String, UserStore)()
            End If

            ' Now return the approprate store 
            If Not _RegisteredStores.ContainsKey(fileName) Then
                _RegisteredStores.Add(fileName, New UserStore(fileName))
            End If

            Return _RegisteredStores(fileName)
        End Function

#End Region

#Region "Private Helper Methods"

        Private Sub LoadStore(ByVal fileName As String)
            Try
                If System.IO.File.Exists(fileName) Then
                    Using reader As New XmlTextReader(fileName)
                        _Users = DirectCast(_Serializer.Deserialize(reader), List(Of SimpleUser))
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
                    _Serializer.Serialize(writer, _Users)
                End Using
            Catch ex As Exception
                Throw New Exception(String.Format("Unable to save file {0}", fileName), ex)
            End Try
        End Sub

#End Region

        Public ReadOnly Property Users() As List(Of SimpleUser)
            Get
                Return _Users
            End Get
        End Property

        Public Sub Save()
            SaveStore(_FileName)
        End Sub

        Public Function GetUserByName(
            ByVal name As String
            ) As SimpleUser
            Return _Users.Find(
                Function(user As SimpleUser) String.Equals(name, user.UserName)
                    )
        End Function

        Public Function GetUserByEmail(
            ByVal email As String
            ) As SimpleUser
            Return _Users.Find(
                Function(user As SimpleUser) String.Equals(email, user.Email)
                    )
        End Function

        Public Function GetUserByKey(
            ByVal key As Guid
            ) As SimpleUser
            Return _Users.Find(
                Function(user As SimpleUser) (user.UserKey.CompareTo(key) = 0)
                    )
        End Function
    End Class
End Namespace
