Imports VariablesGlobales
Imports Karve.ConfiguracionApp

Public Class ContratosCons
    Inherits Bases.Consulta

    Protected Overrides Sub DefineLupa()
        Dim definition As New Definiciones.defGridLupaContratosRC

        dgcColumns = definition.Columns
        dgtTables = definition.Tables
        colRelation = definition.ColumnRel
        dgoOrdenes = definition.Ordenes

        ColSelectFilter = "NOMBRE"
        Me.Text = cTituloLupas & "Contratos"
        Me.OpenFormNuevo = Karve.ConfiguracionApp.frmContratos
    End Sub

    
End Class