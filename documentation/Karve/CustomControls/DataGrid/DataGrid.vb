Imports System.Text
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Windows.Forms.Design
Imports Telerik.WinControls.UI
Imports Telerik.WinControls.UI.Localization
Imports VariablesGlobales.Modulo_VariablesGlobales
Imports Telerik.WinControls
Imports System.Drawing
Imports Microsoft.VisualBasic
Imports Telerik.WinControls.Data

<Designer(GetType(ControlDesigner))> _
Public Class DataGrid
    Inherits RadGridView

#Region "Variables"

    Dim tbsElement As New Telerik.WinControls.UI.GridTableElement
    Protected _Theme As ThemeType = ThemeType.Plain

    Protected datasetFiltering As Boolean = False
    Protected dgdDefinicion As New DataGridDefinicion
    Protected dgtTablas As New DataGridTables
    Protected dgcColumnas As New DataGridColumns
    Protected dgrClausulas As New DataGridRules
    Protected dgoOrdenes As New DataGridOrdenColumnas
    Protected dgcgGroups As DataGridColumnGroups

    Private _colRel As DataGridTextBoxColumn 'en esta variable se almacena la columna que relaciona los datos de la grid con los de la cabecera
    Protected _idRel As String 'en este campo se almacena el codigo de la tabla relacional
    Protected _MarcarFilas As Boolean = False

    Protected _DataGridType As GridType = GridType.Search
    Protected _sColsSelect As String

    Private _bScrolling As Boolean
    Private _BarraNotifica As New RadProgressBarElement
    Private _LabelNotifica As New RadLabelElement
    Private _bChangeOperator As Boolean
    Private _reloadCons As Boolean = True
    Private requery As Boolean = False

    Protected Event CellValidatingExtra(sender As Object, e As CellValidatingEventArgs)

    Public Event LanzaConsulta(Clausulas As DataGridRules)
    Public Event OpenMenu(sender As Object, e As ContextMenuOpeningEventArgs)
    Dim bCargando As Boolean
    Dim IndexRow As Integer
    Dim bBtnIzq As Boolean
    Dim OldRow As Integer

    Public Enum GridType
        Edit
        Search
    End Enum

#End Region

#Region "Propiedades"

    Public ReadOnly Property Scrolling As Boolean
        Get
            Return _bScrolling
        End Get
    End Property

    Property Theme As ThemeType
        Get
            Return _Theme
        End Get
        Set(value As ThemeType)
            _Theme = value
            If Theme = ThemeType.Plain Then
                Me.ThemeName = "TelerikMetroBlue"
            Else
                Me.ThemeName = "Control Default"
            End If
        End Set
    End Property

    Property BarraNotifica As RadProgressBarElement
        Get
            Return _BarraNotifica
        End Get
        Set(value As RadProgressBarElement)
            _BarraNotifica = value
        End Set
    End Property

    Property Tablas As DataGridTables
        Get
            Return dgtTablas
        End Get
        Set(value As DataGridTables)
            dgtTablas = value
        End Set
    End Property

    Property Columnas As DataGridColumns
        Get
            Return dgcColumnas
        End Get
        Set(value As DataGridColumns)
            dgcColumnas = value
        End Set
    End Property

    Property Ordenes As DataGridOrdenColumnas
        Get
            Return dgoOrdenes
        End Get
        Set(value As DataGridOrdenColumnas)
            dgoOrdenes = value
        End Set
    End Property

    Property MarcarFilas As Boolean
        Get
            Return _MarcarFilas
        End Get
        Set(value As Boolean)
            _MarcarFilas = value
        End Set
    End Property

    Property Clausulas As DataGridRules
        Get
            Return dgrClausulas
        End Get
        Set(value As DataGridRules)
            dgrClausulas = value
        End Set
    End Property

    Property EnforceConstrains As Boolean

        Get
            Return dgdDefinicion.EnforceConstrains
        End Get
        Set(value As Boolean)
            dgdDefinicion.EnforceConstrains = value
        End Set
    End Property

    Property DataGridType As GridType
        Get
            Return _DataGridType
        End Get
        Set(value As GridType)
            _DataGridType = value
            setGridType()
        End Set
    End Property

    Property idRel As String
        Get
            Return _idRel
        End Get
        Set(value As String)
            _idRel = value
        End Set
    End Property

    Property ColSelectFilter As String
        Get
            Return _sColsSelect
        End Get
        Set(value As String)
            _sColsSelect = value
        End Set
    End Property

    Shadows Property DBConnection As ASADB.Connection
        Get
            Return dgdDefinicion.DBConnection
        End Get
        Set(value As ASADB.Connection)
            dgdDefinicion.DBConnection = value
        End Set
    End Property

    Shadows Property ColRel As DataGridTextBoxColumn
        Get
            Return _colRel
        End Get
        Set(value As DataGridTextBoxColumn)
            _colRel = value
        End Set
    End Property

    Shadows Property TablaEdit As DataGridTable
        Get
            Return dgdDefinicion.TablaEdit
        End Get
        Set(value As DataGridTable)
            dgdDefinicion.TablaEdit = value
        End Set
    End Property

