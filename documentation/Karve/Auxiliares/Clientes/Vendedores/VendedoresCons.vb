Imports System.Windows.Forms
Imports Karve.ConfiguracionApp
Imports VariablesGlobales

Public Class VendedoresCons
    Inherits Bases.Consulta

    Protected Overrides Sub DefineLupa()
        If DesignMode = False Then
            Dim definition As New Definiciones.defGridLupaVendedores

            dgcColumns = definition.Columns
            dgtTables = definition.Tables
            dgoOrdenes = definition.Ordenes

            ColSelectFilter = "NOMBRE"

            Me.Text = cTituloLupas & "Vendedores"
            Me.OpenFormNuevo = Karve.ConfiguracionApp.Vendedores
        End If
    End Sub

End Class