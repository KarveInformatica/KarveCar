Imports CustomControls
Public Class defGridLires
    Inherits Definicion

    Protected Overrides Sub SetColumns(ByRef dgcColumns As CustomControls.DataGridColumns, ByRef colRelation As DataGridTextBoxColumn, ByRef dgcgGroups As CustomControls.DataGridColumnGroups)
        Dim cols As New ColumnasLires
        Dim colRel As DataGridBrowseBoxColumn
        Dim tmp As Object

        colRel = cols.ConceptoLiRes
        dgcColumns.Add(colRel)
        colRel.RelatedColumn = cols.DescripcionLiRes
        dgcColumns.Add(colRel.RelatedColumn)

        dgcColumns.Add(cols.IncluidoLiRes)
        dgcColumns.Add(cols.UnidadLiRes)
        dgcColumns.Add(cols.CantidadLiRes)
        dgcColumns.Add(cols.PrecioLiRes)
        dgcColumns.Add(cols.DtoLiRes)
        dgcColumns.Add(cols.IvaLiRes)
        dgcColumns.Add(cols.SubtotalLiRes)

        dgcColumns.Add(cols.GruposLiRes)
        dgcColumns.Add(cols.TarifasLiRes)

        tmp = cols.ReservaLiRes
        dgcColumns.Add(tmp)
        colRelation = tmp
        dgcColumns.Add(cols.PKLiRes)
    End Sub

    Protected Overrides Sub SetRules(ByRef dgrRules As CustomControls.DataGridRules)

    End Sub

    Protected Overrides Sub SetOrdenes(ByRef dgrOder As CustomControls.DataGridOrdenColumnas)

    End Sub

    Protected Overrides Sub SetTables(ByRef dgtTables As CustomControls.DataGridTables, ByRef tbEdit As DataGridTable)
        Dim tablas As New TablasLires
        Dim tmp As Object

        tmp = tablas.LiRes
        dgtTables.Add(tmp)
        tbEdit = tmp
    End Sub
End Class
