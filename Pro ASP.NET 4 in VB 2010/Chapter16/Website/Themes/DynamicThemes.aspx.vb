Imports System.IO

Partial Class Themes_DynamicThemes
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        If Not Page.IsPostBack Then
            ' Fill the list box with available themes
            ' by reading the folders in the App_Themes folder.
            Dim themeDir As New DirectoryInfo(Server.MapPath("App_Themes"))
            lstThemes.DataTextField = "Name"
            lstThemes.DataSource = themeDir.GetDirectories()
            lstThemes.DataBind()
        End If
    End Sub
    Protected Sub cmdApply_Click(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles cmdApply.Click
        ' Set the chosen theme.
        Session("Theme") = lstThemes.SelectedValue
        ' Refresh the page.
        Server.Transfer(Request.FilePath)
    End Sub
    Protected Sub Page_PreInit(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.PreInit
        If Session("Theme") = Nothing Then
            ' No theme has been chosen. Choose a default
            ' (or set a blank string to make sure no theme
            ' is used).
            Page.Theme = ""
        Else
            Page.Theme = DirectCast(Session("Theme"), String)
        End If
    End Sub
End Class
