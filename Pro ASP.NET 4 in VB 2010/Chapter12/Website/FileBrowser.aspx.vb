Imports System.IO
Imports System.Diagnostics

Partial Class FileBrowser
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        If Not Page.IsPostBack Then
            ShowDirectoryContents(Server.MapPath("."))
        End If
    End Sub
    Private Sub ShowDirectoryContents(ByVal path As String)
        ' Define the current directory.
        Dim dir As DirectoryInfo = New DirectoryInfo(path)

        ' Get the DirectoryInfo and FileInfo objects.
        Dim files As FileInfo() = dir.GetFiles()
        Dim dirs As DirectoryInfo() = dir.GetDirectories()

        ' Show the directory listing.
        lblCurrentDir.Text = "Currently showing " & path
        gridFileList.DataSource = files
        gridDirList.DataSource = dirs
        Page.DataBind()

        ' Clear any selection.
        gridFileList.SelectedIndex = -1

        ' Keep track of the current path.
        ViewState("CurrentPath") = path

    End Sub

    Protected Function GetVersionInfoString(
        ByVal path As Object
        ) As String
        Dim info As FileVersionInfo =
            FileVersionInfo.GetVersionInfo(path.ToString())
        Return info.FileName & " " & info.FileVersion & "<br>" &
            info.ProductName & " " & info.ProductVersion
    End Function

    Protected Sub cmdUp_Click(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles cmdUp.Click
        Dim strPath As String =
            ViewState("CurrentPath").ToString()
        strPath = Path.Combine(strPath, "..")
        strPath = Path.GetFullPath(strPath)
        ShowDirectoryContents(strPath)
    End Sub

    Protected Sub gridDirList_SelectedIndexChanged(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles gridDirList.SelectedIndexChanged
        ' Get the selected directory.
        Dim dir As String =
            gridDirList.DataKeys(gridDirList.SelectedIndex).Value
        ' Now refresh the directory list to
        ' show the selected directory.
        ShowDirectoryContents(dir)
    End Sub

    Protected Sub gridFileList_SelectedIndexChanged(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles gridFileList.SelectedIndexChanged
        ' Get the selected file.
        Dim file As String =
            gridFileList.DataKeys(gridFileList.SelectedIndex).Value

        ' The FormView shows a collection (or list) of items.
        ' To accomodate this model, you must add the file object
        ' to a collection of some sort.
        Dim files As ArrayList = New ArrayList()
        files.Add(New FileInfo(file))

        ' Now show the selected file.
        formFileDetails.DataSource = files
        formFileDetails.DataBind()
    End Sub
End Class
