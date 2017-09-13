Imports Karve.ConfiguracionApp
Imports VariablesGlobales
Imports Bases

Public Class ModelosVehiculoCons
    Inherits Consulta

    Protected Overrides Sub DefineLupa()
        If DesignMode = False Then
            Dim definition As New Definiciones.defGridLupaModelosVehiculo

            dgcColumns = definition.Columns
            dgtTables = definition.Tables
            dgoOrdenes = definition.Ordenes

            ColSelectFilter = "NOMBRE"
            Me.Text = cTituloLupas & "Modelos"
            Me.OpenFormNuevo = Karve.ConfiguracionApp.ModelosVehiculo
        End If
    End Sub

End Class