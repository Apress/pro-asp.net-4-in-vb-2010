Imports System.Data.Common
Imports System.Data
Imports System.Data.SqlClient
''' <summary> 
''' Summary description for SqlSiteMapProvider 
''' </summary> 
Public Class SqlSiteMapProvider
    Inherits StaticSiteMapProvider

    ' Track the connection string, provider name, and stored procedure name. 
    Private connectionString As String
    Private providerName As String
    Private storedProcedure As String
    'Private cacheTime As Integer
    Private initialized As Boolean = False
    Public Overloads Overrides Sub Initialize(
        ByVal name As String,
        ByVal attributes As System.Collections.Specialized.NameValueCollection
        )
        If Not IsInitialized Then
            MyBase.Initialize(name, attributes)

            ' Retrieve the web.config settings. 
            providerName = attributes("providerName")
            connectionString = attributes("connectionString")
            storedProcedure = attributes("storedProcedure")
            'cacheTime = Int32.Parse(attributes("cacheTime"))

            If [String].IsNullOrEmpty(providerName) Then
                Throw New ArgumentException("The provider name was not found.")
            ElseIf [String].IsNullOrEmpty(connectionString) Then
                Throw New ArgumentException("The connection string was not found.")
            ElseIf [String].IsNullOrEmpty(storedProcedure) Then
                Throw New ArgumentException("The stored procedure name was not found.")
            End If

            initialized = True
        End If
    End Sub

    Public Overridable ReadOnly Property IsInitialized() As Boolean
        Get
            Return initialized
        End Get
    End Property
    Public Overloads Overrides Function BuildSiteMap() As SiteMapNode
        Dim rootNode As SiteMapNode

        ' Since the class is exposed to multiple pages, 
        ' use locking to make sure that the site map is not  
        ' rebuilt by more than one page at the same time. 
        SyncLock Me
            rootNode =
                TryCast(HttpContext.Current.Cache("rootNode"), SiteMapNode)
            ' Don't rebuild the map unless needed.
            ' If your site map changes often, consider using caching.
            If rootNode Is Nothing Then
                ' Start with a clean slate.
                Clear()

                ' Get all the data (using provider-agnostic code). 
                Dim provider As DbProviderFactory =
                    DbProviderFactories.GetFactory(providerName)

                ' Use this factory to create a connection. 
                Dim con As DbConnection = provider.CreateConnection()
                con.ConnectionString = connectionString

                ' Create the command. 
                Dim cmd As DbCommand = provider.CreateCommand()
                cmd.CommandText = storedProcedure
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Connection = con

                ' Creat the DataAdapter. 
                Dim adapter As DbDataAdapter = provider.CreateDataAdapter()
                adapter.SelectCommand = cmd

                ' Get the results in a DataSet 
                ' (a DataReader won't work because we need back-and-forth 
                ' navigation). 
                ' (Error handling code would be appropriate here.) 
                Dim ds As New DataSet()
                adapter.Fill(ds, "SiteMap")
                Dim dtSiteMap As DataTable = ds.Tables("SiteMap")

                ' Now navigate the DataSet to create the SiteMap. 
                ' We won't check for all the possible error conditions 
                ' (like duplicate root nodes). 

                ' Get the root node. 
                Dim rowRoot As DataRow =
                    dtSiteMap.[Select]("ParentID IS NULL")(0)

                rootNode =
                    New SiteMapNode(
                        Me,
                        rowRoot("Url").ToString(),
                        rowRoot("Url").ToString(),
                        rowRoot("Title").ToString(),
                        rowRoot("Description").ToString()
                        )
                Dim rootID As String = rowRoot("ID").ToString()
                AddNode(rootNode)

                ' Fill down the hierarchy. 
                AddChildren(rootNode, rootID, dtSiteMap)

                'HttpContext.Current.Cache.Insert(
                '     "rootNode",
                '     rootNode,
                '     Nothing,
                '     DateTime.Now.AddSeconds(cacheTime),
                '     TimeSpan.Zero
                '     )
            End If
        End SyncLock
        Return rootNode
    End Function


    Private Sub AddChildren(
        ByVal rootNode As SiteMapNode,
        ByVal rootID As String,
        ByVal dtSiteMap As DataTable
        )
        Dim childRows As DataRow() =
            dtSiteMap.[Select]("ParentID = " & rootID)
        For Each row As DataRow In childRows
            Dim childNode As New SiteMapNode(
                Me,
                row("Url").ToString(),
                row("Url").ToString(),
                row("Title").ToString(),
                row("Description").ToString()
                )
            Dim rowID As String = row("ID").ToString()

            ' Use the SiteMapNode AddNode method to add 
            ' the SiteMapNode to the ChildNodes collection. 
            AddNode(childNode, rootNode)

            ' Check for children in this node. 
            AddChildren(childNode, rowID, dtSiteMap)
        Next
    End Sub

    Protected Overloads Overrides Function GetRootNodeCore() As SiteMapNode
        Return BuildSiteMap()
    End Function

    Public Overloads Overrides ReadOnly Property RootNode() As SiteMapNode
        Get
            Return BuildSiteMap()
        End Get
    End Property

    Protected Overloads Overrides Sub Clear()
        SyncLock Me
            'HttpContext.Current.Cache.Remove("rootNode")
            MyBase.Clear()
        End SyncLock
    End Sub

End Class