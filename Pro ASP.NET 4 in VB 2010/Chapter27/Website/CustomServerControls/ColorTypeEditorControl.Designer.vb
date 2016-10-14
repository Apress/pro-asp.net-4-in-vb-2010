<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ColorTypeEditorControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnPicker = New System.Windows.Forms.Button
        Me.txtSample = New System.Windows.Forms.Label
        Me.trkBlue = New System.Windows.Forms.TrackBar
        Me.trkGreen = New System.Windows.Forms.TrackBar
        Me.trkRed = New System.Windows.Forms.TrackBar
        Me.pnlSample = New System.Windows.Forms.Panel
        Me.label3 = New System.Windows.Forms.Label
        Me.label2 = New System.Windows.Forms.Label
        Me.label1 = New System.Windows.Forms.Label
        Me.label5 = New System.Windows.Forms.Label
        Me.trkAlpha = New System.Windows.Forms.TrackBar
        CType(Me.trkBlue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trkGreen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trkRed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trkAlpha, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnPicker
        '
        Me.btnPicker.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPicker.Location = New System.Drawing.Point(148, 158)
        Me.btnPicker.Name = "btnPicker"
        Me.btnPicker.Size = New System.Drawing.Size(48, 22)
        Me.btnPicker.TabIndex = 26
        Me.btnPicker.Text = "Picker"
        '
        'txtSample
        '
        Me.txtSample.Location = New System.Drawing.Point(8, 162)
        Me.txtSample.Name = "txtSample"
        Me.txtSample.Size = New System.Drawing.Size(76, 16)
        Me.txtSample.TabIndex = 20
        Me.txtSample.Text = "Sample Color:"
        '
        'trkBlue
        '
        Me.trkBlue.AutoSize = False
        Me.trkBlue.Location = New System.Drawing.Point(52, 106)
        Me.trkBlue.Maximum = 255
        Me.trkBlue.Name = "trkBlue"
        Me.trkBlue.Size = New System.Drawing.Size(144, 45)
        Me.trkBlue.SmallChange = 10
        Me.trkBlue.TabIndex = 23
        '
        'trkGreen
        '
        Me.trkGreen.AutoSize = False
        Me.trkGreen.Location = New System.Drawing.Point(52, 74)
        Me.trkGreen.Maximum = 255
        Me.trkGreen.Name = "trkGreen"
        Me.trkGreen.Size = New System.Drawing.Size(144, 45)
        Me.trkGreen.SmallChange = 10
        Me.trkGreen.TabIndex = 22
        '
        'trkRed
        '
        Me.trkRed.AutoSize = False
        Me.trkRed.Location = New System.Drawing.Point(52, 42)
        Me.trkRed.Maximum = 255
        Me.trkRed.Name = "trkRed"
        Me.trkRed.Size = New System.Drawing.Size(144, 45)
        Me.trkRed.SmallChange = 10
        Me.trkRed.TabIndex = 25
        '
        'pnlSample
        '
        Me.pnlSample.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlSample.Location = New System.Drawing.Point(8, 182)
        Me.pnlSample.Name = "pnlSample"
        Me.pnlSample.Size = New System.Drawing.Size(188, 16)
        Me.pnlSample.TabIndex = 21
        '
        'label3
        '
        Me.label3.Location = New System.Drawing.Point(8, 110)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(40, 16)
        Me.label3.TabIndex = 18
        Me.label3.Text = "Blue:"
        '
        'label2
        '
        Me.label2.Location = New System.Drawing.Point(8, 78)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(40, 16)
        Me.label2.TabIndex = 17
        Me.label2.Text = "Green:"
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(8, 46)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(40, 16)
        Me.label1.TabIndex = 16
        Me.label1.Text = "Red:"
        '
        'label5
        '
        Me.label5.Location = New System.Drawing.Point(8, 14)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(40, 16)
        Me.label5.TabIndex = 19
        Me.label5.Text = "Alpha:"
        '
        'trkAlpha
        '
        Me.trkAlpha.AutoSize = False
        Me.trkAlpha.Location = New System.Drawing.Point(52, 10)
        Me.trkAlpha.Maximum = 255
        Me.trkAlpha.Name = "trkAlpha"
        Me.trkAlpha.Size = New System.Drawing.Size(144, 45)
        Me.trkAlpha.SmallChange = 10
        Me.trkAlpha.TabIndex = 24
        '
        'ColorTypeEditorControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Controls.Add(Me.btnPicker)
        Me.Controls.Add(Me.txtSample)
        Me.Controls.Add(Me.trkBlue)
        Me.Controls.Add(Me.trkGreen)
        Me.Controls.Add(Me.trkRed)
        Me.Controls.Add(Me.pnlSample)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.label5)
        Me.Controls.Add(Me.trkAlpha)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ColorTypeEditorControl"
        Me.Size = New System.Drawing.Size(204, 208)
        CType(Me.trkBlue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.trkGreen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.trkRed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.trkAlpha, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents btnPicker As System.Windows.Forms.Button
    Private WithEvents txtSample As System.Windows.Forms.Label
    Private WithEvents trkBlue As System.Windows.Forms.TrackBar
    Private WithEvents trkGreen As System.Windows.Forms.TrackBar
    Private WithEvents trkRed As System.Windows.Forms.TrackBar
    Private WithEvents pnlSample As System.Windows.Forms.Panel
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents label5 As System.Windows.Forms.Label
    Private WithEvents trkAlpha As System.Windows.Forms.TrackBar

End Class
