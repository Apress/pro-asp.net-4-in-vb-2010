Imports Microsoft.VisualBasic
Imports System.IO

Namespace RolesDemo.Handlers
    Public Class GenericHandler
        Implements IHttpHandler

#Region "IHttpHandler Members"
        Public ReadOnly Property IsReusable() As Boolean Implements System.Web.IHttpHandler.IsReusable
            Get
                Return True
            End Get
        End Property

        Public Sub ProcessRequest(ByVal context As System.Web.HttpContext) Implements System.Web.IHttpHandler.ProcessRequest
            Dim ret As Byte() = Nothing
            ' Open the file specified in the context
            Dim PhysicalPath As String = context.Server.MapPath(context.Request.Path)
            Using fs As New FileStream(PhysicalPath, FileMode.Open)
                ret = New Byte(fs.Length) {}

                fs.Read(ret, 0, Convert.ToInt32(fs.Length))
            End Using


            ' If it is not null, return the byte array
            If ret IsNot Nothing Then
                context.Response.BinaryWrite(ret)
            End If
        End Sub
#End Region

    End Class

End Namespace
