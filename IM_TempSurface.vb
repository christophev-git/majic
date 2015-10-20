Option Strict Off
Option Explicit On
Imports System.Data
Imports System.Data.OleDb
Imports Npgsql

Public Class IM_TempSurface
    Private mLettre As String
    Private mContenance As String
    Private mCompteCom As String
    Private mRC As String
    Private mRCreval As String
    Private mSerieTarif As String
    Private mGroupe As String
    Private mSousGroupe As String
    Private mGroupeClasse As String
    Private mCultureSpeciale As String
    Private mConstructible As String
    Private mPrefixeParc As String
    Private mSectionParc As String
    Private mPlanParc As String
    Private mNumPDL As String
    Private mNumLot As String


    Private mID_Surface As Integer
    Public Property ID_Surface() As Integer
        Get
            Return mID_Surface
        End Get
        Set(ByVal value As Integer)
            mID_Surface = value
        End Set
    End Property


    Private mPtrTempParcelle As Integer
    Public Property PtrTempParcelle() As Integer
        Get
            Return mPtrTempParcelle
        End Get
        Set(ByVal value As Integer)
            mPtrTempParcelle = value
        End Set
    End Property


    Public Property Lettre() As String
        Get

            Lettre = mLettre

        End Get
        Set(ByVal Value As String)

            mLettre = Value

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


    Public Property RC() As String
        Get

            RC = mRC

        End Get
        Set(ByVal Value As String)

            mRC = Value

        End Set
    End Property


    Public Property RCreval() As String
        Get

            RCreval = mRCreval

        End Get
        Set(ByVal Value As String)

            mRCreval = Value

        End Set
    End Property


    Public Property SerieTarif() As String
        Get

            SerieTarif = mSerieTarif

        End Get
        Set(ByVal Value As String)

            mSerieTarif = Value

        End Set
    End Property


    Public Property Groupe() As String
        Get

            Groupe = mGroupe

        End Get
        Set(ByVal Value As String)

            mGroupe = Value

        End Set
    End Property


    Public Property SousGroupe() As String
        Get

            SousGroupe = mSousGroupe

        End Get
        Set(ByVal Value As String)

            mSousGroupe = Value

        End Set
    End Property


    Public Property GroupeClasse() As String
        Get

            GroupeClasse = mGroupeClasse

        End Get
        Set(ByVal Value As String)

            mGroupeClasse = Value

        End Set
    End Property


    Public Property CultureSpeciale() As String
        Get

            CultureSpeciale = mCultureSpeciale

        End Get
        Set(ByVal Value As String)

            mCultureSpeciale = Value

        End Set
    End Property


    Public Property Constructible() As String
        Get

            Constructible = mConstructible

        End Get
        Set(ByVal Value As String)

            mConstructible = Value

        End Set
    End Property


    Public Property PrefixeParc() As String
        Get

            PrefixeParc = mPrefixeParc

        End Get
        Set(ByVal Value As String)

            mPrefixeParc = Value

        End Set
    End Property


    Public Property SectionParc() As String
        Get

            SectionParc = mSectionParc

        End Get
        Set(ByVal Value As String)

            mSectionParc = Value

        End Set
    End Property


    Public Property PlanParc() As String
        Get

            PlanParc = mPlanParc

        End Get
        Set(ByVal Value As String)

            mPlanParc = Value

        End Set
    End Property


    Public Property NumPDL() As String
        Get

            NumPDL = mNumPDL

        End Get
        Set(ByVal Value As String)

            mNumPDL = Value

        End Set
    End Property


    Public Property NumLot() As String
        Get

            NumLot = mNumLot

        End Get
        Set(ByVal Value As String)

            mNumLot = Value

        End Set
    End Property
    Public Sub New()

    End Sub
    Public Sub New(ByVal ID As Integer)

        Dim sql1 As String = "SELECT * FROM TempSurface WHERE (idtempSurface)=" & ID & ";"

        Dim cmd As New NpgsqlCommand(sql1, cnngen)
        Dim da As New NpgsqlDataAdapter
        da.SelectCommand = cmd
        Dim ds As New DataSet
        da.Fill(ds)
        If ds.Tables.Count <> 0 And ds.Tables(0).Rows.Count <> 0 Then
            Dim row As DataRow = ds.Tables(0).Rows(0)
            Affecte(row)
        End If
        cmd.Dispose()

    End Sub

    Public Sub Affecte(ByVal row As DataRow)
        mID_Surface = row("idtempSurface")
        mPtrTempParcelle = row("ptrtempParcelle")
        mLettre = row("lettre").ToString
        mContenance = row("contenance").ToString
        mCompteCom = row("comptecom").ToString
        mRC = row("rc").ToString
        mRCreval = row("rcreval").ToString
        mSerieTarif = row("serietarif").ToString
        mGroupe = row("groupe").ToString
        mSousGroupe = row("sousgroupe").ToString
        mGroupeClasse = row("groupeclasse").ToString
        mCultureSpeciale = row("culturespeciale").ToString
        mConstructible = row("constructible").ToString
        mPrefixeParc = row("prefixeparc").ToString
        mSectionParc = row("sectionparc").ToString
        mPlanParc = row("planparc").ToString
        mNumPDL = row("numpdl").ToString
        mNumLot = row("numlot").ToString
    End Sub

    Public Sub Affecte(ByVal LIgne As String)
        mLettre = LIgne.Substring(15, 2)
        mContenance = LIgne.Substring(21, 9)
        mCompteCom = LIgne.Substring(30, 6)
        mRC = LIgne.Substring(38, 10)
        mRCreval = LIgne.Substring(48, 10)
        mSerieTarif = LIgne.Substring(58, 1)
        mGroupe = LIgne.Substring(59, 2)
        mSousGroupe = LIgne.Substring(61, 2)
        mGroupeClasse = LIgne.Substring(63, 2)
        mCultureSpeciale = LIgne.Substring(65, 5)
        mConstructible = LIgne.Substring(70, 1)
        If LIgne.Length > 73 Then
            mPrefixeParc = LIgne.Substring(71, 3)
            mSectionParc = LIgne.Substring(74, 2)
            mPlanParc = LIgne.Substring(76, 4)
            mNumPDL = LIgne.Substring(80, 3)
            mNumLot = LIgne.Substring(83, 7)
        End If

    End Sub

    Public Function Enregistre(ByVal PtrParc As Integer) As Integer
        Dim sql1 As String = "INSERT INTO " & SchemaName & ".tempSurface ( ptrtempparcelle, lettre, contenance, comptecom, rc, rcreval, serietarif," _
        & " groupe, sousgroupe, groupeclasse, culturespeciale, constructible"

        If mPrefixeParc <> "" Then
            sql1 = sql1 & ", prefixeparc, sectionparc, planparc, numpdl, numlot ) VALUES (:Ptr,:lett,:cont,:compte,:rc,:rcr,:st,:gr,:sgr,:gc,:cs,:cons,:pref,:sec,:plan,:npdl,:nl);"
        Else
            sql1 = sql1 & ") VALUES (:Ptr,:lett,:cont,:compte,:rc,:rcr,:st,:gr,:sgr,:gc,:cs,:cons);"
        End If


        Dim cmd As New NpgsqlCommand(sql1, cnngen)
        cmd.Parameters.Clear()

        Dim ptr As New NpgsqlParameter("ptr", PtrParc)
        cmd.Parameters.Add(ptr)
        Dim lett As New NpgsqlParameter("lett", mLettre)
        cmd.Parameters.Add(lett)
        Dim cont As New NpgsqlParameter("cont", mContenance)
        cmd.Parameters.Add(cont)
        Dim compte As New NpgsqlParameter("compte", mCompteCom)
        cmd.Parameters.Add(compte)
        Dim rc As New NpgsqlParameter("rc", mRC)
        cmd.Parameters.Add(rc)
        Dim rcr As New NpgsqlParameter("rcr", mRCreval)
        cmd.Parameters.Add(rcr)
        Dim st As New NpgsqlParameter("st", mSerieTarif)
        cmd.Parameters.Add(st)
        Dim gr As New NpgsqlParameter("gr", mGroupe)
        cmd.Parameters.Add(gr)
        Dim sgr As New NpgsqlParameter("sgr", mSousGroupe)
        cmd.Parameters.Add(sgr)
        Dim gc As New NpgsqlParameter("gc", mGroupeClasse)
        cmd.Parameters.Add(gc)
        Dim cs As New NpgsqlParameter("cs", mCultureSpeciale)
        cmd.Parameters.Add(cs)
        Dim cons As New NpgsqlParameter("cons", mConstructible)
        cmd.Parameters.Add(cons)
        Dim pref As New NpgsqlParameter("pref", mPrefixeParc)
        cmd.Parameters.Add(pref)
        Dim sec As New NpgsqlParameter("sec", mSectionParc)
        cmd.Parameters.Add(sec)
        Dim plan As New NpgsqlParameter("plan", mPlanParc)
        cmd.Parameters.Add(plan)
        Dim npdl As New NpgsqlParameter("npdl", mNumPDL)
        cmd.Parameters.Add(npdl)
        Dim nl As New NpgsqlParameter("nl", mNumLot)
        cmd.Parameters.Add(nl)

        Enregistre = cmd.ExecuteNonQuery
        cmd.Parameters.Clear()
        cmd.Dispose()
    End Function
End Class