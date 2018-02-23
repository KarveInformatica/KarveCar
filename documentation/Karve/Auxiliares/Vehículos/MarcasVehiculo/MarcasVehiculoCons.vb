Imports Karve.ConfiguracionApp
Imports VariablesGlobales
Imports Bases

Public Class MarcasVehiculoCons
    Inherits Consulta

    Protected Overrides Sub DefineLupa()
        If DesignMode = False Then
            Dim definition As New Definiciones.defGridLupaMarcasVehiculo

            dgcColumns = definition.Columns
            dgtTables = definition.Tables
            dgoOrdenes = definition.Ordenes

            ColSelectFilter = "NOMBRE"
            Me.Text = cTituloLupas & "Marcas"
            Me.OpenFormNuevo = Karve.ConfiguracionApp.MarcasVehiculo
        End If
    End Sub

End Class