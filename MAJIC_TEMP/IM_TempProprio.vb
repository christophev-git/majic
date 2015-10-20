Imports System.Data
Imports System.Data.OleDb
Imports Npgsql
Public Class IM_TempProprio
    Private mNomBaseComplet As String
    Public Property NombaseComplet() As String
        Get
            Return mNomBaseComplet
        End Get
        Set(ByVal value As String)
            mNomBaseComplet = value
        End Set
    End Property


    Private mID_Proprietaire As Integer
    Public Property ID_Proprietaire() As Integer
        Get
            Return mID_Proprietaire
        End Get
        Set(ByVal value As Integer)
            mID_Proprietaire = value
        End Set
    End Property


    Private mDnumper As String
    Public Property Dnumper() As String
        Get
            Return mDnumper
        End Get
        Set(ByVal value As String)
            mDnumper = value
        End Set
    End Property


    Private mDestavis As String
    Public Property Destavis() As String
        Get
            Return mDestavis
        End Get
        Set(ByVal value As String)
            mDestavis = value
        End Set
    End Property


    Private mPhysique As String
    Public Property Physique() As String
        Get
            Return mPhysique
        End Get
        Set(ByVal value As String)
            mPhysique = value
        End Set
    End Property


    Private mCodephysique As String
    Public Property Codephysique() As String
        Get
            Return mCodephysique
        End Get
        Set(ByVal value As String)
            mCodephysique = value
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

    Private mGroupe As String
    Public Property Groupe() As String
        Get
            Return mGroupe
        End Get
        Set(ByVal value As String)
            mGroupe = value
        End Set
    End Property


    Private mSigle As String
    Public Property Sigle() As String
        Get
            Return mSigle
        End Get
        Set(ByVal value As String)
            mSigle = value
        End Set
    End Property


    Private mSiglemajic As String
    Public Property Siglemajic() As String
        Get
            Return mSiglemajic
        End Get
        Set(ByVal value As String)
            mSiglemajic = value
        End Set
    End Property

    Private mDenomination As String
    Public Property Denomination() As String
        Get
            Return mDenomination
        End Get
        Set(ByVal value As String)
            mDenomination = value
        End Set
    End Property


    Private mType3 As String
    Public Property Type3() As String
        Get
            Return mType3
        End Get
        Set(ByVal value As String)
            mType3 = value
        End Set
    End Property
    Private mType4 As String
    Public Property Type4() As String
        Get
            Return mType4
        End Get
        Set(ByVal value As String)
            mType4 = value
        End Set
    End Property

    Private mType5 As String
    Public Property Type5() As String
        Get
            Return mType5
        End Get
        Set(ByVal value As String)
            mType5 = value
        End Set
    End Property


    Private mType6 As String
    Public Property Type6() As String
        Get
            Return mType6
        End Get
        Set(ByVal value As String)
            mType6 = value
        End Set
    End Property


    Private mAdr3 As String
    Public Property Adr3() As String
        Get
            Return mAdr3
        End Get
        Set(ByVal value As String)
            mAdr3 = value
        End Set
    End Property

    Private mAdr4 As String
    Public Property Adr4() As String
        Get
            Return mAdr4
        End Get
        Set(ByVal value As String)
            mAdr4 = value
        End Set
    End Property

    Private mAdr5 As String
    Public Property Adr5() As String
        Get
            Return mAdr5
        End Get
        Set(ByVal value As String)
            mAdr5 = value
        End Set
    End Property

    Private mAdr6 As String
    Public Property Adr6() As String
        Get
            Return mAdr6
        End Get
        Set(ByVal value As String)
            mAdr6 = value
        End Set
    End Property


    Private mCodepays As String
    Public Property Codepays() As String
        Get
            Return mCodepays
        End Get
        Set(ByVal value As String)
            mCodepays = value
        End Set
    End Property


    Private mDepadr As String
    Public Property Depadr() As String
        Get
            Return mDepadr
        End Get
        Set(ByVal value As String)
            mDepadr = value
        End Set
    End Property

    Private mInseeadr As String
    Public Property Inseeadr() As String
        Get
            Return mInseeadr
        End Get
        Set(ByVal value As String)
            mInseeadr = value
        End Set
    End Property


    Private mQualite As String
    Public Property Qualite() As String
        Get
            Return mQualite
        End Get
        Set(ByVal value As String)
            mQualite = value
        End Set
    End Property


    Private mNom As String
    Public Property Nom() As String
        Get
            Return mNom
        End Get
        Set(ByVal value As String)
            mNom = value
        End Set
    End Property

    Private mPrenom As String
    Public Property Prenom() As String
        Get
            Return mPrenom
        End Get
        Set(ByVal value As String)
            mPrenom = value
        End Set
    End Property


    Private mDatenaissance As String
    Public Property Datenaissance() As String
        Get
            Return mDatenaissance
        End Get
        Set(ByVal value As String)
            mDatenaissance = value
        End Set
    End Property


    Private mLieunaissance As String
    Public Property Lieunaissance() As String
        Get
            Return mLieunaissance
        End Get
        Set(ByVal value As String)
            mLieunaissance = value
        End Set
    End Property


    Private mComplement As String
    Public Property Complement() As String
        Get
            Return mComplement
        End Get
        Set(ByVal value As String)
            mComplement = value
        End Set
    End Property


    Private mNomcomplement As String
    Public Property Nomcomplement() As String
        Get
            Return mNomcomplement
        End Get
        Set(ByVal value As String)
            mNomcomplement = value
        End Set
    End Property


    Private mPrenomcomplement As String
    Public Property Prenomcomplement() As String
        Get
            Return mPrenomcomplement
        End Get
        Set(ByVal value As String)
            mPrenomcomplement = value
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

    Private mCodeDroit As String
    Public Property CodeDroit() As String
        Get
            Return mCodeDroit
        End Get
        Set(ByVal value As String)
            mCodeDroit = value
        End Set
    End Property


    Private mCodeDem As String
    Public Property CodeDem() As String
        Get
            Return mCodeDem
        End Get
        Set(ByVal value As String)
            mCodeDem = value
        End Set
    End Property
    Private mExiste As Boolean
    Public ReadOnly Property Existe() As Boolean
        Get
            Return mExiste
        End Get

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

    Private mCodeMajicAdr As String
    Public Property CodeMajicAdr() As String
        Get
            Return mCodeMajicAdr
        End Get
        Set(ByVal value As String)
            mCodeMajicAdr = value
        End Set
    End Property

    Private mRivoliAdr As String
    Public Property RivoliAdr() As String
        Get
            Return mRivoliAdr
        End Get
        Set(ByVal value As String)
            mRivoliAdr = value
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

    Private mRepNumVoie As String
    Public Property RepNumVoie() As String
        Get
            Return mRepNumVoie
        End Get
        Set(ByVal value As String)
            mRepNumVoie = value
        End Set
    End Property


    Public Sub New()

    End Sub
    Public Sub New(ByVal ligne As String, ByVal l As String)
        Affecte(ligne)
    End Sub
    Public Sub New(ByVal ID As Integer)

        Dim sql1 As String = "SELECT * FROM " & SchemaName & ".tempproprio WHERE idtempproprio)=:p;"

        Dim cmd As New NpgsqlCommand(sql1, cnngen)
        Dim p As New NpgsqlParameter("p", ID)
        cmd.Parameters.Add(p)
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
    Public Sub New(ByVal Dnumper As String)

        Dim sql1 As String = "SELECT * FROM " & SchemaName & ".tempproprio WHERE numper=:p;"

        Dim cmd As New NpgsqlCommand(sql1, cnngen)
        Dim p As New NpgsqlParameter("p", Dnumper)
        cmd.Parameters.Add(p)
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

        mID_Proprietaire = row("idtempproprio")
        mDepartement = row("departement")
        mDnumper = row("numper").ToString
        mDestavis = row("destavis")
        mPhysique = row("physique")
        mCodephysique = row("codephysique")
        mGroupe = row("codegroupemoral")
        mSigle = row("siglemoral").ToString
        mSiglemajic = row("siglemajic").ToString
        mDenomination = row("denomination").ToString
        mType3 = row("type3")
        mType4 = row("type4")
        mType5 = row("type5")
        mType6 = row("type6")
        mAdr3 = row("adr3").ToString
        mAdr4 = row("adr4").ToString
        mAdr5 = row("adr5").ToString
        mAdr6 = row("adr6").ToString
        mCodepays = row("codepays").ToString
        mDepadr = row("depadr").ToString
        mInseeadr = row("adrinsee").ToString
        mQualite = row("qualite").ToString
        mNom = row("nom").ToString
        mPrenom = row("prenom").ToString
        mDatenaissance = row("datenaissance").ToString
        mLieunaissance = row("lieuxnaissance").ToString
        mComplement = row("complement").ToString
        mNomcomplement = row("nomcomplement").ToString
        mPrenomcomplement = row("prenomcomplement").ToString
        mCompteCom = row("comptecom").ToString
        mCodeDroit = row("codedroit").ToString
        mCodeDem = row("codedem").ToString

    End Sub

    Public Sub Affecte(ByVal ligne As String)

        If ligne.Length < 450 Then
            Do While ligne.Length <= 450
                ligne = ligne & " "
            Loop
        End If

        ligne = ligne.Replace(Chr(34), "_")
        mDepartement = ligne.Substring(0, 2)
        mInsee = ligne.Substring(3, 3)
        mCompteCom = ligne.Substring(6, 6)
        mDnumper = ligne.Substring(18, 6)
        mCodeDroit = ligne.Substring(24, 1)
        mCodeDem = ligne.Substring(25, 1)
        mDestavis = ligne.Substring(26, 1)
        mPhysique = ligne.Substring(27, 1)
        mCodephysique = ligne.Substring(28, 1)
        mNature = ligne.Substring(34, 3)
        mGroupe = ligne.Substring(37, 2)
        mSigle = ligne.Substring(39, 10)
        mSiglemajic = ligne.Substring(49, 7)
        mDenomination = ligne.Substring(56, 60)
        mType3 = ligne.Substring(116, 1)
        mType4 = ligne.Substring(117, 1)
        mType5 = ligne.Substring(118, 1)
        mType6 = ligne.Substring(119, 1)
        mAdr3 = ligne.Substring(120, 30)
        mAdr4 = ligne.Substring(150, 36)
        mAdr5 = ligne.Substring(186, 30)
        mAdr6 = ligne.Substring(216, 32)
        mCodepays = ligne.Substring(248, 3)
        mDepadr = ligne.Substring(251, 2)
        mInseeadr = ligne.Substring(254, 3)
        mCodeMajicAdr = ligne.Substring(257, 5)
        mRivoliAdr = ligne.Substring(262, 4)
        mNumVoie = ligne.Substring(266, 4)
        mRepNumVoie = ligne.Substring(270, 1)

        mQualite = ligne.Substring(286, 3)
        mNom = ligne.Substring(289, 30)


        mPrenom = ligne.Substring(319, 15)


        mDatenaissance = ligne.Substring(334, 10)


        mLieunaissance = ligne.Substring(344, 58)


        mComplement = ligne.Substring(402, 3)



        mNomcomplement = ligne.Substring(405, 30)


        mPrenomcomplement = ligne.Substring(435, 15)


    End Sub

    Public Function Enregistre()
        Dim sql1 As String = "INSERT INTO " & SchemaName & ".tempproprio ( departement, insee, comptecom, numper, codedroit, codedem, destavis, physique," _
        & " codephysique, codenaturephy, codegroupemoral, siglemoral, siglemajic, denomination, type3, type4, type5, type6," _
        & " adr3, adr4, adr5, adr6, codepays, depadr, adrinsee, codemajicadr, rivoliadr, numvoie, repnumVoie, qualite, nom," _
        & " prenom, datenaissance, lieuxnaissance, complement, nomcomplement, prenomcomplement ) VALUES " _
        & "(:p1,:p2,:p3,:p4,:p5,:p6,:p7,:p8,:p9,:p10,:p11,:p12,:p13,:p14,:p15,:p16,:p17,:p18,:p19,:p20,:p21,:p22,:p23,:p24,:p25,:p26,:p27,:p28,:p29,:p30,:p31,:p32,:p33,:p34,:p35,:p36,:p37);"

        Dim cmd As New NpgsqlCommand(sql1, cnngen)


        Dim p1 As New NpgsqlParameter("p1", mDepartement)
        cmd.Parameters.Add(p1)
        Dim p2 As New NpgsqlParameter("p2", mInsee)
        cmd.Parameters.Add(p2)
        Dim p3 As New NpgsqlParameter("p3", mCompteCom)
        cmd.Parameters.Add(p3)
        Dim p4 As New NpgsqlParameter("p4", mDnumper)
        cmd.Parameters.Add(p4)
        Dim p5 As New NpgsqlParameter("p5", mCodeDroit)
        cmd.Parameters.Add(p5)
        Dim p6 As New NpgsqlParameter("p6", mCodeDem)
        cmd.Parameters.Add(p6)
        Dim p7 As New NpgsqlParameter("p7", mDestavis)
        cmd.Parameters.Add(p7)
        Dim p8 As New NpgsqlParameter("p8", mPhysique)
        cmd.Parameters.Add(p8)
        Dim p9 As New NpgsqlParameter("p9", mCodephysique)
        cmd.Parameters.Add(p9)
        Dim p10 As New NpgsqlParameter("p10", mNature)
        cmd.Parameters.Add(p10)
        Dim p11 As New NpgsqlParameter("p11", mGroupe)
        cmd.Parameters.Add(p11)
        Dim p12 As New NpgsqlParameter("p12", mSigle)
        cmd.Parameters.Add(p12)
        Dim p13 As New NpgsqlParameter("p13", mSiglemajic)
        cmd.Parameters.Add(p13)
        Dim p14 As New NpgsqlParameter("p14", mDenomination)
        cmd.Parameters.Add(p14)
        Dim p15 As New NpgsqlParameter("p15", mType3)
        cmd.Parameters.Add(p15)
        Dim p16 As New NpgsqlParameter("p16", mType4)
        cmd.Parameters.Add(p16)
        Dim p17 As New NpgsqlParameter("p17", mType5)
        cmd.Parameters.Add(p17)
        Dim p18 As New NpgsqlParameter("p18", mType6)
        cmd.Parameters.Add(p18)
        Dim p19 As New NpgsqlParameter("p19", mAdr3)
        cmd.Parameters.Add(p19)
        Dim p20 As New NpgsqlParameter("p20", mAdr4)
        cmd.Parameters.Add(p20)
        Dim p21 As New NpgsqlParameter("p21", mAdr5)
        cmd.Parameters.Add(p21)
        Dim p22 As New NpgsqlParameter("p22", mAdr6)
        cmd.Parameters.Add(p22)
        Dim p23 As New NpgsqlParameter("p23", mCodepays)
        cmd.Parameters.Add(p23)
        Dim p24 As New NpgsqlParameter("p24", mDepadr)
        cmd.Parameters.Add(p24)
        Dim p25 As New NpgsqlParameter("p25", mInseeadr)
        cmd.Parameters.Add(p25)
        Dim p26 As New NpgsqlParameter("p26", mCodeMajicAdr)
        cmd.Parameters.Add(p26)
        Dim p27 As New NpgsqlParameter("p27", mRivoliAdr)
        cmd.Parameters.Add(p27)
        Dim p28 As New NpgsqlParameter("p28", mNumVoie)
        cmd.Parameters.Add(p28)
        Dim p29 As New NpgsqlParameter("p29", mRepNumVoie)
        cmd.Parameters.Add(p29)
        Dim p30 As New NpgsqlParameter("p30", mQualite)
        cmd.Parameters.Add(p30)
        Dim p31 As New NpgsqlParameter("p31", mNom)
        cmd.Parameters.Add(p31)
        Dim p32 As New NpgsqlParameter("p32", mPrenom)
        cmd.Parameters.Add(p32)
        Dim p33 As New NpgsqlParameter("p33", mDatenaissance)
        cmd.Parameters.Add(p33)
        Dim p34 As New NpgsqlParameter("p34", mLieunaissance)
        cmd.Parameters.Add(p34)
        Dim p35 As New NpgsqlParameter("p35", mComplement)
        cmd.Parameters.Add(p35)
        Dim p36 As New NpgsqlParameter("p36", mNomcomplement)
        cmd.Parameters.Add(p36)
        Dim p37 As New NpgsqlParameter("p37", mPrenomcomplement)
        cmd.Parameters.Add(p37)

        Enregistre = cmd.ExecuteNonQuery
        cmd.Parameters.Clear()
        cmd.Dispose()
    End Function
End Class
