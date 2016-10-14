Imports SherlockLib
Partial Class HolmesQuote
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        Dim quotes As SherlockQuotes =
            New SherlockQuotes(Server.MapPath("./sherlock-holmes.xml"))
        Dim quote As Quotation =
            quotes.GetRandomQuote()
        Response.Write("<b>" & quote.Source & "</b> (<i>" & quote.Date & "</i>)")
        Response.Write("<blockquote>" & quote.QuotationText & "</blockquote>")
    End Sub
End Class
