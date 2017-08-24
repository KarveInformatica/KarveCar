Imports CustomControls

Public Class ColumnasFacturas

    Public Function CodigoFacturas() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Número"
        col.Campo = "NUMERO_FAC"
        col.Name = "NUMERO_FAC"
        col.Tabla = "F"
        col.Width = 90
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function FechaFacturas() As DataGridDateColumn
        Dim col As DataGridDateColumn
        col = New DataGridDateColumn
        col.HeaderText = "Fecha"
        col.Campo = "FECHA_FAC"
        col.Name = "Fecha"
        'col.ExpresionBd = "CAST(FECHA_FAC AS DATE) "
        col.Tabla = "F"
        col.AliasCampo = "FECHA_FAC"
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function ReferenciaFacturas() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Referencia"
        col.Campo = "REFEREN_FAC"
        col.Name = "REFEREN_FAC"
        col.Tabla = "F"
        col.Width = 100
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function ClienteFacturas() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Cliente"
        col.Campo = "CLIENTE_FAC"
        col.Name = "CLIENTE_FAC"
        col.Tabla = "F"
        col.Width = 80
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function NomClienteFacturas() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Nombre Cliente"
        col.Campo = "NOMBRE"
        col.Name = "NOMBRE"
        col.Tabla = "CL1"
        col.Width = 200
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function EmpFacturas() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Emp"
        col.Campo = "SUBLICEN_FAC"
        col.Name = "SUBLICEN_FAC"
        col.Tabla = "F"
        col.Width = 60
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function OfiFacturas() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Ofi"
        col.Campo = "OFICINA_FAC"
        col.Name = "OFICINA_FAC"
        col.Tabla = "F"
        col.Width = 60
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function ContraFacturas() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Contratos"
        col.Campo = "CONTRATOS"
        col.Name = "CONTRATOS"
        col.ExpresionBd = " (SELECT LIST(DISTINCT ISNULL(CONTRATO_LIF, ''), '; ' ORDER BY CONTRATO_LIF) FROM LIFAC WHERE NUMERO_LIF = NUMERO_FAC)"
        col.Tabla = "F"
        col.Width = 200
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function AsientoFacturas() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Asiento"
        col.Campo = "ASIENTO_FAC"
        col.Name = "ASIENTO_FAC"
        col.Tabla = "F"
        col.Width = 90
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function UltModiFacturas() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Ultima Mod."
        col.Campo = "ULTMODI_FAC"
        col.Name = "ULTMODI_FAC"
        col.Tabla = "F"
        col.Width = 90
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function UsuModiFacturas() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Usu.Mod."
        col.AliasCampo = "USUARIO_FAC"
        col.Name = "USUARIO_FAC"
        col.Tabla = "F"
        col.Width = 60
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

End Class
