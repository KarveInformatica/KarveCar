Imports Bases
Imports VariablesGlobales

Public Class ExtrasVehiculoCons
    Inherits Consulta

    Protected Overrides Sub DefineLupa()
        If DesignMode = False Then
            Dim definition As New Definiciones.defGridLupaExtrasVehiculo

            dgcColumns = definition.Columns
            dgtTables = definition.Tables

            ColSelectFilter = "NOMBRE"

            Me.Text = cTituloLupas & "Extras Vehículo"
            Me.OpenFormNuevo = Karve.ConfiguracionApp.ExtrasVehiculo
        End If
    End Sub
End Class
