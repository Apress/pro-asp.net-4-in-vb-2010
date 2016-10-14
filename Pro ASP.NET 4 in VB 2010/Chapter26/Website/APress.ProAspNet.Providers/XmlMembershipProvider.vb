﻿Imports System
Imports System.IO
Imports System.Web
Imports System.Web.Security
Imports System.Configuration.Provider
Imports System.Collections.Generic
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Security.Permissions
Imports System.Security.Cryptography
Imports APress.ProAspNet.Providers.APress.ProAspNet.Providers.Store

Namespace APress.ProAspNet.Providers
    Public Class XmlMembershipProvider
        Inherits MembershipProvider
        Private _Name As String
        Private _FileName As String
        Private _CurrentStore As UserStore = Nothing
        Private _ApplicationName As String
        Private _EnablePasswordReset As Boolean
        Private _RequiresQuestionAndAnswer As Boolean
        Private _PasswordStrengthRegEx As String
        Private _MaxInvalidPasswordAttempts As Integer
        Private _MinRequiredNonAlphanumericChars As Integer
        Private _MinRequiredPasswordLength As Integer
        Private _PasswordFormat As MembershipPasswordFormat

        Private ReadOnly Property CurrentStore() As UserStore
            Get
                If _CurrentStore Is Nothing Then
                    _CurrentStore = UserStore.GetStore(_FileName)
                End If
                Return _CurrentStore
            End Get
        End Property

        Public Overloads Overrides Sub Initialize(
            ByVal name As String,
            ByVal config As System.Collections.Specialized.NameValueCollection
            )
            If config Is Nothing Then
                Throw New ArgumentNullException("config")
            End If
            If String.IsNullOrEmpty(name) Then
                name = "XmlMembershipProvider"
            End If
            If String.IsNullOrEmpty(config("description")) Then
                config.Remove("description")
                config.Add("description", "XML Membership Provider")
            End If

            ' Initialize the base class 
            MyBase.Initialize(name, config)

            ' Initialize default values 
            _ApplicationName = "DefaultApp"
            _EnablePasswordReset = False
            _PasswordStrengthRegEx = "[\w| !§$%&/()=\-?\*]*"
            _MaxInvalidPasswordAttempts = 3
            _MinRequiredNonAlphanumericChars = 1
            _MinRequiredPasswordLength = 5
            _RequiresQuestionAndAnswer = False
            _PasswordFormat = MembershipPasswordFormat.Hashed

            ' Now go through the properties 
            ' and initialize custom values 
            For Each key As String In config.Keys
                Select Case key.ToLower()
                    Case "name"
                        _Name = config(key)
                        Exit Select
                    Case "applicationname"
                        _ApplicationName = config(key)
                        Exit Select
                    Case "filename"
                        _FileName = config(key)
                        Exit Select
                    Case "enablepasswordreset"
                        _EnablePasswordReset =
                            Boolean.Parse(config(key))
                        Exit Select
                    Case "passwordstrengthregex"
                        _PasswordStrengthRegEx = config(key)
                        Exit Select
                    Case "maxinvalidpasswordattempts"
                        _MaxInvalidPasswordAttempts =
                            Integer.Parse(config(key))
                        Exit Select
                    Case "minrequirednonalphanumericchars"
                        _MinRequiredNonAlphanumericChars =
                            Integer.Parse(config(key))
                        Exit Select
                    Case "minrequiredpasswordlength"
                        _MinRequiredPasswordLength =
                            Integer.Parse(config(key))
                        Exit Select
                    Case "passwordformat"
                        _PasswordFormat =
                            DirectCast(
                                [Enum].Parse(
                                    GetType(MembershipPasswordFormat),
                                    config(key)
                                    ), MembershipPasswordFormat
                                )
                        Exit Select
                    Case "requiresquestionandanswer"
                        _RequiresQuestionAndAnswer =
                            Boolean.Parse(config(key))
                        Exit Select
                End Select
            Next
        End Sub

