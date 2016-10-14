﻿Imports System.Web.UI.DataVisualization.Charting
Imports System.Drawing
Imports NorthwindModel

Partial Class Charting_LINQBinding
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

        ' add and format the title
        Chart1.Titles.Add("LINQ Chart")
        Chart1.Titles(0).Font = New Font("Utopia", 16)

        ' add and format a new data series
        Chart1.Series.Add("StockLevel")
        Chart1.Series("StockLevel").ChartType = SeriesChartType.Spline
        Chart1.Series("StockLevel").BorderWidth = 3
        Chart1.Series("StockLevel").Color = Color.PaleVioletRed

        ' create a new EF context 
        Dim context As New NorthwindEntities()

        ' perform a query
        Dim data =
            context.Products.Where(
                Function(item) Not item.Discontinued
                    ).[Select](Function(item) item).Take(5)

        ' bind the default data series to the data
        Chart1.Series(0).Points.DataBind(
            data, "ProductName", "UnitPrice", ""
            )
        Chart1.Series(1).Points.DataBind(
            data, "ProductName", "UnitsInStock", ""
            )
    End Sub
End Class
