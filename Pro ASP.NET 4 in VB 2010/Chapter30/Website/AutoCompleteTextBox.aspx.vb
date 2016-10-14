Imports System.Data.SqlClient
Imports System.Web.Configuration

Partial Class AutoCompleteTextBox
    Inherits System.Web.UI.Page
    <System.Web.Services.WebMethod()>
    <System.Web.Script.Services.ScriptMethod()>
    Public Shared Function GetNames(
        ByVal prefixText As String, ByVal count As Integer
        ) As List(Of String)
        Dim names As List(Of String) = Nothing

        ' Check if the list is in the cache.
        If HttpContext.Current.Cache("NameList") Is Nothing Then
            ' If not, regenerate the list. The ADO.NET code for this part
            ' isn't shown (but you can see it in the downloadable examples
            ' for this chapter.
            names = GetNameListFromDB()

            ' Store the name list in the cache for sixty minutes.
            HttpContext.Current.Cache.Insert("NameList", names, Nothing, DateTime.Now.AddMinutes(60), TimeSpan.Zero)
        Else
            ' Get the name list out of the cache.
            names = DirectCast(HttpContext.Current.Cache("NameList"), List(Of String))
        End If

        Dim index As Integer = -1
        For i As Integer = 0 To names.Count - 1
            ' Check if this is a suitable match.
            If names(i).StartsWith(prefixText, StringComparison.InvariantCultureIgnoreCase) Then
                index = i
                Exit For
            End If
        Next

        ' Give up if there isn't a match.
        If index = -1 Then
            Return New List(Of String)()
        End If

        Dim wordList As New List(Of String)()
        For i As Integer = index To (index + count) - 1
            ' Stop if the end of the list is reached.
            If i >= names.Count Then
                Exit For
            End If

            ' Stop if the names stop matching.
            If Not names(i).StartsWith(
                prefixText, StringComparison.InvariantCultureIgnoreCase
                ) Then
                Exit For
            End If

            wordList.Add(names(i))
        Next

        Return wordList
    End Function

    Private Shared Function GetNameListFromDB() As List(Of String)
        Dim connectionString As String =
            WebConfigurationManager.ConnectionStrings("Northwind").ConnectionString
        Dim con As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand("SELECT ContactName FROM Customers ORDER BY ContactName", con)

        Dim names As New List(Of String)()

        Try
            con.Open()
            Dim reader As SqlDataReader = cmd.ExecuteReader()

            While reader.Read()
                names.Add(DirectCast(reader("ContactName"), String))
            End While
            reader.Close()

            Return names
        Finally
            con.Close()
        End Try
    End Function

End Class
