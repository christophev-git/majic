' Lecture des zones d'un enregistrement MAJIC à longueur fixe (200 caractères).
' Les positions sont celles du descriptif DGFiP (1ère position = 1), pour pouvoir
' recopier DEB/LGR du dessin d'enregistrement sans conversion.
Module LectureMajic

    Public Const LongueurEnregistrement As Integer = 200

    ' Zone alphanumérique (nature X), sans espaces autour (ex. collectivité " C" -> "C").
    ' Les lignes livrées sont tronquées après la dernière zone servie, d'où le PadRight.
    Public Function Zone(ByVal ligne As String, ByVal debut As Integer, ByVal longueur As Integer) As String
        Return ligne.PadRight(LongueurEnregistrement).Substring(debut - 1, longueur).Trim()
    End Function

    ' Zone numérique (nature 9). Nothing si la zone est à blanc ou non numérique.
    Public Function ZoneEntier(ByVal ligne As String, ByVal debut As Integer, ByVal longueur As Integer) As Integer?
        Dim valeur As Integer
        If Integer.TryParse(Zone(ligne, debut, longueur).Trim(), valeur) Then Return valeur
        Return Nothing
    End Function

    ' Valeur prête pour un NpgsqlParameter : DBNull pour une zone vide.
    Public Function ValeurParametre(ByVal valeur As Integer?) As Object
        If valeur.HasValue Then Return valeur.Value
        Return DBNull.Value
    End Function

End Module
