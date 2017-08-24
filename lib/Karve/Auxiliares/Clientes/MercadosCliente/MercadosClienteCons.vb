Imports Bases
Imports VariablesGlobales

Public Class MercadosClienteCons
    Inherits Consulta

    Protected Overrides Sub DefineLupa()
        If DesignMode = False Then
            Dim definition As New Definiciones.defGridLupaMercadoCliente

            dgcColumns = definition.Columns
            dgtTables = definition.Tables

            ColSelectFilter = "NOMBRE"

            Me.Text = cTituloLupas & "Mercados"
            Me.OpenFormNuevo = Karve.ConfiguracionApp.MercadosCliente
        End If
    End Sub

End Class