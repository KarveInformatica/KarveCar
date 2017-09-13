Imports CustomControls

Public Class ColumnasPais

    Public Function CodigoPais() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Codigo"
        col.AliasCampo = "SIGLAS"
        col.Name = "SIGLAS"
        col.Tabla = "P"
        col.Width = 80
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function SiglasPais() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Siglas"
        col.AliasCampo = "SIGLASTEXTO"
        col.Name = "SIGLASTEXTO"
        col.Tabla = "P"
        col.Width = 80
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function NombrePais() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Nombre"
        col.AliasCampo = "PAIS"
        col.Name = "PAIS"
        col.Tabla = "P"
        col.Width = 200
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function IdiomaPais() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Idioma"
        col.AliasCampo = "NOMBRE"
        col.Name = "IDIOMA"
        col.Tabla = "LANG"
        col.Width = 200
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function IntracomunitarioPais() As DataGridCheckBoxColumn
        Dim col As DataGridCheckBoxColumn
        col = New DataGridCheckBoxColumn
        col.HeaderText = "Intracomunitario"
        col.AliasCampo = "INTRACO"
        col.Name = "INTRACO"
        col.Tabla = "P"
        col.Width = 80
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function


End Class
