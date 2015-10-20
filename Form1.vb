﻿Imports Npgsql
Public Class Form1

    Private Sub ConnexionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConnexionToolStripMenuItem.Click
        Dialogconnection.ShowDialog()
    End Sub

    Private Sub initschema()
        If CnnGen Is Nothing Then
            If Dialogconnection.ShowDialog = DialogResult.OK Then

            Else
                Exit Sub
            End If
        End If
        CnnGen.ChangeDatabase(DatabaseName)

        Dim d As String = InputBox("Millesime des données ?", "")
        If d = "" Then
            MsgBox("Impossible d'intégrer des données sans millesime", MsgBoxStyle.Critical)
            Exit Sub
        End If
        Dim m_cmd As New NpgsqlCommand
        m_cmd = New NpgsqlCommand
        m_cmd.Connection = CnnGen
        m_cmd.CommandText = "SELECT schema_name FROM information_schema.schemata WHERE schema_name=:p;"
        Dim p As New NpgsqlParameter("p", "majic" & d)
        m_cmd.Parameters.Add(p)
        Dim m_da As New NpgsqlDataAdapter
        Dim m_ds As New System.Data.DataSet
        m_da.SelectCommand = m_cmd
        m_da.Fill(m_ds)


        If m_ds.Tables(0).Rows.Count = 0 Then
            m_cmd.CommandText = "CREATE SCHEMA majic" & d & ";"
            m_cmd.ExecuteNonQuery()

        End If


        SchemaName = "majic" & d

        m_da.Dispose()
        m_cmd.Dispose()

    End Sub

    Private Sub NonBatiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NonBatiToolStripMenuItem.Click

        initschema()
        
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim Maj As New MAJIC_TextFile
            Maj.PopulateTempParcelle(OpenFileDialog1.FileName)
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
End Class
