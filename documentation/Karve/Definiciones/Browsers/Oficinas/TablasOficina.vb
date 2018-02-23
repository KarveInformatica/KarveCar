Imports CustomControls

Public Class TablasOficina

    Public Function OficinaFrom() As DataGridTable
        Dim Tb As DataGridTable
        Tb = New DataGridTable
        Tb.Table = "OFICINAS"
        Tb.AliasTabla = "OFI"

        Return Tb
    End Function

    Public Function Empresa() As DataGridTable
        Dim Tb As DataGridTable
        Tb = New DataGridTable
        Tb.Table = "SUBLICEN"
        Tb.Criterio = "ON OFI.SUBLICEN = EMP.CODIGO"
        Tb.Join = DataGridTable.euCriteriosJoin.LeftJoin
        Tb.AliasTabla = "EMP"

        Return Tb
    End Function

    Public Function Provincias() As DataGridTable
        Dim Tb As DataGridTable
        Tb = New DataGridTable
        Tb.Table = "PROVINCIA"
        Tb.Criterio = "ON OFI.PROVINCIA = PROV.SIGLAS"
        Tb.Join = DataGridTable.euCriteriosJoin.LeftJoin
        Tb.AliasTabla = "PROV"

        Return Tb
    End Function

    Public Function ZonaOfi() As DataGridTable
        Dim Tb As DataGridTable
        Tb = New DataGridTable
        Tb.Table = "ZONAOFI"
        Tb.Criterio = "ON OFI.ZONAOFI = ZO.COD_ZONAOFI"
        Tb.Join = DataGridTable.euCriteriosJoin.LeftJoin
        Tb.AliasTabla = "ZO"

        Return Tb
    End Function
End Class
