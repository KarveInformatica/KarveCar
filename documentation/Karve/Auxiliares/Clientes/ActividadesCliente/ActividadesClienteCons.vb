Imports System.Windows.Forms
Imports Karve.ConfiguracionApp
Imports VariablesGlobales

Public Class ActividadesClienteCons
    Inherits Bases.Consulta

    Protected Overrides Sub DefineLupa()
        If DesignMode = False Then
            Dim definition As New Definiciones.defGridLupaActividadCliente

            dgcColumns = definition.Columns
            dgtTables = definition.Tables
            dgoOrdenes = definition.Ordenes

            ColSelectFilter = "NOMBRE"
            Me.Text = cTituloLupas & "Actividades Cliente"
            Me.OpenFormNuevo = Karve.ConfiguracionApp.ActividadesCliente
        End If
    End Sub

End Class