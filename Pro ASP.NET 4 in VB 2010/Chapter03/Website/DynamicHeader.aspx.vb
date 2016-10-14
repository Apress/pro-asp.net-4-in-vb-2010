Partial Class DynamicHeader
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(
        ByVal sender As Object,
        ByVal e As System.EventArgs
        ) Handles Me.Load
        ' Try commenting the second and third sections to see the difference in the header

        Page.Header.Title = "Dynamically Titled Page"
        Page.Header.Description = "Apress: A great website to learn .NET"
        Page.Header.Keywords = ".NET, VB, ASP.NET"

        Dim metaTag As HtmlMeta = New HtmlMeta()
        metaTag.Name = "robots"
        metaTag.Content = "noindex"
        Page.Header.Controls.Add(metaTag)

        ' Define and add a second metadata tag.
        ' Be aware that the same name will override previous values.
        Dim secondMeta As HtmlMeta = New HtmlMeta()
        secondMeta.Name = "keywords"
        secondMeta.Content = "More.NET, MoreVB, MoreASP.NET"
        Page.Header.Controls.Add(secondMeta)
    End Sub
End Class
