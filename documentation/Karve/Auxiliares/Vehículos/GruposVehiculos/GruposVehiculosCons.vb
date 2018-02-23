Imports VariablesGlobales

Public Class GruposVehiculosCons
    Inherits Bases.Consulta


    Protected Overrides Sub DefineLupa()
        If DesignMode = False Then
            Dim definition As New Definiciones.defGridLupaGruposVehiculos

            dgcColumns = definition.Columns
            dgtTables = definition.Tables

            ColSelectFilter = "NOMBRE"
            Me.Text = cTituloLupas & "Grupos de Vehículos"
            Me.OpenFormNuevo = Karve.ConfiguracionApp.GruposVehiculo
        End If
    End Sub
End Class