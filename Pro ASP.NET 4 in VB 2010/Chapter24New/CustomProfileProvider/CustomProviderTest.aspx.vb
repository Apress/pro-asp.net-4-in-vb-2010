Partial Class ComplexTypes
    Inherits System.Web.UI.Page

    Protected Sub cmdSave_Click(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles cmdSave.Click
        Profile.AddressName = txtName.Text
        Profile.AddressStreet = txtStreet.Text
        Profile.AddressCity = txtCity.Text
        Profile.AddressZipCode = txtZip.Text
        Profile.AddressState = txtState.Text
        Profile.AddressCountry = txtCountry.Text
        txtName.Text = ""
        txtStreet.Text = ""
        txtCity.Text = ""
        txtZip.Text = ""
        txtState.Text = ""
        txtCountry.Text = ""
    End Sub

    Protected Sub cmdGet_Click(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles cmdGet.Click
        txtName.Text = Profile.AddressName
        txtStreet.Text = Profile.AddressStreet
        txtCity.Text = Profile.AddressCity
        txtZip.Text = Profile.AddressZipCode
        txtState.Text = Profile.AddressState
        txtCountry.Text = Profile.AddressCountry
    End Sub
End Class
