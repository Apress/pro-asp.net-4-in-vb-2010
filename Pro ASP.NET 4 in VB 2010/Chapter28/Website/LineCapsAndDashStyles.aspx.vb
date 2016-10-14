Imports System.Drawing
Imports System.Drawing.Drawing2D

Partial Class LineCapsAndDashStyles
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        ' Create the in-memory bitmap where you will draw the image.
        ' This bitmap is 600 pixels wide and 400 pixels high.
        Dim image As New Bitmap(600, 400)
        Dim g As Graphics = Graphics.FromImage(image)
        ' Paint the background.
        g.FillRectangle(Brushes.White, 0, 0, 600, 400)
        ' Create a pen to use for all the examples.
        Dim myPen As New Pen(Color.Blue, 10)
        ' The y variable tracks the current y (up/down) position
        ' in the image.
        Dim y As Integer = 60
        ' Draw an example of each LineCap style in the first column (left).
        g.DrawString(
            "LineCap Choices",
            New Font("Tahoma", 15, FontStyle.Bold),
            Brushes.Blue, 0, 10
            )
        For Each cap As LineCap In System.[Enum].GetValues(GetType(LineCap))
            myPen.StartCap = cap
            myPen.EndCap = cap
            g.DrawLine(myPen, 20, y, 100, y)
            g.DrawString(
                cap.ToString(),
                New Font("Tahoma", 8),
                Brushes.Black, 120, y - 10
                )
            y += 30
        Next
        ' Draw an example of each DashStyle in the second column (right).
        y = 60
        g.DrawString(
            "DashStyle Choices",
            New Font("Tahoma", 15, FontStyle.Bold),
            Brushes.Blue, 250, 10
            )
        For Each dash As DashStyle In _
            System.[Enum].GetValues(GetType(DashStyle))
            ' Configure the pen.
            myPen.DashStyle = dash
            ' Draw a short line segment.
            g.DrawLine(myPen, 270, y, 300, y)
            ' Add a text label.
            g.DrawString(
                dash.ToString(),
                New Font("Tahoma", 8),
                Brushes.Black, 370, y - 10
                )
            ' Move down one line.
            y += 30
        Next
        ' Render the image to the output stream.
        image.Save(
            Response.OutputStream,
            System.Drawing.Imaging.ImageFormat.Gif
            )
        g.Dispose()
        image.Dispose()
    End Sub
End Class