#End Region

    Sub New()
        MyBase.New()
        Me.ThemeClassName = "Telerik.WinControls.UI.RadGridView"
        RadGridLocalizationProvider.CurrentProvider = New MyTraducRadGrid
        AddHandler Me.TableElement.VScrollBar.MouseDown, AddressOf VScrollBar_MouseDown
    End Sub

    Private Function DameColor(sAliasCampo As String) As System.Drawing.Color
        Dim DGT As Object
        For Each DGTh As DictionaryEntry In dgcColumnas
            DGT = CType(dgcColumnas(DGTh.Key), Object)
            If UCase(DGT.AliasCampo) = UCase(sAliasCampo) Then
                Return DGT.BackColor
            End If
        Next
    End Function

    Private Sub DataGrid_CellEditorInitialized(sender As Object, e As GridViewCellEventArgs) Handles Me.CellEditorInitialized
        Dim tbEditor As RadTextBoxEditor = TryCast(Me.ActiveEditor, RadTextBoxEditor)
        If Not tbEditor Is Nothing Then
            Dim tbElement As RadTextBoxEditorElement = CType(tbEditor.EditorElement, RadTextBoxEditorElement)
            RemoveHandler tbElement.KeyDown, AddressOf tbElement_KeyDown
            AddHandler tbElement.KeyDown, AddressOf tbElement_KeyDown
        End If
    End Sub

    Private Sub tbElement_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        If _DataGridType = GridType.Search Then
            If Me.MasterView.TableFilteringRow.IsCurrent Then
                If e.KeyCode = Keys.Enter Then
                    LoadCons()
                ElseIf e.KeyCode = Keys.F4 Then
                End If
            End If
        End If
    End Sub

    Private Sub DataGrid_EditorRequired(sender As Object, e As EditorRequiredEventArgs) Handles Me.EditorRequired
        If e.EditorType Is GetType(GridBrowseEditor) Then
            e.EditorType = GetType(BrowerGridEditorKarve)
        End If
    End Sub

#Region "Definicion"

    Private Sub setGridType()
        If _DataGridType = GridType.Edit Then
            Me.EnableFiltering = True
            Me.datasetFiltering = True
            Me.AllowEditRow = True
            Me.AllowAddNewRow = True
            Me.AllowDeleteRow = True
            Me.AllowColumnChooser = False
            Me.EnableGrouping = False
            Me.SelectionMode = Telerik.WinControls.UI.GridViewSelectionMode.CellSelect
            Me.MultiSelect = True
        ElseIf _DataGridType = GridType.Search Then
            Me.EnableFiltering = True
            Me.datasetFiltering = False
            Me.AllowEditRow = True
            Me.AllowAddNewRow = False
            Me.AllowDeleteRow = False
            Me.MultiSelect = False
            Me.EnableGrouping = True
            Me.AllowColumnChooser = True
            Me.SelectionMode = Telerik.WinControls.UI.GridViewSelectionMode.FullRowSelect
        End If
    End Sub

    Protected Overridable Sub defineGrid()

    End Sub

    Public Sub generateGrid()
        defineGrid()

        For Each col In dgcColumnas.ToArray()
            dgdDefinicion.Columnas.Add(col)
        Next
        For Each tb In dgtTablas.ToArray()
            dgdDefinicion.TablasQuery.Add(tb)
        Next
        For Each Ord In dgoOrdenes.ToArray()
            dgdDefinicion.Ordenes.Add(Ord)
        Next
        For Each Rl In dgrClausulas.Order()
            dgdDefinicion.Clausulas.Add(Rl)
        Next
        If Not IsNothing(dgcgGroups) Then
            For Each gr In dgcgGroups.ColumnGroups
                dgdDefinicion.GruposColumnas.Add(gr)
            Next
        End If
    End Sub

