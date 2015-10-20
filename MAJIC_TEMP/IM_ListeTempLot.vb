Imports System.Data
Imports System.Data.OleDb
Imports System.Collections
Imports Npgsql
Public Class IM_ListeTempLot
    Private m_col As System.Collections.Generic.List(Of IM_Temppdl)

    Public Sub New()
        m_col = New System.Collections.Generic.List(Of IM_Temppdl)
    End Sub
    Public Function Count() As Integer
        Count = m_col.Count
    End Function
    Public Function Add(ByVal TP As IM_Temppdl) As IM_Temppdl
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

    Public Function Remove(ByVal TP As IM_Temppdl) As Integer
        Try
            m_col.Remove(TP)
            Remove = m_col.Count
        Catch ex As Exception
            Remove = -1
        End Try
    End Function

    Default Public ReadOnly Property Item(ByVal Iindex As Integer) As IM_Temppdl
        Get
            Item = m_col.Item(Iindex)
        End Get

    End Property

    Public Function ChercheIndex(ByVal TP As IM_Temppdl) As Integer
        Try
            ChercheIndex = m_col.IndexOf(TP)
        Catch ex As Exception
            ChercheIndex = -1
        End Try

    End Function

    Public Function Populate(ByVal insee As String, ByVal nomsec As String, ByVal numplan As String) As Integer

        

        Dim sql1 As String = "SELECT temppdl.pdltype, temppdl.insee, temppdl.section, temppdl.plan, temppdl.numpdl, templot.*" _
      & " FROM " & SchemaName & ".temppdl INNER JOIN " & SchemaName & ".templot ON temppdl.idtemppdl = templot.ptrtemppdl" _
      & " WHERE temppdl.insee=:p1 AND temppdl.section=:p2 AND temppdl.plan=:p3;"



        Dim cmd As New NpgsqlCommand(sql1, cnngen)

        Dim p1 As New NpgsqlParameter("p1", insee)
        cmd.Parameters.Add(p1)
        Dim p2 As New NpgsqlParameter("p2", nomsec)
        cmd.Parameters.Add(p2)
        Dim p3 As New NpgsqlParameter("p3", numplan)
        cmd.Parameters.Add(p3)

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

            Dim TP As New IM_Temppdl

            TP.Affecte(row)
            TP.PDLType = row("pdltype").ToString
            m_col.Add(TP)

        Next i

        Populate = m_col.Count

        cmd.Dispose()
        da.Dispose()

    End Function
End Class
