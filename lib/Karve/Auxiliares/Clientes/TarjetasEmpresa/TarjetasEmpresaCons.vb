Imports CustomControls
Imports VariablesGlobales
Imports Karve.ConfiguracionApp
Imports Bases

Public Class TarjetasEmpresaCons
    Inherits Consulta

    Protected Overrides Sub DefineLupa()
        If DesignMode = False Then
            Dim definition As New Definiciones.defGridLupaTarjetasEmpresa

            dgcColumns = definition.Columns
            dgtTables = definition.Tables

            ColSelectFilter = "NOMBRE"

            Me.Text = cTituloLupas & "Tarjetas Empresa"
            Me.OpenFormNuevo = Karve.ConfiguracionApp.TarjetasEmpresa
        End If
    End Sub
End Class