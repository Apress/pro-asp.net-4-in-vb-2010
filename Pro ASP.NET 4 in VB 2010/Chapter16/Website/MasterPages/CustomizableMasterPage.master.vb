
Partial Class MasterPages_CustomizableMasterPage
    Inherits System.Web.UI.MasterPage

    ' Page events are wired up automatically to methods 
    ' with the following names:
    ' Page_Load, Page_AbortTransaction, Page_CommitTransaction,
    ' Page_DataBinding, Page_Disposed, Page_Error, Page_Init, 
    ' Page_Init Complete, Page_Load, Page_LoadComplete, Page_PreInit
    ' Page_PreLoad, Page_PreRender, Page_PreRenderComplete, 
    ' Page_SaveStateComplete, Page_Unload
    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load
        ' A dead end.
        If Not Page.IsPostBack Then
            If Page.PreviousPage IsNot Nothing Then
                Dim previous As MasterPages_CustomizableMasterPage =
                    Page.PreviousPage.Master
                If previous IsNot Nothing Then
                    BannerText = previous.BannerText
                End If
            End If
        End If
    End Sub

    Public Property BannerText() As String
        Get
            Return lblTitleContent.Text
        End Get
        Set(ByVal value As String)
            lblTitleContent.Text = value
        End Set
    End Property
End Class

