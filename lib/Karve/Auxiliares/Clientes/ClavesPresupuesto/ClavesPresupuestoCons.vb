Imports Bases
Imports VariablesGlobales

Public Class ClavesPresupuestoCons
    Inherits Consulta

    Protected Overrides Sub DefineLupa()
        If DesignMode = False Then
            Dim definition As New Definiciones.defGridLupaClavesPresupuesto

            dgcColumns = definition.Columns
            dgtTables = definition.Tables

            ColSelectFilter = "NOMBRE"

            Me.Text = cTituloLupas & "Claves de Presupuesto"
            Me.OpenFormNuevo = Karve.ConfiguracionApp.ClavePto
        End If
    End Sub
End Class