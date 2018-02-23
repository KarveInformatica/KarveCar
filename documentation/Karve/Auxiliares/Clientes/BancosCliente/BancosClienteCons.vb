Imports System.Windows.Forms
Imports Karve.ConfiguracionApp
Imports VariablesGlobales

Public Class BancosClienteCons
    Inherits Bases.Consulta

    Protected Overrides Sub DefineLupa()
        If DesignMode = False Then
            Dim definition As New Definiciones.defGridLupaBancos

            dgcColumns = definition.Columns
            dgtTables = definition.Tables
            dgoOrdenes = definition.Ordenes

            ColSelectFilter = "NOMBRE"
            Me.Text = cTituloLupas & "Bancos de Cliente"
            Me.OpenFormNuevo = Karve.ConfiguracionApp.BancosCliente
        End If
    End Sub

End Class
