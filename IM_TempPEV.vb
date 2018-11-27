Imports Npgsql
Public Class IM_TempPEV

    Private mIdPEV As Integer
    Public Property IdPEV() As Integer
        Get
            Return mIdPEV
        End Get
        Set(ByVal value As Integer)
            mIdPEV = value
        End Set
    End Property


    Private mPtrLocal As Integer
    Public Property PtrLocal() As Integer
        Get
            Return mPtrLocal
        End Get
        Set(ByVal value As Integer)
            mPtrLocal = value
        End Set
    End Property


    Private mNumPEV As Integer
    Public Property NumPEV() As Integer
        Get
            Return mNumPEV
        End Get
        Set(ByVal value As Integer)
            mNumPEV = value
        End Set
    End Property


    Private mAffectation As String
    Public Property Affectation() As String
        Get
            Return mAffectation
        End Get
        Set(ByVal value As String)
            mAffectation = value
        End Set
    End Property


    Private mCategorie As String
    Public Property Categorie() As String
        Get
            Return mCategorie
        End Get
        Set(ByVal value As String)
            mCategorie = value
        End Set
    End Property


    Private mVL70 As Integer
    Public Property VL70() As Integer
        Get
            Return mVL70
        End Get
        Set(ByVal value As Integer)
            mVL70 = value
        End Set
    End Property


    Private mVLactu As Integer
    Public Property VLactu() As Integer
        Get
            Return mVLactu
        End Get
        Set(ByVal value As Integer)
            mVLactu = value
        End Set
    End Property


    Private mExoP As String
    Public Property ExoP() As String
        Get
            Return mExoP
        End Get
        Set(ByVal value As String)
            mExoP = value
        End Set
    End Property

    Public Sub affecte(ByVal ligne As String, ByVal ptrloc As Integer)



        mPtrLocal = ptrloc
        mNumPEV = ligne.Substring(27, 3)
        mAffectation = ligne.Substring(35, 1)
        mCategorie = ligne.Substring(37, 2)
        mVL70 = Val(Trim(ligne).Substring(60, 9))
        mVLactu = Val(Trim(ligne).Substring(69, 9))
        mExoP = ligne.Substring(78, 2)
    End Sub
    Public Function Enregistre()

        Dim sql1 As String = "INSERT INTO " & SchemaName & ".temppev (ptrlocal," _
        & " numpev,affectation,categorie,vl70,vlactu,exop" _
        & ") VALUES (:p,:p1,:p2,:p3,:p4,:p5,:p6) RETURNING idtemppev;"

        Dim cmd As New NpgsqlCommand(sql1, CnnGen)



        cmd.Parameters.Clear()

        Dim p As New NpgsqlParameter("p", mPtrLocal)
        cmd.Parameters.Add(p)
        Dim p1 As New NpgsqlParameter("p1", mNumPEV)
        cmd.Parameters.Add(p1)
        Dim p2 As New NpgsqlParameter("p2", mAffectation)
        cmd.Parameters.Add(p2)
        Dim p3 As New NpgsqlParameter("p3", mCategorie)
        cmd.Parameters.Add(p3)
        Dim p4 As New NpgsqlParameter("p4", mVL70)
        cmd.Parameters.Add(p4)
        Dim p5 As New NpgsqlParameter("p5", mVLactu)
        cmd.Parameters.Add(p5)
        Dim p6 As New NpgsqlParameter("p6", mExoP)
        cmd.Parameters.Add(p6)
        mIdPEV = cmd.ExecuteScalar
        Enregistre = mIdPEV
        cmd.Dispose()
    End Function
End Class
