Imports CustomControls
Imports VariablesGlobales
Imports Karve.ConfiguracionApp
Imports Bases

Public Class ProveedoresCons
    Inherits Bases.Consulta

    Protected Overrides Sub DefineLupa()
        Dim definition As New Definiciones.defGridLupaProvee

        dgcColumns = definition.Columns
        dgtTables = definition.Tables

        ColSelectFilter = "NOMBRE"
        Me.Text = cTituloLupas & "Proveedores"
        Me.OpenFormNuevo = Karve.ConfiguracionApp.frmProvee
    End Sub

End Class
