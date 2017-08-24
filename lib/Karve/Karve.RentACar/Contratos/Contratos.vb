Imports Karve.ConfiguracionApp
Imports Karve.Logic
Imports Telerik.WinControls.UI
Imports VariablesGlobales
Imports Karve.Definiciones

Public Class Contratos
    Inherits Bases.frmBase

#Region "Variables"
    Private operLineas As New OperacionesLineas
    Private kMsgBox As New CustomControls.kMsgBox
    Private DV As DatosVehiculo
    Private WithEvents ribbon As New RibbonContratos

    Private estadoCtr As EstadoCtr
    Private esLarga As Boolean

#End Region

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        'Ribbon_Bar.CommandTabs.Add(rbtContrato)
        pvwBase.PanelCabezera = pnlCabecera
        rbnAction.CommandTabs.AddRange(ribbon.CommandTabs)
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

#Region "Setters"

    Protected Overrides Sub setTables()
        'Me.rbnAction.CommandTabs.AddRange(New Telerik.WinControls.RadItem() {Me.rbtEdicion})

        With New frmTablasContratosRC
            tablasEdit = .Tablas
        End With
        pkEdit = tablasEdit.Where(Function(o) o.Tabla = "CONTRATOS1").First.CamposID.Where(Function(o) o.CampoID = "NUMERO").First

        tablaUltmodi.TableAlias = "C1"
        tablaUltmodi.CampoID = "ULTMODI_CON1"

        tablaUsumodi.TableAlias = "C1"
        tablaUsumodi.CampoID = "USUARIO_CON1"

        tablaOficina.TableAlias = "C1"
        tablaOficina.CampoID = "OFICINA_CON1"

        tablaEmpresa.TableAlias = "C1"
        tablaEmpresa.CampoID = "SUBLICEN_CON1"
    End Sub

    Protected Overrides Sub setLupas()
        Me.dtfGrupo.Lupa = lupaGruposVehiculo
        Me.dtfVehiculo.Lupa = lupaVehiculos
        Me.dtfTarifa.Lupa = lupaTarifas
        Me.dtfCliente.Lupa = lupaClientes
        Me.dtfConductor.Lupa = lupaClientes
        Me.dtfOfiSalida.Lupa = lupaOficina
        Me.dtfOfiLlegada.Lupa = lupaOficina
        Me.dtfEmpresaOficina.Lupa = lupaOficina
        Me.dtfReserva.Lupa = lupaReservas
        Me.dtfOrigen.Lupa = lupaOrigenesCliente
        Me.dtfIdioma.Lupa = lupaIdiomas
    End Sub

    Protected Overrides Sub setOpenForm()
        Me.dtfGrupo.OpenForm = GruposVehiculo
        Me.dtfVehiculo.OpenForm = Vehiculos
        Me.dtfOrigen.OpenForm = OrigenesCliente
        Me.dtfIdioma.OpenForm = Idiomas
    End Sub

    Private Sub Contratos_HandleCreated(sender As Object, e As EventArgs) Handles Me.HandleCreated
        'Ribbon_Bar.CommandTabs.Add(rbtContrato)
        Me.estadoCtr = Contratos_Module.EstadoCtr.Null
    End Sub

    Private Sub Contratos_Load(sender As Object, e As EventArgs) Handles Me.Load
        dgvLiCon.DBConnection = db
        dgvLiCon.generateGrid()

        dgvBasesCon.DBConnection = db
        dgvBasesCon.generateGrid()
    End Sub

    Private Sub Contratos_SelectedPageChanged(sender As Object, e As EventArgs) Handles Me.SelectedPageChanged
        Select Case pvwBase.SelectedPage.Name
            Case pvpGeneral.Name
                pnlGenIzq.Focus()
                dtfCliente.Focus()
            Case pvpCierre.Name
                pnlCierreIzq.Focus()
                dtdFRetorno.Focus()
                If Me.estadoCtr <> Contratos_Module.EstadoCtr.Cerrado Then
                    dtdFRetorno.Value_Data = dtdFPrevista.Value_Data

                End If
            Case pvpOtrosDatos.Name
                pnlOtrosDatosIzq.Focus()
                dtfFcobro.Focus()
            Case pvpConductores.Name
                pnlConductoresIzq.Focus()
                dtfConductorDetalles.Focus()
        End Select
    End Sub

    Private Sub Contratos_SelectedPageChanging(sender As Object, e As Telerik.WinControls.UI.RadPageViewCancelEventArgs) Handles Me.SelectedPageChanging
        Select Case e.Page.Name
            Case pvpGeneral.Name : pnlGenDer.Controls.Add(gbxCotiza)
            Case pvpCierre.Name : pnlCierreDer.Controls.Add(gbxCotiza)
        End Select
    End Sub

    Protected Overrides Sub setCrystalProperties()
        reportPath = "euros/Contra.rpt"
        reportWhere = "{CT1.NUMERO} = '" & CodigoEdicion & "' AND {LC.INCLUIDO} <> 0"
        reportName = "Contrato_" & CodigoEdicion
    End Sub

    Protected Overrides Sub setIconosExtra()
        ribbon.setIconos()
    End Sub

    Private Sub setEstadoContrato()
        esLarga = radLarga.IsChecked

        If Me.Estado = EstadoForm.Agregar Then
            estadoCtr = Contratos_Module.EstadoCtr.Null
        Else
            estadoCtr = Contratos_Module.EstadoCtr.Abierto

            If Not IsDBNull(dtsEdit.Tables("C1").Rows(0).Item("FRETOR_CON1")) Then
                estadoCtr = Contratos_Module.EstadoCtr.Cerrado
            End If
            If Not IsDBNull(dtsEdit.Tables("C1").Rows(0).Item("ULTFRANUM_CON1")) And Not esLarga Then
                estadoCtr = Contratos_Module.EstadoCtr.Facturado
            End If
        End If

        ribbon.EstadoCtr = estadoCtr
    End Sub
