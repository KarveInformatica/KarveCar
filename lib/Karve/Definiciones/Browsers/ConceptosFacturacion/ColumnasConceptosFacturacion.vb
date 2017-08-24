Imports CustomControls

Public Class ColumnasConceptosFacturacion
    Public Function CodigoConceptosFacturacion() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        With col
            .HeaderText = "Codigo"
            .AliasCampo = "CODIGO"
            .Name = "CODIGO"
            .Tabla = "COF"
            .Width = 80
            .ReadOnly = True
            .AllowFiltering = True
        End With
        Return col
    End Function

    Public Function NombreConceptosFacturacion() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        With col
            .HeaderText = "Nombre"
            .AliasCampo = "NOMBRE"
            .Name = "NOMBRE"
            .Tabla = "COF"
            .Width = 200
            .ReadOnly = True
            .AllowFiltering = True
        End With

        Return col
    End Function
End Class
