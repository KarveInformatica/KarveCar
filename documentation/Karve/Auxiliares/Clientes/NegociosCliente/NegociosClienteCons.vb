Imports Bases
Imports VariablesGlobales

Public Class NegociosClienteCons
    Inherits Consulta

    Protected Overrides Sub DefineLupa()
        If DesignMode = False Then
            Dim definition As New Definiciones.defGridLupaNegocioCliente

            dgcColumns = definition.Columns
            dgtTables = definition.Tables

            ColSelectFilter = "NOMBRE"

            Me.Text = cTituloLupas & "Negocios"
            Me.OpenFormNuevo = Karve.ConfiguracionApp.NegociosCliente
        End If
    End Sub
End Class