﻿
Partial Class IFrameTest
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        IFrame1.Attributes("src") = "PageProcessor_Start.aspx"
    End Sub
End Class
