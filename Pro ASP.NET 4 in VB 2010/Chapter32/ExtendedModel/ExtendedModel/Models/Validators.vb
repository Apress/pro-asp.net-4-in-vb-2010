Imports System.ComponentModel.DataAnnotations

Public Class OddOrEvenAttribute
    Inherits ValidationAttribute
    Public Property theMode() As Mode

    Public Sub New(ByVal m As Mode)
        theMode = m
    End Sub

    Public Overrides Function IsValid(
        ByVal value As Object
        ) As Boolean
        Try
            If Integer.Parse(value.ToString()) Mod 2 = 0 Then
                Return theMode = Mode.Even
            Else
                Return theMode = Mode.Odd
            End If
        Catch
            Return False
        End Try
    End Function

    Public Enum Mode
        Odd
        Even
    End Enum
End Class



