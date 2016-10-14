
Partial Class XmlDataSourceNoFile
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        sourceDVD.Data =
            "<DvdList><DVD ID='1' Category='Science Fiction'><Title>The Matrix</Title>" &
            "<Director>Larry Wachowski</Director><Price>18.74</Price><Starring><Star>Keanu Reeves</Star>" &
            "<Star>Laurence Fishburne</Star></Starring></DVD></DvdList>"
    End Sub
End Class
