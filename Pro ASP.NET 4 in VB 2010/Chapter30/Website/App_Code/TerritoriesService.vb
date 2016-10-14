Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports System.Data

<System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class TerritoriesService
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function GetTerritoriesInRegion(
        ByVal regionID As Integer
        ) As List(Of Territory)
        Dim con As New SqlConnection(
            WebConfigurationManager.ConnectionStrings("Northwind").ConnectionString
            )
        Dim cmd As New SqlCommand(
            "SELECT * FROM Territories WHERE RegionID=@RegionID", con
            )
        ' To test the SQL Data Error Handling
        'Dim cmd As New SqlCommand(
        '    "SELECT * FROM George WHERE RegionID=@RegionID", con
        '    )
        cmd.Parameters.Add(New SqlParameter("@RegionID", SqlDbType.Int, 4))
        cmd.Parameters("@RegionID").Value = regionID

        Dim territories As New List(Of Territory)()
        Try
            con.Open()
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                territories.Add(
                    New Territory(
                        reader("TerritoryID").ToString(),
                        reader("TerritoryDescription").ToString())
                    )
            End While
            reader.Close()
        Catch err As SqlException
            ' Mask errors.
            Throw New ApplicationException("Data error.")
        Finally
            con.Close()
        End Try
        Return territories
    End Function
    Public Class Territory
        Public ID As String
        Public Description As String

        Public Sub New(ByVal id As String, ByVal description As String)
            Me.ID = id
            Me.Description = description
        End Sub

        Public Sub New()
        End Sub
    End Class
End Class