#End Region

#Region "Add Extra"

    Protected Overrides Sub AddExtra()
        dtfCodigo.Text_Data = "AGREGAR"
        dtdFSalida.Value_Data = Today
        dtdFSalida.Default_Value = Today
        dtdFPrevista.Min_Value = dtdFSalida.Value_Data
        dtdFPrevista.MinDate = dtdFSalida.Value_Data
        dtdFPrevista.Value_Data = Today.AddDays(1)
        dtdFPrevista.Default_Value = Today.AddDays(1)

        dttHSalida.Time = Now.TimeOfDay
        dttHPrevista.Time = Now.TimeOfDay

        dtdFecha.Value_Data = Today
        dttHora.Time = Now.TimeOfDay

        dgvLiCon.EnforceConstrains = False
        cargaGrids()
        rdgTipoAlquiler.DefaultIndex = CE.GStr("DURACION_CON")
        If rdgTipoAlquiler.DefaultIndex = "" Then
            rdgTipoAlquiler.DefaultIndex = "C"
        End If
        rdgDevolucion.Index = CE.GBool("RECALC_CE")
        dtfEmpresaOficina.Text_Oficina = CO.GStr("OFICINA")
        Me.dtfOfiSalida.Text_Data = CO.GStr("OFICINA")
        Me.dtfOfiLlegada.Text_Data = CO.GStr("OFICINA")
        Me.dtfUsuEntrega.Text_Data = US.GStr("CODIGO")

        dtfReserva.ReadOnly_Data = False
        dtfReserva.Focus()

        dtfDiasPrevistos.Text_Data = 1

        setEstadoContrato()
    End Sub

#End Region

#Region "Load Extra"

    Protected Overrides Sub LoadExtra()
        Me.estadoCtr = Contratos_Module.EstadoCtr.Cargando
        dtdFPrevista.Min_Value = dtdFSalida.Value_Data
        dtdFPrevista.MinDate = dtdFSalida.Value_Data
        loadVehi()
        If VD.Ok_DataSet(dtsEdit, dtfLitrosSalida.DataTable) Then trbLitrosSale.LitrosAct = VD.getInt(dtsEdit.Tables(dtfLitrosSalida.DataTable).Rows(0).Item(dtfLitrosSalida.DataField))
        If VD.Ok_DataSet(dtsEdit, dtfCombusLlegadaCierre.DataTable) Then trbLitrosLlega.LitrosAct = VD.getInt(dtsEdit.Tables(dtfCombusLlegadaCierre.DataTable).Rows(0).Item(dtfCombusLlegadaCierre.DataField))
        cargaGrids()
        cargarDatosCierre()
        setEstadoContrato()
        Me.estadoCtr = Contratos_Module.EstadoCtr.Cargando
    End Sub

    Protected Overrides Sub loadAfterSave()
        Me.estadoCtr = Contratos_Module.EstadoCtr.Cargando
        cargaGrids()
        cargarDatosCierre()
        setEstadoContrato()
    End Sub

    Private Sub cargaGrids()
        dgvLiCon.idRel = tablasEdit(0).CamposID(0).CodEdit
        dgvLiCon.loadGrid()
        dgvLiCon.Tarifa = dtfTarifa.Text_Data
        dgvLiCon.Grupo = dtfGrupo.Text_Data

        If (CE.GBool("TIPOPORCONCEPTO")) Then
            dgvBasesCon.idRel = tablasEdit(0).CamposID(0).CodEdit
            dgvBasesCon.loadGrid()
            dtfBrutoCon.Visible = True
            dtfDto.Visible = True
            dtfBasei.Visible = False
            dtfIVA.Visible = False
            dtfCuota.Visible = False
        Else
            dtfBrutoCon.Visible = False
            dtfDto.Visible = False
            dtfBasei.Visible = True
            dtfIVA.Visible = True
            dtfCuota.Visible = True
            If CE.GBool("MODIFICA_IVA") Then
                dtfIVA.ReadOnly_Data = False
            End If
            dtfIVA.Descripcion = CE.GStr("NOMIMP")
        End If
    End Sub

    Private Sub loadVehi(Optional ByVal setCombus As Boolean = False)
        DV = New DatosVehiculo(dtfVehiculo.Text_Data, db)
        If DV.Datos.Tables(0).Rows.Count <> 0 Then
            dtfMatricula.Query_on_Text_Changed = False
            Me.dtfMatricula.Text_Data = DV.Datos.Tables(0).Rows(0).Item("MATRICULA").ToString
            dtfMatricula.Query_on_Text_Changed = True
            dtfMatricula.ReQuery = False
            Dim totalLitros As Double = DV.GDbl("DEPOSITO")
            trbLitrosSale.TotalLitros = totalLitros
            trbLitrosLlega.TotalLitros = totalLitros
            If Estado <> EstadoForm.Cargando And Estado <> EstadoForm.Bloqueado Then
                Dim str As String = DV.Datos.Tables(0).Rows(0).Item("GRUPO").ToString
                Me.dtfGrupo.Text_Data = str
                If setCombus Then trbLitrosSale.LitrosAct = DV.GDbl("LITROS")
                dtfKilometros.Text_Data = DV.GDbl("KM")
            End If
        End If
    End Sub

    'Private Sub dtfVehiculo_TextChanged() Handles dtfVehiculo.TextChanged
    '    If Estado <> EstadoForm.Cargando And Estado <> EstadoForm.Guardando Then
    '        Me.dtfVehiculo_Ctr.Text_Data = dtfVehiculo.Text_Data
    '        dtsEdit.Tables(dtfVehiculo_Ctr.DataTable).Rows(0).Item(dtfVehiculo_Ctr.DataField) = dtfVehiculo.Text_Data
    '        dtfVehiculo_Ctr.EndEdit()
    '    End If
    '    loadVehi(True)
    'End Sub
