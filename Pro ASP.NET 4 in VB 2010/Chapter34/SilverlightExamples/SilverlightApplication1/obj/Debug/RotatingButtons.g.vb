#ExternalChecksum("D:\Apress\Pro ASP .NET 3.5 in VB 2008\Pro ASP.NET VB2008\Chapter33\SilverlightVB\SilverlightVB\SilverlightApplication1\RotatingButtons.xaml","{406ea660-64cf-4c82-b6f0-42d48172a799}","0A1752D6225186906DFC72CA3A0127AF")
'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:2.0.50727.3053
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System
Imports System.Windows
Imports System.Windows.Automation
Imports System.Windows.Automation.Peers
Imports System.Windows.Automation.Provider
Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Ink
Imports System.Windows.Input
Imports System.Windows.Interop
Imports System.Windows.Markup
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Media.Imaging
Imports System.Windows.Resources
Imports System.Windows.Shapes
Imports System.Windows.Threading



<Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>  _
Partial Public Class RotatingButtons
    Inherits System.Windows.Controls.UserControl
    
    Friend WithEvents rotateStoryboard As System.Windows.Media.Animation.Storyboard
    
    Friend WithEvents unrotateStoryboard As System.Windows.Media.Animation.Storyboard
    
    Friend WithEvents LayoutRoot As System.Windows.Controls.Grid
    
    Private _contentLoaded As Boolean
    
    '''<summary>
    '''InitializeComponent
    '''</summary>
    <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Public Sub InitializeComponent()
        If _contentLoaded Then
            Return
        End If
        _contentLoaded = true
        System.Windows.Application.LoadComponent(Me, New System.Uri("/SilverlightApplication1;component/RotatingButtons.xaml", System.UriKind.Relative))
        Me.rotateStoryboard = CType(Me.FindName("rotateStoryboard"),System.Windows.Media.Animation.Storyboard)
        Me.unrotateStoryboard = CType(Me.FindName("unrotateStoryboard"),System.Windows.Media.Animation.Storyboard)
        Me.LayoutRoot = CType(Me.FindName("LayoutRoot"),System.Windows.Controls.Grid)
    End Sub
End Class
