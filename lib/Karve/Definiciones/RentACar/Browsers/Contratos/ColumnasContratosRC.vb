Imports CustomControls

Public Class ColumnasContratosRC

    Public Function NumeroContrato() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Contrato"
        col.Campo = "NUMERO"
        col.AliasCampo = "NUMERO"
        col.Name = "Contrato"
        col.Tabla = "C1"
        col.Width = 80
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function NumeroCliente() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Cliente"
        col.Campo = "NUMERO_CLI"
        col.AliasCampo = "NUMERO_CL1"
        col.Name = "NumeroCliente"
        col.Tabla = "CL1"
        col.Width = 80
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function NombreCliente() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Nombre Cliente"
        col.Campo = "NOMBRE"
        col.AliasCampo = "NOMBRE_CL1"
        col.Name = "NombreCliente"
        col.Tabla = "CL1"
        col.Width = 200
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function NombreConductor() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Nombre Conductor"
        col.ExpresionBd = "ISNULL(COND1.NOMBRE, CL1.NOMBRE)"
        col.AliasCampo = "NOMBRE_COND1"
        col.Name = "NombreConductor"
        col.Tabla = "COND1"
        col.Width = 200
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function FechaSalida() As DataGridDateColumn
        Dim col As DataGridDateColumn
        col = New DataGridDateColumn
        col.HeaderText = "Desde"
        col.Campo = "FSALIDA_CON1"
        col.AliasCampo = "FSALIDA_CON1"
        col.Name = "FSALIDA_CON1"
        col.Tabla = "C1"
        col.Width = 80
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function FechaPrevista() As DataGridDateColumn
        Dim col As DataGridDateColumn
        col = New DataGridDateColumn
        col.HeaderText = "Prevista"
        col.Campo = "FPREV_CON1"
        col.Name = "FechaPrevista"
        col.Tabla = "C1"
        col.Width = 80
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function FechaRetorno() As DataGridDateColumn
        Dim col As DataGridDateColumn
        col = New DataGridDateColumn
        col.HeaderText = "Retorno"
        col.Campo = "FRETOR_CON1"
        col.Name = "FechaRetorno"
        col.Tabla = "C1"
        col.Width = 80
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function OfiSalida() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "O.S."
        col.Campo = "OFISALIDA_CON1"
        col.Name = "OfiSalida"
        col.Tabla = "C1"
        col.Width = 40
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function OfiRetorno() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "O.R."
        col.Campo = "OFIRETORNO_CON1"
        col.Name = "OfiRetorno"
        col.Tabla = "C1"
        col.Width = 40
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function DiasContrato() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Dias"
        col.ExpresionBd = "CASE WHEN ISNULL(C1.DIACER_CON1, 0) = 0 THEN C1.DIAS_CON1 " & _
                            "ELSE C1.DIACER_CON1 END"
        col.AliasCampo = "DIAS"
        col.Name = "DiasContrato"
        col.Tabla = "C1"
        col.Width = 40
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function
End Class
