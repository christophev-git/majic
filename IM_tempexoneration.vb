Imports Npgsql
Imports NpgsqlTypes

' Enregistrements 30 (exonération sur la base imposable) et 31 (exonération sur la
' base imposée) du fichier bâti : même dessin, distingués par CodeEnregistrement.
Public Class IM_tempexoneration
    Public Property Departement As String
    Public Property Direction As String
    Public Property Insee As String
    Public Property Invariant As String
    Public Property AnneeImmobilisation As String
    Public Property NumPev As String
    Public Property CodeEnregistrement As String
    Public Property NumOrdre As String
    Public Property Collectivite As String
    Public Property Prctexo As Integer?
    Public Property Nature As String
    Public Property AnneeDep As String
    Public Property AnneeRet As String
    Public Property VlExo70 As Integer?
    Public Property VlExoAnnee As Integer?
    Public Property FractionExo70 As Integer?
    Public Property FractionExoAnnee As Integer?
    Public Property RcExoAnnee As Integer?
    Public Property Plafonnement As String

    Public Sub Affecte(ByVal ligne As String)
        Departement = Zone(ligne, 1, 2)            ' CCODEP
        Direction = Zone(ligne, 3, 1)              ' CCODIR
        Insee = Zone(ligne, 4, 3)                  ' CCOCOM
        Invariant = Zone(ligne, 7, 10)             ' INVAR
        AnneeImmobilisation = Zone(ligne, 24, 4)   ' JANBIL (établissements industriels)
        NumPev = Zone(ligne, 28, 3)                ' DNUPEV
        CodeEnregistrement = Zone(ligne, 31, 2)    ' CENR : 30 ou 31
        NumOrdre = Zone(ligne, 33, 3)              ' DNUEXB
        Collectivite = Zone(ligne, 36, 2)          ' CCOLLOC : C, TC, GC
        Prctexo = ZoneEntier(ligne, 38, 5)         ' PEXB 999V99 : 10000 = 100 %
        Nature = Zone(ligne, 43, 2)                ' GNEXTL
        AnneeDep = Zone(ligne, 45, 4)              ' JANDEB
        AnneeRet = Zone(ligne, 49, 4)              ' JANIMP
        VlExo70 = ZoneEntier(ligne, 103, 9)        ' DVLDIF2 (non révisé)
        VlExoAnnee = ZoneEntier(ligne, 113, 9)     ' DVLDIF2A
        FractionExo70 = ZoneEntier(ligne, 123, 9)  ' FCEXB2 (non révisé)
        FractionExoAnnee = ZoneEntier(ligne, 133, 9) ' FCEXBA2
        RcExoAnnee = ZoneEntier(ligne, 143, 9)     ' RCEXBA2
        Plafonnement = Zone(ligne, 173, 10)        ' VALPLAF (non révisé)
    End Sub

    Public Sub Enregistre()

        Dim sql1 As String = "INSERT INTO " & GetFullQualifiedTableName("tempexoneration") _
        & " (departement,direction,insee,invariant,anneeimmo,numpev,cenr,numordre,collectivite,prctexo,nature,annee_dep,annee_ret," _
        & "vlexo70,vlexoannee,fractionexo70,fractionexoannee,rcexoannee,plafonnement)" _
        & " VALUES (:dep,:dir,:insee,:invar,:janbil,:pev,:cenr,:ordre,:coll,:prct,:nature,:deb,:ret,:vl70,:vla,:fc70,:fca,:rca,:plaf)"

        Using cmd As New NpgsqlCommand(sql1, CnnGen)
            cmd.Parameters.AddWithValue("dep", Departement)
            cmd.Parameters.AddWithValue("dir", Direction)
            cmd.Parameters.AddWithValue("insee", Insee)
            cmd.Parameters.AddWithValue("invar", Invariant)
            cmd.Parameters.AddWithValue("janbil", AnneeImmobilisation)
            cmd.Parameters.AddWithValue("pev", NumPev)
            cmd.Parameters.AddWithValue("cenr", CodeEnregistrement)
            cmd.Parameters.AddWithValue("ordre", NumOrdre)
            cmd.Parameters.AddWithValue("coll", Collectivite)
            cmd.Parameters.AddWithValue("prct", NpgsqlDbType.Integer, ValeurParametre(Prctexo))
            cmd.Parameters.AddWithValue("nature", Nature)
            cmd.Parameters.AddWithValue("deb", AnneeDep)
            cmd.Parameters.AddWithValue("ret", AnneeRet)
            cmd.Parameters.AddWithValue("vl70", NpgsqlDbType.Integer, ValeurParametre(VlExo70))
            cmd.Parameters.AddWithValue("vla", NpgsqlDbType.Integer, ValeurParametre(VlExoAnnee))
            cmd.Parameters.AddWithValue("fc70", NpgsqlDbType.Integer, ValeurParametre(FractionExo70))
            cmd.Parameters.AddWithValue("fca", NpgsqlDbType.Integer, ValeurParametre(FractionExoAnnee))
            cmd.Parameters.AddWithValue("rca", NpgsqlDbType.Integer, ValeurParametre(RcExoAnnee))
            cmd.Parameters.AddWithValue("plaf", Plafonnement)
            cmd.ExecuteNonQuery()
        End Using
    End Sub
End Class
