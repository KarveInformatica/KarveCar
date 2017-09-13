Imports Telerik.WinControls.UI
Imports CustomControls

Public Class GridExtras
    Inherits CustomControls.DataGrid

    Private i As Integer = 1

    Protected Overrides Sub DefineGrid()

        Dim definition As New Definiciones.defGridExtrasMod

        dgcColumnas = definition.Columns
        ColRel = definition.ColumnRel

        dgtTablas = definition.Tables
        TablaEdit = definition.TablaEdit

        dgrClausulas = definition.Rules

    End Sub

    Protected Overrides Sub AddExtra(sender As Object, e As GridViewRowCancelEventArgs)
        Dim kMsgBox As New CustomControls.kMsgBox
        '*============================================================================
        For Each Rw In CType(Me.DataSource, DataTable).Rows
            If CType(Rw, DataRow).Item("CODMOD_EV").ToString = e.Rows(0).Cells("CodMod").Value.ToString And _
               CType(Rw, DataRow).Item("CODIGO_EV").ToString = e.Rows(0).Cells("Codigo").Value.ToString _
            Then
                e.Cancel = True
                kMsgBox.Print("Ya tiene un Registro con este código", CustomControls.kMsgBox.kMsgBoxStyle.ErrorInformation)
                Exit Sub
            End If

        Next
    End Sub

End Class
