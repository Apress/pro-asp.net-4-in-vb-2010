Imports System.Security.Cryptography
Partial Class CreateMachineKey
    Inherits System.Web.UI.Page

    Protected Sub CreateKey_Click(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles CreateKey.Click
        If IsInteger(KeyLength.Text) Then
            If CInt(KeyLength.Text) >= 40 And
                CInt(KeyLength.Text) <= 128 Then
                theKey.Text = CreateAKey(CInt(KeyLength.Text))
            Else
                MsgBox("Key Length must be between 40 and 128")
            End If
        Else
            MsgBox("Key Length must be an integer")
        End If
    End Sub
    Private Function CreateAKey(ByVal Length As Integer) As String
        'Create a byte array
        Dim random As Byte() = New Byte(Length / 2 - 1) {}
        'Create a cyptographically strong random number generator
        Dim rng As New RNGCryptoServiceProvider()
        'Fill the byte array with random bytes
        rng.GetBytes(random)
        'Create a StringBuilder to hold the result once it is converted
        'to hexadecimal
        Dim machineKey As New System.Text.StringBuilder(Length)
        For i As Integer = 0 To random.Length - 1
            'Loop through the random byte arran and append each value
            'to the StringBuilder
            machineKey.Append([String].Format("{0:X2}", random(i)))
        Next
        Return machineKey.ToString
    End Function
    Private Function IsInteger(ByVal strNumber As String) As Boolean
        Dim _RegexNotIntPattern As _
            New System.Text.RegularExpressions.Regex("[^0-9-]")
        Dim _RegexIntPattern As _
            New System.Text.RegularExpressions.Regex("^-[0-9]+$|^[0-9]+$")
        Return (Not _RegexNotIntPattern.IsMatch(strNumber) AndAlso
                _RegexIntPattern.IsMatch(strNumber))
    End Function
End Class