#End Region

    Public Sub MarcarFilasEnGrid(Value As Boolean)
        Dim dtt As New DataTable
        Dim dtr As DataRow
        dtt = Me.DataSource
        For Each dtr In dtt.Rows
            dtr.Item(dgdDefinicion.NombreColMarcar) = Value
        Next
    End Sub

#Region "Funciones de Acceso a Datos"

    Public Sub loadGrid()
        _MarcarFilas = False
        If _DataGridType = GridType.Edit Then
            Dim dgrWhere As New DataGridRules
            Dim rl As New DataGridRule
            rl.Criterio = DataGridRule.euCriterio.Igual
            rl.Tabla = _colRel.Tabla
            rl.Campo = IIf(_colRel.Campo <> "", _colRel.Campo, _colRel.AliasCampo)
            rl.Valor = _idRel
            rl.Name = _colRel.Name
            dgrWhere.Add(rl)
            dgdDefinicion.Clausulas = dgrWhere
        End If
        dgdDefinicion.LoadGrid(Me)
        If _MarcarFilas Then SetConditions()
        setGridType()
        loadExtra()

        Dim dta As DataTable
        dta = Me.DataSource
        AddHandler dta.RowDeleted, AddressOf rowDeleted

    End Sub

    Protected Overridable Sub loadExtra()

    End Sub

    Protected Overridable Sub rowDeleted()

    End Sub

    Private Function Columna_Existe(Value As String) As Boolean
        For Each CL As Telerik.WinControls.UI.GridViewCellInfo In Me.MasterView.TableFilteringRow.Cells
            If CL.ColumnInfo.Name = Value Then Return True : Exit Function
        Next
        Return False
    End Function

    Public Sub LoadCons(Optional bMerge As Boolean = False)
        bCargando = True
        requery = False
        dgdDefinicion.LoadCons(Me, bMerge)
        LoadFiltros()
        LoadOrdenes()
        RaiseEvent LanzaConsulta(dgrClausulas)
        bCargando = False

    End Sub

    Public Sub guardar()
        dgdDefinicion.guardar()
    End Sub

    Public Sub setIdRel()
        For Each row In Me.Rows
            row.Cells(_colRel.Name).Value = _idRel
        Next
        If _DataGridType = GridType.Edit Then
            Dim dgrWhere As New DataGridRules
            Dim rl As New DataGridRule
            rl.Criterio = DataGridRule.euCriterio.Igual
            rl.Tabla = _colRel.Tabla
            rl.Campo = IIf(_colRel.Campo <> "", _colRel.Campo, _colRel.AliasCampo)
            rl.Valor = _idRel
            rl.Name = _colRel.Name
            dgrWhere.Add(rl)
            dgdDefinicion.Clausulas.Clear()
            dgdDefinicion.Clausulas = dgrWhere
        End If

        'CType(dgrClausulas.Item(_colRel.Name), DataGridRule).Valor = _idRel
    End Sub

    Private Sub GridDelegacion_UserAddingRow(sender As Object, e As Telerik.WinControls.UI.GridViewRowCancelEventArgs) Handles Me.UserAddingRow
        e.Rows(0).Cells(_colRel.Name).Value = _idRel
        AddExtra(sender, e)
    End Sub

    Protected Overridable Sub AddExtra(sender As Object, e As Telerik.WinControls.UI.GridViewRowCancelEventArgs)

    End Sub

    Public Sub Clear()
        Dim dta As DataTable = Me.DataSource
        dta.Rows.Clear()
    End Sub

#End Region

