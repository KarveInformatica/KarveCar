
Public Class defGridLupaFormasProvee
    Inherits Definicion

    Protected Overrides Sub SetColumns(ByRef dgcColumns As CustomControls.DataGridColumns, ByRef colRelation As CustomControls.DataGridTextBoxColumn, ByRef dgcgGroups As CustomControls.DataGridColumnGroups)
        Dim columns As New ColumnasFormasProvee
        dgcColumns.Add(columns.CodigoFormasProvee)
        dgcColumns.Add(columns.NombreFormasProvee)
        dgcColumns.Add(columns.CtaGastoFormasProvee)
    End Sub

    Protected Overrides Sub SetOrdenes(ByRef dgoOrdenes As CustomControls.DataGridOrdenColumnas)
        Dim Cols As New Definiciones.OrdenesFormasProvee
        dgoOrdenes.Add(Cols.OrdenFormasProvee)
    End Sub

    Protected Overrides Sub SetRules(ByRef dgrRules As CustomControls.DataGridRules)

    End Sub

    Protected Overrides Sub SetTables(ByRef dgtTables As CustomControls.DataGridTables, ByRef tbEdit As CustomControls.DataGridTable)
        Dim tables As New Definiciones.TablasFormasProvee

        dgtTables.Add(tables.FormasProveeFrom)
    End Sub
End Class
