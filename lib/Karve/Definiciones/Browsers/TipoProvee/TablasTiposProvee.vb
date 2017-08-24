Imports CustomControls

Public Class TablasTiposProvee

    Public Function TiposVehiculoFrom() As DataGridTable
        Dim Tb As DataGridTable
        Tb = New DataGridTable
        Tb.Table = "TIPOPROVE"
        Tb.AliasTabla = "TPR"

        Return Tb
    End Function


End Class
