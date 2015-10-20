
Imports System.Data
Imports System.Data.OleDb
Imports System.Collections
Imports Npgsql
Public Class IM_ListeTempProprio
    Private m_col As System.Collections.Generic.List(Of IM_TempProprio)

    Public Sub New()
        m_col = New System.Collections.Generic.List(Of IM_TempProprio)
    End Sub
    Public Function Count() As Integer
        Count = m_col.Count
    End Function
    Public Function Add(ByVal TP As IM_TempProprio) As IM_TempProprio
        Try
            m_col.Add(TP)
            Add = TP

        Catch ex As Exception

            Add = Nothing

        End Try

    End Function

    Public Sub Clear()
        m_col.Clear()
    End Sub

    Public Function Remove(ByVal TP As IM_TempProprio) As Integer
        Try
            m_col.Remove(TP)
            Remove = m_col.Count
        Catch ex As Exception
            Remove = -1
        End Try
    End Function

    Default Public ReadOnly Property Item(ByVal Iindex As Integer) As IM_TempProprio
        Get
            Item = m_col.Item(Iindex)
        End Get

    End Property

    Public Function ChercheIndex(ByVal TP As IM_TempProprio) As Integer
        Try
            ChercheIndex = m_col.IndexOf(TP)
        Catch ex As Exception
            ChercheIndex = -1
        End Try

    End Function

    Public Function TousLesProprietaires(ByVal insee As String) As Integer
        Dim sql1 As String = "SELECT * FROM " & SchemaName & ".tempproprio WHERE insee=:p;"


        Dim cmd As New NpgsqlCommand(sql1, cnngen)
        Dim p As New NpgsqlParameter("p", insee)
        cmd.Parameters.Add(p)
        Dim da As New NpgsqlDataAdapter
        da.SelectCommand = cmd
        Dim ds As New DataSet
        da.Fill(ds)

        Dim i As Integer
        Dim row As DataRow

        m_col.Clear()
        Dim tbl1 As DataTable = ds.Tables(0)

        For i = 0 To tbl1.Rows.Count - 1
            row = tbl1.Rows(i)
            'dim TP As New tempproprio(row("Id_TempLot"), nomcomplet)
            Dim TP As New IM_TempProprio

            TP.Affecte(row)
            m_col.Add(TP)
            TP = Nothing
        Next i

        TousLesProprietaires = m_col.Count


    End Function

End Class
