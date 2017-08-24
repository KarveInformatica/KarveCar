Imports Bases
Imports VariablesGlobales
Imports Karve.ConfiguracionApp.Modulo_ConstantesFormularios

Public Class FacturasCons
    Inherits Bases.Consulta

    Protected Overrides Sub DefineLupa()
        Dim definition As New Definiciones.defGridLupaFacturas

        dgcColumns = definition.Columns
        dgtTables = definition.Tables
        colRelation = definition.ColumnRel
        dgoOrdenes = definition.Ordenes

        ColSelectFilter = "NOMBRE"
        Me.Text = cTituloLupas & "Facturas"
        Me.OpenFormNuevo = Karve.ConfiguracionApp.frmFacturas
    End Sub

End Class