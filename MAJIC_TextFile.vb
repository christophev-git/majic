Imports Npgsql
Public Class MAJIC_TextFile
    Private cmd As NpgsqlCommand
    Private Da As NpgsqlDataAdapter
    Private ds As DataSet

    Public Sub New()
        cmd = New NpgsqlCommand
        Da = New NpgsqlDataAdapter
    End Sub

    Public Sub CreateTables()
        cmd.Connection = cnngen
        cmd.CommandText = "CREATE TABLE IF NOT EXISTS " & GetFullQualifiedTableName("tempparcelle") & "(idtempparcelle serial," _
        & "departement varchar(2),insee varchar(3),prefsec varchar(3),section varchar(2),plan varchar(4),contenance varchar(9)" _
        & ",comptecom varchar(6),dateacte varchar(8),gpdl varchar(1),pref2 varchar(3),section2 varchar(2),numplan2 varchar(4)" _
        & ",primitive varchar(4),arpente varchar(1),nfp varchar(1),refbati varchar(1),numvoie varchar(4),rivoli varchar(5),voiemajic varchar(5)" _
        & ",inseemere varchar(3),prefsecmere varchar(3),sectionmere varchar(2),numplanmere varchar(4),typefiliation varchar(1),traitee boolean);"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "CREATE TABLE IF NOT EXISTS " & GetFullQualifiedTableName("tempsurface") & " (idtempsurface serial,ptrtempparcelle integer,lettre varchar(2),contenance varchar(9),comptecom varchar(6),rc varchar(10),rcreval varchar(10), serietarif varchar(1), groupe varchar(2),sousgroupe varchar(2), groupeclasse varchar(2),culturespeciale varchar(5),constructible varchar(1), prefixeparc varchar(3), sectionparc varchar(2), planparc varchar(4),numpdl varchar(3), numlot varchar(7));"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "CREATE TABLE IF NOT EXISTS " & GetFullQualifiedTableName("temppdl") & " (idtemppdl serial,departement varchar(2),insee varchar(3),prefsec varchar(3),section varchar(2),plan varchar(4),numpdl varchar(3),pdltype varchar(3),comptecom varchar(6));"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "CREATE TABLE IF NOT EXISTS " & GetFullQualifiedTableName("templot") & "(idtemplot serial,ptrtemppdl integer,numlot varchar(7),naturelot varchar(1),surfacelot varchar(9),numerateur varchar(7),denominateur varchar(7),dateactelot varchar(8),comptecomlot varchar(6));"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "CREATE TABLE IF NOT EXISTS " & GetFullQualifiedTableName("tempproprio") & "(idtempproprio serial,departement varchar(2), insee varchar(3), comptecom varchar(6), numper varchar(6), codedroit varchar(1), codedem varchar(1), destavis varchar(1), physique varchar(1)," _
        & " codephysique varchar(1), codenaturephy varchar(3), codegroupemoral varchar(2), siglemoral varchar(10), siglemajic varchar(7), denomination varchar(60), type3 varchar(1), type4 varchar(1), type5 varchar(1), type6 varchar(1)," _
        & " adr3 varchar(30), adr4 varchar(36), adr5 varchar(30), adr6 varchar(32), codepays varchar(3), depadr varchar(2), adrinsee varchar(3), codemajicadr varchar(5), rivoliadr varchar(4), numvoie varchar(4), repnumVoie varchar(1), qualite varchar(3), nom varchar(30)," _
        & " prenom varchar(15), datenaissance varchar(10), lieuxnaissance varchar(58), complement varchar(3), nomcomplement varchar(30), prenomcomplement varchar(15));"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "CREATE TABLE IF NOT EXISTS " & GetFullQualifiedTableName("templocaux") & "(idtemplocal serial,departement varchar(2), insee varchar(3), invariant varchar(10), prefsection varchar(3), section varchar(2), plan varchar(4)," _
                & " lettre varchar(2), entree varchar(2), niveau varchar(2), numero varchar(5), coderivoli varchar(4), codemajic varchar(5), numvoie varchar(4), indrep varchar(1), libelle varchar(30), clefalpha varchar(1), gpdl varchar(1)," _
                & " serierole varchar(1), comptecom varchar(6), datemutation varchar(8), codeeval varchar(1), typelocal varchar(1), codeconstructionp varchar(1), codenature varchar(2), vl varchar(9), occupation varchar(1)," _
                & " topmutation varchar(1), anneeconstruction varchar(4), nbniveau varchar(2));"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "CREATE TABLE IF NOT EXISTS " & GetFullQualifiedTableName("tempadresse") & " (departement varchar(2), insee varchar(3), identifiant varchar(4), clefrivoli varchar(1), naturevoie varchar(4)," _
                & " libelle  varchar(26), voiepublique varchar(1), datecreation varchar(7), codemajic  varchar(5), typevoie varchar(1), bati  varchar(1));"
        cmd.ExecuteNonQuery()

        cmd.CommandText = "CREATE TABLE IF NOT EXISTS " & GetFullQualifiedTableName("templotlocal") & " (departement varchar(2), insee varchar(3), prefsection varchar(3), section varchar(2), plan varchar(4), " _
        & " numpdl varchar(3), numlot varchar(7), invariant varchar(10), numerateur varchar(7), denominateur varchar(7));"
        cmd.ExecuteNonQuery()

        cmd.CommandText = "CREATE TABLE IF NOT EXISTS " & GetFullQualifiedTableName("temppev") & "(idtemppev serial,ptrlocal integer, " _
        & " numpev varchar(3),  affectation varchar(1),categorie varchar(2),vl70 integer,vlactu integer,exop varchar(2),coefentretien varchar(5),surfpond integer,coefsp varchar(5),coefsg varchar(5));"
        cmd.ExecuteNonQuery()

        cmd.CommandText = "CREATE TABLE IF NOT EXISTS " & GetFullQualifiedTableName("tempadresse") & "(idtempadresse serial,departement varchar(2),insee varchar(3),identifiant varchar(4),clefrivoli varchar(1),naturevoie varchar(4),libelle varchar(26),voiepublique boolean,datecreation varchar(7),codemajic varchar(5));"

        cmd.CommandText = "CREATE TABLE IF NOT EXISTS " & GetFullQualifiedTableName("tempart40") & "(idtempart40 serial,ptrtemppev integer,dependance varchar," _
        & " eau boolean, electricite boolean,escalier boolean, gaz boolean,ascenceur boolean,chauffagecentral boolean,videordure boolean,egout boolean,baignoire integer," _
        & " douche integer, lavabo integer,wc integer, pieceprincipale integer,salleamanger integer,chambre integer,cuisineinf9 integer,cuisinesup9 integer,salledebain integer," _
        & "annexe integer,piece integer,superficie real);"
        cmd.ExecuteNonQuery()

        cmd.CommandText = "CREATE TABLE IF NOT EXISTS " & GetFullQualifiedTableName("tempart50") & "(idtempart50 serial,ptrtemppev integer, " _
        & "surface real);"
        cmd.ExecuteNonQuery()

        cmd.CommandText = "CREATE TABLE IF NOT EXISTS " & GetFullQualifiedTableName("tempart60") & "(idtempart60 serial,ptrtemppev integer, " _
        & "nature varchar(2),surface real);"
        cmd.ExecuteNonQuery()


    End Sub

    Public Sub PopulateTempParcelle(ByVal nomfichier As String)
        If cnngen Is Nothing Then
            If Dialogconnection.ShowDialog = DialogResult.OK Then

            Else
                Exit Sub
            End If
        End If
        cnngen.ChangeDatabase(databasename)
        'cnn.Open()
        CreateTables()
        Dim tempparc As New IM_TempParcelle

        Using sr As New System.IO.StreamReader(nomfichier)
            sr.ReadLine()
            Do While Not sr.EndOfStream
                Dim ligne As String = sr.ReadLine
                If ligne.Length > 20 Then
                    If ligne.Substring(19, 2) = "10" Then
                        tempparc = New IM_TempParcelle(ligne)
                        tempparc.Enregistre()
                    End If

                    If ligne.Substring(19, 2) = "21" Then
                        Dim tempsurf As New IM_TempSurface
                        tempsurf.Affecte(ligne)
                        tempsurf.Enregistre(tempparc.ID_TempParcelle)
                    End If
                    end if


            Loop
        End Using
        cnngen.Close()
    End Sub

    Public Sub PopulateTempPDL(ByVal nomfichier As String)
        If cnngen Is Nothing Then
            If Dialogconnection.ShowDialog = DialogResult.OK Then

            Else
                Exit Sub
            End If
        End If
        CnnGen.Open()
        CnnGen.ChangeDatabase(databasename)

        CreateTables()

        Dim tempPDL As New IM_MajicPDL

        Using SR As New System.IO.StreamReader(nomfichier)
            SR.ReadLine()
            Do While Not SR.EndOfStream
                Dim ligne As String = SR.ReadLine
                If ligne.Length > 26 Then
                    If ligne.Substring(25, 2) = "10" Then
                        tempPDL = New IM_MajicPDL(ligne)
                        tempPDL.Enregistre()
                    End If

                    If ligne.Substring(25, 2) = "30" Then
                        Dim templot As New IM_Temppdl
                        templot.Affecte(ligne)
                        templot.Enregistre(tempPDL.ID_MajicPDL)
                    End If
                End If
            Loop
        End Using

    End Sub

    Public Sub PopulateTempProprio(ByVal nomfichier As String)
        If cnngen Is Nothing Then
            If Dialogconnection.ShowDialog = DialogResult.OK Then

            Else
                Exit Sub
            End If
        End If
        cnngen.ChangeDatabase(databasename)
        'cnn.Open()
        CreateTables()

        Dim tempprop As New IM_TempProprio


        Using SR As New System.IO.StreamReader(nomfichier)
            SR.ReadLine()
            Do While Not SR.EndOfStream
                Dim ligne As String = SR.ReadLine
                If Trim(ligne.Substring(6, 10)) = "" Then
                Else
                    tempprop = New IM_TempProprio(ligne, "")
                    tempprop.Enregistre()
                End If

                


            Loop
        End Using

    End Sub

    Public Sub PopulateTempLocaux(ByVal nomfichier As String)
        If cnngen Is Nothing Then
            If Dialogconnection.ShowDialog = DialogResult.OK Then

            Else
                Exit Sub
            End If
        End If
        cnngen.ChangeDatabase(databasename)
        'cnn.Open()
        CreateTables()
        Dim temploc As New IM_TempLocal
        Dim temppev As New IM_TempPEV
        Dim tempart40 As New IM_TempArt40
        Dim tempart50 As New IM_TempArt50
        Dim tempart60 As New IM_TempArt60

        Using SR As New System.IO.StreamReader(nomfichier)
            Dim ligne As String
            ligne = SR.ReadLine
            Do While Not SR.EndOfStream

                If ligne.Length > 32 Then
                    If ligne.Substring(30, 2) = "00" Then
                        Dim ligne10 As String = SR.ReadLine
                        temploc = New IM_TempLocal
                        temploc.Affecte(ligne, ligne10)
                        temploc.Enregistre()
                    End If
                    ligne = SR.ReadLine()
                    Do While temploc.Invariant = ligne.Substring(6, 10)




                        If ligne.Substring(30, 2) = "21" Then
                            temppev = New IM_TempPEV
                            temppev.affecte(ligne, temploc.ID_TempLocal)
                            temppev.Enregistre()

                        End If

                        If ligne.Substring(30, 2) = "40" Then
                            tempart40 = New IM_TempArt40
                            tempart40.Affecte(ligne, temppev.IdPEV)
                            tempart40.Enregistre()
                        End If

                        If ligne.Substring(30, 2) = "50" Then
                            tempart50 = New IM_TempArt50
                            tempart50.Affecte(ligne, temppev.IdPEV)
                            tempart50.Enregistre()
                        End If

                        If ligne.Substring(30, 2) = "60" Then
                            tempart60 = New IM_TempArt60
                            tempart60.Affecte(ligne, temppev.IdPEV)
                            tempart60.Enregistre()
                        End If


                        ligne = SR.ReadLine
                        If SR.EndOfStream Then Exit Do

                    Loop
                Else
                    ligne = SR.ReadLine
                End If

            Loop
        End Using

    End Sub

    Public Sub PopulateTempAdresse(ByVal nomfichier As String)
        If cnngen Is Nothing Then
            If Dialogconnection.ShowDialog = DialogResult.OK Then

            Else
                Exit Sub
            End If
        End If
        cnngen.ChangeDatabase(databasename)
        'cnn.Open()
        CreateTables()

        Dim tempadr As New IM_TempAdresse
        Using SR As New System.IO.StreamReader(nomfichier)
            'lit l'article commune 
            SR.ReadLine()
            '****************************
            Do While Not SR.EndOfStream
                Dim ligne As String = SR.ReadLine

                If ligne.Length > 88 Then

                    tempadr = New IM_TempAdresse(ligne)

                    tempadr.Enregistre()

                End If

            Loop
        End Using

    End Sub

    Public Sub PopulateTempLotLocal(ByVal nomfichier As String)
        If cnngen Is Nothing Then
            If Dialogconnection.ShowDialog = DialogResult.OK Then

            Else
                Exit Sub
            End If
        End If
        cnngen.ChangeDatabase(databasename)
        'cnn.Open()
        CreateTables()

        Dim templc As New IM_TempLotLocal

        Using SR As New System.IO.StreamReader(nomfichier)
            'lit l'article commune 
            SR.ReadLine()
            '****************************
            Do While Not SR.EndOfStream
                Dim ligne As String = SR.ReadLine
                If Trim(ligne.Substring(6, 10)) = "" Then
                Else

                    templc = New IM_TempLotLocal(ligne)
                    templc.Enregistre()
                End If

            Loop
        End Using
    End Sub
End Class