#End Region

#Region "Save Extra"

    Protected Overrides Function getExtraChanges() As Boolean
        If Not IsNothing(dgvBasesCon.DataSource) Then
            If dgvBasesCon.DataSource.Dataset.HasChanges() Then
                Return True
            End If
        End If
        If dgvLiCon.DataSource.Dataset.HasChanges() Then
            Return True
        End If
        Return False
    End Function

    Protected Overrides Sub SaveBefore(AddReg As Boolean)
        If AddReg Then
            CodigoEdicion = ConfiguracionApp.dameCodigoAgregar(db, ConfiguracionApp.tipoCodigo.contratos, CE.GStr("EMPRESA"), CO.GStr("OFICINA"))

            dgvLiCon.idRel = CodigoEdicion
            dgvLiCon.setIdRel()

            dgvBasesCon.idRel = CodigoEdicion
            dgvBasesCon.setIdRel()

            For Each table In Me.tablasEdit
                For Each pk As PrimaryKey In table.CamposID
                    If pk.CampoGrid = "NUMERO" Then
                        pk.CodEdit = CodigoEdicion
                    End If
                Next
            Next

            tablasEdit.Where(Function(o) o.TableAlias = "VC").First.CamposID.Where(Function(r) r.CampoID = "CODIINT_VC").First.CodEdit = dtfVehiculo_Ctr.Text_Data

            dtfReserva.ReadOnly_Data = True
        End If
    End Sub

    Protected Overrides Sub SaveExtra(newReg As Boolean)
        dgvLiCon.EndEdit()
        dgvLiCon.guardar()
        If (CE.GBool("TIPOPORCONCEPTO")) Then
            dgvBasesCon.EndEdit()
            dgvBasesCon.guardar()
        End If
    End Sub

#End Region

#Region "Calculo Dias"
    Private noRecalculoDias As Boolean = False

    Private Sub dtdFSalida_ValueChanging(oldValue As Date, newValue As Date) Handles dtdFSalida.ValueChanging
        If Recalc() Then
            Try
                Dim difDias As Integer
                noRecalculoDias = True
                difDias = DateDiff(DateInterval.Day, CDate(oldValue), CDate(newValue))
                dtdFPrevista.Value_Data = CDate(dtdFPrevista.Value_Data).AddDays(difDias)
                dtdFPrevista.Min_Value = newValue
                dtdFPrevista.MinDate = newValue

                dtdFRetorno.Min_Value = newValue
                dtdFRetorno.MinDate = newValue
                If dtfDiasRetorno.Text_Data <> "" Then
                    calculateDias(dtdFRetorno, dttHRetorno, dtfDiasRetorno, radConRecalc.IsChecked)
                End If
            Catch
            End Try
            noRecalculoDias = False
        End If
    End Sub

#Region "Calculo Numero Dias Fecha Prevista"

    Private Sub dtdFPrevista_ValueChanged() Handles dtdFPrevista.ValueChanged
        calcDiasPrevistos()
    End Sub

    Private Sub dttHPrevista_Validating() Handles dttHSalida.Validating, dttHPrevista.Validating
        calcDiasPrevistos()
    End Sub

    Private Sub calcDiasPrevistos()
        If Recalc() Then
            calculateDias(dtdFPrevista, dttHPrevista, dtfDiasPrevistos, IIf(dtfDiasRetorno.Text_Data = "", True, False))
        End If
    End Sub

    Private Sub dtfDiasPrevistos_TextChanged() Handles dtfDiasPrevistos.TextChanged
        If Recalc() And Not noRecalculoDias Then
            Dim difDias As Integer
            Dim difHoras As Integer
            Dim difMinutos As Integer
            difDias = CInt(dtfDiasPrevistos.Text_Data)
            difHoras = CType(dttHPrevista.Time, TimeSpan).Hours - CType(dttHSalida.Time, TimeSpan).Hours
            difMinutos = CType(dttHPrevista.Time, TimeSpan).Minutes - CType(dttHSalida.Time, TimeSpan).Minutes

            If difHoras > CE.GInt("HORAS") Or (difHoras = CE.GInt("HORAS") And difMinutos > 0) Then
                'Si la diferencia de horas es superior a las horas de gracia añade un dia
                difDias -= 1
            End If
            noRecalculoDias = True
            dtdFPrevista.Value_Data = CDate(dtdFSalida.Value_Data).AddDays(difDias)
            Cotiza(True)
            noRecalculoDias = False
        End If
    End Sub

#End Region ' FUNCIONA CORRECTAMENTE

#Region "Calculo Dias Fecha Retorno"

    Private Sub dtdFRetorno_ValueChanged() Handles dtdFRetorno.ValueChanged
        calcDiasRetorno()
    End Sub

    Private Sub dttHretorno_Validating() Handles dttHSalida.Validating, dttHRetorno.Validating
        calcDiasRetorno()
    End Sub

    Private Sub calcDiasRetorno()
        calculateDias(dtdFRetorno, dttHRetorno, dtfDiasRetorno, radConRecalc.IsChecked)
    End Sub

