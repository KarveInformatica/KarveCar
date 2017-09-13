Imports Bases
Imports VariablesGlobales

Public Class ZonasCons
    Inherits Consulta

    Protected Overrides Sub DefineLupa()
        Dim definition As New Definiciones.defGridLupaZonas
        If DesignMode = False Then
            dgcColumns = definition.Columns
            dgtTables = definition.Tables

            ColSelectFilter = "NOMBRE"

            Me.Text = cTituloLupas & "Zonas"
            Me.OpenFormNuevo = Karve.ConfiguracionApp.Zonas
        End If
    End Sub

End Class