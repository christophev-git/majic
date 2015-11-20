Imports Npgsql
Public Class DVF_TextFile
    Private cmd As NpgsqlCommand
    Private Da As NpgsqlDataAdapter
    Private ds As DataSet

    Public Sub New()
        cmd = New NpgsqlCommand
        Da = New NpgsqlDataAdapter
    End Sub

    Public Sub CreateTables()
        cmd.Connection = cnngen
        cmd.CommandText = "CREATE TABLE IF NOT EXISTS " & GetFullQualifiedTableName("tempdvf") & "(idtempdvf serial," _
        & "codech varchar(7), refpublication varchar(10), art1 varchar(10),art2 varchar(10),art3 varchar(10),art4 varchar(10),art5 varchar(10), numdispo integer, " _
        & "datemutation varchar(10),nature varchar(255), valeur real, commune varchar(255)," _
        & "departement varchar(2),insee varchar(3),prefsec varchar(3),section varchar(2),plan varchar(4),volume integer," _
        & "lot1 varchar(10), surf1 real,lot2 varchar(10), surf2 real,lot3 varchar(10), surf3 real,lot4 varchar(10), surf4 real,lot5 varchar(10), surf5 real, nblot integer, typelocal varchar(255),surflocal real,surfterrain real);"
        cmd.ExecuteNonQuery()
    End Sub

    Public Sub PopulateTempDVF(ByVal nomfichier As String)
        If CnnGen Is Nothing Then
            If Dialogconnection.ShowDialog = DialogResult.OK Then

            Else
                Exit Sub
            End If
        End If
        CnnGen.ChangeDatabase(DatabaseName)
        'cnn.Open()
        CreateTables()

        Dim dvf As New TempDVF

        Using sr As New System.IO.StreamReader(nomfichier)
            sr.ReadLine()
            Do While Not sr.EndOfStream
                Dim ligne As String = sr.ReadLine

                dvf.affecte(ligne)
                dvf.enregistre()

            Loop
        End Using
        CnnGen.Close()

    End Sub
End Class
