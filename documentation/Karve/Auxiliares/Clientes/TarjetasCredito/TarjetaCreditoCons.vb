Imports Bases
Imports VariablesGlobales

Public Class tarjetaCreditoCons
    Inherits Consulta

    Protected Overrides Sub DefineLupa()
        If DesignMode = False Then
            Dim definition As New Definiciones.defGridLupaTarjetasCredito

            dgcColumns = definition.Columns
            dgtTables = definition.Tables

            ColSelectFilter = "NOMBRE"

            Me.Text = cTituloLupas & "Tarjetas de Crédito"
            Me.OpenFormNuevo = Karve.ConfiguracionApp.TarjetasCredito
        End If
    End Sub

End Class