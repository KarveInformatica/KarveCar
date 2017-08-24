Imports CustomControls

Public Class ColumnasCli

    Public Function NumeroCli() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Número"
        col.AliasCampo = "NUMERO_CLI"
        col.Name = "NUMERO_CLI"
        col.Tabla = "C1"
        col.Width = 80
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function FecAltaCli() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.Tabla = "C2"
        col.HeaderText = "Fecha Alta"
        col.AliasCampo = "ALTA"
        col.Name = "ALTA"
        col.ExpresionBd = " DATEFORMAT(C2.ALTA, 'yyyy/mm/dd') "
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function NifCli() As DataGridTextBoxColumn
        Dim col = New DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.Tabla = "C1"
        col.HeaderText = "Nif"
        col.AliasCampo = "NIF"
        col.Name = "NIF"
        col.Campo = "NIF"
        col.Width = 80
        col.AllowFiltering = True
        col.IsVisible = False
        col.VisibleInColumnChooser = True
        Return col
    End Function

    Public Function NombreCli() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.Tabla = "C1"
        col.HeaderText = "Nombre Cliente"
        col.AliasCampo = "NOMBRE"
        col.Name = "NOMBRE"
        col.Width = 200
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function DireccionCli() As DataGridTextBoxColumn
        Dim col = New DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.Tabla = "C1"
        col.HeaderText = "Dirección"
        col.AliasCampo = "DIRECCION"
        col.Name = "DIRECCION"
        col.Width = 200
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function CpCli() As DataGridTextBoxColumn
        Dim col = New DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.Tabla = "C1"
        col.HeaderText = "CP"
        col.AliasCampo = "CP"
        col.Name = "CP"
        col.Width = 60
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function PoblacionCli() As DataGridTextBoxColumn
        Dim col = New DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.Tabla = "C1"
        col.HeaderText = "Población"
        col.AliasCampo = "POBLACION"
        col.Name = "POBLACION"
        col.Width = 200
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function TelefonoCli() As DataGridTextBoxColumn
        Dim col = New DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.Tabla = "C1"
        col.HeaderText = "Teléfono"
        col.AliasCampo = "TELEFONO"
        col.Name = "TELEFONO"
        col.Width = 80
        col.AllowFiltering = True
        col.IsVisible = False
        col.VisibleInColumnChooser = True
        Return col
    End Function

    Public Function Telefono2Cli() As DataGridTextBoxColumn
        Dim col = New DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.Tabla = "C1"
        col.HeaderText = "Teléfono 2"
        col.AliasCampo = "TEL2"
        col.Name = "TEL2"
        col.Width = 80
        col.AllowFiltering = True
        col.IsVisible = False
        col.VisibleInColumnChooser = True
        Return col
    End Function

    Public Function FaxCli() As DataGridTextBoxColumn
        Dim col = New DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.Tabla = "C1"
        col.HeaderText = "Fax"
        col.AliasCampo = "FAX"
        col.Name = "FAX"
        col.Width = 80
        col.AllowFiltering = True
        col.IsVisible = False
        col.VisibleInColumnChooser = True
        Return col
    End Function

    Public Function MailCli() As DataGridTextBoxColumn
        Dim col = New DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.Tabla = "C2"
        col.HeaderText = "eMail"
        col.AliasCampo = "EMAIL"
        col.Name = "EMAIL"
        col.ExpresionBd = " (REPLACE(EMAIL, '#', '@'))"
        col.Width = 180
        col.AllowFiltering = True
        col.IsVisible = False
        col.VisibleInColumnChooser = True
        Return col
    End Function

    Public Function ObsCli() As DataGridTextBoxColumn
        Dim col = New DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.Tabla = "C1"
        col.HeaderText = "Observaciones"
        col.AliasCampo = "OBSERVA"
        col.Campo = "OBSERVA"
        col.Name = "OBSERVA"
        col.Width = 180
        col.AllowFiltering = True
        col.IsVisible = False
        col.VisibleInColumnChooser = True
        Return col
    End Function

End Class

