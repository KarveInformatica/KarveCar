Imports VariablesGlobales
Imports Karve.ConfiguracionApp

Public Class TarifasCons
    Inherits Bases.Consulta


    Protected Overrides Sub DefineLupa()
        Dim definition As New Definiciones.defGridLupaTarifas

        dgcColumns = definition.Columns
        dgtTables = definition.Tables
        colRelation = definition.ColumnRel
        dgoOrdenes = definition.Ordenes

        ColSelectFilter = "NOMBRE"
        Me.Text = cTituloLupas & "Tarifas"
        Me.OpenFormNuevo = Karve.ConfiguracionApp.Tarifas
    End Sub

End Class