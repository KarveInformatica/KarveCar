
Public Class defGridLupaGruposVehiculos
    Inherits Definicion

    Protected Overrides Sub SetColumns(ByRef dgcColumns As CustomControls.DataGridColumns, ByRef colRelation As CustomControls.DataGridTextBoxColumn, ByRef dgcgGroups As CustomControls.DataGridColumnGroups)
        Dim columns As New ColumnasGruposVehiculos
        dgcColumns.Add(columns.CodigoGrupo)
        dgcColumns.Add(columns.NombreGrupo)
    End Sub

    Protected Overrides Sub SetOrdenes(ByRef dgoOrdenes As CustomControls.DataGridOrdenColumnas)
        Dim Cols As New Definiciones.OrdenesGruposVehiculos
        dgoOrdenes.Add(Cols.OrdenGruposVehiculos)
    End Sub

    Protected Overrides Sub SetRules(ByRef dgrRules As CustomControls.DataGridRules)
        
    End Sub

    Protected Overrides Sub SetTables(ByRef dgtTables As CustomControls.DataGridTables, ByRef tbEdit As CustomControls.DataGridTable)
        Dim tables As New Definiciones.TablasGruposVehiculos

        dgtTables.Add(tables.GruposFrom)
    End Sub
End Class
