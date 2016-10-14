Imports TerritoriesService

Partial Public Class WebServiceCallback_PageMethods
    Inherits System.Web.UI.Page
    <System.Web.Services.WebMethod()>
    <System.Web.Script.Services.ScriptMethod()>
    Public Shared Function GetTerritoriesInRegion(
        ByVal regionID As Integer
        ) As List(Of Territory)
        ' Farm the work out to the web service class.
        Dim service As New TerritoriesService()
        Return service.GetTerritoriesInRegion(regionID)
    End Function
    Protected Sub cmdOK_Click(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles cmdOK.Click
        lblInfo.Text = "You selected territory ID #" &
            Request.Form("lstTerritories")
        lstRegions.SelectedIndex = 0
    End Sub
End Class

