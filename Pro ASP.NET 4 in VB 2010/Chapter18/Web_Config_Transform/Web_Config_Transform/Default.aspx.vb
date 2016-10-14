' Add the Northwind database to the App_Data folder from the download
Imports System.Configuration

Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Label1.Text =
            ConfigurationManager.ConnectionStrings(
                "NorthwindConnectionString"
                ).ConnectionString
    End Sub
End Class