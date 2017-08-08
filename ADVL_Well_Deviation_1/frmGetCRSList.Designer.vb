<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGetCRSList
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtNLatDegrees = New System.Windows.Forms.TextBox()
        Me.cmbWLongWE = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtNLatMinutes = New System.Windows.Forms.TextBox()
        Me.txtWLongSeconds = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtNLatSeconds = New System.Windows.Forms.TextBox()
        Me.txtWLongMinutes = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.cmbNLatNS = New System.Windows.Forms.ComboBox()
        Me.txtWLongDegrees = New System.Windows.Forms.TextBox()
        Me.txtSLatDegrees = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cmbELongWE = New System.Windows.Forms.ComboBox()
        Me.txtSLatMinutes = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtELongSeconds = New System.Windows.Forms.TextBox()
        Me.txtSLatSeconds = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtELongMinutes = New System.Windows.Forms.TextBox()
        Me.cmbSLatNS = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtELongDegrees = New System.Windows.Forms.TextBox()
        Me.txtAreaOfUseName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnPasteFromClipboard = New System.Windows.Forms.Button()
        Me.btnGetGeoCRSList = New System.Windows.Forms.Button()
        Me.btnGetProjCRSList = New System.Windows.Forms.Button()
        Me.rbGetAll = New System.Windows.Forms.RadioButton()
        Me.rbExtendingInto = New System.Windows.Forms.RadioButton()
        Me.rbInside = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkGeographic2D = New System.Windows.Forms.CheckBox()
        Me.chkGeographic3D = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.Location = New System.Drawing.Point(593, 12)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(64, 22)
        Me.btnExit.TabIndex = 8
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.txtNLatDegrees)
        Me.GroupBox1.Controls.Add(Me.cmbWLongWE)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.txtNLatMinutes)
        Me.GroupBox1.Controls.Add(Me.txtWLongSeconds)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label23)
        Me.GroupBox1.Controls.Add(Me.txtNLatSeconds)
        Me.GroupBox1.Controls.Add(Me.txtWLongMinutes)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label24)
        Me.GroupBox1.Controls.Add(Me.cmbNLatNS)
        Me.GroupBox1.Controls.Add(Me.txtWLongDegrees)
        Me.GroupBox1.Controls.Add(Me.txtSLatDegrees)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.cmbELongWE)
        Me.GroupBox1.Controls.Add(Me.txtSLatMinutes)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.txtELongSeconds)
        Me.GroupBox1.Controls.Add(Me.txtSLatSeconds)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.txtELongMinutes)
        Me.GroupBox1.Controls.Add(Me.cmbSLatNS)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.txtELongDegrees)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 130)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(624, 167)
        Me.GroupBox1.TabIndex = 170
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Geographic Bounding Box"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(121, 35)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(89, 13)
        Me.Label12.TabIndex = 104
        Me.Label12.Text = "Northern Latitude"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(13, 97)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(97, 13)
        Me.Label21.TabIndex = 128
        Me.Label21.Text = "Western Longitude"
        '
        'txtNLatDegrees
        '
        Me.txtNLatDegrees.Location = New System.Drawing.Point(216, 32)
        Me.txtNLatDegrees.Name = "txtNLatDegrees"
        Me.txtNLatDegrees.Size = New System.Drawing.Size(39, 20)
        Me.txtNLatDegrees.TabIndex = 97
        '
        'cmbWLongWE
        '
        Me.cmbWLongWE.FormattingEnabled = True
        Me.cmbWLongWE.Location = New System.Drawing.Point(227, 74)
        Me.cmbWLongWE.Name = "cmbWLongWE"
        Me.cmbWLongWE.Size = New System.Drawing.Size(42, 21)
        Me.cmbWLongWE.TabIndex = 127
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(213, 16)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(27, 13)
        Me.Label11.TabIndex = 98
        Me.Label11.Text = "Deg"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(107, 58)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(26, 13)
        Me.Label22.TabIndex = 126
        Me.Label22.Text = "Sec"
        '
        'txtNLatMinutes
        '
        Me.txtNLatMinutes.Location = New System.Drawing.Point(260, 32)
        Me.txtNLatMinutes.Name = "txtNLatMinutes"
        Me.txtNLatMinutes.Size = New System.Drawing.Size(38, 20)
        Me.txtNLatMinutes.TabIndex = 99
        '
        'txtWLongSeconds
        '
        Me.txtWLongSeconds.Location = New System.Drawing.Point(101, 74)
        Me.txtWLongSeconds.Name = "txtWLongSeconds"
        Me.txtWLongSeconds.Size = New System.Drawing.Size(120, 20)
        Me.txtWLongSeconds.TabIndex = 125
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(265, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(24, 13)
        Me.Label10.TabIndex = 100
        Me.Label10.Text = "Min"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(66, 58)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(24, 13)
        Me.Label23.TabIndex = 124
        Me.Label23.Text = "Min"
        '
        'txtNLatSeconds
        '
        Me.txtNLatSeconds.Location = New System.Drawing.Point(304, 32)
        Me.txtNLatSeconds.Name = "txtNLatSeconds"
        Me.txtNLatSeconds.Size = New System.Drawing.Size(120, 20)
        Me.txtNLatSeconds.TabIndex = 101
        '
        'txtWLongMinutes
        '
        Me.txtWLongMinutes.Location = New System.Drawing.Point(58, 74)
        Me.txtWLongMinutes.Name = "txtWLongMinutes"
        Me.txtWLongMinutes.Size = New System.Drawing.Size(38, 20)
        Me.txtWLongMinutes.TabIndex = 123
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(308, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(26, 13)
        Me.Label9.TabIndex = 102
        Me.Label9.Text = "Sec"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(17, 58)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(27, 13)
        Me.Label24.TabIndex = 122
        Me.Label24.Text = "Deg"
        '
        'cmbNLatNS
        '
        Me.cmbNLatNS.FormattingEnabled = True
        Me.cmbNLatNS.Location = New System.Drawing.Point(430, 32)
        Me.cmbNLatNS.Name = "cmbNLatNS"
        Me.cmbNLatNS.Size = New System.Drawing.Size(42, 21)
        Me.cmbNLatNS.TabIndex = 103
        '
        'txtWLongDegrees
        '
        Me.txtWLongDegrees.Location = New System.Drawing.Point(13, 74)
        Me.txtWLongDegrees.Name = "txtWLongDegrees"
        Me.txtWLongDegrees.Size = New System.Drawing.Size(39, 20)
        Me.txtWLongDegrees.TabIndex = 121
        '
        'txtSLatDegrees
        '
        Me.txtSLatDegrees.Location = New System.Drawing.Point(215, 134)
        Me.txtSLatDegrees.Name = "txtSLatDegrees"
        Me.txtSLatDegrees.Size = New System.Drawing.Size(39, 20)
        Me.txtSLatDegrees.TabIndex = 105
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(348, 97)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(93, 13)
        Me.Label17.TabIndex = 120
        Me.Label17.Text = "Eastern Longitude"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(217, 118)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(27, 13)
        Me.Label16.TabIndex = 106
        Me.Label16.Text = "Deg"
        '
        'cmbELongWE
        '
        Me.cmbELongWE.FormattingEnabled = True
        Me.cmbELongWE.Location = New System.Drawing.Point(566, 74)
        Me.cmbELongWE.Name = "cmbELongWE"
        Me.cmbELongWE.Size = New System.Drawing.Size(42, 21)
        Me.cmbELongWE.TabIndex = 119
        '
        'txtSLatMinutes
        '
        Me.txtSLatMinutes.Location = New System.Drawing.Point(260, 134)
        Me.txtSLatMinutes.Name = "txtSLatMinutes"
        Me.txtSLatMinutes.Size = New System.Drawing.Size(38, 20)
        Me.txtSLatMinutes.TabIndex = 107
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(447, 58)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(26, 13)
        Me.Label18.TabIndex = 118
        Me.Label18.Text = "Sec"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(265, 118)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(24, 13)
        Me.Label15.TabIndex = 108
        Me.Label15.Text = "Min"
        '
        'txtELongSeconds
        '
        Me.txtELongSeconds.Location = New System.Drawing.Point(440, 74)
        Me.txtELongSeconds.Name = "txtELongSeconds"
        Me.txtELongSeconds.Size = New System.Drawing.Size(120, 20)
        Me.txtELongSeconds.TabIndex = 117
        '
        'txtSLatSeconds
        '
        Me.txtSLatSeconds.Location = New System.Drawing.Point(304, 134)
        Me.txtSLatSeconds.Name = "txtSLatSeconds"
        Me.txtSLatSeconds.Size = New System.Drawing.Size(120, 20)
        Me.txtSLatSeconds.TabIndex = 109
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(398, 58)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(24, 13)
        Me.Label19.TabIndex = 116
        Me.Label19.Text = "Min"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(308, 118)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(26, 13)
        Me.Label14.TabIndex = 110
        Me.Label14.Text = "Sec"
        '
        'txtELongMinutes
        '
        Me.txtELongMinutes.Location = New System.Drawing.Point(396, 74)
        Me.txtELongMinutes.Name = "txtELongMinutes"
        Me.txtELongMinutes.Size = New System.Drawing.Size(38, 20)
        Me.txtELongMinutes.TabIndex = 115
        '
        'cmbSLatNS
        '
        Me.cmbSLatNS.FormattingEnabled = True
        Me.cmbSLatNS.Location = New System.Drawing.Point(429, 134)
        Me.cmbSLatNS.Name = "cmbSLatNS"
        Me.cmbSLatNS.Size = New System.Drawing.Size(42, 21)
        Me.cmbSLatNS.TabIndex = 111
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(348, 58)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(27, 13)
        Me.Label20.TabIndex = 114
        Me.Label20.Text = "Deg"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(118, 137)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(91, 13)
        Me.Label13.TabIndex = 112
        Me.Label13.Text = "Southern Latitude"
        '
        'txtELongDegrees
        '
        Me.txtELongDegrees.Location = New System.Drawing.Point(351, 74)
        Me.txtELongDegrees.Name = "txtELongDegrees"
        Me.txtELongDegrees.Size = New System.Drawing.Size(39, 20)
        Me.txtELongDegrees.TabIndex = 113
        '
        'txtAreaOfUseName
        '
        Me.txtAreaOfUseName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAreaOfUseName.Location = New System.Drawing.Point(73, 100)
        Me.txtAreaOfUseName.Name = "txtAreaOfUseName"
        Me.txtAreaOfUseName.Size = New System.Drawing.Size(441, 20)
        Me.txtAreaOfUseName.TabIndex = 172
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 103)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 13)
        Me.Label3.TabIndex = 171
        Me.Label3.Text = "Area name:"
        '
        'btnPasteFromClipboard
        '
        Me.btnPasteFromClipboard.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPasteFromClipboard.Location = New System.Drawing.Point(520, 99)
        Me.btnPasteFromClipboard.Name = "btnPasteFromClipboard"
        Me.btnPasteFromClipboard.Size = New System.Drawing.Size(119, 22)
        Me.btnPasteFromClipboard.TabIndex = 201
        Me.btnPasteFromClipboard.Text = "Paste from Clipboard"
        Me.btnPasteFromClipboard.UseVisualStyleBackColor = True
        '
        'btnGetGeoCRSList
        '
        Me.btnGetGeoCRSList.Location = New System.Drawing.Point(12, 12)
        Me.btnGetGeoCRSList.Name = "btnGetGeoCRSList"
        Me.btnGetGeoCRSList.Size = New System.Drawing.Size(150, 22)
        Me.btnGetGeoCRSList.TabIndex = 202
        Me.btnGetGeoCRSList.Text = "Get Geographic CRS List"
        Me.btnGetGeoCRSList.UseVisualStyleBackColor = True
        '
        'btnGetProjCRSList
        '
        Me.btnGetProjCRSList.Location = New System.Drawing.Point(168, 12)
        Me.btnGetProjCRSList.Name = "btnGetProjCRSList"
        Me.btnGetProjCRSList.Size = New System.Drawing.Size(150, 22)
        Me.btnGetProjCRSList.TabIndex = 203
        Me.btnGetProjCRSList.Text = "Get Projected CRS List"
        Me.btnGetProjCRSList.UseVisualStyleBackColor = True
        '
        'rbGetAll
        '
        Me.rbGetAll.AutoSize = True
        Me.rbGetAll.Location = New System.Drawing.Point(6, 19)
        Me.rbGetAll.Name = "rbGetAll"
        Me.rbGetAll.Size = New System.Drawing.Size(204, 17)
        Me.rbGetAll.TabIndex = 204
        Me.rbGetAll.TabStop = True
        Me.rbGetAll.Text = "Get all Coordinate Reference Systems"
        Me.rbGetAll.UseVisualStyleBackColor = True
        '
        'rbExtendingInto
        '
        Me.rbExtendingInto.AutoSize = True
        Me.rbExtendingInto.Location = New System.Drawing.Point(6, 42)
        Me.rbExtendingInto.Name = "rbExtendingInto"
        Me.rbExtendingInto.Size = New System.Drawing.Size(196, 17)
        Me.rbExtendingInto.TabIndex = 205
        Me.rbExtendingInto.TabStop = True
        Me.rbExtendingInto.Text = "Get all CRSs extending into the area"
        Me.rbExtendingInto.UseVisualStyleBackColor = True
        '
        'rbInside
        '
        Me.rbInside.AutoSize = True
        Me.rbInside.Location = New System.Drawing.Point(6, 65)
        Me.rbInside.Name = "rbInside"
        Me.rbInside.Size = New System.Drawing.Size(157, 17)
        Me.rbInside.TabIndex = 206
        Me.rbInside.TabStop = True
        Me.rbInside.Text = "Get all CRSs inside the area"
        Me.rbInside.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.btnPasteFromClipboard)
        Me.GroupBox2.Controls.Add(Me.rbExtendingInto)
        Me.GroupBox2.Controls.Add(Me.rbInside)
        Me.GroupBox2.Controls.Add(Me.rbGetAll)
        Me.GroupBox2.Controls.Add(Me.GroupBox1)
        Me.GroupBox2.Controls.Add(Me.txtAreaOfUseName)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 109)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(645, 303)
        Me.GroupBox2.TabIndex = 207
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Selection Area:"
        '
        'chkGeographic2D
        '
        Me.chkGeographic2D.AutoSize = True
        Me.chkGeographic2D.Location = New System.Drawing.Point(12, 40)
        Me.chkGeographic2D.Name = "chkGeographic2D"
        Me.chkGeographic2D.Size = New System.Drawing.Size(98, 17)
        Me.chkGeographic2D.TabIndex = 208
        Me.chkGeographic2D.Text = "Geographic 2D"
        Me.chkGeographic2D.UseVisualStyleBackColor = True
        '
        'chkGeographic3D
        '
        Me.chkGeographic3D.AutoSize = True
        Me.chkGeographic3D.Location = New System.Drawing.Point(12, 63)
        Me.chkGeographic3D.Name = "chkGeographic3D"
        Me.chkGeographic3D.Size = New System.Drawing.Size(98, 17)
        Me.chkGeographic3D.TabIndex = 209
        Me.chkGeographic3D.Text = "Geographic 3D"
        Me.chkGeographic3D.UseVisualStyleBackColor = True
        '
        'frmGetCRSList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(669, 424)
        Me.Controls.Add(Me.chkGeographic3D)
        Me.Controls.Add(Me.chkGeographic2D)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnGetProjCRSList)
        Me.Controls.Add(Me.btnGetGeoCRSList)
        Me.Controls.Add(Me.btnExit)
        Me.Name = "frmGetCRSList"
        Me.Text = "Get Coordinate Reference System List"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnExit As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents txtNLatDegrees As TextBox
    Friend WithEvents cmbWLongWE As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents txtNLatMinutes As TextBox
    Friend WithEvents txtWLongSeconds As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents txtNLatSeconds As TextBox
    Friend WithEvents txtWLongMinutes As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents cmbNLatNS As ComboBox
    Friend WithEvents txtWLongDegrees As TextBox
    Friend WithEvents txtSLatDegrees As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents cmbELongWE As ComboBox
    Friend WithEvents txtSLatMinutes As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents txtELongSeconds As TextBox
    Friend WithEvents txtSLatSeconds As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents txtELongMinutes As TextBox
    Friend WithEvents cmbSLatNS As ComboBox
    Friend WithEvents Label20 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents txtELongDegrees As TextBox
    Friend WithEvents txtAreaOfUseName As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btnPasteFromClipboard As Button
    Friend WithEvents btnGetGeoCRSList As Button
    Friend WithEvents btnGetProjCRSList As Button
    Friend WithEvents rbGetAll As RadioButton
    Friend WithEvents rbExtendingInto As RadioButton
    Friend WithEvents rbInside As RadioButton
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents chkGeographic2D As CheckBox
    Friend WithEvents chkGeographic3D As CheckBox
End Class
