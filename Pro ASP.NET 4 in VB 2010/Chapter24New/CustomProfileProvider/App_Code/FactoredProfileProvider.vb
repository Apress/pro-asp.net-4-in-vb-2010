Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.Profile

Public Class FactoredProfileProvider
    Inherits ProfileProvider
    Private m_name As String
    Public Overloads Overrides ReadOnly Property Name() As String
        Get
            Return m_name
        End Get
    End Property

    Private m_connectionString As String
    Public ReadOnly Property ConnectionString() As String
        Get
            Return m_connectionString
        End Get
    End Property

    Private updateProcedure As String
    Public ReadOnly Property UpdateUserProcedure() As String
        Get
            Return updateProcedure
        End Get
    End Property

    Private getProcedure As String
    Public ReadOnly Property GetUserProcedure() As String
        Get
            Return getProcedure
        End Get
    End Property

    ' System.Configuration.Provider.ProviderBase.Initialize Method 
    Public Overloads Overrides Sub Initialize(
        ByVal name As String, ByVal config As NameValueCollection
        )
        ' Initialize values from web.config. 
        Me.m_name = name

        Dim connectionStringSettings As ConnectionStringSettings =
            ConfigurationManager.ConnectionStrings(config("connectionStringName"))
        If connectionStringSettings Is Nothing OrElse
            connectionStringSettings.ConnectionString.Trim() = "" Then
            Throw New HttpException("You must supply a connection string.")
        Else
            m_connectionString = connectionStringSettings.ConnectionString
        End If

        updateProcedure = config("updateUserProcedure")
        If updateProcedure.Trim() = "" Then
            Throw New HttpException(
                "You must specify a stored procedure to use for updates."
                )
        End If

        getProcedure = config("getUserProcedure")
        If getProcedure.Trim() = "" Then
            Throw New HttpException(
                "You must specify a stored procedure to use for retrieving individual user records."
                )
        End If
    End Sub

    Public Overloads Overrides Function DeleteProfiles(ByVal usernames As String()) As Integer
        Throw New Exception("The method or operation is not implemented.")
    End Function

    Public Overloads Overrides Function DeleteProfiles(ByVal profiles As ProfileInfoCollection) As Integer
        Throw New Exception("The method or operation is not implemented.")
    End Function

    Public Overloads Overrides Function DeleteInactiveProfiles(ByVal authenticationOption As ProfileAuthenticationOption, ByVal userInactiveSinceDate As DateTime) As Integer
        Throw New Exception("The method or operation is not implemented.")
    End Function

    Public Overloads Overrides Function FindInactiveProfilesByUserName(ByVal authenticationOption As ProfileAuthenticationOption, ByVal usernameToMatch As String, ByVal userInactiveSinceDate As DateTime, ByVal pageIndex As Integer, ByVal pageSize As Integer, ByRef totalRecords As Integer) As ProfileInfoCollection
        Throw New Exception("The method or operation is not implemented.")
    End Function

    Public Overloads Overrides Function FindProfilesByUserName(ByVal authenticationOption As ProfileAuthenticationOption, ByVal usernameToMatch As String, ByVal pageIndex As Integer, ByVal pageSize As Integer, ByRef totalRecords As Integer) As ProfileInfoCollection
        Throw New Exception("The method or operation is not implemented.")
    End Function

    Public Overloads Overrides Function GetAllInactiveProfiles(ByVal authenticationOption As ProfileAuthenticationOption, ByVal userInactiveSinceDate As DateTime, ByVal pageIndex As Integer, ByVal pageSize As Integer, ByRef totalRecords As Integer) As ProfileInfoCollection
        Throw New Exception("The method or operation is not implemented.")
    End Function

    Public Overloads Overrides Function GetAllProfiles(ByVal authenticationOption As ProfileAuthenticationOption, ByVal pageIndex As Integer, ByVal pageSize As Integer, ByRef totalRecords As Integer) As ProfileInfoCollection
        Throw New Exception("The method or operation is not implemented.")
    End Function

    Public Overloads Overrides Function GetNumberOfInactiveProfiles(ByVal authenticationOption As ProfileAuthenticationOption, ByVal userInactiveSinceDate As DateTime) As Integer
        Throw New Exception("The method or operation is not implemented.")
    End Function

    Public Overloads Overrides Property ApplicationName() As String
        Get
            Throw New Exception("The method or operation is not implemented.")
        End Get
        Set(ByVal value As String)
            Throw New Exception("The method or operation is not implemented.")
        End Set
    End Property

    Public Overloads Overrides Function GetPropertyValues(
        ByVal context As SettingsContext, ByVal properties As SettingsPropertyCollection
        ) As SettingsPropertyValueCollection
        ' If you want to mimic the behavior of the SqlProfileProvider, 
        ' you should also update the database with the last activity time 
        ' whenever this method is called. 

        ' This collection will store the retrieved values. 
        Dim values As New SettingsPropertyValueCollection()

        ' Prepare the command. 
        ' The only non-configurable assumption in this code is 
        ' that the stored procedure accepts a parameter named 
        ' @UserName. You could add additional configuration attributes 
        ' to make this detail configurable. 
        Dim con As New SqlConnection(m_connectionString)
        Dim cmd As New SqlCommand(getProcedure, con)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add(New SqlParameter(
            "@UserName", DirectCast(context("UserName"), String))
        )

        Try
            con.Open()
            Dim reader As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleRow)

            ' Get the first row. 
            reader.Read()

            ' Look for every requested value. 
            For Each [property] As SettingsProperty In properties
                Dim value As New SettingsPropertyValue([property])

                ' Non-matching users are allowed 
                ' (properties are kept, but no values are added). 
                If reader.HasRows Then
                    value.PropertyValue = reader([property].Name)
                End If
                values.Add(value)
            Next
            reader.Close()
        Finally
            con.Close()
        End Try

        Return values
    End Function

    Public Overloads Overrides Sub SetPropertyValues(
        ByVal context As SettingsContext, ByVal values As SettingsPropertyValueCollection
        )
        ' If you want to mimic the behavior of the SqlProfileProvider, 
        ' you should also update the database with the last update time 
        ' whenever this method is called. 

        ' Prepare the command. 
        Dim con As New SqlConnection(m_connectionString)
        Dim cmd As New SqlCommand(updateProcedure, con)
        cmd.CommandType = CommandType.StoredProcedure

        ' Add the parameters. 
        ' The assumption is that every property maps exactly 
        ' to a single stored procedure parameter name. 
        For Each value As SettingsPropertyValue In values
            ' You could check value.IsDirty here and only save 
            ' the record if at least one value has changed. 

            cmd.Parameters.Add(New SqlParameter(value.Name, value.PropertyValue))
        Next
        ' Again, this code assumes the stored procedure accepts a parameter named 
        ' @UserName. 
        cmd.Parameters.Add(
            New SqlParameter(
                "@UserName", DirectCast(context("UserName"), String)
                )
            )

        ' Execute the command. 
        Try
            con.Open()
            cmd.ExecuteNonQuery()
        Finally
            con.Close()
        End Try
    End Sub
End Class