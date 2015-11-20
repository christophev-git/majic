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
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.DvfToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IntégrationTempToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GestionToolStripMenuItem, Me.DvfToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(8, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(985, 27)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'GestionToolStripMenuItem
        '
        Me.GestionToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConnexionToolStripMenuItem, Me.NonBatiToolStripMenuItem, Me.PDLToolStripMenuItem, Me.ProprietaireToolStripMenuItem, Me.BatiToolStripMenuItem, Me.LotLocauxToolStripMenuItem, Me.FantoirToolStripMenuItem})
        Me.GestionToolStripMenuItem.Name = "GestionToolStripMenuItem"
        Me.GestionToolStripMenuItem.Size = New System.Drawing.Size(68, 23)
        Me.GestionToolStripMenuItem.Text = "Gestion"
        '
        'ConnexionToolStripMenuItem
        '
        Me.ConnexionToolStripMenuItem.Name = "ConnexionToolStripMenuItem"
        Me.ConnexionToolStripMenuItem.Size = New System.Drawing.Size(152, 24)
        Me.ConnexionToolStripMenuItem.Text = "Connexion"
        '
        'NonBatiToolStripMenuItem
        '
        Me.NonBatiToolStripMenuItem.Name = "NonBatiToolStripMenuItem"
        Me.NonBatiToolStripMenuItem.Size = New System.Drawing.Size(152, 24)
        Me.NonBatiToolStripMenuItem.Text = "Non Bati"
        '
        'PDLToolStripMenuItem
        '
        Me.PDLToolStripMenuItem.Name = "PDLToolStripMenuItem"
        Me.PDLToolStripMenuItem.Size = New System.Drawing.Size(152, 24)
        Me.PDLToolStripMenuItem.Text = "PDL"
        '
        'ProprietaireToolStripMenuItem
        '
        Me.ProprietaireToolStripMenuItem.Name = "ProprietaireToolStripMenuItem"
        Me.ProprietaireToolStripMenuItem.Size = New System.Drawing.Size(152, 24)
        Me.ProprietaireToolStripMenuItem.Text = "Proprietaire"
        '
        'BatiToolStripMenuItem
        '
        Me.BatiToolStripMenuItem.Name = "BatiToolStripMenuItem"
        Me.BatiToolStripMenuItem.Size = New System.Drawing.Size(152, 24)
        Me.BatiToolStripMenuItem.Text = "Bati"
        '
        'LotLocauxToolStripMenuItem
        '
        Me.LotLocauxToolStripMenuItem.Name = "LotLocauxToolStripMenuItem"
        Me.LotLocauxToolStripMenuItem.Size = New System.Drawing.Size(152, 24)
        Me.LotLocauxToolStripMenuItem.Text = "Lot Locaux"
        '
        'FantoirToolStripMenuItem
        '
        Me.FantoirToolStripMenuItem.Name = "FantoirToolStripMenuItem"
        Me.FantoirToolStripMenuItem.Size = New System.Drawing.Size(152, 24)
        Me.FantoirToolStripMenuItem.Text = "Fantoir"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'DvfToolStripMenuItem
        '
        Me.DvfToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.IntégrationTempToolStripMenuItem})
        Me.DvfToolStripMenuItem.Name = "DvfToolStripMenuItem"
        Me.DvfToolStripMenuItem.Size = New System.Drawing.Size(40, 23)
        Me.DvfToolStripMenuItem.Text = "dvf"
        '
        'IntégrationTempToolStripMenuItem
        '
        Me.IntégrationTempToolStripMenuItem.Name = "IntégrationTempToolStripMenuItem"
        Me.IntégrationTempToolStripMenuItem.Size = New System.Drawing.Size(181, 24)
        Me.IntégrationTempToolStripMenuItem.Text = "intégration temp"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(985, 322)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
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

End Class
