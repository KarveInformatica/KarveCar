Imports VariablesGlobales
Imports CustomControls
Imports Karve.ConfiguracionApp

Public Class ColumnasTramosTari

    Public Function TramoTramosTari() As DataGridTextBoxColumn
        Dim col As New DataGridTextBoxColumn
        col.HeaderText = "Tramo"
        col.Name = "Tramo"
        col.Campo = "tramo"
        col.AliasCampo = "TRAMO"
        col.Tabla = "TRT"
        col.Width = 50
        col.ReadOnly = True
        col.AllowFiltering = False
        Return col
    End Function

    Public Function DesdeTramosTari() As DataGridTextBoxColumn
        Dim col As New DataGridTextBoxColumn
        col.HeaderText = "Desde"
        col.Name = "Desde"
        col.Campo = "desde"
        col.AliasCampo = "desde"
        col.Tabla = "TRT"
        col.Width = 50
        Return col
    End Function

    Public Function HastaTramosTari() As DataGridTextBoxColumn
        Dim col As New DataGridTextBoxColumn
        col.HeaderText = "Hasta"
        col.Name = "Hasta"
        col.Campo = "hasta"
        col.AliasCampo = "hasta"
        col.Tabla = "TRT"
        col.Width = 50
        Return col
    End Function

    Public Function CantidadTramosTari() As DataGridTextBoxColumn
        Dim col As New DataGridTextBoxColumn
        col.HeaderText = "Cantidad"
        col.Name = "Cantidad"
        col.Campo = "cantidad"
        col.AliasCampo = "cantidad"
        col.Tabla = "TRT"
        col.Width = 100
        Return col
    End Function

    Public Function UnidadTramosTari() As DataGridComboBoxColumn
        Dim col As New DataGridComboBoxColumn
        col.DataSource = dtatramos()
        col.ValueMember = "codigo"
        col.DisplayMember = "nombre"
        col.HeaderText = "Unidad"
        col.Name = "Unidad"
        col.Campo = "unidad"
        col.AliasCampo = "unidadcombo"
        col.Tabla = "TRT"
        col.Width = 250

        Return col
    End Function

    Private Function dtatramos() As DataTable
        Dim dts As DataSet
        Dim db As New ASADB.Connection

        dts = db.fillDts("select codigo, nombre from unidades where codigo < 7")
        TranslateDataTable(dts.Tables(0), "nombre")
        Return dts.Tables(0)
    End Function


    Public Function NtariTramosTari() As DataGridTextBoxColumn
        Dim col As New DataGridTextBoxColumn
        col.HeaderText = "Tarifa"
        col.Name = "Tarifa"
        col.Campo = "NTARI"
        col.Tabla = "TRT"
        col.Width = 50
        col.IsVisible = False
        col.VisibleInColumnChooser = False
        col.ReadOnly = True
        Return col
    End Function

    Public Function PKTramosTari() As DataGridTextBoxColumn
        Dim col As New DataGridTextBoxColumn
        col.HeaderText = "PK"
        col.Name = "PK"
        col.Campo = "CLAVE_TT"
        col.Tabla = "TRT"
        col.Width = 50
        col.IsVisible = False
        col.VisibleInColumnChooser = False
        col.ReadOnly = True
        Return col
    End Function

End Class
