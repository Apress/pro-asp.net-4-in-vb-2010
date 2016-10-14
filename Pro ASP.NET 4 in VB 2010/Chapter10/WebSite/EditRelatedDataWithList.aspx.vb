
Partial Class EditRelatedDataWithList
    Inherits System.Web.UI.Page

    Protected Sub DetailsView1_PageIndexChanged(
        ByVal sender As Object, ByVal e As EventArgs
        )
        detailsProducts.ChangeMode(DetailsViewMode.[ReadOnly])
    End Sub
End Class
