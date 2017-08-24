Imports CustomControls

Public Class ColumnasTipoDocumentos
    Public Function CodigoTipoDocumento() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Codigo"
        col.AliasCampo = "CODIGO"
        col.Name = "CODIGO"
        col.Tabla = "TIDO"
        col.Width = 80
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function NombreTipoDocumento() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Nombre"
        col.AliasCampo = "NOMBRE"
        col.Name = "NOMBRE"
        col.Tabla = "TIDO"
        col.Width = 200
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function
    Public Function RTratamientoTipoDocumento() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Requiere_Tratamiento"
        col.AliasCampo = "REQUIERE_TRATAMIENTO"
        col.Name = "REQUIERE_TRATAMIENTO"
        col.Tabla = "TIDO"
        col.Width = 200
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function
    Public Function RVistobuenoTipoDocumento() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Requiere Vistobueno"
        col.AliasCampo = "REQUIERE_VISTOBUENO"
        col.Name = "REQUIERE_VISTOBUENO"
        col.Tabla = "TIDO"
        col.Width = 200
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function
    Public Function RSupervisionTipoDocumento() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Requiere Supervisión"
        col.AliasCampo = "REQUIERE_SUPERVISION"
        col.Name = "REQUIERE_SUPERVISION"
        col.Tabla = "TIDO"
        col.Width = 200
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function
End Class
