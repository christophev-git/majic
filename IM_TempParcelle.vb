Option Strict Off
Option Explicit On
Imports System.Data

Imports Npgsql

Public Class IM_TempParcelle

    'Gestion des parcelles non baties majic
    Private mDep As String
    Private mInsee As String
    Private mPrefSec As String
    Private mSection As String
    Private mPlan As String
    Private mCodeEnrg As String
    Private mContenance As String
    Private mCompteCom As String
    Private mDateActe As String
    Private mGPDL As String
    Private mPrimitive As String
    Private mArpente As String
    Private mNFP As String
    Private mRefBati As String
    Private mNumVoie As String
    Private mRivoli As String
    Private mVoieMajic As String

    Private mID_TempParcelle As Integer
    Public Property ID_TempParcelle() As Integer
        Get
            Return mID_TempParcelle
        End Get
        Set(ByVal value As Integer)
            mID_TempParcelle = value
        End Set
    End Property


    Public Property Dep() As String
        Get

            Dep = mDep

        End Get
        Set(ByVal Value As String)

            mDep = Value

        End Set
    End Property


    Public Property Insee() As String
        Get

            Insee = mInsee

        End Get
        Set(ByVal Value As String)

            mInsee = Value

        End Set
    End Property


    Public Property PrefSec() As String
        Get

            PrefSec = mPrefSec

        End Get
        Set(ByVal Value As String)

            mPrefSec = Value

        End Set
    End Property

    Public Property Section() As String
        Get

            Section = mSection

        End Get
        Set(ByVal Value As String)

            mSection = Value

        End Set
    End Property

    Public Property Plan() As String
        Get

            Plan = mPlan

        End Get
        Set(ByVal Value As String)

            mPlan = Value

        End Set
    End Property

    Public Property CodeEnrg() As String
        Get

            CodeEnrg = mCodeEnrg

        End Get
        Set(ByVal Value As String)

            mCodeEnrg = Value

        End Set
    End Property

    Public Property Contenance() As String
        Get

            Contenance = mContenance

        End Get
        Set(ByVal Value As String)

            mContenance = Value

        End Set
    End Property

    Public Property CompteCom() As String
        Get

            CompteCom = mCompteCom

        End Get
        Set(ByVal Value As String)

            mCompteCom = Value

        End Set
    End Property

    Public Property DateActe() As String
        Get

            DateActe = mDateActe

        End Get
        Set(ByVal Value As String)

            mDateActe = Value

        End Set
    End Property

    Public Property GPDL() As String
        Get

            GPDL = mGPDL

        End Get
        Set(ByVal Value As String)

            mGPDL = Value

        End Set
    End Property


    Private mPref2 As String
    Public Property Pref2() As String
        Get
            Return mPref2
        End Get
        Set(ByVal value As String)
            mPref2 = value
        End Set
    End Property


    Private mSection2 As String
    Public Property Section2() As String
        Get
            Return mSection2
        End Get
        Set(ByVal value As String)
            mSection2 = value
        End Set
    End Property


    Private mNumplan2 As String
    Public Property Numplan2() As String
        Get
            Return mNumplan2
        End Get
        Set(ByVal value As String)
            mNumplan2 = value
        End Set
    End Property

    Public Property Primitive() As String
        Get

            Primitive = mPrimitive

        End Get
        Set(ByVal Value As String)

            mPrimitive = Value

        End Set
    End Property

    Public Property Arpente() As String
        Get

            Arpente = mArpente

        End Get
        Set(ByVal Value As String)

            mArpente = Value

        End Set
    End Property

    Public Property NFP() As String
        Get

            NFP = mNFP

        End Get
        Set(ByVal Value As String)

            mNFP = Value

        End Set
    End Property

    Public Property RefBati() As String
        Get

            RefBati = mRefBati

        End Get
        Set(ByVal Value As String)

            mRefBati = Value

        End Set
    End Property

    Public Property NumVoie() As String
        Get

            NumVoie = mNumVoie

        End Get
        Set(ByVal Value As String)

            mNumVoie = Value

        End Set
    End Property

    Public Property Rivoli() As String
        Get

            Rivoli = mRivoli

        End Get
        Set(ByVal Value As String)

            mRivoli = Value

        End Set
    End Property

    Public Property VoieMajic() As String
        Get

            VoieMajic = mVoieMajic

        End Get
        Set(ByVal Value As String)

            mVoieMajic = Value

        End Set
    End Property


    Private mExiste As Boolean
    Public ReadOnly Property Existe() As Boolean
        Get
            Return mExiste
        End Get

    End Property


    Private mFlaganoplan As Boolean
    Public Property Flaganoplan() As Boolean
        Get
            Return mFlaganoplan
        End Get
        Set(ByVal value As Boolean)
            mFlaganoplan = value
        End Set
    End Property

    Private mInseeMere As String
    Public Property InseeMere() As String
        Get
            Return mInseeMere
        End Get
        Set(ByVal value As String)
            mInseeMere = value
        End Set
    End Property


    Private mPrefSecMere As String
    Public Property PrefSecMere() As String
        Get
            Return mPrefSecMere
        End Get
        Set(ByVal value As String)
            mPrefSecMere = value
        End Set
    End Property


    Private mSectionMere As String
    Public Property SectionMere() As String
        Get
            Return mSectionMere
        End Get
        Set(ByVal value As String)
            mSectionMere = value
        End Set
    End Property


    Private mNumPlanMere As String
    Public Property NumPlanMere() As String
        Get
            Return mNumPlanMere
        End Get
        Set(ByVal value As String)
            mNumPlanMere = value
        End Set
    End Property

    Private mTypeFiliation As String
    Public Property TypeFiliation() As String
        Get
            Return mTypeFiliation
        End Get
        Set(ByVal value As String)
            mTypeFiliation = value
        End Set
    End Property


    Private mTraitee As Boolean
    Public Property NewPropertyTraitee() As Boolean
        Get
            Return mTraitee
        End Get
        Set(ByVal value As Boolean)
            mTraitee = value
        End Set
    End Property

    Private mListeSurface As IM_TempSurfaces
    Public Property ListeSurface() As IM_TempSurfaces
        Get
            Return mListeSurface
        End Get
        Set(ByVal value As IM_TempSurfaces)
            mListeSurface = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(ByVal Ligne As String)
        Affecte(Ligne)
    End Sub
    'attention dans tempparcelle tous les champs sont des String de longueur spécifique donc
    'section = " A" et Numplan = "0001" !!!!


    Public Sub New(ByVal insee As String, ByVal nomsection As String, ByVal numplan As String)
        Dim sql1 = "select *" _
             & " from " & SchemaName & ".tempparcelle" _
             & " where (((insee)=:ins) and ((section)=:ns) and ((plan)=:num));"


        Dim cmd As New NpgsqlCommand(sql1, cnngen)
        cmd.Parameters.Clear()

        Dim ins As New NpgsqlParameter("ins", insee)
        Dim ns As New NpgsqlParameter("ns", nomsection)
        Dim num As New NpgsqlParameter("num", numplan)

        cmd.Parameters.Add(ins)
        cmd.Parameters.Add(ns)
        cmd.Parameters.Add(num)

        Dim da As New npgsqldataadapter
        da.selectcommand = cmd
        Dim ds As New dataset
        da.fill(ds)
        If ds.tables.count <> 0 And ds.tables(0).rows.count <> 0 Then
            mexiste = True
            Dim row As datarow = ds.tables(0).rows(0)
            affecte(row)
        Else
            mexiste = False
        End If

        'affecte la liste des surfaces de la parcelle

        mlistesurface = New im_tempsurfaces
        mListeSurface.Populate(mID_TempParcelle)
        cmd.Dispose()
    End Sub

    Public Sub Affecte(ByVal row As DataRow)
        mID_TempParcelle = row("idtempparcelle")
        mDep = row("departement")
        mInsee = row("insee")
        mPrefSec = row("prefsec")
        mSection = row("section")
        mPlan = row("plan")
        mContenance = row("contenance")
        mCompteCom = row("comptecom")
        mDateActe = row("dateacte")
        mGPDL = row("gpdl")
        mPref2 = row("pref2")
        mSection2 = row("section2")
        mNumplan2 = row("numplan2")
        mPrimitive = row("primitive")
        mArpente = row("arpente")
        mNFP = row("nfp")
        mRefBati = row("refbati")
        mNumVoie = row("numvoie")
        mRivoli = row("rivoli")
        mVoieMajic = row("voiemajic")
        mTraitee = row("traitee")
        mInseeMere = row("inseemere")
        mPrefSecMere = row("prefsecmere")
        mSectionMere = row("sectionmere")
        mNumPlanMere = row("numplanmere")
        mTypeFiliation = row("typefiliation")
    End Sub

    Public Sub Affecte(ByVal Ligne As String)
        mDep = Ligne.Substring(0, 2)
        mInsee = Ligne.Substring(3, 3)
        mPrefSec = Ligne.Substring(6, 3)
        mSection = Ligne.Substring(9, 2)
        mPlan = Ligne.Substring(11, 4)
        mContenance = Ligne.Substring(21, 9)
        mCompteCom = Ligne.Substring(31, 6)
        mDateActe = Ligne.Substring(37, 8)
        mGPDL = Ligne.Substring(50, 1)
        mPref2 = Ligne.Substring(51, 3)
        mSection2 = Ligne.Substring(54, 2)
        mNumplan2 = Ligne.Substring(56, 4)
        mPrimitive = Ligne.Substring(64, 4)
        mArpente = Ligne.Substring(68, 1)
        mNFP = Ligne.Substring(69, 1)
        mRefBati = Ligne.Substring(70, 1)
        mNumVoie = Ligne.Substring(85, 4)
        mVoieMajic = Ligne.Substring(90, 5)
        mRivoli = Ligne.Substring(95, 4)



        If Ligne.Length > 165 Then
            mInseeMere = Ligne.Substring(165, 3)
            mPrefSecMere = Ligne.Substring(168, 3)
            mSectionMere = Ligne.Substring(171, 2)
            mNumPlanMere = Ligne.Substring(173, 4)
            mTypeFiliation = Ligne.Substring(177, 1)
        End If

        
        mTraitee = False
    End Sub
    Public Function TemparcTraitee(ByVal tr As Boolean) As Integer
        Dim sql1 As String = "UPDATE " & SchemaName & ".tempparcelle SET traitee = " & tr & " WHERE idtempparcelle=" & mID_TempParcelle & ";"


        Dim cmd As New NpgsqlCommand(sql1, cnngen)
        TemparcTraitee = cmd.ExecuteNonQuery


    End Function
    'enregistre tempparcelle et récupère ID
    Public Function Enregistre(Optional ByVal traitee As Boolean = False) As Integer



        Dim dep As New NpgsqlParameter("dep", mDep)
        Dim ins As New NpgsqlParameter("ins", mInsee)
        Dim prefsec As New NpgsqlParameter("prefsec", mPrefSec)
        Dim sec As New NpgsqlParameter("sec", mSection)
        Dim plan As New NpgsqlParameter("plan", mPlan)
        Dim cont As New NpgsqlParameter("cont", mContenance)
        Dim compte As New NpgsqlParameter("compte", mCompteCom)
        Dim acte As New NpgsqlParameter("acte", mDateActe)
        Dim gpdl As New NpgsqlParameter("gpdl", mGPDL)
        Dim pref2 As New NpgsqlParameter("pref2", mPref2)
        Dim sec2 As New NpgsqlParameter("sec2", mSection2)
        Dim plan2 As New NpgsqlParameter("plan2", mNumplan2)
        Dim prim As New NpgsqlParameter("prim", mPrimitive)
        Dim arp As New NpgsqlParameter("arp", mArpente)
        Dim nfp As New NpgsqlParameter("nfp", mNFP)
        Dim refb As New NpgsqlParameter("refb", mRefBati)
        Dim numv As New NpgsqlParameter("numv", mNumVoie)
        Dim riv As New NpgsqlParameter("riv", mRivoli)
        Dim vmaj As New NpgsqlParameter("vmaj", mVoieMajic)
        Dim trai As New NpgsqlParameter("trai", traitee)
        Dim mere1 As New NpgsqlParameter("mere1", mInseeMere)
        Dim mere2 As New NpgsqlParameter("mere2", mPrefSecMere)
        Dim mere3 As New NpgsqlParameter("mere3", mSectionMere)
        Dim mere4 As New NpgsqlParameter("mere4", mNumPlanMere)
        Dim mere5 As New NpgsqlParameter("mere5", mTypeFiliation)



        Dim sql1 As String = "INSERT INTO " & SchemaName & ".tempparcelle ( departement, insee, prefSec, section, plan, contenance," _
        & " comptecom, dateacte, gpdl, pref2, section2, numplan2, primitive, arpente, nfp, refbati, numvoie, voiemajic, rivoli," _
        & " inseemere, prefsecmere, sectionmere, numplanmere, typefiliation, traitee )" _
        & " VALUES (:dep,:ins,:prefsec,:sec,:plan,:cont,:compte,:acte,:gpdl,:pref2,:sec2,:plan2,:prim,:arp,:nfp,:refb,:numv,:riv,:vmaj,:mere1,:mere2,:mere3,:mere4,:mere5,:trai) RETURNING idtempparcelle;"

        Dim cmd As New NpgsqlCommand(sql1, cnngen)
        cmd.Parameters.Clear()

        cmd.Parameters.Add(dep)
        cmd.Parameters.Add(ins)
        cmd.Parameters.Add(prefsec)
        cmd.Parameters.Add(sec)
        cmd.Parameters.Add(plan)
        cmd.Parameters.Add(cont)
        cmd.Parameters.Add(compte)
        cmd.Parameters.Add(acte)
        cmd.Parameters.Add(gpdl)
        cmd.Parameters.Add(pref2)
        cmd.Parameters.Add(sec2)
        cmd.Parameters.Add(plan2)
        cmd.Parameters.Add(prim)
        cmd.Parameters.Add(arp)
        cmd.Parameters.Add(nfp)
        cmd.Parameters.Add(refb)
        cmd.Parameters.Add(numv)
        cmd.Parameters.Add(riv)
        cmd.Parameters.Add(vmaj)
        cmd.Parameters.Add(trai)
        cmd.Parameters.Add(mere1)
        cmd.Parameters.Add(mere2)
        cmd.Parameters.Add(mere3)
        cmd.Parameters.Add(mere4)
        cmd.Parameters.Add(mere5)

        'Dim da As New NpgsqlDataAdapter
        'da.SelectCommand = cmd
        'Dim ds As New DataSet
        'da.Fill(ds)
        'Dim row As DataRow = ds.Tables(0).Rows(0)
        mID_TempParcelle = cmd.ExecuteScalar
        cmd.Parameters.Clear()
        cmd.Dispose()
    End Function


End Class