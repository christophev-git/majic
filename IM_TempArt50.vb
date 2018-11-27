Imports Npgsql
Public Class IM_TempArt50
    Private mId_Art50 As Integer
    Public Property Id_Art50() As Integer
        Get
            Return mId_Art50
        End Get
        Set(ByVal value As Integer)
            mId_Art50 = value
        End Set
    End Property

    Private mPtrTemppev As Integer
    Public Property PtrTemppev() As Integer
        Get
            Return mPtrTemppev
        End Get
        Set(ByVal value As Integer)
            mPtrTemppev = value
        End Set
    End Property

    Private mSurface As Double
    Public Property Surface() As Double
        Get
            Return mSurface
        End Get
        Set(ByVal value As Double)
            mSurface = value
        End Set
    End Property
    Public Sub Affecte(ByVal ligne As String, ByVal idpev As Integer)

        ligne = ligne.Replace(Chr(34), "_")
        mPtrTemppev = idpev
        mSurface = ligne.Substring(37, 9)

    End Sub
    Public Function Enregistre()


        Dim sql1 As String = "INSERT INTO " & SchemaName & ".tempart50 (ptrtemppev,surface)" _
                             & " VALUES " _
                             & "(:p1,:p2) RETURNING idtempart50;"
        Dim cmd As New NpgsqlCommand(sql1, CnnGen)
        cmd.Parameters.Clear()

        Dim p1 As New NpgsqlParameter("p1", mPtrTemppev)
        cmd.Parameters.Add(p1)
        Dim p2 As New NpgsqlParameter("p2", mSurface)
        cmd.Parameters.Add(p2)

        mId_Art50 = cmd.ExecuteScalar
        Enregistre = mId_Art50
        cmd.Dispose()
    End Function
End Class
