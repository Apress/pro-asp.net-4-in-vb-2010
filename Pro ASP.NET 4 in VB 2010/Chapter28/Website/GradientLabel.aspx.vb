Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D

Partial Public Class GradientLabel
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As EventArgs
        )
        Dim text As String =
            Server.UrlDecode(Request.QueryString("Text"))
        Dim textSize As Integer =
            Int32.Parse(Request.QueryString("TextSize"))
        Dim textColor As Color =
            Color.FromArgb(Int32.Parse(Request.QueryString("TextColor")))
        Dim gradientColorStart As Color =
            Color.FromArgb(Int32.Parse(Request.QueryString("GradientColorStart")))
        Dim gradientColorEnd As Color =
            Color.FromArgb(Int32.Parse(Request.QueryString("GradientColorEnd")))

        ' Define the font.
        Dim font As New Font("Tahoma", textSize, FontStyle.Bold)

        ' Use a test image to measure the text.
        Dim image As New Bitmap(1, 1)
        Dim g As Graphics = Graphics.FromImage(image)
        Dim size As SizeF = g.MeasureString(text, font)
        g.Dispose()
        image.Dispose()

        ' Using these measurements, try to choose a reasonable bitmap size.
        ' If the text is large, cap the size at some maximum to
        ' prevent causing a serious server slowdown.
        Dim width As Integer =
            CInt(Math.Truncate(Math.Min(size.Width + 20, 800)))
        Dim height As Integer =
            CInt(Math.Truncate(Math.Min(size.Height + 20, 800)))
        image = New Bitmap(width, height)
        g = Graphics.FromImage(image)

        Dim brush As New LinearGradientBrush(
            New Rectangle(
                New Point(0, 0), image.Size
                ),
            gradientColorStart,
            gradientColorEnd,
            LinearGradientMode.ForwardDiagonal
            )

        ' Draw the gradient background.
        g.FillRectangle(brush, 0, 0, width, height)

        ' Draw the label text.
        g.DrawString(text, font, New SolidBrush(textColor), 10, 10)

        ' Render the image to the output stream.
        image.Save(
            Response.OutputStream,
            System.Drawing.Imaging.ImageFormat.Jpeg
            )

        g.Dispose()
        image.Dispose()
    End Sub
End Class

