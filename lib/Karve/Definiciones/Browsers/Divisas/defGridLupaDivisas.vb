Public Class defGridLupaDivisas
    Inherits Definicion

    Protected Overrides Sub SetColumns(ByRef dgcColumns As CustomControls.DataGridColumns, ByRef colRelation As CustomControls.DataGridTextBoxColumn, ByRef dgcgGroups As CustomControls.DataGridColumnGroups)
        Dim Cols As New Definiciones.ColumnasDivisas

        dgcColumns.Add(Cols.CodigoDivisas)
        dgcColumns.Add(Cols.NombreDivisas)
        dgcColumns.Add(Cols.CompraDivisas)
        dgcColumns.Add(Cols.VentaDivisas)
    End Sub

    Protected Overrides Sub SetRules(ByRef dgrRules As CustomControls.DataGridRules)

    End Sub

    Protected Overrides Sub SetOrdenes(ByRef dgoOrdenes As CustomControls.DataGridOrdenColumnas)
        Dim Cols As New Definiciones.OrdenesDivisas

        dgoOrdenes.Add(Cols.OrdenNombreDivisas)
    End Sub

    Protected Overrides Sub SetTables(ByRef dgtTables As CustomControls.DataGridTables, ByRef tbEdit As CustomControls.DataGridTable)
        Dim Tbls As New Definiciones.TablasDivisas

        dgtTables.Add(Tbls.DivisasFrom)
    End Sub
End Class
