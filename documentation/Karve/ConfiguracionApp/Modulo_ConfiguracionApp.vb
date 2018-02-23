Imports Karve.Theme
Imports System.Windows.Forms
Imports Telerik.WinControls.UI
Imports Telerik.WinControls.UI.RibbonBar
Imports VariablesGlobales

Public Module Modulo_ConfiguracionApp
#Region "Variables"

    Public CK As New ConfiguracionApp
    Public CE As New ConfiguracionApp
    Public CO As New ConfiguracionApp
    Public US As New ConfiguracionApp

    Public oficina As String
    Public empresa As String

    Public decimalesPrecios As Integer
    Public decimalesTotales As Integer
    Public decimalesCantidad As Integer
    Public decimalesPorcentaje As Integer

    Public VersionCrystal As crystalVersion

    Public TemaAplicacion As New Theme_Definicion

    Public Enum crystalVersion
        crystal13
    End Enum

    Public Enum tipoCodigo
        agentes 'NUM_INI_AGENTE'
        asientos 'NUM_INI_AS'
        atipicos 'NUM_INI_ATIPICOS'
        bia 'NUM_INI_BIA'
        cambiocs 'NUM_INI_CAMBIOCS'
        central 'NUM_INI_CENTRAL'
        clarga 'NUM_INI_CLARGA'
        clientes 'NUM_INI_CLI'
        cliente_garantia 'NUM_INI_CLIGARAN'
        cobh 'num_ini_cobh'
        cobro_multa 'NUM_INI_COBMUL'
        cobros 'NUM_INI_COBROS'
        comisionistas 'NUM_INI_COMI'
        compras 'NUM_INI_COMPRAS'
        contratos 'NUM_INI_CONTRA'
        docs_gral 'NUM_INI_DOCS_GRAL'
        elementos 'NUM_INI_ELEM'
        entrbono 'NUM_INI_ENTRBONO'
        entrmanu 'NUM_INI_ENTRMANU'
        exc 'NUM_INI_EXC'
        expedientes 'NUM_INI_EXPEDIENTES'
        facturas 'NUM_INI_FAC'
        faclar 'NUM_INI_FACLAR'
        facna 'NUM_INI_FACNA'
        racturas_rectificativas 'NUM_INI_FACREC'
        fact 'NUM_INI_FACT'
        facv 'NUM_INI_FACV'
        flarga 'NUM_INI_FLARGA'
        gar 'NUM_INI_GAR'
        compras_intracomuitarias 'NUM_INI_ICOMPRAS'
        incidencias_contratos 'NUM_INI_INCICON'
        incidencias 'NUM_INI_INCIDEN'
        incidencias_reservas 'NUM_INI_INCIRE'
        inmobilizaciones 'NUM_INI_INMO'
        lrcoti 'NUM_INI_LRCOTI'
        multas 'NUM_INI_MULTAS'
        ofertas_mantenimiento 'NUM_INI_OFERMANT'
        partes_transporte 'NUM_INI_partestransp'
        pedirenting 'NUM_INI_PEDIRENTING'
        personal 'NUM_INI_PERSONAL'
        peticiones 'NUM_INI_PETI'
        potenciale 'NUM_INI_POTENCIAL'
        potenciales 'NUM_INI_POTENCIALES'
        recibos_proveedor 'NUM_INI_PRECB'
        recibos_proveedor_man 'NUM_INI_PRECIBOS_MAN'
        presupuesto_a 'NUM_INI_PRESU_A'
        presupuesto_c 'NUM_INI_PRESU_C'
        presupuesto_m 'NUM_INI_PRESU_M'
        presupuesto_r 'NUM_INI_PRESU_R'
        presupuesto_v 'NUM_INI_PRESU_V'
        previent 'NUM_INI_PREVIENT'
        proveedores 'NUM_INI_PROVEE'
        propirtarios 'NUM_INI_PRPOPIE'
        rec 'NUM_INI_REC'
        recibos_man 'NUM_INI_RECIBOS_MAN'
        reclamaciones_cliente 'NUM_INI_RECLAMACLI'
        remesa_pagare 'NUM_INI_REMESA_PAGARE'
        repos 'NUM_INI_REPOS'
        res 'NUM_INI_RES'
        siniestros 'NUM_INI_SINIES'
        compras_t 'NUM_INI_TCOMPRAS'
        tras 'NUM_INI_TRAS'
        vehiculos 'NUM_INI_VEHI'
        cambio_vehiculos 'NUM_INI_VEHI_CAMBIO'
        vendedores 'NUM_INI_VEN'

        albaranes 'TL_NUM_INI_ALBARAN'
        albaranes_venta 'TL_NUM_INI_ALBVTA'
        facturas_proforma 'TL_NUM_INI_FACPROFO'
        albaranes_proveedor 'TL_NUM_INI_PALBARAN'
        pedidos_cliente 'TL_NUM_INI_PEDICLI'
        pedidos_proveedor 'TL_NUM_INI_PEDIPRO'
        preuspuestos 'TL_NUM_INI_PRESU'
        presupuestos_proveedor 'TL_NUM_INI_PRESUPRO'

        albaran_devolucion 'NUM_INI_ALB_DEVOLUCION'
        albaran_entrega 'NUM_INI_ALB_ENTREGA'
        alqreser 'NUM_INI_ALQRESER'
        ctrcv 'NUM_INI_CTRCV'
        contrato_mantenimiento 'NUM_INI_CTRMANT'
        ctrper 'NUM_INI_CTRPER'
        fac_bu 'NUM_INI_FAC_BU'
        fac_ctrmant 'NUM_INI_FAC_CTRMANT'
        fac_oti 'NUM_INI_FAC_OTI'
        fac_renting 'NUM_INI_FAC_RENTING'
        facclc 'NUM_INI_FACCLC'
        facot 'NUM_INI_FACOT'
        lecturas 'NUM_INI_LECTURAS'
        liexam 'NUM_INI_LIEXAM'
        obras 'NUM_INI_OBRAS'
        ofertas 'NUM_INI_OFERTAS'
        ot 'NUM_INI_OT'
        otp 'NUM_INI_OTP'
        prefac 'NUM_INI_PREFAC'
        presu_x 'NUM_INI_PRESU_X'
        produccion 'NUM_INI_PRODUCCION'
        regula 'NUM_INI_REGULA'
        bienes 'TL_NUM_INI_BIENES'
        garantia 'TL_NUM_INI_GARANTIA'
        traspaso 'TL_NUM_INI_TRASPASO'
    End Enum
