Imports Bases
Imports VariablesGlobales

Public Class IdiomasCons
    Inherits Consulta

    Protected Overrides Sub DefineLupa()
        If DesignMode = False Then
            Dim definition As New Definiciones.defGridLupaIdiomas

            dgcColumns = definition.Columns
            dgtTables = definition.Tables

            ColSelectFilter = "NOMBRE"

            Me.Text = cTituloLupas & "Idiomas"
            Me.OpenFormNuevo = Karve.ConfiguracionApp.Idiomas
        End If
    End Sub

End Class