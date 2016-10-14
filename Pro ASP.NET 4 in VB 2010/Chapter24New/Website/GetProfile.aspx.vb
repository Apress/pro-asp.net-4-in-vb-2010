Partial Class GetProfile
    Inherits System.Web.UI.Page

    Protected Sub cmdGet_Click(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles cmdGet.Click
        Dim profileCom As ProfileCommon =
            Profile.GetProfile(txtUserName.Text)
        lbl.Text = "This user lives in " & profileCom.Address.Country
    End Sub
End Class
