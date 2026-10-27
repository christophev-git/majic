Imports Npgsql

' Intégration de tempart36 et tempexoneration dans art36 et exoneration, rattachées à pev par ptrpev
' (clé étrangère). Jointure sur departement + invariant + numpev :
'  - le département du local vient de commune -> section -> subsection -> parcelle -> locaux ;
'  - pour un local sans parcelle d'assise (ptrparcelle = 0), repli sur templocaux
'    (même idtemplocal ET même invariant, pour ne pas suivre un idtemplocal recyclé).
' numpev est comparé sans les zéros de tête : temppev l'a converti en entier ("001" -> "1").
' Une ligne déjà intégrée n'est pas réinsérée : le bouton peut être relancé sans doublon.
Public Class IntegrationExoneration

    Private Const TablePevDepartement As String = "tmp_pev_departement"

    Public Function Integre() As String
        If CnnGen Is Nothing Then
            If Dialogconnection.ShowDialog <> DialogResult.OK Then Return "Intégration annulée : pas de connexion."
        End If
        If CnnGen.State = ConnectionState.Closed Then CnnGen.Open()
        CnnGen.ChangeDatabase(DatabaseName)

        Dim compteRendu As New System.Text.StringBuilder()

        Using tr As NpgsqlTransaction = CnnGen.BeginTransaction()
            AssurerClePrimairePev()
            CreerTables()
            Dim sansDepartement As Integer = PreparerPevDepartement()

            Dim nb36 As Integer = Execute(SqlInsertionArt36())
            Dim ignores36 As Integer = Scalaire(SqlSansPev("tempart36"))
            Dim nbExo As Integer = Execute(SqlInsertionExoneration())
            Dim ignoresExo As Integer = Scalaire(SqlSansPev("tempexoneration"))

            tr.Commit()

            compteRendu.AppendLine("art36 : " & nb36 & " ligne(s) intégrée(s), " & ignores36 & " sans PEV correspondante.")
            compteRendu.AppendLine("exoneration : " & nbExo & " ligne(s) intégrée(s), " & ignoresExo & " sans PEV correspondante.")
            If sansDepartement > 0 Then
                compteRendu.AppendLine(sansDepartement & " PEV dont le département du local est introuvable (ni parcelle, ni templocaux).")
            End If
        End Using

        Return compteRendu.ToString()
    End Function

    ' La clé étrangère ptrpev exige que pev.idpev soit clé primaire (absent du script d'intégration d'origine).
    Private Sub AssurerClePrimairePev()
        Dim pev As String = GetFullQualifiedTableName("pev")
        Execute("DO $$ BEGIN" _
                & " IF NOT EXISTS (SELECT 1 FROM pg_constraint WHERE conrelid = '" & pev & "'::regclass AND contype = 'p') THEN" _
                & " ALTER TABLE " & pev & " ADD PRIMARY KEY (idpev);" _
                & " END IF; END $$;")
    End Sub

    Private Sub CreerTables()
        Dim pev As String = GetFullQualifiedTableName("pev")

        Execute("CREATE TABLE IF NOT EXISTS " & GetFullQualifiedTableName("art36") & " (idart36 serial PRIMARY KEY," _
                & " ptrpev integer NOT NULL REFERENCES " & pev & " (idpev) ON DELETE CASCADE," _
                & " vlimp70_com integer, vlimpannee_com integer, baseimp_com integer," _
                & " vlimp70_tse integer, vlimpannee_tse integer, baseimp_tse integer," _
                & " vlimp70_gc integer, vlimpannee_gc integer, baseimp_gc integer," _
                & " baseom integer, baseomecretee integer, montanttieom integer);")
        Execute("CREATE INDEX IF NOT EXISTS art36_ptrpev_idx ON " & GetFullQualifiedTableName("art36") & " (ptrpev);")

        Execute("CREATE TABLE IF NOT EXISTS " & GetFullQualifiedTableName("exoneration") & " (idexoneration serial PRIMARY KEY," _
                & " ptrpev integer NOT NULL REFERENCES " & pev & " (idpev) ON DELETE CASCADE," _
                & " anneeimmo varchar(4), cenr varchar(2), numordre varchar(3), collectivite varchar(2), prctexo integer," _
                & " nature varchar(2), annee_dep varchar(4), annee_ret varchar(4)," _
                & " vlexo70 integer, vlexoannee integer, fractionexo70 integer, fractionexoannee integer, rcexoannee integer," _
                & " plafonnement varchar(10));")
        Execute("CREATE INDEX IF NOT EXISTS exoneration_ptrpev_idx ON " & GetFullQualifiedTableName("exoneration") & " (ptrpev);")
    End Sub

    ' Table temporaire (supprimée au commit) : chaque PEV avec le département, l'invariant et le numéro de PEV de son local.
    ' Retourne le nombre de PEV dont le département n'a pas pu être déterminé.
    Private Function PreparerPevDepartement() As Integer
        Dim templocaux As String = GetFullQualifiedTableName("templocaux")
        Dim avecTemplocaux As Boolean = Scalaire("SELECT CASE WHEN to_regclass('" & templocaux & "') IS NULL THEN 0 ELSE 1 END;") = 1

        Dim departement As String = "c.departement"
        Dim repli As String = ""
        If avecTemplocaux Then
            departement = "COALESCE(c.departement, tl.departement)"
            repli = " LEFT JOIN " & templocaux & " tl ON c.departement IS NULL AND tl.idtemplocal = l.idtemplocal AND tl.invariant = l.invariant"
        End If

        Execute("CREATE TEMP TABLE " & TablePevDepartement & " ON COMMIT DROP AS" _
                & " SELECT pv.idpev, " & departement & " AS departement, l.invariant, ltrim(trim(pv.numpev), '0') AS numpev" _
                & " FROM " & GetFullQualifiedTableName("pev") & " pv" _
                & " JOIN " & GetFullQualifiedTableName("locaux") & " l ON l.idlocal = pv.ptrlocal" _
                & " LEFT JOIN " & GetFullQualifiedTableName("parcelle") & " p ON p.idparcelle = l.ptrparcelle" _
                & " LEFT JOIN " & GetFullQualifiedTableName("subsection") & " ss ON ss.idsubsection = p.ptrsubsection" _
                & " LEFT JOIN " & GetFullQualifiedTableName("section") & " s ON s.idsection = ss.ptrsection" _
                & " LEFT JOIN " & GetFullQualifiedTableName("commune") & " c ON c.idcommune = s.ptrcommune" _
                & repli & ";")
        Execute("CREATE INDEX ON " & TablePevDepartement & " (departement, invariant, numpev);")
        Execute("ANALYZE " & TablePevDepartement & ";")

        Return Scalaire("SELECT count(*) FROM " & TablePevDepartement & " WHERE departement IS NULL;")
    End Function

    ' Jointure d'une table temporaire (alias t) avec la PEV de son local (alias d).
    Private Shared Function JointurePev() As String
        Return " JOIN " & TablePevDepartement & " d ON d.departement = t.departement AND d.invariant = t.invariant" _
             & " AND d.numpev = ltrim(t.numpev, '0')"
    End Function

    Private Shared Function SqlInsertionArt36() As String
        Dim art36 As String = GetFullQualifiedTableName("art36")
        Return "INSERT INTO " & art36 & " (ptrpev, vlimp70_com, vlimpannee_com, baseimp_com, vlimp70_tse, vlimpannee_tse, baseimp_tse," _
             & " vlimp70_gc, vlimpannee_gc, baseimp_gc, baseom, baseomecretee, montanttieom)" _
             & " SELECT d.idpev, t.vlimp70_com, t.vlimpannee_com, t.baseimp_com, t.vlimp70_tse, t.vlimpannee_tse, t.baseimp_tse," _
             & " t.vlimp70_gc, t.vlimpannee_gc, t.baseimp_gc, t.baseom, t.baseomecretee, t.montanttieom" _
             & " FROM " & GetFullQualifiedTableName("tempart36") & " t" & JointurePev() _
             & " WHERE NOT EXISTS (SELECT 1 FROM " & art36 & " a WHERE a.ptrpev = d.idpev);"
    End Function

    Private Shared Function SqlInsertionExoneration() As String
        Dim exo As String = GetFullQualifiedTableName("exoneration")
        Return "INSERT INTO " & exo & " (ptrpev, anneeimmo, cenr, numordre, collectivite, prctexo, nature, annee_dep, annee_ret," _
             & " vlexo70, vlexoannee, fractionexo70, fractionexoannee, rcexoannee, plafonnement)" _
             & " SELECT d.idpev, t.anneeimmo, t.cenr, t.numordre, t.collectivite, t.prctexo, t.nature, t.annee_dep, t.annee_ret," _
             & " t.vlexo70, t.vlexoannee, t.fractionexo70, t.fractionexoannee, t.rcexoannee, t.plafonnement" _
             & " FROM " & GetFullQualifiedTableName("tempexoneration") & " t" & JointurePev() _
             & " WHERE NOT EXISTS (SELECT 1 FROM " & exo & " e WHERE e.ptrpev = d.idpev AND e.cenr = t.cenr" _
             & " AND e.numordre = t.numordre AND e.anneeimmo IS NOT DISTINCT FROM t.anneeimmo);"
    End Function

    ' Lignes de la table temporaire sans PEV correspondante (local non intégré dans locaux).
    Private Shared Function SqlSansPev(ByVal tableTemp As String) As String
        Return "SELECT count(*) FROM " & GetFullQualifiedTableName(tableTemp) & " t" _
             & " WHERE NOT EXISTS (SELECT 1 FROM " & TablePevDepartement & " d WHERE d.departement = t.departement" _
             & " AND d.invariant = t.invariant AND d.numpev = ltrim(t.numpev, '0'));"
    End Function

    ' Requêtes ensemblistes potentiellement longues sur un département entier : pas de délai d'expiration.
    Private Shared Function Execute(ByVal sql As String) As Integer
        Using cmd As New NpgsqlCommand(sql, CnnGen)
            cmd.CommandTimeout = 0
            Return cmd.ExecuteNonQuery()
        End Using
    End Function

    Private Shared Function Scalaire(ByVal sql As String) As Integer
        Using cmd As New NpgsqlCommand(sql, CnnGen)
            cmd.CommandTimeout = 0
            Return Convert.ToInt32(cmd.ExecuteScalar())
        End Using
    End Function

End Class
