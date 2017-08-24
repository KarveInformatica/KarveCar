Imports CustomControls

Public Class TablasExtrasMod

    Public Function ExtraMod() As DataGridTable
        Dim tb As New DataGridTable
        tb = New DataGridTable
        tb.Table = "MODELO_EXTRASVEHI"
        tb.AliasTabla = "MEV"
        Return tb
    End Function

    Public Function Extras() As DataGridTable
        Dim tb As New DataGridTable
        tb = New DataGridTable
        tb.Table = "EXTRASVEHI"
        tb.AliasTabla = "EV"
        tb.Criterio = "ON MEV.CODIGO_EV = EV.CODIGO"
        tb.Join = DataGridTable.euCriteriosJoin.LeftJoin
        Return tb
    End Function

End Class
