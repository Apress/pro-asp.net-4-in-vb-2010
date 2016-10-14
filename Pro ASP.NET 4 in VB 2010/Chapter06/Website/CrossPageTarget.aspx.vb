Imports System.Collections
Imports System.Configuration

Partial Class CrossPageTarget
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        If PreviousPage IsNot Nothing Then
            If Not PreviousPage.IsValid Then
                Response.Redirect(Request.UrlReferrer.AbsolutePath & "?err=true")
            Else
                lbl.Text = "You came from a page titled " &
                    PreviousPage.Header.Title & "<br />"
                Dim prevPage As CrossPageSource =
                    TryCast(PreviousPage, CrossPageSource)
                If prevPage IsNot Nothing Then
                    lbl.Text &= "You typed in this: " &
                        prevPage.TextBoxContent & "<br />"
                End If
                If PreviousPage.IsCrossPagePostBack Then
                    lbl.Text &= "The page was posted directly"
                Else
                    lbl.Text &= "You used Server.Transfer()"
                End If
            End If
        End If
    End Sub
End Class
