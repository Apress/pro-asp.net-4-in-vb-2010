Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Data.SqlClient
Imports System.Web.Configuration

Namespace DatabaseComponent
    Public Class ProductDB
        Private connectionString As String

        Public Sub New()
            ' Get connection string from web.config.
            connectionString = WebConfigurationManager.ConnectionStrings("Northwind").ConnectionString
        End Sub
        Public Sub New(ByVal connectionString As String)
            Me.connectionString = connectionString
        End Sub

        Public Function GetProducts() As List(Of ProductDetails)
            Dim con As New SqlConnection(connectionString)
            Dim cmd As New SqlCommand("SELECT * FROM Products", con)

            ' Create a collection for all the employee records.
            Dim products As List(Of ProductDetails) = New List(Of ProductDetails)()

            Try
                con.Open()
                Dim reader As SqlDataReader = cmd.ExecuteReader()

                Do While reader.Read()
                    Dim product As New ProductDetails(CInt(Fix(reader("ProductID"))), reader("ProductName").ToString(), reader("UnitPrice"), reader("CategoryID"))
                    products.Add(product)
                Loop
                reader.Close()

                Return products
            Catch err As SqlException
                ' Replace the error with something less specific.
                ' You could also log the error now.
                Throw New ApplicationException("Data error.")
            Finally
                con.Close()
            End Try
        End Function
    End Class
End Namespace