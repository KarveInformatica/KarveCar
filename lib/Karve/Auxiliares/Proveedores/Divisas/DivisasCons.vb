Imports VariablesGlobales

Public Class DivisasCons
    Inherits Bases.Consulta

    Protected Overrides Sub DefineLupa()
        If DesignMode = False Then
            Dim definition As New Definiciones.defGridLupaDivisas

            dgcColumns = definition.Columns
            dgtTables = definition.Tables

            ColSelectFilter = "NOMBRE"
            Me.Text = cTituloLupas & "Divisas"
            Me.OpenFormNuevo = Karve.ConfiguracionApp.Divisas
        End If
    End Sub
End Class