Imports CustomControls
Imports Telerik.WinControls.UI


Public Class GridDelegacion
    Inherits CustomControls.DataGrid

    Private i As Integer = 1

    Protected Overrides Sub DefineGrid()

        Dim definition As New Definiciones.defGridProDelegaciones

        dgcColumnas = definition.Columns
        ColRel = definition.ColumnRel

        dgtTablas = definition.Tables
        TablaEdit = definition.TablaEdit

        dgrClausulas = definition.Rules

    End Sub

    Private Sub GridDelegacion_HandleCreated(sender As Object, e As EventArgs) Handles Me.HandleCreated

    End Sub

    Protected Overrides Sub AddExtra(sender As Object, e As Telerik.WinControls.UI.GridViewRowCancelEventArgs)
        e.Rows(0).Cells(0).Value = "AGR" & Strings.Right("000" & CStr(i), 3)
        i += 1
    End Sub

End Class
