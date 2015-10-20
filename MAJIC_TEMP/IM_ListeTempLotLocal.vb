Imports System.Data
Imports System.Data.OleDb
Imports System.Collections
Imports Npgsql
Public Class IM_ListeTempLotLocal
    Private m_col As System.Collections.Generic.List(Of IM_TempLotLocal)

    Public Sub New()
        m_col = New System.Collections.Generic.List(Of IM_TempLotLocal)
    End Sub
    Public Function Count() As Integer
        Count = m_col.Count
    End Function
    Public Function Add(ByVal TP As IM_TempLotLocal) As IM_TempLotLocal
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

    Public Function Remove(ByVal TP As IM_TempLotLocal) As Integer
        Try
            m_col.Remove(TP)
            Remove = m_col.Count
        Catch ex As Exception
            Remove = -1
        End Try
    End Function

    Default Public ReadOnly Property Item(ByVal Iindex As Integer) As IM_TempLotLocal
        Get
            Item = m_col.Item(Iindex)
        End Get

    End Property

    Public Function ChercheIndex(ByVal TP As IM_TempLotLocal) As Integer
        Try
            ChercheIndex = m_col.IndexOf(TP)
        Catch ex As Exception
            ChercheIndex = -1
        End Try

    End Function

    Public Sub Existe(ByVal invariant As String)
        Dim res As IM_TempLotLocal

        Dim sql1 As String = "SELECT * FROM templotlocal WHERE invariant=:p;"

        Dim cmd As New NpgsqlCommand(sql1, cnngen)

        cmd.Parameters.Clear()
        Dim p As New NpgsqlParameter("p", invariant)
        cmd.Parameters.Add(p)

        Dim da As New NpgsqlDataAdapter
        da.SelectCommand = cmd
        Dim ds As New DataSet
        da.Fill(ds)
        If ds.Tables.Count <> 0 And ds.Tables(0).Rows.Count <> 0 Then

            For i = 0 To ds.Tables(0).Rows.Count - 1
                res = New IM_TempLotLocal()
                res.Affecte(ds.Tables(0).Rows(i))
                Add(res)
            Next


        Else
            res = Nothing
        End If



    End Sub
End Class
