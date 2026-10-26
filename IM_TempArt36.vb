Imports Npgsql
Imports NpgsqlTypes

' Enregistrement 36 du fichier bâti : taxation de la PEV (unique par PEV).
' Positions 36 à 155 : 4 occurrences de 30 caractères (VLBAI, VLBAIA, BIPEVA),
' dans l'ordre commune, (à blanc), TSE, groupement de communes.
Public Class IM_TempArt36
    Public Property Departement As String
    Public Property Insee As String
    Public Property Invariant As String
    Public Property NumPev As String
    Public Property VlImp70Commune As Integer?
    Public Property VlImpAnneeCommune As Integer?
    Public Property BaseImpCommune As Integer?
    Public Property VlImp70Tse As Integer?
    Public Property VlImpAnneeTse As Integer?
    Public Property BaseImpTse As Integer?
    Public Property VlImp70Gc As Integer?
    Public Property VlImpAnneeGc As Integer?
    Public Property BaseImpGc As Integer?
    Public Property BaseOm As Integer?
    Public Property BaseOmEcretee As Integer?
    Public Property MontantTieom As Integer?

    Private Const DebutOccurrences As Integer = 36
    Private Const LongueurOccurrence As Integer = 30

    ' Début de l'occurrence n (1 = commune, 3 = TSE, 4 = groupement de communes).
    Private Shared Function DebutOccurrence(ByVal n As Integer) As Integer
        Return DebutOccurrences + (n - 1) * LongueurOccurrence
    End Function

    Public Sub Affecte(ByVal ligne As String)
        Departement = Zone(ligne, 1, 2)    ' CCODEP
        Insee = Zone(ligne, 4, 3)          ' CCOCOM
        Invariant = Zone(ligne, 7, 10)     ' INVAR
        NumPev = Zone(ligne, 28, 3)        ' DNUPEV

        ' Dans chaque occurrence : VLBAI +0 (non révisé), VLBAIA +10 (non révisé), BIPEVA +20
        Dim d As Integer = DebutOccurrence(1)
        VlImp70Commune = ZoneEntier(ligne, d, 9)
        VlImpAnneeCommune = ZoneEntier(ligne, d + 10, 9)
        BaseImpCommune = ZoneEntier(ligne, d + 20, 9)

        d = DebutOccurrence(3)
        VlImp70Tse = ZoneEntier(ligne, d, 9)
        VlImpAnneeTse = ZoneEntier(ligne, d + 10, 9)
        BaseImpTse = ZoneEntier(ligne, d + 20, 9)

        d = DebutOccurrence(4)
        VlImp70Gc = ZoneEntier(ligne, d, 9)
        VlImpAnneeGc = ZoneEntier(ligne, d + 10, 9)
        BaseImpGc = ZoneEntier(ligne, d + 20, 9)

        BaseOm = ZoneEntier(ligne, 156, 9)          ' BATEOM
        BaseOmEcretee = ZoneEntier(ligne, 166, 9)   ' BAOMEC (non révisé)
        MontantTieom = ZoneEntier(ligne, 175, 6)    ' MVLTIEOMX
    End Sub

    Public Sub Enregistre()

        Dim sql1 As String = "INSERT INTO " & GetFullQualifiedTableName("tempart36") _
        & " (departement,insee,invariant,numpev,vlimp70_com,vlimpannee_com,baseimp_com,vlimp70_tse,vlimpannee_tse,baseimp_tse," _
        & "vlimp70_gc,vlimpannee_gc,baseimp_gc,baseom,baseomecretee,montanttieom)" _
        & " VALUES (:dep,:insee,:invar,:pev,:c1,:c2,:c3,:t1,:t2,:t3,:g1,:g2,:g3,:om,:omec,:tieom)"

        Using cmd As New NpgsqlCommand(sql1, CnnGen)
            cmd.Parameters.AddWithValue("dep", Departement)
            cmd.Parameters.AddWithValue("insee", Insee)
            cmd.Parameters.AddWithValue("invar", Invariant)
            cmd.Parameters.AddWithValue("pev", NumPev)
            cmd.Parameters.AddWithValue("c1", NpgsqlDbType.Integer, ValeurParametre(VlImp70Commune))
            cmd.Parameters.AddWithValue("c2", NpgsqlDbType.Integer, ValeurParametre(VlImpAnneeCommune))
            cmd.Parameters.AddWithValue("c3", NpgsqlDbType.Integer, ValeurParametre(BaseImpCommune))
            cmd.Parameters.AddWithValue("t1", NpgsqlDbType.Integer, ValeurParametre(VlImp70Tse))
            cmd.Parameters.AddWithValue("t2", NpgsqlDbType.Integer, ValeurParametre(VlImpAnneeTse))
            cmd.Parameters.AddWithValue("t3", NpgsqlDbType.Integer, ValeurParametre(BaseImpTse))
            cmd.Parameters.AddWithValue("g1", NpgsqlDbType.Integer, ValeurParametre(VlImp70Gc))
            cmd.Parameters.AddWithValue("g2", NpgsqlDbType.Integer, ValeurParametre(VlImpAnneeGc))
            cmd.Parameters.AddWithValue("g3", NpgsqlDbType.Integer, ValeurParametre(BaseImpGc))
            cmd.Parameters.AddWithValue("om", NpgsqlDbType.Integer, ValeurParametre(BaseOm))
            cmd.Parameters.AddWithValue("omec", NpgsqlDbType.Integer, ValeurParametre(BaseOmEcretee))
            cmd.Parameters.AddWithValue("tieom", NpgsqlDbType.Integer, ValeurParametre(MontantTieom))
            cmd.ExecuteNonQuery()
        End Using
    End Sub
End Class