#End Region ' FUNCIONA CORRECTAMENTE

    Private Sub calculateDias(ByRef dtdReto As CustomControls.DataDate, ByRef dttReto As CustomControls.DataTime, ByRef dtfDias As CustomControls.Datafield, Optional ByVal cotizar As Boolean = True)
        If Me.Estado <> EstadoForm.Cargando And Me.Estado <> EstadoForm.Abriendo And Not noRecalculoDias Then
            If IsNothing(dtdReto.Value_Data) Or IsNothing(dttReto.Time) Then Exit Sub
            Dim difDias As Integer
            Dim difHoras As Integer
            Dim difMinutos As Integer
            difDias = DateDiff(DateInterval.Day, CDate(dtdFSalida.Value_Data), CDate(dtdReto.Value_Data))
            difHoras = CType(dttReto.Time, TimeSpan).Hours - CType(dttHSalida.Time, TimeSpan).Hours
            difMinutos = CType(dttReto.Time, TimeSpan).Minutes - CType(dttHSalida.Time, TimeSpan).Minutes

            If difHoras > CE.GInt("HORAS") Or (difHoras = CE.GInt("HORAS") And difMinutos > 0) Then
                'Si la diferencia de horas es superior a las horas de gracia añade un dia
                difDias += 1
            End If
            noRecalculoDias = True
            Dim dtfDiasText As Integer
            Try
                dtfDiasText = dtfDias.Text_Data
            Catch
                dtfDiasText = 0
            End Try

            dtfDias.Text_Data = difDias
            If cotizar Then
                dgvLiCon.setDias(difDias)
                Cotiza(True)
            End If

            noRecalculoDias = False
        End If
    End Sub

#End Region ' FUNCIONA CORRECTAMENTE

#Region "Calculo Totales"

    Private Sub dgvbasescon_IvaChanged(oldIva As Double, newIva As Double) Handles dgvBasesCon.IvaChanged

        Dim updateRows = From rows In CType(dgvLiCon.DataSource, DataTable).Rows
                     Where rows.Item("Iva") = oldIva
                     Select rows

        For Each row In updateRows
            row.Item("Iva") = newIva
        Next
    End Sub

    Private Sub TotalesChanged() Handles dgvLiCon.TotalesChanged, dgvBasesCon.TotalesChanged, dtfDto.TextChanged
        If Me.Estado <> EstadoForm.Cargando And Me.Estado <> EstadoForm.Cancelando And Me.Estado <> EstadoForm.Guardando Then
            recalcularTotales()
        End If
    End Sub

    Private Sub recalcularTotales()
        Dim totales As DataTable

        If (CE.GBool("TIPOPORCONCEPTO")) Then
            dtfBrutoCon.Text_Data = dgvLiCon.Bruto

            totales = operLineas.calculaTotales(CodigoEdicion, dgvBasesCon.DataSource, dgvLiCon.Bases, dtfBrutoCon.Text_Data, _
                                                0, IIf(dtfDto.Text_Data = "", 0, dtfDto.Text_Data))

        Else

            dtfBasei.Text_Data = dgvLiCon.Base
            If CE.GBool("TIPOPORGRUPO_VEHI") Then
                dtfIVA.Text_Data = VD.getDouble(db.executeQuery("SELECT IVA_GR FROM GRUPOS WHERE CODIGO = '" & dtfGrupo.Text_Data & "'"))
            Else
                dtfIVA.Text_Data = CE.GDbl("IVA")
            End If
            dtfCuota.Text_Data = VD.getDouble(dtfBasei.Text_Data * dtfIVA.Text_Data / 100)
            dtfTotalCon.Text_Data = VD.getDouble(dtfBasei.Text_Data) + VD.getDouble(dtfCuota.Text_Data)
        End If
    End Sub

#End Region ' FUNCIONA CORRECTAMENTE

