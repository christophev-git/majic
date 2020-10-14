Imports Npgsql
Imports System.Threading
Public Class Form1

    Public ListeFichier(4) As String

    Private Sub ConnexionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConnexionToolStripMenuItem.Click
        initschema()
    End Sub
    Private Sub initschema_dvf()
        If CnnGen Is Nothing Then
            If Dialogconnection.ShowDialog = DialogResult.OK Then

            Else
                TextBox1.Text = "Abandon"
                Exit Sub
            End If
        End If
        CnnGen.ChangeDatabase(DatabaseName)



        If SchemaName <> "" Then

        Else
            MsgBox("Impossible d'intégrer des données sans schema", MsgBoxStyle.Critical)
            TextBox1.Text = TextBox1.Text & vbCrLf & "Impossible d'intégrer des données sans schema"
            Exit Sub
        End If
        
        Dim m_cmd As New NpgsqlCommand
        m_cmd = New NpgsqlCommand
        m_cmd.Connection = CnnGen
        m_cmd.CommandText = "SELECT schema_name FROM information_schema.schemata WHERE schema_name=:p;"
        Dim p As New NpgsqlParameter("p", SchemaName)
        m_cmd.Parameters.Add(p)
        Dim m_da As New NpgsqlDataAdapter
        Dim m_ds As New System.Data.DataSet
        m_da.SelectCommand = m_cmd
        m_da.Fill(m_ds)


        If m_ds.Tables(0).Rows.Count = 0 Then
            m_cmd.CommandText = "CREATE SCHEMA " & SchemaName & ";"
            m_cmd.ExecuteNonQuery()

        End If



        m_da.Dispose()
        m_cmd.Dispose()
    End Sub

    Private Function initschema() As Integer
        If CnnGen Is Nothing Then
            If Dialogconnection.ShowDialog = DialogResult.OK Then

            Else
                TextBox1.Text = "Abandon"
                Return 1
            End If
        End If
        Dialogconnection.Dispose()
        CnnGen.ChangeDatabase(DatabaseName)

        Dim d As String = InputBox("Millesime des données (rien pour intégrer dans le shema choisi ou année pour intégration dans le schéma majic+milésime)?", "")
        If d = "" Then
            If SchemaName <> "" Then
                If MsgBox("Intgegration dans le schema : " & SchemaName, MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    d = SchemaName
                    TextBox1.Text = TextBox1.Text & vbCrLf & "Intégration dans le schéma " & SchemaName & vbCrLf & "Millésime actuel"
                End If

            Else
                MsgBox("Impossible d'intégrer des données sans millesime", MsgBoxStyle.Critical)
                TextBox1.Text = TextBox1.Text & vbCrLf & "Impossible d'inétgrer les données"
                Return 2
            End If
        Else

            TextBox1.Text = TextBox1.Text & vbCrLf & "Millésime " & d
            d = "majic" & d
            TextBox1.Text = TextBox1.Text & vbCrLf & "Schéma " & d
        End If

        Dim m_cmd As New NpgsqlCommand
        m_cmd = New NpgsqlCommand
        m_cmd.Connection = CnnGen
        m_cmd.CommandText = "SELECT schema_name FROM information_schema.schemata WHERE schema_name=:p;"
        Dim p As New NpgsqlParameter("p", d)
        m_cmd.Parameters.Add(p)
        Dim m_da As New NpgsqlDataAdapter
        Dim m_ds As New System.Data.DataSet
        m_da.SelectCommand = m_cmd
        m_da.Fill(m_ds)


        If m_ds.Tables(0).Rows.Count = 0 Then
            m_cmd.CommandText = "CREATE SCHEMA " & d & ";"
            m_cmd.ExecuteNonQuery()
            TextBox1.Text = TextBox1.Text & vbCrLf & " Création du scéma " & d
        Else
            TextBox1.Text = TextBox1.Text & vbCrLf & "Schéma " & d & " existant"
        End If


        SchemaName = d

        m_da.Dispose()
        m_cmd.Dispose()

    End Function

    Private Sub NonBatiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NonBatiToolStripMenuItem.Click

        initschema()
        
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            If OpenFileDialog1.FileName.ToString = "*" Then


            Else
                Dim Maj As New MAJIC_TextFile
                Maj.PopulateTempParcelle(OpenFileDialog1.FileName)
            End If
        End If
    End Sub

    Private Sub PDLToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PDLToolStripMenuItem.Click
        initschema()

        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim Maj As New MAJIC_TextFile
            Maj.PopulateTempPDL(OpenFileDialog1.FileName)
        End If
    End Sub

    Private Sub ProprietaireToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProprietaireToolStripMenuItem.Click
        initschema()

        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim Maj As New MAJIC_TextFile
            Maj.PopulateTempProprio(OpenFileDialog1.FileName)
        End If
    End Sub

    Private Sub BatiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BatiToolStripMenuItem.Click
        initschema()

        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim Maj As New MAJIC_TextFile
            Maj.PopulateTempLocaux(OpenFileDialog1.FileName)
        End If
    End Sub

    Private Sub LotLocauxToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LotLocauxToolStripMenuItem.Click
        initschema()

        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim Maj As New MAJIC_TextFile
            Maj.PopulateTempLotLocal(OpenFileDialog1.FileName)
        End If
    End Sub

    Private Sub FantoirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FantoirToolStripMenuItem.Click
        initschema()
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim Maj As New MAJIC_TextFile
            Maj.PopulateTempAdresse(OpenFileDialog1.FileName)
        End If
    End Sub

    Private Sub GestionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GestionToolStripMenuItem.Click

    End Sub

    Private Sub IntégrationTempToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IntégrationTempToolStripMenuItem.Click
        initschema_dvf()

        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim Maj As New DVF_TextFile
            Maj.PopulateTempDVF(OpenFileDialog1.FileName)
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        t(0) = "Fichier NON BATI"
        t(1) = "Fichier PDL"
        t(2) = "Fichier PROPRIETAIRE"
        t(3) = "Fichier BATI"
        t(4) = "Fichier LOT LOCAUX"

        RadioButton1.Checked = False
        RadioButton1.Enabled = False

        Labelschema.Enabled = False
        GroupBox1.Enabled = False
        Button3.Visible = False
        ButtonIntegration.Visible = False
        Button5.Visible = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.Clear()
        Select Case initschema()

            Case 0
                Labelschema.Text = "Schéma : & " & SchemaName
                RadioButton1.Checked = True
                Button1.Enabled = False
                Labelschema.Enabled = True
                GroupBox1.Enabled = True
            Case Is > 0

        End Select
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub RadioButtonsimple_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonsimple.CheckedChanged
        If RadioButtonsimple.Checked Then
            Button2.Visible = True
        End If
    End Sub
    Private t(4) As String
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        GroupBox1.Enabled = False
        With OpenFileDialog1
            .Filter = "|*.*"

            For i = 0 To 4
                .Title = t(i)


                If .ShowDialog <> Windows.Forms.DialogResult.OK Then
                    Exit Sub
                End If
                If RadioButtonMultiple.Checked Then
                    ListeFichier(i) = .SafeFileName
                    TextBox1.Text = TextBox1.Text & vbCrLf & t(i) & " : " & .SafeFileName
                Else
                    ListeFichier(i) = .FileName
                    TextBox1.Text = TextBox1.Text & vbCrLf & t(i) & " : " & .FileName
                End If
                

            Next i
        End With

        If RadioButtonMultiple.Checked Then
            Button2.Visible = False
            Button3.Visible = True
        Else
            Button2.Visible = False
            ButtonIntegration.Visible = True
        End If
    End Sub

    Private Sub RadioButtonMultiple_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonMultiple.CheckedChanged
        If RadioButtonMultiple.Checked Then
            Button2.Visible = True
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        t(0) = "Fichier NON BATI"
        t(1) = "Fichier PDL"
        t(2) = "Fichier PROPRIETAIRE"
        t(3) = "Fichier BATI"
        t(4) = "Fichier LOT LOCAUX"

        RadioButton1.Checked = False
        RadioButton1.Enabled = False

        Labelschema.Enabled = False
        GroupBox1.Enabled = False
        Button3.Visible = False
        ButtonIntegration.Visible = False
        Button5.Visible = False
    End Sub

    Private RepRacine As String = ""

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        If FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then

            RepRacine = FolderBrowserDialog1.SelectedPath

            ButtonIntegration.Visible = True
            Button3.Visible = False
        End If
    End Sub
    Private Sub integre()
        Dim Maj As New MAJIC_TextFile

        If RadioButtonsimple.Checked Then
            Me.Invoke(ProgresInstance, " Traitement non bati")
            Maj.PopulateTempParcelle(ListeFichier(0))
            Me.Invoke(ProgresInstance, " Traitement PDL")
            Maj.PopulateTempPDL(ListeFichier(1))
            Me.Invoke(ProgresInstance, " Traitement PROPRIETAIRE")
            Maj.PopulateTempProprio(ListeFichier(2))
            Me.Invoke(ProgresInstance, " Traitement LOCAUX")
            Maj.PopulateTempLocaux(ListeFichier(3))
            Me.Invoke(ProgresInstance, " Traitement LOT LOCAUX")
            Maj.PopulateTempLotLocal(ListeFichier(4))


        Else

            Dim lf As New System.IO.DirectoryInfo(RepRacine)
            ' TextBox1.Clear()
            For i = 0 To 4


                For Each fi As System.IO.FileInfo In lf.GetFiles(ListeFichier(i), IO.SearchOption.AllDirectories)

                    Me.Invoke(ProgresInstance, " Traitement " & fi.FullName)

                    Select Case i

                        Case 0

                            Maj.PopulateTempParcelle(fi.FullName)
                        Case 1
                            Maj.PopulateTempPDL(fi.FullName)
                        Case 2
                            Maj.PopulateTempProprio(fi.FullName)
                        Case 3
                            Maj.PopulateTempLocaux(fi.FullName)
                        Case 4
                            Maj.PopulateTempLotLocal(fi.FullName)
                    End Select

                Next


            Next




        End If
    End Sub
    Private Sub ButtonIntegration_Click(sender As Object, e As EventArgs) Handles ButtonIntegration.Click
        Dim THRIntegration As New Thread(AddressOf integre)

        THRIntegration.Start()

        
    End Sub

    Private Sub RealiseProgres(msg As String)
        TextBox1.Text = TextBox1.Text & vbCrLf & msg
    End Sub

    Private Delegate Sub Progres(msg As String)

    Private ProgresInstance As New Progres(AddressOf RealiseProgres)

End Class
