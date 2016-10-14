Imports System.Data
Namespace ADOHelpers
    Public Class ADOHelperFunctions
        Public Shared Sub ExecuteStatementInDb(ByVal cmd As String)
            Dim connection As String =
                "Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;"

            Dim sqlConn As New System.Data.SqlClient.SqlConnection(connection)

            If sqlConn.State <> ConnectionState.Open Then
                sqlConn.Open()
            End If

            Dim sqlComm As New System.Data.SqlClient.SqlCommand(cmd)

            sqlComm.Connection = sqlConn
            Try
                System.Diagnostics.Debug.WriteLine("Executing SQL statement against database with ADO.NET ...")
                sqlComm.ExecuteNonQuery()
                System.Diagnostics.Debug.WriteLine("Database updated.")
            Finally
                '  Close the connection.
                sqlComm.Connection.Close()
            End Try
        End Sub

        Public Shared Function GetStringFromDb(ByVal sqlQuery As String) As String

            Dim connection As String =
                "Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;"

            Dim sqlConn As New System.Data.SqlClient.SqlConnection(connection)


            If sqlConn.State <> ConnectionState.Open Then
                sqlConn.Open()
            End If

            Dim sqlCommand As New System.Data.SqlClient.SqlCommand(sqlQuery, sqlConn)

            Dim sqlDataReader As System.Data.SqlClient.SqlDataReader =
                sqlCommand.ExecuteReader()
            Dim result As String = Nothing

            Try
                If Not sqlDataReader.Read() Then
                    Throw (
                        New Exception([String].Format(
                            "Unexpected exception executing query [{0}].", sqlQuery)
                        )
                    )
                Else
                    If Not sqlDataReader.IsDBNull(0) Then
                        result = sqlDataReader.GetString(0)
                    End If
                End If
            Finally
                ' always call Close when done reading.
                sqlDataReader.Close()
                sqlConn.Close()
            End Try

            Return (result)
        End Function

    End Class
End Namespace
