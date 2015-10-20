Option Explicit On
Imports Npgsql
Imports System.Data
Imports System.Data.OleDb
Imports System.Collections
Public Class IM_TempSurfaces
    Private m_col As System.Collections.Generic.List(Of IM_TempSurface)

    Public Sub New()
        m_col = New System.Collections.Generic.List(Of IM_TempSurface)
    End Sub
    Public Function Count() As Integer
        Count = m_col.Count
    End Function
    Public Function Add(ByVal TS As IM_TempSurface) As IM_TempSurface
        Try
            m_col.Add(TS)
            Add = TS

        Catch ex As Exception

            Add = Nothing

        End Try

    End Function

    Public Sub Clear()
        m_col.Clear()
    End Sub

    Public Function Remove(ByVal TS As IM_TempSurface) As Integer
        Try
            m_col.Remove(TS)
            Remove = m_col.Count
        Catch ex As Exception
            Remove = -1
        End Try
    End Function

    Default Public ReadOnly Property Item(ByVal Iindex As Integer) As IM_TempSurface
        Get
            Item = m_col.Item(Iindex)
        End Get

    End Property

    Public Function ChercheIndex(ByVal TS As IM_TempSurface) As Integer
        Try
            ChercheIndex = m_col.IndexOf(TS)
        Catch ex As Exception
            ChercheIndex = -1
        End Try

    End Function

    Public Function Populate(ByVal IDParc As Integer) As Integer

        Dim sql1 As String = "SELECT * FROM " & SchemaName & ".tempsurface WHERE ptrtempParcelle=:id;"

        Dim cmd As New NpgsqlCommand(sql1, cnngen)
        cmd.Parameters.Clear()
        Dim id As New NpgsqlParameter("id", IDParc)
        cmd.Parameters.Add(id)

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

            Dim ts As New IM_TempSurface
            ts.Affecte(row)
            m_col.Add(ts)
            ts = Nothing
        Next i

        Populate = m_col.Count


    End Function
End Class
