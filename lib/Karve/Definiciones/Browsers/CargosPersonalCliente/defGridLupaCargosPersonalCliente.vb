Imports CustomControls

Public Class defGridLupaCargosPersonalCliente
    Inherits Definicion

    Protected Overrides Sub SetColumns(ByRef dgcColumns As CustomControls.DataGridColumns, ByRef colRelation As CustomControls.DataGridTextBoxColumn, ByRef dgcgGroups As CustomControls.DataGridColumnGroups)
        Dim Cols As New Definiciones.ColumnasCargosPersonalCliente

        dgcColumns.Add(Cols.CodigoCargosPersonalCliente)
        dgcColumns.Add(Cols.NombreCargosPersonalCliente)

    End Sub

    Protected Overrides Sub SetRules(ByRef dgrRules As CustomControls.DataGridRules)

    End Sub

    Protected Overrides Sub SetOrdenes(ByRef dgoOrdenes As CustomControls.DataGridOrdenColumnas)
        Dim Cols As New Definiciones.OrdenesCargosPersonalCliente
        dgoOrdenes.Add(Cols.OrdenNomCanalCliente)
    End Sub

    Protected Overrides Sub SetTables(ByRef dgtTables As CustomControls.DataGridTables, ByRef tbEdit As CustomControls.DataGridTable)
        Dim Tbls As New Definiciones.TablasCargosPersonalCliente

        dgtTables.Add(Tbls.CargosPersonalFrom)

    End Sub
End Class
