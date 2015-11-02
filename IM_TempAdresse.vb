Imports Npgsql
Public Class IM_TempAdresse

    Private mID_TempAdresse As Integer

    Public Property ID_TempAdresse() As Integer
        Get
            Return mID_TempAdresse
        End Get
        Set(ByVal value As Integer)
            mID_TempAdresse = value
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

    Private mIdendifiant As String

    Public Property Idendifiant() As String
        Get
            Return mIdendifiant
        End Get
        Set(ByVal value As String)
            mIdendifiant = value
        End Set
    End Property

    Private mClefRivoli As String

    Public Property ClefRivoli() As String
        Get
            Return mClefRivoli
        End Get
        Set(ByVal value As String)
            mClefRivoli = value
        End Set
    End Property

    Private mNatureVoie As String

    Public Property NatureVoie() As String
        Get
            Return mNatureVoie
        End Get
        Set(ByVal value As String)
            mNatureVoie = value
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

    Private mVoiePublique As String

    Public Property VoiePublique() As String
        Get
            Return mVoiePublique
        End Get
        Set(ByVal value As String)
            mVoiePublique = value
        End Set
    End Property

    Private mDateCreation As String

    Public Property DateCreation() As String
        Get
            Return mDateCreation
        End Get
        Set(ByVal value As String)
            mDateCreation = value
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

    Private mTypeVoie As String

    Public Property TypeVoie() As String
        Get
            Return mTypeVoie
        End Get
        Set(ByVal value As String)
            mTypeVoie = value
        End Set
    End Property

    Private mBati As String

    Public Property Bati() As String
        Get
            Return mBati
        End Get
        Set(ByVal value As String)
            mBati = value
        End Set
    End Property

    Public Sub New()

    End Sub
    Public Sub New(ByVal ligne As String)
        Affecte(ligne)
    End Sub
    Public Sub Affecte(ByVal ligne As String)

        ligne = ligne.Replace(Chr(34), "_")
        mDepartement = ligne.Substring(0, 2)
        mInsee = ligne.Substring(3, 3)
        mIdendifiant = ligne.Substring(6, 4)
        mClefRivoli = ligne.Substring(10, 1)
        mNatureVoie = ligne.Substring(11, 4)
        mLibelle = ligne.Substring(15, 26)
        mVoiePublique = ligne.Substring(48, 1)
        mDateCreation = ligne.Substring(81, 7)
        mCodeMajic = ligne.Substring(103, 5)
        'mTypeVoie = ligne.Substring(108, 1)
        'mBati = ligne.Substring(109, 1)

    End Sub
    Public Sub Affecte(ByVal row As DataRow)


        mDepartement = row("departement")
        mInsee = row("insee")
        mIdendifiant = row("identifiant")
        mClefRivoli = row("clefrivoli")
        mNatureVoie = row("naturevoie")
        mLibelle = row("libelle")
        mVoiePublique = row("voiepublique")
        mDateCreation = row("datecreation")
        mCodeMajic = row("codemajic")
        'mTypeVoie = row("typevoie")
        'mBati = row("bati")

    End Sub
    Public Function Enregistre()
        Dim sql1 As String = "INSERT INTO " & SchemaName & ".TempAdresse ( Departement, Insee, Identifiant, ClefRivoli, NatureVoie," _
        & " Libelle, VoiePublique, DateCreation, CodeMajic) VALUES (:p1,:p2,:p3,:p4,:p5,:p6,:p7,:p8,:p9);"

        Dim cmd As New NpgsqlCommand(sql1, cnngen)
        cmd.Parameters.Clear()

        Dim p1 As New NpgsqlParameter("p1", mDepartement)
        cmd.Parameters.Add(p1)
        Dim p2 As New NpgsqlParameter("p2", mInsee)
        cmd.Parameters.Add(p2)
        Dim p3 As New NpgsqlParameter("p3", mIdendifiant)
        cmd.Parameters.Add(p3)
        Dim p4 As New NpgsqlParameter("p4", mClefRivoli)
        cmd.Parameters.Add(p4)
        Dim p5 As New NpgsqlParameter("p5", mNatureVoie)
        cmd.Parameters.Add(p5)
        Dim p6 As New NpgsqlParameter("p6", mLibelle)
        cmd.Parameters.Add(p6)
        Dim p7 As New NpgsqlParameter("p7", mVoiePublique)
        cmd.Parameters.Add(p7)
        Dim p8 As New NpgsqlParameter("p8", mDateCreation)
        cmd.Parameters.Add(p8)
        Dim p9 As New NpgsqlParameter("p9", mCodeMajic)
        cmd.Parameters.Add(p9)
        'Dim p10 As New NpgsqlParameter("p10", mTypeVoie)
        'cmd.Parameters.Add(p10)
        'Dim p11 As New NpgsqlParameter("p11", mBati)
        'cmd.Parameters.Add(p11)

        Enregistre = cmd.ExecuteNonQuery
    End Function
End Class
