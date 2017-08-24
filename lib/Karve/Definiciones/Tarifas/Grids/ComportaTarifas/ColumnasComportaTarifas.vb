Imports CustomControls
Imports Karve.ConfiguracionApp

Public Class ColumnasComportaTarifas

    Public Function ConceptoComportaTari() As DataGridTextBoxColumn
        Dim col As New DataGridTextBoxColumn
        col.HeaderText = "Concepto"
        col.Name = "Concepto"
        col.Campo = "CONCEPTO"
        col.AliasCampo = "Concepto"
        col.Tabla = "CPT"
        col.Width = 140
        col.ReadOnly = False
        col.AllowFiltering = True
        col.ReadOnly = True
        Return col
    End Function

    Public Function SiempreComportaTari() As DataGridCheckBoxColumn
        Dim col As New DataGridCheckBoxColumn
        col.HeaderText = "Siempre"
        col.Name = "Siempre"
        col.Campo = "IND_INCLUIDO"
        col.Tabla = "CPT"
        col.Width = 75
        Return col
    End Function

    Public Function FacturarAComportaTari() As DataGridTextBoxColumn
        Dim col As New DataGridTextBoxColumn
        col.HeaderText = "Facturar a"
        col.Name = "Facturar"
        col.Campo = "IND_FACTURAR"
        col.Tabla = "CPT"
        col.Width = 100
        col.ReadOnly = False
        Return col
    End Function   'COMBO

    Public Function TipoComportaTari() As DataGridTextBoxColumn
        Dim col As New DataGridTextBoxColumn
        col.HeaderText = "Tipo"
        col.Name = "Tipo"
        col.Campo = "TIPO"
        col.Tabla = "CPT"
        col.Width = 75
        Return col
    End Function        'COMBO

    Public Function ImporteComportaTari() As DataGridDecimalColumn
        Dim col As New DataGridDecimalColumn
        col.HeaderText = "Importe"
        col.Name = "Importe"
        col.Campo = "IMPORTE"
        col.Tabla = "CPT"
        col.Width = 100
        col.ReadOnly = True
        Return col
    End Function

    Public Function MaximoComportaTari() As DataGridDecimalColumn
        Dim col As New DataGridDecimalColumn
        col.HeaderText = "Máximo"
        col.Name = "Maximo"
        col.Campo = "MAXIMO"
        col.Tabla = "CPT"
        col.Width = 100
        col.ReadOnly = True
        Return col
    End Function

    Public Function AcumulaComportaTari() As DataGridCheckBoxColumn
        Dim col As New DataGridCheckBoxColumn
        col.HeaderText = "Acum."
        col.Name = "Acumulado"
        col.Campo = "ACUMULA_ALQ"
        col.Tabla = "CPT"
        col.Width = 100
        col.ReadOnly = True
        Return col
    End Function

    Public Function MinimoComportaTari() As DataGridDecimalColumn
        Dim col As New DataGridDecimalColumn
        col.HeaderText = "Mínimo"
        col.Name = "Minimo"
        col.Campo = "MINIMO"
        col.Tabla = "CPT"
        col.Width = 100
        col.ReadOnly = True
        Return col
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
    End Function         'PRIMARIA, AUNQUE NO SALGA EN GRID TIENE QUE ESTAR
End Class
