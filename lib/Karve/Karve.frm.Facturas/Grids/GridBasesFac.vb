Imports Telerik.WinControls.UI

Public Class GridBasesFac
    Inherits CustomControls.DataGrid
    Public Event TotalesChanged()
    Public Event IvaChanged(oldIva As Double, newIva As Double)

    Protected Overrides Sub DefineGrid()

        Dim definition As New Definiciones.defGridBasesfac

        dgcColumnas = definition.Columns
        ColRel = definition.ColumnRel

        dgtTablas = definition.Tables
        TablaEdit = definition.TablaEdit

        dgrClausulas = definition.Rules

    End Sub

    Protected Overrides Sub loadExtra()
        Me.EnableFiltering = False
        Me.datasetFiltering = True
        Me.AllowEditRow = True
        Me.AllowAddNewRow = False
        Me.AllowDeleteRow = False
        Me.SelectionMode = Telerik.WinControls.UI.GridViewSelectionMode.CellSelect
        Me.MultiSelect = False
    End Sub

    Private Sub GridBasesFac_CellValidating(sender As Object, e As CellValidatingEventArgs) Handles Me.CellValidating
        Try
            If e.Column.Name = "Iva" Then
                RaiseEvent IvaChanged(e.OldValue, e.Value)
            End If
        Catch
        End Try
    End Sub


    Private Sub GridBasesFac_CellValueChanged(sender As Object, e As GridViewCellEventArgs) Handles Me.CellValueChanged
        Try
            If e.Column.Name = "Recargo" Or e.Column.Name = "Iva" Then
                RaiseEvent TotalesChanged()
            End If
        Catch
        End Try
    End Sub
End Class
