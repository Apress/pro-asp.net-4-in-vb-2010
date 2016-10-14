Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Web.Configuration
Imports System.Collections.Generic
Imports System.ComponentModel

Namespace DatabaseComponent
    <DataObject()>
    Public Class EmployeeDB
        Private connectionString As String

        Public Sub New()
            ' Get connection string from web.config. 
            connectionString =
                WebConfigurationManager.ConnectionStrings("Northwind").ConnectionString
        End Sub
        Public Sub New(ByVal connectionString As String)
            Me.connectionString = connectionString
        End Sub

        <DataObjectMethod(DataObjectMethodType.Insert, True)>
        Public Function InsertEmployee(
            ByVal emp As EmployeeDetails
            ) As Integer
            Dim con As New SqlConnection(connectionString)
            Dim cmd As New SqlCommand("InsertEmployee", con)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.Add(New SqlParameter("@FirstName", SqlDbType.NVarChar, 10))
            cmd.Parameters("@FirstName").Value = emp.FirstName
            cmd.Parameters.Add(New SqlParameter("@LastName", SqlDbType.NVarChar, 20))
            cmd.Parameters("@LastName").Value = emp.LastName
            cmd.Parameters.Add(New SqlParameter("@TitleOfCourtesy", SqlDbType.NVarChar, 25))
            cmd.Parameters("@TitleOfCourtesy").Value = emp.TitleOfCourtesy
            cmd.Parameters.Add(New SqlParameter("@EmployeeID", SqlDbType.Int, 4))
            cmd.Parameters("@EmployeeID").Direction = ParameterDirection.Output

            Try
                con.Open()
                cmd.ExecuteNonQuery()
                Return CInt(cmd.Parameters("@EmployeeID").Value)
            Catch err As SqlException
                ' Replace the error with something less specific. 
                ' You could also log the error now. 
                Throw New ApplicationException("Data error.")
            Finally
                con.Close()
            End Try
        End Function

        <DataObjectMethod(DataObjectMethodType.Update, True)> _
        Public Sub UpdateEmployee(ByVal emp As EmployeeDetails)
            Dim con As New SqlConnection(connectionString)
            Dim cmd As New SqlCommand("UpdateEmployee", con)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.Add(New SqlParameter("@FirstName", SqlDbType.NVarChar, 10))
            cmd.Parameters("@FirstName").Value = emp.FirstName
            cmd.Parameters.Add(New SqlParameter("@LastName", SqlDbType.NVarChar, 20))
            cmd.Parameters("@LastName").Value = emp.LastName
            cmd.Parameters.Add(New SqlParameter("@TitleOfCourtesy", SqlDbType.NVarChar, 25))
            cmd.Parameters("@TitleOfCourtesy").Value = emp.TitleOfCourtesy
            cmd.Parameters.Add(New SqlParameter("@EmployeeID", SqlDbType.Int, 4))
            cmd.Parameters("@EmployeeID").Value = emp.EmployeeID

            Try
                con.Open()
                cmd.ExecuteNonQuery()
            Catch err As SqlException
                ' Replace the error with something less specific. 
                ' You could also log the error now. 
                Throw New ApplicationException("Data error.")
            Finally
                con.Close()
            End Try
        End Sub

        <DataObjectMethod(DataObjectMethodType.Update, False)> _
        Public Sub UpdateEmployee(
            ByVal EmployeeID As Integer,
            ByVal firstName As String,
            ByVal lastName As String,
            ByVal titleOfCourtesy As String)
            Dim con As New SqlConnection(connectionString)
            Dim cmd As New SqlCommand("UpdateEmployee", con)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.Add(New SqlParameter("@FirstName", SqlDbType.NVarChar, 10))
            cmd.Parameters("@FirstName").Value = firstName
            cmd.Parameters.Add(New SqlParameter("@LastName", SqlDbType.NVarChar, 20))
            cmd.Parameters("@LastName").Value = lastName
            cmd.Parameters.Add(New SqlParameter("@TitleOfCourtesy", SqlDbType.NVarChar, 25))
            cmd.Parameters("@TitleOfCourtesy").Value = titleOfCourtesy
            cmd.Parameters.Add(New SqlParameter("@EmployeeID", SqlDbType.Int, 4))
            cmd.Parameters("@EmployeeID").Value = EmployeeID

            Try
                con.Open()
                cmd.ExecuteNonQuery()
            Catch err As SqlException
                ' Replace the error with something less specific. 
                ' You could also log the error now. 
                Throw New ApplicationException("Data error.")
            Finally
                con.Close()
            End Try
        End Sub

        ' Variant used for testing ObjectDataSourceUpdate2.aspx. 
        <DataObjectMethod(DataObjectMethodType.Update, False)> _
        Public Sub UpdateEmployee(ByVal firstName As String, ByVal lastName As String, ByVal titleOfCourtesy As String, ByVal ID As Integer)
            ' Just send the call to our standard method. 
            UpdateEmployee(ID, firstName, lastName, titleOfCourtesy)
        End Sub

        <DataObjectMethod(DataObjectMethodType.Delete, True)> _
        Public Sub DeleteEmployee(ByVal employeeID As Integer)
            Dim con As New SqlConnection(connectionString)
            Dim cmd As New SqlCommand("DeleteEmployee", con)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.Add(New SqlParameter("@EmployeeID", SqlDbType.Int, 4))
            cmd.Parameters("@EmployeeID").Value = employeeID

            Try
                con.Open()
                cmd.ExecuteNonQuery()
            Catch err As SqlException
                ' Replace the error with something less specific. 
                ' You could also log the error now. 
                Throw New ApplicationException("Data error.")
            Finally
                con.Close()
            End Try
        End Sub

        <DataObjectMethod(DataObjectMethodType.Delete, False)> _
        Public Sub DeleteEmployee(ByVal emp As EmployeeDetails)
            DeleteEmployee(emp.EmployeeID)
        End Sub

        <DataObjectMethod(DataObjectMethodType.[Select], False)> _
        Public Function GetEmployee(
            ByVal employeeID As Integer
            ) As EmployeeDetails
            Dim con As New SqlConnection(connectionString)
            Dim cmd As New SqlCommand("GetEmployee", con)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.Add(New SqlParameter("@EmployeeID", SqlDbType.Int, 4))
            cmd.Parameters("@EmployeeID").Value = employeeID

            Try
                con.Open()
                Dim reader As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleRow)

                ' Get the first row. 
                reader.Read()
                Dim emp As New EmployeeDetails(CInt(reader("EmployeeID")), DirectCast(reader("FirstName"), String), DirectCast(reader("LastName"), String), DirectCast(reader("TitleOfCourtesy"), String))
                reader.Close()
                Return emp
            Catch err As SqlException
                ' Replace the error with something less specific. 
                ' You could also log the error now. 
                Throw New ApplicationException("Data error.")
            Finally
                con.Close()
            End Try
        End Function

        <DataObjectMethod(DataObjectMethodType.[Select], True)> _
        Public Function GetEmployees() As List(Of EmployeeDetails)
            Dim con As New SqlConnection(connectionString)
            Dim cmd As New SqlCommand("GetAllEmployees", con)
            cmd.CommandType = CommandType.StoredProcedure

            ' Create a collection for all the employee records. 
            Dim employees As New List(Of EmployeeDetails)()

            Try
                con.Open()
                Dim reader As SqlDataReader = cmd.ExecuteReader()

                While reader.Read()
                    Dim emp As New EmployeeDetails(
                        CInt(reader("EmployeeID")),
                        DirectCast(reader("FirstName"), String),
                        DirectCast(reader("LastName"), String),
                        DirectCast(reader("TitleOfCourtesy"), String))
                    employees.Add(emp)
                End While
                reader.Close()
                Return employees
            Catch err As SqlException
                ' Replace the error with something less specific. 
                ' You could also log the error now. 
                ' Throw New ApplicationException("Data error.")
            Finally
                con.Close()
            End Try
        End Function

        Public Function CountEmployees() As Integer
            Dim con As New SqlConnection(connectionString)
            Dim cmd As New SqlCommand("CountEmployees", con)
            cmd.CommandType = CommandType.StoredProcedure

            Try
                con.Open()
                Return CInt(cmd.ExecuteScalar())
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
