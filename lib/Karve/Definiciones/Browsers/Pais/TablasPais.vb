Imports CustomControls

Public Class TablasPais

    Public Function PaisFrom() As DataGridTable
        Dim Tb As DataGridTable
        Tb = New DataGridTable
        Tb.Table = "PAIS"
        Tb.AliasTabla = "P"

        Return Tb
    End Function

    Public Function Idiomas() As DataGridTable
        Dim Tb As DataGridTable
        Tb = New DataGridTable
        Tb.Table = "IDIOMAS"
        Tb.Criterio = "ON P.IDIOMA_PAIS = LANG.CODIGO"
        Tb.Join = DataGridTable.euCriteriosJoin.LeftJoin
        Tb.AliasTabla = "LANG"

        Return Tb
    End Function

End Class
