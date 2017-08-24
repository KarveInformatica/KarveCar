Imports CustomControls

Public Class defGridLupaActividadCliente
    Inherits Definicion

    Protected Overrides Sub SetColumns(ByRef dgcColumns As CustomControls.DataGridColumns, ByRef colRelation As CustomControls.DataGridTextBoxColumn, ByRef dgcgGroups As DataGridColumnGroups)
        Dim Cols As New Definiciones.ColumnasActividadCliente

        dgcColumns.Add(Cols.CodigoActividadCliente)
        dgcColumns.Add(Cols.NombreActividadCliente)

    End Sub

    Protected Overrides Sub SetRules(ByRef dgrRules As CustomControls.DataGridRules)

    End Sub

    Protected Overrides Sub SetOrdenes(ByRef dgoOrdenes As CustomControls.DataGridOrdenColumnas)
        Dim Cols As New Definiciones.OrdenesActividadCliente
        dgoOrdenes.Add(Cols.OrdenNomActividad)
    End Sub

    Protected Overrides Sub SetTables(ByRef dgtTables As CustomControls.DataGridTables, ByRef tbEdit As CustomControls.DataGridTable)
        Dim Tbls As New Definiciones.TablasActividadCliente

        dgtTables.Add(Tbls.ActividadesClienteFrom)

    End Sub
End Class
