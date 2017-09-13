Imports CustomControls
Imports VariablesGlobales
Imports Karve.ConfiguracionApp
Imports Bases

Public Class ProvinciaCons
    Inherits Bases.Consulta


    Protected Overrides Sub DefineLupa()
        Dim definition As New Definiciones.defGridLupaProvincia

        dgcColumns = definition.Columns
        dgtTables = definition.Tables

        ColSelectFilter = "PROV"
        Me.Text = cTituloLupas & "Provincias"
        Me.OpenFormNuevo = Karve.ConfiguracionApp.Provincia
    End Sub
End Class