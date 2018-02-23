Imports Bases
Imports VariablesGlobales

Public Class OrigenesClienteCons
    Inherits Consulta

    Protected Overrides Sub DefineLupa()
        Dim definition As New Definiciones.defGridLupaOrigen

        dgcColumns = definition.Columns
        dgtTables = definition.Tables

        ColSelectFilter = "NOMBRE"

        Me.Text = cTituloLupas & "Orígenes"
        Me.OpenFormNuevo = Karve.ConfiguracionApp.OrigenesCliente
    End Sub

End Class