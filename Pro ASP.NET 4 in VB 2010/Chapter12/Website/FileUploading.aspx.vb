Imports System.IO

Partial Class FileUploading
    Inherits System.Web.UI.Page

    Protected Sub cmdUpload_Click(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles cmdUpload.Click
        ' Check if a file was submitted.
        If Uploader.PostedFile.ContentLength <> 0 Then
            Try
                If Uploader.PostedFile.ContentLength > 1048576 Then
                    ' This exceeds the size linit you want to allow.
                    ' You should check the size to prevent the denail of
                    ' service attack that attempts to fill up your
                    ' web server's hard drive.
                    ' You might also want to check the amount of
                    ' remaining free space.
                    lblStatus.Text = "Too large. This file is not allowed"
                Else
                    ' Retrieve the physical directory path for the Upload
                    ' subdirectory.
                    Dim destDir As String = Server.MapPath("./Upload")

                    ' Exract the file name part from the full path of the 
                    ' original file.
                    Dim fileName As String = Uploader.FileName

                    ' Combine the destination directory with the file name.
                    Dim destPath As String = Path.Combine(destDir, fileName)

                    ' Save the file on the server.
                    Uploader.PostedFile.SaveAs(destPath)
                    lblStatus.Text = "Thanks for submitting your file."

                    '' Display the whole file content. 
                    'Dim r As New StreamReader(Uploader.PostedFile.InputStream)
                    'lblStatus.Text = r.ReadToEnd()
                    'r.Close()

                End If
            Catch err As Exception
                lblStatus.Text = err.Message
            End Try
        End If
    End Sub
End Class
