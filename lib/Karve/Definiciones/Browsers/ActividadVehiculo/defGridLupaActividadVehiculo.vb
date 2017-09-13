Imports CustomControls

Public Class defGridLupaActividadVehiculo
    Inherits Definicion

    Protected Overrides Sub SetColumns(ByRef dgcColumns As CustomControls.DataGridColumns, ByRef colRelation As CustomControls.DataGridTextBoxColumn, ByRef dgcgGroups As CustomControls.DataGridColumnGroups)
        Dim Cols As New Definiciones.ColumnasActividadVehiculo

        dgcColumns.Add(Cols.CodigoActividadVehiculo)
        dgcColumns.Add(Cols.NombreActividadVehiculo)
        dgcColumns.Add(Cols.CalcOcupaActividadVehiculo)
        dgcColumns.Add(Cols.ActAlqActividadVehiculo)
        'dgcColumns.Add(Cols.CodTariActActividadVehiculo)

    End Sub

    Protected Overrides Sub SetRules(ByRef dgrRules As CustomControls.DataGridRules)

    End Sub

    Protected Overrides Sub SetOrdenes(ByRef dgoOrdenes As CustomControls.DataGridOrdenColumnas)
        Dim Cols As New Definiciones.OrdenesActividadVehiculo
        dgoOrdenes.Add(Cols.OrdenNomActividad)
    End Sub

    Protected Overrides Sub SetTables(ByRef dgtTables As CustomControls.DataGridTables, ByRef tbEdit As CustomControls.DataGridTable)
        Dim Tbls As New Definiciones.TablasActividadVehiculo

        dgtTables.Add(Tbls.ActividadesVehiculoFrom)

    End Sub

End Class