Imports CustomControls

Public Class ColumnasFormasProvee

    Public Function CodigoFormasProvee() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Código"
        col.Campo = "CODIGO"
        col.Name = "CODIGO"
        col.Tabla = "FPR"
        col.Width = 80
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function NombreFormasProvee() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Nombre"
        col.Campo = "NOMBRE"
        col.Name = "NOMBRE"
        col.Tabla = "FPR"
        col.Width = 200
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function CtaGastoFormasProvee() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Cta. Pago"
        col.Campo = "CTAPAGO"
        col.Name = "CTAPAGO"
        col.Tabla = "FPR"
        col.Width = 100
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

End Class
