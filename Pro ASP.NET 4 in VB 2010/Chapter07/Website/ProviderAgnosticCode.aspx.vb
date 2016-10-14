Imports System.Web.Configuration
Imports System.Data.Common
Imports System.Collections

Partial Class ProviderAgnosticCode
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        ' Get the factory. 
        Dim factory As String =
            WebConfigurationManager.AppSettings("factory")
        Dim provider As DbProviderFactory =
            DbProviderFactories.GetFactory(factory)

        ' Use this factory to create a connection. 
        Dim con As DbConnection = provider.CreateConnection()
        con.ConnectionString =
            WebConfigurationManager.ConnectionStrings("Northwind").ConnectionString

        ' Create the command. 
        Dim cmd As DbCommand =
            provider.CreateCommand()
        cmd.CommandText =
            WebConfigurationManager.AppSettings("employeeQuery")
        cmd.Connection = con

        ' Open the Connection and get the DataReader. 
        con.Open()
        Dim reader As DbDataReader = cmd.ExecuteReader()

        ' Cycle through the records, and build the HTML string. 
        Dim htmlStr As New StringBuilder("")
        While reader.Read()
            htmlStr.Append("<li>")
            htmlStr.Append(reader("TitleOfCourtesy"))
            htmlStr.Append(" <b>")
            htmlStr.Append(reader.GetString(1))
            htmlStr.Append("</b>, ")
            htmlStr.Append(reader.GetString(2))
            htmlStr.Append(" - employee from ")
            htmlStr.Append(reader.GetDateTime(6).ToString("d"))
            htmlStr.Append("</li>")
        End While

        ' Close the DataReader and the Connection. 
        reader.Close()
        con.Close()

        ' Show the generated HTML code on the page. 
        HtmlContent.Text = htmlStr.ToString()
    End Sub
End Class
