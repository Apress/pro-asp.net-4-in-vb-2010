Imports System.Web.Profile
Partial Class ComplexTypes
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        Context.Items("AddressDirtyFlag") = False
    End Sub

    Protected Sub cmdSave_Click(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles cmdSave.Click
        Profile.Address =
            New Address(
                txtName.Text,
                txtStreet.Text,
                txtCity.Text,
                txtZip.Text,
                txtState.Text,
                txtCountry.Text
                )
    End Sub

    Protected Sub cmdGet_Click(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles cmdGet.Click
        txtName.Text = Profile.Address.Name
        txtStreet.Text = Profile.Address.Street
        txtCity.Text = Profile.Address.City
        txtZip.Text = Profile.Address.ZipCode
        txtState.Text = Profile.Address.State
        txtCountry.Text = Profile.Address.Country
    End Sub
    Protected Sub txt_TextChanged(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles txtName.TextChanged,
                txtStreet.TextChanged, txtCity.TextChanged,
                txtZip.TextChanged, txtState.TextChanged,
                txtCountry.TextChanged
        Context.Items("AddressDirtyFlag") = True
    End Sub
End Class
