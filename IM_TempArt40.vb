Imports Npgsql
Public Class IM_TempArt40
    Private mId_Art40 As Integer
    Public Property Id_Art40() As Integer
        Get
            Return mId_Art40
        End Get
        Set(ByVal value As Integer)
            mId_Art40 = value
        End Set
    End Property

    Private mPtrTemppev As Integer
    Public Property PtrTemppev() As Integer
        Get
            Return mPtrTemppev
        End Get
        Set(ByVal value As Integer)
            mPtrTemppev = value
        End Set
    End Property
    Private mDependance As String
    Public Property Dependance() As String
        Get
            Return mDependance
        End Get
        Set(ByVal value As String)
            mDependance = value
        End Set
    End Property
    Private mEau As Boolean
    Public Property Eau() As Boolean
        Get
            Return mEau
        End Get
        Set(ByVal value As Boolean)
            mEau = value
        End Set
    End Property

    Private mElectricite As Boolean
    Public Property Electricite() As Boolean
        Get
            Return mElectricite
        End Get
        Set(ByVal value As Boolean)
            mElectricite = value
        End Set
    End Property

    Private mEscalier As Boolean
    Public Property Escalier() As Boolean
        Get
            Return mEscalier
        End Get
        Set(ByVal value As Boolean)
            mEscalier = value
        End Set
    End Property

    Private mGaz As Boolean
    Public Property gaz() As Boolean
        Get
            Return mGaz
        End Get
        Set(ByVal value As Boolean)
            mGaz = value
        End Set
    End Property

    Private mAscenceur As Boolean
    Public Property Ascenceur() As Boolean
        Get
            Return mAscenceur
        End Get
        Set(ByVal value As Boolean)
            mAscenceur = value
        End Set
    End Property

    Private mChauffageCentral As Boolean
    Public Property ChauffageCentral() As Boolean
        Get
            Return mChauffageCentral
        End Get
        Set(ByVal value As Boolean)
            mChauffageCentral = value
        End Set
    End Property

    Private mVideOrdure As Boolean
    Public Property VeideOrdure() As Boolean
        Get
            Return mVideOrdure
        End Get
        Set(ByVal value As Boolean)
            mVideOrdure = value
        End Set
    End Property

    Private mEgout As Boolean
    Public Property Egout() As Boolean
        Get
            Return mEgout
        End Get
        Set(ByVal value As Boolean)
            mEgout = value
        End Set
    End Property

    Private mBaignoire As Integer
    Public Property Baignoire() As Integer
        Get
            Return mBaignoire
        End Get
        Set(ByVal value As Integer)
            mBaignoire = value
        End Set
    End Property

    Private mDouche As Integer
    Public Property Douche() As Integer
        Get
            Return mDouche
        End Get
        Set(ByVal value As Integer)
            mDouche = value
        End Set
    End Property

    Private mLavabo As Integer
    Public Property Lavabo() As Integer
        Get
            Return mLavabo
        End Get
        Set(ByVal value As Integer)
            mLavabo = value
        End Set
    End Property

    Private mWC As Integer
    Public Property WC() As Integer
        Get
            Return mWC
        End Get
        Set(ByVal value As Integer)
            mWC = value
        End Set
    End Property

    Private mPiece_Principal As Integer
    Public Property Piece_Principal() As Integer
        Get
            Return mPiece_Principal
        End Get
        Set(ByVal value As Integer)
            mPiece_Principal = value
        End Set
    End Property

    Private mSalleAManger As Integer
    Public Property SalleAManger() As Integer
        Get
            Return mSalleAManger
        End Get
        Set(ByVal value As Integer)
            mSalleAManger = value
        End Set
    End Property

    Private mChambre As Integer
    Public Property Chambre() As Integer
        Get
            Return mChambre
        End Get
        Set(ByVal value As Integer)
            mChambre = value
        End Set
    End Property

    Private mCuisineInf9 As Integer
    Public Property CuisineInf9() As Integer
        Get
            Return mCuisineInf9
        End Get
        Set(ByVal value As Integer)
            mCuisineInf9 = value
        End Set
    End Property

    Private mCuisineSup9 As Integer
    Public Property CuisineSup9() As Integer
        Get
            Return mCuisineSup9
        End Get
        Set(ByVal value As Integer)
            mCuisineSup9 = value
        End Set
    End Property

    Private mSalleDeBain As Integer
    Public Property SalleDeBain() As Integer
        Get
            Return mSalleDeBain
        End Get
        Set(ByVal value As Integer)
            mSalleDeBain = value
        End Set
    End Property

    Private mAnnexe As Integer
    Public Property Annexe() As Integer
        Get
            Return mAnnexe
        End Get
        Set(ByVal value As Integer)
            mAnnexe = value
        End Set
    End Property
    Private mPiece As Integer
    Public Property Piece() As Integer
        Get
            Return mPiece
        End Get
        Set(ByVal value As Integer)
            mPiece = value
        End Set
    End Property

    Private mSuperficie As Double
    Public Property Superficie() As Double
        Get
            Return mSuperficie
        End Get
        Set(ByVal value As Double)
            mSuperficie = value
        End Set
    End Property

    Private mNiveau As Integer
    Public Property Niveau() As Integer
        Get
            Return mNiveau
        End Get
        Set(ByVal value As Integer)
            mNiveau = value
        End Set
    End Property

    Public Sub Affecte(ByVal ligne As String, ByVal idpev As Integer)

        ligne = ligne.Replace(Chr(34), "_")

        mPtrTemppev = idpev

        mDependance = ligne.Substring(35, 40)

        If ligne.Substring(75, 1) = "O" Then
            mEau = True
        Else
            mEau = False
        End If

        If ligne.Substring(76, 1) = "O" Then
            mElectricite = True
        Else
            mElectricite = False
        End If

        If ligne.Substring(77, 1) = "O" Then
            mEscalier = True
        Else
            mEscalier = False
        End If

        If ligne.Substring(78, 1) = "O" Then
            mGaz = True
        Else
            mGaz = False
        End If
        If ligne.Substring(79, 1) = "O" Then
            mAscenceur = True
        Else
            mAscenceur = False
        End If
        If ligne.Substring(80, 1) = "O" Then
            mChauffageCentral = True
        Else
            mChauffageCentral = False
        End If

        If ligne.Substring(81, 1) = "O" Then
            mVideOrdure = True
        Else
            mVideOrdure = False
        End If
        If ligne.Substring(82, 1) = "O" Then
            mEgout = True
        Else
            mEgout = False
        End If
        mBaignoire = ligne.Substring(83, 2)
        mDouche = ligne.Substring(85, 2)
        mLavabo = ligne.Substring(87, 2)
        mWC = ligne.Substring(89, 2)
        mPiece_Principal = ligne.Substring(94, 2)
        mSalleAManger = ligne.Substring(96, 2)
        mChambre = ligne.Substring(98, 2)
        mCuisineInf9 = ligne.Substring(100, 2)
        mCuisineSup9 = ligne.Substring(102, 2)
        mSalleDeBain = ligne.Substring(104, 2)
        mAnnexe = ligne.Substring(106, 2)
        mPiece = ligne.Substring(108, 2)
        mSuperficie = ligne.Substring(110, 6)

    End Sub

    Public Function Enregistre()

        Dim sql1 As String = "INSERT INTO " & SchemaName & ".tempart40 (ptrtemppev,dependance,eau,electricite,escalier,gaz,ascenceur,chauffagecentral,videordure," _
                             & "baignoire,douche,lavabo,wc,pieceprincipale,salleamanger,chambre,cuisineinf9,cuisinesup9,salledebain,annexe,piece,superficie,egout)" _
                              & " VALUES " _
                              & "(:p1,:q,:p2,:p3,:p4,:p5,:p6,:p7,:p8,:p9,:p10,:p11,:p12,:p13,:p14,:p15,:p16,:p17,:p18,:p19,:p20,:p21,:p22) RETURNING idtempart40;"
        Dim cmd As New NpgsqlCommand(sql1, CnnGen)
        cmd.Parameters.Clear()

        Dim p1 As New NpgsqlParameter("p1", mPtrTemppev)
        cmd.Parameters.Add(p1)

        Dim q As New NpgsqlParameter("q", mDependance)
        cmd.Parameters.Add(q)

        Dim p2 As New NpgsqlParameter("p2", mEau)
        cmd.Parameters.Add(p2)

        Dim p3 As New NpgsqlParameter("p3", mElectricite)
        cmd.Parameters.Add(p3)

        Dim p4 As New NpgsqlParameter("p4", mEscalier)
        cmd.Parameters.Add(p4)

        Dim p5 As New NpgsqlParameter("p5", mGaz)
        cmd.Parameters.Add(p5)

        Dim p6 As New NpgsqlParameter("p6", mAscenceur)
        cmd.Parameters.Add(p6)

        Dim p7 As New NpgsqlParameter("p7", mChauffageCentral)
        cmd.Parameters.Add(p7)

        Dim p8 As New NpgsqlParameter("p8", mVideOrdure)
        cmd.Parameters.Add(p8)

        Dim p9 As New NpgsqlParameter("p9", mBaignoire)
        cmd.Parameters.Add(p9)

        Dim p10 As New NpgsqlParameter("p10", mDouche)
        cmd.Parameters.Add(p10)

        Dim p11 As New NpgsqlParameter("p11", mLavabo)
        cmd.Parameters.Add(p11)

        Dim p12 As New NpgsqlParameter("p12", mWC)
        cmd.Parameters.Add(p12)

        Dim p13 As New NpgsqlParameter("p13", mPiece)
        cmd.Parameters.Add(p13)

        Dim p14 As New NpgsqlParameter("p14", mSalleAManger)
        cmd.Parameters.Add(p14)

        Dim p15 As New NpgsqlParameter("p15", mChambre)
        cmd.Parameters.Add(p15)

        Dim p16 As New NpgsqlParameter("p16", mCuisineInf9)
        cmd.Parameters.Add(p16)

        Dim p17 As New NpgsqlParameter("p17", mCuisineSup9)
        cmd.Parameters.Add(p17)

        Dim p18 As New NpgsqlParameter("p18", mSalleDeBain)
        cmd.Parameters.Add(p18)

        Dim p19 As New NpgsqlParameter("p19", mAnnexe)
        cmd.Parameters.Add(p19)

        Dim p20 As New NpgsqlParameter("p20", mPiece)
        cmd.Parameters.Add(p20)

        Dim p21 As New NpgsqlParameter("p21", mSuperficie)
        cmd.Parameters.Add(p21)

        Dim p22 As New NpgsqlParameter("p22", mEgout)
        cmd.Parameters.Add(p22)

        mId_Art40 = cmd.ExecuteScalar
        Enregistre = mId_Art40
        cmd.Dispose()

    End Function

End Class