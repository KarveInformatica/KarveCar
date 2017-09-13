Imports System.Text
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Windows.Forms.Design
Imports Telerik.WinControls.UI
Imports Telerik.WinControls.UI.Localization
Imports VariablesGlobales.Modulo_VariablesGlobales
Imports Telerik.WinControls
Imports System.Drawing

Public Class DataGridDefinicion

#Region "Variables"
    Dim _sSQL As String
    Private _TablaEdit As DataGridTable
    Dim _Tablas As New DataGridTables
    Dim _Columnas As New DataGridColumns
    Dim _columnasGrupos As New DataGridColumnGroups
    Dim _Clausulas As New DataGridRules
    Dim _Ordenes As New DataGridOrdenColumnas
    Dim _GridEditable As Boolean
    Dim _Grid As DataGrid
    Dim _iPaginado As Integer
    Dim db As ASADB.Connection
    Dim dts As New DataSet
    Const MarcarName As String = "MARCAR_GRID"
    Protected sWhere As String
#End Region

#Region "Propiedades"

    Shadows Property DBConnection As ASADB.Connection
        Get
            Return db
        End Get
        Set(value As ASADB.Connection)
            db = value
        End Set
    End Property

    Public ReadOnly Property NombreColMarcar As String
        Get
            Return MarcarName
        End Get
    End Property

    Public Property EnforceConstrains As Boolean
        Get
            Return dts.EnforceConstraints
        End Get
        Set(value As Boolean)
            dts.EnforceConstraints = value
        End Set
    End Property

    Public Property Editable As Boolean
        Get
            Return _GridEditable
        End Get
        Set(value As Boolean)
            _GridEditable = value
        End Set
    End Property

    Public Property NRegPaginado As Integer
        Get
            Return _iPaginado
        End Get
        Set(value As Integer)
            _iPaginado = value
        End Set
    End Property

    Public Property TablasQuery As DataGridTables
        Get
            Return _Tablas
        End Get
        Set(value As DataGridTables)
            _Tablas = value
        End Set
    End Property

    Public Property Columnas As DataGridColumns
        Get
            Return _Columnas
        End Get
        Set(value As DataGridColumns)
            _Columnas = value
        End Set
    End Property

    Property TablaEdit As DataGridTable
        Get
            Return _TablaEdit
        End Get
        Set(value As DataGridTable)
            _TablaEdit = value
        End Set
    End Property

    Public Property Clausulas As DataGridRules
        Get
            Return _Clausulas
        End Get
        Set(value As DataGridRules)
            _Clausulas = value
        End Set
    End Property

    Public Property Ordenes As DataGridOrdenColumnas
        Get
            Return _Ordenes
        End Get
        Set(value As DataGridOrdenColumnas)
            _Ordenes = value
        End Set
    End Property

    Public Property GruposColumnas As DataGridColumnGroups
        Get
            Return _columnasGrupos
        End Get
        Set(value As DataGridColumnGroups)
            _columnasGrupos = value
        End Set
    End Property