#Region "DualDTF extra queries"

    Private Sub dtfCliente_QueryThrown(dts As DataSet) Handles dtfCliente.QueryThrown
        Try
            dtfDelegacion.MensajeIncorrectoCustom = "Esta delegacion no pertenece a este cliente."
            dtfDelegacion.Desc_Where = "CLDIDCLIENTE = '" & dtfCliente.Text_Data & "'"
            dtfDelegacion.forceQuery()
        Catch ex As Exception
            dtfDelegacion.Desc_Where = "1 = 0"
            dtfDelegacion.MensajeIncorrectoCustom = "Primero debe asignar un cliente."
        End Try
    End Sub

    Private Sub dtfTarifa_QueryThrown(dts As DataSet) Handles dtfTarifa.QueryThrown
        If Estado <> EstadoForm.Cargando And Estado <> EstadoForm.Bloqueado Then
            If Not IsNothing(dts) Then
                dgvLiCon.Tarifa = dtfTarifa.Text_Data
                Cotiza(False)
            Else
                dgvLiCon.Tarifa = ""
            End If
        End If
    End Sub

    Private Sub dtfGrupo_QueryThrown(dts As DataSet) Handles dtfGrupo.QueryThrown
        If Estado <> EstadoForm.Cargando And Estado <> EstadoForm.Bloqueado Then
            If Not IsNothing(dts) Then
                dgvLiCon.Grupo = dtfGrupo.Text_Data
                Cotiza(True)
            Else
                dgvLiCon.Grupo = ""
            End If
        End If
    End Sub

    Private Sub dtfMatricula_QueryThrown(dts As DataSet) Handles dtfMatricula.QueryThrown
        If Not IsNothing(dts) Then
            If dts.Tables(0).Rows.Count > 0 Then
                dtfVehiculo.Text_Data = dtfMatricula.Text_Data_Desc
            End If
        End If
    End Sub

    Private Sub dtfVehiculo_QueryThrown(dts As DataSet) Handles dtfVehiculo.QueryThrown
        If Not IsNothing(dts) Then
            If Estado <> EstadoForm.Cargando And Estado <> EstadoForm.Guardando Then
                Me.dtfVehiculo_Ctr.Text_Data = dtfVehiculo.Text_Data
                dtsEdit.Tables(dtfVehiculo_Ctr.DataTable).Rows(0).Item(dtfVehiculo_Ctr.DataField) = dtfVehiculo.Text_Data
                dtfVehiculo_Ctr.EndEdit()
            End If
            loadVehi(True)
        End If
    End Sub

    Private Sub dtfReserva_QueryThrown(dts As DataSet) Handles dtfReserva.QueryThrown
        If Estado <> EstadoForm.Cargando And Estado <> EstadoForm.Bloqueado Then
            If Estado <> EstadoForm.Agregar Then Exit Sub
            If Not IsNothing(dts) Then
                If dts.Tables(0).Rows.Count > 0 Then
                    dtfReserva.Query_on_Text_Changed = False
                    Dim estadoAnt As EstadoForm
                    estadoAnt = Me.Estado
                    Me.Estado = EstadoForm.Cargando
                    Dim gen As New ContratosGen
                    gen.CodigoOrigen = dtfReserva.Text_Data

                    'gen.TablasDestino = Me.tablasEdit

                    Me.limpiar()
                    gen.DatasetDestino = Me.dtsEdit
                    gen.MatchDatasets()
                    dtdFPrevista.Min_Value = Nothing
                    dtdFPrevista.MinDate = Nothing
                    reBind()
                    dtdFPrevista.Min_Value = dtdFSalida.Value_Data
                    dtdFPrevista.MinDate = dtdFSalida.Value_Data
                    loadVehi()
                    trbLitrosSale.LitrosAct = VD.getDouble(dtfLitrosSalida.Text_Data)
                    dtfReserva.Text_Data = gen.CodigoOrigen
                    dtfReserva.ReQuery = False
                    dtfGrupo.ReQuery = False
                    dtfTarifa.ReQuery = False
                    dgvLiCon.Tarifa = dtfTarifa.Text_Data
                    dgvLiCon.Grupo = dtfGrupo.Text_Data
                    gen.LoadLicon(dgvLiCon, dtfGrupo.Text_Data, dtfVehiculo_Ctr.Text_Data)
                    Me.Estado = estadoAnt
                    dtfReserva.Query_on_Text_Changed = True
                    dgvLiCon.recalcularTotal()
                    recalcularTotales()
                End If
            End If
        End If
    End Sub

#End Region

#Region "Cotizacion"

    Private Sub btnLoadTari_Click(sender As Object, e As EventArgs) Handles btnLoadTari.Click
        Cotiza(False)
    End Sub

    Private Sub btnRecalcularGeneral_Click(sender As Object, e As EventArgs) Handles btnRecalcularGeneral.Click
        calculateDias(dtdFPrevista, dttHPrevista, dtfDiasPrevistos)
    End Sub

    Private Sub btnRecalcularCierre_Click(sender As Object, e As EventArgs) Handles btnRecalcularCierre.Click
        calculateDias(dtdFRetorno, dttHRetorno, dtfDiasRetorno)
    End Sub

    Private Sub Cotiza(ByVal merge As Boolean)

        Dim antes As DateTime
        Dim despues As DateTime
        Dim diff As Long

        If Not Recalc() Then Exit Sub

        Cursor = Windows.Forms.Cursors.WaitCursor
        Dim DT As New DataSet
        Dim TR As New Karve.Logic.Cotiza(db)
        Dim DR As DataRow
        Dim DRG As DataRow
        With TR
            .Grupo = Me.dtfGrupo.Text_Data
            .Tarifa = Me.dtfTarifa.Text_Data
            .DiasPrev = Me.dtfDiasPrevistos.Text_Data
            .DiasCierre = IIf(Me.dtfDiasRetorno.Text_Data <> "", Me.dtfDiasRetorno.Text_Data, .DiasPrev)
            'DT = .getCotiza
            DT = .getCotizaContrato(CodigoEdicion, 21)
            Me.dgvLiCon.EnforceConstrains = False

            With CType(Me.dgvLiCon.DataSource, DataTable)
                'si cotizamos por un cambio de tarifa no mergeamos, borramos todo lo que hay
                If Not merge Then
                    For i = .Rows.Count - 1 To 0 Step -1
                        If .Rows(i).RowState <> DataRowState.Deleted Then
                            .Rows(i).Delete()
                        End If
                    Next
                    'si cotizamos por un cambio de numero de dias solo eliminamos los extras que hay en la tarifa y los recalculamos
                Else
                    Dim rowsABorrar = From delRows As DataRow In (From existingRows As DataRow In .Rows
                                                                  Where existingRows.RowState <> DataRowState.Deleted
                                                                  Select existingRows)
                                      Where (From concepABorrar As DataRow In DT.Tables(0).Rows
                                             Select CInt(concepABorrar.Item("CONCEPTO"))).Contains(delRows.Item("CONCEPTO"))
                                      Select delRows

                    For i = rowsABorrar.Count - 1 To 0 Step -1
                        If rowsABorrar(i).RowState <> DataRowState.Deleted Then
                            rowsABorrar(i).Delete()
                        End If
                    Next

                End If

                antes = Now

                For Each DR In DT.Tables(0).Rows
                    'dgvLiCon.Grupo = DR.Item("GRUPO")
                    'dgvLiCon.Tarifa = DR.Item("TARIFA")
                    DRG = .NewRow()
                    DRG.Item("NUMERO") = CodigoEdicion
                    DRG.Item("GRUPO") = DR.Item("GRUPO")
                    DRG.Item("TARIFA") = DR.Item("TARIFA")
                    DRG.Item("CONCEPTO") = DR.Item("CONCEPTO")
                    DRG.Item("DESCCON") = DR.Item("DESCCON")
                    DRG.Item("INCLUIDO") = DR.Item("INCLUIDO")
                    DRG.Item("UNIDAD") = DR.Item("UNIDAD")
                    DRG.Item("CANTIDAD") = DR.Item("CANTIDAD")
                    DRG.Item("PRECIO") = DR.Item("PRECIO")
                    DRG.Item("DTO") = DR.Item("DTO")
                    DRG.Item("IVA") = DR.Item("IVA")
                    DRG.Item("SUBTOTAL") = DR.Item("SUBTOTAL")
                    .Rows.Add(DRG)

                    '.ImportRow(DR)
                Next
            End With

        End With

        despues = Now
        diff = DateDiff(DateInterval.Second, antes, despues)

        dgvLiCon.recalcularTotal()
        recalcularTotales()

        Dim res As String = db.selectSpResults("fnKILOMETROS", {dtfTarifa.Text_Data, dtfGrupo.Text_Data, dtfDiasPrevistos.Text_Data, dtdFSalida.ToString, dtdFPrevista.ToString}).Tables(0).Rows(0).Item(0)
        Dim kminc As Double = Replace(res.Split("@")(0), ".", ",")
        dtfKmIncluidos.Text_Data = kminc

        Cursor = Windows.Forms.Cursors.Default
    End Sub

