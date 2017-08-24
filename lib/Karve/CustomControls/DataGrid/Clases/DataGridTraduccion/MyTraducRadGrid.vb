Imports Telerik.WinControls.UI.Localization
Imports VariablesGlobales

Public Class MyTraducRadGrid
    Inherits RadGridLocalizationProvider

    Public Overrides Function GetLocalizedString(id As String) As String
        Select Case id
            Case RadGridStringId.ConditionalFormattingPleaseSelectValidCellValue
                GetLocalizedString = "Por favor seleccione un valor celda valido" ' Please select valid cell value
            Case RadGridStringId.ConditionalFormattingPleaseSetValidCellValue
                GetLocalizedString = "Por favor seleccione un valor celda valido" ' Please select valid cell value
            Case RadGridStringId.ConditionalFormattingPleaseSetValidCellValues
                GetLocalizedString = "Por favor seleccione valores celda validos" ' Please select valid cell values
            Case RadGridStringId.ConditionalFormattingPleaseSetValidExpression
                GetLocalizedString = "Por favor selecciona una expresion valida" ' Please set a valid expression
            Case RadGridStringId.ConditionalFormattingItem
                GetLocalizedString = "Item"
            Case RadGridStringId.ConditionalFormattingInvalidParameters
                GetLocalizedString = "Parametros inválidos" ' Invalid parameters

            Case RadGridStringId.FilterFunctionBetween
                GetLocalizedString = "Entre" ' Between
            Case RadGridStringId.FilterFunctionContains
                GetLocalizedString = "Contiene" ' Contains
            Case RadGridStringId.FilterFunctionDoesNotContain
                GetLocalizedString = "No contiene" ' Does not contain
            Case RadGridStringId.FilterFunctionEndsWith
                GetLocalizedString = "Acaba con" ' Ends with
            Case RadGridStringId.FilterFunctionEqualTo
                GetLocalizedString = "Igual" ' Equals
            Case RadGridStringId.FilterFunctionGreaterThan
                GetLocalizedString = "Mayor que" ' Greater than
            Case RadGridStringId.FilterFunctionGreaterThanOrEqualTo
                GetLocalizedString = "Mayor o igual que" ' Greater than or equal to
            Case RadGridStringId.FilterFunctionIsEmpty
                GetLocalizedString = "Esta vacio" ' Is empty
            Case RadGridStringId.FilterFunctionIsNull
                GetLocalizedString = "Es nulo" ' Is null
            Case RadGridStringId.FilterFunctionLessThan
                GetLocalizedString = "Menor que" ' Less than
            Case RadGridStringId.FilterFunctionLessThanOrEqualTo
                GetLocalizedString = "Menor o igual que" ' Less than or equal to
            Case RadGridStringId.FilterFunctionNoFilter
                GetLocalizedString = "Sin filtro" ' No filter
            Case RadGridStringId.FilterFunctionNotBetween
                GetLocalizedString = "No entre" ' Not between
            Case RadGridStringId.FilterFunctionNotEqualTo
                GetLocalizedString = "Distinto de" ' Not equal to
            Case RadGridStringId.FilterFunctionNotIsEmpty
                GetLocalizedString = "No esta vacío" ' Is not empty
            Case RadGridStringId.FilterFunctionNotIsNull
                GetLocalizedString = "No es nulo" ' Is not null
            Case RadGridStringId.FilterFunctionStartsWith
                GetLocalizedString = "Empieza por" ' Starts with
            Case RadGridStringId.FilterFunctionCustom
                GetLocalizedString = "Personalizado" ' Custom

            Case RadGridStringId.FilterOperatorBetween
                GetLocalizedString = String.Empty ' "Between"
            Case RadGridStringId.FilterOperatorContains
                GetLocalizedString = String.Empty ' "Contains"
            Case RadGridStringId.FilterOperatorDoesNotContain
                GetLocalizedString = String.Empty ' "NotContains"
            Case RadGridStringId.FilterOperatorEndsWith
                GetLocalizedString = String.Empty ' "EndsWith"
            Case RadGridStringId.FilterOperatorEqualTo
                GetLocalizedString = String.Empty ' "Equals"
            Case RadGridStringId.FilterOperatorGreaterThan
                GetLocalizedString = String.Empty ' "GreaterThan"
            Case RadGridStringId.FilterOperatorGreaterThanOrEqualTo
                GetLocalizedString = String.Empty ' "GreaterThanOrEquals"
            Case RadGridStringId.FilterOperatorIsEmpty
                GetLocalizedString = String.Empty ' "IsEmpty"
            Case RadGridStringId.FilterOperatorIsNull
                GetLocalizedString = String.Empty ' "IsNull"
            Case RadGridStringId.FilterOperatorLessThan
                GetLocalizedString = String.Empty ' "LessThan"
            Case RadGridStringId.FilterOperatorLessThanOrEqualTo
                GetLocalizedString = String.Empty ' "LessThanOrEquals"
            Case RadGridStringId.FilterOperatorNoFilter
                GetLocalizedString = String.Empty ' "No filter"
            Case RadGridStringId.FilterOperatorNotBetween
                GetLocalizedString = String.Empty ' "NotBetween"
            Case RadGridStringId.FilterOperatorNotEqualTo
                GetLocalizedString = String.Empty ' "NotEquals"
            Case RadGridStringId.FilterOperatorNotIsEmpty
                GetLocalizedString = String.Empty ' "NotEmpty"
            Case RadGridStringId.FilterOperatorNotIsNull
                GetLocalizedString = String.Empty ' "NotNull"
            Case RadGridStringId.FilterOperatorStartsWith
                GetLocalizedString = String.Empty ' "StartsWith"
            Case RadGridStringId.FilterOperatorIsLike
                GetLocalizedString = String.Empty ' "Like"
            Case RadGridStringId.FilterOperatorNotIsLike
                GetLocalizedString = String.Empty ' "NotLike"
            Case RadGridStringId.FilterOperatorIsContainedIn
                GetLocalizedString = String.Empty ' "ContainedIn"
            Case RadGridStringId.FilterOperatorNotIsContainedIn
                GetLocalizedString = String.Empty ' "NotContainedIn"
            Case RadGridStringId.FilterOperatorCustom
                GetLocalizedString = String.Empty ' "Custom"

            Case RadGridStringId.CustomFilterMenuItem
                GetLocalizedString = "Personalizado" ' Custom
            Case RadGridStringId.CustomFilterDialogCaption
                GetLocalizedString = "RadGridView Filter Dialog [{0}]"
            Case RadGridStringId.CustomFilterDialogLabel
                GetLocalizedString = "Mostrar columnas donde:" ' Show rows where:
            Case RadGridStringId.CustomFilterDialogRbAnd
                GetLocalizedString = "Y" ' And
            Case RadGridStringId.CustomFilterDialogRbOr
                GetLocalizedString = "O" ' Or
            Case RadGridStringId.CustomFilterDialogBtnOk
                GetLocalizedString = "OK"
            Case RadGridStringId.CustomFilterDialogBtnCancel
                GetLocalizedString = "Cancelar" ' Cancel
            Case RadGridStringId.CustomFilterDialogCheckBoxNot
                GetLocalizedString = "No" ' Not
            Case RadGridStringId.CustomFilterDialogTrue
                GetLocalizedString = "Cierto" ' True
            Case RadGridStringId.CustomFilterDialogFalse
                GetLocalizedString = "Falso" ' False

            Case RadGridStringId.FilterMenuAvailableFilters
                GetLocalizedString = "Filtros disponibles" ' Available Filters
            Case RadGridStringId.FilterMenuSearchBoxText
                GetLocalizedString = "Buscar..." ' Search...
            Case RadGridStringId.FilterMenuClearFilters
                GetLocalizedString = "Limpiar Filtro" ' Clear Filter
            Case RadGridStringId.FilterMenuButtonOK
                GetLocalizedString = "OK"
            Case RadGridStringId.FilterMenuButtonCancel
                GetLocalizedString = "Cancelar" ' Cancel
            Case RadGridStringId.FilterMenuSelectionAll
                GetLocalizedString = "Todos" ' All
            Case RadGridStringId.FilterMenuSelectionAllSearched
                GetLocalizedString = "Todos los resultados de la busqueda" ' All Search Result
            Case RadGridStringId.FilterMenuSelectionNull
                GetLocalizedString = "Nulo" ' Null
            Case RadGridStringId.FilterMenuSelectionNotNull
                GetLocalizedString = "No Nulo" ' Not Null

            Case RadGridStringId.FilterFunctionSelectedDates
                GetLocalizedString = "Filtrar por fechas especificas:" ' Filter by specific dates:
            Case RadGridStringId.FilterFunctionToday
                GetLocalizedString = "Hoy" ' Today
            Case RadGridStringId.FilterFunctionYesterday
                GetLocalizedString = "Ayer" ' Yesterday
            Case RadGridStringId.FilterFunctionDuringLast7days
                GetLocalizedString = "Los ultimos 7 dias" ' During last 7 days

            Case RadGridStringId.FilterLogicalOperatorAnd
                GetLocalizedString = "Y" ' AND
            Case RadGridStringId.FilterLogicalOperatorOr
                GetLocalizedString = "O" ' OR
            Case RadGridStringId.FilterCompositeNotOperator
                GetLocalizedString = "NO" ' NOT

            Case RadGridStringId.DeleteRowMenuItem
                GetLocalizedString = "Borrar Fila" ' Delete Row
            Case RadGridStringId.SortAscendingMenuItem
                GetLocalizedString = "Ordenar Ascendentemente" ' Sort Ascending
            Case RadGridStringId.SortDescendingMenuItem
                GetLocalizedString = "Ordenar Descendentemente" ' Sort Descending
            Case RadGridStringId.ClearSortingMenuItem
                GetLocalizedString = "Limpiar Ordenacion" ' Clear Sorting
            Case RadGridStringId.ConditionalFormattingMenuItem
                GetLocalizedString = "Formato Condicional" ' Conditional Formatting
            Case RadGridStringId.GroupByThisColumnMenuItem
                GetLocalizedString = "Agrupar por esta columna" ' Group by this column
            Case RadGridStringId.UngroupThisColumn
                GetLocalizedString = "Desagrupar esta columna" ' Ungroup this column
            Case RadGridStringId.ColumnChooserMenuItem
                GetLocalizedString = "Seleccionar Columna" ' Column Chooser
            Case RadGridStringId.HideMenuItem
                GetLocalizedString = "Ocultar Columna" ' Hide Column
            Case RadGridStringId.HideGroupMenuItem
                GetLocalizedString = "Ocultar Grupo" ' Hide Group
            Case RadGridStringId.UnpinMenuItem
                GetLocalizedString = "Desanclar Columna" ' Unpin Column
            Case RadGridStringId.UnpinRowMenuItem
                GetLocalizedString = "Desanclar Fila" ' Unpin Row
            Case RadGridStringId.PinMenuItem
                GetLocalizedString = "Estado de Anclaje" ' Pinned state
            Case RadGridStringId.PinAtLeftMenuItem
                GetLocalizedString = "Anlar a izquierda" ' Pin at left
            Case RadGridStringId.PinAtRightMenuItem
                GetLocalizedString = "Anlar a derecha" ' Pin at right
            Case RadGridStringId.PinAtBottomMenuItem
                GetLocalizedString = "Anlar al pie" ' Pin at bottom
            Case RadGridStringId.PinAtTopMenuItem
                GetLocalizedString = "Anlar a la cabezera" ' Pin at top
            Case RadGridStringId.BestFitMenuItem
                GetLocalizedString = "Mejor Ajuste" ' Best Fit
            Case RadGridStringId.PasteMenuItem
                GetLocalizedString = "Pegar" ' Paste
            Case RadGridStringId.EditMenuItem
                GetLocalizedString = "Editar" ' Edit
            Case RadGridStringId.ClearValueMenuItem
                GetLocalizedString = "Limpiar Valor" ' Clear Value
            Case RadGridStringId.CopyMenuItem
                GetLocalizedString = "Copiar" ' Copy
            Case RadGridStringId.CutMenuItem
                GetLocalizedString = "Cortar" ' Cut
            Case RadGridStringId.AddNewRowString
                GetLocalizedString = "Click aqui para añadir una nueva fila" ' Click here to add a new row
            Case RadGridStringId.SearchRowResultsOfLabel
                GetLocalizedString = "de" ' of
            Case RadGridStringId.SearchRowMatchCase
                GetLocalizedString = "Coincide caso" ' Match case
            Case RadGridStringId.ConditionalFormattingSortAlphabetically
                GetLocalizedString = "Ordenar columnas alfabeticamente" ' Sort columns alphabetically
            Case RadGridStringId.ConditionalFormattingCaption
                GetLocalizedString = "Asistente de Fromato de Reglas Condicionales" ' Conditional Formatting Rules Manager
            Case RadGridStringId.ConditionalFormattingLblColumn
                GetLocalizedString = "Dar Formato solo a celdas con" ' Format only cells with
            Case RadGridStringId.ConditionalFormattingLblName
                GetLocalizedString = "Nombre de la Regla" ' Rule name
            Case RadGridStringId.ConditionalFormattingLblType
                GetLocalizedString = "Valor de la Celda" ' Cell value
            Case RadGridStringId.ConditionalFormattingLblValue1
                GetLocalizedString = "Valor 1" ' Value 1
            Case RadGridStringId.ConditionalFormattingLblValue2
                GetLocalizedString = "Valor 2" ' Value 2
            Case RadGridStringId.ConditionalFormattingGrpConditions
                GetLocalizedString = "Reglas" ' Rules
            Case RadGridStringId.ConditionalFormattingGrpProperties
                GetLocalizedString = "Propiedades de las Reglas" ' Rule Properties
            Case RadGridStringId.ConditionalFormattingChkApplyToRow
                GetLocalizedString = "Aplicar este formato a toda la fila" ' Apply this formatting to entire row
            Case RadGridStringId.ConditionalFormattingChkApplyOnSelectedRows
                GetLocalizedString = "Aplicar este formato si la fila esta seleccionada" ' Apply this formatting if the row is selected
            Case RadGridStringId.ConditionalFormattingBtnAdd
                GetLocalizedString = "Añadir nueva regla" ' Add new rule
            Case RadGridStringId.ConditionalFormattingBtnRemove
                GetLocalizedString = "Eliminar" ' Remove
            Case RadGridStringId.ConditionalFormattingBtnOK
                GetLocalizedString = "OK"
            Case RadGridStringId.ConditionalFormattingBtnCancel
                GetLocalizedString = "Cancelar" ' Cancel
            Case RadGridStringId.ConditionalFormattingBtnApply
                GetLocalizedString = "Aplicar" ' Apply
            Case RadGridStringId.ConditionalFormattingRuleAppliesOn
                GetLocalizedString = "la Regla se aplica a" ' Rule applies to
            Case RadGridStringId.ConditionalFormattingCondition
                GetLocalizedString = "Condición" ' Condition
            Case RadGridStringId.ConditionalFormattingExpression
                GetLocalizedString = "Expresión" ' Expression
            Case RadGridStringId.ConditionalFormattingChooseOne
                GetLocalizedString = "[Elige uno]" ' [Choose one]
            Case RadGridStringId.ConditionalFormattingEqualsTo
                GetLocalizedString = "Igual a [Valor1]" ' Equals to [Value1]
            Case RadGridStringId.ConditionalFormattingIsNotEqualTo
                GetLocalizedString = "Distinti de [Valor1]" ' Is not equal to [Value1]
            Case RadGridStringId.ConditionalFormattingStartsWith
                GetLocalizedString = "Empieza por [Valor1]" ' Starts with [Value1]
            Case RadGridStringId.ConditionalFormattingEndsWith
                GetLocalizedString = "Acaba con [Valor1]" ' Ends with [Value1]
            Case RadGridStringId.ConditionalFormattingContains
                GetLocalizedString = "Contiene [Valor1]" ' Contains [Value1]
            Case RadGridStringId.ConditionalFormattingDoesNotContain
                GetLocalizedString = "No contiene [Valor1]" ' Does not contain [Value1]
            Case RadGridStringId.ConditionalFormattingIsGreaterThan
                GetLocalizedString = "Mayor que [Valor1]" ' Is greater than [Value1]
            Case RadGridStringId.ConditionalFormattingIsGreaterThanOrEqual
                GetLocalizedString = "Mayor o igual que [Valor1]" ' Is greater than or equal [Value1]
            Case RadGridStringId.ConditionalFormattingIsLessThan
                GetLocalizedString = "Menor que [Valor1]" ' Is less than [Value1]
            Case RadGridStringId.ConditionalFormattingIsLessThanOrEqual
                GetLocalizedString = "Menor o igual que [Valor1]" ' Is less than or equal to [Value1]
            Case RadGridStringId.ConditionalFormattingIsBetween
                GetLocalizedString = "Entre [Valor1] y [Valor2]" ' Is between [Value1] and [Value2]"
            Case RadGridStringId.ConditionalFormattingIsNotBetween
                GetLocalizedString = "No esta entre [Valor1] y [Valor2]" ' Is not between [Value1] and [Value1]"
            Case RadGridStringId.ConditionalFormattingLblFormat
                GetLocalizedString = "Formato" ' Format

            Case RadGridStringId.ConditionalFormattingBtnExpression
                GetLocalizedString = "Editor de expresiones" ' Expression editor
            Case RadGridStringId.ConditionalFormattingTextBoxExpression
                GetLocalizedString = "Expresión" ' Expression

            Case RadGridStringId.ConditionalFormattingPropertyGridCaseSensitive
                GetLocalizedString = "Sensible a Mayusculas" ' Case Sensitive
            Case RadGridStringId.ConditionalFormattingPropertyGridCellBackColor
                GetLocalizedString = "Celda-ColorFondo" ' CellBackColor
            Case RadGridStringId.ConditionalFormattingPropertyGridCellForeColor
                GetLocalizedString = "Celda-ColorPrincipal" ' CellForeColor
            Case RadGridStringId.ConditionalFormattingPropertyGridEnabled
                GetLocalizedString = "Habilitado" ' Enabled
            Case RadGridStringId.ConditionalFormattingPropertyGridRowBackColor
                GetLocalizedString = "Fila-ColorFondo" ' RowBackColor
            Case RadGridStringId.ConditionalFormattingPropertyGridRowForeColor
                GetLocalizedString = "Fila-ColorPrincipal" ' RowForeColor
            Case RadGridStringId.ConditionalFormattingPropertyGridRowTextAlignment
                GetLocalizedString = "Fila-AlineacionTexto" ' RowTextAlignment
            Case RadGridStringId.ConditionalFormattingPropertyGridTextAlignment
                GetLocalizedString = "AlineacionTexto" ' TextAlignment

            Case RadGridStringId.ConditionalFormattingPropertyGridCaseSensitiveDescription
                GetLocalizedString = "Determina cuando las comparaciones de texto seran sensibles a las mayusculas" ' Determines whether case-sensitive comparisons will be made when evaluating string values.
            Case RadGridStringId.ConditionalFormattingPropertyGridCellBackColorDescription
                GetLocalizedString = "Selecciona el color de fondo que sera usado para la celda" ' Enter the background color to be used for the cell.
            Case RadGridStringId.ConditionalFormattingPropertyGridCellForeColorDescription
                GetLocalizedString = "Selecciona el color principal que sera usado para la celda" ' Enter the foreground color to be used for the cell.
            Case RadGridStringId.ConditionalFormattingPropertyGridEnabledDescription
                GetLocalizedString = "Determines whether the condition is enabled (can be evaluated and applied)."
            Case RadGridStringId.ConditionalFormattingPropertyGridRowBackColorDescription
                GetLocalizedString = "Selecciona el color de fondo que sera usado para toda la fila" ' "Enter the background color to be used for the entire row."
            Case RadGridStringId.ConditionalFormattingPropertyGridRowForeColorDescription
                GetLocalizedString = "Selecciona el color principal que sera usado para toda la fila" ' "Enter the foreground color to be used for the entire row."
            Case RadGridStringId.ConditionalFormattingPropertyGridRowTextAlignmentDescription
                GetLocalizedString = "Enter the alignment to be used for the cell values, when ApplyToRow is true."
            Case RadGridStringId.ConditionalFormattingPropertyGridTextAlignmentDescription
                GetLocalizedString = "Enter the alignment to be used for the cell values."

            Case RadGridStringId.ColumnChooserFormCaption
                GetLocalizedString = "Column Chooser"
            Case RadGridStringId.ColumnChooserFormMessage
                GetLocalizedString = "Drag a column header from the" & vbLf & "grid here to remove it from" & vbLf & "the current view."
            Case RadGridStringId.GroupingPanelDefaultMessage
                GetLocalizedString = "Desplazar la columna aquí para Agrupar por esta columna." '"Drag a column here to group by this column."
            Case RadGridStringId.GroupingPanelHeader
                GetLocalizedString = "Group by:"
            Case RadGridStringId.PagingPanelPagesLabel
                GetLocalizedString = "Page"
            Case RadGridStringId.PagingPanelOfPagesLabel
                GetLocalizedString = "of"
            Case RadGridStringId.NoDataText
                GetLocalizedString = "No data to display"
            Case RadGridStringId.CompositeFilterFormErrorCaption
                GetLocalizedString = "Filter Error"
            Case RadGridStringId.CompositeFilterFormInvalidFilter
                GetLocalizedString = "The composite filter descriptor is not valid."

            Case RadGridStringId.ExpressionMenuItem
                GetLocalizedString = "Expression"
            Case RadGridStringId.ExpressionFormTitle
                GetLocalizedString = "Expression Builder"
            Case RadGridStringId.ExpressionFormFunctions
                GetLocalizedString = "Functions"
            Case RadGridStringId.ExpressionFormFunctionsText
                GetLocalizedString = "Text"
            Case RadGridStringId.ExpressionFormFunctionsAggregate
                GetLocalizedString = "Aggregate"
            Case RadGridStringId.ExpressionFormFunctionsDateTime
                GetLocalizedString = "Date-Time"
            Case RadGridStringId.ExpressionFormFunctionsLogical
                GetLocalizedString = "Logical"
            Case RadGridStringId.ExpressionFormFunctionsMath
                GetLocalizedString = "Math"
            Case RadGridStringId.ExpressionFormFunctionsOther
                GetLocalizedString = "Other"
            Case RadGridStringId.ExpressionFormOperators
                GetLocalizedString = "Operators"
            Case RadGridStringId.ExpressionFormConstants
                GetLocalizedString = "Constants"
            Case RadGridStringId.ExpressionFormFields
                GetLocalizedString = "Fields"
            Case RadGridStringId.ExpressionFormDescription
                GetLocalizedString = "Description"
            Case RadGridStringId.ExpressionFormResultPreview
                GetLocalizedString = "Result preview"
            Case RadGridStringId.ExpressionFormTooltipPlus
                GetLocalizedString = "Plus"
            Case RadGridStringId.ExpressionFormTooltipMinus
                GetLocalizedString = "Minus"
            Case RadGridStringId.ExpressionFormTooltipMultiply
                GetLocalizedString = "Multiply"
            Case RadGridStringId.ExpressionFormTooltipDivide
                GetLocalizedString = "Divide"
            Case RadGridStringId.ExpressionFormTooltipModulo
                GetLocalizedString = "Modulo"
            Case RadGridStringId.ExpressionFormTooltipEqual
                GetLocalizedString = "Equal"
            Case RadGridStringId.ExpressionFormTooltipNotEqual
                GetLocalizedString = "Not Equal"
            Case RadGridStringId.ExpressionFormTooltipLess
                GetLocalizedString = "Less"
            Case RadGridStringId.ExpressionFormTooltipLessOrEqual
                GetLocalizedString = "Less Or Equal"
            Case RadGridStringId.ExpressionFormTooltipGreaterOrEqual
                GetLocalizedString = "Greater Or Equal"
            Case RadGridStringId.ExpressionFormTooltipGreater
                GetLocalizedString = "Greater"
            Case RadGridStringId.ExpressionFormTooltipAnd
                GetLocalizedString = "Logical ""AND"""
            Case RadGridStringId.ExpressionFormTooltipOr
                GetLocalizedString = "Logical ""OR"""
            Case RadGridStringId.ExpressionFormTooltipNot
                GetLocalizedString = "Logical ""NOT"""
            Case RadGridStringId.ExpressionFormAndButton
                GetLocalizedString = String.Empty
                'if empty, default button image is used
            Case RadGridStringId.ExpressionFormOrButton
                GetLocalizedString = String.Empty
                'if empty, default button image is used
            Case RadGridStringId.ExpressionFormNotButton
                GetLocalizedString = String.Empty
                'if empty, default button image is used
            Case RadGridStringId.ExpressionFormOKButton
                GetLocalizedString = "OK"
            Case RadGridStringId.ExpressionFormCancelButton
                GetLocalizedString = "Cancel"
            Case Else
                GetLocalizedString = String.Empty
        End Select

        Return Translate(GetLocalizedString)
    End Function

End Class