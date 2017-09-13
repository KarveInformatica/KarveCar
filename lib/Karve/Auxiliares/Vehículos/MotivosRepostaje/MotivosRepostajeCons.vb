Imports Karve.ConfiguracionApp
Imports VariablesGlobales
Imports Bases

Public Class MotivosRepostajeCons
    Inherits Consulta

    Protected Overrides Sub DefineLupa()
        If DesignMode = False Then
            Dim definition As New Definiciones.defGridLupaMotivosRepostaje

            dgcColumns = definition.Columns
            dgtTables = definition.Tables
            dgoOrdenes = definition.Ordenes

            ColSelectFilter = "NOM_MOT"
            Me.Text = cTituloLupas & "Motivos Repostaje"
            Me.OpenFormNuevo = Karve.ConfiguracionApp.MotivosRepostaje
        End If
    End Sub

End Class