#Region "Properties"

        Public Overloads Overrides Property ApplicationName() As String
            Get
                Return _ApplicationName
            End Get
            Set(ByVal value As String)
                _ApplicationName = value
                _CurrentStore = Nothing
            End Set
        End Property

        Public Overloads Overrides ReadOnly Property EnablePasswordReset() As Boolean
            Get
                Return _EnablePasswordReset
            End Get
        End Property

        Public Overloads Overrides ReadOnly Property EnablePasswordRetrieval() As Boolean
            Get
                If Me.PasswordFormat = MembershipPasswordFormat.Hashed Then
                    Return False
                Else
                    Return True
                End If
            End Get
        End Property

        Public Overloads Overrides ReadOnly Property MaxInvalidPasswordAttempts() As Integer
            Get
                Return _MaxInvalidPasswordAttempts
            End Get
        End Property

        Public Overloads Overrides ReadOnly Property MinRequiredNonAlphanumericCharacters() As Integer
            Get
                Return _MinRequiredNonAlphanumericChars
            End Get
        End Property

        Public Overloads Overrides ReadOnly Property MinRequiredPasswordLength() As Integer
            Get
                Return _MinRequiredPasswordLength
            End Get
        End Property

        Public Overloads Overrides ReadOnly Property PasswordAttemptWindow() As Integer
            Get
                Return 20
            End Get
        End Property

        Public Overloads Overrides ReadOnly Property PasswordFormat() As MembershipPasswordFormat
            Get
                Return _PasswordFormat
            End Get
        End Property

        Public Overloads Overrides ReadOnly Property PasswordStrengthRegularExpression() As String
            Get
                Return _PasswordStrengthRegEx
            End Get
        End Property

        Public Overloads Overrides ReadOnly Property RequiresQuestionAndAnswer() As Boolean
            Get
                Return _RequiresQuestionAndAnswer
            End Get
        End Property

        Public Overloads Overrides ReadOnly Property RequiresUniqueEmail() As Boolean
            Get
                Return True
            End Get
        End Property

#End Region

