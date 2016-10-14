Imports System
Imports System.Collections.Generic
Imports System.Text

Namespace APress.ProAspNet.Utility
    Public NotInheritable Class HexEncoding
        Private Sub New()
        End Sub
        Public Shared Function GetString(ByVal data As Byte()) As String
            Dim Results As New StringBuilder()
            For Each b As Byte In data
                Results.Append(b.ToString("X2"))
            Next

            Return Results.ToString()
        End Function

        Public Shared Function GetBytes(ByVal data As String) As Byte()
            ' GetString encodes the hex-numbers with two digits 
            Dim Results As Byte() = New Byte(data.Length / 2 - 1) {}
            For i As Integer = 0 To data.Length - 1 Step 2
                Results(i / 2) = Convert.ToByte(data.Substring(i, 2), 16)
            Next

            Return Results
        End Function
    End Class
End Namespace