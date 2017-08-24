Imports VariablesGlobales

Public Class FormasPagoCons
    Inherits Bases.Consulta


    Protected Overrides Sub DefineLupa()
        If DesignMode = False Then
            Dim definition As New Definiciones.defGridLupaFormasProvee

            dgcColumns = definition.Columns
            dgtTables = definition.Tables

            ColSelectFilter = "NOMBRE"
            Me.Text = cTituloLupas & "Formas de Cobro Prove."
            Me.OpenFormNuevo = Karve.ConfiguracionApp.FormasProvee
        End If
    End Sub
End Class