using Telerik.WinControls.UI.Localization;

namespace KarveControls.DataGrid.DataGridHelpers
{
    public class MyTraducRadGrid : RadGridLocalizationProvider
    {

        public override string GetLocalizedString(string id)
        {
            string functionReturnValue = null;
            switch (id) {
                case RadGridStringId.ConditionalFormattingPleaseSelectValidCellValue:
                    functionReturnValue = "Por favor seleccione un valor celda valido";
                    // Please select valid cell value
                    break;
                case RadGridStringId.ConditionalFormattingPleaseSetValidCellValue:
                    functionReturnValue = "Por favor seleccione un valor celda valido";
                    // Please select valid cell value
                    break;
                case RadGridStringId.ConditionalFormattingPleaseSetValidCellValues:
                    functionReturnValue = "Por favor seleccione valores celda validos";
                    // Please select valid cell values
                    break;
                case RadGridStringId.ConditionalFormattingPleaseSetValidExpression:
                    functionReturnValue = "Por favor selecciona una expresion valida";
                    // Please set a valid expression
                    break;
                case RadGridStringId.ConditionalFormattingItem:
                    functionReturnValue = "Item";
                    break;
                case RadGridStringId.ConditionalFormattingInvalidParameters:
                    functionReturnValue = "Parametros inválidos";
                    // Invalid parameters
                    break;

                case RadGridStringId.FilterFunctionBetween:
                    functionReturnValue = "Entre";
                    // Between
                    break;
                case RadGridStringId.FilterFunctionContains:
                    functionReturnValue = "Contiene";
                    // Contains
                    break;
                case RadGridStringId.FilterFunctionDoesNotContain:
                    functionReturnValue = "No contiene";
                    // Does not contain
                    break;
                case RadGridStringId.FilterFunctionEndsWith:
                    functionReturnValue = "Acaba con";
                    // Ends with
                    break;
                case RadGridStringId.FilterFunctionEqualTo:
                    functionReturnValue = "Igual";
                    // Equals
                    break;
                case RadGridStringId.FilterFunctionGreaterThan:
                    functionReturnValue = "Mayor que";
                    // Greater than
                    break;
                case RadGridStringId.FilterFunctionGreaterThanOrEqualTo:
                    functionReturnValue = "Mayor o igual que";
                    // Greater than or equal to
                    break;
                case RadGridStringId.FilterFunctionIsEmpty:
                    functionReturnValue = "Esta vacio";
                    // Is empty
                    break;
                case RadGridStringId.FilterFunctionIsNull:
                    functionReturnValue = "Es nulo";
                    // Is null
                    break;
                case RadGridStringId.FilterFunctionLessThan:
                    functionReturnValue = "Menor que";
                    // Less than
                    break;
                case RadGridStringId.FilterFunctionLessThanOrEqualTo:
                    functionReturnValue = "Menor o igual que";
                    // Less than or equal to
                    break;
                case RadGridStringId.FilterFunctionNoFilter:
                    functionReturnValue = "Sin filtro";
                    // No filter
                    break;
                case RadGridStringId.FilterFunctionNotBetween:
                    functionReturnValue = "No entre";
                    // Not between
                    break;
                case RadGridStringId.FilterFunctionNotEqualTo:
                    functionReturnValue = "Distinto de";
                    // Not equal to
                    break;
                case RadGridStringId.FilterFunctionNotIsEmpty:
                    functionReturnValue = "No esta vacío";
                    // Is not empty
                    break;
                case RadGridStringId.FilterFunctionNotIsNull:
                    functionReturnValue = "No es nulo";
                    // Is not null
                    break;
                case RadGridStringId.FilterFunctionStartsWith:
                    functionReturnValue = "Empieza por";
                    // Starts with
                    break;
                case RadGridStringId.FilterFunctionCustom:
                    functionReturnValue = "Personalizado";
                    // Custom
                    break;

                case RadGridStringId.FilterOperatorBetween:
                    functionReturnValue = string.Empty;
                    // "Between"
                    break;
                case RadGridStringId.FilterOperatorContains:
                    functionReturnValue = string.Empty;
                    // "Contains"
                    break;
                case RadGridStringId.FilterOperatorDoesNotContain:
                    functionReturnValue = string.Empty;
                    // "NotContains"
                    break;
                case RadGridStringId.FilterOperatorEndsWith:
                    functionReturnValue = string.Empty;
                    // "EndsWith"
                    break;
                case RadGridStringId.FilterOperatorEqualTo:
                    functionReturnValue = string.Empty;
                    // "Equals"
                    break;
                case RadGridStringId.FilterOperatorGreaterThan:
                    functionReturnValue = string.Empty;
                    // "GreaterThan"
                    break;
                case RadGridStringId.FilterOperatorGreaterThanOrEqualTo:
                    functionReturnValue = string.Empty;
                    // "GreaterThanOrEquals"
                    break;
                case RadGridStringId.FilterOperatorIsEmpty:
                    functionReturnValue = string.Empty;
                    // "IsEmpty"
                    break;
                case RadGridStringId.FilterOperatorIsNull:
                    functionReturnValue = string.Empty;
                    // "IsNull"
                    break;
                case RadGridStringId.FilterOperatorLessThan:
                    functionReturnValue = string.Empty;
                    // "LessThan"
                    break;
                case RadGridStringId.FilterOperatorLessThanOrEqualTo:
                    functionReturnValue = string.Empty;
                    // "LessThanOrEquals"
                    break;
                case RadGridStringId.FilterOperatorNoFilter:
                    functionReturnValue = string.Empty;
                    // "No filter"
                    break;
                case RadGridStringId.FilterOperatorNotBetween:
                    functionReturnValue = string.Empty;
                    // "NotBetween"
                    break;
                case RadGridStringId.FilterOperatorNotEqualTo:
                    functionReturnValue = string.Empty;
                    // "NotEquals"
                    break;
                case RadGridStringId.FilterOperatorNotIsEmpty:
                    functionReturnValue = string.Empty;
                    // "NotEmpty"
                    break;
                case RadGridStringId.FilterOperatorNotIsNull:
                    functionReturnValue = string.Empty;
                    // "NotNull"
                    break;
                case RadGridStringId.FilterOperatorStartsWith:
                    functionReturnValue = string.Empty;
                    // "StartsWith"
                    break;
                case RadGridStringId.FilterOperatorIsLike:
                    functionReturnValue = string.Empty;
                    // "Like"
                    break;
                case RadGridStringId.FilterOperatorNotIsLike:
                    functionReturnValue = string.Empty;
                    // "NotLike"
                    break;
                case RadGridStringId.FilterOperatorIsContainedIn:
                    functionReturnValue = string.Empty;
                    // "ContainedIn"
                    break;
                case RadGridStringId.FilterOperatorNotIsContainedIn:
                    functionReturnValue = string.Empty;
                    // "NotContainedIn"
                    break;
                case RadGridStringId.FilterOperatorCustom:
                    functionReturnValue = string.Empty;
                    // "Custom"
                    break;

                case RadGridStringId.CustomFilterMenuItem:
                    functionReturnValue = "Personalizado";
                    // Custom
                    break;
                case RadGridStringId.CustomFilterDialogCaption:
                    functionReturnValue = "RadGridView Filter Dialog [{0}]";
                    break;
                case RadGridStringId.CustomFilterDialogLabel:
                    functionReturnValue = "Mostrar columnas donde:";
                    // Show rows where:
                    break;
                case RadGridStringId.CustomFilterDialogRbAnd:
                    functionReturnValue = "Y";
                    // And
                    break;
                case RadGridStringId.CustomFilterDialogRbOr:
                    functionReturnValue = "O";
                    // Or
                    break;
                case RadGridStringId.CustomFilterDialogBtnOk:
                    functionReturnValue = "OK";
                    break;
                case RadGridStringId.CustomFilterDialogBtnCancel:
                    functionReturnValue = "Cancelar";
                    // Cancel
                    break;
                case RadGridStringId.CustomFilterDialogCheckBoxNot:
                    functionReturnValue = "No";
                    // Not
                    break;
                case RadGridStringId.CustomFilterDialogTrue:
                    functionReturnValue = "Cierto";
                    // True
                    break;
                case RadGridStringId.CustomFilterDialogFalse:
                    functionReturnValue = "Falso";
                    // False
                    break;

                case RadGridStringId.FilterMenuAvailableFilters:
                    functionReturnValue = "Filtros disponibles";
                    // Available Filters
                    break;
                case RadGridStringId.FilterMenuSearchBoxText:
                    functionReturnValue = "Buscar...";
                    // Search...
                    break;
                case RadGridStringId.FilterMenuClearFilters:
                    functionReturnValue = "Limpiar Filtro";
                    // Clear Filter
                    break;
                case RadGridStringId.FilterMenuButtonOK:
                    functionReturnValue = "OK";
                    break;
                case RadGridStringId.FilterMenuButtonCancel:
                    functionReturnValue = "Cancelar";
                    // Cancel
                    break;
                case RadGridStringId.FilterMenuSelectionAll:
                    functionReturnValue = "Todos";
                    // All
                    break;
                case RadGridStringId.FilterMenuSelectionAllSearched:
                    functionReturnValue = "Todos los resultados de la busqueda";
                    // All Search Result
                    break;
                case RadGridStringId.FilterMenuSelectionNull:
                    functionReturnValue = "Nulo";
                    // Null
                    break;
                case RadGridStringId.FilterMenuSelectionNotNull:
                    functionReturnValue = "No Nulo";
                    // Not Null
                    break;

                case RadGridStringId.FilterFunctionSelectedDates:
                    functionReturnValue = "Filtrar por fechas especificas:";
                    // Filter by specific dates:
                    break;
                case RadGridStringId.FilterFunctionToday:
                    functionReturnValue = "Hoy";
                    // Today
                    break;
                case RadGridStringId.FilterFunctionYesterday:
                    functionReturnValue = "Ayer";
                    // Yesterday
                    break;
                case RadGridStringId.FilterFunctionDuringLast7days:
                    functionReturnValue = "Los ultimos 7 dias";
                    // During last 7 days
                    break;

                case RadGridStringId.FilterLogicalOperatorAnd:
                    functionReturnValue = "Y";
                    // AND
                    break;
                case RadGridStringId.FilterLogicalOperatorOr:
                    functionReturnValue = "O";
                    // OR
                    break;
                case RadGridStringId.FilterCompositeNotOperator:
                    functionReturnValue = "NO";
                    // NOT
                    break;

                case RadGridStringId.DeleteRowMenuItem:
                    functionReturnValue = "Borrar Fila";
                    // Delete Row
                    break;
                case RadGridStringId.SortAscendingMenuItem:
                    functionReturnValue = "Ordenar Ascendentemente";
                    // Sort Ascending
                    break;
                case RadGridStringId.SortDescendingMenuItem:
                    functionReturnValue = "Ordenar Descendentemente";
                    // Sort Descending
                    break;
                case RadGridStringId.ClearSortingMenuItem:
                    functionReturnValue = "Limpiar Ordenacion";
                    // Clear Sorting
                    break;
                case RadGridStringId.ConditionalFormattingMenuItem:
                    functionReturnValue = "Formato Condicional";
                    // Conditional Formatting
                    break;
                case RadGridStringId.GroupByThisColumnMenuItem:
                    functionReturnValue = "Agrupar por esta columna";
                    // Group by this column
                    break;
                case RadGridStringId.UngroupThisColumn:
                    functionReturnValue = "Desagrupar esta columna";
                    // Ungroup this column
                    break;
                case RadGridStringId.ColumnChooserMenuItem:
                    functionReturnValue = "Seleccionar Columna";
                    // Column Chooser
                    break;
                case RadGridStringId.HideMenuItem:
                    functionReturnValue = "Ocultar Columna";
                    // Hide Column
                    break;
                case RadGridStringId.HideGroupMenuItem:
                    functionReturnValue = "Ocultar Grupo";
                    // Hide Group
                    break;
                case RadGridStringId.UnpinMenuItem:
                    functionReturnValue = "Desanclar Columna";
                    // Unpin Column
                    break;
                case RadGridStringId.UnpinRowMenuItem:
                    functionReturnValue = "Desanclar Fila";
                    // Unpin Row
                    break;
                case RadGridStringId.PinMenuItem:
                    functionReturnValue = "Estado de Anclaje";
                    // Pinned state
                    break;
                case RadGridStringId.PinAtLeftMenuItem:
                    functionReturnValue = "Anlar a izquierda";
                    // Pin at left
                    break;
                case RadGridStringId.PinAtRightMenuItem:
                    functionReturnValue = "Anlar a derecha";
                    // Pin at right
                    break;
                case RadGridStringId.PinAtBottomMenuItem:
                    functionReturnValue = "Anlar al pie";
                    // Pin at bottom
                    break;
                case RadGridStringId.PinAtTopMenuItem:
                    functionReturnValue = "Anlar a la cabezera";
                    // Pin at top
                    break;
                case RadGridStringId.BestFitMenuItem:
                    functionReturnValue = "Mejor Ajuste";
                    // Best Fit
                    break;
                case RadGridStringId.PasteMenuItem:
                    functionReturnValue = "Pegar";
                    // Paste
                    break;
                case RadGridStringId.EditMenuItem:
                    functionReturnValue = "Editar";
                    // Edit
                    break;
                case RadGridStringId.ClearValueMenuItem:
                    functionReturnValue = "Limpiar Valor";
                    // Clear Value
                    break;
                case RadGridStringId.CopyMenuItem:
                    functionReturnValue = "Copiar";
                    // Copy
                    break;
                case RadGridStringId.CutMenuItem:
                    functionReturnValue = "Cortar";
                    // Cut
                    break;
                case RadGridStringId.AddNewRowString:
                    functionReturnValue = "Click aqui para añadir una nueva fila";
                    // Click here to add a new row
                    break;
                case RadGridStringId.SearchRowResultsOfLabel:
                    functionReturnValue = "de";
                    // of
                    break;
                case RadGridStringId.SearchRowMatchCase:
                    functionReturnValue = "Coincide caso";
                    // Match case
                    break;
                case RadGridStringId.ConditionalFormattingSortAlphabetically:
                    functionReturnValue = "Ordenar columnas alfabeticamente";
                    // Sort columns alphabetically
                    break;
                case RadGridStringId.ConditionalFormattingCaption:
                    functionReturnValue = "Asistente de Fromato de Reglas Condicionales";
                    // Conditional Formatting Rules Manager
                    break;
                case RadGridStringId.ConditionalFormattingLblColumn:
                    functionReturnValue = "Dar Formato solo a celdas con";
                    // Format only cells with
                    break;
                case RadGridStringId.ConditionalFormattingLblName:
                    functionReturnValue = "Nombre de la Regla";
                    // Rule name
                    break;
                case RadGridStringId.ConditionalFormattingLblType:
                    functionReturnValue = "Valor de la Celda";
                    // Cell value
                    break;
                case RadGridStringId.ConditionalFormattingLblValue1:
                    functionReturnValue = "Valor 1";
                    // Value 1
                    break;
                case RadGridStringId.ConditionalFormattingLblValue2:
                    functionReturnValue = "Valor 2";
                    // Value 2
                    break;
                case RadGridStringId.ConditionalFormattingGrpConditions:
                    functionReturnValue = "Reglas";
                    // Rules
                    break;
                case RadGridStringId.ConditionalFormattingGrpProperties:
                    functionReturnValue = "Propiedades de las Reglas";
                    // Rule Properties
                    break;
                case RadGridStringId.ConditionalFormattingChkApplyToRow:
                    functionReturnValue = "Aplicar este formato a toda la fila";
                    // Apply this formatting to entire row
                    break;
                case RadGridStringId.ConditionalFormattingChkApplyOnSelectedRows:
                    functionReturnValue = "Aplicar este formato si la fila esta seleccionada";
                    // Apply this formatting if the row is selected
                    break;
                case RadGridStringId.ConditionalFormattingBtnAdd:
                    functionReturnValue = "Añadir nueva regla";
                    // Add new rule
                    break;
                case RadGridStringId.ConditionalFormattingBtnRemove:
                    functionReturnValue = "Eliminar";
                    // Remove
                    break;
                case RadGridStringId.ConditionalFormattingBtnOK:
                    functionReturnValue = "OK";
                    break;
                case RadGridStringId.ConditionalFormattingBtnCancel:
                    functionReturnValue = "Cancelar";
                    // Cancel
                    break;
                case RadGridStringId.ConditionalFormattingBtnApply:
                    functionReturnValue = "Aplicar";
                    // Apply
                    break;
                case RadGridStringId.ConditionalFormattingRuleAppliesOn:
                    functionReturnValue = "la Regla se aplica a";
                    // Rule applies to
                    break;
                case RadGridStringId.ConditionalFormattingCondition:
                    functionReturnValue = "Condición";
                    // Condition
                    break;
                case RadGridStringId.ConditionalFormattingExpression:
                    functionReturnValue = "Expresión";
                    // Expression
                    break;
                case RadGridStringId.ConditionalFormattingChooseOne:
                    functionReturnValue = "[Elige uno]";
                    // [Choose one]
                    break;
                case RadGridStringId.ConditionalFormattingEqualsTo:
                    functionReturnValue = "Igual a [Valor1]";
                    // Equals to [Value1]
                    break;
                case RadGridStringId.ConditionalFormattingIsNotEqualTo:
                    functionReturnValue = "Distinti de [Valor1]";
                    // Is not equal to [Value1]
                    break;
                case RadGridStringId.ConditionalFormattingStartsWith:
                    functionReturnValue = "Empieza por [Valor1]";
                    // Starts with [Value1]
                    break;
                case RadGridStringId.ConditionalFormattingEndsWith:
                    functionReturnValue = "Acaba con [Valor1]";
                    // Ends with [Value1]
                    break;
                case RadGridStringId.ConditionalFormattingContains:
                    functionReturnValue = "Contiene [Valor1]";
                    // Contains [Value1]
                    break;
                case RadGridStringId.ConditionalFormattingDoesNotContain:
                    functionReturnValue = "No contiene [Valor1]";
                    // Does not contain [Value1]
                    break;
                case RadGridStringId.ConditionalFormattingIsGreaterThan:
                    functionReturnValue = "Mayor que [Valor1]";
                    // Is greater than [Value1]
                    break;
                case RadGridStringId.ConditionalFormattingIsGreaterThanOrEqual:
                    functionReturnValue = "Mayor o igual que [Valor1]";
                    // Is greater than or equal [Value1]
                    break;
                case RadGridStringId.ConditionalFormattingIsLessThan:
                    functionReturnValue = "Menor que [Valor1]";
                    // Is less than [Value1]
                    break;
                case RadGridStringId.ConditionalFormattingIsLessThanOrEqual:
                    functionReturnValue = "Menor o igual que [Valor1]";
                    // Is less than or equal to [Value1]
                    break;
                case RadGridStringId.ConditionalFormattingIsBetween:
                    functionReturnValue = "Entre [Valor1] y [Valor2]";
                    // Is between [Value1] and [Value2]"
                    break;
                case RadGridStringId.ConditionalFormattingIsNotBetween:
                    functionReturnValue = "No esta entre [Valor1] y [Valor2]";
                    // Is not between [Value1] and [Value1]"
                    break;
                case RadGridStringId.ConditionalFormattingLblFormat:
                    functionReturnValue = "Formato";
                    // Format
                    break;

                case RadGridStringId.ConditionalFormattingBtnExpression:
                    functionReturnValue = "Editor de expresiones";
                    // Expression editor
                    break;
                case RadGridStringId.ConditionalFormattingTextBoxExpression:
                    functionReturnValue = "Expresión";
                    // Expression
                    break;

                case RadGridStringId.ConditionalFormattingPropertyGridCaseSensitive:
                    functionReturnValue = "Sensible a Mayusculas";
                    // Case Sensitive
                    break;
                case RadGridStringId.ConditionalFormattingPropertyGridCellBackColor:
                    functionReturnValue = "Celda-ColorFondo";
                    // CellBackColor
                    break;
                case RadGridStringId.ConditionalFormattingPropertyGridCellForeColor:
                    functionReturnValue = "Celda-ColorPrincipal";
                    // CellForeColor
                    break;
                case RadGridStringId.ConditionalFormattingPropertyGridEnabled:
                    functionReturnValue = "Habilitado";
                    // Enabled
                    break;
                case RadGridStringId.ConditionalFormattingPropertyGridRowBackColor:
                    functionReturnValue = "Fila-ColorFondo";
                    // RowBackColor
                    break;
                case RadGridStringId.ConditionalFormattingPropertyGridRowForeColor:
                    functionReturnValue = "Fila-ColorPrincipal";
                    // RowForeColor
                    break;
                case RadGridStringId.ConditionalFormattingPropertyGridRowTextAlignment:
                    functionReturnValue = "Fila-AlineacionTexto";
                    // RowTextAlignment
                    break;
                case RadGridStringId.ConditionalFormattingPropertyGridTextAlignment:
                    functionReturnValue = "AlineacionTexto";
                    // TextAlignment
                    break;

                case RadGridStringId.ConditionalFormattingPropertyGridCaseSensitiveDescription:
                    functionReturnValue = "Determina cuando las comparaciones de texto seran sensibles a las mayusculas";
                    // Determines whether case-sensitive comparisons will be made when evaluating string values.
                    break;
                case RadGridStringId.ConditionalFormattingPropertyGridCellBackColorDescription:
                    functionReturnValue = "Selecciona el color de fondo que sera usado para la celda";
                    // Enter the background color to be used for the cell.
                    break;
                case RadGridStringId.ConditionalFormattingPropertyGridCellForeColorDescription:
                    functionReturnValue = "Selecciona el color principal que sera usado para la celda";
                    // Enter the foreground color to be used for the cell.
                    break;
                case RadGridStringId.ConditionalFormattingPropertyGridEnabledDescription:
                    functionReturnValue = "Determines whether the condition is enabled (can be evaluated and applied).";
                    break;
                case RadGridStringId.ConditionalFormattingPropertyGridRowBackColorDescription:
                    functionReturnValue = "Selecciona el color de fondo que sera usado para toda la fila";
                    // "Enter the background color to be used for the entire row."
                    break;
                case RadGridStringId.ConditionalFormattingPropertyGridRowForeColorDescription:
                    functionReturnValue = "Selecciona el color principal que sera usado para toda la fila";
                    // "Enter the foreground color to be used for the entire row."
                    break;
                case RadGridStringId.ConditionalFormattingPropertyGridRowTextAlignmentDescription:
                    functionReturnValue = "Enter the alignment to be used for the cell values, when ApplyToRow is true.";
                    break;
                case RadGridStringId.ConditionalFormattingPropertyGridTextAlignmentDescription:
                    functionReturnValue = "Enter the alignment to be used for the cell values.";

                    break;
                case RadGridStringId.ColumnChooserFormCaption:
                    functionReturnValue = "Column Chooser";
                    break;
                case RadGridStringId.ColumnChooserFormMessage:
                    functionReturnValue = "Drag a column header from the grid here to remove it from the current view.";
                    break;
                case RadGridStringId.GroupingPanelDefaultMessage:
                    functionReturnValue = "Desplazar la columna aquí para Agrupar por esta columna.";
                    //"Drag a column here to group by this column."
                    break;
                case RadGridStringId.GroupingPanelHeader:
                    functionReturnValue = "Group by:";
                    break;
                case RadGridStringId.PagingPanelPagesLabel:
                    functionReturnValue = "Page";
                    break;
                case RadGridStringId.PagingPanelOfPagesLabel:
                    functionReturnValue = "of";
                    break;
                case RadGridStringId.NoDataText:
                    functionReturnValue = "No data to display";
                    break;
                case RadGridStringId.CompositeFilterFormErrorCaption:
                    functionReturnValue = "Filter Error";
                    break;
                case RadGridStringId.CompositeFilterFormInvalidFilter:
                    functionReturnValue = "The composite filter descriptor is not valid.";

                    break;
                case RadGridStringId.ExpressionMenuItem:
                    functionReturnValue = "Expression";
                    break;
                case RadGridStringId.ExpressionFormTitle:
                    functionReturnValue = "Expression Builder";
                    break;
                case RadGridStringId.ExpressionFormFunctions:
                    functionReturnValue = "Functions";
                    break;
                case RadGridStringId.ExpressionFormFunctionsText:
                    functionReturnValue = "Text";
                    break;
                case RadGridStringId.ExpressionFormFunctionsAggregate:
                    functionReturnValue = "Aggregate";
                    break;
                case RadGridStringId.ExpressionFormFunctionsDateTime:
                    functionReturnValue = "Date-Time";
                    break;
                case RadGridStringId.ExpressionFormFunctionsLogical:
                    functionReturnValue = "Logical";
                    break;
                case RadGridStringId.ExpressionFormFunctionsMath:
                    functionReturnValue = "Math";
                    break;
                case RadGridStringId.ExpressionFormFunctionsOther:
                    functionReturnValue = "Other";
                    break;
                case RadGridStringId.ExpressionFormOperators:
                    functionReturnValue = "Operators";
                    break;
                case RadGridStringId.ExpressionFormConstants:
                    functionReturnValue = "Constants";
                    break;
                case RadGridStringId.ExpressionFormFields:
                    functionReturnValue = "Fields";
                    break;
                case RadGridStringId.ExpressionFormDescription:
                    functionReturnValue = "Description";
                    break;
                case RadGridStringId.ExpressionFormResultPreview:
                    functionReturnValue = "Result preview";
                    break;
                case RadGridStringId.ExpressionFormTooltipPlus:
                    functionReturnValue = "Plus";
                    break;
                case RadGridStringId.ExpressionFormTooltipMinus:
                    functionReturnValue = "Minus";
                    break;
                case RadGridStringId.ExpressionFormTooltipMultiply:
                    functionReturnValue = "Multiply";
                    break;
                case RadGridStringId.ExpressionFormTooltipDivide:
                    functionReturnValue = "Divide";
                    break;
                case RadGridStringId.ExpressionFormTooltipModulo:
                    functionReturnValue = "Modulo";
                    break;
                case RadGridStringId.ExpressionFormTooltipEqual:
                    functionReturnValue = "Equal";
                    break;
                case RadGridStringId.ExpressionFormTooltipNotEqual:
                    functionReturnValue = "Not Equal";
                    break;
                case RadGridStringId.ExpressionFormTooltipLess:
                    functionReturnValue = "Less";
                    break;
                case RadGridStringId.ExpressionFormTooltipLessOrEqual:
                    functionReturnValue = "Less Or Equal";
                    break;
                case RadGridStringId.ExpressionFormTooltipGreaterOrEqual:
                    functionReturnValue = "Greater Or Equal";
                    break;
                case RadGridStringId.ExpressionFormTooltipGreater:
                    functionReturnValue = "Greater";
                    break;
                case RadGridStringId.ExpressionFormTooltipAnd:
                    functionReturnValue = "Logical \"AND\"";
                    break;
                case RadGridStringId.ExpressionFormTooltipOr:
                    functionReturnValue = "Logical \"OR\"";
                    break;
                case RadGridStringId.ExpressionFormTooltipNot:
                    functionReturnValue = "Logical \"NOT\"";
                    break;
                case RadGridStringId.ExpressionFormAndButton:
                    functionReturnValue = string.Empty;
                    break;
                //if empty, default button image is used
                case RadGridStringId.ExpressionFormOrButton:
                    functionReturnValue = string.Empty;
                    break;
                //if empty, default button image is used
                case RadGridStringId.ExpressionFormNotButton:
                    functionReturnValue = string.Empty;
                    break;
                //if empty, default button image is used
                case RadGridStringId.ExpressionFormOKButton:
                    functionReturnValue = "OK";
                    break;
                case RadGridStringId.ExpressionFormCancelButton:
                    functionReturnValue = "Cancel";
                    break;
                default:
                    functionReturnValue = string.Empty;
                    break;
            }

            //return Translate(GetLocalizedString());
            return functionReturnValue;
        }

    }
}