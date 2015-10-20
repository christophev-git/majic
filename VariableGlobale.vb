

Module VariableGlobale

    Public PrefixeLot As String = ""
    Public SRID As Integer = 3942    
    Public UserSchemaName As String    
    Public Property DatabaseName() As String
        Get
            Return My.Settings.Nombase
        End Get
        Set(ByVal value As String)
            My.Settings.Nombase = value
        End Set
    End Property

    Public Property SchemaName() As String
        Get
            Return My.Settings.NomSchema
        End Get
        Set(ByVal value As String)
            My.Settings.NomSchema = value
        End Set
    End Property




    Public Function GetConnectionStringFromSettings() As String
        Dim b As New Npgsql.NpgsqlConnectionStringBuilder
        b.Host = My.Settings.Host
        b.Port = My.Settings.PortTcp
        b.UserName = My.Settings.Utilisateur
        b.Database = My.Settings.Nombase        
        Return b.ConnectionString
    End Function


    Private mconnectionStringB As Npgsql.NpgsqlConnectionStringBuilder
    Public Property connectionstringB() As Npgsql.NpgsqlConnectionStringBuilder
        Get
            Return mconnectionStringB
        End Get
        Set(ByVal value As Npgsql.NpgsqlConnectionStringBuilder)
            mconnectionStringB = value
        End Set
    End Property





    Private mCnnGen As Npgsql.NpgsqlConnection
    Public Property CnnGen() As Npgsql.NpgsqlConnection
        Get
            Return mCnnGen
        End Get
        Set(ByVal value As Npgsql.NpgsqlConnection)
            mCnnGen = value
        End Set
    End Property

   

    Function GetUserName() As String
        If TypeOf My.User.CurrentPrincipal Is  _
        Security.Principal.WindowsPrincipal Then
            ' The application is using Windows authentication.
            ' The name format is DOMAIN\USERNAME.
            Dim parts() As String = Split(My.User.Name, "\")
            Dim username As String = parts(1).ToLower()
            Return username
        Else
            ' The application is using custom authentication.
            Return My.User.Name
        End If
    End Function





    Public Function GetFullQualifiedTableName(ByVal table As String)        
        If table.Contains(".") Then
            If table.StartsWith(".") Then
                Throw New ArgumentException("table commence par un point.")
            End If
            Return table
        End If
        If String.IsNullOrEmpty(SchemaName) Then
            Return table
        End If
        Return SchemaName & "." & table
    End Function
End Module