#Region "Eventos celdas Browser"

    Private Sub DataGrid_CellValidating(sender As Object, e As CellValidatingEventArgs) Handles Me.CellValidating
        Try
            If e.Column.GetType = GetType(DataGridBrowseBoxColumn) Then
                Dim OldValue As String = ""
                If IsDBNull(e.OldValue) Then
                    OldValue = ""
                Else
                    OldValue = e.OldValue
                End If

                If StrComp(OldValue, e.Value, CompareMethod.Text) Then
                    Dim col As DataGridBrowseBoxColumn = CType(e.Column, DataGridBrowseBoxColumn)
                    If Not IsNothing(col.RelatedColumn) Then
                        If col.Requery And Not Me.MasterView.TableFilteringRow.IsCurrent Then
                            e.Row.Cells(col.RelatedColumn.Name).Value = col.queryDesc(e.Value)
                        End If
                    End If
                End If
            End If
        Catch
        End Try

        Try
            If Me.MasterView.TableFilteringRow.IsCurrent And requery And Not bCargando Then
                LoadCons()
                requery = False
            End If
        Catch ex As Exception
        End Try

        RaiseEvent CellValidatingExtra(sender, e)
    End Sub

    Private Sub DataGrid_CellValueChanged(sender As Object, e As GridViewCellEventArgs) Handles Me.CellValueChanged
        If e.Column.GetType = GetType(DataGridBrowseBoxColumn) Then
            CType(e.Column, DataGridBrowseBoxColumn).Requery = True
        End If
        If Me.MasterView.TableFilteringRow.IsCurrent Then
            requery = True
        End If
    End Sub

    Private Sub SetConditions()
        'add a couple of sample formatting objects
        Dim c1 As New ConditionalFormattingObject("Fila Marcada", ConditionTypes.Equal, True, "", True)
        c1.RowBackColor = Color.SkyBlue
        c1.CellBackColor = Color.SkyBlue

        Me.Columns(dgdDefinicion.NombreColMarcar).ConditionalFormattingObjectList.Add(c1)

        'update the grid view for the conditional formatting to take effect


    End Sub

    Private Sub DataGrid_RowFormatting(sender As Object, e As RowFormattingEventArgs) Handles Me.RowFormatting
        If _MarcarFilas Then
            If e.RowElement.IsSelected Then
                e.RowElement.BackColor = Color.BlueViolet
            ElseIf e.RowElement.RowInfo.Cells(dgdDefinicion.NombreColMarcar).Value = False Then
                e.RowElement.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local)
                e.RowElement.ResetValue(LightVisualElement.GradientStyleProperty, ValueResetFlags.Local)
                e.RowElement.ResetValue(LightVisualElement.DrawFillProperty, ValueResetFlags.Local)
            End If
        End If
    End Sub

    Private Sub DataGrid_CellFormatting(sender As Object, e As CellFormattingEventArgs) Handles Me.CellFormatting

        Dim Color As System.Drawing.Color = DameColor(UCase(e.CellElement.ColumnInfo.Name))
        If _DataGridType = GridType.Edit Then   'Para las Lupas, desactivamos marcar columnas con colorines
            If Color <> System.Drawing.Color.Empty Then
                e.CellElement.DrawFill = (e.Row.IsSelected = False)
                e.CellElement.NumberOfColors = 1
                e.CellElement.BackColor = Color
            Else
                e.CellElement.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local)
                e.CellElement.ResetValue(LightVisualElement.GradientStyleProperty, ValueResetFlags.Local)
                e.CellElement.ResetValue(LightVisualElement.DrawFillProperty, ValueResetFlags.Local)
            End If
        End If

    End Sub

#End Region

#Region ".  No Usar.  "

    Private Function DameColor_(sAliasCampo As String) As System.Drawing.Color
        Dim DGT As DataGridColumn
        For iRg = 0 To dgcColumnas.Count - 1
            DGT = New DataGridColumn
            DGT = CType(dgcColumnas.Item(iRg), Object)
            If UCase(DGT.AliasCampo) = UCase(sAliasCampo) Then
                Return DGT.BackColor
            End If
        Next
    End Function

