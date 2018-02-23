Imports CustomControls

Public Class ColumnasTiposProvee

    Public Function CodigoTiposProvee() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Codigo"
        col.AliasCampo = "NUM_TIPROVE"
        col.Name = "NUM_TIPROVE"
        col.Tabla = "TPR"
        col.Width = 80
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function NombreTiposProvee() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Nombre"
        col.AliasCampo = "NOMBRE"
        col.Name = "NOMBRE"
        col.Tabla = "TPR"
        col.Width = 200
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function CodigoCtaGastoTiposProvee() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Cta.Gasto"
        col.AliasCampo = "CTAGASTO"
        col.Name = "CTAGASTO"
        col.Tabla = "TPR"
        col.Width = 110
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

End Class
