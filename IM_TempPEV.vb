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
    Private mCoefEntretien As String
    Public Property CoefEntretien() As String
        Get
            Return mCoefEntretien
        End Get
        Set(ByVal value As String)
            mCoefEntretien = value
        End Set
    End Property
    Private mSurfPond As Integer
    Public Property SurfPond() As Integer
        Get
            Return mSurfPond
        End Get
        Set(ByVal value As Integer)
            mSurfPond = value
        End Set
    End Property

    Private mCoefSP As String
    Public Property CoefSP() As String
        Get
            Return mCoefSP
        End Get
        Set(ByVal value As String)
            mCoefSP = value
        End Set
    End Property

    Private mCoefSG As String
    Public Property CoefSG() As String
        Get
            Return mCoefSG
        End Get
        Set(ByVal value As String)
            mCoefSG = value
        End Set
    End Property
    Private mCodeCat As String
    Public Property CodeCat() As String
        Get
            Return mCodeCat
        End Get
        Set(ByVal value As String)
            mCodeCat = value
        End Set
    End Property

    Private mRevise As String
    Public Property Revise() As String
        Get
            Return mRevise
        End Get
        Set(ByVal value As String)
            mRevise = value
        End Set
    End Property
    Private mCoefLoc As String
    Public Property CoefLoc() As String
        Get
            Return mCoefLoc
        End Get
        Set(ByVal value As String)
            mCoefLoc = value
        End Set
    End Property
    Public Sub affecte(ByVal ligne As String, ByVal ptrloc As Integer)



        mPtrLocal = ptrloc
        mNumPEV = ligne.Substring(27, 3)
        mAffectation = ligne.Substring(35, 1)
        mCategorie = ligne.Substring(37, 2)
        mCodeCat = ligne.Substring(45, 4)
        mRevise = ligne.Substring(49, 2)
        mCoefLoc = ligne.Substring(51, 3)
        mVL70 = Val(Trim(ligne).Substring(60, 9))
        mVLactu = Val(Trim(ligne).Substring(69, 9))
        mExoP = ligne.Substring(78, 2)
        mCoefEntretien = ligne.Substring(39, 3)
        mSurfPond = ligne.Substring(54, 6)
        If ligne.Length >= 165 Then
            mCoefSP = ligne.Substring(155, 5)
            mCoefSG = ligne.Substring(160, 5)
        Else
            mCoefSP = 0
            mCoefSG = 0
        End If
    End Sub
    Public Function Enregistre()

        Dim sql1 As String = "INSERT INTO " & SchemaName & ".temppev (ptrlocal," _
        & " numpev,affectation,categorie,vl70,vlactu,exop,coefentretien,codecat,revise,coefloc,surfpond,coefsp,coefsg" _
        & ") VALUES (:p,:p1,:p2,:p3,:p4,:p5,:p6,:p7,:p11,:p12,:p13,:p8,:p9,:p10) RETURNING idtemppev;"

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
        Dim p7 As New NpgsqlParameter("p7", mCoefEntretien)
        cmd.Parameters.Add(p7)
        Dim p11 As New NpgsqlParameter("p11", mCodeCat)
        cmd.Parameters.Add(p11)
        Dim p12 As New NpgsqlParameter("p12", mRevise)
        cmd.Parameters.Add(p12)
        Dim p13 As New NpgsqlParameter("p13", mCoefLoc)
        cmd.Parameters.Add(p13)
        Dim p8 As New NpgsqlParameter("p8", mSurfPond)
        cmd.Parameters.Add(p8)
        Dim p9 As New NpgsqlParameter("p9", mCoefSP)
        cmd.Parameters.Add(p9)
        Dim p10 As New NpgsqlParameter("p10", mCoefSG)
        cmd.Parameters.Add(p10)
        mIdPEV = cmd.ExecuteScalar
        Enregistre = mIdPEV
        cmd.Dispose()
    End Function
End Class
