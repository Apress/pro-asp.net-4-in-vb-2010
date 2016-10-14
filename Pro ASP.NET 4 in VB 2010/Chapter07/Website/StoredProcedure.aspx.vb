
Imports System.Web.Configuration
Imports System.Data.SqlClient
Imports System.Data
Partial Class StoredProcedure
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim connectionString As String =
    WebConfigurationManager.ConnectionStrings("Northwind").ConnectionString
        Dim con As SqlConnection = New SqlConnection(connectionString)
        ' Create the command for the InsertEmployee stored procedure.
        Dim cmd As SqlCommand = New SqlCommand("InsertEmployee", con)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add(
            New SqlParameter(
                "@TitleOfCourtesy", SqlDbType.NVarChar, 25))
        cmd.Parameters("@TitleOfCourtesy").Value = theTitle.Text
        cmd.Parameters.Add(
            New SqlParameter(
                "@LastName", SqlDbType.NVarChar, 20))
        cmd.Parameters("@LastName").Value = lastName.Text
        cmd.Parameters.Add(
            New SqlParameter(
                "@FirstName", SqlDbType.NVarChar, 10))
        cmd.Parameters("@FirstName").Value = firstName.Text

        cmd.Parameters.Add(
            New SqlParameter("@EmployeeID", SqlDbType.Int, 4))
        cmd.Parameters(
            "@EmployeeID").Direction = ParameterDirection.Output

        con.Open()
        Try
            Dim numAff As Integer = cmd.ExecuteNonQuery()
            HtmlContent.Text &= String.Format(
              "Inserted <b>{0}</b> record(s)<br />", numAff)

            ' Get the newly generated ID.
            Dim empID As Integer =
                DirectCast(cmd.Parameters("@EmployeeID").Value, Integer)
            HtmlContent.Text += "New ID: " & empID.ToString()
        Finally
            con.Close()
        End Try
    End Sub
End Class
