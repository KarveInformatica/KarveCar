Imports Karve.ConfiguracionApp
Imports VariablesGlobales
Imports Bases

Public Class CanalesClienteCons
    Inherits Consulta

    Protected Overrides Sub DefineLupa()
        If DesignMode = False Then
            Dim definition As New Definiciones.defGridLupaCanalCliente

            dgcColumns = definition.Columns
            dgtTables = definition.Tables
            dgoOrdenes = definition.Ordenes

            ColSelectFilter = "NOMBRE"
            Me.Text = cTituloLupas & "Canales"
            Me.OpenFormNuevo = Karve.ConfiguracionApp.CanalesCliente
        End If
    End Sub
    
End Class