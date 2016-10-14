Imports System.Web.Util
Public Class CustomRequestValidator
    Inherits RequestValidator
    Protected Overrides Function IsValidRequestString(
        ByVal context As HttpContext,
        ByVal value As String,
        ByVal theRequestValidationSource As RequestValidationSource,
        ByVal collectionKey As String,
        ByRef validationFailureIndex As Integer
        ) As Boolean
        If theRequestValidationSource =
            RequestValidationSource.Form Then
            Dim errorIndex As Integer = value.IndexOf("<script>")
            If errorIndex <> -1 Then
                validationFailureIndex = errorIndex
                Return False
            Else
                validationFailureIndex = 0
                Return True
            End If
        Else
            Return MyBase.IsValidRequestString(
                context, value,
                theRequestValidationSource,
                collectionKey,
                validationFailureIndex)
        End If
    End Function
End Class

