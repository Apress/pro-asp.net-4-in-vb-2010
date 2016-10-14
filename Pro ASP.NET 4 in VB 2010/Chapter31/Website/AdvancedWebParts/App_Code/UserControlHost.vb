Namespace Apress.WebParts.Samples
    Public Class UserControlHostPart
        Inherits WebPart
        Private _ControlUpdated As Boolean = False
        Private _CurrentUserControlPath As String = String.Empty

        <WebBrowsable(True)>
        <Personalizable(PersonalizationScope.User)>
        Public Property CurrentUserControlPath() As String
            Get
                Return _CurrentUserControlPath
            End Get
            Set(ByVal value As String)
                If Not _CurrentUserControlPath.Equals(String.Empty) Then
                    _ControlUpdated = True
                End If

                _CurrentUserControlPath = value
            End Set
        End Property

        Private FallBackLabel As Label = Nothing
        Private CurrentControl As Control = Nothing

        Protected Overrides Sub CreateChildControls()
            ' Label showing a default text if no control is loaded
            FallBackLabel = New Label()
            FallBackLabel.Text = "No control selected"
            FallBackLabel.EnableViewState = False

            ' If a user control is selected, you need to
            ' load this control through Page.Load
            LoadSelectedControl()

            ' Add the controls to the parent
            Controls.Add(FallBackLabel)
            If CurrentControl IsNot Nothing Then
                Controls.Add(CurrentControl)
            End If
        End Sub

        Private Sub LoadSelectedControl()
            If Not _CurrentUserControlPath.Equals(String.Empty) Then
                Try
                    CurrentControl = Page.LoadControl(_CurrentUserControlPath)
                Catch ex As Exception
                    FallBackLabel.Text = "Unable to load control: " & ex.Message
                End Try
            End If
        End Sub

        Protected Overrides Sub OnPreRender(ByVal e As EventArgs)
            MyBase.OnPreRender(e)

            If _ControlUpdated Then
                ' Remove the currently loaded control
                Controls.Remove(CurrentControl)
                LoadSelectedControl()
                Controls.Add(CurrentControl)
            End If
        End Sub

        Public Overrides Sub RenderControl(ByVal writer As HtmlTextWriter)
            If CurrentControl IsNot Nothing Then
                CurrentControl.RenderControl(writer)
            Else
                FallBackLabel.RenderControl(writer)
            End If
        End Sub
    End Class
End Namespace