#Region "Methods"

        Public Overloads Overrides Function CreateUser(
            ByVal username As String,
            ByVal password As String,
            ByVal email As String,
            ByVal passwordQuestion As String,
            ByVal passwordAnswer As String,
            ByVal isApproved As Boolean,
            ByVal providerUserKey As Object,
            ByRef status As MembershipCreateStatus
            ) As MembershipUser
            Try
                ' Validate the username and email 
                If Not ValidateUsername(username, email, Guid.Empty) Then
                    status = MembershipCreateStatus.InvalidUserName
                    Return Nothing
                End If

                ' Raise the event before validating the password 
                MyBase.OnValidatingPassword(
                    New ValidatePasswordEventArgs(username, password, True)
                    )

                ' Validate the password 
                If Not ValidatePassword(password) Then
                    status = MembershipCreateStatus.InvalidPassword
                    Return Nothing
                End If

                ' Everything is valid, create the user 
                Dim user As New SimpleUser()
                user.UserKey = Guid.NewGuid()
                user.UserName = username
                user.PasswordSalt = String.Empty
                ' Note - the TransformPassword() method creates
                ' the salted hash value for storing the password
                user.Password =
                    Me.TransformPassword(password, user.PasswordSalt)
                user.Email = email
                user.PasswordQuestion = passwordQuestion
                user.PasswordAnswer = passwordAnswer
                user.CreationDate = DateTime.Now
                user.LastActivityDate = DateTime.Now
                user.LastPasswordChangeDate = DateTime.Now

                ' Add the user to the store 
                CurrentStore.Users.Add(user)
                CurrentStore.Save()

                status = MembershipCreateStatus.Success
                Return CreateMembershipFromInternalUser(user)
            Catch
                ' If an exception is raised while saving the storage
                ' or while serializing contents we just forward it to the
                ' caller. It would be cleaner to work with custom exception
                ' classes here and pass more detailed information to the caller
                ' but we leave as is for simplicity.
                Throw
            End Try
        End Function

        Public Overloads Overrides Function DeleteUser(
            ByVal username As String,
            ByVal deleteAllRelatedData As Boolean
            ) As Boolean
            Try
                Dim user As SimpleUser = CurrentStore.GetUserByName(username)
                If user IsNot Nothing Then
                    CurrentStore.Users.Remove(user)
                    Return True
                End If

                Return False
            Catch
                Throw
            End Try
        End Function

        Public Overloads Overrides Function GetUser(
            ByVal username As String,
            ByVal userIsOnline As Boolean
            ) As MembershipUser
            Try
                Dim user As SimpleUser =
                    CurrentStore.GetUserByName(username)
                If user IsNot Nothing Then
                    If userIsOnline Then
                        user.LastActivityDate = DateTime.Now
                        CurrentStore.Save()
                    End If
                    Return CreateMembershipFromInternalUser(user)
                Else
                    Return Nothing
                End If
            Catch
                ' If an exception is raised while saving the storage
                ' or while serializing contents we just forward it to the
                ' caller. It would be cleaner to work with custom exception
                ' classes here and pass more detailed information to the caller
                ' but we leave as is for simplicity.
                Throw
            End Try
        End Function

        Public Overloads Overrides Function GetUser(
            ByVal providerUserKey As Object,
            ByVal userIsOnline As Boolean
            ) As MembershipUser
            Try
                Dim user As SimpleUser =
                    CurrentStore.GetUserByKey(
                        DirectCast(providerUserKey, Guid)
                        )
                If user IsNot Nothing Then
                    If userIsOnline Then
                        user.LastActivityDate = DateTime.Now
                        CurrentStore.Save()
                    End If
                    Return CreateMembershipFromInternalUser(user)
                Else
                    Return Nothing
                End If
            Catch
                Throw
            End Try
        End Function

        Public Overloads Overrides Function GetUserNameByEmail(
            ByVal email As String
            ) As String
            Try
                Dim user As SimpleUser = CurrentStore.GetUserByEmail(email)

                If user IsNot Nothing Then
                    Return user.UserName
                Else
                    Return Nothing
                End If
            Catch
                Throw
            End Try
        End Function

        Public Overloads Overrides Sub UpdateUser(
            ByVal user As MembershipUser
            )
            Try
                Dim suser As SimpleUser =
                    CurrentStore.GetUserByKey(
                        DirectCast(user.ProviderUserKey, Guid)
                        )

                If suser IsNot Nothing Then
                    If Not ValidateUsername(
                        suser.UserName, suser.Email, suser.UserKey
                        ) Then
                        Throw New ArgumentException(
                            "Username and / or email are not unique!"
                            )
                    End If

                    suser.Email = user.Email
                    suser.LastActivityDate = user.LastActivityDate
                    suser.LastLoginDate = user.LastLoginDate
                    suser.Comment = user.Comment

                    CurrentStore.Save()
                Else
                    Throw New ProviderException("User does not exist!")
                End If
            Catch
                Throw
            End Try
        End Sub

        Public Overloads Overrides Function ValidateUser(
            ByVal username As String,
            ByVal password As String
            ) As Boolean
            Try
                Dim user As SimpleUser =
                    CurrentStore.GetUserByName(username)
                If user Is Nothing Then
                    Return False
                End If

                If ValidateUserInternal(user, password) Then
                    user.LastLoginDate = DateTime.Now
                    user.LastActivityDate = DateTime.Now
                    CurrentStore.Save()
                    Return True
                Else
                    Return False
                End If
            Catch
                ' If an exception is raised while saving the storage
                ' or while serializing contents we just forward it to the
                ' caller. It would be cleaner to work with custom exception
                ' classes here and pass more detailed information to the caller
                ' but we leave as is for simplicity.
                Throw
            End Try
        End Function

        Public Overloads Overrides Function ChangePassword(
            ByVal username As String,
            ByVal oldPassword As String,
            ByVal newPassword As String
            ) As Boolean
            Try
                ' Get the user from the store 
                Dim user As SimpleUser =
                    CurrentStore.GetUserByName(username)
                If user Is Nothing Then
                    Throw New Exception("User does not exist!")
                End If

                If ValidateUserInternal(user, oldPassword) Then
                    ' Raise the event before validating the password 
                    MyBase.OnValidatingPassword(
                        New ValidatePasswordEventArgs(
                            username, newPassword, False
                            )
                        )

                    If Not ValidatePassword(newPassword) Then
                        Throw New ArgumentException(
                            "Password doesn't meet password strength requirements!"
                            )
                    End If

                    user.PasswordSalt = String.Empty
                    user.Password =
                        TransformPassword(newPassword, user.PasswordSalt)
                    user.LastPasswordChangeDate = DateTime.Now
                    CurrentStore.Save()

                    Return True
                End If

                Return False
            Catch
                Throw
            End Try
        End Function

        Public Overloads Overrides Function ChangePasswordQuestionAndAnswer(
            ByVal username As String,
            ByVal password As String,
            ByVal newPasswordQuestion As String,
            ByVal newPasswordAnswer As String
            ) As Boolean
            Try
                ' Get the user from the store 
                Dim user As SimpleUser =
                    CurrentStore.GetUserByName(username)

                If ValidateUserInternal(user, password) Then
                    user.PasswordQuestion = newPasswordQuestion
                    user.PasswordAnswer = newPasswordAnswer
                    CurrentStore.Save()

                    Return True
                End If

                Return False
            Catch
                Throw
            End Try
        End Function

        Public Overrides Function FindUsersByEmail(
            ByVal emailToMatch As String,
            ByVal pageIndex As Integer,
            ByVal pageSize As Integer,
            <System.Runtime.InteropServices.Out()> ByRef totalRecords As Integer
            ) As MembershipUserCollection
            Try
                Dim matchingUsers As List(Of SimpleUser) =
                    CurrentStore.Users.FindAll(
                        Function(
                            user As SimpleUser
                                 ) user.Email.Equals(
                                 emailToMatch,
                                 StringComparison.OrdinalIgnoreCase
                                 )
                             )

                totalRecords = matchingUsers.Count
                Return CreateMembershipCollectionFromInternalList(matchingUsers)
            Catch
                ' If an exception is raised while saving the storage
                ' or while serializing contents we just forward it to the
                ' caller. It would be cleaner to work with custom exception
                ' classes here and pass more detailed information to the caller
                ' but we leave as is for simplicity.
                Throw
            End Try
        End Function

        Public Overrides Function FindUsersByName(
            ByVal usernameToMatch As String,
            ByVal pageIndex As Integer,
            ByVal pageSize As Integer,
            <System.Runtime.InteropServices.Out()> ByRef totalRecords As Integer
            ) As MembershipUserCollection
            Try
                Dim matchingUsers As List(Of SimpleUser) =
                    CurrentStore.Users.FindAll(
                        Function(
                            user As SimpleUser
                                 ) user.UserName.Equals(
                                 usernameToMatch, StringComparison.OrdinalIgnoreCase
                                 )
                             )

                totalRecords = matchingUsers.Count
                Return CreateMembershipCollectionFromInternalList(matchingUsers)
            Catch
                Throw
            End Try
        End Function
        Public Overloads Overrides Function GetAllUsers(
            ByVal pageIndex As Integer,
            ByVal pageSize As Integer,
            ByRef totalRecords As Integer
            ) As MembershipUserCollection
            Try
                totalRecords = CurrentStore.Users.Count
                Return CreateMembershipCollectionFromInternalList(CurrentStore.Users)
            Catch
                Throw
            End Try
        End Function

        Public Overloads Overrides Function GetNumberOfUsersOnline(
            ) As Integer
            Dim ret As Integer = 0

            For Each user As SimpleUser In CurrentStore.Users
                If user.LastActivityDate.AddMinutes(
                    Membership.UserIsOnlineTimeWindow
                    ) >= DateTime.Now Then
                    ret += 1
                End If
            Next

            Return ret
        End Function

        Public Overloads Overrides Function GetPassword(
            ByVal username As String,
            ByVal answer As String
            ) As String
            Try
                If EnablePasswordRetrieval Then
                    Dim user As SimpleUser = CurrentStore.GetUserByName(username)

                    If answer.Equals(user.PasswordAnswer, StringComparison.OrdinalIgnoreCase) Then
                        Return user.Password
                    Else
                        Throw New System.Web.Security.MembershipPasswordException()
                    End If
                Else
                    Throw New Exception("Password retrieval is not enabled!")
                End If
            Catch
                Throw
            End Try
        End Function

        Public Overloads Overrides Function ResetPassword(
            ByVal username As String,
            ByVal answer As String
            ) As String
            Try
                Dim user As SimpleUser =
                    CurrentStore.GetUserByName(username)
                If user.PasswordAnswer.Equals(
                    answer,
                    StringComparison.OrdinalIgnoreCase
                    ) Then
                    Dim NewPassword As Byte() = New Byte(15) {}
                    Dim rng As RandomNumberGenerator =
                        RandomNumberGenerator.Create()
                    rng.GetBytes(NewPassword)

                    Dim NewPasswordString As String =
                        Convert.ToBase64String(NewPassword)
                    user.PasswordSalt = String.Empty
                    user.Password =
                        TransformPassword(NewPasswordString, user.PasswordSalt)
                    CurrentStore.Save()

                    Return NewPasswordString
                Else
                    Throw New Exception("Invalid answer entered!")
                End If
            Catch
                Throw
            End Try
        End Function

        Public Overloads Overrides Function UnlockUser(
            ByVal userName As String
            ) As Boolean
            ' This provider doesn't support locking 
            Return True
        End Function

