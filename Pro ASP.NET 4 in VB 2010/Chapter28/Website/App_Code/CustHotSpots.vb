Imports Microsoft.VisualBasic

Namespace CustomHotSpots
    Public Class TriangleHotSpot
        Inherits HotSpot
        Public Sub New()
            Width = 0
            Height = 0
            X = 0
            Y = 0
        End Sub

        Public Property Width() As Integer
            Get
                Return CInt(ViewState("Width"))
            End Get
            Set(ByVal value As Integer)
                ViewState("Width") = value
            End Set
        End Property

        Public Property Height() As Integer
            Get
                Return CInt(ViewState("Height"))
            End Get
            Set(ByVal value As Integer)
                ViewState("Height") = value
            End Set
        End Property

        ' X and Y are the coordinates of the center point.
        Public Property X() As Integer
            Get
                Return CInt(ViewState("X"))
            End Get
            Set(ByVal value As Integer)
                ViewState("X") = value
            End Set
        End Property

        Public Property Y() As Integer
            Get
                Return CInt(ViewState("Y"))
            End Get
            Set(ByVal value As Integer)
                ViewState("Y") = value
            End Set
        End Property
        Protected Overrides ReadOnly Property MarkupName() As String
            Get
                Return "polygon"
            End Get
        End Property
        Public Overrides Function GetCoordinates() As String
            ' Top coordinate.
            Dim topX As Integer = X
            Dim topY As Integer = Y - Height \ 2

            ' Bottom-left coordinate.
            Dim btmLeftX As Integer = X - Width \ 2
            Dim btmLeftY As Integer = Y + Height \ 2

            ' Bottom-right coordinate.
            Dim btmRightX As Integer = X + Width \ 2
            Dim btmRightY As Integer = Y + Height \ 2

            Return topX.ToString() & "," & topY.ToString() & "," &
                btmLeftX.ToString() & "," & btmLeftY.ToString() & "," &
                btmRightX.ToString() & "," & btmRightY.ToString()
        End Function
    End Class
End Namespace

