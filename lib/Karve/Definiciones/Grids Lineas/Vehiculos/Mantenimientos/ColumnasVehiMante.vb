Imports CustomControls
Imports Telerik.WinControls.UI

Public Class ColumnasVehiMante

    Public Function GrVacio() As DataGridColumnGroup
        Dim col As DataGridColumnGroup
        col = New DataGridColumnGroup()
        col.Text = ""
        Return col
    End Function

    Public Function CodigoMante() As DataGridBrowseBoxColumn
        Dim col As New DataGridBrowseBoxColumn
        col.HeaderText = "Código Mantenimiento"
        col.Name = "CodigoMantenimiento"
        col.AliasCampo = "CODIGO_MANT_MV"
        col.Tabla = "MV"
        col.Width = 100
        col.AllowFiltering = True

        col.Desc_Datafield = "NOMBRE_MAN"
        col.Desc_DBTable = "MANTENIMIENTO"
        col.Desc_DBPK = "CODIGO_MAN"
        Return col
    End Function

    Public Function Mantenimiento() As DataGridTextBoxColumn
        Dim col As New DataGridTextBoxColumn
        col.HeaderText = "Mantenimiento"
        col.Name = "Mantenimiento"

        col.Width = 200
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function UltMante() As DataGridColumnGroup
        Dim col As DataGridColumnGroup
        col = New DataGridColumnGroup()
        col.Name = "UltMante"
        col.Text = "Ult. Mante"
        Return col
    End Function

    Public Function FechaUltMante() As DataGridDateColumn
        Dim col As DataGridDateColumn
        col = New DataGridDateColumn
        col.HeaderText = "Fecha"
        col.Campo = "ULT_FEC_MV"
        col.Name = "FechaUltMante"
        col.Tabla = "MV"
        col.Width = 80
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function KmUltMante() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Km"
        col.Campo = "ULT_KM_MV"
        col.Name = "KmUltMante"
        col.Tabla = "MV"
        col.Width = 80
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function ProxMante() As DataGridColumnGroup
        Dim col As DataGridColumnGroup
        col = New DataGridColumnGroup()
        col.Name = "ProxMante"
        col.Text = "Prox. Mante"
        Return col
    End Function

    Public Function FechaProxMante() As DataGridDateColumn
        Dim col As DataGridDateColumn
        col = New DataGridDateColumn
        col.HeaderText = "Fecha"
        col.Campo = "PROX_FEC_MV"
        col.Name = "FechaProxMante"
        col.Tabla = "MV"
        col.Width = 80
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function KmProxMante() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Km"
        col.Campo = "PROX_KM_MV"
        col.Name = "KmProxMante"
        col.Tabla = "MV"
        col.Width = 80
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function ManteVehi() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Km"
        col.Campo = "CODIGO_VEHI_MV"
        col.Name = "ManteVehi"
        col.Tabla = "MV"
        col.Width = 80
        col.ReadOnly = True
        col.AllowFiltering = True
        col.VisibleInColumnChooser = False
        Return col
    End Function

End Class
