Imports System.Data
Imports System.Data.OleDb
Imports Npgsql
Public Class IM_MajicPDL
    Private mDep As String
    Private mInsee As String
    Private mPrefSec As String
    Private mSection As String
    Private mPlan As String

    Private mNombasecomplet As String
    Public Property Nombasecomplet() As String
        Get
            Return mNombasecomplet
        End Get
        Set(ByVal value As String)
            mNombasecomplet = value
        End Set
    End Property



    Private mID_MajicPDL As Integer
    Public Property ID_MajicPDL() As Integer
        Get
            Return mID_MajicPDL
        End Get
        Set(ByVal value As Integer)
            mID_MajicPDL = value
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

    Private mNumPDL As String
    Public Property NumPDL() As String
        Get
            Return mNumPDL
        End Get
        Set(ByVal value As String)
            mNumPDL = value
        End Set
    End Property

    Private MPDLType As String
    Public Property PDLType() As String
        Get
            Return MPDLType
        End Get
        Set(ByVal value As String)
            MPDLType = value
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

    Public Sub New()

    End Sub
    Public Sub New(ByVal ligne As String)
        Affecte(ligne)
    End Sub
    Public Sub Affecte(ByVal Ligne As String)
        mDep = Ligne.Substring(0, 2)
        mInsee = Ligne.Substring(3, 3)
        mPrefSec = Ligne.Substring(6, 3)
        mSection = Ligne.Substring(9, 2)
        mPlan = Ligne.Substring(11, 4)
        mNumPDL = Ligne.Substring(15, 3)
        MPDLType = Ligne.Substring(28, 3)
        mCompteCom = Ligne.Substring(82, 6)
    End Sub

    Public Function Enregistre() As Integer
        Dim sql1 As String = "INSERT INTO " & SchemaName & ".temppdl ( departement, insee, prefsec, section, plan, numpdl, pdltype, comptecom )" _
       & " VALUES (:dep,:ins,:pref,:sec,:plan,:num,:ty,:compte) RETURNING idtemppdl;"

        'Connect(mNombasecomplet)
        Dim cmd As New NpgsqlCommand(sql1, cnngen)


        Dim dep As New NpgsqlParameter("dep", mDep)
        cmd.Parameters.Add(dep)
        Dim ins As New NpgsqlParameter("ins", mInsee)
        cmd.Parameters.Add(ins)
        Dim pref As New NpgsqlParameter("pref", mPrefSec)
        cmd.Parameters.Add(pref)
        Dim sec As New NpgsqlParameter("sec", mSection)
        cmd.Parameters.Add(sec)
        Dim plan As New NpgsqlParameter("plan", mPlan)
        cmd.Parameters.Add(plan)
        Dim num As New NpgsqlParameter("num", mNumPDL)
        cmd.Parameters.Add(num)
        Dim ty As New NpgsqlParameter("ty", MPDLType)
        cmd.Parameters.Add(ty)
        Dim compte As New NpgsqlParameter("compte", mCompteCom)
        cmd.Parameters.Add(compte)

        'Dim da As New NpgsqlDataAdapter
        'da.SelectCommand = cmd
        'Dim ds As New DataSet
        'da.Fill(ds)
        'Dim row As DataRow = ds.Tables(0).Rows(0)
        mID_MajicPDL = cmd.ExecuteScalar

        cmd.Parameters.Clear()
        cmd.Dispose()

    End Function
End Class
