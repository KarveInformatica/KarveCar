Imports CustomControls
Imports VariablesGlobales

Public Class ColumnasProvee

    Public Function NumeroProvee() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Número"
        col.AliasCampo = "NUM_PROVEE"
        col.Name = "NUM_PROVEE"
        col.Tabla = "P1"
        col.Width = 80
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function NombreProvee() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Nombre"
        col.AliasCampo = "NOMBRE"
        col.Name = "NOMBRE"
        col.Campo = "NOMBRE"
        col.Tabla = "P1"
        col.Width = 200
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function NifProvee() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "N.I.F."
        col.AliasCampo = "NIF"
        col.Name = "NIF"
        col.Tabla = "P1"
        col.Width = 100
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function ComercialProvee() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Comercial"
        col.AliasCampo = "COMERCIAL"
        col.Name = "COMERCIAL"
        col.Tabla = "P2"
        col.Width = 200
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function TelefonoProvee() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Teléfono"
        col.AliasCampo = "TELEFONO"
        col.Name = "TELEFONO"
        col.Tabla = "P1"
        col.Width = 100
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function DireccionProvee() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Dirección"
        col.AliasCampo = "DIRECCION"
        col.Name = "DIRECCION"
        col.Tabla = "P1"
        col.Width = 200
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function CPProvee() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "CP"
        col.AliasCampo = "CP"
        col.Name = "CP"
        col.Tabla = "P1"
        col.Width = 80
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function PoblacionProvee() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Población"
        col.AliasCampo = "POBLACION"
        col.Name = "POBLACION"
        col.Tabla = "P1"
        col.Width = 200
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function EmailProvee() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "eMail"
        col.AliasCampo = "EMAIL"
        col.ExpresionBd = "REPLACE(EMAIL, '#', '@')"
        col.Tabla = "P1"
        col.Width = 200
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function CtaProvee() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Cuenta"
        col.AliasCampo = "CONTABLE"
        col.Name = "CONTABLE"
        col.Tabla = "P2"
        col.Width = 100
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function NombreTipoProvee() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Tipo"
        col.AliasCampo = "NOM_TIPO"
        col.Name = "NOM_TIPO"
        col.ExpresionBd = "TP.NOMBRE"
        'col.Campo = "NOMBRE"
        col.Tabla = "TP"
        col.Width = 150
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function FAeatProvee() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "FAeat"
        col.AliasCampo = "F_AEAT"
        col.Name = "F_AEAT"
        col.Tabla = "P1"
        col.Width = 100
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function CtaGastoProvee() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "C.Gasto"
        col.AliasCampo = "CUGASTO"
        col.Name = "CUGASTO"
        col.Tabla = "P2"
        col.Width = 100
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function PlazoProvee() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Plazo"
        col.AliasCampo = "PLAZO"
        col.Name = "PLAZO"
        col.Tabla = "P2"
        col.Width = 70
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function Plazo2Provee() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Plazo2"
        col.AliasCampo = "PLAZO2"
        col.Name = "PLAZO2"
        col.Tabla = "P2"
        col.Width = 70
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function Plazo3Provee() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Plazo3"
        col.AliasCampo = "PLAZO3"
        col.Name = "PLAZO3"
        col.Tabla = "P2"
        col.Width = 70
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function FPagoNomProvee() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Forma Pago"
        col.AliasCampo = "FPAGO_NOM"
        col.Name = "FPAGO_NOM"
        'col.Campo = "NOMBRE"
        col.ExpresionBd = "FP.NOMBRE"
        col.Tabla = "FP"
        col.Width = 150
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function DiaPagoProvee() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Dia"
        col.AliasCampo = "DIA"
        col.Name = "DIA"
        col.Tabla = "P2"
        col.Width = 70
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function DiaPago2Provee() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Dia 2"
        col.AliasCampo = "DIA2"
        col.Name = "DIA2"
        col.Tabla = "P2"
        col.Width = 70
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function DiaPago3Provee() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Dia 3"
        col.AliasCampo = "DIA3"
        col.Name = "DIA3"
        col.Tabla = "P2"
        col.Width = 70
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function MesVacaProvee() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Mes Vaca."
        col.AliasCampo = "MES"
        col.Name = "MES"
        col.ExpresionBd = CaseMeses_SQL("MESVACA")
        col.Width = 80
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function MesVaca2Provee() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Mes Vaca.2"
        col.AliasCampo = "MES2"
        col.Name = "MES2"
        col.ExpresionBd = CaseMeses_SQL("MESVACA2")
        col.Tabla = "P1"
        col.Width = 70
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function DivisaProvee() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Divisa"
        col.AliasCampo = "DIVISA"
        col.Name = "DIVISA"
        col.Tabla = "P2"
        col.Width = 70
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function UltimaModiProvee() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Ult.Modi"
        col.AliasCampo = "ULTMODI"
        col.Name = "ULTMODI"
        col.Tabla = "P1"
        col.Width = 100
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function UsuModiProvee() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Usu.Modi"
        col.AliasCampo = "USUARIO"
        col.Name = "USUARIO"
        col.Tabla = "P1"
        col.Width = 70
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

End Class
