Imports CustomControls

Public Class defGridLupaTarjetasCredito
    Inherits Definicion

    Protected Overrides Sub SetColumns(ByRef dgcColumns As CustomControls.DataGridColumns, ByRef colRelation As CustomControls.DataGridTextBoxColumn, ByRef dgcgGroups As CustomControls.DataGridColumnGroups)
        Dim Cols As New Definiciones.ColumnasTarjetasCredito

        dgcColumns.Add(Cols.CodigoTarjetasCredito)
        dgcColumns.Add(Cols.NombreTarjetasCredito)

    End Sub

    Protected Overrides Sub SetRules(ByRef dgrRules As CustomControls.DataGridRules)

    End Sub

    Protected Overrides Sub SetOrdenes(ByRef dgoOrdenes As CustomControls.DataGridOrdenColumnas)
        Dim Cols As New Definiciones.OrdenesTarjetasCredito
        dgoOrdenes.Add(Cols.OrdenNomTarjetasCredito)
    End Sub

    Protected Overrides Sub SetTables(ByRef dgtTables As CustomControls.DataGridTables, ByRef tbEdit As CustomControls.DataGridTable)
        Dim Tbls As New Definiciones.TablasTarjetasCredito

        dgtTables.Add(Tbls.TarjetasCreditoFrom)

    End Sub
End Class
