Imports System.Windows.Forms
Imports Karve.ConfiguracionApp
Imports VariablesGlobales

Public Class ActividadesVehiculoCons
    Inherits Bases.Consulta

    Protected Overrides Sub DefineLupa()
        If DesignMode = False Then
            Dim definition As New Definiciones.defGridLupaActividadVehiculo

            dgcColumns = definition.Columns
            dgtTables = definition.Tables
            dgoOrdenes = definition.Ordenes

            ColSelectFilter = "NOMBRE"

            Me.Text = cTituloLupas & "Actividades de Vehículo"
            Me.OpenFormNuevo = Karve.ConfiguracionApp.ActividadesVehiculo
        End If
    End Sub

End Class
