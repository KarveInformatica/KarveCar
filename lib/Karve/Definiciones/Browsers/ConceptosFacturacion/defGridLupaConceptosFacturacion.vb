Public Class defGridLupaConceptosFacturacion
    Inherits Definicion

    Protected Overrides Sub SetColumns(ByRef dgcColumns As CustomControls.DataGridColumns, ByRef colRelation As CustomControls.DataGridTextBoxColumn, ByRef dgcgGroups As CustomControls.DataGridColumnGroups)
        Dim Cols As New Definiciones.ColumnasConceptosFacturacion

        dgcColumns.Add(Cols.CodigoConceptosFacturacion)
        dgcColumns.Add(Cols.NombreConceptosFacturacion)

    End Sub

    Protected Overrides Sub SetOrdenes(ByRef dgoOrdenes As CustomControls.DataGridOrdenColumnas)
        Dim Cols As New Definiciones.OrdenesConceptosFacturacion

        dgoOrdenes.Add(Cols.OrdenCodigoConcepto)
        dgoOrdenes.Add(Cols.OrdenNombreConcepto)

    End Sub

    Protected Overrides Sub SetRules(ByRef dgrRules As CustomControls.DataGridRules)

    End Sub

    Protected Overrides Sub SetTables(ByRef dgtTables As CustomControls.DataGridTables, ByRef tbEdit As CustomControls.DataGridTable)
        Dim Tbls As New Definiciones.TablasConceptosFacturacion

        dgtTables.Add(Tbls.ConceptosFacturacionFrom)

    End Sub

End Class
