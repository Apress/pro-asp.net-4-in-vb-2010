Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Net
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Shapes

Public Partial Class FallingRectangles
    Inherits UserControl
    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub Page_Loaded(ByVal o As Object, ByVal e As EventArgs)
        ' Generate some rectangles.
        Dim rand As New Random()
        For i As Integer = 0 To 19
            ' Create a new rectangle.
            Dim rect As New Rectangle()
            rect.Fill = New SolidColorBrush(Colors.Red)

            ' Size and place it randomly.
            rect.Width = rand.Next(10, 40)
            rect.Height = rand.Next(10, 40)
            Canvas.SetTop(rect, rand.Next(CInt(Fix(Me.Height - rect.Height))))
            Canvas.SetLeft(rect, rand.Next(CInt(Fix(Me.Width - rect.Width))))

            ' Handle clicks.
            AddHandler rect.MouseLeftButtonDown, AddressOf rect_MouseLeftButtonDown

            ' Add it to the Canvas.
            canvas.Children.Add(rect)
        Next
    End Sub

    ' Collection for tracking animations.
    Private animatedShapes As Dictionary(Of Storyboard, Rectangle) = New Dictionary(Of Storyboard, Rectangle)()

    Private Sub rect_MouseLeftButtonDown(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
        Dim rect As Rectangle = CType(sender, Rectangle)

        ' Create the storyboard for the rectangle.
        Dim storyboard As New Storyboard()

        ' Create the animation for moving the rectangle.
        Dim fallingAnimation As New DoubleAnimation()
        Storyboard.SetTarget(fallingAnimation, rect)
        Storyboard.SetTargetProperty(fallingAnimation, New PropertyPath("(Canvas.Top)"))
        fallingAnimation.To = Me.Height - rect.Height
        fallingAnimation.Duration = TimeSpan.FromSeconds(2)
        storyboard.Children.Add(fallingAnimation)

        ' Create the animation for changing the rectangle's color.
        Dim colorAnimation As New ColorAnimation()
        Storyboard.SetTarget(colorAnimation, rect.Fill)
        Storyboard.SetTargetProperty(colorAnimation, New PropertyPath("Color"))
        colorAnimation.To = Colors.Blue
        colorAnimation.Duration = fallingAnimation.Duration
        storyboard.Children.Add(colorAnimation)

        ' Track the rectangle.
        animatedShapes.Add(storyboard, rect)

        ' React when the storyboard is finished.
        AddHandler storyboard.Completed, AddressOf storyboard_Completed

        ' Start the storyboard.
        storyboard.Begin()
    End Sub

    Private Sub storyboard_Completed(ByVal sender As Object, ByVal e As EventArgs)
        ' Stop the animation but keep the new position.
        Dim storyboard As Storyboard = CType(sender, Storyboard)
        Dim rect As Rectangle = animatedShapes(storyboard)
        Dim newTop As Double = Canvas.GetTop(rect)
        storyboard.Stop()
        Canvas.SetTop(rect, newTop)

        ' Remove it from the tracking collection.          
        animatedShapes.Remove(storyboard)
    End Sub


End Class
