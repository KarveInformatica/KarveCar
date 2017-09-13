Imports Bases
Imports VariablesGlobales

Public Class ColoresVehiculoCons
    Inherits Consulta

    Protected Overrides Sub DefineLupa()
        If DesignMode = False Then
            Dim definition As New Definiciones.defGridLupaColoresVehiculo

            dgcColumns = definition.Columns
            dgtTables = definition.Tables

            ColSelectFilter = "NOMBRE"

            Me.Text = cTituloLupas & "Colores"
            Me.OpenFormNuevo = Karve.ConfiguracionApp.ColoresVehiculo
        End If
    End Sub
End Class
