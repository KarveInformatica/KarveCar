Imports CustomControls
Imports VariablesGlobales
Imports Karve.ConfiguracionApp
Imports Bases

Public Class PoblacionCons
    Inherits Bases.Consulta


    Protected Overrides Sub DefineLupa()
        Dim definition As New Definiciones.defGridLupaPoblacion

        dgcColumns = definition.Columns
        dgtTables = definition.Tables

        ColSelectFilter = "NOMBRE"
        Me.Text = cTituloLupas & "Poblaciones"
        Me.OpenFormNuevo = Karve.ConfiguracionApp.Poblacion
    End Sub
End Class