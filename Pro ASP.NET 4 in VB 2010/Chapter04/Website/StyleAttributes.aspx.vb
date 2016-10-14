Partial Class StyleAttributes
    Inherits System.Web.UI.Page

    Protected Sub form1_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles form1.Load
        ' Only perform the initialization the first time the page is requested. 
        ' After that, this information is tracked in view state. 
        If Not Page.IsPostBack Then
            ' Set the style attributes to configure appearance. 
            TextBox1.Style("font-size") = "20px"
            TextBox1.Style("color") = "red"
            TextBox1.Style("width") = "300px"

            ' Use a slightly different but equivalent syntax 
            ' for setting a style attribute. 
            TextBox1.Style.Add("background-color", "lightyellow")

            ' Set the default text. 
            TextBox1.Value = "<Enter e-mail address here>"

            ' Set other nonstandard attributes. 
            TextBox1.Attributes("onfocus") = "alert(TextBox1.value)"
        End If
    End Sub
End Class
