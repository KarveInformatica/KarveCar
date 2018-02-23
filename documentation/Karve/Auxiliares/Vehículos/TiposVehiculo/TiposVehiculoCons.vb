Imports CustomControls
Imports VariablesGlobales
Imports Karve.ConfiguracionApp
Imports Bases

Public Class TiposVehiculoCons
    Inherits Consulta

    Protected Overrides Sub DefineLupa()
        If DesignMode = False Then
            Dim definition As New Definiciones.defGridLupaTiposVehiculo

            dgcColumns = definition.Columns
            dgtTables = definition.Tables

            ColSelectFilter = "NOMBRE"

            Me.Text = cTituloLupas & "Tipos Vehículo"
            Me.OpenFormNuevo = Karve.ConfiguracionApp.TiposVehiculo
        End If
    End Sub

End Class


