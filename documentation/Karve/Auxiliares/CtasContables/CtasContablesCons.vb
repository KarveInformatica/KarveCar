Imports Bases
Imports VariablesGlobales

Public Class CtasContablesCons
    Inherits Consulta

    Protected Overrides Sub DefineLupa()
        If DesignMode = False Then
            Dim definition As New Definiciones.defGridLupaCtasContables

            dgcColumns = definition.Columns
            dgtTables = definition.Tables
            dgoOrdenes = definition.Ordenes
            dgrRules = definition.Rules

            ColSelectFilter = "NOMBRE"

            Me.Text = cTituloLupas & "Cuentas Contables"
        End If
    End Sub

End Class