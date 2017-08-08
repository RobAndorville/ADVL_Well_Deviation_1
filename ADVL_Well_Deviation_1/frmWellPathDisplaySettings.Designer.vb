<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWellPathDisplaySettings
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.btnApply = New System.Windows.Forms.Button()
        Me.rbUseLocalSettings = New System.Windows.Forms.RadioButton()
        Me.rbUseProjectSettings = New System.Windows.Forms.RadioButton()
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.Location = New System.Drawing.Point(575, 12)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(64, 22)
        Me.btnExit.TabIndex = 9
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(12, 40)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(627, 458)
        Me.TabControl1.TabIndex = 10
        '
        'TabPage1
        '
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(619, 432)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "East-West Section"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(619, 432)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "North-South Section"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(619, 432)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Plan View"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'btnApply
        '
        Me.btnApply.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnApply.Location = New System.Drawing.Point(12, 12)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(64, 22)
        Me.btnApply.TabIndex = 11
        Me.btnApply.Text = "Apply"
        Me.btnApply.UseVisualStyleBackColor = True
        '
        'rbUseLocalSettings
        '
        Me.rbUseLocalSettings.AutoSize = True
        Me.rbUseLocalSettings.Location = New System.Drawing.Point(82, 15)
        Me.rbUseLocalSettings.Name = "rbUseLocalSettings"
        Me.rbUseLocalSettings.Size = New System.Drawing.Size(114, 17)
        Me.rbUseLocalSettings.TabIndex = 12
        Me.rbUseLocalSettings.TabStop = True
        Me.rbUseLocalSettings.Text = "Use Local Settings"
        Me.rbUseLocalSettings.UseVisualStyleBackColor = True
        '
        'rbUseProjectSettings
        '
        Me.rbUseProjectSettings.AutoSize = True
        Me.rbUseProjectSettings.Location = New System.Drawing.Point(202, 17)
        Me.rbUseProjectSettings.Name = "rbUseProjectSettings"
        Me.rbUseProjectSettings.Size = New System.Drawing.Size(121, 17)
        Me.rbUseProjectSettings.TabIndex = 13
        Me.rbUseProjectSettings.TabStop = True
        Me.rbUseProjectSettings.Text = "Use Project Settings"
        Me.rbUseProjectSettings.UseVisualStyleBackColor = True
        '
        'frmWellPathDisplaySettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(651, 510)
        Me.Controls.Add(Me.rbUseProjectSettings)
        Me.Controls.Add(Me.rbUseLocalSettings)
        Me.Controls.Add(Me.btnApply)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btnExit)
        Me.Name = "frmWellPathDisplaySettings"
        Me.Text = "Well Path Display Settings"
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnExit As Button
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents btnApply As Button
    Friend WithEvents rbUseLocalSettings As RadioButton
    Friend WithEvents rbUseProjectSettings As RadioButton
End Class
