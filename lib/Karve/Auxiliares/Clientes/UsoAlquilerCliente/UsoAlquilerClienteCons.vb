Imports System.Windows.Forms
Imports Karve.ConfiguracionApp
Imports VariablesGlobales

Public Class UsoAlquilerClienteCons
    Inherits Bases.Consulta

    Protected Overrides Sub DefineLupa()
        If DesignMode = False Then
            Dim definition As New Definiciones.defGridUsoAlquilerCliente

            dgcColumns = definition.Columns
            dgtTables = definition.Tables
            dgoOrdenes = definition.Ordenes

            ColSelectFilter = "NOMBRE"

            Me.Text = cTituloLupas & "Uso Alquiler de Cliente"
            Me.OpenFormNuevo = Karve.ConfiguracionApp.UsoAlquilerCliente
        End If
    End Sub

End Class