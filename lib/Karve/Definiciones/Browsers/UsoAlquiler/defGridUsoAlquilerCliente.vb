Imports CustomControls

Public Class defGridUsoAlquilerCliente
    Inherits Definicion

    Protected Overrides Sub SetColumns(ByRef dgcColumns As CustomControls.DataGridColumns, ByRef colRelation As CustomControls.DataGridTextBoxColumn, ByRef dgcgGroups As CustomControls.DataGridColumnGroups)
        Dim Cols As New Definiciones.ColumnasUsoAlquilerCliente

        dgcColumns.Add(Cols.CodigoUsoAlqCliente)
        dgcColumns.Add(Cols.NombreUsoAlqCliente)

    End Sub

    Protected Overrides Sub SetRules(ByRef dgrRules As CustomControls.DataGridRules)

    End Sub

    Protected Overrides Sub SetOrdenes(ByRef dgoOrdenes As CustomControls.DataGridOrdenColumnas)

    End Sub

    Protected Overrides Sub SetTables(ByRef dgtTables As CustomControls.DataGridTables, ByRef tbEdit As CustomControls.DataGridTable)
        Dim Tbls As New Definiciones.TablasUsoAlquilerCliente

        dgtTables.Add(Tbls.UsoAlquilerClienteFrom)

    End Sub
End Class
