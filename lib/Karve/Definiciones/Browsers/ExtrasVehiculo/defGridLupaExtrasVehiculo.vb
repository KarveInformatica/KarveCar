Public Class defGridLupaExtrasVehiculo
    Inherits Definicion

    Protected Overrides Sub SetColumns(ByRef dgcColumns As CustomControls.DataGridColumns, ByRef colRelation As CustomControls.DataGridTextBoxColumn, ByRef dgcgGroups As CustomControls.DataGridColumnGroups)
        Dim Cols As New Definiciones.ColumnasExtrasVehiculo

        dgcColumns.Add(Cols.CodigoExtrasVehiculo)
        dgcColumns.Add(Cols.NombreExtrasVehiculo)
        dgcColumns.Add(Cols.ReferenciaExtrasVehiculo)
        dgcColumns.Add(Cols.TipoVehExtrasVehiculo)
    End Sub

    Protected Overrides Sub SetRules(ByRef dgrRules As CustomControls.DataGridRules)

    End Sub

    Protected Overrides Sub SetOrdenes(ByRef dgoOrdenes As CustomControls.DataGridOrdenColumnas)
        Dim Cols As New Definiciones.OrdenesExtrasVehiculo
        dgoOrdenes.Add(Cols.OrdenNombreExtras)
    End Sub

    Protected Overrides Sub SetTables(ByRef dgtTables As CustomControls.DataGridTables, ByRef tbEdit As CustomControls.DataGridTable)
        Dim Tbls As New Definiciones.TablasExtrasVehiculo

        dgtTables.Add(Tbls.ExtrasVehiculoFrom)
        dgtTables.Add(Tbls.TiposVehiculo)

    End Sub
End Class