#End Region

#Region "Private Helper Methods"

        Private Function TransformPassword(
            ByVal password As String,
            ByRef salt As String
            ) As String
            Dim ret As String = String.Empty

            Select Case PasswordFormat
                Case MembershipPasswordFormat.Clear
                    ret = password
                    Exit Select
                Case MembershipPasswordFormat.Hashed
                    ' Generate the salt if not passed in 
                    If String.IsNullOrEmpty(salt) Then
                        Dim saltBytes As Byte() = New Byte(15) {}
                        Dim rng As RandomNumberGenerator =
                            RandomNumberGenerator.Create()
                        rng.GetBytes(saltBytes)
                        salt = Convert.ToBase64String(saltBytes)
                    End If
                    ret = FormsAuthentication.HashPasswordForStoringInConfigFile(
                        (salt & password),
                        "SHA1"
                        )
                    Exit Select
                Case MembershipPasswordFormat.Encrypted

                    Dim ClearText As Byte() =
                        Encoding.UTF8.GetBytes(password)
                    Dim EncryptedText As Byte() =
                        MyBase.EncryptPassword(ClearText)
                    ret = Convert.ToBase64String(EncryptedText)
                    Exit Select
            End Select

            Return ret
        End Function

        Private Function ValidateUsername(
            ByVal userName As String,
            ByVal email As String,
            ByVal excludeKey As Guid
            ) As Boolean
            Dim IsValid As Boolean = True

            Dim store As UserStore = UserStore.GetStore(_FileName)
            For Each user As SimpleUser In store.Users
                If user.UserKey.CompareTo(excludeKey) <> 0 Then
                    If String.Equals(
                        user.UserName,
                        userName,
                        StringComparison.OrdinalIgnoreCase
                        ) Then
                        IsValid = False
                        Exit For
                    End If

                    If String.Equals(
                        user.Email,
                        email,
                        StringComparison.OrdinalIgnoreCase
                        ) Then
                        IsValid = False
                        Exit For
                    End If
                End If
            Next

            Return IsValid
        End Function

        Private Function ValidatePassword(
            ByVal password As String
            ) As Boolean
            Dim IsValid As Boolean = True
            Dim HelpExpression As Regex

            ' Validate simple properties 
            IsValid = IsValid AndAlso
                (password.Length >=
                 Me.MinRequiredPasswordLength)
            ' Validate non-alphanumeric characters 
            HelpExpression = New Regex("\W")
            IsValid = IsValid AndAlso
                (HelpExpression.Matches(password).Count >=
                 Me.MinRequiredNonAlphanumericCharacters)
            ' Validate regular expression 
            HelpExpression =
                New Regex(Me.PasswordStrengthRegularExpression)
            IsValid = IsValid AndAlso
                (HelpExpression.Matches(password).Count > 0)
            Return IsValid
        End Function

        Private Function ValidateUserInternal(
            ByVal user As SimpleUser, ByVal password As String
            ) As Boolean
            If user IsNot Nothing Then
                Dim passwordValidate As String =
                    TransformPassword(password, user.PasswordSalt)
                If String.Compare(passwordValidate, user.Password) = 0 Then
                    Return True
                End If
            End If

            Return False
        End Function

        Private Function CreateMembershipFromInternalUser(
            ByVal user As SimpleUser
            ) As MembershipUser
            Dim muser As New MembershipUser(
                MyBase.Name,
                user.UserName,
                user.UserKey,
                user.Email,
                user.PasswordQuestion,
                String.Empty,
                True,
                False,
                user.CreationDate,
                user.LastLoginDate,
                user.LastActivityDate,
                user.LastPasswordChangeDate,
                DateTime.MaxValue
                )
            Return muser
        End Function

        Private Function CreateMembershipCollectionFromInternalList(
            ByVal users As List(Of SimpleUser)
            ) As MembershipUserCollection
            Dim ReturnCollection As New MembershipUserCollection()

            For Each user As SimpleUser In users
                ReturnCollection.Add(CreateMembershipFromInternalUser(user))
            Next

            Return ReturnCollection
        End Function

        Private Function TransformPassword(
            ByVal password As String
            ) As String
            Dim ret As String = String.Empty

            Select Case PasswordFormat
                Case MembershipPasswordFormat.Clear
                    ret = password
                    Exit Select
                Case MembershipPasswordFormat.Hashed
                    ret =
                        FormsAuthentication.HashPasswordForStoringInConfigFile(
                            password, "SHA1"
                            )
                    Exit Select
                Case MembershipPasswordFormat.Encrypted
                    Dim ClearText As Byte() =
                        Encoding.UTF8.GetBytes(password)
                    Dim EncryptedText As Byte() =
                        MyBase.EncryptPassword(ClearText)
                    ret = Convert.ToBase64String(EncryptedText)
                    Exit Select
            End Select

            Return ret
        End Function





#End Region
    End Class
End Namespace
