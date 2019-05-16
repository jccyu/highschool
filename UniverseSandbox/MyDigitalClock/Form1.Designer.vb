<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.tkbMass = New System.Windows.Forms.TrackBar()
        Me.lblMass = New System.Windows.Forms.Label()
        Me.lblMassTextA = New System.Windows.Forms.Label()
        Me.lblDSP = New System.Windows.Forms.Label()
        Me.tkbDPS = New System.Windows.Forms.TrackBar()
        Me.tkbTPS = New System.Windows.Forms.TrackBar()
        Me.lblTPS = New System.Windows.Forms.Label()
        Me.lblStaticUnit = New System.Windows.Forms.Label()
        Me.lblStatic = New System.Windows.Forms.Label()
        Me.txtTPS = New System.Windows.Forms.TextBox()
        Me.txtDPS = New System.Windows.Forms.TextBox()
        Me.grpEditor = New System.Windows.Forms.GroupBox()
        Me.cboExisting = New System.Windows.Forms.ComboBox()
        Me.rdoExisting = New System.Windows.Forms.RadioButton()
        Me.rdoNextNew = New System.Windows.Forms.RadioButton()
        Me.txtStatic = New System.Windows.Forms.TextBox()
        Me.txtMass = New System.Windows.Forms.TextBox()
        Me.txtMassExp = New System.Windows.Forms.TextBox()
        Me.lblMassTextB = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tkbMass, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tkbDPS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tkbTPS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpEditor.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer1
        '
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.PictureBox1.Location = New System.Drawing.Point(-1, -1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1000, 800)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'btnReset
        '
        Me.btnReset.Location = New System.Drawing.Point(1020, 698)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(75, 23)
        Me.btnReset.TabIndex = 1
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(1020, 727)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 2
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'tkbMass
        '
        Me.tkbMass.Location = New System.Drawing.Point(12, 103)
        Me.tkbMass.Name = "tkbMass"
        Me.tkbMass.Size = New System.Drawing.Size(182, 45)
        Me.tkbMass.TabIndex = 3
        Me.tkbMass.Value = 6
        '
        'lblMass
        '
        Me.lblMass.AutoSize = True
        Me.lblMass.Location = New System.Drawing.Point(9, 80)
        Me.lblMass.Name = "lblMass"
        Me.lblMass.Size = New System.Drawing.Size(35, 13)
        Me.lblMass.TabIndex = 4
        Me.lblMass.Text = "Mass:"
        '
        'lblMassTextA
        '
        Me.lblMassTextA.AutoSize = True
        Me.lblMassTextA.Location = New System.Drawing.Point(116, 80)
        Me.lblMassTextA.Name = "lblMassTextA"
        Me.lblMassTextA.Size = New System.Drawing.Size(13, 13)
        Me.lblMassTextA.TabIndex = 5
        Me.lblMassTextA.Text = "e"
        '
        'lblDSP
        '
        Me.lblDSP.AutoSize = True
        Me.lblDSP.Location = New System.Drawing.Point(1005, 79)
        Me.lblDSP.Name = "lblDSP"
        Me.lblDSP.Size = New System.Drawing.Size(88, 13)
        Me.lblDSP.TabIndex = 6
        Me.lblDSP.Text = "Day Per Second:"
        '
        'tkbDPS
        '
        Me.tkbDPS.Location = New System.Drawing.Point(1008, 102)
        Me.tkbDPS.Maximum = 20
        Me.tkbDPS.Minimum = 1
        Me.tkbDPS.Name = "tkbDPS"
        Me.tkbDPS.Size = New System.Drawing.Size(193, 45)
        Me.tkbDPS.TabIndex = 8
        Me.tkbDPS.Value = 10
        '
        'tkbTPS
        '
        Me.tkbTPS.Location = New System.Drawing.Point(1008, 32)
        Me.tkbTPS.Maximum = 20
        Me.tkbTPS.Minimum = 1
        Me.tkbTPS.Name = "tkbTPS"
        Me.tkbTPS.Size = New System.Drawing.Size(193, 45)
        Me.tkbTPS.TabIndex = 11
        Me.tkbTPS.Value = 10
        '
        'lblTPS
        '
        Me.lblTPS.AutoSize = True
        Me.lblTPS.Location = New System.Drawing.Point(1005, 9)
        Me.lblTPS.Name = "lblTPS"
        Me.lblTPS.Size = New System.Drawing.Size(90, 13)
        Me.lblTPS.TabIndex = 9
        Me.lblTPS.Text = "Tick Per Second:"
        '
        'lblStaticUnit
        '
        Me.lblStaticUnit.AutoSize = True
        Me.lblStaticUnit.Location = New System.Drawing.Point(1162, 352)
        Me.lblStaticUnit.Name = "lblStaticUnit"
        Me.lblStaticUnit.Size = New System.Drawing.Size(40, 13)
        Me.lblStaticUnit.TabIndex = 14
        Me.lblStaticUnit.Text = "e29 kg"
        '
        'lblStatic
        '
        Me.lblStatic.AutoSize = True
        Me.lblStatic.Location = New System.Drawing.Point(1005, 328)
        Me.lblStatic.Name = "lblStatic"
        Me.lblStatic.Size = New System.Drawing.Size(113, 13)
        Me.lblStatic.TabIndex = 13
        Me.lblStatic.Text = "No Calculation Above:"
        '
        'txtTPS
        '
        Me.txtTPS.Location = New System.Drawing.Point(1101, 6)
        Me.txtTPS.Name = "txtTPS"
        Me.txtTPS.Size = New System.Drawing.Size(100, 20)
        Me.txtTPS.TabIndex = 15
        Me.txtTPS.Text = "10"
        '
        'txtDPS
        '
        Me.txtDPS.Location = New System.Drawing.Point(1101, 76)
        Me.txtDPS.Name = "txtDPS"
        Me.txtDPS.Size = New System.Drawing.Size(100, 20)
        Me.txtDPS.TabIndex = 16
        Me.txtDPS.Text = "10"
        '
        'grpEditor
        '
        Me.grpEditor.Controls.Add(Me.lblMassTextB)
        Me.grpEditor.Controls.Add(Me.txtMassExp)
        Me.grpEditor.Controls.Add(Me.txtMass)
        Me.grpEditor.Controls.Add(Me.cboExisting)
        Me.grpEditor.Controls.Add(Me.rdoExisting)
        Me.grpEditor.Controls.Add(Me.rdoNextNew)
        Me.grpEditor.Controls.Add(Me.lblMass)
        Me.grpEditor.Controls.Add(Me.lblMassTextA)
        Me.grpEditor.Controls.Add(Me.tkbMass)
        Me.grpEditor.Location = New System.Drawing.Point(1008, 153)
        Me.grpEditor.Name = "grpEditor"
        Me.grpEditor.Size = New System.Drawing.Size(200, 162)
        Me.grpEditor.TabIndex = 17
        Me.grpEditor.TabStop = False
        Me.grpEditor.Text = "Editor"
        '
        'cboExisting
        '
        Me.cboExisting.FormattingEnabled = True
        Me.cboExisting.Location = New System.Drawing.Point(27, 41)
        Me.cboExisting.Name = "cboExisting"
        Me.cboExisting.Size = New System.Drawing.Size(121, 21)
        Me.cboExisting.TabIndex = 3
        '
        'rdoExisting
        '
        Me.rdoExisting.AutoSize = True
        Me.rdoExisting.Location = New System.Drawing.Point(7, 44)
        Me.rdoExisting.Name = "rdoExisting"
        Me.rdoExisting.Size = New System.Drawing.Size(14, 13)
        Me.rdoExisting.TabIndex = 2
        Me.rdoExisting.TabStop = True
        Me.rdoExisting.UseVisualStyleBackColor = True
        '
        'rdoNextNew
        '
        Me.rdoNextNew.AutoSize = True
        Me.rdoNextNew.Location = New System.Drawing.Point(7, 20)
        Me.rdoNextNew.Name = "rdoNextNew"
        Me.rdoNextNew.Size = New System.Drawing.Size(72, 17)
        Me.rdoNextNew.TabIndex = 1
        Me.rdoNextNew.TabStop = True
        Me.rdoNextNew.Text = "Next New"
        Me.rdoNextNew.UseVisualStyleBackColor = True
        '
        'txtStatic
        '
        Me.txtStatic.Location = New System.Drawing.Point(1007, 349)
        Me.txtStatic.Name = "txtStatic"
        Me.txtStatic.Size = New System.Drawing.Size(148, 20)
        Me.txtStatic.TabIndex = 18
        Me.txtStatic.Text = "1"
        '
        'txtMass
        '
        Me.txtMass.Location = New System.Drawing.Point(50, 77)
        Me.txtMass.Name = "txtMass"
        Me.txtMass.Size = New System.Drawing.Size(60, 20)
        Me.txtMass.TabIndex = 19
        Me.txtMass.Text = "5.972"
        '
        'txtMassExp
        '
        Me.txtMassExp.Location = New System.Drawing.Point(134, 77)
        Me.txtMassExp.Name = "txtMassExp"
        Me.txtMassExp.Size = New System.Drawing.Size(28, 20)
        Me.txtMassExp.TabIndex = 20
        Me.txtMassExp.Text = "24"
        '
        'lblMassTextB
        '
        Me.lblMassTextB.AutoSize = True
        Me.lblMassTextB.Location = New System.Drawing.Point(168, 80)
        Me.lblMassTextB.Name = "lblMassTextB"
        Me.lblMassTextB.Size = New System.Drawing.Size(19, 13)
        Me.lblMassTextB.TabIndex = 21
        Me.lblMassTextB.Text = "kg"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1224, 762)
        Me.Controls.Add(Me.txtStatic)
        Me.Controls.Add(Me.grpEditor)
        Me.Controls.Add(Me.txtDPS)
        Me.Controls.Add(Me.txtTPS)
        Me.Controls.Add(Me.lblStaticUnit)
        Me.Controls.Add(Me.lblStatic)
        Me.Controls.Add(Me.tkbTPS)
        Me.Controls.Add(Me.lblTPS)
        Me.Controls.Add(Me.tkbDPS)
        Me.Controls.Add(Me.lblDSP)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tkbMass, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tkbDPS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tkbTPS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpEditor.ResumeLayout(False)
        Me.grpEditor.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents tkbMass As System.Windows.Forms.TrackBar
    Friend WithEvents lblMass As System.Windows.Forms.Label
    Friend WithEvents lblMassTextA As System.Windows.Forms.Label
    Friend WithEvents lblDSP As System.Windows.Forms.Label
    Friend WithEvents tkbDPS As System.Windows.Forms.TrackBar
    Friend WithEvents tkbTPS As System.Windows.Forms.TrackBar
    Friend WithEvents lblTPS As System.Windows.Forms.Label
    Friend WithEvents lblStaticUnit As System.Windows.Forms.Label
    Friend WithEvents lblStatic As System.Windows.Forms.Label
    Friend WithEvents txtTPS As System.Windows.Forms.TextBox
    Friend WithEvents txtDPS As System.Windows.Forms.TextBox
    Friend WithEvents grpEditor As System.Windows.Forms.GroupBox
    Friend WithEvents cboExisting As System.Windows.Forms.ComboBox
    Friend WithEvents rdoExisting As System.Windows.Forms.RadioButton
    Friend WithEvents rdoNextNew As System.Windows.Forms.RadioButton
    Friend WithEvents txtStatic As System.Windows.Forms.TextBox
    Friend WithEvents lblMassTextB As System.Windows.Forms.Label
    Friend WithEvents txtMassExp As System.Windows.Forms.TextBox
    Friend WithEvents txtMass As System.Windows.Forms.TextBox

End Class
