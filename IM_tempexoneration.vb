Imports Npgsql

Public Class IM_tempexoneration
    Private mInvariant As String
    Public Property Invariant() As String
        Get
            Return mInvariant
        End Get
        Set(ByVal value As String)
            mInvariant = value
        End Set
    End Property
    Private mCollectivite As String
    Public Property Collectivite() As String
        Get
            Return mCollectivite
        End Get
        Set(ByVal value As String)
            mCollectivite = value
        End Set
    End Property
    Private mPrctexo As Integer
    Public Property Prctexo() As Integer
        Get
            Return mPrctexo
        End Get
        Set(ByVal value As Integer)
            mPrctexo = value
        End Set
    End Property
    Private mNature As String
    Public Property Nature() As String
        Get
            Return mNature
        End Get
        Set(ByVal value As String)
            mNature = value
        End Set
    End Property
    Private mAnneeDep As String
    Public Property AnneeDep() As String
        Get
            Return mAnneeDep
        End Get
        Set(ByVal value As String)
            mAnneeDep = value
        End Set
    End Property
    Private mAnneeRet As String
    Public Property AnneeRet() As String
        Get
            Return mAnneeRet
        End Get
        Set(ByVal value As String)
            mAnneeRet = value
        End Set
    End Property

    Public Sub Affecte(ByVal ligne As String)
        mInvariant = ligne.Substring(6, 10)
        mCollectivite = ligne.Substring(35, 2)
        mPrctexo = ligne.Substring(37, 5)
        mNature = ligne.Substring(42, 2)
        mAnneeDep = ligne.Substring(44, 4)
        mAnneeRet = ligne.Substring(48, 4)

    End Sub

    Public Function Enregistre()

        Dim sql1 As String = "INSERT INTO " & SchemaName & ".tempexoneration (invariant,collectivite,prctexo,nature,annee_dep,annee_ret)" _
        & " VALUES (:p,:p1,:p2,:p3,:p4,:p5)"

        Dim cmd As New NpgsqlCommand(sql1, CnnGen)
        cmd.Parameters.Clear()

        Dim p As New NpgsqlParameter("p", mInvariant)
        cmd.Parameters.Add(p)
        Dim p1 As New NpgsqlParameter("p1", mCollectivite)
        cmd.Parameters.Add(p1)
        Dim p2 As New NpgsqlParameter("p2", mPrctexo)
        cmd.Parameters.Add(p2)
        Dim p3 As New NpgsqlParameter("p3", mNature)
        cmd.Parameters.Add(p3)
        Dim p4 As New NpgsqlParameter("p4", mAnneeDep)
        cmd.Parameters.Add(p4)
        Dim p5 As New NpgsqlParameter("p5", mAnneeRet)
        cmd.Parameters.Add(p5)

        cmd.ExecuteNonQuery()
        cmd.Dispose()
    End Function
End Class