#End Region

    Public Sub LoadGrid(ByRef Grid As DataGrid)
        _Grid = Grid
        _sSQL = ConstruyeSQL()
        clearGrid()
        ConstruyeCols()
        DataSource()
        'Construye Criterios Filtros 
        GridEditable()
    End Sub

    Public Sub LoadCons(ByRef Grid As DataGrid, Optional bMerge As Boolean = False)
        '_Grid = Grid
        _sSQL = ConstruyeSQL()
        DataSource(bMerge)
    End Sub

    Public Sub guardar()
        Try
            Dim saveSQL = ConstruyeSQLGuardar()
            Dim saveDTS As New DataSet
            Dim deleteCols As New ArrayList
            _Grid.EndEdit()

            Dim columns_extract As String = ""

            saveDTS = dts.Copy
            For Each col As Object In _Columnas.ToArray()
                saveDTS.Tables(0).Columns(col.AliasCampo).ColumnName = col.Campo

                If col.Tabla <> _TablaEdit.AliasTabla Then
                    columns_extract &= col.Campo & " "
                End If
            Next
            For Each col As DataColumn In saveDTS.Tables(0).Columns
                If InStr(columns_extract, col.ColumnName, CompareMethod.Text) > 0 Then
                    deleteCols.Add(col)
                End If
            Next

            For Each col In deleteCols
                saveDTS.Tables(0).Columns.Remove(col)
            Next

            db.updateDts(saveSQL, saveDTS)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DataSource(Optional bMerge As Boolean = False)
        Dim dtsc As New DataSet
        Dim TBL As New DataGridTable
        Dim sAlias As String = ""
        TBL = _Tablas.ToArray.Item(0)
        If TBL.AliasTabla <> "" Then sAlias = TBL.AliasTabla & "."
        Dim sPks As String = DameListPkTabla(TBL.Table, TBL.AliasTabla)
        Try
            If _sSQL <> "" Then
                If bMerge Then
                    If sPks <> "" Then dtsc = dts.Copy()
                    dts = db.fillDts(_sSQL)
                    dts.Merge(dtsc)
                Else : dts = db.fillDts(_sSQL)
                End If
                If _Grid.MarcarFilas Then dts.Tables(0).Columns(MarcarName).ReadOnly = False
                _Grid.DataSource = dts.Tables(0)
            End If
        Catch
        End Try
    End Sub

    Private Sub ConstruyeCols()
        _Grid.AutoGenerateColumns = False
        If _Grid.MarcarFilas Then _Grid.Columns.Add(Marcar)
        For Each col In _Columnas.ToArray
            _Grid.Columns.Add(col)
            DefineColumnaEspecial(col)
        Next
        'grupos aqui
        If _columnasGrupos.ColumnGroups.Count > 0 Then
            _Grid.ViewDefinition = _columnasGrupos
        End If
    End Sub

    Private Function Marcar() As DataGridCheckBoxColumn

        Dim col As DataGridCheckBoxColumn
        col = New DataGridCheckBoxColumn
        col.HeaderText = "Marcar"
        col.AliasCampo = MarcarName
        col.Name = MarcarName
        col.Width = 80
        col.AllowFiltering = False
        col.ReadOnly = False
        col.AllowHide = False
        col.AllowReorder = False
        col.AllowResize = False
        Return col

    End Function

    Private Sub clearGrid()
        Try
            _Grid.Columns.Clear()
            _Grid.DataSource = Nothing
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DefineColumnaEspecial(col As Object)
        If TypeOf col Is DataGridDateColumn Then
            CType(col, DataGridDateColumn).Format = DateTimePickerFormat.Custom
            CType(col, DataGridDateColumn).FormatString = "{0:dd/MM/yyyy}"
            _Grid.Columns(col.name).Width = 130
            '_Grid.Columns(col.name).Format = Windows.Forms.DateTimePickerFormat.Custom
            '_Grid.Columns(col.name).CustomFormat = "dd/MM/yyyy"
            _Grid.Columns(col.name).AllowResize = False
        End If
    End Sub

    Private Sub GridEditable()
        _Grid.AllowAddNewRow = _GridEditable
        _Grid.AllowEditRow = _GridEditable
        _Grid.AllowDeleteRow = _GridEditable
    End Sub

    Private Function ConstruyeSQL() As String

        Dim sCols As String = ColumnasGridSQL()
        Dim sSQL As String = BeginSQL(_Tablas, "", sCols)
        Dim sOrder As String = _Ordenes.DameOrder
        If _GridEditable = False Then sOrder = DameOrderPrincipal(sOrder)
        sWhere = _Clausulas.DameWhere
        If sWhere <> "" Then sSQL &= vbNewLine & sWhere
        If sOrder <> "" Then sSQL &= vbNewLine & sOrder
        Return sSQL
    End Function

    Public Function ConstruyeSQL(idReg As Integer, sPk As String) As String
        Dim sCols As String = " SELECT TOP 1 START AT " & idReg & " " & sPk
        Dim sSQL As String = BeginSQL(_Tablas, "", sCols)
        Dim sOrder As String = _Ordenes.DameOrder
        If _GridEditable = False Then sOrder = DameOrderPrincipal(sOrder)
        sWhere = _Clausulas.DameWhere
        If sWhere <> "" Then sSQL &= vbNewLine & sWhere
        If sOrder <> "" Then sSQL &= vbNewLine & sOrder
        Return sSQL
    End Function

    Public Function ConstruyeSQLDesplaza(sPk As String, Optional sPkCriterio As String = " ASC ") As String
        Dim sOrder As String = _Ordenes.DameOrder
        Dim sCols As String = ""
        If _GridEditable = False Then sOrder = DameOrderPrincipal(sOrder)
        If sOrder <> "" Then
            sCols = " SELECT ROW_NUMBER() OVER (" & sOrder & ") X, " & sPk & " VALOR "
        End If
        Dim sSQL As String = BeginSQL(_Tablas, "", sCols)
        sWhere = _Clausulas.DameWhere
        If sWhere <> "" Then sSQL &= vbNewLine & sWhere
        Return sSQL
    End Function

    Private Function DameOrderPrincipal(sOrder As String) As String
        Dim TBL As New DataGridTable
        Dim sAlias As String = ""
        TBL = _Tablas.ToArray.Item(0)
        If TBL.AliasTabla <> "" Then sAlias = TBL.AliasTabla & "."
        Dim sOrdPpal As String = DameListPkTabla(TBL.Table, sAlias)
        If sOrdPpal <> "" Then
            If sOrder = "" Then
                sOrder = " ORDER BY " & sOrdPpal & " ASC "
            Else : sOrder = sOrder & ", " & sOrdPpal & " ASC "
            End If
        End If
        Return sOrder
    End Function

    Private Function DameListPkTabla(sTabla As String, sAlias As String) As String
        Dim _sSQL As String = " SELECT LIST(DISTINCT ISNULL(" & VD.setApostrofa(sAlias) & " + COLUMN_NAME, ''), ', ' ORDER BY COLUMN_ID) AS PK " & vbNewLine & _
                              " FROM SYSCOLUMN SC " & vbNewLine & _
                              " INNER JOIN SYSTABLE ST ON ST.TABLE_ID = SC.TABLE_ID " & vbNewLine & _
                              " WHERE TABLE_NAME = " & VD.setApostrofa(sTabla) & vbNewLine & _
                              " AND PKEY = 'Y' "
        Dim sPks As String = db.executeQuery(_sSQL)
        Return sPks
    End Function

    Private Function ConstruyeSQLGuardar() As String
        Dim sCols As String = ColumnasGridSQL(_TablaEdit)
        Dim dgtTmp As New DataGridTables

        'sWhere = _Clausulas.DameWhere

        dgtTmp.Add(_TablaEdit)
        Dim sSQL As String = BeginSQL(dgtTmp, "", sCols)
        If sWhere <> "" Then sSQL &= sWhere
        Return sSQL
    End Function

    Private Function BeginSQL(DGTS As DataGridTables, sSQL As String, sCols As String) As String
        Dim DGT As DataGridTable
        Dim sBegin As String = ""
        Dim iRg As Integer
        Dim sColsX As String = ""
        Dim DGTa As ArrayList = DGTS.ToArray
        '*==========================================================================
        For iRg = 0 To DGTa.Count - 1
            With DGTS.Item(iRg)
                DGT = New DataGridTable()
                DGT = DGTa.Item(iRg)

                If DGT.TablasVirtual.Count <> 0 Then
                    sColsX = ColumnasVirtualSQL(DGT)
                    sBegin = sBegin & DGT.JoinText
                    sBegin = sBegin & "    (   " & vbNewLine & _
                            BeginSQL(DGT.TablasVirtual, sBegin, sColsX) & vbNewLine & _
                                      "    ) " & DGT.AliasTabla & " " & DGT.Criterio

                Else
                    sBegin = sBegin & DGT.JoinText
                    sBegin = sBegin & " " & DGT.Table & " " & DGT.AliasTabla & " " & DGT.Criterio
                End If
            End With
        Next
        sSQL = sCols & vbNewLine & _
               sBegin
        Return sSQL
    End Function

    Private Function ColumnasVirtualSQL(DGT As DataGridTable) As String
        Dim sCols As String = ""
        Dim iRg As Integer = 0
        Dim DVC As DataGridColumnVirtual = Nothing
        Dim sAlias As String = ""
        Dim CTV As ArrayList = DGT.ColumnasTablaVirtual.Order
        '*==============================================================

        For iRg = 0 To CTV.Count - 1  'Buscamos todas las columnas de la colleccion para buscar los campos de la virtual
            DVC = New DataGridColumnVirtual
            DVC = CTV(iRg)
            sAlias = ""
            If iRg <> 0 Then sCols = sCols & ", " 'Añade coma menos en la última
            If DVC.AliasTabla <> "" Then sAlias = DVC.AliasTabla & "."
            If DVC.Expresion <> "" Then 'Si hay Expresión prevalece sobre name
                sCols = sCols & " " & DVC.Expresion & " " & DVC.AliasCampo
            Else : sCols = sCols & " " & sAlias & DVC.Name & " " & DVC.AliasCampo
            End If
        Next

        If sCols <> "" Then sCols = " SELECT " & sCols
        Return sCols
    End Function

    Private Function ColumnasGridSQL(Optional ByVal Table As DataGridTable = Nothing) As String
        Dim sCols As String = ""
        Dim DC As Object
        Dim sAlias As String
        Dim sCol As String = ""
        Dim CLS As ArrayList = _Columnas.ToArray
        Dim filterTable As String = ""
        Dim sMarcar As String = ""
        Dim sPaginado As String = ""
        '*===============================================================================
        If Not IsNothing(Table) Then
            filterTable = Table.AliasTabla
        End If
        If _Grid.MarcarFilas Then sMarcar = " CAST(0 AS BIT) " & MarcarName & ", "
        If _iPaginado = 0 Then _iPaginado = 40
        If _Grid.DataGridType = DataGrid.GridType.Search Then sPaginado = " TOP " & _iPaginado
        With CLS
            For iRg = 0 To .Count - 1  'Buscamos todas las columnas de la colleccion para buscar los campos de la virtual
                DC = .Item(iRg)
                If filterTable = "" Or DC.Tabla = filterTable Then
                    sAlias = IIf((DC.Tabla <> ""), DC.Tabla & ".", "")

                    If iRg <> 0 Then sCols = sCols & ", " 'Añade coma menos en la última
                    If DC.Tabla <> "" Then sAlias = DC.Tabla & "."
                    If DC.ExpresionBd <> "" Then 'Si hay Expresión prevalece sobre name
                        sCol = IIf((DC.Campo = ""), DC.AliasCampo, DC.Campo)
                        sCols = sCols & " " & DC.ExpresionBd & " " & sCol
                    Else
                        If DC.Campo = "" Then DC.Campo = DC.AliasCampo
                        If DC.AliasCampo = "" Then DC.AliasCampo = DC.campo
                        If filterTable = "" Then
                            sCols = sCols & " " & sAlias & DC.Campo & " " & DC.AliasCampo
                        Else ' cuando se construye la sql de guardar no se pueden usar alias ya que si no no se puede guardar el dataset
                            sCols = sCols & " " & sAlias & DC.Campo
                        End If
                    End If
                End If
            Next
        End With
        If sCols <> "" Then sCols = " SELECT " & sPaginado & sMarcar & sCols
        Return sCols
    End Function

End Class
