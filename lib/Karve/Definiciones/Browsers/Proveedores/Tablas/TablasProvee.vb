Imports CustomControls

Public Class TablasProvee

    Public Function Provee1From() As DataGridTable
        Dim Tb As DataGridTable
        Tb = New DataGridTable
        Tb.Table = "PROVEE1"
        Tb.AliasTabla = "P1"

        Return Tb
    End Function

    Public Function Provee2() As DataGridTable
        Dim Tb As DataGridTable
        Tb = New DataGridTable
        Tb.Table = "PROVEE2"
        Tb.Criterio = "ON P1.NUM_PROVEE = P2.NUM_PROVEE"
        Tb.Join = DataGridTable.euCriteriosJoin.InnerJoin
        Tb.AliasTabla = "P2"

        Return Tb
    End Function

    Public Function TipoProvee() As DataGridTable
        Dim Tb As DataGridTable
        Tb = New DataGridTable
        Tb.Table = "TIPOPROVE"
        Tb.Criterio = "ON TIPO = NUM_TIPROVE"
        Tb.Join = DataGridTable.euCriteriosJoin.LeftJoin
        Tb.AliasTabla = "TP"

        Return Tb
    End Function

    Public Function FormasProvee() As DataGridTable
        Dim Tb As DataGridTable
        Tb = New DataGridTable
        Tb.Table = "FORPRO"
        Tb.Criterio = "ON P2.FORPA = FP.CODIGO"
        Tb.Join = DataGridTable.euCriteriosJoin.LeftJoin
        Tb.AliasTabla = "FP"

        Return Tb
    End Function

End Class