#End Region

#Region "Calculo Litros"
#Region "Litros Salida"
    Private cambiarSalida As Boolean = True

    Private Sub trbListrosSale_BarValueChanged() Handles trbLitrosSale.BarValueChanged
        If cambiarSalida And Recalc() Then
            cambiarSalida = False
            mdfOctavosSalida.Text_Data = trbLitrosSale.Octavos & "/8"
            dtfLitrosSalida.Text_Data = trbLitrosSale.LitrosAct
            cambiarSalida = True
        End If
    End Sub

    Private Sub dtfOctavosSalida_TextChanged() Handles mdfOctavosSalida.TextChanged
        If cambiarSalida And Recalc() Then
            cambiarSalida = False
            trbLitrosSale.Octavos = VD.getInt(mdfOctavosSalida.Text_Data.Substring(0, 1))
            cambiarSalida = True
        End If
    End Sub

    Private Sub dtfLitrosSalida_TextChanged() Handles dtfLitrosSalida.TextChanged
        If cambiarSalida And Recalc() Then
            cambiarSalida = False
            trbLitrosSale.LitrosAct = VD.getDouble(dtfLitrosSalida.Text_Data)
            cambiarSalida = True
        End If
    End Sub

    Private Sub trbListrosSale_LitrosValueChanged() Handles trbLitrosSale.LitrosValueChanged
        dtfLitrosSalida.Text_Data = trbLitrosSale.LitrosAct
    End Sub

    Private Sub trbListrosSale_OctavosValueChanged() Handles trbLitrosSale.OctavosValueChanged
        mdfOctavosSalida.Text_Data = trbLitrosSale.Octavos & "/8"
    End Sub

    Private Sub setLitrosSalidaCierre()

    End Sub

#End Region ' FUNCIONA CORRECTAMENTE

#Region "Litros Llegada"
    Private cambiarLlegada As Boolean = True

    Private Sub trbLitrosLlega_BarValueChanged() Handles trbLitrosLlega.BarValueChanged
        If cambiarLlegada And Recalc() Then
            cambiarLlegada = False
            mdfOctavosLlegadaCierre.Text_Data = trbLitrosLlega.Octavos & "/8"
            dtfCombusLlegadaCierre.Text_Data = trbLitrosLlega.LitrosAct
            cambiarLlegada = True
        End If
    End Sub

    Private Sub mdfOctavosLlegadaCierre_TextChanged() Handles mdfOctavosLlegadaCierre.TextChanged
        If cambiarLlegada And Estado <> Recalc() Then
            cambiarLlegada = False
            trbLitrosLlega.Octavos = VD.getInt(mdfOctavosLlegadaCierre.Text_Data.Substring(0, 1))
            cambiarLlegada = True
        End If
    End Sub

    Private Sub dtfCombusLlegadaCierre_TextChanged() Handles dtfCombusLlegadaCierre.TextChanged
        If cambiarLlegada And Recalc() Then
            cambiarLlegada = False
            trbLitrosLlega.LitrosAct = VD.getDouble(dtfCombusLlegadaCierre.Text_Data)
            cambiarLlegada = True
        End If
        calculoCombusKmsRetorno(True)
    End Sub

    Private Sub trbLitrosLlega_LitrosValueChanged() Handles trbLitrosLlega.LitrosValueChanged
        dtfCombusLlegadaCierre.Text_Data = trbLitrosLlega.LitrosAct
    End Sub

    Private Sub trbLitrosLlega_OctavosValueChanged() Handles trbLitrosLlega.OctavosValueChanged
        mdfOctavosLlegadaCierre.Text_Data = trbLitrosLlega.Octavos & "/8"
    End Sub
#End Region ' FUNCIONA CORRECTAMENTE
#End Region ' FUNCIONA CORRECTAMENTE

