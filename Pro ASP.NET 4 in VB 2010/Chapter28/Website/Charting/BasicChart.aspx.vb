Imports System.Drawing
Imports System.Web.UI.DataVisualization.Charting

Partial Public Class Charting_BasicChart
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As EventArgs
        ) Handles Me.Load

        ' format the chart
        Chart1.BackColor = Color.Gray
        Chart1.BackSecondaryColor = Color.WhiteSmoke
        Chart1.BackGradientStyle = GradientStyle.DiagonalRight
        Chart1.BorderlineDashStyle = ChartDashStyle.Solid
        Chart1.BorderlineColor = Color.Gray
        Chart1.BorderSkin.SkinStyle = BorderSkinStyle.Emboss
        ' format the chart area
        Chart1.ChartAreas(0).BackColor = Color.Wheat
        ' add and format the title
        Chart1.Titles.Add("ASP.NET Chart")
        Chart1.Titles(0).Font = New Font("Utopia", 16)

        ' For 3D Chart
        Chart1.ChartAreas(0).Area3DStyle.Enable3D = True

        Chart1.Series.Add(
            New Series("ColumnSeries") With
                {.ChartType = SeriesChartType.Column})
        Chart1.Series.Add(
            New Series("SplineSeries") With
                {.ChartType = SeriesChartType.Spline,
                 .borderWidth = 3, .ShadowOffset = 2,
                 .color = Color.PaleVioletRed
                }
            )
        Chart1.Series(0).Points.DataBindY(
            New Integer() {5, 3, 12, 14, 11, 7, 3, 5, 9, 12, 11, 10}
            )
        Chart1.Series(1).Points.DataBindY(
            New Integer() {3, 7, 13, 2, 7, 15, 23, 20, 1, 5, 7, 6}
            )

        ' To chart in two areas
        'Chart1.ChartAreas.Add("SecondArea")
        'Chart1.Series(1).ChartArea = "SecondArea"
    End Sub
End Class
