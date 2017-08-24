Imports CustomControls

Public Class TablasBancos

    Public Function BancosClienteFrom() As DataGridTable
        Dim Tb As DataGridTable
        Tb = New DataGridTable
        Tb.Table = "BANCO"
        Tb.AliasTabla = "BC"

        Return Tb
    End Function

End Class
