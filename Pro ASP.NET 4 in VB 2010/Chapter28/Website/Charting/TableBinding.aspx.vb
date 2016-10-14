Imports System.Drawing
Imports System.Web.UI.DataVisualization.Charting
Imports System.Data.SqlClient

Partial Class Charting_TableBinding
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
        Chart1.Titles.Add("Table Bound Chart")
        Chart1.Titles(0).Font = New Font("Utopia", 16)
        ' create the connection to the database
        Dim conn As New SqlConnection(ConfigurationManager.ConnectionStrings("Northwind").ConnectionString)

        ' define the command
        Dim command As New SqlCommand("SELECT TOP (5) ProductName, UnitsInStock " & "FROM Products WHERE (Discontinued = 'FALSE')", conn)

        ' open the command and create the reader
        command.Connection.Open()
        Dim reader As SqlDataReader = command.ExecuteReader()
        ' clear the chart series and bind to the table
        'Chart1.Series.Clear();
        'Chart1.DataBindTable(reader);
        'Chart1.Series["UnitsInStock"].ChartType = SeriesChartType.StackedBar;

        ' bind the X and Y values to the default series and format the chart
        Chart1.Series(0).Points.DataBindXY(reader, "ProductName", reader, "UnitsInStock")
        Chart1.Series(0).ChartType = SeriesChartType.StackedBar

        ' close the reader and the connection
        reader.Close()
        conn.Close()
    End Sub
End Class
