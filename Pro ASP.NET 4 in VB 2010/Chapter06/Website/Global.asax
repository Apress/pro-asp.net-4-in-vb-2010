<%@ Application Language="VB" ClassName="myGlobal" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="System.Collections.Generic" %>
<script runat="server">

    Private Shared m_fileList As String()
    Public Shared ReadOnly Property FileList() As String()
        Get
            If m_fileList Is Nothing Then
                m_fileList = Directory.GetFiles(HttpContext.Current.Request.PhysicalApplicationPath)
            End If
            Return m_fileList
        End Get
    End Property
    Private Shared metadata As New Dictionary(Of String, String)
    Public Sub AddMetaData(ByVal key As String, ByVal value As String)
        SyncLock metadata
            metadata(key) = value
        End SyncLock
    End Sub
    
    Public Function GetMetaData(ByVal key As String) As String
        SyncLock metadata
            Return metadata(key)
        End SyncLock
    End Function
</script>
