Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports System.Data

Partial Class ClientCallback
    Inherits System.Web.UI.Page
    Implements ICallbackEventHandler
    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        Dim callbackRef As String =
            Page.ClientScript.GetCallbackEventReference(
                Me,
                "document.getElementById('lstRegions').value",
                "ClientCallback", "null",
                True
                )
        lstRegions.Attributes("onChange") = callbackRef
    End Sub

    Protected Sub cmdOK_Click(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles cmdOK.Click
        ' The server-side control doesn't have the territory list, so
        ' you need to get the selected territory from the Request object.
        ' Remember to check for injection attacks if the Territories
        ' table contains sensitive data.
        lblInfo.Text = "You selected territory ID #" &
            Request.Form("lstTerritories")

        ' Reset the region list box 
        ' (because the territory list box will be empty).
        lstRegions.SelectedIndex = 0
    End Sub

    Private eventArgument As String
    Public Sub RaiseCallbackEvent(
        ByVal eventArgument As String
        ) Implements ICallbackEventHandler.RaiseCallbackEvent
        Me.eventArgument = eventArgument
    End Sub

    Public Function GetCallbackResult() As String _
        Implements ICallbackEventHandler.GetCallbackResult
        Dim con As New SqlConnection(
            WebConfigurationManager.ConnectionStrings("Northwind").ConnectionString
            )
        Dim cmd As New SqlCommand(
            "SELECT * FROM Territories WHERE RegionID=@RegionID", con
            )
        cmd.Parameters.Add(New SqlParameter("@RegionID", SqlDbType.Int, 4))
        cmd.Parameters("@RegionID").Value = Int32.Parse(eventArgument)

        Dim results As New StringBuilder()
        Try
            con.Open()
            Dim reader As SqlDataReader = cmd.ExecuteReader()

            While reader.Read()
                results.Append(reader("TerritoryDescription"))
                results.Append("|")
                results.Append(reader("TerritoryID"))
                results.Append("||")
            End While
            reader.Close()
            ' Hide errors.
        Catch err As SqlException
        Finally
            con.Close()
        End Try
        Return results.ToString()
    End Function
End Class
