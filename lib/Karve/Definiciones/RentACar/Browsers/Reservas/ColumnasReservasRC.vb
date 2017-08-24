Imports CustomControls

Public Class ColumnasReservasRC

    Public Function NumeroReserva() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Reserva"
        col.Campo = "NUMERO_RES"
        col.AliasCampo = "NUMERO_RES"
        col.Name = "Reserva"
        col.Tabla = "R1"
        col.Width = 80
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function FCreaReserva() As DataGridDateColumn
        Dim col As DataGridDateColumn
        col = New DataGridDateColumn
        col.HeaderText = "F.Crea"
        col.Campo = "FECHA_RES1"
        col.AliasCampo = "FECHA_RES1"
        col.Name = "FCrea"
        col.Tabla = "R1"
        col.Width = 80
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function LocalizadorReserva() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Localizador"
        col.Campo = "LOCALIZA_RES1"
        col.AliasCampo = "LOCALIZA_RES1"
        col.Name = "Localizador"
        col.Tabla = "R1"
        col.Width = 120
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function OSalReserva() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "O.Sal"
        col.Campo = "OFISALIDA_RES1"
        col.AliasCampo = "OFISALIDA_RES1"
        col.Name = "Osal"
        col.Tabla = "R1"
        col.Width = 60
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function ConductorReserva() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Conductor"
        col.Campo = "NOMBRE_RES1"
        col.AliasCampo = "NOMBRE_RES1"
        col.Name = "Conductor"
        col.Tabla = "R1"
        col.Width = 200
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function GrupoReserva() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Grupo"
        col.Campo = "GRUPO_RES1"
        col.AliasCampo = "GRUPO_RES1"
        col.Name = "Grupo"
        col.Tabla = "R1"
        col.Width = 60
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function LuEntregaReserva() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Lugar Entrega"
        col.Campo = "LUENTRE_RES1"
        col.AliasCampo = "LUENTRE_RES1"
        col.Name = "LugarEntrega"
        col.Tabla = "R1"
        col.Width = 140
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function LuDevoReserva() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Lugar Devolución"
        col.Campo = "LUDEVO_RES1"
        col.AliasCampo = "LUDEVO_RES1"
        col.Name = "LugarDevolucion"
        col.Tabla = "R1"
        col.Width = 140
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function TarifaReserva() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Tarifa"
        col.Campo = "TARIFA_RES1"
        col.AliasCampo = "TARIFA_RES1"
        col.Name = "Tarifa"
        col.Tabla = "R1"
        col.Width = 80
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function ClienteReserva() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Cliente"
        col.Campo = "CLIENTE_RES1"
        col.AliasCampo = "CLIENTE_RES1"
        col.Name = "Cliente"
        col.Tabla = "R1"
        col.Width = 80
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function NomClienteReserva() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Nombre Cliente"
        col.Campo = "CL1.NOMBRE"
        col.AliasCampo = "NOM_CLIENTE"
        col.Name = "NombreCliente"
        col.Tabla = "CL1."
        col.Width = 200
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function FSalidaReserva() As DataGridDateColumn
        Dim col As DataGridDateColumn
        col = New DataGridDateColumn
        col.HeaderText = "F.Salida"
        col.Campo = "FSALIDA_RES1"
        col.AliasCampo = "FSALIDA_RES1"
        col.Name = "FSalida"
        col.Tabla = "R1"
        col.Width = 60
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function FPrevReserva() As DataGridDateColumn
        Dim col As DataGridDateColumn
        col = New DataGridDateColumn
        col.HeaderText = "F.Prev."
        col.Campo = "FPREV_RES1"
        col.AliasCampo = "FPREV_RES1"
        col.Name = "FPrev"
        col.Tabla = "R1"
        col.Width = 60
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

End Class
