Imports System.Web.Configuration

Partial Class ReadConfiguration
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(
            ByVal sender As Object, ByVal e As System.EventArgs
            ) Handles Me.Load
        For Each connection As ConnectionStringSettings
            In WebConfigurationManager.ConnectionStrings
            Response.Write("Name: " & connection.Name & "<br />")
            Response.Write("Connection String: " &
                connection.ConnectionString & "<br /><br />")
        Next
        Dim config As Configuration =
            WebConfigurationManager.OpenWebConfiguration("/")
        Dim compSection As CompilationSection =
            DirectCast(config.GetSection(
                    "system.web/compilation"), CompilationSection)
        For Each assm As AssemblyInfo In compSection.Assemblies
            Response.Write(assm.Assembly & "<br /")
        Next
    End Sub
End Class
