Imports VariablesGlobales
Imports Karve.ConfiguracionApp

Public Class VehiculosCons
    Inherits Bases.Consulta


    Protected Overrides Sub DefineLupa()
        Dim definition As New Definiciones.defGridLupaVehiculos

        dgcColumns = definition.Columns
        dgtTables = definition.Tables
        colRelation = definition.ColumnRel
        dgoOrdenes = definition.Ordenes

        ColSelectFilter = "NOMBRE"
        Me.Text = cTituloLupas & "Vehículos"
        Me.OpenFormNuevo = Karve.ConfiguracionApp.Vehiculos
    End Sub


End Class