
Partial Class CookieMgmt
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Button1.Click

        ' Create the cookie object.
        Dim cookie As HttpCookie =
            New HttpCookie("Preferences")

        ' This cookie lives for one year.
        cookie.Expires = DateTime.Now.AddYears(1)

        ' Set a value in it.
        cookie("LanguagePref") = "English"

        ' Add another value.
        cookie("Country") = "US"

        ' Add it to the current web response.
        Response.Cookies.Add(cookie)
    End Sub

    Protected Sub Button2_Click(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Button2.Click

        Dim cookie As HttpCookie = Request.Cookies("Preferences")
        ' Check to see whether a cookie was found with this name.
        ' This is a good precaution to take,
        ' because the user could disable cookies,
        ' in which case the cookie would not exist.
        Dim language As String = ""
        If cookie IsNot Nothing Then
            language = cookie("LanguagePref")
        End If
        TextBox1.Text = language
    End Sub

    Protected Sub Button3_Click(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Button3.Click
        Dim cookie As HttpCookie = New HttpCookie("Preferences")
        cookie.Expires = DateTime.Now.AddDays(-1)
        Response.SetCookie(cookie)
    End Sub
End Class
