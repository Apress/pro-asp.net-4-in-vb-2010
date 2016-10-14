﻿Imports System.IO

Partial Public Class CacheFileDependency
    Inherits System.Web.UI.Page
    Protected Sub Page_PreRender(
        ByVal sender As Object, ByVal e As EventArgs
        )
        lblInfo.Text &= "<br>"
    End Sub

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As EventArgs
        ) Handles Me.Load
        If Not Me.IsPostBack Then
            lblInfo.Text &= "Creating dependent item...<br/>"
            Cache.Remove("File")
            Dim dependency _
                As New System.Web.Caching.CacheDependency(
                    Server.MapPath("dependency.txt")
                    )
            Dim item As String = "Dependent cached item"
            lblInfo.Text += "Adding dependent item<br>"
            Cache.Insert("File", item, dependency)
        End If
    End Sub
    Protected Sub cmdModfiy_Click(
        ByVal sender As Object, ByVal e As EventArgs
        )
        lblInfo.Text &= "Modifying dependency.txt file.<br>"
        Dim w As StreamWriter =
            File.CreateText(Server.MapPath("dependency.txt"))
        w.Write(DateTime.Now)
        w.Flush()
        w.Close()
    End Sub
    Protected Sub cmdGetItem_Click(
        ByVal sender As Object, ByVal e As EventArgs
        )
        If Cache("File") Is Nothing Then
            lblInfo.Text += "Cache item no longer exits.<br>"
        Else
            Dim cacheInfo As String = DirectCast(Cache("File"), String)
            lblInfo.Text &= "Retrieved item with text: '" & cacheInfo & "'<br>"
        End If
    End Sub
End Class