#End Region

#Region "Autocodigos"

    Public Function dameCodigoMax(ByRef db As ASADB.Connection, Tabla As String, Codigo As String, Optional Criterio As String = "", Optional Rellenar As Boolean = False) As String
        Dim _sCod As String = ""
        Dim _sSQL As String = ""
        Dim _sSQLT As String = ""
        Dim _sWhere As String = ""
        Dim _lWidth As Long
        '====================================================================================
        If Criterio <> "" Then _sWhere = Criterio
        _sSQL = " SELECT CAST(ISNULL(MAX(ISNULL(" & Codigo & ", 0)), 0) AS INTEGER) + 1 MAXIMO " & vbNewLine & _
                " FROM  " & Tabla & vbNewLine & _
                _sWhere

        _sCod = db.executeQuery(_sSQL)
        If Rellenar Then
            _sSQLT = " SELECT [WIDTH] FROM SYSCOLUMN SC INNER JOIN SYSTABLE ST ON SC.TABLE_ID = ST.TABLE_ID WHERE TABLE_TYPE = 'BASE' AND TABLE_NAME = " & vd.setApostrofa(Tabla) & " AND COLUMN_NAME = " & vd.setApostrofa(Codigo)
            _lWidth = db.executeQuery(_sSQLT)
            _sCod = Right(Replace(Space(_lWidth), " ", "0") & _sCod, _lWidth)
        End If
        Return _sCod
    End Function

    Public Function dameCodigoAgregar(ByRef db As ASADB.Connection, ByVal tipo As tipoCodigo, Optional ByVal emp As String = "", Optional ByVal ofi As String = "") As String
        Dim tabla As String = ""
        Dim pk As String = ""
        Dim num_ini As String = ""
        Dim ofi_emp As String = ""
        Dim length As Integer = 0

        If emp = "" Then emp = CE.GStr("EMPRESA")
        If ofi = "" Then ofi = CO.GStr("OFICINA")

        Try
            setCodigos(tipo, tabla, pk, num_ini, ofi_emp, length)
            dameCodigoAgregar = db.callSpResults("spGetCodigoAgregar", {tabla, pk, emp, ofi, num_ini, ofi_emp}).Tables(0).Rows(0).Item(0)
            'dameCodigoAgregar = db.callSpResults("spGetCodigoAgregar", {tabla, pk, emp, ofi, num_ini, ofi_emp, length}).Tables(0).Rows(0).Item(0)
        Catch
            Throw New Exception("Error al obtener el código.")
        End Try
    End Function

    Private Sub setCodigos(ByVal tipo As tipoCodigo, ByRef tabla As String, ByRef pk As String, ByRef num_ini As String, ByRef ofi_emp As String, ByRef length As Integer)
        Select Case tipo
            Case tipoCodigo.agentes : LoadAgentes(tabla, pk, num_ini, ofi_emp, length)
            Case tipoCodigo.asientos 'NUM_INI_AS'
            Case tipoCodigo.atipicos 'NUM_INI_ATIPICOS'
            Case tipoCodigo.bia 'NUM_INI_BIA'
            Case tipoCodigo.cambiocs 'NUM_INI_CAMBIOCS'
            Case tipoCodigo.central 'NUM_INI_CENTRAL'
            Case tipoCodigo.clarga 'NUM_INI_CLARGA'
            Case tipoCodigo.clientes : LoadClientes(tabla, pk, num_ini, ofi_emp, length)
            Case tipoCodigo.contratos : LoadContratos(tabla, pk, num_ini, ofi_emp, length)
            Case tipoCodigo.res : LoadReservas(tabla, pk, num_ini, ofi_emp, length)
            Case tipoCodigo.vehiculos : LoadVehiculo(tabla, pk, num_ini, ofi_emp, length)
            Case tipoCodigo.vendedores : LoadVendedor(tabla, pk, num_ini, ofi_emp, length)
        End Select
    End Sub

    Private Sub LoadAgentes(ByRef tabla As String, ByRef pk As String, ByRef num_ini As String, ByRef ofi_emp As String, ByRef length As Integer)
        tabla = ""
        pk = ""
        num_ini = "NUM_INI_AGENTE"
        ofi_emp = ""
        length = 0
    End Sub

    Private Sub LoadClientes(ByRef tabla As String, ByRef pk As String, ByRef num_ini As String, ByRef ofi_emp As String, ByRef length As Integer)
        tabla = "CLIENTES1"
        pk = "NUMERO_CLI"
        num_ini = "NUM_INI_CLI"
        ofi_emp = "CLI_EMP"
        length = 7
    End Sub

    Private Sub LoadContratos(ByRef tabla As String, ByRef pk As String, ByRef num_ini As String, ByRef ofi_emp As String, ByRef length As Integer)
        tabla = "CONTRATOS1"
        pk = "NUMERO"
        num_ini = "NUM_INI_CONTRA"
        ofi_emp = "CONTRA_EMP"
        length = 10
    End Sub

    Private Sub LoadReservas(ByRef tabla As String, ByRef pk As String, ByRef num_ini As String, ByRef ofi_emp As String, ByRef length As Integer)
        tabla = "RESERVAS1"
        pk = "NUMERO_RES"
        num_ini = "NUM_INI_RES"
        ofi_emp = "RES_EMP"
        length = 10
    End Sub

    Private Sub LoadVehiculo(ByRef tabla As String, ByRef pk As String, ByRef num_ini As String, ByRef ofi_emp As String, ByRef length As Integer)
        tabla = "VEHICULO1"
        pk = "CODIINT"
        num_ini = "NUM_INI_VEHI"
        ofi_emp = "VEHI_EMP"
        length = 7
    End Sub
    Private Sub LoadVendedor(ByRef tabla As String, ByRef pk As String, ByRef num_ini As String, ByRef ofi_emp As String, ByRef length As Integer)
        tabla = "VENDEDOR"
        pk = "NUM_VENDE"
        num_ini = "NUM_INI_VEN"
        ofi_emp = "VEND_EMP"
        length = 7
    End Sub
