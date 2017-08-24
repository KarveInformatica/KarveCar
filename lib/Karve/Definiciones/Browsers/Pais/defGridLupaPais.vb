Imports CustomControls

Public Class defGridLupaPais
    Inherits Definicion

    Protected Overrides Sub SetColumns(ByRef dgcColumns As CustomControls.DataGridColumns, ByRef colRelation As CustomControls.DataGridTextBoxColumn, ByRef dgcgGroups As CustomControls.DataGridColumnGroups)
        Dim Cols As New Definiciones.ColumnasPais

        dgcColumns.Add(Cols.CodigoPais)
        dgcColumns.Add(Cols.SiglasPais)
        dgcColumns.Add(Cols.NombrePais)
        dgcColumns.Add(Cols.IdiomaPais)
        dgcColumns.Add(Cols.IntracomunitarioPais)
    End Sub

    Protected Overrides Sub SetRules(ByRef dgrRules As CustomControls.DataGridRules)

    End Sub

    Protected Overrides Sub SetOrdenes(ByRef dgoOrdenes As CustomControls.DataGridOrdenColumnas)
        Dim Cols As New Definiciones.OrdenesPais
        dgoOrdenes.Add(Cols.OrdenCodigoPais)
        dgoOrdenes.Add(Cols.OrdenNombrePais)
    End Sub

    Protected Overrides Sub SetTables(ByRef dgtTables As CustomControls.DataGridTables, ByRef tbEdit As CustomControls.DataGridTable)
        Dim Tbls As New Definiciones.TablasPais

        dgtTables.Add(Tbls.PaisFrom)
        dgtTables.Add(Tbls.Idiomas)
    End Sub
End Class
