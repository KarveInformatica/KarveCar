Imports System.Windows.Forms
Imports Karve.ConfiguracionApp
Imports VariablesGlobales

Public Class BloquesFacturacionCons
    Inherits Bases.Consulta

    Protected Overrides Sub DefineLupa()
        If DesignMode = False Then
            Dim definition As New Definiciones.defGridLupaBloquesFacturacion

            dgcColumns = definition.Columns
            dgtTables = definition.Tables
            dgoOrdenes = definition.Ordenes

            ColSelectFilter = "NOMBRE"
            Me.Text = cTituloLupas & "Bloques de Facturación"
            Me.OpenFormNuevo = Karve.ConfiguracionApp.BloquesFacturacion
        End If
    End Sub

End Class