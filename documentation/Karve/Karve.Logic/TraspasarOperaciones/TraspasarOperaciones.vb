Imports Karve.Definiciones

Public MustInherit Class TraspasarOperaciones

#Region "Variables"
    Private _tablasDestino As DefinicionTablas
    Private _tablasOrigen As DefinicionTablas

    Private dtsDestino As DataSet
    Private mySqlDestino As String
    Private dtsOrigen As DataSet
    Private mySqlOrigen As String

    Private _codigoDestino As String
    Private _codigoOrigen As String

    Private tableAlias As New ArrayList()
    Private _evitarCampos As New ArrayList

    Protected db As New ASADB.Connection
#End Region

#Region "Propiedades"

    Public Property DatasetDestino As DataSet
        Get
            Return dtsDestino
        End Get
        Set(value As DataSet)
            dtsDestino = value
        End Set
    End Property

    Public Property DatasetOrigen As DataSet
        Get
            Return dtsOrigen
        End Get
        Set(value As DataSet)
            dtsOrigen = value
        End Set
    End Property

    Protected Property TablasDestino As DefinicionTablas
        Get
            Return _tablasDestino
        End Get
        Set(value As DefinicionTablas)
            _tablasDestino = value
        End Set
    End Property

    Protected Property TablasOrigen As DefinicionTablas
        Get
            Return _tablasOrigen
        End Get
        Set(value As DefinicionTablas)
            _tablasOrigen = value
        End Set
    End Property

    Public Property CodigoDestino As String
        Get
            Return _codigoDestino
        End Get
        Set(value As String)
            _codigoDestino = value
        End Set
    End Property

    Public Property CodigoOrigen As String
        Get
            Return _codigoOrigen
        End Get
        Set(value As String)
            _codigoOrigen = value
        End Set
    End Property

    Protected Property CamposAEvitar As ArrayList
        Get
            Return _evitarCampos
        End Get
        Set(value As ArrayList)
            _evitarCampos = value
        End Set
    End Property

#End Region

    Private Function prepareSql(ByVal codEdit As String, ByRef tablas As DefinicionTablas) As String
        Dim mySql As String
        mySql = ""
        If Not IsNothing(tablas) Then
            tableAlias.Clear()
            For Each table As TablaEdit In tablas.Tablas
                mySql &= "select * from " & table.Tabla & " where " & table.CampoID & " = '" & codEdit & "'" & IIf(table.ExtraWhere <> "", " and " & Replace(table.ExtraWhere, "%codEdit%", codEdit), "") & "; "
                tableAlias.Add(table.TableAlias)
            Next
        End If
        Return mySql
    End Function
    Private Function prepareSqlAgregar(ByRef tablas As DefinicionTablas) As String
        Dim mySql As String
        mySql = ""
        If Not IsNothing(tablas.Tablas) Then
            tableAlias.Clear()
            For Each table As TablaEdit In tablas.Tablas
                mySql &= "select * from " & table.Tabla & " where 0 = 1; "
                tableAlias.Add(table.TableAlias)
            Next
        End If
        Return mySql
    End Function

    Private Function loadDts(ByVal mySql As String) As DataSet
        Dim dts As New DataSet
        Try
            dts = db.fillDts(mySql, tableAlias)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        Return dts
    End Function

    Private Sub LoadDatasets()
        If IsNothing(dtsOrigen) Then
            dtsOrigen = loadDts(prepareSql(_codigoOrigen, _tablasOrigen))
        End If

        If IsNothing(dtsDestino) Then
            If _codigoDestino <> "" Then
                dtsDestino = loadDts(prepareSql(_codigoDestino, _tablasDestino))
            Else
                dtsDestino = loadDts(prepareSqlAgregar(_tablasDestino))
                dtsDestino.EnforceConstraints = False
                For Each table As DataTable In dtsDestino.Tables
                    table.Rows.Add(table.NewRow)
                Next
            End If
        End If
    End Sub

    Public Sub MatchDatasets()
        LoadDatasets()

        For Each tablaDes As TablaEdit In _tablasDestino.Tablas
            For Each tablaOri As TablaEdit In _tablasOrigen.Tablas
                If tablaDes.SufijoABuscar = tablaOri.Sufijo Then
                    MatchDatatables(tablaOri, tablaDes)
                End If
            Next
        Next

        ExtraMatch(dtsOrigen, dtsDestino)
    End Sub

    Protected Sub MatchLineas(ByRef tablaOri As TablaEdit, ByRef tablaDes As TablaEdit)
        MatchDatatables(tablaOri, tablaDes)
    End Sub

    Private Sub MatchDatatables(ByRef tablaOri As TablaEdit, ByRef tablaDes As TablaEdit)
        For Each colDes As DataColumn In dtsDestino.Tables(tablaDes.TableAlias).Columns
            If colDes.ColumnName.Contains(tablaDes.Sufijo) Then
                If Not _evitarCampos.Contains(colDes.ColumnName) Then
                    Try
                        dtsDestino.Tables(tablaDes.TableAlias).Rows(0).Item(colDes.ColumnName) = dtsOrigen.Tables(tablaOri.TableAlias).Rows(0).Item(colDes.ColumnName.Replace(tablaDes.Sufijo, tablaOri.Sufijo))
                    Catch
                    End Try
                End If
            End If
        Next
    End Sub

    Protected MustOverride Sub ExtraMatch(ByRef dtsOrigen As DataSet, ByRef dtsDestino As DataSet)

End Class
