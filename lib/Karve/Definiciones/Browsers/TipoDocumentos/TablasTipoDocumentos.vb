Imports CustomControls

Public Class TablasTipoDocumentos
    Public Function TipoClienteFrom() As DataGridTable
        Dim Tb As DataGridTable
        Tb = New DataGridTable
        Tb.Table = "TIPODOCUMENTO"
        Tb.AliasTabla = "TIDO"

        Return Tb
    End Function
End Class
