<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.components = New System.ComponentModel.Container()
        Me.btnRoll = New System.Windows.Forms.Button()
        Me.txtResult = New System.Windows.Forms.TextBox()
        Me.txtHistoric = New System.Windows.Forms.TextBox()
        Me.grpTreasure = New System.Windows.Forms.GroupBox()
        Me.radBlackMarket = New System.Windows.Forms.RadioButton()
        Me.radUnique = New System.Windows.Forms.RadioButton()
        Me.radNPC = New System.Windows.Forms.RadioButton()
        Me.radSettlement = New System.Windows.Forms.RadioButton()
        Me.grpSettlement = New System.Windows.Forms.GroupBox()
        Me.lbl_SetNote = New System.Windows.Forms.Label()
        Me.txtSetMajor = New System.Windows.Forms.TextBox()
        Me.lbl_SetMajor = New System.Windows.Forms.Label()
        Me.txtSetMedium = New System.Windows.Forms.TextBox()
        Me.txtSetMinor = New System.Windows.Forms.TextBox()
        Me.lbl_SetMedium = New System.Windows.Forms.Label()
        Me.lbl_SetMinor = New System.Windows.Forms.Label()
        Me.lblSet_PopRange = New System.Windows.Forms.Label()
        Me.lblSet_Population = New System.Windows.Forms.Label()
        Me.cmbSettlement = New System.Windows.Forms.ComboBox()
        Me.lblSettlement = New System.Windows.Forms.Label()
        Me.grpNPC = New System.Windows.Forms.GroupBox()
        Me.chk_TreasureI = New System.Windows.Forms.CheckBox()
        Me.chk_TreasureH = New System.Windows.Forms.CheckBox()
        Me.lblNPC_TreasureType = New System.Windows.Forms.Label()
        Me.chk_TreasureG = New System.Windows.Forms.CheckBox()
        Me.grp_NPCLootType = New System.Windows.Forms.GroupBox()
        Me.radLTypeTriple = New System.Windows.Forms.RadioButton()
        Me.radLTypeDouble = New System.Windows.Forms.RadioButton()
        Me.radLTypeStandard = New System.Windows.Forms.RadioButton()
        Me.radLTypeIncidental = New System.Windows.Forms.RadioButton()
        Me.chk_TreasureF = New System.Windows.Forms.CheckBox()
        Me.chkNPCAddExtra = New System.Windows.Forms.CheckBox()
        Me.chk_TreasureE = New System.Windows.Forms.CheckBox()
        Me.cmbNPCType = New System.Windows.Forms.ComboBox()
        Me.chk_TreasureD = New System.Windows.Forms.CheckBox()
        Me.lblNPCType = New System.Windows.Forms.Label()
        Me.chk_TreasureC = New System.Windows.Forms.CheckBox()
        Me.txtNPCLoot = New System.Windows.Forms.TextBox()
        Me.chk_TreasureB = New System.Windows.Forms.CheckBox()
        Me.grp_NPCEvolution = New System.Windows.Forms.GroupBox()
        Me.radEvoFast = New System.Windows.Forms.RadioButton()
        Me.radEvoMedium = New System.Windows.Forms.RadioButton()
        Me.radEvoSlow = New System.Windows.Forms.RadioButton()
        Me.chk_TreasureA = New System.Windows.Forms.CheckBox()
        Me.lblNPC_GP = New System.Windows.Forms.Label()
        Me.cmbNPC = New System.Windows.Forms.ComboBox()
        Me.lblNPC = New System.Windows.Forms.Label()
        Me.ttip = New System.Windows.Forms.ToolTip(Me.components)
        Me.grpBlackMarket = New System.Windows.Forms.GroupBox()
        Me.lbl_SetBMNote = New System.Windows.Forms.Label()
        Me.txtSetBMMajor = New System.Windows.Forms.TextBox()
        Me.lbl_BMSetMajor = New System.Windows.Forms.Label()
        Me.txtSetBMMedium = New System.Windows.Forms.TextBox()
        Me.txtSetBMMinor = New System.Windows.Forms.TextBox()
        Me.lbl_SetBMMedium = New System.Windows.Forms.Label()
        Me.lbl_BMSetMinor = New System.Windows.Forms.Label()
        Me.lblSet_BMPopRange = New System.Windows.Forms.Label()
        Me.lbl_Set_BMPopulation = New System.Windows.Forms.Label()
        Me.cmbBlackMarket = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.grpTreasure.SuspendLayout()
        Me.grpSettlement.SuspendLayout()
        Me.grpNPC.SuspendLayout()
        Me.grp_NPCLootType.SuspendLayout()
        Me.grp_NPCEvolution.SuspendLayout()
        Me.grpBlackMarket.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnRoll
        '
        Me.btnRoll.Location = New System.Drawing.Point(462, 239)
        Me.btnRoll.Name = "btnRoll"
        Me.btnRoll.Size = New System.Drawing.Size(75, 23)
        Me.btnRoll.TabIndex = 4
        Me.btnRoll.Text = "&Roll"
        Me.btnRoll.UseVisualStyleBackColor = True
        '
        'txtResult
        '
        Me.txtResult.Location = New System.Drawing.Point(15, 268)
        Me.txtResult.Multiline = True
        Me.txtResult.Name = "txtResult"
        Me.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtResult.Size = New System.Drawing.Size(522, 313)
        Me.txtResult.TabIndex = 5
        '
        'txtHistoric
        '
        Me.txtHistoric.Location = New System.Drawing.Point(543, 12)
        Me.txtHistoric.Multiline = True
        Me.txtHistoric.Name = "txtHistoric"
        Me.txtHistoric.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtHistoric.Size = New System.Drawing.Size(431, 569)
        Me.txtHistoric.TabIndex = 6
        '
        'grpTreasure
        '
        Me.grpTreasure.Controls.Add(Me.radBlackMarket)
        Me.grpTreasure.Controls.Add(Me.radUnique)
        Me.grpTreasure.Controls.Add(Me.radNPC)
        Me.grpTreasure.Controls.Add(Me.radSettlement)
        Me.grpTreasure.Location = New System.Drawing.Point(15, 12)
        Me.grpTreasure.Name = "grpTreasure"
        Me.grpTreasure.Size = New System.Drawing.Size(163, 221)
        Me.grpTreasure.TabIndex = 0
        Me.grpTreasure.TabStop = False
        Me.grpTreasure.Text = "Treasure Type"
        '
        'radBlackMarket
        '
        Me.radBlackMarket.AutoSize = True
        Me.radBlackMarket.Location = New System.Drawing.Point(6, 42)
        Me.radBlackMarket.Name = "radBlackMarket"
        Me.radBlackMarket.Size = New System.Drawing.Size(156, 17)
        Me.radBlackMarket.TabIndex = 1
        Me.radBlackMarket.Text = "&Black Market Magical Items"
        Me.radBlackMarket.UseVisualStyleBackColor = True
        '
        'radUnique
        '
        Me.radUnique.AutoSize = True
        Me.radUnique.Location = New System.Drawing.Point(6, 88)
        Me.radUnique.Name = "radUnique"
        Me.radUnique.Size = New System.Drawing.Size(82, 17)
        Me.radUnique.TabIndex = 3
        Me.radUnique.Text = "&Unique Item"
        Me.radUnique.UseVisualStyleBackColor = True
        '
        'radNPC
        '
        Me.radNPC.AutoSize = True
        Me.radNPC.Location = New System.Drawing.Point(6, 65)
        Me.radNPC.Name = "radNPC"
        Me.radNPC.Size = New System.Drawing.Size(95, 17)
        Me.radNPC.TabIndex = 2
        Me.radNPC.Text = "Monsters/&NPC"
        Me.radNPC.UseVisualStyleBackColor = True
        '
        'radSettlement
        '
        Me.radSettlement.AutoSize = True
        Me.radSettlement.Checked = True
        Me.radSettlement.Location = New System.Drawing.Point(6, 19)
        Me.radSettlement.Name = "radSettlement"
        Me.radSettlement.Size = New System.Drawing.Size(143, 17)
        Me.radSettlement.TabIndex = 0
        Me.radSettlement.TabStop = True
        Me.radSettlement.Text = "&Settlement Magical Items"
        Me.radSettlement.UseVisualStyleBackColor = True
        '
        'grpSettlement
        '
        Me.grpSettlement.Controls.Add(Me.lbl_SetNote)
        Me.grpSettlement.Controls.Add(Me.txtSetMajor)
        Me.grpSettlement.Controls.Add(Me.lbl_SetMajor)
        Me.grpSettlement.Controls.Add(Me.txtSetMedium)
        Me.grpSettlement.Controls.Add(Me.txtSetMinor)
        Me.grpSettlement.Controls.Add(Me.lbl_SetMedium)
        Me.grpSettlement.Controls.Add(Me.lbl_SetMinor)
        Me.grpSettlement.Controls.Add(Me.lblSet_PopRange)
        Me.grpSettlement.Controls.Add(Me.lblSet_Population)
        Me.grpSettlement.Controls.Add(Me.cmbSettlement)
        Me.grpSettlement.Controls.Add(Me.lblSettlement)
        Me.grpSettlement.Location = New System.Drawing.Point(184, 12)
        Me.grpSettlement.Name = "grpSettlement"
        Me.grpSettlement.Size = New System.Drawing.Size(353, 221)
        Me.grpSettlement.TabIndex = 1
        Me.grpSettlement.TabStop = False
        Me.grpSettlement.Text = "Settlement Magical Items"
        '
        'lbl_SetNote
        '
        Me.lbl_SetNote.AutoSize = True
        Me.lbl_SetNote.Location = New System.Drawing.Point(6, 164)
        Me.lbl_SetNote.Name = "lbl_SetNote"
        Me.lbl_SetNote.Size = New System.Drawing.Size(313, 13)
        Me.lbl_SetNote.TabIndex = 10
        Me.lbl_SetNote.Text = "* Nearly all minor magic items are available, rolling 4d4 as sample."
        Me.lbl_SetNote.Visible = False
        '
        'txtSetMajor
        '
        Me.txtSetMajor.Location = New System.Drawing.Point(274, 104)
        Me.txtSetMajor.Name = "txtSetMajor"
        Me.txtSetMajor.ReadOnly = True
        Me.txtSetMajor.Size = New System.Drawing.Size(61, 20)
        Me.txtSetMajor.TabIndex = 9
        Me.txtSetMajor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lbl_SetMajor
        '
        Me.lbl_SetMajor.AutoSize = True
        Me.lbl_SetMajor.Location = New System.Drawing.Point(271, 88)
        Me.lbl_SetMajor.Name = "lbl_SetMajor"
        Me.lbl_SetMajor.Size = New System.Drawing.Size(64, 13)
        Me.lbl_SetMajor.TabIndex = 8
        Me.lbl_SetMajor.Text = "Major Items:"
        '
        'txtSetMedium
        '
        Me.txtSetMedium.Location = New System.Drawing.Point(143, 104)
        Me.txtSetMedium.Name = "txtSetMedium"
        Me.txtSetMedium.ReadOnly = True
        Me.txtSetMedium.Size = New System.Drawing.Size(61, 20)
        Me.txtSetMedium.TabIndex = 7
        Me.txtSetMedium.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtSetMinor
        '
        Me.txtSetMinor.Location = New System.Drawing.Point(9, 104)
        Me.txtSetMinor.Name = "txtSetMinor"
        Me.txtSetMinor.ReadOnly = True
        Me.txtSetMinor.Size = New System.Drawing.Size(61, 20)
        Me.txtSetMinor.TabIndex = 5
        Me.txtSetMinor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lbl_SetMedium
        '
        Me.lbl_SetMedium.AutoSize = True
        Me.lbl_SetMedium.Location = New System.Drawing.Point(140, 88)
        Me.lbl_SetMedium.Name = "lbl_SetMedium"
        Me.lbl_SetMedium.Size = New System.Drawing.Size(75, 13)
        Me.lbl_SetMedium.TabIndex = 6
        Me.lbl_SetMedium.Text = "Medium Items:"
        '
        'lbl_SetMinor
        '
        Me.lbl_SetMinor.AutoSize = True
        Me.lbl_SetMinor.Location = New System.Drawing.Point(6, 88)
        Me.lbl_SetMinor.Name = "lbl_SetMinor"
        Me.lbl_SetMinor.Size = New System.Drawing.Size(64, 13)
        Me.lbl_SetMinor.TabIndex = 4
        Me.lbl_SetMinor.Text = "Minor Items:"
        '
        'lblSet_PopRange
        '
        Me.lblSet_PopRange.AutoSize = True
        Me.lblSet_PopRange.Location = New System.Drawing.Point(140, 35)
        Me.lblSet_PopRange.Name = "lblSet_PopRange"
        Me.lblSet_PopRange.Size = New System.Drawing.Size(13, 13)
        Me.lblSet_PopRange.TabIndex = 3
        Me.lblSet_PopRange.Text = "0"
        '
        'lblSet_Population
        '
        Me.lblSet_Population.AutoSize = True
        Me.lblSet_Population.Location = New System.Drawing.Point(140, 16)
        Me.lblSet_Population.Name = "lblSet_Population"
        Me.lblSet_Population.Size = New System.Drawing.Size(95, 13)
        Me.lblSet_Population.TabIndex = 2
        Me.lblSet_Population.Text = "Population Range:"
        '
        'cmbSettlement
        '
        Me.cmbSettlement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSettlement.FormattingEnabled = True
        Me.cmbSettlement.Items.AddRange(New Object() {"Thorp", "Hamlet", "Village", "Small town", "Large town", "Small city", "Large city", "Metropolis"})
        Me.cmbSettlement.Location = New System.Drawing.Point(9, 32)
        Me.cmbSettlement.Name = "cmbSettlement"
        Me.cmbSettlement.Size = New System.Drawing.Size(121, 21)
        Me.cmbSettlement.TabIndex = 1
        '
        'lblSettlement
        '
        Me.lblSettlement.AutoSize = True
        Me.lblSettlement.Location = New System.Drawing.Point(6, 16)
        Me.lblSettlement.Name = "lblSettlement"
        Me.lblSettlement.Size = New System.Drawing.Size(87, 13)
        Me.lblSettlement.TabIndex = 0
        Me.lblSettlement.Text = "Settlement Type:"
        '
        'grpNPC
        '
        Me.grpNPC.Controls.Add(Me.chk_TreasureI)
        Me.grpNPC.Controls.Add(Me.chk_TreasureH)
        Me.grpNPC.Controls.Add(Me.lblNPC_TreasureType)
        Me.grpNPC.Controls.Add(Me.chk_TreasureG)
        Me.grpNPC.Controls.Add(Me.grp_NPCLootType)
        Me.grpNPC.Controls.Add(Me.chk_TreasureF)
        Me.grpNPC.Controls.Add(Me.chkNPCAddExtra)
        Me.grpNPC.Controls.Add(Me.chk_TreasureE)
        Me.grpNPC.Controls.Add(Me.cmbNPCType)
        Me.grpNPC.Controls.Add(Me.chk_TreasureD)
        Me.grpNPC.Controls.Add(Me.lblNPCType)
        Me.grpNPC.Controls.Add(Me.chk_TreasureC)
        Me.grpNPC.Controls.Add(Me.txtNPCLoot)
        Me.grpNPC.Controls.Add(Me.chk_TreasureB)
        Me.grpNPC.Controls.Add(Me.grp_NPCEvolution)
        Me.grpNPC.Controls.Add(Me.chk_TreasureA)
        Me.grpNPC.Controls.Add(Me.lblNPC_GP)
        Me.grpNPC.Controls.Add(Me.cmbNPC)
        Me.grpNPC.Controls.Add(Me.lblNPC)
        Me.grpNPC.Location = New System.Drawing.Point(184, 12)
        Me.grpNPC.Name = "grpNPC"
        Me.grpNPC.Size = New System.Drawing.Size(353, 221)
        Me.grpNPC.TabIndex = 3
        Me.grpNPC.TabStop = False
        Me.grpNPC.Text = "Monsters/NPC"
        Me.grpNPC.Visible = False
        '
        'chk_TreasureI
        '
        Me.chk_TreasureI.AutoSize = True
        Me.chk_TreasureI.Location = New System.Drawing.Point(320, 198)
        Me.chk_TreasureI.Name = "chk_TreasureI"
        Me.chk_TreasureI.Size = New System.Drawing.Size(29, 17)
        Me.chk_TreasureI.TabIndex = 18
        Me.chk_TreasureI.Text = "I"
        Me.chk_TreasureI.UseVisualStyleBackColor = True
        '
        'chk_TreasureH
        '
        Me.chk_TreasureH.AutoSize = True
        Me.chk_TreasureH.Location = New System.Drawing.Point(281, 198)
        Me.chk_TreasureH.Name = "chk_TreasureH"
        Me.chk_TreasureH.Size = New System.Drawing.Size(34, 17)
        Me.chk_TreasureH.TabIndex = 17
        Me.chk_TreasureH.Text = "H"
        Me.chk_TreasureH.UseVisualStyleBackColor = True
        '
        'lblNPC_TreasureType
        '
        Me.lblNPC_TreasureType.AutoSize = True
        Me.lblNPC_TreasureType.Location = New System.Drawing.Point(6, 182)
        Me.lblNPC_TreasureType.Name = "lblNPC_TreasureType"
        Me.lblNPC_TreasureType.Size = New System.Drawing.Size(125, 13)
        Me.lblNPC_TreasureType.TabIndex = 9
        Me.lblNPC_TreasureType.Text = "Available Treasure Type:"
        '
        'chk_TreasureG
        '
        Me.chk_TreasureG.AutoSize = True
        Me.chk_TreasureG.Location = New System.Drawing.Point(242, 198)
        Me.chk_TreasureG.Name = "chk_TreasureG"
        Me.chk_TreasureG.Size = New System.Drawing.Size(34, 17)
        Me.chk_TreasureG.TabIndex = 16
        Me.chk_TreasureG.Text = "G"
        Me.chk_TreasureG.UseVisualStyleBackColor = True
        '
        'grp_NPCLootType
        '
        Me.grp_NPCLootType.Controls.Add(Me.radLTypeTriple)
        Me.grp_NPCLootType.Controls.Add(Me.radLTypeDouble)
        Me.grp_NPCLootType.Controls.Add(Me.radLTypeStandard)
        Me.grp_NPCLootType.Controls.Add(Me.radLTypeIncidental)
        Me.grp_NPCLootType.Location = New System.Drawing.Point(136, 69)
        Me.grp_NPCLootType.Name = "grp_NPCLootType"
        Me.grp_NPCLootType.Size = New System.Drawing.Size(123, 103)
        Me.grp_NPCLootType.TabIndex = 6
        Me.grp_NPCLootType.TabStop = False
        Me.grp_NPCLootType.Text = "Loot Type"
        '
        'radLTypeTriple
        '
        Me.radLTypeTriple.AutoSize = True
        Me.radLTypeTriple.Location = New System.Drawing.Point(16, 79)
        Me.radLTypeTriple.Name = "radLTypeTriple"
        Me.radLTypeTriple.Size = New System.Drawing.Size(71, 17)
        Me.radLTypeTriple.TabIndex = 3
        Me.radLTypeTriple.Text = "Triple (x3)"
        Me.radLTypeTriple.UseVisualStyleBackColor = True
        '
        'radLTypeDouble
        '
        Me.radLTypeDouble.AutoSize = True
        Me.radLTypeDouble.Location = New System.Drawing.Point(16, 59)
        Me.radLTypeDouble.Name = "radLTypeDouble"
        Me.radLTypeDouble.Size = New System.Drawing.Size(79, 17)
        Me.radLTypeDouble.TabIndex = 2
        Me.radLTypeDouble.Text = "Double (x2)"
        Me.radLTypeDouble.UseVisualStyleBackColor = True
        '
        'radLTypeStandard
        '
        Me.radLTypeStandard.AutoSize = True
        Me.radLTypeStandard.Checked = True
        Me.radLTypeStandard.Location = New System.Drawing.Point(16, 39)
        Me.radLTypeStandard.Name = "radLTypeStandard"
        Me.radLTypeStandard.Size = New System.Drawing.Size(88, 17)
        Me.radLTypeStandard.TabIndex = 1
        Me.radLTypeStandard.TabStop = True
        Me.radLTypeStandard.Text = "Standard (x1)"
        Me.radLTypeStandard.UseVisualStyleBackColor = True
        '
        'radLTypeIncidental
        '
        Me.radLTypeIncidental.AutoSize = True
        Me.radLTypeIncidental.Location = New System.Drawing.Point(16, 19)
        Me.radLTypeIncidental.Name = "radLTypeIncidental"
        Me.radLTypeIncidental.Size = New System.Drawing.Size(100, 17)
        Me.radLTypeIncidental.TabIndex = 0
        Me.radLTypeIncidental.Text = "Incidental (50%)"
        Me.radLTypeIncidental.UseVisualStyleBackColor = True
        '
        'chk_TreasureF
        '
        Me.chk_TreasureF.AutoSize = True
        Me.chk_TreasureF.Location = New System.Drawing.Point(204, 198)
        Me.chk_TreasureF.Name = "chk_TreasureF"
        Me.chk_TreasureF.Size = New System.Drawing.Size(32, 17)
        Me.chk_TreasureF.TabIndex = 15
        Me.chk_TreasureF.Text = "F"
        Me.chk_TreasureF.UseVisualStyleBackColor = True
        '
        'chkNPCAddExtra
        '
        Me.chkNPCAddExtra.AutoSize = True
        Me.chkNPCAddExtra.Location = New System.Drawing.Point(9, 112)
        Me.chkNPCAddExtra.Name = "chkNPCAddExtra"
        Me.chkNPCAddExtra.Size = New System.Drawing.Size(78, 17)
        Me.chkNPCAddExtra.TabIndex = 5
        Me.chkNPCAddExtra.Text = "Add Extra?"
        Me.chkNPCAddExtra.UseVisualStyleBackColor = True
        Me.chkNPCAddExtra.Visible = False
        '
        'chk_TreasureE
        '
        Me.chk_TreasureE.AutoSize = True
        Me.chk_TreasureE.Location = New System.Drawing.Point(165, 198)
        Me.chk_TreasureE.Name = "chk_TreasureE"
        Me.chk_TreasureE.Size = New System.Drawing.Size(33, 17)
        Me.chk_TreasureE.TabIndex = 14
        Me.chk_TreasureE.Text = "E"
        Me.chk_TreasureE.UseVisualStyleBackColor = True
        '
        'cmbNPCType
        '
        Me.cmbNPCType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNPCType.FormattingEnabled = True
        Me.cmbNPCType.Items.AddRange(New Object() {"Aberration", "Animal", "Construct", "Dragon", "Fey", "Humanoid", "Magical Beast", "Monstous Humanoid", "Ooze", "Outsider", "Plant", "Undead", "Vermin"})
        Me.cmbNPCType.Location = New System.Drawing.Point(9, 83)
        Me.cmbNPCType.Name = "cmbNPCType"
        Me.cmbNPCType.Size = New System.Drawing.Size(121, 21)
        Me.cmbNPCType.TabIndex = 4
        '
        'chk_TreasureD
        '
        Me.chk_TreasureD.AutoSize = True
        Me.chk_TreasureD.Location = New System.Drawing.Point(126, 198)
        Me.chk_TreasureD.Name = "chk_TreasureD"
        Me.chk_TreasureD.Size = New System.Drawing.Size(34, 17)
        Me.chk_TreasureD.TabIndex = 13
        Me.chk_TreasureD.Text = "D"
        Me.chk_TreasureD.UseVisualStyleBackColor = True
        '
        'lblNPCType
        '
        Me.lblNPCType.AutoSize = True
        Me.lblNPCType.Location = New System.Drawing.Point(6, 67)
        Me.lblNPCType.Name = "lblNPCType"
        Me.lblNPCType.Size = New System.Drawing.Size(75, 13)
        Me.lblNPCType.TabIndex = 3
        Me.lblNPCType.Text = "Monster Type:"
        '
        'chk_TreasureC
        '
        Me.chk_TreasureC.AutoSize = True
        Me.chk_TreasureC.Location = New System.Drawing.Point(87, 198)
        Me.chk_TreasureC.Name = "chk_TreasureC"
        Me.chk_TreasureC.Size = New System.Drawing.Size(33, 17)
        Me.chk_TreasureC.TabIndex = 12
        Me.chk_TreasureC.Text = "C"
        Me.chk_TreasureC.UseVisualStyleBackColor = True
        '
        'txtNPCLoot
        '
        Me.txtNPCLoot.Location = New System.Drawing.Point(268, 83)
        Me.txtNPCLoot.Name = "txtNPCLoot"
        Me.txtNPCLoot.ReadOnly = True
        Me.txtNPCLoot.Size = New System.Drawing.Size(75, 20)
        Me.txtNPCLoot.TabIndex = 8
        Me.txtNPCLoot.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'chk_TreasureB
        '
        Me.chk_TreasureB.AutoSize = True
        Me.chk_TreasureB.Location = New System.Drawing.Point(48, 198)
        Me.chk_TreasureB.Name = "chk_TreasureB"
        Me.chk_TreasureB.Size = New System.Drawing.Size(33, 17)
        Me.chk_TreasureB.TabIndex = 11
        Me.chk_TreasureB.Text = "B"
        Me.chk_TreasureB.UseVisualStyleBackColor = True
        '
        'grp_NPCEvolution
        '
        Me.grp_NPCEvolution.Controls.Add(Me.radEvoFast)
        Me.grp_NPCEvolution.Controls.Add(Me.radEvoMedium)
        Me.grp_NPCEvolution.Controls.Add(Me.radEvoSlow)
        Me.grp_NPCEvolution.Location = New System.Drawing.Point(136, 16)
        Me.grp_NPCEvolution.Name = "grp_NPCEvolution"
        Me.grp_NPCEvolution.Size = New System.Drawing.Size(207, 47)
        Me.grp_NPCEvolution.TabIndex = 2
        Me.grp_NPCEvolution.TabStop = False
        Me.grp_NPCEvolution.Text = "Evolution"
        '
        'radEvoFast
        '
        Me.radEvoFast.AutoSize = True
        Me.radEvoFast.Location = New System.Drawing.Point(138, 20)
        Me.radEvoFast.Name = "radEvoFast"
        Me.radEvoFast.Size = New System.Drawing.Size(45, 17)
        Me.radEvoFast.TabIndex = 2
        Me.radEvoFast.Text = "Fast"
        Me.radEvoFast.UseVisualStyleBackColor = True
        '
        'radEvoMedium
        '
        Me.radEvoMedium.AutoSize = True
        Me.radEvoMedium.Checked = True
        Me.radEvoMedium.Location = New System.Drawing.Point(70, 20)
        Me.radEvoMedium.Name = "radEvoMedium"
        Me.radEvoMedium.Size = New System.Drawing.Size(62, 17)
        Me.radEvoMedium.TabIndex = 1
        Me.radEvoMedium.TabStop = True
        Me.radEvoMedium.Text = "Medium"
        Me.radEvoMedium.UseVisualStyleBackColor = True
        '
        'radEvoSlow
        '
        Me.radEvoSlow.AutoSize = True
        Me.radEvoSlow.Location = New System.Drawing.Point(16, 20)
        Me.radEvoSlow.Name = "radEvoSlow"
        Me.radEvoSlow.Size = New System.Drawing.Size(48, 17)
        Me.radEvoSlow.TabIndex = 0
        Me.radEvoSlow.Text = "Slow"
        Me.radEvoSlow.UseVisualStyleBackColor = True
        '
        'chk_TreasureA
        '
        Me.chk_TreasureA.AutoSize = True
        Me.chk_TreasureA.Location = New System.Drawing.Point(9, 198)
        Me.chk_TreasureA.Name = "chk_TreasureA"
        Me.chk_TreasureA.Size = New System.Drawing.Size(33, 17)
        Me.chk_TreasureA.TabIndex = 10
        Me.chk_TreasureA.Tag = ""
        Me.chk_TreasureA.Text = "A"
        Me.chk_TreasureA.UseVisualStyleBackColor = True
        '
        'lblNPC_GP
        '
        Me.lblNPC_GP.AutoSize = True
        Me.lblNPC_GP.Location = New System.Drawing.Point(265, 67)
        Me.lblNPC_GP.Name = "lblNPC_GP"
        Me.lblNPC_GP.Size = New System.Drawing.Size(52, 13)
        Me.lblNPC_GP.TabIndex = 7
        Me.lblNPC_GP.Text = "Loot (gp):"
        '
        'cmbNPC
        '
        Me.cmbNPC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNPC.FormattingEnabled = True
        Me.cmbNPC.Items.AddRange(New Object() {"1/8", "1/6", "1/4", "1/3", "1/2", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25"})
        Me.cmbNPC.Location = New System.Drawing.Point(9, 32)
        Me.cmbNPC.Name = "cmbNPC"
        Me.cmbNPC.Size = New System.Drawing.Size(121, 21)
        Me.cmbNPC.TabIndex = 1
        '
        'lblNPC
        '
        Me.lblNPC.AutoSize = True
        Me.lblNPC.Location = New System.Drawing.Point(6, 16)
        Me.lblNPC.Name = "lblNPC"
        Me.lblNPC.Size = New System.Drawing.Size(93, 13)
        Me.lblNPC.TabIndex = 0
        Me.lblNPC.Text = "Monster/NPC CR:"
        '
        'grpBlackMarket
        '
        Me.grpBlackMarket.Controls.Add(Me.lbl_SetBMNote)
        Me.grpBlackMarket.Controls.Add(Me.txtSetBMMajor)
        Me.grpBlackMarket.Controls.Add(Me.lbl_BMSetMajor)
        Me.grpBlackMarket.Controls.Add(Me.txtSetBMMedium)
        Me.grpBlackMarket.Controls.Add(Me.txtSetBMMinor)
        Me.grpBlackMarket.Controls.Add(Me.lbl_SetBMMedium)
        Me.grpBlackMarket.Controls.Add(Me.lbl_BMSetMinor)
        Me.grpBlackMarket.Controls.Add(Me.lblSet_BMPopRange)
        Me.grpBlackMarket.Controls.Add(Me.lbl_Set_BMPopulation)
        Me.grpBlackMarket.Controls.Add(Me.cmbBlackMarket)
        Me.grpBlackMarket.Controls.Add(Me.Label7)
        Me.grpBlackMarket.Location = New System.Drawing.Point(184, 12)
        Me.grpBlackMarket.Name = "grpBlackMarket"
        Me.grpBlackMarket.Size = New System.Drawing.Size(353, 221)
        Me.grpBlackMarket.TabIndex = 2
        Me.grpBlackMarket.TabStop = False
        Me.grpBlackMarket.Text = "Black Market Magical Items"
        Me.grpBlackMarket.Visible = False
        '
        'lbl_SetBMNote
        '
        Me.lbl_SetBMNote.AutoSize = True
        Me.lbl_SetBMNote.Location = New System.Drawing.Point(6, 164)
        Me.lbl_SetBMNote.Name = "lbl_SetBMNote"
        Me.lbl_SetBMNote.Size = New System.Drawing.Size(313, 13)
        Me.lbl_SetBMNote.TabIndex = 10
        Me.lbl_SetBMNote.Text = "* Nearly all minor magic items are available, rolling 4d4 as sample."
        Me.lbl_SetBMNote.Visible = False
        '
        'txtSetBMMajor
        '
        Me.txtSetBMMajor.Location = New System.Drawing.Point(274, 104)
        Me.txtSetBMMajor.Name = "txtSetBMMajor"
        Me.txtSetBMMajor.ReadOnly = True
        Me.txtSetBMMajor.Size = New System.Drawing.Size(61, 20)
        Me.txtSetBMMajor.TabIndex = 9
        Me.txtSetBMMajor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lbl_BMSetMajor
        '
        Me.lbl_BMSetMajor.AutoSize = True
        Me.lbl_BMSetMajor.Location = New System.Drawing.Point(271, 88)
        Me.lbl_BMSetMajor.Name = "lbl_BMSetMajor"
        Me.lbl_BMSetMajor.Size = New System.Drawing.Size(64, 13)
        Me.lbl_BMSetMajor.TabIndex = 8
        Me.lbl_BMSetMajor.Text = "Major Items:"
        '
        'txtSetBMMedium
        '
        Me.txtSetBMMedium.Location = New System.Drawing.Point(143, 104)
        Me.txtSetBMMedium.Name = "txtSetBMMedium"
        Me.txtSetBMMedium.ReadOnly = True
        Me.txtSetBMMedium.Size = New System.Drawing.Size(61, 20)
        Me.txtSetBMMedium.TabIndex = 7
        Me.txtSetBMMedium.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtSetBMMinor
        '
        Me.txtSetBMMinor.Location = New System.Drawing.Point(9, 104)
        Me.txtSetBMMinor.Name = "txtSetBMMinor"
        Me.txtSetBMMinor.ReadOnly = True
        Me.txtSetBMMinor.Size = New System.Drawing.Size(61, 20)
        Me.txtSetBMMinor.TabIndex = 5
        Me.txtSetBMMinor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lbl_SetBMMedium
        '
        Me.lbl_SetBMMedium.AutoSize = True
        Me.lbl_SetBMMedium.Location = New System.Drawing.Point(140, 88)
        Me.lbl_SetBMMedium.Name = "lbl_SetBMMedium"
        Me.lbl_SetBMMedium.Size = New System.Drawing.Size(75, 13)
        Me.lbl_SetBMMedium.TabIndex = 6
        Me.lbl_SetBMMedium.Text = "Medium Items:"
        '
        'lbl_BMSetMinor
        '
        Me.lbl_BMSetMinor.AutoSize = True
        Me.lbl_BMSetMinor.Location = New System.Drawing.Point(6, 88)
        Me.lbl_BMSetMinor.Name = "lbl_BMSetMinor"
        Me.lbl_BMSetMinor.Size = New System.Drawing.Size(64, 13)
        Me.lbl_BMSetMinor.TabIndex = 4
        Me.lbl_BMSetMinor.Text = "Minor Items:"
        '
        'lblSet_BMPopRange
        '
        Me.lblSet_BMPopRange.AutoSize = True
        Me.lblSet_BMPopRange.Location = New System.Drawing.Point(140, 35)
        Me.lblSet_BMPopRange.Name = "lblSet_BMPopRange"
        Me.lblSet_BMPopRange.Size = New System.Drawing.Size(13, 13)
        Me.lblSet_BMPopRange.TabIndex = 3
        Me.lblSet_BMPopRange.Text = "0"
        '
        'lbl_Set_BMPopulation
        '
        Me.lbl_Set_BMPopulation.AutoSize = True
        Me.lbl_Set_BMPopulation.Location = New System.Drawing.Point(140, 16)
        Me.lbl_Set_BMPopulation.Name = "lbl_Set_BMPopulation"
        Me.lbl_Set_BMPopulation.Size = New System.Drawing.Size(95, 13)
        Me.lbl_Set_BMPopulation.TabIndex = 2
        Me.lbl_Set_BMPopulation.Text = "Population Range:"
        '
        'cmbBlackMarket
        '
        Me.cmbBlackMarket.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBlackMarket.FormattingEnabled = True
        Me.cmbBlackMarket.Items.AddRange(New Object() {"Hideout", "Den", "Hotbed", "Underbelly", "Underground", "Underworld"})
        Me.cmbBlackMarket.Location = New System.Drawing.Point(9, 32)
        Me.cmbBlackMarket.Name = "cmbBlackMarket"
        Me.cmbBlackMarket.Size = New System.Drawing.Size(121, 21)
        Me.cmbBlackMarket.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Black Market Type:"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(983, 593)
        Me.Controls.Add(Me.grpBlackMarket)
        Me.Controls.Add(Me.grpNPC)
        Me.Controls.Add(Me.grpTreasure)
        Me.Controls.Add(Me.txtHistoric)
        Me.Controls.Add(Me.txtResult)
        Me.Controls.Add(Me.btnRoll)
        Me.Controls.Add(Me.grpSettlement)
        Me.Name = "frmMain"
        Me.Text = "Pathfinder Treasure Roll v1.0"
        Me.grpTreasure.ResumeLayout(False)
        Me.grpTreasure.PerformLayout()
        Me.grpSettlement.ResumeLayout(False)
        Me.grpSettlement.PerformLayout()
        Me.grpNPC.ResumeLayout(False)
        Me.grpNPC.PerformLayout()
        Me.grp_NPCLootType.ResumeLayout(False)
        Me.grp_NPCLootType.PerformLayout()
        Me.grp_NPCEvolution.ResumeLayout(False)
        Me.grp_NPCEvolution.PerformLayout()
        Me.grpBlackMarket.ResumeLayout(False)
        Me.grpBlackMarket.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnRoll As System.Windows.Forms.Button
    Friend WithEvents txtResult As System.Windows.Forms.TextBox
    Friend WithEvents txtHistoric As System.Windows.Forms.TextBox
    Friend WithEvents grpTreasure As System.Windows.Forms.GroupBox
    Friend WithEvents radUnique As System.Windows.Forms.RadioButton
    Friend WithEvents radNPC As System.Windows.Forms.RadioButton
    Friend WithEvents radSettlement As System.Windows.Forms.RadioButton
    Friend WithEvents grpSettlement As System.Windows.Forms.GroupBox
    Friend WithEvents cmbSettlement As System.Windows.Forms.ComboBox
    Friend WithEvents lblSettlement As System.Windows.Forms.Label
    Friend WithEvents lblSet_PopRange As System.Windows.Forms.Label
    Friend WithEvents lblSet_Population As System.Windows.Forms.Label
    Friend WithEvents txtSetMajor As System.Windows.Forms.TextBox
    Friend WithEvents lbl_SetMajor As System.Windows.Forms.Label
    Friend WithEvents txtSetMedium As System.Windows.Forms.TextBox
    Friend WithEvents txtSetMinor As System.Windows.Forms.TextBox
    Friend WithEvents lbl_SetMedium As System.Windows.Forms.Label
    Friend WithEvents lbl_SetMinor As System.Windows.Forms.Label
    Friend WithEvents lbl_SetNote As System.Windows.Forms.Label
    Friend WithEvents grpNPC As System.Windows.Forms.GroupBox
    Friend WithEvents lblNPC_GP As System.Windows.Forms.Label
    Friend WithEvents cmbNPC As System.Windows.Forms.ComboBox
    Friend WithEvents lblNPC As System.Windows.Forms.Label
    Friend WithEvents txtNPCLoot As System.Windows.Forms.TextBox
    Friend WithEvents grp_NPCEvolution As System.Windows.Forms.GroupBox
    Friend WithEvents radEvoFast As System.Windows.Forms.RadioButton
    Friend WithEvents radEvoMedium As System.Windows.Forms.RadioButton
    Friend WithEvents radEvoSlow As System.Windows.Forms.RadioButton
    Friend WithEvents cmbNPCType As System.Windows.Forms.ComboBox
    Friend WithEvents lblNPCType As System.Windows.Forms.Label
    Friend WithEvents chkNPCAddExtra As System.Windows.Forms.CheckBox
    Friend WithEvents grp_NPCLootType As System.Windows.Forms.GroupBox
    Friend WithEvents radLTypeTriple As System.Windows.Forms.RadioButton
    Friend WithEvents radLTypeDouble As System.Windows.Forms.RadioButton
    Friend WithEvents radLTypeStandard As System.Windows.Forms.RadioButton
    Friend WithEvents radLTypeIncidental As System.Windows.Forms.RadioButton
    Friend WithEvents lblNPC_TreasureType As System.Windows.Forms.Label
    Friend WithEvents chk_TreasureA As System.Windows.Forms.CheckBox
    Friend WithEvents chk_TreasureB As System.Windows.Forms.CheckBox
    Friend WithEvents chk_TreasureD As System.Windows.Forms.CheckBox
    Friend WithEvents chk_TreasureC As System.Windows.Forms.CheckBox
    Friend WithEvents chk_TreasureF As System.Windows.Forms.CheckBox
    Friend WithEvents chk_TreasureE As System.Windows.Forms.CheckBox
    Friend WithEvents chk_TreasureI As System.Windows.Forms.CheckBox
    Friend WithEvents chk_TreasureH As System.Windows.Forms.CheckBox
    Friend WithEvents chk_TreasureG As System.Windows.Forms.CheckBox
    Friend WithEvents ttip As System.Windows.Forms.ToolTip
    Friend WithEvents radBlackMarket As System.Windows.Forms.RadioButton
    Friend WithEvents grpBlackMarket As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_SetBMNote As System.Windows.Forms.Label
    Friend WithEvents txtSetBMMajor As System.Windows.Forms.TextBox
    Friend WithEvents lbl_BMSetMajor As System.Windows.Forms.Label
    Friend WithEvents txtSetBMMedium As System.Windows.Forms.TextBox
    Friend WithEvents txtSetBMMinor As System.Windows.Forms.TextBox
    Friend WithEvents lbl_SetBMMedium As System.Windows.Forms.Label
    Friend WithEvents lbl_BMSetMinor As System.Windows.Forms.Label
    Friend WithEvents lblSet_BMPopRange As System.Windows.Forms.Label
    Friend WithEvents lbl_Set_BMPopulation As System.Windows.Forms.Label
    Friend WithEvents cmbBlackMarket As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label

End Class
