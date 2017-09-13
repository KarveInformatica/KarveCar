Imports CustomControls
Imports VariablesGlobales
Imports Karve.ConfiguracionApp
Imports Bases

Public Class TipoDocumentosCons
    Inherits Consulta

    Protected Overrides Sub DefineLupa()
        If DesignMode = False Then
            Dim definition As New Definiciones.defGridLupaTipoDocumentos

            dgcColumns = definition.Columns
            dgtTables = definition.Tables

            ColSelectFilter = "NOMBRE"

            Me.Text = cTituloLupas & "Tipo Documentos"
            Me.OpenFormNuevo = Karve.ConfiguracionApp.TiposDocumentos
        End If
    End Sub

End Class