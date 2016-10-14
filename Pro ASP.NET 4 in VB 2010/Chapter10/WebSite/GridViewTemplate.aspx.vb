
Partial Class GridViewTemplate
    Inherits System.Web.UI.Page

    Protected ReadOnly Property TitlesOfCourtesy() As String()
        Get
            Return New String() {"Mr.", "Dr.", "Ms.", "Mrs."}
        End Get
    End Property

    Protected Function GetSelectedTitle(
        ByVal title As Object
        ) As Integer
        Return Array.IndexOf(TitlesOfCourtesy, title.ToString())
    End Function

    Protected Sub gridEmployees_RowUpdating(
        ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs
        ) Handles gridEmployees.RowUpdating

        ' Get the reference to the list control. 
        Dim title As DropDownList =
            DirectCast((gridEmployees.Rows(e.RowIndex).FindControl("EditTitle")), DropDownList)

        ' Add it to the parameters. 
        e.NewValues.Add("TitleOfCourtesy", title.Text)
    End Sub
End Class
