Imports System.Net
Imports System.Security.Cryptography.X509Certificates

''' <summary> 
''' Summary description for WebRequestCreator 
''' </summary> 
Public NotInheritable Class WebRequestCreator
    Private Sub New()
    End Sub
    Public Shared Sub ExecuteWebRequest(ByVal url As String)
        Dim Certificate As X509Certificate2 = Nothing

        ' Read the certificate from the store 
        Dim store As New X509Store(
            StoreName.My,
            StoreLocation.LocalMachine
            )
        store.Open(OpenFlags.[ReadOnly])
        Try
            ' Try to find the certificate 
            ' based on its common name 
            Dim Results As X509Certificate2Collection =
                store.Certificates.Find(
                    X509FindType.FindBySubjectDistinguishedName,
                    "CN=Robbin, CN=Hood", False
                    )
            If Results.Count = 0 Then
                Throw New Exception("Unable to find certificate!")
            Else
                Certificate = Results(0)
            End If
        Finally
            store.Close()
        End Try

        ' Now create the web request 
        Dim Request As HttpWebRequest =
            DirectCast(WebRequest.Create(url), HttpWebRequest)
        Request.ClientCertificates.Add(Certificate)
        Dim Response As HttpWebResponse =
            DirectCast(Request.GetResponse(), HttpWebResponse)

    End Sub
End Class