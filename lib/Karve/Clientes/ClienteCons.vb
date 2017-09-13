Imports CustomControls
Imports VariablesGlobales
Imports Karve.ConfiguracionApp
Imports Bases

Public Class ClienteCons
    Inherits Bases.Consulta

    

    Protected Overrides Sub DefineLupa()
        Dim definition As New Definiciones.defGridLupaClientes

        dgcColumns = definition.Columns
        dgtTables = definition.Tables
        dgoOrdenes = definition.Ordenes

        ColSelectFilter = "NOMBRE"
        Me.Text = cTituloLupas & "Clientes"
        Me.OpenFormNuevo = ConfiguracionApp.frmClientes
    End Sub

    
End Class