Imports System.Drawing
Imports System.Drawing.Drawing2D

Partial Class GradientView
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        ' Create the in-memory bitmap.
        Dim image As New Bitmap(300, 300)
        Dim g As Graphics = Graphics.FromImage(image)
        ' Paint the background.
        g.FillRectangle(Brushes.White, 0, 0, 300, 300)
        ' Show a rectangle with each type of gradient.
        Dim myBrush As LinearGradientBrush
        Dim y As Integer = 20
        For Each gradientStyle As LinearGradientMode _
            In System.[Enum].GetValues(GetType(LinearGradientMode))
            ' Configure the brush.
            myBrush = New LinearGradientBrush(
                New Rectangle(20, y, 100, 60),
                Color.Violet,
                Color.White,
                gradientStyle
                )
            ' Draw a small rectangle and add a text label.
            g.FillRectangle(myBrush, 20, y, 100, 60)
            g.DrawString(
                gradientStyle.ToString(),
                New Font("Tahoma", 8),
                Brushes.Black, 130, y + 20)
            ' Move to the next line.
            y += 70
        Next
        ' Render the image to the output stream.
        image.Save(
            Response.OutputStream,
            System.Drawing.Imaging.ImageFormat.Jpeg
            )
        g.Dispose()
        image.Dispose()
    End Sub
End Class
