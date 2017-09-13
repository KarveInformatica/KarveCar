Imports CustomControls

Public Class defGridLupaBloquesFacturacion
    Inherits Definicion

    Protected Overrides Sub SetColumns(ByRef dgcColumns As CustomControls.DataGridColumns, ByRef colRelation As CustomControls.DataGridTextBoxColumn, ByRef dgcgGroups As CustomControls.DataGridColumnGroups)
        Dim Cols As New Definiciones.ColumnasBloquesFacturacion

        dgcColumns.Add(Cols.CodigoBloqueFacturacion)
        dgcColumns.Add(Cols.NombreBloqueFacturacion)

    End Sub

    Protected Overrides Sub SetRules(ByRef dgrRules As CustomControls.DataGridRules)

    End Sub

    Protected Overrides Sub SetOrdenes(ByRef dgoOrdenes As CustomControls.DataGridOrdenColumnas)
        Dim Cols As New Definiciones.OrdenesBloquesFacturacion
        dgoOrdenes.Add(Cols.OrdenNomBloqueFac)
    End Sub

    Protected Overrides Sub SetTables(ByRef dgtTables As CustomControls.DataGridTables, ByRef tbEdit As CustomControls.DataGridTable)
        Dim Tbls As New Definiciones.TablasBloquesFacturacion

        dgtTables.Add(Tbls.BloquesFacturacionFrom)

    End Sub
End Class
