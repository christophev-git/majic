Option Explicit On
Imports System.Data
Imports System.Data.OleDb
Imports Npgsql
Public Class IM_Temppdl
    Private mNombasecomplet As String
    Public Property Nombasecomplet() As String
        Get
            Return mNombasecomplet
        End Get
        Set(ByVal value As String)
            mNombasecomplet = value
        End Set
    End Property


    Private mID_TempLot As Integer
    Public Property ID_TempLot() As Integer
        Get
            Return mID_TempLot
        End Get
        Set(ByVal value As Integer)
            mID_TempLot = value
        End Set
    End Property

    Private mPtr_TempPDL As Integer
    Public Property Ptr_TempPDL() As Integer
        Get
            Return mPtr_TempPDL
        End Get
        Set(ByVal value As Integer)
            mPtr_TempPDL = value
        End Set
    End Property


    Private mPDLType As String
    Public Property PDLType() As String
        Get
            Return mPDLtype
        End Get
        Set(ByVal value As String)
            mPDLtype = value
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


    Private mNaturelot As String
    Public Property Naturelot() As String
        Get
            Return mNaturelot
        End Get
        Set(ByVal value As String)
            mNaturelot = value
        End Set
    End Property


    Private mSurfacelot As String
    Public Property Surfacelot() As String
        Get
            Return mSurfacelot
        End Get
        Set(ByVal value As String)
            mSurfacelot = value
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

    Private mDateactelot As String
    Public Property Dateactelot() As String
        Get
            Return mDateactelot
        End Get
        Set(ByVal value As String)
            mDateactelot = value
        End Set
    End Property

    Private mComptecomlot As String
    Public Property CompteComLot() As String
        Get
            Return mCompteComLot
        End Get
        Set(ByVal value As String)
            mComptecomlot = value
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

    Private mExiste As Boolean
    Public ReadOnly Property Existe() As Boolean
        Get
            Return mExiste
        End Get

    End Property


    Public Sub New()

    End Sub


    
    Public Sub New(ByVal IDLot As Integer)
        Dim sql1 As String = "SELECT * FROM TempLot WHERE idtempLot=:id);"


        Dim cmd As New NpgsqlCommand(sql1, cnngen)
        cmd.Parameters.Clear()
        Dim id As New NpgsqlParameter("id", IDLot)
        cmd.Parameters.Add(id)

        Dim da As New NpgsqlDataAdapter
        da.SelectCommand = cmd
        Dim ds As New DataSet
        da.Fill(ds)
        If ds.Tables.Count <> 0 And ds.Tables(0).Rows.Count <> 0 Then
            mExiste = True
            Dim row As DataRow = ds.Tables(0).Rows(0)
            Affecte(row)
        Else
            mExiste = False
        End If

    End Sub
    Public Sub Affecte(ByVal row As DataRow)
        mID_TempLot = row("idtemplot")
        mPtr_TempPDL = row("ptrtemppdl")
        mPDLType = row("pdltype").ToString
        mNumlot = row("numlot").ToString
        mNaturelot = row("naturelot").ToString
        mSurfacelot = row("surfaceLot").ToString
        mNumerateur = row("numerateur").ToString
        mDenominateur = row("denominateur").ToString
        mDateactelot = row("dateactelot").ToString
        mComptecomlot = row("comptecomlot").ToString
        mNumPDL = row("numpdl").ToString

    End Sub
    Public Sub Affecte(ByVal ligne As String)
        mNumlot = ligne.Substring(18, 7)
        mNaturelot = ligne.Substring(27, 1)
        mSurfacelot = ligne.Substring(28, 9)
        mNumerateur = ligne.Substring(37, 7)
        mDenominateur = ligne.Substring(44, 7)
        mDateactelot = ligne.Substring(71, 8)
        mComptecomlot = ligne.Substring(82, 6)
    End Sub

    Public Function Enregistre(ByVal IDpdl As Integer)

        Dim sql1 As String = "INSERT INTO " & SchemaName & ".tempLot ( ptrtemppdl, numlot, naturelot, surfacelot, numerateur, denominateur, dateactelot, comptecomlot) VALUES " _
                & "(:id,:num,:nat,:surf,:nume,:den,:dat,:compte);"
        Dim cmd As New NpgsqlCommand(sql1, cnngen)


        Dim id As New NpgsqlParameter("id", IDpdl)
        cmd.Parameters.Add(id)
        Dim num As New NpgsqlParameter("num", mNumlot)
        cmd.Parameters.Add(num)
        Dim nat As New NpgsqlParameter("nat", mNaturelot)
        cmd.Parameters.Add(nat)
        Dim surf As New NpgsqlParameter("surf", mSurfacelot)
        cmd.Parameters.Add(surf)
        Dim nume As New NpgsqlParameter("nume", mNumerateur)
        cmd.Parameters.Add(nume)
        Dim den As New NpgsqlParameter("den", mDenominateur)
        cmd.Parameters.Add(den)
        Dim dat As New NpgsqlParameter("dat", mDateactelot)
        cmd.Parameters.Add(dat)
        Dim compte As New NpgsqlParameter("compte", mComptecomlot)
        cmd.Parameters.Add(compte)

        Enregistre = cmd.ExecuteNonQuery
        cmd.Parameters.Clear()
        cmd.Dispose()
    End Function
End Class
