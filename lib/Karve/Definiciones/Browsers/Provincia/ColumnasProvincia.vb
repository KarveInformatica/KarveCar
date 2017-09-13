Imports CustomControls

Public Class ColumnasProvincia

    Public Function CodigoProvincia() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Codigo"
        col.AliasCampo = "SIGLAS"
        col.Name = "SIGLAS"
        col.Tabla = "PROV"
        col.Width = 80
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function SiglasProvincia() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Siglas"
        col.AliasCampo = "ABREVIA"
        col.Name = "ABREVIA"
        col.Tabla = "PROV"
        col.Width = 80
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function NombreProvincia() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Nombre"
        col.AliasCampo = "PROV"
        col.Name = "PROVINCIA"
        col.Tabla = "PROV"
        col.Width = 200
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function CapitalProvincia() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Capital"
        col.AliasCampo = "CAPITAL"
        col.Name = "CAPITAL"
        col.Tabla = "PROV"
        col.Width = 200
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function PaisProvincia() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Pais"
        col.AliasCampo = "PAIS"
        col.Name = "PAIS"
        col.Tabla = "P"
        col.Width = 200
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

End Class
