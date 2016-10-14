Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Shapes

Public Partial Class RotatingButtons
    Inherits UserControl
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub cmd_MouseEnter(ByVal sender As Object, ByVal e As MouseEventArgs)
        rotateStoryboard.Stop()
        Storyboard.SetTarget(rotateStoryboard, (CType(sender, Button)).RenderTransform)
        rotateStoryboard.Begin()
    End Sub

    Private Sub cmd_MouseLeave(ByVal sender As Object, ByVal e As MouseEventArgs)
        unrotateStoryboard.Stop()
        Storyboard.SetTarget(unrotateStoryboard, (CType(sender, Button)).RenderTransform)
        unrotateStoryboard.Begin()
    End Sub
End Class
