Public Class defGridLupaTiposVehiculo
    Inherits Definicion

    Protected Overrides Sub SetColumns(ByRef dgcColumns As CustomControls.DataGridColumns, ByRef colRelation As CustomControls.DataGridTextBoxColumn, ByRef dgcgGroups As CustomControls.DataGridColumnGroups)
        Dim Cols As New Definiciones.ColumnasTiposVehiculo

        dgcColumns.Add(Cols.CodigoTiposVehiculo)
        dgcColumns.Add(Cols.NombreTiposVehiculo)

    End Sub

    Protected Overrides Sub SetRules(ByRef dgrRules As CustomControls.DataGridRules)

    End Sub

    Protected Overrides Sub SetOrdenes(ByRef dgoOrdenes As CustomControls.DataGridOrdenColumnas)
        Dim Cols As New Definiciones.OrdenesTiposVehiculo
        dgoOrdenes.Add(Cols.OrdenNomTiposVehiculo)
    End Sub

    Protected Overrides Sub SetTables(ByRef dgtTables As CustomControls.DataGridTables, ByRef tbEdit As CustomControls.DataGridTable)
        Dim Tbls As New Definiciones.TablasTiposVehiculo

        dgtTables.Add(Tbls.TiposVehiculoFrom)

    End Sub
End Class
