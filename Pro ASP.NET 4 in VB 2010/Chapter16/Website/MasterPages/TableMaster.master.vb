
Partial Class MasterPages_TableMaster
    Inherits System.Web.UI.MasterPage

    Public Property ShowNavigationControls() As Boolean
        Get
            Return Treeview1.Visible
        End Get
        Set(ByVal value As Boolean)
            Treeview1.Visible = value
        End Set
    End Property
End Class

