<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea3 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend3 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series3 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnOnline = New System.Windows.Forms.Button()
        Me.btnMessages = New System.Windows.Forms.Button()
        Me.btnAppInfo = New System.Windows.Forms.Button()
        Me.btnAndorville = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.txtFileName = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtCalcOffsetDecPl = New System.Windows.Forms.TextBox()
        Me.txtCalcDepthDecPl = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.cmbCalcOffsetUnit = New System.Windows.Forms.ComboBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.cmbCalcDepthUnit = New System.Windows.Forms.ComboBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cmbMeasDepthUnit = New System.Windows.Forms.ComboBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.cmbMeasNorthReference = New System.Windows.Forms.ComboBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.cmbMeasAngleUnit = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtRT = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnCalculateProjCoords = New System.Windows.Forms.Button()
        Me.txtLongSign = New System.Windows.Forms.TextBox()
        Me.txtLatSign = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.txtLongSec = New System.Windows.Forms.TextBox()
        Me.txtLongMin = New System.Windows.Forms.TextBox()
        Me.txtLongDeg = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtLatSec = New System.Windows.Forms.TextBox()
        Me.txtLatMin = New System.Windows.Forms.TextBox()
        Me.txtLatDeg = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.btnGetProjCRSList = New System.Windows.Forms.Button()
        Me.btnGetGeoCRSList = New System.Windows.Forms.Button()
        Me.txtEasting = New System.Windows.Forms.TextBox()
        Me.txtNorthing = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtLatitude = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtLongitude = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cmbProjCRS = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cmbGeoCRS = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtBoreholeName = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtWellName = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.btnAddRow = New System.Windows.Forms.Button()
        Me.dgvMeasuredData = New System.Windows.Forms.DataGridView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvCalculatedData = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.txtInterpolateddY = New System.Windows.Forms.TextBox()
        Me.txtInterpolateddX = New System.Windows.Forms.TextBox()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.txtInterpolatedNorthing = New System.Windows.Forms.TextBox()
        Me.txtInterpolatedEasting = New System.Windows.Forms.TextBox()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.txtInterpolatedTVDSS = New System.Windows.Forms.TextBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.txtInterpolatedTVDRT = New System.Windows.Forms.TextBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.txtInputDepthValue = New System.Windows.Forms.TextBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.cmbInputDepth = New System.Windows.Forms.ComboBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.cmbInterpolationType = New System.Windows.Forms.ComboBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnCalculateWellPath = New System.Windows.Forms.Button()
        Me.cmbCalcMethod = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Chart2 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Chart3 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.btnOpenParentDir = New System.Windows.Forms.Button()
        Me.btnOpenArchive = New System.Windows.Forms.Button()
        Me.btnCreateArchive = New System.Windows.Forms.Button()
        Me.btnShowProjectInfo = New System.Windows.Forms.Button()
        Me.chkConnect = New System.Windows.Forms.CheckBox()
        Me.btnOpenProject = New System.Windows.Forms.Button()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.txtProjectPath = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtProNetName = New System.Windows.Forms.TextBox()
        Me.btnOpenAppDir = New System.Windows.Forms.Button()
        Me.btnOpenSystem = New System.Windows.Forms.Button()
        Me.btnOpenData = New System.Windows.Forms.Button()
        Me.btnOpenSettings = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.txtParentProject = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnParameters = New System.Windows.Forms.Button()
        Me.Label79 = New System.Windows.Forms.Label()
        Me.txtSystemLocationType = New System.Windows.Forms.TextBox()
        Me.txtSystemPath = New System.Windows.Forms.TextBox()
        Me.txtCurrentDuration = New System.Windows.Forms.TextBox()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.txtTotalDuration = New System.Windows.Forms.TextBox()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.txtLastUsed = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtCreationDate = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtDataPath = New System.Windows.Forms.TextBox()
        Me.txtDataLocationType = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtSettingsPath = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtSettingsLocationType = New System.Windows.Forms.TextBox()
        Me.txtProjectType = New System.Windows.Forms.TextBox()
        Me.txtProjectDescription = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtProjectName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnProject = New System.Windows.Forms.Button()
        Me.btnOpen = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.btnWebPages = New System.Windows.Forms.Button()
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1_EditWorkflowTabPage = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1_ShowStartPageInWorkflowTab = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TabControl1.SuspendLayout()
        Me.TabPage6.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.dgvMeasuredData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.dgvCalculatedData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        Me.ContextMenuStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.Location = New System.Drawing.Point(779, 12)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(64, 22)
        Me.btnExit.TabIndex = 8
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnOnline
        '
        Me.btnOnline.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOnline.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOnline.ForeColor = System.Drawing.Color.Red
        Me.btnOnline.Location = New System.Drawing.Point(717, 12)
        Me.btnOnline.Name = "btnOnline"
        Me.btnOnline.Size = New System.Drawing.Size(56, 22)
        Me.btnOnline.TabIndex = 37
        Me.btnOnline.Text = "Offline"
        Me.btnOnline.UseVisualStyleBackColor = True
        '
        'btnMessages
        '
        Me.btnMessages.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMessages.Location = New System.Drawing.Point(639, 12)
        Me.btnMessages.Name = "btnMessages"
        Me.btnMessages.Size = New System.Drawing.Size(72, 22)
        Me.btnMessages.TabIndex = 38
        Me.btnMessages.Text = "Messages"
        Me.btnMessages.UseVisualStyleBackColor = True
        '
        'btnAppInfo
        '
        Me.btnAppInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAppInfo.Location = New System.Drawing.Point(538, 12)
        Me.btnAppInfo.Name = "btnAppInfo"
        Me.btnAppInfo.Size = New System.Drawing.Size(95, 22)
        Me.btnAppInfo.TabIndex = 46
        Me.btnAppInfo.Text = "Application Info"
        Me.btnAppInfo.UseVisualStyleBackColor = True
        '
        'btnAndorville
        '
        Me.btnAndorville.BackgroundImage = Global.ADVL_Well_Deviation_1.My.Resources.Resources.Andorville_16May16_TM_Crop_Grey
        Me.btnAndorville.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAndorville.Font = New System.Drawing.Font("Harlow Solid Italic", 14.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAndorville.Location = New System.Drawing.Point(5, 5)
        Me.btnAndorville.Name = "btnAndorville"
        Me.btnAndorville.Size = New System.Drawing.Size(118, 29)
        Me.btnAndorville.TabIndex = 50
        Me.btnAndorville.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage6)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(12, 40)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(831, 479)
        Me.TabControl1.TabIndex = 51
        '
        'TabPage6
        '
        Me.TabPage6.Controls.Add(Me.WebBrowser1)
        Me.TabPage6.Location = New System.Drawing.Point(4, 22)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Size = New System.Drawing.Size(823, 453)
        Me.TabPage6.TabIndex = 5
        Me.TabPage6.Text = "Workflow"
        Me.TabPage6.UseVisualStyleBackColor = True
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.WebBrowser1.Location = New System.Drawing.Point(3, 3)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(817, 447)
        Me.WebBrowser1.TabIndex = 69
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.txtFileName)
        Me.TabPage4.Controls.Add(Me.Label27)
        Me.TabPage4.Controls.Add(Me.GroupBox3)
        Me.TabPage4.Controls.Add(Me.txtRT)
        Me.TabPage4.Controls.Add(Me.Label21)
        Me.TabPage4.Controls.Add(Me.GroupBox2)
        Me.TabPage4.Controls.Add(Me.txtBoreholeName)
        Me.TabPage4.Controls.Add(Me.Label14)
        Me.TabPage4.Controls.Add(Me.txtWellName)
        Me.TabPage4.Controls.Add(Me.Label13)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(823, 453)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Well Information"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'txtFileName
        '
        Me.txtFileName.Location = New System.Drawing.Point(90, 12)
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.Size = New System.Drawing.Size(565, 20)
        Me.txtFileName.TabIndex = 9
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(3, 15)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(55, 13)
        Me.Label27.TabIndex = 8
        Me.Label27.Text = "File name:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.GroupBox5)
        Me.GroupBox3.Controls.Add(Me.GroupBox4)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 297)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(649, 138)
        Me.GroupBox3.TabIndex = 7
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Units:"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txtCalcOffsetDecPl)
        Me.GroupBox5.Controls.Add(Me.txtCalcDepthDecPl)
        Me.GroupBox5.Controls.Add(Me.Label37)
        Me.GroupBox5.Controls.Add(Me.cmbCalcOffsetUnit)
        Me.GroupBox5.Controls.Add(Me.Label26)
        Me.GroupBox5.Controls.Add(Me.cmbCalcDepthUnit)
        Me.GroupBox5.Controls.Add(Me.Label25)
        Me.GroupBox5.Location = New System.Drawing.Point(291, 19)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(344, 105)
        Me.GroupBox5.TabIndex = 7
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Calculated Data:"
        '
        'txtCalcOffsetDecPl
        '
        Me.txtCalcOffsetDecPl.Location = New System.Drawing.Point(255, 63)
        Me.txtCalcOffsetDecPl.Name = "txtCalcOffsetDecPl"
        Me.txtCalcOffsetDecPl.Size = New System.Drawing.Size(37, 20)
        Me.txtCalcOffsetDecPl.TabIndex = 6
        '
        'txtCalcDepthDecPl
        '
        Me.txtCalcDepthDecPl.Location = New System.Drawing.Point(255, 36)
        Me.txtCalcDepthDecPl.Name = "txtCalcDepthDecPl"
        Me.txtCalcDepthDecPl.Size = New System.Drawing.Size(37, 20)
        Me.txtCalcDepthDecPl.TabIndex = 5
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(252, 16)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(83, 13)
        Me.Label37.TabIndex = 4
        Me.Label37.Text = "Decimal Places:"
        '
        'cmbCalcOffsetUnit
        '
        Me.cmbCalcOffsetUnit.FormattingEnabled = True
        Me.cmbCalcOffsetUnit.Location = New System.Drawing.Point(71, 63)
        Me.cmbCalcOffsetUnit.Name = "cmbCalcOffsetUnit"
        Me.cmbCalcOffsetUnit.Size = New System.Drawing.Size(165, 21)
        Me.cmbCalcOffsetUnit.TabIndex = 3
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(6, 66)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(58, 13)
        Me.Label26.TabIndex = 2
        Me.Label26.Text = "Offset unit:"
        '
        'cmbCalcDepthUnit
        '
        Me.cmbCalcDepthUnit.FormattingEnabled = True
        Me.cmbCalcDepthUnit.Location = New System.Drawing.Point(71, 36)
        Me.cmbCalcDepthUnit.Name = "cmbCalcDepthUnit"
        Me.cmbCalcDepthUnit.Size = New System.Drawing.Size(165, 21)
        Me.cmbCalcDepthUnit.TabIndex = 1
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(6, 39)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(59, 13)
        Me.Label25.TabIndex = 0
        Me.Label25.Text = "Depth unit:"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cmbMeasDepthUnit)
        Me.GroupBox4.Controls.Add(Me.Label24)
        Me.GroupBox4.Controls.Add(Me.cmbMeasNorthReference)
        Me.GroupBox4.Controls.Add(Me.Label22)
        Me.GroupBox4.Controls.Add(Me.cmbMeasAngleUnit)
        Me.GroupBox4.Controls.Add(Me.Label23)
        Me.GroupBox4.Location = New System.Drawing.Point(9, 19)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(271, 106)
        Me.GroupBox4.TabIndex = 6
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Measured Data:"
        '
        'cmbMeasDepthUnit
        '
        Me.cmbMeasDepthUnit.FormattingEnabled = True
        Me.cmbMeasDepthUnit.Location = New System.Drawing.Point(96, 19)
        Me.cmbMeasDepthUnit.Name = "cmbMeasDepthUnit"
        Me.cmbMeasDepthUnit.Size = New System.Drawing.Size(165, 21)
        Me.cmbMeasDepthUnit.TabIndex = 1
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(6, 76)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(84, 13)
        Me.Label24.TabIndex = 4
        Me.Label24.Text = "North reference:"
        '
        'cmbMeasNorthReference
        '
        Me.cmbMeasNorthReference.FormattingEnabled = True
        Me.cmbMeasNorthReference.Location = New System.Drawing.Point(96, 73)
        Me.cmbMeasNorthReference.Name = "cmbMeasNorthReference"
        Me.cmbMeasNorthReference.Size = New System.Drawing.Size(165, 21)
        Me.cmbMeasNorthReference.TabIndex = 5
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(6, 22)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(59, 13)
        Me.Label22.TabIndex = 0
        Me.Label22.Text = "Depth unit:"
        '
        'cmbMeasAngleUnit
        '
        Me.cmbMeasAngleUnit.FormattingEnabled = True
        Me.cmbMeasAngleUnit.Location = New System.Drawing.Point(96, 46)
        Me.cmbMeasAngleUnit.Name = "cmbMeasAngleUnit"
        Me.cmbMeasAngleUnit.Size = New System.Drawing.Size(165, 21)
        Me.cmbMeasAngleUnit.TabIndex = 3
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(6, 49)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(57, 13)
        Me.Label23.TabIndex = 2
        Me.Label23.Text = "Angle unit:"
        '
        'txtRT
        '
        Me.txtRT.Location = New System.Drawing.Point(90, 90)
        Me.txtRT.Name = "txtRT"
        Me.txtRT.Size = New System.Drawing.Size(41, 20)
        Me.txtRT.TabIndex = 6
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(59, 93)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(25, 13)
        Me.Label21.TabIndex = 5
        Me.Label21.Text = "RT:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnCalculateProjCoords)
        Me.GroupBox2.Controls.Add(Me.txtLongSign)
        Me.GroupBox2.Controls.Add(Me.txtLatSign)
        Me.GroupBox2.Controls.Add(Me.Label33)
        Me.GroupBox2.Controls.Add(Me.Label34)
        Me.GroupBox2.Controls.Add(Me.Label35)
        Me.GroupBox2.Controls.Add(Me.txtLongSec)
        Me.GroupBox2.Controls.Add(Me.txtLongMin)
        Me.GroupBox2.Controls.Add(Me.txtLongDeg)
        Me.GroupBox2.Controls.Add(Me.Label32)
        Me.GroupBox2.Controls.Add(Me.Label31)
        Me.GroupBox2.Controls.Add(Me.Label30)
        Me.GroupBox2.Controls.Add(Me.Label29)
        Me.GroupBox2.Controls.Add(Me.txtLatSec)
        Me.GroupBox2.Controls.Add(Me.txtLatMin)
        Me.GroupBox2.Controls.Add(Me.txtLatDeg)
        Me.GroupBox2.Controls.Add(Me.Label28)
        Me.GroupBox2.Controls.Add(Me.btnGetProjCRSList)
        Me.GroupBox2.Controls.Add(Me.btnGetGeoCRSList)
        Me.GroupBox2.Controls.Add(Me.txtEasting)
        Me.GroupBox2.Controls.Add(Me.txtNorthing)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.txtLatitude)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.txtLongitude)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.cmbProjCRS)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.cmbGeoCRS)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 116)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(649, 161)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Surface Location"
        '
        'btnCalculateProjCoords
        '
        Me.btnCalculateProjCoords.Location = New System.Drawing.Point(557, 125)
        Me.btnCalculateProjCoords.Name = "btnCalculateProjCoords"
        Me.btnCalculateProjCoords.Size = New System.Drawing.Size(60, 22)
        Me.btnCalculateProjCoords.TabIndex = 29
        Me.btnCalculateProjCoords.Text = "Calculate"
        Me.btnCalculateProjCoords.UseVisualStyleBackColor = True
        '
        'txtLongSign
        '
        Me.txtLongSign.Location = New System.Drawing.Point(356, 66)
        Me.txtLongSign.Name = "txtLongSign"
        Me.txtLongSign.Size = New System.Drawing.Size(12, 20)
        Me.txtLongSign.TabIndex = 28
        '
        'txtLatSign
        '
        Me.txtLatSign.Location = New System.Drawing.Point(22, 66)
        Me.txtLatSign.Name = "txtLatSign"
        Me.txtLatSign.Size = New System.Drawing.Size(12, 20)
        Me.txtLatSign.TabIndex = 10
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(622, 69)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(24, 13)
        Me.Label33.TabIndex = 27
        Me.Label33.Text = "sec"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(500, 69)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(23, 13)
        Me.Label34.TabIndex = 26
        Me.Label34.Text = "min"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(419, 69)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(25, 13)
        Me.Label35.TabIndex = 25
        Me.Label35.Text = "deg"
        '
        'txtLongSec
        '
        Me.txtLongSec.Location = New System.Drawing.Point(533, 66)
        Me.txtLongSec.Name = "txtLongSec"
        Me.txtLongSec.Size = New System.Drawing.Size(83, 20)
        Me.txtLongSec.TabIndex = 24
        '
        'txtLongMin
        '
        Me.txtLongMin.Location = New System.Drawing.Point(454, 66)
        Me.txtLongMin.Name = "txtLongMin"
        Me.txtLongMin.Size = New System.Drawing.Size(40, 20)
        Me.txtLongMin.TabIndex = 23
        '
        'txtLongDeg
        '
        Me.txtLongDeg.Location = New System.Drawing.Point(374, 66)
        Me.txtLongDeg.Name = "txtLongDeg"
        Me.txtLongDeg.Size = New System.Drawing.Size(40, 20)
        Me.txtLongDeg.TabIndex = 22
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(266, 43)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(46, 13)
        Me.Label32.TabIndex = 21
        Me.Label32.Text = "dec deg"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(288, 69)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(24, 13)
        Me.Label31.TabIndex = 20
        Me.Label31.Text = "sec"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(166, 69)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(23, 13)
        Me.Label30.TabIndex = 19
        Me.Label30.Text = "min"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(85, 69)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(25, 13)
        Me.Label29.TabIndex = 18
        Me.Label29.Text = "deg"
        '
        'txtLatSec
        '
        Me.txtLatSec.Location = New System.Drawing.Point(199, 66)
        Me.txtLatSec.Name = "txtLatSec"
        Me.txtLatSec.Size = New System.Drawing.Size(83, 20)
        Me.txtLatSec.TabIndex = 17
        '
        'txtLatMin
        '
        Me.txtLatMin.Location = New System.Drawing.Point(120, 66)
        Me.txtLatMin.Name = "txtLatMin"
        Me.txtLatMin.Size = New System.Drawing.Size(40, 20)
        Me.txtLatMin.TabIndex = 16
        '
        'txtLatDeg
        '
        Me.txtLatDeg.Location = New System.Drawing.Point(40, 66)
        Me.txtLatDeg.Name = "txtLatDeg"
        Me.txtLatDeg.Size = New System.Drawing.Size(40, 20)
        Me.txtLatDeg.TabIndex = 15
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(600, 43)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(46, 13)
        Me.Label28.TabIndex = 14
        Me.Label28.Text = "dec deg"
        '
        'btnGetProjCRSList
        '
        Me.btnGetProjCRSList.Location = New System.Drawing.Point(557, 99)
        Me.btnGetProjCRSList.Name = "btnGetProjCRSList"
        Me.btnGetProjCRSList.Size = New System.Drawing.Size(55, 22)
        Me.btnGetProjCRSList.TabIndex = 13
        Me.btnGetProjCRSList.Text = "Get List"
        Me.btnGetProjCRSList.UseVisualStyleBackColor = True
        '
        'btnGetGeoCRSList
        '
        Me.btnGetGeoCRSList.Location = New System.Drawing.Point(557, 13)
        Me.btnGetGeoCRSList.Name = "btnGetGeoCRSList"
        Me.btnGetGeoCRSList.Size = New System.Drawing.Size(55, 22)
        Me.btnGetGeoCRSList.TabIndex = 12
        Me.btnGetGeoCRSList.Text = "Get List"
        Me.btnGetGeoCRSList.UseVisualStyleBackColor = True
        '
        'txtEasting
        '
        Me.txtEasting.Location = New System.Drawing.Point(60, 126)
        Me.txtEasting.Name = "txtEasting"
        Me.txtEasting.Size = New System.Drawing.Size(200, 20)
        Me.txtEasting.TabIndex = 11
        '
        'txtNorthing
        '
        Me.txtNorthing.Location = New System.Drawing.Point(351, 126)
        Me.txtNorthing.Name = "txtNorthing"
        Me.txtNorthing.Size = New System.Drawing.Size(200, 20)
        Me.txtNorthing.TabIndex = 10
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(288, 129)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(50, 13)
        Me.Label20.TabIndex = 9
        Me.Label20.Text = "Northing:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(6, 129)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(45, 13)
        Me.Label19.TabIndex = 8
        Me.Label19.Text = "Easting:"
        '
        'txtLatitude
        '
        Me.txtLatitude.Location = New System.Drawing.Point(60, 40)
        Me.txtLatitude.Name = "txtLatitude"
        Me.txtLatitude.Size = New System.Drawing.Size(200, 20)
        Me.txtLatitude.TabIndex = 7
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(331, 43)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(57, 13)
        Me.Label18.TabIndex = 6
        Me.Label18.Text = "Longitude:"
        '
        'txtLongitude
        '
        Me.txtLongitude.Location = New System.Drawing.Point(394, 40)
        Me.txtLongitude.Name = "txtLongitude"
        Me.txtLongitude.Size = New System.Drawing.Size(200, 20)
        Me.txtLongitude.TabIndex = 5
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(6, 43)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(48, 13)
        Me.Label17.TabIndex = 4
        Me.Label17.Text = "Latitude:"
        '
        'cmbProjCRS
        '
        Me.cmbProjCRS.FormattingEnabled = True
        Me.cmbProjCRS.Location = New System.Drawing.Point(221, 99)
        Me.cmbProjCRS.Name = "cmbProjCRS"
        Me.cmbProjCRS.Size = New System.Drawing.Size(330, 21)
        Me.cmbProjCRS.TabIndex = 3
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(6, 102)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(199, 13)
        Me.Label16.TabIndex = 2
        Me.Label16.Text = "Projected Coordinate Reference System:"
        '
        'cmbGeoCRS
        '
        Me.cmbGeoCRS.FormattingEnabled = True
        Me.cmbGeoCRS.Location = New System.Drawing.Point(221, 13)
        Me.cmbGeoCRS.Name = "cmbGeoCRS"
        Me.cmbGeoCRS.Size = New System.Drawing.Size(330, 21)
        Me.cmbGeoCRS.TabIndex = 1
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(6, 16)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(209, 13)
        Me.Label15.TabIndex = 0
        Me.Label15.Text = "Geographic Coordinate Reference System:"
        '
        'txtBoreholeName
        '
        Me.txtBoreholeName.Location = New System.Drawing.Point(90, 64)
        Me.txtBoreholeName.Name = "txtBoreholeName"
        Me.txtBoreholeName.Size = New System.Drawing.Size(565, 20)
        Me.txtBoreholeName.TabIndex = 3
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(3, 67)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(81, 13)
        Me.Label14.TabIndex = 2
        Me.Label14.Text = "Borehole name:"
        '
        'txtWellName
        '
        Me.txtWellName.Location = New System.Drawing.Point(90, 38)
        Me.txtWellName.Name = "txtWellName"
        Me.txtWellName.Size = New System.Drawing.Size(565, 20)
        Me.txtWellName.TabIndex = 1
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(3, 41)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(60, 13)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Well name:"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.SplitContainer1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(823, 453)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Deviation Data"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(6, 6)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnAddRow)
        Me.SplitContainer1.Panel1.Controls.Add(Me.dgvMeasuredData)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgvCalculatedData)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label2)
        Me.SplitContainer1.Size = New System.Drawing.Size(811, 433)
        Me.SplitContainer1.SplitterDistance = 310
        Me.SplitContainer1.TabIndex = 0
        '
        'btnAddRow
        '
        Me.btnAddRow.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnAddRow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddRow.Location = New System.Drawing.Point(115, 5)
        Me.btnAddRow.Name = "btnAddRow"
        Me.btnAddRow.Size = New System.Drawing.Size(56, 18)
        Me.btnAddRow.TabIndex = 2
        Me.btnAddRow.Text = "Add Row"
        Me.btnAddRow.UseVisualStyleBackColor = True
        '
        'dgvMeasuredData
        '
        Me.dgvMeasuredData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvMeasuredData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMeasuredData.ContextMenuStrip = Me.ContextMenuStrip1
        Me.dgvMeasuredData.Location = New System.Drawing.Point(6, 27)
        Me.dgvMeasuredData.Name = "dgvMeasuredData"
        Me.dgvMeasuredData.Size = New System.Drawing.Size(301, 403)
        Me.dgvMeasuredData.TabIndex = 1
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CutToolStripMenuItem, Me.CopyToolStripMenuItem, Me.PasteToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(103, 70)
        '
        'CutToolStripMenuItem
        '
        Me.CutToolStripMenuItem.Name = "CutToolStripMenuItem"
        Me.CutToolStripMenuItem.Size = New System.Drawing.Size(102, 22)
        Me.CutToolStripMenuItem.Text = "Cut"
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(102, 22)
        Me.CopyToolStripMenuItem.Text = "Copy"
        '
        'PasteToolStripMenuItem
        '
        Me.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem"
        Me.PasteToolStripMenuItem.Size = New System.Drawing.Size(102, 22)
        Me.PasteToolStripMenuItem.Text = "Paste"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Measured Data"
        '
        'dgvCalculatedData
        '
        Me.dgvCalculatedData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCalculatedData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCalculatedData.Location = New System.Drawing.Point(6, 27)
        Me.dgvCalculatedData.Name = "dgvCalculatedData"
        Me.dgvCalculatedData.Size = New System.Drawing.Size(488, 403)
        Me.dgvCalculatedData.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Calculated Data"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.GroupBox6)
        Me.TabPage3.Controls.Add(Me.GroupBox1)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(823, 453)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Calculations"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.GroupBox7)
        Me.GroupBox6.Controls.Add(Me.txtInputDepthValue)
        Me.GroupBox6.Controls.Add(Me.Label39)
        Me.GroupBox6.Controls.Add(Me.cmbInputDepth)
        Me.GroupBox6.Controls.Add(Me.Label38)
        Me.GroupBox6.Controls.Add(Me.cmbInterpolationType)
        Me.GroupBox6.Controls.Add(Me.Label36)
        Me.GroupBox6.Location = New System.Drawing.Point(3, 123)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(470, 289)
        Me.GroupBox6.TabIndex = 1
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Interpolation"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.Label51)
        Me.GroupBox7.Controls.Add(Me.Label50)
        Me.GroupBox7.Controls.Add(Me.txtInterpolateddY)
        Me.GroupBox7.Controls.Add(Me.txtInterpolateddX)
        Me.GroupBox7.Controls.Add(Me.Label49)
        Me.GroupBox7.Controls.Add(Me.Label48)
        Me.GroupBox7.Controls.Add(Me.Label47)
        Me.GroupBox7.Controls.Add(Me.Label46)
        Me.GroupBox7.Controls.Add(Me.Label45)
        Me.GroupBox7.Controls.Add(Me.Label44)
        Me.GroupBox7.Controls.Add(Me.Label43)
        Me.GroupBox7.Controls.Add(Me.txtInterpolatedNorthing)
        Me.GroupBox7.Controls.Add(Me.txtInterpolatedEasting)
        Me.GroupBox7.Controls.Add(Me.Label42)
        Me.GroupBox7.Controls.Add(Me.txtInterpolatedTVDSS)
        Me.GroupBox7.Controls.Add(Me.Label41)
        Me.GroupBox7.Controls.Add(Me.txtInterpolatedTVDRT)
        Me.GroupBox7.Controls.Add(Me.Label40)
        Me.GroupBox7.Location = New System.Drawing.Point(9, 73)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(444, 207)
        Me.GroupBox7.TabIndex = 6
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Interpolated Values:"
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Location = New System.Drawing.Point(304, 100)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(45, 13)
        Me.Label51.TabIndex = 17
        Me.Label51.Text = "Label51"
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Location = New System.Drawing.Point(304, 74)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(45, 13)
        Me.Label50.TabIndex = 16
        Me.Label50.Text = "Label50"
        '
        'txtInterpolateddY
        '
        Me.txtInterpolateddY.Location = New System.Drawing.Point(148, 97)
        Me.txtInterpolateddY.Name = "txtInterpolateddY"
        Me.txtInterpolateddY.Size = New System.Drawing.Size(150, 20)
        Me.txtInterpolateddY.TabIndex = 15
        '
        'txtInterpolateddX
        '
        Me.txtInterpolateddX.Location = New System.Drawing.Point(148, 71)
        Me.txtInterpolateddX.Name = "txtInterpolateddX"
        Me.txtInterpolateddX.Size = New System.Drawing.Size(150, 20)
        Me.txtInterpolateddX.TabIndex = 14
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Location = New System.Drawing.Point(8, 100)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(23, 13)
        Me.Label49.TabIndex = 13
        Me.Label49.Text = "dY:"
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Location = New System.Drawing.Point(8, 74)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(23, 13)
        Me.Label48.TabIndex = 12
        Me.Label48.Text = "dX:"
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Location = New System.Drawing.Point(304, 152)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(45, 13)
        Me.Label47.TabIndex = 11
        Me.Label47.Text = "Label47"
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Location = New System.Drawing.Point(304, 126)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(45, 13)
        Me.Label46.TabIndex = 10
        Me.Label46.Text = "Label46"
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Location = New System.Drawing.Point(304, 48)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(45, 13)
        Me.Label45.TabIndex = 9
        Me.Label45.Text = "Label45"
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Location = New System.Drawing.Point(304, 22)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(45, 13)
        Me.Label44.TabIndex = 8
        Me.Label44.Text = "Label44"
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Location = New System.Drawing.Point(6, 152)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(50, 13)
        Me.Label43.TabIndex = 7
        Me.Label43.Text = "Northing:"
        '
        'txtInterpolatedNorthing
        '
        Me.txtInterpolatedNorthing.Location = New System.Drawing.Point(148, 149)
        Me.txtInterpolatedNorthing.Name = "txtInterpolatedNorthing"
        Me.txtInterpolatedNorthing.Size = New System.Drawing.Size(150, 20)
        Me.txtInterpolatedNorthing.TabIndex = 6
        '
        'txtInterpolatedEasting
        '
        Me.txtInterpolatedEasting.Location = New System.Drawing.Point(148, 123)
        Me.txtInterpolatedEasting.Name = "txtInterpolatedEasting"
        Me.txtInterpolatedEasting.Size = New System.Drawing.Size(150, 20)
        Me.txtInterpolatedEasting.TabIndex = 5
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Location = New System.Drawing.Point(6, 126)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(45, 13)
        Me.Label42.TabIndex = 4
        Me.Label42.Text = "Easting:"
        '
        'txtInterpolatedTVDSS
        '
        Me.txtInterpolatedTVDSS.Location = New System.Drawing.Point(148, 45)
        Me.txtInterpolatedTVDSS.Name = "txtInterpolatedTVDSS"
        Me.txtInterpolatedTVDSS.Size = New System.Drawing.Size(150, 20)
        Me.txtInterpolatedTVDSS.TabIndex = 3
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(6, 48)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(136, 13)
        Me.Label41.TabIndex = 2
        Me.Label41.Text = "True vertical depth subsea:"
        '
        'txtInterpolatedTVDRT
        '
        Me.txtInterpolatedTVDRT.Location = New System.Drawing.Point(148, 19)
        Me.txtInterpolatedTVDRT.Name = "txtInterpolatedTVDRT"
        Me.txtInterpolatedTVDRT.Size = New System.Drawing.Size(150, 20)
        Me.txtInterpolatedTVDRT.TabIndex = 1
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(6, 22)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(117, 13)
        Me.Label40.TabIndex = 0
        Me.Label40.Text = "True vertical depth RT:"
        '
        'txtInputDepthValue
        '
        Me.txtInputDepthValue.Location = New System.Drawing.Point(294, 47)
        Me.txtInputDepthValue.Name = "txtInputDepthValue"
        Me.txtInputDepthValue.Size = New System.Drawing.Size(134, 20)
        Me.txtInputDepthValue.TabIndex = 5
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(434, 50)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(31, 13)
        Me.Label39.TabIndex = 4
        Me.Label39.Text = "Units"
        '
        'cmbInputDepth
        '
        Me.cmbInputDepth.FormattingEnabled = True
        Me.cmbInputDepth.Location = New System.Drawing.Point(76, 46)
        Me.cmbInputDepth.Name = "cmbInputDepth"
        Me.cmbInputDepth.Size = New System.Drawing.Size(212, 21)
        Me.cmbInputDepth.TabIndex = 3
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(6, 49)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(64, 13)
        Me.Label38.TabIndex = 2
        Me.Label38.Text = "Input depth:"
        '
        'cmbInterpolationType
        '
        Me.cmbInterpolationType.FormattingEnabled = True
        Me.cmbInterpolationType.Location = New System.Drawing.Point(76, 19)
        Me.cmbInterpolationType.Name = "cmbInterpolationType"
        Me.cmbInterpolationType.Size = New System.Drawing.Size(212, 21)
        Me.cmbInterpolationType.TabIndex = 1
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(6, 22)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(34, 13)
        Me.Label36.TabIndex = 0
        Me.Label36.Text = "Type:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnCalculateWellPath)
        Me.GroupBox1.Controls.Add(Me.cmbCalcMethod)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(394, 85)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Well Path Calculation"
        '
        'btnCalculateWellPath
        '
        Me.btnCalculateWellPath.Location = New System.Drawing.Point(112, 51)
        Me.btnCalculateWellPath.Name = "btnCalculateWellPath"
        Me.btnCalculateWellPath.Size = New System.Drawing.Size(143, 22)
        Me.btnCalculateWellPath.TabIndex = 2
        Me.btnCalculateWellPath.Text = "Calculate Well Path"
        Me.btnCalculateWellPath.UseVisualStyleBackColor = True
        '
        'cmbCalcMethod
        '
        Me.cmbCalcMethod.FormattingEnabled = True
        Me.cmbCalcMethod.Location = New System.Drawing.Point(112, 24)
        Me.cmbCalcMethod.Name = "cmbCalcMethod"
        Me.cmbCalcMethod.Size = New System.Drawing.Size(270, 21)
        Me.cmbCalcMethod.TabIndex = 1
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 27)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(100, 13)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Calculation method:"
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.SplitContainer2)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Size = New System.Drawing.Size(823, 453)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Well Path Display"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer2.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.SplitContainer3)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.Chart3)
        Me.SplitContainer2.Size = New System.Drawing.Size(817, 447)
        Me.SplitContainer2.SplitterDistance = 532
        Me.SplitContainer2.TabIndex = 0
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer3.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer3.Name = "SplitContainer3"
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.Chart1)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.Chart2)
        Me.SplitContainer3.Size = New System.Drawing.Size(524, 439)
        Me.SplitContainer3.SplitterDistance = 283
        Me.SplitContainer3.TabIndex = 0
        '
        'Chart1
        '
        Me.Chart1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ChartArea1.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend1)
        Me.Chart1.Location = New System.Drawing.Point(3, 3)
        Me.Chart1.Name = "Chart1"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.Chart1.Series.Add(Series1)
        Me.Chart1.Size = New System.Drawing.Size(275, 431)
        Me.Chart1.TabIndex = 0
        Me.Chart1.Text = "Chart1"
        '
        'Chart2
        '
        Me.Chart2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ChartArea2.Name = "ChartArea1"
        Me.Chart2.ChartAreas.Add(ChartArea2)
        Legend2.Name = "Legend1"
        Me.Chart2.Legends.Add(Legend2)
        Me.Chart2.Location = New System.Drawing.Point(3, 3)
        Me.Chart2.Name = "Chart2"
        Series2.ChartArea = "ChartArea1"
        Series2.Legend = "Legend1"
        Series2.Name = "Series1"
        Me.Chart2.Series.Add(Series2)
        Me.Chart2.Size = New System.Drawing.Size(229, 431)
        Me.Chart2.TabIndex = 0
        Me.Chart2.Text = "Chart2"
        '
        'Chart3
        '
        Me.Chart3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ChartArea3.Name = "ChartArea1"
        Me.Chart3.ChartAreas.Add(ChartArea3)
        Legend3.Name = "Legend1"
        Me.Chart3.Legends.Add(Legend3)
        Me.Chart3.Location = New System.Drawing.Point(3, 3)
        Me.Chart3.Name = "Chart3"
        Series3.ChartArea = "ChartArea1"
        Series3.Legend = "Legend1"
        Series3.Name = "Series1"
        Me.Chart3.Series.Add(Series3)
        Me.Chart3.Size = New System.Drawing.Size(273, 439)
        Me.Chart3.TabIndex = 0
        Me.Chart3.Text = "Chart3"
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.btnOpenParentDir)
        Me.TabPage1.Controls.Add(Me.btnOpenArchive)
        Me.TabPage1.Controls.Add(Me.btnCreateArchive)
        Me.TabPage1.Controls.Add(Me.btnShowProjectInfo)
        Me.TabPage1.Controls.Add(Me.chkConnect)
        Me.TabPage1.Controls.Add(Me.btnOpenProject)
        Me.TabPage1.Controls.Add(Me.Label57)
        Me.TabPage1.Controls.Add(Me.txtProjectPath)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.txtProNetName)
        Me.TabPage1.Controls.Add(Me.btnOpenAppDir)
        Me.TabPage1.Controls.Add(Me.btnOpenSystem)
        Me.TabPage1.Controls.Add(Me.btnOpenData)
        Me.TabPage1.Controls.Add(Me.btnOpenSettings)
        Me.TabPage1.Controls.Add(Me.btnAdd)
        Me.TabPage1.Controls.Add(Me.txtParentProject)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.btnParameters)
        Me.TabPage1.Controls.Add(Me.Label79)
        Me.TabPage1.Controls.Add(Me.txtSystemLocationType)
        Me.TabPage1.Controls.Add(Me.txtSystemPath)
        Me.TabPage1.Controls.Add(Me.txtCurrentDuration)
        Me.TabPage1.Controls.Add(Me.Label54)
        Me.TabPage1.Controls.Add(Me.txtTotalDuration)
        Me.TabPage1.Controls.Add(Me.Label55)
        Me.TabPage1.Controls.Add(Me.Label56)
        Me.TabPage1.Controls.Add(Me.txtLastUsed)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.txtCreationDate)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.txtDataPath)
        Me.TabPage1.Controls.Add(Me.txtDataLocationType)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.txtSettingsPath)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.txtSettingsLocationType)
        Me.TabPage1.Controls.Add(Me.txtProjectType)
        Me.TabPage1.Controls.Add(Me.txtProjectDescription)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.txtProjectName)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.btnProject)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(823, 453)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Project Information"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'btnOpenParentDir
        '
        Me.btnOpenParentDir.Location = New System.Drawing.Point(125, 398)
        Me.btnOpenParentDir.Name = "btnOpenParentDir"
        Me.btnOpenParentDir.Size = New System.Drawing.Size(125, 22)
        Me.btnOpenParentDir.TabIndex = 311
        Me.btnOpenParentDir.Text = "Open Parent Directory"
        Me.ToolTip1.SetToolTip(Me.btnOpenParentDir, "Open the Parent directory")
        Me.btnOpenParentDir.UseVisualStyleBackColor = True
        '
        'btnOpenArchive
        '
        Me.btnOpenArchive.Location = New System.Drawing.Point(354, 398)
        Me.btnOpenArchive.Name = "btnOpenArchive"
        Me.btnOpenArchive.Size = New System.Drawing.Size(94, 22)
        Me.btnOpenArchive.TabIndex = 310
        Me.btnOpenArchive.Text = "Open Archive"
        Me.ToolTip1.SetToolTip(Me.btnOpenArchive, "Open a project archive file")
        Me.btnOpenArchive.UseVisualStyleBackColor = True
        '
        'btnCreateArchive
        '
        Me.btnCreateArchive.Location = New System.Drawing.Point(256, 398)
        Me.btnCreateArchive.Name = "btnCreateArchive"
        Me.btnCreateArchive.Size = New System.Drawing.Size(92, 22)
        Me.btnCreateArchive.TabIndex = 309
        Me.btnCreateArchive.Text = "Create Archive"
        Me.ToolTip1.SetToolTip(Me.btnCreateArchive, "Create a project archive file")
        Me.btnCreateArchive.UseVisualStyleBackColor = True
        '
        'btnShowProjectInfo
        '
        Me.btnShowProjectInfo.Location = New System.Drawing.Point(6, 398)
        Me.btnShowProjectInfo.Name = "btnShowProjectInfo"
        Me.btnShowProjectInfo.Size = New System.Drawing.Size(113, 22)
        Me.btnShowProjectInfo.TabIndex = 308
        Me.btnShowProjectInfo.Text = "Show Project Info"
        Me.btnShowProjectInfo.UseVisualStyleBackColor = True
        '
        'chkConnect
        '
        Me.chkConnect.AutoSize = True
        Me.chkConnect.Location = New System.Drawing.Point(431, 138)
        Me.chkConnect.Name = "chkConnect"
        Me.chkConnect.Size = New System.Drawing.Size(112, 17)
        Me.chkConnect.TabIndex = 305
        Me.chkConnect.Text = "Connect On Open"
        Me.chkConnect.UseVisualStyleBackColor = True
        '
        'btnOpenProject
        '
        Me.btnOpenProject.Location = New System.Drawing.Point(84, 181)
        Me.btnOpenProject.Name = "btnOpenProject"
        Me.btnOpenProject.Size = New System.Drawing.Size(48, 22)
        Me.btnOpenProject.TabIndex = 304
        Me.btnOpenProject.Text = "Open"
        Me.btnOpenProject.UseVisualStyleBackColor = True
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.Location = New System.Drawing.Point(6, 165)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(67, 13)
        Me.Label57.TabIndex = 303
        Me.Label57.Text = "Project path:"
        '
        'txtProjectPath
        '
        Me.txtProjectPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProjectPath.Location = New System.Drawing.Point(138, 162)
        Me.txtProjectPath.Multiline = True
        Me.txtProjectPath.Name = "txtProjectPath"
        Me.txtProjectPath.Size = New System.Drawing.Size(561, 46)
        Me.txtProjectPath.TabIndex = 302
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(162, 37)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(84, 13)
        Me.Label8.TabIndex = 301
        Me.Label8.Text = "Project network:"
        '
        'txtProNetName
        '
        Me.txtProNetName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProNetName.Location = New System.Drawing.Point(271, 34)
        Me.txtProNetName.Name = "txtProNetName"
        Me.txtProNetName.Size = New System.Drawing.Size(428, 20)
        Me.txtProNetName.TabIndex = 300
        Me.ToolTip1.SetToolTip(Me.txtProNetName, "The name of the Application Network containing the project")
        '
        'btnOpenAppDir
        '
        Me.btnOpenAppDir.Location = New System.Drawing.Point(6, 370)
        Me.btnOpenAppDir.Name = "btnOpenAppDir"
        Me.btnOpenAppDir.Size = New System.Drawing.Size(150, 22)
        Me.btnOpenAppDir.TabIndex = 298
        Me.btnOpenAppDir.Text = "Open Application Directory"
        Me.btnOpenAppDir.UseVisualStyleBackColor = True
        '
        'btnOpenSystem
        '
        Me.btnOpenSystem.Location = New System.Drawing.Point(84, 337)
        Me.btnOpenSystem.Name = "btnOpenSystem"
        Me.btnOpenSystem.Size = New System.Drawing.Size(48, 22)
        Me.btnOpenSystem.TabIndex = 295
        Me.btnOpenSystem.Text = "Open"
        Me.btnOpenSystem.UseVisualStyleBackColor = True
        '
        'btnOpenData
        '
        Me.btnOpenData.Location = New System.Drawing.Point(84, 285)
        Me.btnOpenData.Name = "btnOpenData"
        Me.btnOpenData.Size = New System.Drawing.Size(48, 22)
        Me.btnOpenData.TabIndex = 294
        Me.btnOpenData.Text = "Open"
        Me.btnOpenData.UseVisualStyleBackColor = True
        '
        'btnOpenSettings
        '
        Me.btnOpenSettings.Location = New System.Drawing.Point(84, 233)
        Me.btnOpenSettings.Name = "btnOpenSettings"
        Me.btnOpenSettings.Size = New System.Drawing.Size(48, 22)
        Me.btnOpenSettings.TabIndex = 293
        Me.btnOpenSettings.Text = "Open"
        Me.btnOpenSettings.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(9, 34)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(147, 22)
        Me.btnAdd.TabIndex = 289
        Me.btnAdd.Text = "Add to Message Service"
        Me.ToolTip1.SetToolTip(Me.btnAdd, "Add selected project to the Message Service list")
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'txtParentProject
        '
        Me.txtParentProject.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtParentProject.Location = New System.Drawing.Point(271, 8)
        Me.txtParentProject.Name = "txtParentProject"
        Me.txtParentProject.Size = New System.Drawing.Size(428, 20)
        Me.txtParentProject.TabIndex = 287
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(166, 11)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 13)
        Me.Label6.TabIndex = 286
        Me.Label6.Text = "Parent project:"
        '
        'btnParameters
        '
        Me.btnParameters.Location = New System.Drawing.Point(84, 6)
        Me.btnParameters.Name = "btnParameters"
        Me.btnParameters.Size = New System.Drawing.Size(72, 22)
        Me.btnParameters.TabIndex = 285
        Me.btnParameters.Text = "Parameters"
        Me.btnParameters.UseVisualStyleBackColor = True
        '
        'Label79
        '
        Me.Label79.AutoSize = True
        Me.Label79.Location = New System.Drawing.Point(6, 321)
        Me.Label79.Name = "Label79"
        Me.Label79.Size = New System.Drawing.Size(108, 13)
        Me.Label79.TabIndex = 90
        Me.Label79.Text = "System location path:"
        '
        'txtSystemLocationType
        '
        Me.txtSystemLocationType.Location = New System.Drawing.Point(6, 337)
        Me.txtSystemLocationType.Name = "txtSystemLocationType"
        Me.txtSystemLocationType.Size = New System.Drawing.Size(72, 20)
        Me.txtSystemLocationType.TabIndex = 89
        '
        'txtSystemPath
        '
        Me.txtSystemPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSystemPath.Location = New System.Drawing.Point(138, 318)
        Me.txtSystemPath.Multiline = True
        Me.txtSystemPath.Name = "txtSystemPath"
        Me.txtSystemPath.Size = New System.Drawing.Size(561, 46)
        Me.txtSystemPath.TabIndex = 88
        '
        'txtCurrentDuration
        '
        Me.txtCurrentDuration.Location = New System.Drawing.Point(471, 370)
        Me.txtCurrentDuration.Name = "txtCurrentDuration"
        Me.txtCurrentDuration.Size = New System.Drawing.Size(120, 20)
        Me.txtCurrentDuration.TabIndex = 78
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Location = New System.Drawing.Point(421, 373)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(44, 13)
        Me.Label54.TabIndex = 76
        Me.Label54.Text = "Current:"
        '
        'txtTotalDuration
        '
        Me.txtTotalDuration.Location = New System.Drawing.Point(283, 370)
        Me.txtTotalDuration.Name = "txtTotalDuration"
        Me.txtTotalDuration.Size = New System.Drawing.Size(120, 20)
        Me.txtTotalDuration.TabIndex = 75
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.Location = New System.Drawing.Point(243, 373)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(34, 13)
        Me.Label55.TabIndex = 74
        Me.Label55.Text = "Total:"
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Location = New System.Drawing.Point(162, 375)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(75, 13)
        Me.Label56.TabIndex = 73
        Me.Label56.Text = "Project usage:"
        '
        'txtLastUsed
        '
        Me.txtLastUsed.Location = New System.Drawing.Point(295, 136)
        Me.txtLastUsed.Name = "txtLastUsed"
        Me.txtLastUsed.Size = New System.Drawing.Size(120, 20)
        Me.txtLastUsed.TabIndex = 65
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(211, 139)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(78, 13)
        Me.Label11.TabIndex = 64
        Me.Label11.Text = "Date last used:"
        '
        'txtCreationDate
        '
        Me.txtCreationDate.Location = New System.Drawing.Point(85, 136)
        Me.txtCreationDate.Name = "txtCreationDate"
        Me.txtCreationDate.Size = New System.Drawing.Size(120, 20)
        Me.txtCreationDate.TabIndex = 63
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 139)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(73, 13)
        Me.Label10.TabIndex = 62
        Me.Label10.Text = "Creation date:"
        '
        'txtDataPath
        '
        Me.txtDataPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDataPath.Location = New System.Drawing.Point(138, 266)
        Me.txtDataPath.Multiline = True
        Me.txtDataPath.Name = "txtDataPath"
        Me.txtDataPath.Size = New System.Drawing.Size(561, 46)
        Me.txtDataPath.TabIndex = 61
        '
        'txtDataLocationType
        '
        Me.txtDataLocationType.Location = New System.Drawing.Point(6, 285)
        Me.txtDataLocationType.Name = "txtDataLocationType"
        Me.txtDataLocationType.Size = New System.Drawing.Size(72, 20)
        Me.txtDataLocationType.TabIndex = 60
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 269)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(97, 13)
        Me.Label9.TabIndex = 59
        Me.Label9.Text = "Data location path:"
        '
        'txtSettingsPath
        '
        Me.txtSettingsPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSettingsPath.Location = New System.Drawing.Point(138, 214)
        Me.txtSettingsPath.Multiline = True
        Me.txtSettingsPath.Name = "txtSettingsPath"
        Me.txtSettingsPath.Size = New System.Drawing.Size(561, 46)
        Me.txtSettingsPath.TabIndex = 57
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 217)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(112, 13)
        Me.Label7.TabIndex = 56
        Me.Label7.Text = "Settings location path:"
        '
        'txtSettingsLocationType
        '
        Me.txtSettingsLocationType.Location = New System.Drawing.Point(6, 233)
        Me.txtSettingsLocationType.Name = "txtSettingsLocationType"
        Me.txtSettingsLocationType.Size = New System.Drawing.Size(72, 20)
        Me.txtSettingsLocationType.TabIndex = 55
        '
        'txtProjectType
        '
        Me.txtProjectType.Location = New System.Drawing.Point(6, 181)
        Me.txtProjectType.Name = "txtProjectType"
        Me.txtProjectType.Size = New System.Drawing.Size(72, 20)
        Me.txtProjectType.TabIndex = 53
        '
        'txtProjectDescription
        '
        Me.txtProjectDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProjectDescription.Location = New System.Drawing.Point(85, 90)
        Me.txtProjectDescription.Multiline = True
        Me.txtProjectDescription.Name = "txtProjectDescription"
        Me.txtProjectDescription.Size = New System.Drawing.Size(614, 40)
        Me.txtProjectDescription.TabIndex = 51
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 93)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 50
        Me.Label4.Text = "Description:"
        '
        'txtProjectName
        '
        Me.txtProjectName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProjectName.Location = New System.Drawing.Point(85, 64)
        Me.txtProjectName.Name = "txtProjectName"
        Me.txtProjectName.Size = New System.Drawing.Size(614, 20)
        Me.txtProjectName.TabIndex = 49
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 48
        Me.Label3.Text = "Name:"
        '
        'btnProject
        '
        Me.btnProject.Location = New System.Drawing.Point(6, 6)
        Me.btnProject.Name = "btnProject"
        Me.btnProject.Size = New System.Drawing.Size(72, 22)
        Me.btnProject.TabIndex = 47
        Me.btnProject.Text = "Project List"
        Me.btnProject.UseVisualStyleBackColor = True
        '
        'btnOpen
        '
        Me.btnOpen.Location = New System.Drawing.Point(129, 12)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(64, 22)
        Me.btnOpen.TabIndex = 52
        Me.btnOpen.Text = "Open"
        Me.btnOpen.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(199, 12)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(64, 22)
        Me.btnSave.TabIndex = 53
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(269, 12)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(64, 22)
        Me.btnNew.TabIndex = 55
        Me.btnNew.Text = "New"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'btnWebPages
        '
        Me.btnWebPages.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnWebPages.ContextMenuStrip = Me.ContextMenuStrip2
        Me.btnWebPages.Location = New System.Drawing.Point(456, 12)
        Me.btnWebPages.Name = "btnWebPages"
        Me.btnWebPages.Size = New System.Drawing.Size(68, 22)
        Me.btnWebPages.TabIndex = 280
        Me.btnWebPages.Text = "Workflows"
        Me.btnWebPages.UseVisualStyleBackColor = True
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1_EditWorkflowTabPage, Me.ToolStripMenuItem1_ShowStartPageInWorkflowTab})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(248, 48)
        '
        'ToolStripMenuItem1_EditWorkflowTabPage
        '
        Me.ToolStripMenuItem1_EditWorkflowTabPage.Name = "ToolStripMenuItem1_EditWorkflowTabPage"
        Me.ToolStripMenuItem1_EditWorkflowTabPage.Size = New System.Drawing.Size(247, 22)
        Me.ToolStripMenuItem1_EditWorkflowTabPage.Text = "Edit Workflow Tab Page"
        '
        'ToolStripMenuItem1_ShowStartPageInWorkflowTab
        '
        Me.ToolStripMenuItem1_ShowStartPageInWorkflowTab.Name = "ToolStripMenuItem1_ShowStartPageInWorkflowTab"
        Me.ToolStripMenuItem1_ShowStartPageInWorkflowTab.Size = New System.Drawing.Size(247, 22)
        Me.ToolStripMenuItem1_ShowStartPageInWorkflowTab.Text = "Show Start Page In Workflow Tab"
        '
        'Timer2
        '
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(855, 531)
        Me.Controls.Add(Me.btnWebPages)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnOpen)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btnAndorville)
        Me.Controls.Add(Me.btnAppInfo)
        Me.Controls.Add(Me.btnMessages)
        Me.Controls.Add(Me.btnOnline)
        Me.Controls.Add(Me.btnExit)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Main"
        Me.Text = "Well Deviation V1-0"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage6.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.dgvMeasuredData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.dgvCalculatedData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage5.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.ResumeLayout(False)
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.ContextMenuStrip2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnExit As Button
    Friend WithEvents btnOnline As Button
    Friend WithEvents btnMessages As Button
    Friend WithEvents btnAppInfo As Button
    Friend WithEvents btnAndorville As Button
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents txtLastUsed As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtCreationDate As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtDataPath As TextBox
    Friend WithEvents txtDataLocationType As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtSettingsPath As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtSettingsLocationType As TextBox
    Friend WithEvents txtProjectType As TextBox
    Friend WithEvents txtProjectDescription As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtProjectName As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btnProject As Button
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents btnOpenTemplateForm As Button
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents dgvMeasuredData As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents dgvCalculatedData As DataGridView
    Friend WithEvents Label2 As Label
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cmbCalcMethod As ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents btnCalculateWellPath As Button
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents CutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CopyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PasteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents txtBoreholeName As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents txtWellName As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label16 As Label
    Friend WithEvents cmbGeoCRS As ComboBox
    Friend WithEvents Label15 As Label
    Friend WithEvents cmbProjCRS As ComboBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents cmbMeasDepthUnit As ComboBox
    Friend WithEvents Label22 As Label
    Friend WithEvents txtRT As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents txtEasting As TextBox
    Friend WithEvents txtNorthing As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents txtLatitude As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents txtLongitude As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents cmbMeasAngleUnit As ComboBox
    Friend WithEvents Label23 As Label
    Friend WithEvents cmbMeasNorthReference As ComboBox
    Friend WithEvents Label24 As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents Label25 As Label
    Friend WithEvents cmbCalcOffsetUnit As ComboBox
    Friend WithEvents Label26 As Label
    Friend WithEvents cmbCalcDepthUnit As ComboBox
    Friend WithEvents btnGetProjCRSList As Button
    Friend WithEvents btnGetGeoCRSList As Button
    Friend WithEvents txtFileName As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents btnOpen As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents btnNew As Button
    Friend WithEvents Label32 As Label
    Friend WithEvents Label31 As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents txtLatSec As TextBox
    Friend WithEvents txtLatMin As TextBox
    Friend WithEvents txtLatDeg As TextBox
    Friend WithEvents Label28 As Label
    Friend WithEvents Label33 As Label
    Friend WithEvents Label34 As Label
    Friend WithEvents Label35 As Label
    Friend WithEvents txtLongSec As TextBox
    Friend WithEvents txtLongMin As TextBox
    Friend WithEvents txtLongDeg As TextBox
    Friend WithEvents txtLongSign As TextBox
    Friend WithEvents txtLatSign As TextBox
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents btnCalculateProjCoords As Button
    Friend WithEvents btnAddRow As Button
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents cmbInterpolationType As ComboBox
    Friend WithEvents Label36 As Label
    Friend WithEvents txtCalcOffsetDecPl As TextBox
    Friend WithEvents txtCalcDepthDecPl As TextBox
    Friend WithEvents Label37 As Label
    Friend WithEvents TabPage5 As TabPage
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
    Friend WithEvents SplitContainer3 As SplitContainer
    Friend WithEvents Chart2 As DataVisualization.Charting.Chart
    Friend WithEvents Chart3 As DataVisualization.Charting.Chart
    Friend WithEvents cmbInputDepth As ComboBox
    Friend WithEvents Label38 As Label
    Friend WithEvents Label39 As Label
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents Label47 As Label
    Friend WithEvents Label46 As Label
    Friend WithEvents Label45 As Label
    Friend WithEvents Label44 As Label
    Friend WithEvents Label43 As Label
    Friend WithEvents txtInterpolatedNorthing As TextBox
    Friend WithEvents txtInterpolatedEasting As TextBox
    Friend WithEvents Label42 As Label
    Friend WithEvents txtInterpolatedTVDSS As TextBox
    Friend WithEvents Label41 As Label
    Friend WithEvents txtInterpolatedTVDRT As TextBox
    Friend WithEvents Label40 As Label
    Friend WithEvents txtInputDepthValue As TextBox
    Friend WithEvents Label51 As Label
    Friend WithEvents Label50 As Label
    Friend WithEvents txtInterpolateddY As TextBox
    Friend WithEvents txtInterpolateddX As TextBox
    Friend WithEvents Label49 As Label
    Friend WithEvents Label48 As Label
    Friend WithEvents txtCurrentDuration As TextBox
    Friend WithEvents Label54 As Label
    Friend WithEvents txtTotalDuration As TextBox
    Friend WithEvents Label55 As Label
    Friend WithEvents Label56 As Label
    Friend WithEvents TabPage6 As TabPage
    Friend WithEvents WebBrowser1 As WebBrowser
    Friend WithEvents Label79 As Label
    Friend WithEvents txtSystemLocationType As TextBox
    Friend WithEvents txtSystemPath As TextBox
    Friend WithEvents btnWebPages As Button
    Friend WithEvents btnOpenAppDir As Button
    Friend WithEvents btnOpenSystem As Button
    Friend WithEvents btnOpenData As Button
    Friend WithEvents btnOpenSettings As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents txtParentProject As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents btnParameters As Button
    Friend WithEvents Timer2 As Timer
    Friend WithEvents btnOpenProject As Button
    Friend WithEvents Label57 As Label
    Friend WithEvents txtProjectPath As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtProNetName As TextBox
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents chkConnect As CheckBox
    Friend WithEvents ContextMenuStrip2 As ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1_EditWorkflowTabPage As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1_ShowStartPageInWorkflowTab As ToolStripMenuItem
    Friend WithEvents btnOpenParentDir As Button
    Friend WithEvents btnOpenArchive As Button
    Friend WithEvents btnCreateArchive As Button
    Friend WithEvents btnShowProjectInfo As Button
End Class