#Region "Calculo datos llegada"
    Private Sub dtfKmLlegadaCierre_TextChanged() Handles dtfKmLlegadaCierre.TextChanged
        calculoCombusKmsRetorno(False)
    End Sub

    Private Sub calculoCombusKmsRetorno(ByVal esCombus As Boolean)
        If esCombus Then
            Try
                If dtfCombusSalidaCierre.Text_Data = "" Or dtfCombusLlegadaCierre.Text_Data = "" Then
                    dtfDiferenciaCombus.Text_Data = 0
                    dtfCargosCombus.Text_Data = 0
                    Exit Sub
                End If

                dtfDiferenciaCombus.Text_Data = dtfCombusSalidaCierre.Text_Data - dtfCombusLlegadaCierre.Text_Data
                If dtfDiferenciaCombus.Text_Data > 0 Then
                    Dim precioTotal As Double
                    Dim precioCombus As Double
                    If DV.GInt("TIPOGAS") = 0 Then
                        precioCombus = CO.GDbl("GASOLINA")
                        precioTotal = dtfDiferenciaCombus.Text_Data * precioCombus
                    Else
                        precioCombus = CO.GDbl("DIESEL")
                        precioTotal = dtfDiferenciaCombus.Text_Data * precioCombus
                    End If
                    dtfCargosCombus.Text_Data = precioTotal
                Else
                    dtfCargosCombus.Text_Data = 0
                End If
            Catch
                dtfDiferenciaCombus.Text_Data = 0
                dtfCargosCombus.Text_Data = 0
            End Try
        Else
            Try
                If dtfKmLlegadaCierre.Text_Data = "" Or dtfKmSalidaCierre.Text_Data = "" Then
                    dtfDiferenciaKilometros.Text_Data = 0
                    dtfCargosKilometros.Text_Data = 0
                    Exit Sub
                End If

                dtfDiferenciaKilometros.Text_Data = CDbl(dtfKmLlegadaCierre.Text_Data) - CDbl(dtfKmSalidaCierre.Text_Data)
                Dim kmIncluidos As Double = CDbl(IIf(dtfKmIncluidos.Text_Data <> "", dtfKmIncluidos.Text_Data, 0))
                Dim kmCargo As Double = CDbl(dtfDiferenciaKilometros.Text_Data) - kmIncluidos

                If kmCargo > 0 Then
                    Dim res As String = db.selectSpResults("fnKILOMETROS", {dtfTarifa.Text_Data, dtfGrupo.Text_Data, dtfDiasPrevistos.Text_Data, dtdFSalida.ToString, dtdFPrevista.ToString}).Tables(0).Rows(0).Item(0)
                    Dim precio As Double = Replace(res.Split("@")(1), ".", ",")
                    dtfCargosKilometros.Text_Data = kmCargo * precio
                Else
                    dtfCargosKilometros.Text_Data = 0
                End If
            Catch
                dtfDiferenciaKilometros.Text_Data = 0
                dtfCargosKilometros.Text_Data = 0
            End Try
        End If
    End Sub
#End Region

    Private Sub dtfCliente_Texto_Changed(Sender As Object) Handles dtfCliente.Texto_Changed
        Me.NombreRegistro = dtfCliente.Text_Data_Desc
    End Sub

    Private Sub btnExpand_Click(sender As Object, e As EventArgs) Handles btnExpand.Click
        If Me.btnExpand.Text = "+" Then
            pnlGenIzq.Visible = False
            pnlCierreIzq.Visible = False
            Me.btnExpand.Text = "-"
        Else
            pnlGenIzq.Visible = True
            pnlCierreIzq.Visible = True
            Me.btnExpand.Text = "+"
        End If
    End Sub ' funciona

