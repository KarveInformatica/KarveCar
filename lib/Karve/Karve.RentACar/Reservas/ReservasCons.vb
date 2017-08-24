Imports VariablesGlobales
Imports Karve.ConfiguracionApp

Public Class ReservasCons
    Inherits Bases.Consulta


    Protected Overrides Sub DefineLupa()
        Dim definition As New Definiciones.defGridLupaReservasRC

        dgcColumns = definition.Columns
        dgtTables = definition.Tables
        colRelation = definition.ColumnRel
        dgoOrdenes = definition.Ordenes

        ColSelectFilter = "NOMBRE"
        Me.Text = cTituloLupas & "Reservas"
        Me.OpenFormNuevo = Karve.ConfiguracionApp.frmReservas
    End Sub


End Class
