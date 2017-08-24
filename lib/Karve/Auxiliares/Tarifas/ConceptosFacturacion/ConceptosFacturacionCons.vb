Imports Bases
Imports VariablesGlobales

Public Class ConceptosFacturacionCons
    Inherits Consulta
    Protected Overrides Sub DefineLupa()
        If DesignMode = False Then
            Dim definition As New Definiciones.defGridLupaConceptosFacturacion

            dgcColumns = definition.Columns
            dgtTables = definition.Tables

            ColSelectFilter = "NOMBRE"

            Me.Text = cTituloLupas & "Conceptos de Facturación"
            Me.OpenFormNuevo = Karve.ConfiguracionApp.frmConceptosFacturacion
        End If
    End Sub
End Class