Imports CustomControls

Public Class defGridLupaClavesPresupuesto
    Inherits Definicion

    Protected Overrides Sub SetColumns(ByRef dgcColumns As CustomControls.DataGridColumns, ByRef colRelation As CustomControls.DataGridTextBoxColumn, ByRef dgcgGroups As CustomControls.DataGridColumnGroups)
        Dim Cols As New Definiciones.ColumnasClavesPresupuesto

        dgcColumns.Add(Cols.CodigoClavesPresupuesto)
        dgcColumns.Add(Cols.NombreClavesPresupuesto)

    End Sub

    Protected Overrides Sub SetRules(ByRef dgrRules As CustomControls.DataGridRules)

    End Sub

    Protected Overrides Sub SetOrdenes(ByRef dgoOrdenes As CustomControls.DataGridOrdenColumnas)
        Dim Cols As New Definiciones.OrdenesClavesPresupuesto
        dgoOrdenes.Add(Cols.OrdenCodClave)
    End Sub

    Protected Overrides Sub SetTables(ByRef dgtTables As CustomControls.DataGridTables, ByRef tbEdit As CustomControls.DataGridTable)
        Dim Tbls As New Definiciones.TablasClavesPresupuesto

        dgtTables.Add(Tbls.ClavesPresupuestoFrom)

    End Sub
End Class