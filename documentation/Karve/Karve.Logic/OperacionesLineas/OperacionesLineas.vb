Imports Karve.ConfiguracionApp

Public Class OperacionesLineas

    Private _bases As New DataTable
    Private _totales As New DataTable

    Public Function calculaBases(ByRef lineas As DataTable) As DataTable
        _bases.Rows.Clear()

        Dim ivas = From rows As DataRow In lineas.Rows
                    Where rows.RowState <> DataRowState.Deleted
                    Select rows.Item("Iva") Distinct.ToArray

        For Each iva In ivas
            Dim row As DataRow
            row = _bases.NewRow()

            Dim base = (From existingRows As DataRow In (From rows As DataRow In lineas.Rows
                                                        Where rows.RowState <> DataRowState.Deleted
                                                        Select rows)
                        Where IIf(IsDBNull(existingRows.Item("Iva")), -1, existingRows.Item("Iva")) = IIf(IsDBNull(iva), -1, iva)
                        Select existingRows.Item("SUBTOTAL")).Sum(Function(r) CDbl(r))

            row.Item("Base") = Math.Round(base, decimalesTotales)
            row.Item("Iva") = iva
            row.Item("Cuota") = Math.Round(row.Item("Base") * IIf(IsDBNull(iva), 0, iva) / 100, decimalesTotales)
            _bases.Rows.Add(row)
        Next

        Return _bases
    End Function

    Public Function calculaBruto(ByRef lineas As DataTable) As Double
        calculaBruto = (From rows As DataRow In lineas.Rows
                        Where rows.RowState <> DataRowState.Deleted
                        Select rows.Item("SUBTOTAL")).Sum(Function(r) CDbl(r))
        calculaBruto = Math.Round(calculaBruto, decimalesTotales)
    End Function

    Public Function calculaTotales(ByVal idEdit As String, ByRef bases As DataTable, ByRef basesLineas As DataTable, ByVal bruto As Double, ByVal dtoPP As Double, ByVal dtoPie As Double) As DataTable
        _totales.Rows.Clear()
        Dim dtoPPImp As Decimal
        Dim dtoPieImp As Decimal
        Dim rowTot As DataRow
        rowTot = _totales.NewRow()

        rowTot.Item("BaseSin") = 0

        For Each row As DataRow In basesLineas.Rows
            Dim newRow As DataRow
            Dim rowExists As Boolean = False

            If IsDBNull(row.Item("Iva")) Then
                dtoPPImp = Math.Round(row.Item("Base") * dtoPP / 100, decimalesTotales)
                dtoPieImp = Math.Round(row.Item("Base") * dtoPie / 100, decimalesTotales)

                rowTot.Item("BaseSin") = row.Item("Base") - dtoPPImp - dtoPieImp

            Else
                Try

                    newRow = (From existingRows In (From rows As DataRow In bases.Rows
                                                    Where rows.RowState <> DataRowState.Deleted
                                                    Select rows)
                                Where existingRows.Item("IVAPOR") = IIf(IsDBNull(row.Item("Iva")), -1, row.Item("Iva"))
                                Select existingRows).First

                Catch
                    newRow = Nothing
                End Try

                If Not IsNothing(newRow) Then
                    rowExists = True
                Else
                    newRow = bases.NewRow()
                End If

                dtoPPImp = Math.Round(row.Item("Base") * dtoPP / 100, decimalesTotales)
                dtoPieImp = Math.Round(row.Item("Base") * dtoPie / 100, decimalesTotales)
                newRow.Item("BASE") = Math.Round(row.Item("Base") - dtoPPImp - dtoPieImp, decimalesTotales)
                newRow.Item("IVAPOR") = row.Item("Iva")
                newRow.Item("NUMERO") = idEdit
                newRow.Item("CUOTA") = Math.Round(newRow.Item("BASE") * newRow.Item("IVAPOR") / 100, decimalesTotales)
                If Not rowExists Then
                    newRow.Item("RECARGO") = 0

                    'newRow.Item("PUNTO_VERDE_BF") = 0
                End If
                newRow.Item("CUORECA") = Math.Round(row.Item("Base") * newRow.Item("RECARGO") / 100, decimalesTotales)
                newRow.Item("SUBTOTAL") = Math.Round(newRow.Item("BASE") + newRow.Item("CUOTA") + newRow.Item("CUORECA"), decimalesTotales)
                If Not rowExists Then
                    bases.Rows.Add(newRow)
                End If
            End If
        Next

        For Each row As DataRow In bases.Rows
            If row.RowState <> DataRowState.Deleted Then
                Dim rowExists As Boolean = False

                rowExists = (From existingRows In (From rows As DataRow In basesLineas.Rows
                                                    Where rows.RowState <> DataRowState.Deleted
                                                    Select rows)
                                Where IIf(IsDBNull(existingRows.Item("Iva")), -1, existingRows.Item("Iva")) = row.Item("IVAPOR")
                                Select existingRows).Count

                If Not rowExists Then
                    row.Delete()
                End If
            End If
        Next

        'bases.AcceptChanges()

        rowTot.Item("DtoPP") = Math.Round(bruto * dtoPP / 100, decimalesTotales)
        rowTot.Item("DtoPie") = Math.Round(bruto * dtoPie / 100, decimalesTotales)

        rowTot.Item("Total") = Math.Round((From rows As DataRow In bases.Rows
                            Where rows.RowState <> DataRowState.Deleted
                            Select rows.Item("SUBTOTAL")).Sum(Function(r) CDbl(r)) + rowTot.Item("BaseSin"), decimalesTotales)

        _totales.Rows.Add(rowTot)
        Return _totales
    End Function

    Public Sub New()
        Dim col As DataColumn

        col = New DataColumn
        col.ColumnName = "Base"
        col.DataType = GetType(System.Double)
        col.ReadOnly = True
        _bases.Columns.Add(col)

        col = New DataColumn
        col.ColumnName = "Iva"
        col.DataType = GetType(System.Double)
        col.ReadOnly = True
        _bases.Columns.Add(col)

        col = New DataColumn
        col.ColumnName = "Cuota"
        col.DataType = GetType(System.Double)
        col.ReadOnly = True
        _bases.Columns.Add(col)

        col = New DataColumn
        col.ColumnName = "DtoPP"
        col.DataType = GetType(System.Double)
        col.ReadOnly = True
        _totales.Columns.Add(col)

        col = New DataColumn
        col.ColumnName = "DtoPie"
        col.DataType = GetType(System.Double)
        col.ReadOnly = True
        _totales.Columns.Add(col)

        col = New DataColumn
        col.ColumnName = "BaseSin"
        col.DataType = GetType(System.Double)
        col.ReadOnly = True
        _totales.Columns.Add(col)

        col = New DataColumn
        col.ColumnName = "Total"
        col.DataType = GetType(System.Double)
        col.ReadOnly = True
        _totales.Columns.Add(col)
    End Sub

End Class

