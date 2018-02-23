Imports Telerik.WinControls.UI
Imports Karve.Logic
Imports Karve.ConfiguracionApp

Public Class GridLiFacs
    Inherits CustomControls.DataGrid
    Private operLineas As New OperacionesLineas
    Private _bases As New DataTable
    Private _bruto As Double
    Public Event TotalesChanged()

    ReadOnly Property Bases As DataTable
        Get
            _bases = operLineas.calculaBases(Me.DataSource)
            Return _bases
        End Get
    End Property

    ReadOnly Property Bruto As Double
        Get
            _bruto = operLineas.calculaBruto(Me.DataSource)
            Return _bruto
        End Get
    End Property

    Protected Overrides Sub DefineGrid()

        Dim definition As New Definiciones.defGridLifacs

        dgcColumnas = definition.Columns
        ColRel = definition.ColumnRel

        dgtTablas = definition.Tables
        TablaEdit = definition.TablaEdit

        dgrClausulas = definition.Rules

    End Sub

    Protected Overrides Sub AddExtra(sender As Object, e As Telerik.WinControls.UI.GridViewRowCancelEventArgs)
        Dim i As Integer
        Try
            i = Me.Rows(Me.RowCount - 1).Cells(0).Value
        Catch ex As Exception
            i = 0
        End Try
        e.Rows(0).Cells(0).Value = i + 1
    End Sub

    Private Sub GridLiFacs_CellValueChanged(sender As Object, e As GridViewCellEventArgs) Handles Me.CellValueChanged
        Try
            If e.Row.RowElementType <> GetType(GridFilterRowElement) And e.Row.RowElementType <> GetType(GridNewRowElement) Then
                If e.Column.Name = "Cantidad" Or e.Column.Name = "Precio" Or e.Column.Name = "Dto" Or e.Column.Name = "Iva" Then
                    calcularSubtotalLin(e.Row)
                    recalcularTotal()
                End If
            End If
        Catch
        End Try
    End Sub

    Private Sub calcularSubtotalLin(row As GridViewRowInfo)
        Try
            If Not IsNothing(row) Then
                Dim lin As New Linea
                lin.Cantidad = IIf(IsDBNull(row.Cells("Cantidad").Value), 0, row.Cells("Cantidad").Value)
                lin.Precio = IIf(IsDBNull(row.Cells("Precio").Value), 0, row.Cells("Precio").Value)
                lin.DTO = IIf(IsDBNull(row.Cells("Dto").Value), 0, row.Cells("Dto").Value)

                lin.calcularTotalLinea()

                row.Cells("Subtotal").Value = Math.Round(lin.Subtotal, decimalesPrecios)
            End If
        Catch
        End Try
    End Sub

    Public Sub recalcularTotal()
        Try
            Me.EndEdit()
            RaiseEvent TotalesChanged()
        Catch
        End Try
    End Sub

    Private Sub GridLiFacs_UserAddedRow(sender As Object, e As GridViewRowEventArgs) Handles Me.UserAddedRow
        calcularSubtotalLin(e.Row)
        recalcularTotal()
    End Sub

    Private Sub GridLiFacs_UserDeletedRow(sender As Object, e As GridViewRowEventArgs) Handles Me.UserDeletedRow
        recalcularTotal()
    End Sub
End Class
