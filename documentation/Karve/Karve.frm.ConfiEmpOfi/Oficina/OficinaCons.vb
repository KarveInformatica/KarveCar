Imports CustomControls
Imports VariablesGlobales
Imports Karve.ConfiguracionApp
Imports Bases

Public Class OficinaCons
    Inherits Bases.Consulta


    Protected Overrides Sub DefineLupa()
        Dim definition As New Definiciones.defGridLupaOficina

        dgcColumns = definition.Columns
        dgtTables = definition.Tables

        ColSelectFilter = "NOMBRE"

        Me.Text = cTituloLupas & "Oficinas"
    End Sub
End Class