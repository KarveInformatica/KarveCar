Imports CustomControls
Public Class defGridCliDelegaciones
    Inherits Definicion

    Protected Overrides Sub SetColumns(ByRef dgcColumns As CustomControls.DataGridColumns, ByRef colRelation As DataGridTextBoxColumn, ByRef dgcgGroups As CustomControls.DataGridColumnGroups)
        Dim cols As New ColumnasCliDelega
        Dim colRel As DataGridBrowseBoxColumn
        Dim tmp As Object

        dgcColumns.Add(cols.NumeroDelega)
        dgcColumns.Add(cols.NombreDelega)
        dgcColumns.Add(cols.DireccionDelega)
        dgcColumns.Add(cols.Direccion2Delega)
        dgcColumns.Add(cols.CPDelega)
        dgcColumns.Add(cols.PoblacionDelega)

        colRel = cols.CodigoProvinciaDelega
        dgcColumns.Add(colRel)
        colRel.RelatedColumn = cols.ProvinciaDelega
        dgcColumns.Add(colRel.RelatedColumn)

        colRel = cols.CodigoPaisDelega
        dgcColumns.Add(colRel)
        colRel.RelatedColumn = cols.PaisDelega
        dgcColumns.Add(colRel.RelatedColumn)

        tmp = cols.ClienteDelega
        dgcColumns.Add(tmp)
        colRelation = tmp
    End Sub

    Protected Overrides Sub SetRules(ByRef dgrRules As CustomControls.DataGridRules)

    End Sub

    Protected Overrides Sub SetOrdenes(ByRef dgrRules As CustomControls.DataGridOrdenColumnas)

    End Sub

    Protected Overrides Sub SetTables(ByRef dgtTables As CustomControls.DataGridTables, ByRef tbEdit As DataGridTable)
        Dim tablas As New TablasCliDelega
        Dim tmp As Object

        tmp = tablas.CliDelega
        dgtTables.Add(tmp)
        tbEdit = tmp

        dgtTables.Add(tablas.Provincia)

        dgtTables.Add(tablas.Pais)
    End Sub
End Class
