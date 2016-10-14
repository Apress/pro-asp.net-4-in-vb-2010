Partial Class BulletedList
    Inherits System.Web.UI.Page

    Protected Sub Page_PreLoad(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.PreLoad
        If Not Page.IsPostBack Then
            For Each style As String In [Enum].GetNames(GetType(BulletStyle))
                BulletedList1.Items.Add(style)
            Next
        End If
    End Sub

    Protected Sub BulletedList1_Click(
        ByVal sender As Object,
        ByVal e As System.Web.UI.WebControls.BulletedListEventArgs
        ) Handles BulletedList1.Click
        Dim styleName As String = BulletedList1.Items(e.Index).Text
        Dim style As BulletStyle =
            DirectCast([Enum].Parse(GetType(BulletStyle), styleName), BulletStyle)
        BulletedList1.BulletStyle = style
        Label1.Text = "You choose style: " & styleName
    End Sub
End Class
