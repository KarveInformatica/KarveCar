Imports CustomControls
Imports VariablesGlobales
Imports Karve.ConfiguracionApp
Imports Bases

Public Class PaisCons
    Inherits Bases.Consulta


    Protected Overrides Sub DefineLupa()
        Dim definition As New Definiciones.defGridLupaPais

        dgcColumns = definition.Columns
        dgtTables = definition.Tables

        ColSelectFilter = "NOMBRE"
        Me.Text = cTituloLupas & "Paises"
        Me.OpenFormNuevo = Karve.ConfiguracionApp.Pais
    End Sub
End Class