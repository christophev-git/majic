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

    Private mSurfacePond As Double
    Public Property SurfacePond() As Double
        Get
            Return mSurfacePond
        End Get
        Set(ByVal value As Double)
            mSurfacePond = value
        End Set
    End Property
    Private mSurfacePrincipale As Integer
    Public Property SurfacePrincipale() As Integer
        Get
            Return mSurfacePrincipale
        End Get
        Set(ByVal value As Integer)
            mSurfacePrincipale = value
        End Set
    End Property
    Private mSurfaceSecondCouverte As Integer
    Public Property SurfaceSecondCouverte() As Integer
        Get
            Return mSurfaceSecondCouverte
        End Get
        Set(ByVal value As Integer)
            mSurfaceSecondCouverte = value
        End Set
    End Property
    Private mSurfaceSecondNonCouv As Integer
    Public Property NewPropertySurfaceSecondNonCouv() As Integer
        Get
            Return mSurfaceSecondNonCouv
        End Get
        Set(ByVal value As Integer)
            mSurfaceSecondNonCouv = value
        End Set
    End Property
    Private mSurfacePKcouvert As Integer
    Public Property SurfacePKcouvert() As Integer
        Get
            Return mSurfacePKcouvert
        End Get
        Set(ByVal value As Integer)
            mSurfacePKcouvert = value
        End Set
    End Property

    Private msurfacePKnonCouvert As Integer
    Public Property SurfacePKnonCouvert() As Integer
        Get
            Return msurfacePKnonCouvert
        End Get
        Set(ByVal value As Integer)
            msurfacePKnonCouvert = value
        End Set
    End Property
    Public Sub Affecte(ByVal ligne As String, ByVal idpev As Integer)

        ligne = ligne.Replace(Chr(34), "_")
        mPtrTemppev = idpev
        mSurfacePond = ligne.Substring(35, 9)
        mSurfacePrincipale = ligne.Substring(44, 9)
        mSurfaceSecondCouverte = ligne.Substring(53, 9)
        mSurfaceSecondNonCouv = ligne.Substring(62, 9)
        mSurfacePKcouvert = ligne.Substring(71, 9)
        msurfacePKnonCouvert = ligne.Substring(80, 9)
    End Sub
    Public Function Enregistre()


        Dim sql1 As String = "INSERT INTO " & SchemaName & ".tempart50 (ptrtemppev,surfacepondere,surfaceprincipale,surfacesecondcouverte,surfacesecondnoncouverte,surfacepkcouvert,surfacepknoncouvert)" _
                             & " VALUES " _
                             & "(:p1,:p2,:p3,:p4,:p5,:p6,:p7) RETURNING idtempart50;"
        Dim cmd As New NpgsqlCommand(sql1, CnnGen)
        cmd.Parameters.Clear()

        Dim p1 As New NpgsqlParameter("p1", mPtrTemppev)
        cmd.Parameters.Add(p1)
        Dim p2 As New NpgsqlParameter("p2", mSurfacePond)
        cmd.Parameters.Add(p2)
        Dim p3 As New NpgsqlParameter("p3", mSurfacePrincipale)
        cmd.Parameters.Add(p3)
        Dim p4 As New NpgsqlParameter("p4", mSurfaceSecondCouverte)
        cmd.Parameters.Add(p4)
        Dim p5 As New NpgsqlParameter("p5", mSurfaceSecondNonCouv)
        cmd.Parameters.Add(p5)
        Dim p6 As New NpgsqlParameter("p6", mSurfacePKcouvert)
        cmd.Parameters.Add(p6)
        Dim p7 As New NpgsqlParameter("p7", msurfacePKnonCouvert)
        cmd.Parameters.Add(p7)
        mId_Art50 = cmd.ExecuteScalar
        Enregistre = mId_Art50
        cmd.Dispose()
    End Function
End Class
