Option Strict Off
Option Explicit On
Imports System.Data

Imports Npgsql
Public Class TempDVF

    Private m_ID As Integer
    Public Property ID() As Integer
        Get
            Return m_ID
        End Get
        Set(ByVal value As Integer)
            m_ID = value
        End Set
    End Property

    Private mCodeCH As String
    Public Property CodeCH() As String
        Get
            Return mCodeCH
        End Get
        Set(ByVal value As String)
            mCodeCH = value
        End Set
    End Property

    Private mRefPublication As String
    Public Property RefPublication() As String
        Get
            Return mRefPublication
        End Get
        Set(ByVal value As String)
            mRefPublication = value
        End Set
    End Property

    Private mArt1 As String
    Public Property Art1() As String
        Get
            Return mArt1
        End Get
        Set(ByVal value As String)
            mArt1 = value
        End Set
    End Property

    Private mArt2 As String
    Public Property Art2() As String
        Get
            Return mArt2
        End Get
        Set(ByVal value As String)
            mArt2 = value
        End Set
    End Property

    Private mArt3 As String
    Public Property Art3() As String
        Get
            Return mArt3
        End Get
        Set(ByVal value As String)
            mArt3 = value
        End Set
    End Property
    Private mArt4 As String
    Public Property Art4() As String
        Get
            Return mArt4
        End Get
        Set(ByVal value As String)
            mArt4 = value
        End Set
    End Property
    Private mArt5 As String
    Public Property Art5() As String
        Get
            Return mArt5
        End Get
        Set(ByVal value As String)
            mArt5 = value
        End Set
    End Property

    Private mNumDispo As Integer
    Public Property NumDispo() As Integer
        Get
            Return mNumDispo
        End Get
        Set(ByVal value As Integer)
            mNumDispo = value
        End Set
    End Property

    Private mDateMutation As String
    Public Property DateMutation() As String
        Get
            Return mDateMutation
        End Get
        Set(ByVal value As String)
            mDateMutation = value
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

    Private mValeur As Double
    Public Property Valeur() As Double
        Get
            Return mValeur
        End Get
        Set(ByVal value As Double)
            mValeur = value
        End Set
    End Property

    Private mCommune As String
    Public Property Commune() As String
        Get
            Return mCommune
        End Get
        Set(ByVal value As String)
            mCommune = value
        End Set
    End Property

    Private mDepartement As String
    Public Property Departement() As String
        Get
            Return mDepartement
        End Get
        Set(ByVal value As String)
            mDepartement = value
        End Set
    End Property

    Private mInsee As String
    Public Property Insee() As String
        Get
            Return mInsee
        End Get
        Set(ByVal value As String)
            mInsee = value
        End Set
    End Property

    Private mPrefSection As String
    Public Property PrefSection() As String
        Get
            Return mPrefSection
        End Get
        Set(ByVal value As String)
            mPrefSection = value
        End Set
    End Property

    Private mSection As String
    Public Property Sectionc() As String
        Get
            Return mSection
        End Get
        Set(ByVal value As String)
            mSection = value
        End Set
    End Property

    Private mPlan As String
    Public Property Plan() As String
        Get
            Return mPlan
        End Get
        Set(ByVal value As String)
            mPlan = value
        End Set
    End Property

    Private mVolume As Integer
    Public Property Volume() As Integer
        Get
            Return mVolume
        End Get
        Set(ByVal value As Integer)
            mVolume = value
        End Set
    End Property

    Private mLot1 As String
    Public Property Lot1() As String
        Get
            Return mLot1
        End Get
        Set(ByVal value As String)
            mLot1 = value
        End Set
    End Property

    Private mSurf1 As Double
    Public Property Surf1() As Double
        Get
            Return mSurf1
        End Get
        Set(ByVal value As Double)
            mSurf1 = value
        End Set
    End Property

    Private mLot2 As String
    Public Property Lot2() As String
        Get
            Return mLot2
        End Get
        Set(ByVal value As String)
            mLot2 = value
        End Set
    End Property

    Private mSurf2 As Double
    Public Property Surf2() As Double
        Get
            Return mSurf2
        End Get
        Set(ByVal value As Double)
            mSurf2 = value
        End Set
    End Property

    Private mLot3 As String
    Public Property Lot3() As String
        Get
            Return mLot3
        End Get
        Set(ByVal value As String)
            mLot3 = value
        End Set
    End Property

    Private mSurf3 As Double
    Public Property Surf3() As Double
        Get
            Return mSurf3
        End Get
        Set(ByVal value As Double)
            mSurf3 = value
        End Set
    End Property

    Private mLot4 As String
    Public Property Lot4() As String
        Get
            Return mLot4
        End Get
        Set(ByVal value As String)
            mLot4 = value
        End Set
    End Property

    Private mSurf4 As Double
    Public Property Surf4() As Double
        Get
            Return mSurf4
        End Get
        Set(ByVal value As Double)
            mSurf4 = value
        End Set
    End Property

    Private mLot5 As String
    Public Property Lot5() As String
        Get
            Return mLot5
        End Get
        Set(ByVal value As String)
            mLot5 = value
        End Set
    End Property

    Private mSurf5 As Double
    Public Property Surf5() As Double
        Get
            Return mSurf5
        End Get
        Set(ByVal value As Double)
            mSurf5 = value
        End Set
    End Property

    Private mNbLot As Integer
    Public Property NbLot() As Integer
        Get
            Return mNbLot
        End Get
        Set(ByVal value As Integer)
            mNbLot = value
        End Set
    End Property

    Private mTypeLocal As String
    Public Property TypeLocal() As String
        Get
            Return mTypeLocal
        End Get
        Set(ByVal value As String)
            mTypeLocal = value
        End Set
    End Property

    Private mSurfLocal As Double
    Public Property SurfLocal() As Double
        Get
            Return mSurfLocal
        End Get
        Set(ByVal value As Double)
            mSurfLocal = value
        End Set
    End Property

    Private mSurfTerrain As Double
    Public Property SurfTerrain() As Double
        Get
            Return mSurfTerrain
        End Get
        Set(ByVal value As Double)
            mSurfTerrain = value
        End Set
    End Property




    Public Sub Affecte(ligne As String)
        Dim s() As String
        s = ligne.Split("|")
        mCodeCH = s(0)
        mRefPublication = s(1)
        mArt1 = s(2)
        mArt2 = s(3)
        mArt3 = s(4)
        mArt4 = s(5)
        mArt5 = s(6)
        mNumDispo = s(7)
        mDateMutation = s(8)
        mNature = s(9)
        mValeur = s(10)
        mCommune = s(17)
        mDepartement = s(18)
        mInsee = Format(Val(s(19)), "000")
        mPrefSection = s(20)
        If Trim(s(21)).Length = 1 Then
            s(21) = "0" & Trim(s(21))
        End If
        mSection = s(21)
        mPlan = Format(Val(s(22)), "0000")
        mVolume = Val(s(23))
        mLot1 = s(24)
        mSurf1 = Val(s(25))
        mLot2 = s(26)
        mSurf2 = Val(s(27))
        mLot3 = s(28)
        mSurf3 = Val(s(29))
        mLot4 = s(30)
        mSurf4 = Val(s(31))
        mLot5 = s(32)
        mSurf5 = Val(s(33))
        mNbLot = Val(s(34))
        mTypeLocal = s(36)
        mSurfLocal = Val(s(38))
        mSurfTerrain = Val(s(42))
    End Sub

    Public Sub enregistre()
        Dim p1 As New NpgsqlParameter("p1", mCodeCH)
        Dim p2 As New NpgsqlParameter("p2", mRefPublication)
        Dim p3 As New NpgsqlParameter("p3", mArt1)
        Dim p4 As New NpgsqlParameter("p4", mArt2)
        Dim p5 As New NpgsqlParameter("p5", mArt3)
        Dim p6 As New NpgsqlParameter("p6", mArt4)
        Dim p7 As New NpgsqlParameter("p7", mArt5)
        Dim p8 As New NpgsqlParameter("p8", mNumDispo)
        Dim p9 As New NpgsqlParameter("p9", mDateMutation)
        Dim p32 As New NpgsqlParameter("p32", mNature)
        Dim p10 As New NpgsqlParameter("p10", mValeur)
        Dim p11 As New NpgsqlParameter("p11", mCommune)
        Dim p12 As New NpgsqlParameter("p12", mDepartement)
        Dim p13 As New NpgsqlParameter("p13", mInsee)
        Dim p14 As New NpgsqlParameter("p14", mPrefSection)
        Dim p15 As New NpgsqlParameter("p15", mSection)
        Dim p16 As New NpgsqlParameter("p16", mPlan)
        Dim p17 As New NpgsqlParameter("p17", mVolume)
        Dim p18 As New NpgsqlParameter("p18", mLot1)
        Dim p19 As New NpgsqlParameter("p19", mSurf1)
        Dim p20 As New NpgsqlParameter("p20", mLot2)
        Dim p21 As New NpgsqlParameter("p21", mSurf2)
        Dim p22 As New NpgsqlParameter("p22", mLot3)
        Dim p23 As New NpgsqlParameter("p23", mSurf3)
        Dim p24 As New NpgsqlParameter("p24", mLot4)
        Dim p25 As New NpgsqlParameter("p25", mSurf4)
        Dim p26 As New NpgsqlParameter("p26", mLot5)
        Dim p27 As New NpgsqlParameter("p27", mSurf5)
        Dim p28 As New NpgsqlParameter("p28", mNbLot)
        Dim p29 As New NpgsqlParameter("p29", mTypeLocal)
        Dim p30 As New NpgsqlParameter("p30", mSurfLocal)
        Dim p31 As New NpgsqlParameter("p31", mSurfTerrain)

        Dim sql1 As String = "INSERT INTO " & SchemaName & ".tempdvf ( " _
        & "codech, refpublication, art1,art2,art3,art4,art5, numdispo, " _
        & "datemutation,nature, valeur, commune,departement,insee,prefsec,section,plan,volume," _
        & "lot1, surf1,lot2, surf2,lot3, surf3,lot4, surf4,lot5, surf5, nblot, typelocal,surflocal,surfterrain)" _
        & " VALUES (:p1,:p2,:p3,:p4,:p5,:p6,:p7,:p8,:p9,:p32,:p10,:p11,:p12,:p13,:p14,:p15,:p16,:p17,:p18,:p19,:p20,:p21," _
        & ":p22,:p23,:p24,:p25,:p26,:p27,:p28,:p29,:p30,:p31) RETURNING idtempdvf;"

        Dim cmd As New NpgsqlCommand(sql1, CnnGen)
        cmd.Parameters.Clear()

        cmd.Parameters.Add(p1)
        cmd.Parameters.Add(p2)
        cmd.Parameters.Add(p3)
        cmd.Parameters.Add(p4)
        cmd.Parameters.Add(p5)
        cmd.Parameters.Add(p6)
        cmd.Parameters.Add(p7)
        cmd.Parameters.Add(p8)
        cmd.Parameters.Add(p9)
        cmd.Parameters.Add(p10)
        cmd.Parameters.Add(p11)
        cmd.Parameters.Add(p12)
        cmd.Parameters.Add(p13)
        cmd.Parameters.Add(p14)
        cmd.Parameters.Add(p15)
        cmd.Parameters.Add(p16)
        cmd.Parameters.Add(p17)
        cmd.Parameters.Add(p18)
        cmd.Parameters.Add(p19)
        cmd.Parameters.Add(p20)
        cmd.Parameters.Add(p21)
        cmd.Parameters.Add(p22)
        cmd.Parameters.Add(p23)
        cmd.Parameters.Add(p24)
        cmd.Parameters.Add(p25)
        cmd.Parameters.Add(p26)
        cmd.Parameters.Add(p27)
        cmd.Parameters.Add(p28)
        cmd.Parameters.Add(p29)
        cmd.Parameters.Add(p30)
        cmd.Parameters.Add(p31)
        cmd.Parameters.Add(p32)

        m_ID = cmd.ExecuteScalar
        cmd.Parameters.Clear()
        cmd.Dispose()
    End Sub
End Class
