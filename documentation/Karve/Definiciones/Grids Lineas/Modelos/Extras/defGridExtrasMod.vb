Imports CustomControls
Public Class defGridExtrasMod
    Inherits Definicion

    Protected Overrides Sub SetColumns(ByRef dgcColumns As CustomControls.DataGridColumns, ByRef colRelation As DataGridTextBoxColumn, ByRef dgcgGroups As CustomControls.DataGridColumnGroups)
        Dim cols As New ColumnasExtrasMod
        Dim colRel As DataGridBrowseBoxColumn
        Dim tmp As Object

        tmp = cols.CodMod
        dgcColumns.Add(tmp)
        colRelation = tmp

        colRel = cols.CodExtra
        dgcColumns.Add(colRel)
        colRel.RelatedColumn = cols.NombreExtra
        dgcColumns.Add(colRel.RelatedColumn)

        dgcColumns.Add(cols.PrecioExtra)
        dgcColumns.Add(cols.DeserieExtra)
        dgcColumns.Add(cols.ObsExtra)
        dgcColumns.Add(cols.UsuarioExtra)
        dgcColumns.Add(cols.UltmodiExtra)





    End Sub

    Protected Overrides Sub SetRules(ByRef dgrRules As CustomControls.DataGridRules)

    End Sub

    Protected Overrides Sub SetOrdenes(ByRef dgrRules As CustomControls.DataGridOrdenColumnas)

    End Sub

    Protected Overrides Sub SetTables(ByRef dgtTables As CustomControls.DataGridTables, ByRef tbEdit As DataGridTable)
        Dim tablas As New TablasExtrasMod
        Dim tmp As Object

        tmp = tablas.ExtraMod
        dgtTables.Add(tmp)
        tbEdit = tmp

        dgtTables.Add(tablas.Extras)

    End Sub
End Class
