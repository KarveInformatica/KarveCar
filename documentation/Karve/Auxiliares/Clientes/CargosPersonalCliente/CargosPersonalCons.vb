Imports System.Windows.Forms
Imports Karve.ConfiguracionApp
Imports VariablesGlobales

Public Class CargosPersonalCons
    Inherits Bases.Consulta

    Protected Overrides Sub DefineLupa()
        If DesignMode = False Then
            Dim definition As New Definiciones.defGridLupaCargosPersonalCliente

            dgcColumns = definition.Columns
            dgtTables = definition.Tables
            dgoOrdenes = definition.Ordenes

            ColSelectFilter = "NOMBRE"

            Me.Text = cTituloLupas & "Cargos Personal Cliente"
            Me.OpenFormNuevo = Karve.ConfiguracionApp.CargosPersonalCliente
        End If
    End Sub

End Class