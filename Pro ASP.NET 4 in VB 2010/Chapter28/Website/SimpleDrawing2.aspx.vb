Imports System.Drawing
Imports System.Drawing.Drawing2D

Partial Class SimpleDrawing2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        ' Create the in-memory bitmap where you will draw the image.
        ' This bitmap is 450 pixels wide and 100 pixels high.
        Dim image As New Bitmap(550, 150)
        Dim g As Graphics = Graphics.FromImage(image)

        ' Ensure high-quality curves.
        g.SmoothingMode = SmoothingMode.AntiAlias

        ' Paint the background.
        g.FillRectangle(Brushes.White, 0, 0, 550, 150)

        ' Add an ellipse.
        g.FillEllipse(Brushes.PaleGoldenrod, 120, 13, 360, 60)
        g.DrawEllipse(Pens.Green, 120, 13, 359, 59)

        ' Draw some text using a fancy font.
        Dim font As New Font(
            "Harrington", 20, FontStyle.Bold
            )
        g.DrawString(
            "Oranges are tasty!",
            font, Brushes.DarkOrange, 150, 20
            )

        ' Add a graphic from a file.
        Dim orangeImage As System.Drawing.Image =
            System.Drawing.Image.FromFile(Server.MapPath("oranges.gif"))
        g.DrawImageUnscaled(orangeImage, 0, 0)

        ' Render the image to the output stream.
        image.Save(
            Response.OutputStream,
            System.Drawing.Imaging.ImageFormat.Jpeg
            )

        ' Clean up.
        g.Dispose()
        image.Dispose()

    End Sub
End Class
