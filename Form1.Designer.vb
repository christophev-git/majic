<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.GestionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConnexionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NonBatiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PDLToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProprietaireToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BatiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LotLocauxToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FantoirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DvfToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IntégrationTempToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Labelschema = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RadioButtonMultiple = New System.Windows.Forms.RadioButton()
        Me.RadioButtonsimple = New System.Windows.Forms.RadioButton()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.ButtonIntegration = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GestionToolStripMenuItem, Me.DvfToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(890, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'GestionToolStripMenuItem
        '
        Me.GestionToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConnexionToolStripMenuItem, Me.NonBatiToolStripMenuItem, Me.PDLToolStripMenuItem, Me.ProprietaireToolStripMenuItem, Me.BatiToolStripMenuItem, Me.LotLocauxToolStripMenuItem, Me.FantoirToolStripMenuItem})
        Me.GestionToolStripMenuItem.Name = "GestionToolStripMenuItem"
        Me.GestionToolStripMenuItem.Size = New System.Drawing.Size(59, 20)
        Me.GestionToolStripMenuItem.Text = "Gestion"
        '
        'ConnexionToolStripMenuItem
        '
        Me.ConnexionToolStripMenuItem.Name = "ConnexionToolStripMenuItem"
        Me.ConnexionToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ConnexionToolStripMenuItem.Text = "Connexion"
        '
        'NonBatiToolStripMenuItem
        '
        Me.NonBatiToolStripMenuItem.Name = "NonBatiToolStripMenuItem"
        Me.NonBatiToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.NonBatiToolStripMenuItem.Text = "Non Bati"
        '
        'PDLToolStripMenuItem
        '
        Me.PDLToolStripMenuItem.Name = "PDLToolStripMenuItem"
        Me.PDLToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.PDLToolStripMenuItem.Text = "PDL"
        '
        'ProprietaireToolStripMenuItem
        '
        Me.ProprietaireToolStripMenuItem.Name = "ProprietaireToolStripMenuItem"
        Me.ProprietaireToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ProprietaireToolStripMenuItem.Text = "Proprietaire"
        '
        'BatiToolStripMenuItem
        '
        Me.BatiToolStripMenuItem.Name = "BatiToolStripMenuItem"
        Me.BatiToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.BatiToolStripMenuItem.Text = "Bati"
        '
        'LotLocauxToolStripMenuItem
        '
        Me.LotLocauxToolStripMenuItem.Name = "LotLocauxToolStripMenuItem"
        Me.LotLocauxToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.LotLocauxToolStripMenuItem.Text = "Lot Locaux"
        '
        'FantoirToolStripMenuItem
        '
        Me.FantoirToolStripMenuItem.Name = "FantoirToolStripMenuItem"
        Me.FantoirToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.FantoirToolStripMenuItem.Text = "Fantoir"
        '
        'DvfToolStripMenuItem
        '
        Me.DvfToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.IntégrationTempToolStripMenuItem})
        Me.DvfToolStripMenuItem.Name = "DvfToolStripMenuItem"
        Me.DvfToolStripMenuItem.Size = New System.Drawing.Size(36, 20)
        Me.DvfToolStripMenuItem.Text = "dvf"
        '
        'IntégrationTempToolStripMenuItem
        '
        Me.IntégrationTempToolStripMenuItem.Name = "IntégrationTempToolStripMenuItem"
        Me.IntégrationTempToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.IntégrationTempToolStripMenuItem.Text = "intégration temp"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(108, 41)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RadioButton1.Size = New System.Drawing.Size(55, 17)
        Me.RadioButton1.TabIndex = 2
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Active"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(307, 27)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(571, 197)
        Me.TextBox1.TabIndex = 3
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 37)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(86, 24)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Connexion"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Labelschema
        '
        Me.Labelschema.AutoSize = True
        Me.Labelschema.Location = New System.Drawing.Point(192, 43)
        Me.Labelschema.Name = "Labelschema"
        Me.Labelschema.Size = New System.Drawing.Size(46, 13)
        Me.Labelschema.TabIndex = 5
        Me.Labelschema.Text = "Schéma"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RadioButtonMultiple)
        Me.GroupBox1.Controls.Add(Me.RadioButtonsimple)
        Me.GroupBox1.Location = New System.Drawing.Point(28, 131)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(151, 93)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Type fichier"
        '
        'RadioButtonMultiple
        '
        Me.RadioButtonMultiple.AutoSize = True
        Me.RadioButtonMultiple.Location = New System.Drawing.Point(6, 53)
        Me.RadioButtonMultiple.Name = "RadioButtonMultiple"
        Me.RadioButtonMultiple.Size = New System.Drawing.Size(61, 17)
        Me.RadioButtonMultiple.TabIndex = 1
        Me.RadioButtonMultiple.TabStop = True
        Me.RadioButtonMultiple.Text = "Multiple"
        Me.RadioButtonMultiple.UseVisualStyleBackColor = True
        '
        'RadioButtonsimple
        '
        Me.RadioButtonsimple.AutoSize = True
        Me.RadioButtonsimple.Location = New System.Drawing.Point(6, 30)
        Me.RadioButtonsimple.Name = "RadioButtonsimple"
        Me.RadioButtonsimple.Size = New System.Drawing.Size(56, 17)
        Me.RadioButtonsimple.TabIndex = 0
        Me.RadioButtonsimple.TabStop = True
        Me.RadioButtonsimple.Text = "Simple"
        Me.RadioButtonsimple.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(185, 144)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(103, 33)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "Fichiers sources"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(185, 115)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(102, 33)
        Me.Button3.TabIndex = 8
        Me.Button3.Text = "Répertoire racine"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'ButtonIntegration
        '
        Me.ButtonIntegration.Location = New System.Drawing.Point(185, 184)
        Me.ButtonIntegration.Name = "ButtonIntegration"
        Me.ButtonIntegration.Size = New System.Drawing.Size(103, 28)
        Me.ButtonIntegration.TabIndex = 9
        Me.ButtonIntegration.Text = "Intégration"
        Me.ButtonIntegration.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(146, 84)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(109, 25)
        Me.Button5.TabIndex = 10
        Me.Button5.Text = "Annuler"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(890, 247)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.ButtonIntegration)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Labelschema)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents GestionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConnexionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NonBatiToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PDLToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProprietaireToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BatiToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LotLocauxToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FantoirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents DvfToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IntégrationTempToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Labelschema As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButtonMultiple As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonsimple As System.Windows.Forms.RadioButton
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents ButtonIntegration As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog

End Class