#Region "Cierre"

    Private Sub Cierre_Enter(sender As Object, e As EventArgs) Handles dtdFRetorno.Enter
        If Recalc() And Me.Estado <> EstadoForm.Agregar Then
            Dim selectedTab As RibbonTab = Nothing
            For Each cmdTab As RibbonTab In ribbon.CommandTabs
                Try
                    If cmdTab.Name = "rbtContrato" Then cmdTab.IsSelected = True
                Catch
                End Try
            Next
        End If
    End Sub

    Private Sub ribbon_VerCierre() Handles ribbon.VerCierre

    End Sub

    Private Sub ribbon_Cerrar() Handles ribbon.Cerrar
        If checkDatosCierre() Then
            setDatosCierre()
            addCombusKmsCotiza()
            Save_Reg()
        End If
    End Sub

    Private Sub ribbon_Prolongar() Handles ribbon.Prolongar

    End Sub

    Private Sub ribbon_Reabrir() Handles ribbon.Reabrir

    End Sub

    Private Sub cargarDatosCierre()

        If Not IsDBNull(dtsEdit.Tables("C1").Rows(0).Item("FRETOR_CON1")) Then
            dtdFRetorno.Value_Data = dtsEdit.Tables("C1").Rows(0).Item("FRETOR_CON1")
            dttHRetorno.Time = dtsEdit.Tables("C1").Rows(0).Item("HRETOR_CON1")
            dtfKmLlegadaCierre.Text_Data = dtsEdit.Tables("VC").Rows(0).Item("KM_LL")
            dtfCombusLlegadaCierre.Text_Data = dtsEdit.Tables("VC").Rows(0).Item("LITROS_LLEGA")
            mdfOctavosLlegadaCierre.Text_Data = dtsEdit.Tables("VC").Rows(0).Item("GASLLEGA")
        End If

        If Not IsDBNull(dtsEdit.Tables("C1").Rows(0).Item("ULTFRANUM_CON1")) Then
            'ULTFRA_CON1 --fecha ultfra
            'ULTFECFRA_CON1 --fecha hasta ultfra
        End If
    End Sub ' funciona

    Private Function checkDatosCierre() As Boolean
        checkDatosCierre = True
        Dim msgError As String = ""

        'CONTROL FECHAS DE RETORNO
        If IsNothing(dtdFRetorno.Value_Data) Or IsNothing(dttHRetorno.Time) Then
            checkDatosCierre = False

            msgError &= "Debe rellenar la fecha y la hora de retorno." & vbCrLf

            dtdFRetorno.MensajeIncorrectoCustom = "Debe rellenar la fecha y la hora de retorno."
            dttHRetorno.MensajeIncorrectoCustom = "Debe rellenar la fecha y la hora de retorno."
            dtdFRetorno.forceSetError()
            dttHRetorno.forceSetError()
        End If

        'SI ES NECESARIO CONTROL KMS RETORNO
        If Not CE.GBool("NOKMS") Then
            If dtfKmLlegadaCierre.Text_Data = "" Then
                checkDatosCierre = False
                msgError &= "Debe indicar los kilómetros de llegada." & vbCrLf
                dtfKmLlegadaCierre.forceSetError()
                dtfKmLlegadaCierre.MensajeIncorrectoCustom = "Debe indicar los kilómetros de llegada."
            ElseIf dtfKmLlegadaCierre.Text_Data < dtfKmSalidaCierre.Text_Data Then
                checkDatosCierre = False
                msgError &= "Los kilómetros de llegada no pueden ser inferiores a los de salida." & vbCrLf
                dtfKmLlegadaCierre.MensajeIncorrectoCustom = "Los kilómetros de llegada no pueden ser inferiores a los de salida."
                dtfKmLlegadaCierre.forceSetError()
            End If
        End If

        'SE ES NECESARIO CONTROL COMBUSTIBLE
        If CK.GBool("GEST_DECCOMBUS") Then
            If mdfOctavosSalicaCierre.Text_Data = "_/8" Then
                checkDatosCierre = False
                msgError &= "Debe asignar el combustible de de salida." & vbCrLf
                mdfOctavosSalicaCierre.MensajeIncorrectoCustom = "Debe asignar el combustible de de salida."
                mdfOctavosSalicaCierre.forceSetError()
            End If
            If mdfOctavosLlegadaCierre.Text_Data = "_/8" Then
                checkDatosCierre = False
                msgError &= "Debe asignar el combustible de de llegada." & vbCrLf
                mdfOctavosLlegadaCierre.MensajeIncorrectoCustom = "Debe asignar el combustible de de llegada."
                mdfOctavosLlegadaCierre.forceSetError()
            End If
        End If

        If Not checkDatosCierre Then
            kMsgBox.Print("Debe solucionar los siguientes problemas antes de cerrar el contrato.", CustomControls.kMsgBox.kMsgBoxStyle.Information, _
                          msgError, "Karve - Contrato nº: " & dtfCodigo.Text_Data)
        End If
    End Function ' solo esta implementado el control de kms y combus

    Private Sub setDatosCierre()
        dtsEdit.Tables("C1").Rows(0).Item("FRETOR_CON1") = dtdFRetorno.Value_Data
        dtsEdit.Tables("C1").Rows(0).Item("HRETOR_CON1") = dttHRetorno.Time
        dtsEdit.Tables("VC").Rows(0).Item("KM_LL") = dtfKmLlegadaCierre.Text_Data
        dtsEdit.Tables("VC").Rows(0).Item("LITROS_LLEGA") = dtfCombusLlegadaCierre.Text_Data
        dtsEdit.Tables("VC").Rows(0).Item("GASLLEGA") = mdfOctavosLlegadaCierre.Text_Data
        addCombusKmsCotiza()
    End Sub ' funciona

    Private Sub addCombusKmsCotiza()
        Dim recalcular As Boolean = False

        If Not CE.GBool("NOKMS") Then
            If dtfDiferenciaKilometros.Text_Data <> "" And dtfCargosKilometros.Text_Data <> "" Then
                If dtfCargosKilometros.Text_Data > 0 Then
                    Dim kmFactur As Double = dtfDiferenciaKilometros.Text_Data - IIf(dtfKmIncluidos.Text_Data <> "", dtfKmIncluidos.Text_Data, 0)
                    dgvLiCon.addLinea(3, True, "UNICO", kmFactur, (dtfCargosKilometros.Text_Data / kmFactur), 0, 21, True)
                Else
                    dgvLiCon.deleteLinea(3)
                End If
                recalcular = True
            End If
        End If

        If CK.GBool("GEST_DECCOMBUS") Then
            If dtfDiferenciaCombus.Text_Data <> "" And dtfCargosCombus.Text_Data <> "" Then
                If dtfCargosCombus.Text_Data > 0 Then
                    dgvLiCon.addLinea(14, True, "UNICO", dtfDiferenciaCombus.Text_Data, (dtfCargosCombus.Text_Data / dtfDiferenciaCombus.Text_Data), 0, 21, True)
                Else
                    dgvLiCon.deleteLinea(14)
                End If
                recalcular = True
            End If
        End If

        If recalcular Then recalcularTotales()
    End Sub ' funciona
#End Region

#Region "Facturacion"
    Private Sub ribbon_Cobros() Handles ribbon.Cobros

    End Sub

    Private Sub ribbon_Facturar() Handles ribbon.Facturar

    End Sub

#End Region


    Private Sub Contratos_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        For Each cmdTab As RibbonTab In VGribbonMDI.CommandTabs
            Try
                If cmdTab.Tag = 1 Then cmdTab.IsSelected = True
            Catch
            End Try
        Next
        setEstadoContrato()
    End Sub

    Private Function Recalc() As Boolean
        Recalc = True

        If Estado = EstadoForm.Abriendo Or Estado = EstadoForm.Bloqueado Or Estado = EstadoForm.Cancelando Or Estado = EstadoForm.Cargando Or _
            estadoCtr = Contratos_Module.EstadoCtr.Cerrado Or estadoCtr = Contratos_Module.EstadoCtr.Facturado Or estadoCtr = Contratos_Module.EstadoCtr.Null Or _
            estadoCtr = Contratos_Module.EstadoCtr.Cargando Then
            Recalc = False
        End If
    End Function

End Class