#End Region

    Private Sub InitializeComponent()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGrid
        '
        CType(Me.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()



    End Sub

#Region "   . Control Ordenes.    "

    Public Sub LoadOrdenes()
        bCargando = True
        Try
            Me.MasterTemplate.SortDescriptors.Clear()
            For Each CL As DataGridOrdenColumna In dgoOrdenes.ToArray
                If Columna_Existe(CL.Name) Then
                    Dim iSort As Integer = 0
                    If CL.Criterio = DataGridOrdenColumna.euCriterio.Desc Then iSort = 1
                    Me.MasterTemplate.SortDescriptors.Add(CL.Name, iSort)
                End If
            Next
        Catch
        End Try
        bCargando = False
    End Sub 'Revisar en que caso petan los orders

    Private Sub DataGrid_SortChanging(sender As Object, e As GridViewCollectionChangingEventArgs) Handles Me.SortChanging
        Dim CL As New DataGridOrdenColumna
        If _DataGridType = GridType.Search Then
            If bCargando = False Then
                e.Cancel = True
                If e.NewItems.Count <> 0 Then
                    With CL
                        Dim col = dgdDefinicion.Columnas.Item(e.NewItems(0).PropertyName)
                        If Not col Is Nothing Then .AliasTabla = col.Tabla
                        .Name = e.NewItems(0).PropertyName
                        If Not IsNothing(col) Then
                            .Campo = col.Campo
                            .AliasCampo = col.AliasCampo
                            .ExpresionBD = col.ExpresionBD
                        End If
                        If e.NewItems(0).Direction = 0 Then
                            .Criterio = DataGridOrdenColumna.euCriterio.Asc
                        Else : .Criterio = DataGridOrdenColumna.euCriterio.Desc
                        End If
                    End With
                    dgoOrdenes.Clear()
                    dgoOrdenes.Add(CL)
                Else
                    If dgoOrdenes(0).criterio = DataGridOrdenColumna.euCriterio.Desc Then
                        dgoOrdenes(0).criterio = DataGridOrdenColumna.euCriterio.Asc
                    Else : dgoOrdenes(0).criterio = DataGridOrdenColumna.euCriterio.Desc
                    End If
                End If
                dgdDefinicion.Ordenes = dgoOrdenes
                LoadCons()
            End If
        End If
    End Sub

#End Region

#Region "   . Control Filtros.    "

    Private Sub DataGrid_FilterChanging(sender As Object, e As GridViewCollectionChangingEventArgs) Handles Me.FilterChanging


        If Not datasetFiltering Then
            If bCargando = False Then
                _bChangeOperator = False
                Select Case e.Action
                    Case NotifyCollectionChangedAction.Remove
                        dgrClausulas.Remove(e.PropertyName)
                        _bChangeOperator = True
                        _reloadCons = False
                    Case Else
                        Select Case e.NewItems(0).GetType
                            Case GetType(FilterDescriptor)
                                TextFilter(e.NewItems(0))
                            Case GetType(DateFilterDescriptor)
                                DateFilter(e.NewItems(0))
                            Case GetType(CompositeFilterDescriptor)
                                CompositeFilter(e.NewItems(0))
                                _bChangeOperator = True
                            Case Else
                                TextFilter(e.NewItems(0))
                        End Select
                End Select

                dgdDefinicion.Clausulas = dgrClausulas
                e.Cancel = Not _bChangeOperator
            End If
        End If
    End Sub

    Private Sub TextFilter(filter As FilterDescriptor)
        Dim RL As New DataGridRule
        Dim col = dgcColumnas.Item(filter.PropertyName)

        If Not IsNothing(col) Then

            With RL 'Hay que machearlo con las columnas
                .Tabla = col.Tabla
                .Name = col.Name
                .Campo = col.Campo
                .AliasCampo = col.AliasCampo
                .ExpresionBD = col.ExpresionBD
                .Criterio = Correspondencia_Filtro(filter.Operator)
                .Tipo = DataGridRule.TipoFiltro.Texto
                If filter.Operator = Telerik.WinControls.Data.FilterOperator.IsNull Then
                    .Valor = ""
                Else
                    .Valor = filter.Value
                End If
            End With

            If VD.getString(filter.Value) = "" And Not PermiteValueNull(filter.Operator) Then 'Borra elemento si lo encuentra
                dgrClausulas.Remove(RL.Name)
            ElseIf dgrClausulas.Existe(RL.Name) Then
                Dim tmp As DataGridRule = dgrClausulas(RL.Name)
                RL.Item = tmp.Item
                If RL.Criterio <> tmp.Criterio Then _bChangeOperator = True
                dgrClausulas.Modify(RL)
            Else
                dgrClausulas.Add(RL)
            End If
        End If
    End Sub

    Private Sub DateFilter(filter As DateFilterDescriptor)
        Dim RL As New DataGridRule
        Dim col = dgcColumnas.Item(filter.PropertyName)

        If Not IsNothing(col) Then

            With RL 'Hay que machearlo con las columnas
                .Tabla = col.Tabla
                .Name = col.Name
                .Campo = col.Campo
                .AliasCampo = col.AliasCampo
                .ExpresionBD = col.ExpresionBD
                .Criterio = Correspondencia_Filtro(filter.Operator)
                .Tipo = DataGridRule.TipoFiltro.Fecha
                If filter.Operator = Telerik.WinControls.Data.FilterOperator.IsNull Then
                    .Valor = ""
                Else
                    .Valor = CDate(filter.Value).ToString("yyyy-MM-dd")
                End If
            End With

            If VD.getString(filter.Value) = "" And Not PermiteValueNull(filter.Operator) Then 'Borra elemento si lo encuentra
                dgrClausulas.Remove(RL.Name)
            ElseIf dgrClausulas.Existe(RL.Name) Then
                Dim tmp As DataGridRule = dgrClausulas(RL.Name)
                RL.Item = tmp.Item
                If RL.Criterio <> tmp.Criterio Then _bChangeOperator = True
                dgrClausulas.Modify(RL)
            Else
                dgrClausulas.Add(RL)
            End If

        End If
    End Sub

    Private Sub CompositeFilter(filter As CompositeFilterDescriptor)
        Dim RL As New DataGridRule
        Dim col = dgcColumnas.Item(filter.PropertyName)
        Dim rlParts As New DataGridRules

        If Not IsNothing(col) Then
            Dim i As Integer = 0
            For Each fil In filter.FilterDescriptors
                Dim rlPart As New DataGridRule

                With rlPart 'Hay que machearlo con las columnas
                    .Tabla = col.Tabla
                    .Name = col.Name & i
                    .Campo = col.Campo
                    .AliasCampo = col.AliasCampo
                    .ExpresionBD = col.ExpresionBD
                    .Criterio = Correspondencia_Filtro(fil.Operator)

                    Select Case fil.GetType
                        Case GetType(FilterDescriptor)
                            .Tipo = DataGridRule.TipoFiltro.Texto
                            If fil.Operator = Telerik.WinControls.Data.FilterOperator.IsNull Then
                                .Valor = ""
                            Else
                                .Valor = fil.Value
                            End If
                        Case GetType(DateFilterDescriptor)
                            .Tipo = DataGridRule.TipoFiltro.Fecha
                            If fil.Operator = Telerik.WinControls.Data.FilterOperator.IsNull Then
                                .Valor = ""
                            Else
                                .Valor = CDate(fil.Value).ToString("yyyy-MM-dd")
                            End If
                    End Select

                End With
                If VD.getString(rlPart.Valor) = "" And Not PermiteValueNull(fil.Operator) Then
                    'en lugar de eliminar la regla no la creamos
                Else
                    rlParts.Add(rlPart)
                    i += 1
                End If
            Next

            With RL
                .Tabla = col.Tabla
                .Name = col.Name
                .Campo = col.Campo
                .AliasCampo = col.AliasCampo
                .ExpresionBD = col.ExpresionBD
                .Tipo = DataGridRule.TipoFiltro.Compuesto
                .Operador = IIf(filter.LogicalOperator = FilterLogicalOperator.And, DataGridRule.euOperadorRule.eAnd, DataGridRule.euOperadorRule.eOr)
                .Rules = rlParts
                .Expresion = " " & IIf(filter.NotOperator, "NOT ", "") & "("
                For Each rlPart As DataGridRule In .Rules.Order
                    If rlPart.Item > 0 Then .Expresion &= .OperadorVal
                    .Expresion &= .Rules.DameClausula(rlPart)
                Next
                .Expresion &= ") "
            End With

            If RL.Rules.Count = 0 Then 'si no tiene reglas las eliminamos
                dgrClausulas.Remove(RL.Name)
            ElseIf dgrClausulas.Existe(RL.Name) Then
                RL.Item = dgrClausulas(RL.Name).Item
                dgrClausulas.Modify(RL)
            Else
                dgrClausulas.Add(RL)
            End If
        End If
    End Sub

    Private Sub DataGrid_FilterChanged(sender As Object, e As GridViewCollectionChangedEventArgs) Handles Me.FilterChanged
        If _DataGridType = GridType.Search Then
            If _bChangeOperator Then
                _bChangeOperator = False
                'If _reloadCons Then LoadCons()
                _reloadCons = True
            End If
        End If
    End Sub

    Private Function PermiteValueNull(Value As Telerik.WinControls.Data.FilterOperator) As Boolean
        Select Case Value
            Case _
                Telerik.WinControls.Data.FilterOperator.IsNull, _
                Telerik.WinControls.Data.FilterOperator.IsNotNull : Return True
            Case Else : Return False
        End Select
    End Function

    Private Function BuscaColumna(Value As String) As Object
        For Each CL As Object In dgcColumnas.ToArray
            If Value = CL.FieldName Then Return CL : Exit Function
        Next
        Return Nothing
    End Function

    Private Function Correspondencia_Filtro(Value As Telerik.WinControls.Data.FilterOperator) As DataGridRule.euCriterio
        Select Case Value
            Case Telerik.WinControls.Data.FilterOperator.Contains : Return DataGridRule.euCriterio.Contiene
            Case Telerik.WinControls.Data.FilterOperator.StartsWith : Return DataGridRule.euCriterio.Empieza
            Case Telerik.WinControls.Data.FilterOperator.EndsWith : Return DataGridRule.euCriterio.Termina
            Case Telerik.WinControls.Data.FilterOperator.IsEqualTo : Return DataGridRule.euCriterio.Igual
            Case Telerik.WinControls.Data.FilterOperator.IsGreaterThan : Return DataGridRule.euCriterio.Mayor_Que
            Case Telerik.WinControls.Data.FilterOperator.IsGreaterThanOrEqualTo : Return DataGridRule.euCriterio.MayorIgual_Que
            Case Telerik.WinControls.Data.FilterOperator.IsLessThan : Return DataGridRule.euCriterio.Menor_Que
            Case Telerik.WinControls.Data.FilterOperator.IsLessThanOrEqualTo : Return DataGridRule.euCriterio.MenorIgual_Que
            Case Telerik.WinControls.Data.FilterOperator.IsNotEqualTo : Return DataGridRule.euCriterio.Distinto
            Case Telerik.WinControls.Data.FilterOperator.IsNotNull : Return DataGridRule.euCriterio.NoEsNulo
            Case Telerik.WinControls.Data.FilterOperator.IsNull : Return DataGridRule.euCriterio.EsNulo
            Case Telerik.WinControls.Data.FilterOperator.NotContains : Return DataGridRule.euCriterio.NoContiene
            Case Else : Return DataGridRule.euCriterio.Empieza
        End Select
    End Function

    Private Function Correspondencia_Filtro_Ret(Value As DataGridRule.euCriterio) As Telerik.WinControls.Data.FilterOperator
        Select Case Value
            Case DataGridRule.euCriterio.Contiene : Return Telerik.WinControls.Data.FilterOperator.Contains
            Case DataGridRule.euCriterio.Empieza : Return Telerik.WinControls.Data.FilterOperator.StartsWith
            Case DataGridRule.euCriterio.Termina : Return Telerik.WinControls.Data.FilterOperator.EndsWith
            Case DataGridRule.euCriterio.Igual : Return Telerik.WinControls.Data.FilterOperator.IsEqualTo
            Case DataGridRule.euCriterio.Mayor_Que : Return Telerik.WinControls.Data.FilterOperator.IsGreaterThan
            Case DataGridRule.euCriterio.MayorIgual_Que : Return Telerik.WinControls.Data.FilterOperator.IsGreaterThanOrEqualTo
            Case DataGridRule.euCriterio.Menor_Que : Return Telerik.WinControls.Data.FilterOperator.IsLessThan
            Case DataGridRule.euCriterio.MenorIgual_Que : Return Telerik.WinControls.Data.FilterOperator.IsLessThanOrEqualTo
            Case DataGridRule.euCriterio.Distinto : Return Telerik.WinControls.Data.FilterOperator.IsNotEqualTo
            Case DataGridRule.euCriterio.EsNulo : Return Telerik.WinControls.Data.FilterOperator.IsNull
            Case DataGridRule.euCriterio.NoEsNulo : Return Telerik.WinControls.Data.FilterOperator.IsNotNull
            Case DataGridRule.euCriterio.NoContiene : Return Telerik.WinControls.Data.FilterOperator.NotContains
            Case Else : Return Telerik.WinControls.Data.FilterOperator.StartsWith
        End Select
    End Function

    Public Sub LoadFiltros()
        Me.FilterDescriptors.BeginUpdate()
        Me.FilterDescriptors.Clear()

        For Each CL As DataGridRule In dgrClausulas.Order

            Try
                Dim s As New Object
                Select Case CL.Tipo
                    Case DataGridRule.TipoFiltro.Texto
                        s = LoadTextFilter(CL)
                    Case DataGridRule.TipoFiltro.Fecha
                        s = LoadDateFilter(CL)
                    Case DataGridRule.TipoFiltro.Compuesto
                        s = LoadCompositeFilter(CL)
                End Select

                Me.FilterDescriptors.Add(s)
            Catch
            End Try
        Next
        Me.FilterDescriptors.EndUpdate()
    End Sub

    Private Function LoadTextFilter(RL As DataGridRule) As FilterDescriptor
        LoadTextFilter = New FilterDescriptor

        With LoadTextFilter
            .Value = RL.Valor
            .Operator = Correspondencia_Filtro_Ret(RL.Criterio)
            .IsFilterEditor = True
            .PropertyName = RL.Name
        End With
    End Function

    Private Function LoadDateFilter(RL As DataGridRule) As DateFilterDescriptor
        LoadDateFilter = New DateFilterDescriptor

        With LoadDateFilter
            .Value = CDate(RL.Valor)
            .Operator = Correspondencia_Filtro_Ret(RL.Criterio)
            .IsFilterEditor = True
            .PropertyName = RL.Name
        End With
    End Function

    Private Function LoadCompositeFilter(RL As DataGridRule) As CompositeFilterDescriptor
        LoadCompositeFilter = New CompositeFilterDescriptor
        For Each rlPart In RL.Rules.Order
            Dim filter As New Object
            Select Case rlPart.Tipo
                Case DataGridRule.TipoFiltro.Texto
                    filter = LoadTextFilter(rlPart)
                Case DataGridRule.TipoFiltro.Fecha
                    filter = LoadDateFilter(rlPart)
            End Select
            filter.PropertyName = RL.Name
            LoadCompositeFilter.FilterDescriptors.Add(filter)
        Next
        With LoadCompositeFilter
            .Value = RL.Valor
            .Operator = FilterOperator.Contains
            .IsFilterEditor = True
            .PropertyName = RL.Name
            .LogicalOperator = IIf(RL.Operador = DataGridRule.euOperadorRule.eAnd, FilterLogicalOperator.And, FilterLogicalOperator.Or)
            .NotOperator = IIf(RL.Expresion.Substring(1, 3) = "NOT", True, False)
        End With
    End Function

#End Region

#Region "   . Control ScrollBar.   "

    Private Sub VScrollBar_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        _bScrolling = True
        If Me.TableElement.VScrollBar.Maximum - Me.TableElement.VScrollBar.Value <= (Me.TableElement.VScrollBar.LargeChange - 1) Then
            LoadConsMerge()
        End If
        _bScrolling = False
    End Sub

    Private Sub DataGrid_MouseWheel(sender As Object, e As MouseEventArgs) Handles Me.MouseWheel
        If _DataGridType = GridType.Search Then
            If Me.TableElement.VScrollBar.Maximum - Me.TableElement.VScrollBar.Value <= (Me.TableElement.VScrollBar.LargeChange - 1) Then
                LoadConsMerge()
            End If
        End If
    End Sub

    Private Sub LoadConsMerge()
        If _DataGridType = GridType.Search Then
            dgdDefinicion.NRegPaginado = dgdDefinicion.NRegPaginado + 40
            LoadCons(True)
            Me.TableElement.ScrollToRow(Me.Rows.Count - (Me.TableElement.RowsPerPage + 5))
        End If
    End Sub

#End Region

#Region "   . Control Menus Contextuales.   "

    Private Sub DataGrid_ContextMenuOpening(sender As Object, e As ContextMenuOpeningEventArgs) Handles Me.ContextMenuOpening
        If Me.MasterView.TableFilteringRow.IsCurrent Or bBtnIzq Then bBtnIzq = False : Exit Sub
        RaiseEvent OpenMenu(sender, e)
    End Sub

    Private Sub DataGrid_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
        bBtnIzq = False
    End Sub

    Private Sub DataGrid_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        bBtnIzq = e.Button = Windows.Forms.MouseButtons.Left
    End Sub

#End Region

End Class

