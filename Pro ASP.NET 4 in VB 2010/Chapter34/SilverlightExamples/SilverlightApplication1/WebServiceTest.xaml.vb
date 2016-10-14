Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Shapes
Imports SilverlightApplication1.ServiceReference1
Imports System.Windows.Browser

Public Partial Class WebServiceTest
    Inherits UserControl
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub callService_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim address As New System.ServiceModel.EndpointAddress("http://localhost:" & HtmlPage.Document.DocumentUri.Port & "/TestService.svc")
        Dim proxy As New TestServiceClient(New System.ServiceModel.BasicHttpBinding(), address)

        AddHandler proxy.GetServerTimeCompleted, AddressOf GetServerTimeCompleted
        proxy.GetServerTimeAsync()
    End Sub
    Private Sub GetServerTimeCompleted(ByVal sender As Object, ByVal e As GetServerTimeCompletedEventArgs)
        Try
            lblTime.Text = e.Result.ToLongTimeString()
        Catch err As Exception
            lblTime.Text = err.Message
            If Not err.InnerException Is Nothing Then
            lblTime.Text += Constants.vbLf + err.InnerException.Message
            End If
        End Try
    End Sub

    Private Sub callCachedService_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim address As New System.ServiceModel.EndpointAddress("http://localhost:" & HtmlPage.Document.DocumentUri.Port & "/TestService.svc")
        Dim proxy As New TestServiceClient(New System.ServiceModel.BasicHttpBinding(), address)

        AddHandler proxy.GetCachedServerTimeCompleted, AddressOf GetCachedServerTimeCompleted
        proxy.GetCachedServerTimeAsync()
    End Sub
    Private Sub GetCachedServerTimeCompleted(ByVal sender As Object, ByVal e As GetCachedServerTimeCompletedEventArgs)
        Try
            lblTime.Text = e.Result.ToLongTimeString()
        Catch err As Exception
            lblTime.Text = err.Message
            If Not err.InnerException Is Nothing Then
            lblTime.Text += Constants.vbLf + err.InnerException.Message
            End If
        End Try
    End Sub
End Class
