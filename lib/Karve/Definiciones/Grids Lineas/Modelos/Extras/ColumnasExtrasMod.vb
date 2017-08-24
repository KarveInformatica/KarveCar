Imports CustomControls

Public Class ColumnasExtrasMod

    Public Function CodMod() As DataGridTextBoxColumn
        Dim col As New DataGridTextBoxColumn
        col.HeaderText = "Cód.Mod."
        col.Name = "CodMod"
        col.AliasCampo = "CODMOD_EV"
        col.Tabla = "MEV"
        col.Width = 80
        col.AllowFiltering = True
        col.IsVisible = False
        col.AllowGroup = False
        Return col
    End Function

    Public Function CodExtra() As DataGridBrowseBoxColumn
        Dim col As New DataGridBrowseBoxColumn
        col.HeaderText = "Código"
        col.Name = "Codigo"
        col.AliasCampo = "CODIGO_EV"
        col.Tabla = "MEV"
        col.Width = 80

        col.Desc_Datafield = "NOMBRE"
        col.Desc_DBTable = "EXTRASVEHI"
        col.Desc_DBPK = "CODIGO"

        col.AllowFiltering = True
        col.ReadOnly = False
        col.AllowGroup = False
        Return col
    End Function

    Public Function NombreExtra() As DataGridTextBoxColumn
        Dim col As New DataGridTextBoxColumn
        col.HeaderText = "Nombre"
        col.Name = "Nombre"
        col.AliasCampo = "NOMBRE"
        col.Tabla = "EV"
        col.Width = 200
        col.AllowFiltering = True
        Return col
    End Function

    Public Function PrecioExtra() As DataGridDecimalColumn
        Dim col As New DataGridDecimalColumn
        col.HeaderText = "Precio"
        col.Name = "Precio"
        col.AliasCampo = "PRECIO_EV"
        col.Tabla = "MEV"
        col.Width = 80
        col.AllowFiltering = True
        Return col
    End Function

    Public Function DeserieExtra() As DataGridCheckBoxColumn
        Dim col As New DataGridCheckBoxColumn
        col.HeaderText = "De Serie"
        col.Name = "De Serie"
        col.AliasCampo = "DESERIE"
        col.Tabla = "MEV"
        col.Width = 80
        col.AllowFiltering = True
        Return col
    End Function

    Public Function ObsExtra() As DataGridTextBoxColumn
        Dim col As New DataGridTextBoxColumn
        col.HeaderText = "Observaciones"
        col.Name = "Observaciones"
        col.AliasCampo = "OBS"
        col.Tabla = "MEV"
        col.Width = 500
        col.AllowFiltering = True
        Return col
    End Function

    Public Function UsuarioExtra() As DataGridTextBoxColumn
        Dim col As New DataGridTextBoxColumn
        col.HeaderText = "Usuario"
        col.Name = "Usuario"
        col.AliasCampo = "USUARIO"
        col.Tabla = "MEV"
        col.Width = 80
        col.AllowFiltering = True
        col.ReadOnly = True
        Return col
    End Function

    Public Function UltmodiExtra() As DataGridTextBoxColumn
        Dim col As New DataGridTextBoxColumn
        col.HeaderText = "Ultima Modi"
        col.Name = "Ultima Modi"
        col.AliasCampo = "ULTMODI"
        col.Tabla = "MEV"
        col.Width = 120
        col.AllowFiltering = True
        col.ReadOnly = True
        Return col
    End Function

End Class
