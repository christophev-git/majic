Imports System.Data
Imports System.Data.OleDb
Imports Npgsql
Public Class IM_TempLotLocal

    Private mID_TempLotLocal As Integer

    Public Property ID_TempLotLocal() As Integer
        Get
            Return mID_TempLotLocal
        End Get
        Set(ByVal value As Integer)
            mID_TempLotLocal = value
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

    Private mNumPDL As String
    Public Property NumPDL() As String
        Get
            Return mNumPDL
        End Get
        Set(ByVal value As String)
            mNumPDL = value
        End Set
    End Property
    Private mNumlot As String
    Public Property Numlot() As String
        Get
            Return mNumlot
        End Get
        Set(ByVal value As String)
            mNumlot = value
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
    Private mNumerateur As String
    Public Property Numerateur() As String
        Get
            Return mNumerateur
        End Get
        Set(ByVal value As String)
            mNumerateur = value
        End Set
    End Property


    Private mDenominateur As String
    Public Property Denominateur() As String
        Get
            Return mDenominateur
        End Get
        Set(ByVal value As String)
            mDenominateur = value
        End Set
    End Property

    Public Sub New()

    End Sub
    Public Sub New(ByVal ligne As String)
        Affecte(ligne)
    End Sub
    Public Sub Affecte(ByVal ligne As String)
        mDepartement = ligne.Substring(0, 2)
        mInsee = ligne.Substring(3, 3)
        mPrefSection = ligne.Substring(6, 3)
        mSection = ligne.Substring(9, 2)
        mPlan = ligne.Substring(11, 4)
        mNumPDL = ligne.Substring(15, 3)
        mNumlot = ligne.Substring(18, 7)
        mInvariant = ligne.Substring(36, 10)
        mNumerateur = ligne.Substring(46, 7)
        mDenominateur = ligne.Substring(53, 7)
    End Sub
    Public Sub Affecte(ByVal row As DataRow)
        mID_TempLotLocal = row("idtemplotlocal")
        mDepartement = row("departement")
        mInsee = row("insee")
        mPrefSection = row("prefsection")
        mSection = row("section")
        mPlan = row("plan")
        mNumPDL = row("numpdl")
        mNumlot = row("numlot")
        mInvariant = row("invariant")
        mNumerateur = row("numerateur")
        mDenominateur = row("denominateur")
    End Sub
    Public Function Enregistre()
        Dim sql1 As String = "INSERT INTO " & SchemaName & ".templotlocal (departement, insee, prefsection, section, plan," _
        & " numpdl, numlot, invariant, numerateur, denominateur )" _
        & " VALUES (:p1,:p2,:p3,:p4,:p5,:p6,:p7,:p8,:p9,:p10);"

        Dim cmd As New NpgsqlCommand(sql1, cnngen)
        cmd.Parameters.Clear()

        Dim p1 As New NpgsqlParameter("p1", mDepartement)
        cmd.Parameters.Add(p1)
        Dim p2 As New NpgsqlParameter("p2", mInsee)
        cmd.Parameters.Add(p2)
        Dim p3 As New NpgsqlParameter("p3", mPrefSection)
        cmd.Parameters.Add(p3)
        Dim p4 As New NpgsqlParameter("p4", mSection)
        cmd.Parameters.Add(p4)
        Dim p5 As New NpgsqlParameter("p5", mPlan)
        cmd.Parameters.Add(p5)
        Dim p6 As New NpgsqlParameter("p6", mNumPDL)
        cmd.Parameters.Add(p6)
        Dim p7 As New NpgsqlParameter("p7", mNumlot)
        cmd.Parameters.Add(p7)
        Dim p8 As New NpgsqlParameter("p8", mInvariant)
        cmd.Parameters.Add(p8)
        Dim p9 As New NpgsqlParameter("p9", mNumerateur)
        cmd.Parameters.Add(p9)
        Dim p10 As New NpgsqlParameter("p10", mDenominateur)
        cmd.Parameters.Add(p10)

        Enregistre = cmd.ExecuteNonQuery
    End Function


End Class
