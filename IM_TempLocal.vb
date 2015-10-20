Imports Npgsql
Public Class IM_TempLocal

    Private mID_Local As Integer
    Public Property ID_TempLocal() As Integer
        Get
            Return mID_Local
        End Get
        Set(ByVal value As Integer)
            mID_Local = value
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


    Private mInvariant As String
    Public Property Invariant() As String
        Get
            Return mInvariant
        End Get
        Set(ByVal value As String)
            mInvariant = value
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

    Public Property Section() As String
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

    Private mLettre As String

    Public Property Lettre() As String
        Get
            Return mLettre
        End Get
        Set(ByVal value As String)
            mLettre = value
        End Set
    End Property

    Private mEntree As String

    Public Property Entree() As String
        Get
            Return mEntree
        End Get
        Set(ByVal value As String)
            mEntree = value
        End Set
    End Property

    Private mNiveau As String

    Public Property Niveau() As String
        Get
            Return mNiveau
        End Get
        Set(ByVal value As String)
            mNiveau = value
        End Set
    End Property

    Private mNumero As String

    Public Property Numero() As String
        Get
            Return mNumero
        End Get
        Set(ByVal value As String)
            mNumero = value
        End Set
    End Property

    Private mCodeRivoli As String

    Public Property CodeRivoli() As String
        Get
            Return mCodeRivoli
        End Get
        Set(ByVal value As String)
            mCodeRivoli = value
        End Set
    End Property

    Private mCodeMajic As String

    Public Property CodeMajic() As String
        Get
            Return mCodeMajic
        End Get
        Set(ByVal value As String)
            mCodeMajic = value
        End Set
    End Property

    Private mNumVoie As String

    Public Property NumVoie() As String
        Get
            Return mNumVoie
        End Get
        Set(ByVal value As String)
            mNumVoie = value
        End Set
    End Property

    Private mIndRep As String

    Public Property IndRep() As String
        Get
            Return mIndRep
        End Get
        Set(ByVal value As String)
            mIndRep = value
        End Set
    End Property

    Private mLibelle As String

    Public Property Libelle() As String
        Get
            Return mLibelle
        End Get
        Set(ByVal value As String)
            mLibelle = value
        End Set
    End Property

    Private mClefAlpha As String

    Public Property ClefAlpha() As String
        Get
            Return mClefAlpha
        End Get
        Set(ByVal value As String)
            mClefAlpha = value
        End Set
    End Property

    Private mGPDL As String

    Public Property GPDL() As String
        Get
            Return mGPDL
        End Get
        Set(ByVal value As String)
            mGPDL = value
        End Set
    End Property

    Private mSerieRole As String

    Public Property SerieRole() As String
        Get
            Return mSerieRole
        End Get
        Set(ByVal value As String)
            mSerieRole = value
        End Set
    End Property

    Private mCompteCom As String

    Public Property CompteCom() As String
        Get
            Return mCompteCom
        End Get
        Set(ByVal value As String)
            mCompteCom = value
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

    Private mCodeEval As String

    Public Property CodeEval() As String
        Get
            Return mCodeEval
        End Get
        Set(ByVal value As String)
            mCodeEval = value
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

    Private mCodeConstructionP As String

    Public Property CodeConstructionP() As String
        Get
            Return mCodeConstructionP
        End Get
        Set(ByVal value As String)
            mCodeConstructionP = value
        End Set
    End Property

    Private mCodeNature As String

    Public Property CodeNature() As String
        Get
            Return mCodeNature
        End Get
        Set(ByVal value As String)
            mCodeNature = value
        End Set
    End Property

    Private mVL As String

    Public Property VL() As String
        Get
            Return mVL
        End Get
        Set(ByVal value As String)
            mVL = value
        End Set
    End Property

    Private mOccupation As String

    Public Property Occupation() As String
        Get
            Return mOccupation
        End Get
        Set(ByVal value As String)
            mOccupation = value
        End Set
    End Property

    Private mTopMutation As String

    Public Property TopMutation() As String
        Get
            Return mTopMutation
        End Get
        Set(ByVal value As String)
            mTopMutation = value
        End Set
    End Property

    Private mAnneeConstruction As String

    Public Property AnneeConstruction() As String
        Get
            Return mAnneeConstruction
        End Get
        Set(ByVal value As String)
            mAnneeConstruction = value
        End Set
    End Property

    Private mNbNiveau As String

    Public Property NbNiveau() As String
        Get
            Return mNbNiveau
        End Get
        Set(ByVal value As String)
            mNbNiveau = value
        End Set
    End Property
    Public Sub New()

    End Sub
    Public Function Enregistre()
        
        Dim sql1 As String = "INSERT INTO " & SchemaName & ".templocaux (departement, insee, invariant, prefsection, section, plan," _
        & " lettre, entree, niveau, numero, coderivoli, codemajic, numvoie, indrep, libelle, clefalpha, gpdl," _
        & " serierole, comptecom, datemutation, codeeval, typelocal, codeconstructionp, codenature, vl, occupation," _
        & " topmutation, anneeconstruction, nbniveau ) VALUES (:p,:p1,:p2,:p3,:p4,:p5,:p6,:p7,:p8,:p9,:p10,:p11,:p12,:p13,:p14,:p15,:p16,:p17,:p18,:p19,:p20,:p21,:p22,:p23,:p24,:p25,:p26,:p27,:p28) RETURNING idtemplocal;"

        Dim cmd As New NpgsqlCommand(sql1, cnngen)
        cmd.Parameters.Clear()

        Dim p As New NpgsqlParameter("p", mDepartement)
        cmd.Parameters.Add(p)
        Dim p1 As New NpgsqlParameter("p1", mInsee)
        cmd.Parameters.Add(p1)
        Dim p2 As New NpgsqlParameter("p2", mInvariant)
        cmd.Parameters.Add(p2)
        Dim p3 As New NpgsqlParameter("p3", mPrefSection)
        cmd.Parameters.Add(p3)
        Dim p4 As New NpgsqlParameter("p4", mSection)
        cmd.Parameters.Add(p4)
        Dim p5 As New NpgsqlParameter("p5", mPlan)
        cmd.Parameters.Add(p5)
        Dim p6 As New NpgsqlParameter("p6", mLettre)
        cmd.Parameters.Add(p6)
        Dim p7 As New NpgsqlParameter("p7", mEntree)
        cmd.Parameters.Add(p7)
        Dim p8 As New NpgsqlParameter("p8", mNiveau)
        cmd.Parameters.Add(p8)
        Dim p9 As New NpgsqlParameter("p9", mNumero)
        cmd.Parameters.Add(p9)
        Dim p10 As New NpgsqlParameter("p10", mCodeRivoli)
        cmd.Parameters.Add(p10)
        Dim p11 As New NpgsqlParameter("p11", mCodeMajic)
        cmd.Parameters.Add(p11)
        Dim p12 As New NpgsqlParameter("p12", mNumVoie)
        cmd.Parameters.Add(p12)
        Dim p13 As New NpgsqlParameter("p13", mIndRep)
        cmd.Parameters.Add(p13)
        Dim p14 As New NpgsqlParameter("p14", mLibelle)
        cmd.Parameters.Add(p14)
        Dim p15 As New NpgsqlParameter("p15", mClefAlpha)
        cmd.Parameters.Add(p15)
        Dim p16 As New NpgsqlParameter("p16", mGPDL)
        cmd.Parameters.Add(p16)
        Dim p17 As New NpgsqlParameter("p17", mSerieRole)
        cmd.Parameters.Add(p17)
        Dim p18 As New NpgsqlParameter("p18", mCompteCom)
        cmd.Parameters.Add(p18)
        Dim p19 As New NpgsqlParameter("p19", mDateMutation)
        cmd.Parameters.Add(p19)
        Dim p20 As New NpgsqlParameter("p20", mCodeEval)
        cmd.Parameters.Add(p20)
        Dim p21 As New NpgsqlParameter("p21", mTypeLocal)
        cmd.Parameters.Add(p21)
        Dim p22 As New NpgsqlParameter("p22", mCodeConstructionP)
        cmd.Parameters.Add(p22)
        Dim p23 As New NpgsqlParameter("p23", mCodeNature)
        cmd.Parameters.Add(p23)
        Dim p24 As New NpgsqlParameter("p24", mVL)
        cmd.Parameters.Add(p24)
        Dim p25 As New NpgsqlParameter("p25", mOccupation)
        cmd.Parameters.Add(p25)
        Dim p26 As New NpgsqlParameter("p26", mTopMutation)
        cmd.Parameters.Add(p26)
        Dim p27 As New NpgsqlParameter("p27", mAnneeConstruction)
        cmd.Parameters.Add(p27)
        Dim p28 As New NpgsqlParameter("p28", mNbNiveau)
        cmd.Parameters.Add(p28)

        mID_Local = cmd.ExecuteScalar
        Enregistre = mID_Local
    End Function
    Public Sub Affecte(ByVal ligne As String, ByVal ligne10 As String)

        ligne = ligne.Replace(Chr(34), "_")
        mDepartement = ligne.Substring(0, 2)
        mInsee = ligne.Substring(3, 3)
        mInvariant = ligne.Substring(6, 10)
        mPrefSection = ligne.Substring(35, 3)
        mSection = ligne.Substring(38, 2)
        mPlan = ligne.Substring(40, 4)
        mLettre = ligne.Substring(45, 2)
        mEntree = ligne.Substring(47, 2)
        mNiveau = ligne.Substring(49, 2)
        mNumero = ligne.Substring(51, 5)
        mCodeRivoli = ligne.Substring(56, 4)
        mCodeMajic = ligne.Substring(61, 5)
        mNumVoie = ligne.Substring(66, 4)
        mIndRep = ligne.Substring(70, 1)
        mLibelle = ligne.Substring(75, 30)
        mClefAlpha = ligne.Substring(105, 1)
        mGPDL = ligne10.Substring(35, 1)
        mSerieRole = ligne10.Substring(36, 1)
        mCompteCom = ligne10.Substring(37, 6)
        mDateMutation = ligne10.Substring(43, 8)
        mCodeEval = ligne10.Substring(57, 1)
        mTypeLocal = ligne10.Substring(59, 1)
        mCodeConstructionP = ligne10.Substring(65, 1)
        mCodeNature = ligne10.Substring(66, 2)
        mVL = ligne10.Substring(68, 9)
        mOccupation = ligne10.Substring(93, 1)
        mTopMutation = ligne10.Substring(107, 1)
        mAnneeConstruction = ligne10.Substring(108, 4)
        mNbNiveau = ligne10.Substring(112, 2)

    End Sub
    Public Sub Affecte(ByVal row As DataRow)
        mID_Local = row("idtemplocal")
        mDepartement = row("departement")
        mInsee = row("insee")
        mInvariant = row("invariant")
        mPrefSection = row("prefsection")
        mSection = row("section")
        mPlan = row("plan")
        mLettre = row("lettre")
        mEntree = row("entree")
        mNiveau = row("niveau")
        mNumero = row("numero")
        mCodeRivoli = row("coderivoli")
        mCodeMajic = row("codemajic")
        mNumVoie = row("numvoie")
        mIndRep = row("indrep")
        mLibelle = row("libelle")
        mClefAlpha = row("clefalpha")
        mGPDL = row("gpdl")
        mSerieRole = row("serierole")
        mCompteCom = row("comptecom")
        mDateMutation = row("datemutation")
        mCodeEval = row("codeeval")
        mTypeLocal = row("typelocal")
        mCodeConstructionP = row("codeconstructionp")
        mCodeNature = row("codenature")
        mVL = row("vl")
        mOccupation = row("occupation")
        mTopMutation = row("topmutation")
        mAnneeConstruction = row("anneeconstruction")
        mNbNiveau = row("nbniveau")
    End Sub


End Class
