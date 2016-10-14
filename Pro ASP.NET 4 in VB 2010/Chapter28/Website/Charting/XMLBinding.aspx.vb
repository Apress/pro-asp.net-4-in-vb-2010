Imports System.Drawing
Imports System.Data
Imports System.Web.UI.DataVisualization.Charting
Partial Class Charting_XMLBinding
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
        Chart1.Titles.Add("XML Chart")
        Chart1.Titles(0).Font = New Font("Utopia", 16)

        ' format the data series
        Chart1.Series(0).ChartType = SeriesChartType.Radar

        ' define the path to the xml file
        Dim dataPath As String = MapPath(".") & "\sampledata.xml"

        ' create a DataSet and read the XML data
        Dim dataSet As New DataSet()
        dataSet.ReadXml(dataPath)
        ' create a DataView from the DataSet
        Dim dataView As New DataView(dataSet.Tables(0))
        ' bind the XML ata to the chart
        Chart1.Series(0).Points.DataBindXY(
            dataView, "Name", dataView, "Quantity"
            )
    End Sub
End Class
