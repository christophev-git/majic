Imports Npgsql
Public Class IM_TempArt60
    Private mId_Art60 As Integer
    Public Property Id_Art60() As Integer
        Get
            Return mId_Art60
        End Get
        Set(ByVal value As Integer)
            mId_Art60 = value
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

    Private mNature As String
    Public Property Nature() As String
        Get
            Return mNature
        End Get
        Set(ByVal value As String)
            mNature = value
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
        mNature = ligne.Substring(41, 2)
        mSurface = ligne.Substring(35, 6)

    End Sub
    Public Function Enregistre()

        Dim sql1 As String = "INSERT INTO " & SchemaName & ".tempart60 (ptrtemppev,nature,surface)" _
                             & " VALUES " _
                             & "(:p1,:p2,:p3) RETURNING idtempart60;"
        Dim cmd As New NpgsqlCommand(sql1, CnnGen)
        cmd.Parameters.Clear()

        Dim p1 As New NpgsqlParameter("p1", mPtrTemppev)
        cmd.Parameters.Add(p1)
        Dim p2 As New NpgsqlParameter("p2", mNature)
        cmd.Parameters.Add(p2)
        Dim p3 As New NpgsqlParameter("p3", mSurface)
        cmd.Parameters.Add(p3)

        mId_Art60 = cmd.ExecuteScalar
        Enregistre = mId_Art60
        cmd.Dispose()
    End Function
End Class