#End Region

    Public Sub ConfiguraCintaEdicion(ByRef rbn As RadRibbonBar)
        For Each cmdTab As RibbonTab In rbn.CommandTabs
            cmdTab.Font = TemaAplicacion.Font
            For Each it In cmdTab.Items
                RecorreCinta(it)
            Next
        Next
    End Sub

    Private Sub RecorreCinta(Item As Object)
        If Item.GetType Is GetType(RadButtonElement) Then
            Dim It As New RadButtonElement
            Dim Sz As New Drawing.Size

            It = Item
            If It.TextImageRelation = TextImageRelation.ImageAboveText Then
                With It
                    Sz.Width = TemaAplicacion.BotonesCinta.Width
                    Sz.Height = TemaAplicacion.BotonesCinta.Height

                    .AutoSize = TemaAplicacion.BotonesCinta.AutoSize
                    .MinSize = Sz
                    .Font = TemaAplicacion.Font
                    .TextAlignment = TemaAplicacion.TextAlignment
                    .ImageAlignment = TemaAplicacion.ImageAlignment
                End With
            ElseIf It.TextImageRelation = TextImageRelation.ImageBeforeText Then
                With It
                    Sz.Width = TemaAplicacion.BotonesCinta.HoritzontalWidth
                    Sz.Height = TemaAplicacion.BotonesCinta.HoritzontalHeight

                    .AutoSize = TemaAplicacion.BotonesCinta.HoritzontalAutoSize
                    .MinSize = Sz
                    .Font = TemaAplicacion.Font
                    .TextAlignment = TemaAplicacion.HoritzontalTextAlignment
                    .ImageAlignment = TemaAplicacion.HoritzontalImageAlignment
                End With
            End If
        Else
            Try
                Item.Font = TemaAplicacion.Font
                For Each Item In Item.items
                    RecorreCinta(Item)
                Next
            Catch
            End Try
        End If
    End Sub

End Module
