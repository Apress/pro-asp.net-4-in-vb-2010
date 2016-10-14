Imports System.Drawing
Imports System.Web.UI.DataVisualization.Charting

Partial Class ObjectAdapterBinding
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        ' format the chart
        Chart1.BackColor = Color.Gray
        Chart1.BackSecondaryColor = Color.WhiteSmoke
        Chart1.BackGradientStyle = GradientStyle.DiagonalRight

        Chart1.BorderlineDashStyle = ChartDashStyle.Solid
        Chart1.BorderSkin.SkinStyle = BorderSkinStyle.Emboss
        Chart1.BorderlineColor = Color.Gray

        ' format the chart area
        Chart1.ChartAreas(0).BackColor = Color.Wheat
        Chart1.ChartAreas(0).Area3DStyle.Enable3D = True

        ' add and format the title
        Chart1.Titles.Add("Table Object Adapter Chart")
        Chart1.Titles(0).Font = New Font("Utopia", 16)

        ' create the object data source
        Dim ds As New ObjectDataSource("MyObjectDataSource", "GetData")
        ' bind the source to the chart
        Chart1.DataSource = ds
        Chart1.Series(0).XValueMember = "Name"
        Chart1.Series(0).YValueMembers = "Popularity"

        ' format the series
        Chart1.Series(0).ChartType = SeriesChartType.Pie
    End Sub
End Class
