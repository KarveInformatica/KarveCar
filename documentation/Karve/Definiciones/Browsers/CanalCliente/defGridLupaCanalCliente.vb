Imports CustomControls

Public Class defGridLupaCanalCliente
    Inherits Definicion

    Protected Overrides Sub SetColumns(ByRef dgcColumns As CustomControls.DataGridColumns, ByRef colRelation As CustomControls.DataGridTextBoxColumn, ByRef dgcgGroups As CustomControls.DataGridColumnGroups)
        Dim Cols As New Definiciones.ColumnasCanalCliente

        dgcColumns.Add(Cols.CodigoCanalCliente)
        dgcColumns.Add(Cols.NombreCanalCliente)

    End Sub

    Protected Overrides Sub SetRules(ByRef dgrRules As CustomControls.DataGridRules)

    End Sub

    Protected Overrides Sub SetOrdenes(ByRef dgoOrdenes As CustomControls.DataGridOrdenColumnas)
        Dim Cols As New Definiciones.OrdenesCanalCliente
        dgoOrdenes.Add(Cols.OrdenNomCanalCliente)
    End Sub

    Protected Overrides Sub SetTables(ByRef dgtTables As CustomControls.DataGridTables, ByRef tbEdit As CustomControls.DataGridTable)
        Dim Tbls As New Definiciones.TablasCanalCliente

        dgtTables.Add(Tbls.CanalClienteFrom)

    End Sub
End Class
