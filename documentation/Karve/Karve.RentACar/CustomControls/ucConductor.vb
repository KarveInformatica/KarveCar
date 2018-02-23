Imports VariablesGlobales
Imports Karve.ConfiguracionApp

Public Class ucConductor

    Private _sufijoCampos As String
    Private _datatable As String

    Private Sub ucConductor_HandleCreated(sender As Object, e As EventArgs) Handles Me.HandleCreated
        dtfConductorDetalles.Lupa = lupaClientes
        dtfConductorDetalles.OpenForm = frmClientes
        setDatafieldsDatatables()

    End Sub

    Private Sub setDatafieldsDatatables()
        dtfConductorDetalles.DataField &= _sufijoCampos
        dtfConductorDetalles.DataTable = _datatable

        dtfNombreCond.DataField &= _sufijoCampos
        dtfNombreCond.DataTable = _datatable

        dtdDirCond.Datafield_Direccion &= _sufijoCampos
        dtdDirCond.Datatable_Direccion = _datatable
        dtdDirCond.Datafield_CP &= _sufijoCampos
        dtdDirCond.Datatable_CP = _datatable
        dtdDirCond.Datafield_Poblacion &= _sufijoCampos
        dtdDirCond.Datatable_Poblacion = _datatable
        dtdDirCond.Datafield_Provincia &= _sufijoCampos
        dtdDirCond.Datatable_Provincia = _datatable
        dtdDirCond.Datafield_Pais &= _sufijoCampos
        dtdDirCond.Datatable_Pais = _datatable

        dtfNIFCond.DataField &= _sufijoCampos
        dtfNIFCond.DataTable = _datatable


    End Sub
End Class
