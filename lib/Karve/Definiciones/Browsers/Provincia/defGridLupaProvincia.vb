Imports CustomControls

Public Class defGridLupaProvincia
    Inherits Definicion

    Protected Overrides Sub SetColumns(ByRef dgcColumns As CustomControls.DataGridColumns, ByRef colRelation As CustomControls.DataGridTextBoxColumn, ByRef dgcgGroups As CustomControls.DataGridColumnGroups)
        Dim Cols As New Definiciones.ColumnasProvincia

        dgcColumns.Add(Cols.CodigoProvincia)
        dgcColumns.Add(Cols.SiglasProvincia)
        dgcColumns.Add(Cols.NombreProvincia)
        dgcColumns.Add(Cols.CapitalProvincia)
        dgcColumns.Add(Cols.PaisProvincia)
    End Sub

    Protected Overrides Sub SetRules(ByRef dgrRules As CustomControls.DataGridRules)

    End Sub

    Protected Overrides Sub SetOrdenes(ByRef dgoOrdenes As CustomControls.DataGridOrdenColumnas)

    End Sub

    Protected Overrides Sub SetTables(ByRef dgtTables As CustomControls.DataGridTables, ByRef tbEdit As CustomControls.DataGridTable)
        Dim Tbls As New Definiciones.TablasProvincia

        dgtTables.Add(Tbls.ProvinciaFrom)
        dgtTables.Add(Tbls.Pais)
    End Sub
End Class
