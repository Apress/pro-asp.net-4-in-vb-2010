
Partial Class Units
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(
    ByVal sender As Object, ByVal e As System.EventArgs
    ) Handles Me.Load
        ' Create a Unit object.
        Dim myUnit As Unit = New Unit(300, UnitType.Pixel)
        ' Assign a BorderStyle so the panel will be visible
        pnl.BorderStyle = BorderStyle.Dashed
        ' Assign the Unit object to several controls or properties.
        pnl.Height = myUnit
        pnl.Width = myUnit

        ' Convert the number 300 to a Unit object
        ' representing pixels, and assign it.
        pnl.Height = Unit.Pixel(300)

        ' Convert the number 50 to a Unit object
        ' representing percent, and assign it.
        pnl.Width = Unit.Percentage(50)
    End Sub
End Class
