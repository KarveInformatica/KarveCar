Public Class Connection

#Region "cnxStrings Examples"
    '<dataBases>
    '	<db name="ODBC DBRENT" connectionString="{Driver=Adaptive Server Anywhere 9.0};DSN=DBRENT;" providerName="ODBC" />
    '	<db name="OLEDB DBRENT" connectionString="EngineName=dbrent;DatabaseName=dbrent;Uid=cv;Pwd=1929;Links=tcpip()" providerName="OLEDB" />
    '	<db name="TERST_TEST" connectionString="EngineName=terst_test;DatabaseName=terst_test;Uid=cv;Pwd=1929;Links=tcpip(Host=dentadam.cloudapp.net:2639)" providerName="OLEBD" />
    '</dataBases>
#End Region

    Inherits ConnBase

    Dim db As ConnBase

#Region "New"
    Public Sub New()
        StartDB()
    End Sub

    Public Sub New(ByVal cnxString As String, ByVal providerName As String)
        StartDB(cnxString, providerName)
    End Sub

    Private Sub StartDB(Optional ByVal cnxString As String = "", Optional ByVal providerName As String = "")
        Try
            If cnxString <> "" Then
                VariablesGlobales.cnxString = cnxString
            End If
            If providerName <> "" Then
                VariablesGlobales.providerName = providerName
            End If

            If VariablesGlobales.providerName = "OLEDB" Then
                db = New ASAOleDB(VariablesGlobales.cnxString)
            ElseIf VariablesGlobales.providerName = "ODBC" Then
                db = New ODBC(VariablesGlobales.cnxString)
            Else
                'Debe permanecer comentado durante el desarrollo para no dar por culo
                'Throw New Exception("No se ha establecido un proveedor de datos válido.")
            End If
        Catch ex As Exception
            msgBoxError.Print("Ha ocurrido un error al conectar con las base de datos.", ex.Message)
        End Try
    End Sub
#End Region

    Public Overrides Function TestConnection() As Boolean
        Return db.TestConnection()
    End Function

#Region "Transaction"
    Public Overrides Sub beginTransaction()
        db.beginTransaction()
    End Sub

    Public Overrides Sub commitTransaction()
        db.commitTransaction()
    End Sub

    Public Overrides Sub rollbackTransaction()
        db.rollbackTransaction()
    End Sub
#End Region

    Public Overrides Function fillDts(ByVal mySql As String) As DataSet
        Return db.fillDts(mySql)
    End Function

    Public Overrides Function fillDts(ByVal mySql As String, ByVal tableAlias As ArrayList) As DataSet
        Return db.fillDts(mySql, tableAlias)
    End Function

    Public Overrides Sub updateDts(ByVal mySql As String, ByRef dts As DataSet)
        db.updateDts(mySql, dts)
    End Sub

    Public Overrides Sub callSp(ByVal spName As String, ByVal spParams As Array)
        db.callSp(spName, spParams)
    End Sub

    Public Overrides Sub callSp(ByVal spName As String, ByVal ParamArray spParams() As String)
        db.callSp(spName, spParams)
    End Sub

    Public Overrides Function callSpResults(ByVal spName As String, ByVal spParams As Array) As DataSet
        Return db.callSpResults(spName, spParams)
    End Function

    Public Overrides Function callSpResults(ByVal spName As String, ByVal ParamArray spParams() As String) As DataSet
        Return db.callSpResults(spName, spParams)
    End Function

    Public Overrides Function selectSpResults(ByVal spName As String, ByVal spParams As Array) As DataSet
        Return db.selectSpResults(spName, spParams)
    End Function

    Public Overrides Function selectSpResults(ByVal spName As String, ByVal ParamArray spParams() As String) As DataSet
        Return db.selectSpResults(spName, spParams)
    End Function

    Public Overrides Sub executeDirect(ByVal mySql As String)
        db.executeDirect(mySql)
    End Sub

    Public Overrides Function executeQuery(ByVal mySql As String) As String
        Return db.executeQuery(mySql)
    End Function

    Public Overrides Function ColumnaIgual(Tabla As String, _
                                 Columna As String, _
                                 Where As String) As Boolean
        Return db.ColumnaIgual(Tabla, Columna, Where)
    End Function

#Region "Dummies"
    Protected Overrides Sub cnxOpen()

    End Sub
    Protected Overrides Sub cnxClose()

    End Sub
#End Region
End Class
