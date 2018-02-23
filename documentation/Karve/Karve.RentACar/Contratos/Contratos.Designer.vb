<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Contratos
    Inherits Bases.frmBase

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim Connection1 As ASADB.Connection = New ASADB.Connection()
        Dim Connection2 As ASADB.Connection = New ASADB.Connection()
        Dim Connection3 As ASADB.Connection = New ASADB.Connection()
        Dim Connection4 As ASADB.Connection = New ASADB.Connection()
        Dim Connection5 As ASADB.Connection = New ASADB.Connection()
        Dim Connection6 As ASADB.Connection = New ASADB.Connection()
        Dim Connection7 As ASADB.Connection = New ASADB.Connection()
        Dim Connection8 As ASADB.Connection = New ASADB.Connection()
        Dim Connection9 As ASADB.Connection = New ASADB.Connection()
        Dim Connection10 As ASADB.Connection = New ASADB.Connection()
        Dim Connection11 As ASADB.Connection = New ASADB.Connection()
        Dim Connection12 As ASADB.Connection = New ASADB.Connection()
        Dim Connection13 As ASADB.Connection = New ASADB.Connection()
        Dim Connection14 As ASADB.Connection = New ASADB.Connection()
        Dim Connection15 As ASADB.Connection = New ASADB.Connection()
        Dim Connection16 As ASADB.Connection = New ASADB.Connection()
        Dim Connection17 As ASADB.Connection = New ASADB.Connection()
        Dim Connection18 As ASADB.Connection = New ASADB.Connection()
        Dim Connection19 As ASADB.Connection = New ASADB.Connection()
        Dim Connection20 As ASADB.Connection = New ASADB.Connection()
        Dim Connection21 As ASADB.Connection = New ASADB.Connection()
        Dim Connection22 As ASADB.Connection = New ASADB.Connection()
        Dim Connection23 As ASADB.Connection = New ASADB.Connection()
        Dim Connection24 As ASADB.Connection = New ASADB.Connection()
        Dim Connection25 As ASADB.Connection = New ASADB.Connection()
        Dim Connection26 As ASADB.Connection = New ASADB.Connection()
        Dim Connection27 As ASADB.Connection = New ASADB.Connection()
        Dim Connection28 As ASADB.Connection = New ASADB.Connection()
        Me.pvpGeneral = New CustomControls.PageViewPage()
        Me.pnlGenDer = New CustomControls.Panel()
        Me.gbxCotiza = New CustomControls.GroupBox()
        Me.pnlGridLiCon = New CustomControls.Panel()
        Me.dgvLiCon = New Karve.frm.RentACar.GridLiCon()
        Me.pnlGridBasesCon = New CustomControls.Panel()
        Me.dgvBasesCon = New Karve.frm.RentACar.GridBasesCon()
        Me.pnlTotal = New CustomControls.Panel()
        Me.dtfBrutoCon = New CustomControls.DatafieldLabel()
        Me.pnlSpace20 = New CustomControls.Panel()
        Me.dtfDto = New CustomControls.DatafieldLabel()
        Me.pnlSpace21 = New CustomControls.Panel()
        Me.dtfBasei = New CustomControls.DatafieldLabel()
        Me.pnlSpace47 = New CustomControls.Panel()
        Me.dtfIVA = New CustomControls.DatafieldLabel()
        Me.pnlSpace48 = New CustomControls.Panel()
        Me.dtfCuota = New CustomControls.DatafieldLabel()
        Me.pnlSpace46 = New CustomControls.Panel()
        Me.btnExpand = New CustomControls.Button()
        Me.dtfTotalCon = New CustomControls.DatafieldLabel()
        Me.pnlGenIzq = New CustomControls.Panel()
        Me.gbxDatosCotiza = New CustomControls.GroupBox()
        Me.btnRecalcularGeneral = New CustomControls.Button()
        Me.btnLoadTari = New CustomControls.Button()
        Me.dtfComisio = New CustomControls.DualDatafieldLabel()
        Me.dtfTarifa = New CustomControls.DualDatafieldLabel()
        Me.gbxDatosVehi = New CustomControls.GroupBox()
        Me.pnlCombustibleKilometros = New CustomControls.Panel()
        Me.trbLitrosSale = New CustomControls.TrackBar()
        Me.pnlLitrosOctavosSalida = New CustomControls.Panel()
        Me.dtfLitrosSalida = New CustomControls.Datafield()
        Me.mdfOctavosSalida = New CustomControls.MaskedDataField()
        Me.pnlKilometros = New CustomControls.Panel()
        Me.dtfKmIncluidos = New CustomControls.DatafieldLabel()
        Me.dtfKilometros = New CustomControls.DatafieldLabel()
        Me.pnlVehiculo = New CustomControls.Panel()
        Me.dtfVehiculo = New CustomControls.DualDatafieldLabel()
        Me.dtfVehiculo_Ctr = New CustomControls.Datafield()
        Me.pnlVehi = New CustomControls.Panel()
        Me.dtfGrupo = New CustomControls.DualDatafieldLabel()
        Me.pnlSpace17 = New CustomControls.Panel()
        Me.dtfMatricula = New CustomControls.DualDatafieldLabel()
        Me.gbxDatosCli = New CustomControls.GroupBox()
        Me.dtfConductor = New CustomControls.DualDataFieldEditableLabel()
        Me.dtfDelegacion = New CustomControls.DualDatafieldLabel()
        Me.dtfCliente = New CustomControls.DualDataFieldEditableLabel()
        Me.pnlCabeceraGeneral = New CustomControls.Panel()
        Me.pnlCabecera = New CustomControls.Panel()
        Me.pnlDatosPrevistos = New CustomControls.Panel()
        Me.dtfLugarRecogida = New CustomControls.DatafieldLabel()
        Me.pnlSpace16 = New CustomControls.Panel()
        Me.dtfUsuRecoje = New CustomControls.DualDatafieldLabel()
        Me.pnlSpace15 = New CustomControls.Panel()
        Me.dtfOfiLlegada = New CustomControls.DualDatafieldLabel()
        Me.pnlSpace14 = New CustomControls.Panel()
        Me.dttHPrevista = New CustomControls.DataTime()
        Me.pnlSpace13 = New CustomControls.Panel()
        Me.dtdFPrevista = New CustomControls.DataDateLabel()
        Me.pnlSpace12 = New CustomControls.Panel()
        Me.pnlDatosSalida = New CustomControls.Panel()
        Me.dtfLugarEntrega = New CustomControls.DatafieldLabel()
        Me.pnlSpace10 = New CustomControls.Panel()
        Me.dtfUsuEntrega = New CustomControls.DualDatafieldLabel()
        Me.pnlSpace19 = New CustomControls.Panel()
        Me.pnlSpace9 = New CustomControls.Panel()
        Me.dtfOfiSalida = New CustomControls.DualDatafieldLabel()
        Me.pnlSpace8 = New CustomControls.Panel()
        Me.dttHSalida = New CustomControls.DataTime()
        Me.pnlSpace7 = New CustomControls.Panel()
        Me.dtdFSalida = New CustomControls.DataDateLabel()
        Me.pnlSpace6 = New CustomControls.Panel()
        Me.dtfDiasPrevistos = New CustomControls.DatafieldLabel()
        Me.pnlCabezeraSup = New CustomControls.Panel()
        Me.dtfEmpresaOficina = New CustomControls.EmpresaOficina()
        Me.pnlSpace4 = New CustomControls.Panel()
        Me.dtdFecha = New CustomControls.DataDateLabel()
        Me.pnlSpace2 = New CustomControls.Panel()
        Me.dtfReserva = New CustomControls.DualDatafieldLabel()
        Me.pnlSpace1 = New CustomControls.Panel()
        Me.dtfCodigo = New CustomControls.DatafieldLabel()
        Me.pnlSpace5 = New CustomControls.Panel()
        Me.dttHora = New CustomControls.DataTime()
        Me.pvpOtrosDatos = New CustomControls.PageViewPage()
        Me.pnlOtrosDatosDer = New CustomControls.Panel()
        Me.dtfDanos = New CustomControls.DatafieldLabel()
        Me.dtaTrayecto = New CustomControls.DataAreaLabel()
        Me.dtaDescripción = New CustomControls.DataAreaLabel()
        Me.dtaObservaciones = New CustomControls.DataAreaLabel()
        Me.pnlOtrosDatosIzq = New CustomControls.Panel()
        Me.dtfMotivoImproduc = New CustomControls.DualDatafieldLabel()
        Me.dtfUbicacion = New CustomControls.DualDatafieldLabel()
        Me.dtfActiVehi = New CustomControls.DualDatafieldLabel()
        Me.dtfUsoAlquiler = New CustomControls.DualDatafieldLabel()
        Me.dtfTipoImpreso = New CustomControls.DualDatafieldLabel()
        Me.dtfBloqueFactur = New CustomControls.DualDatafieldLabel()
        Me.dtfEmpleado = New CustomControls.DualDatafieldLabel()
        Me.dtfIdioma = New CustomControls.DualDatafieldLabel()
        Me.dtfReferenciaFactura = New CustomControls.DatafieldLabel()
        Me.dtfOrigen = New CustomControls.DualDatafieldLabel()
        Me.dtfFcobro = New CustomControls.DualDatafieldLabel()
        Me.pnlOpcionesAlquiler = New CustomControls.Panel()
        Me.pnlChecksOtrosDatos = New CustomControls.Panel()
        Me.chnNoPrtImp = New CustomControls.DataCheck()
        Me.chkImproductivo = New CustomControls.DataCheck()
        Me.chkExentos = New CustomControls.DataCheck()
        Me.chnNoPendCob = New CustomControls.DataCheck()
        Me.chkVehi2000Kg = New CustomControls.DataCheck()
        Me.chProlongacionAutomatica = New CustomControls.DataCheck()
        Me.pnlSpace22 = New CustomControls.Panel()
        Me.rdgTipoAlquiler = New CustomControls.RadioGroup()
        Me.radCorta = New CustomControls.DataRadio()
        Me.radLarga = New CustomControls.DataRadio()
        Me.pnlCabeceraOtros = New CustomControls.Panel()
        Me.pvpConductores = New CustomControls.PageViewPage()
        Me.pnlConductoresDer = New CustomControls.Panel()
        Me.gbxConductoresAdicionales = New CustomControls.GroupBox()
        Me.gbxOtroCond3 = New CustomControls.GroupBox()
        Me.pnlOtroPermismo3 = New CustomControls.Panel()
        Me.dtdOtroNac3 = New CustomControls.DataDateLabel()
        Me.dtfOtroPer3 = New CustomControls.DatafieldLabel()
        Me.pnlOtroFPermismo3 = New CustomControls.Panel()
        Me.dtdOtroCadu3 = New CustomControls.DataDateLabel()
        Me.dtdOtroExpe3 = New CustomControls.DataDateLabel()
        Me.dtfOtroCond3 = New CustomControls.DualDatafieldLabel()
        Me.gbxOtroCond2 = New CustomControls.GroupBox()
        Me.pnlOtroPermismo2 = New CustomControls.Panel()
        Me.dtdOtroNac2 = New CustomControls.DataDateLabel()
        Me.dtfOtroPer2 = New CustomControls.DatafieldLabel()
        Me.pnlOtroFPermismo2 = New CustomControls.Panel()
        Me.dtdOtroCadu2 = New CustomControls.DataDateLabel()
        Me.dtdOtroExpe2 = New CustomControls.DataDateLabel()
        Me.dtfOtroCond2 = New CustomControls.DualDatafieldLabel()
        Me.gbxOtroCond = New CustomControls.GroupBox()
        Me.pnlOtroPermismo = New CustomControls.Panel()
        Me.dtdOtroNac = New CustomControls.DataDateLabel()
        Me.dtfOtroPer = New CustomControls.DatafieldLabel()
        Me.pnlOtroFPermismo = New CustomControls.Panel()
        Me.dtdOtroCadu = New CustomControls.DataDateLabel()
        Me.dtdOtroExpe = New CustomControls.DataDateLabel()
        Me.dtfOtroCond = New CustomControls.DualDatafieldLabel()
        Me.pnlConductoresIzq = New CustomControls.Panel()
        Me.gbxConductor = New CustomControls.GroupBox()
        Me.pnlTarjeta = New CustomControls.Panel()
        Me.dtfTarNum = New CustomControls.DatafieldLabel()
        Me.pnlSpace31 = New CustomControls.Panel()
        Me.lblTarCadu = New CustomControls.Label()
        Me.pnlSpace30 = New CustomControls.Panel()
        Me.mdfTarcadu = New CustomControls.MaskedDataField()
        Me.dtfTarjetaCond = New CustomControls.DualDatafieldLabel()
        Me.dtfEmailCond = New CustomControls.DatafieldLabel()
        Me.pnlPermiso = New CustomControls.Panel()
        Me.pnlPermisoInf = New CustomControls.Panel()
        Me.dtfLuExpe = New CustomControls.DatafieldLabel()
        Me.pnlSpace29 = New CustomControls.Panel()
        Me.dtdFeExpe = New CustomControls.DataDateLabel()
        Me.pnlPermisoSup = New CustomControls.Panel()
        Me.dtfPermiso = New CustomControls.DatafieldLabel()
        Me.pnlSpace28 = New CustomControls.Panel()
        Me.dtfClase = New CustomControls.DatafieldLabel()
        Me.pnlLuNace = New CustomControls.Panel()
        Me.dtfLuNace = New CustomControls.DatafieldLabel()
        Me.pnlSpace27 = New CustomControls.Panel()
        Me.dtdFechaNac = New CustomControls.DataDateLabel()
        Me.pnlNifTelf = New CustomControls.Panel()
        Me.dtfNIFCond = New CustomControls.DatafieldLabel()
        Me.pnlSpace25 = New CustomControls.Panel()
        Me.dtfTelfCond = New CustomControls.DatafieldLabel()
        Me.pnlSpace24 = New CustomControls.Panel()
        Me.dtfTelfCond2 = New CustomControls.Datafield()
        Me.dtdDirCond = New CustomControls.DataDir()
        Me.dtfNombreCond = New CustomControls.DatafieldLabel()
        Me.pnlConductor = New CustomControls.Panel()
        Me.dtfConductorDetalles = New CustomControls.DualDatafieldLabel()
        Me.pnlSpace23 = New CustomControls.Panel()
        Me.btnCargarCond = New CustomControls.Button()
        Me.pnlSpace26 = New CustomControls.Panel()
        Me.btnGuardar = New CustomControls.Button()
        Me.pnlCabeceraConductores = New CustomControls.Panel()
        Me.pvpCierre = New CustomControls.PageViewPage()
        Me.pnlCierreDer = New CustomControls.Panel()
        Me.pnlCierreIzq = New CustomControls.Panel()
        Me.rdgDevolucion = New CustomControls.RadioGroup()
        Me.pnlKmLitrosCierre = New CustomControls.Panel()
        Me.trbLitrosLlega = New CustomControls.TrackBar()
        Me.pnlCombustibleCierre = New CustomControls.Panel()
        Me.dtfDiferenciaCombus = New CustomControls.Datafield()
        Me.pnlSpace45 = New CustomControls.Panel()
        Me.pnlSpace44 = New CustomControls.Panel()
        Me.mdfOctavosLlegadaCierre = New CustomControls.MaskedDataField()
        Me.pnlSpace43 = New CustomControls.Panel()
        Me.dtfCombusLlegadaCierre = New CustomControls.Datafield()
        Me.pnlSpace42 = New CustomControls.Panel()
        Me.mdfOctavosSalicaCierre = New CustomControls.MaskedDataField()
        Me.pnlSpace41 = New CustomControls.Panel()
        Me.dtfCombusSalidaCierre = New CustomControls.DatafieldLabel()
        Me.dtfCargosCombus = New CustomControls.Datafield()
        Me.pnlKilometrosCierre = New CustomControls.Panel()
        Me.dtfDiferenciaKilometros = New CustomControls.Datafield()
        Me.pnlSpace40 = New CustomControls.Panel()
        Me.pnlSpace39 = New CustomControls.Panel()
        Me.dtfKmLlegadaCierre = New CustomControls.Datafield()
        Me.pnlSpace38 = New CustomControls.Panel()
        Me.dtfKmSalidaCierre = New CustomControls.DatafieldLabel()
        Me.dtfCargosKilometros = New CustomControls.Datafield()
        Me.pnlLabelsCierre = New CustomControls.Panel()
        Me.lblCargos = New CustomControls.Label()
        Me.lblDiferencia = New CustomControls.Label()
        Me.lblLlegada = New CustomControls.Label()
        Me.lblSalida = New CustomControls.Label()
        Me.btnRecalcularCierre = New CustomControls.Button()
        Me.radConRecalc = New CustomControls.DataRadio()
        Me.radSinRecalc = New CustomControls.DataRadio()
        Me.pnlFacturHasta = New CustomControls.Panel()
        Me.btnPasaraLienas = New CustomControls.Button()
        Me.pnlSpace37 = New CustomControls.Panel()
        Me.dttFacturHasta = New CustomControls.DataTime()
        Me.pnlSpace36 = New CustomControls.Panel()
        Me.dtdFacturHasta = New CustomControls.DataDateLabel()
        Me.pnlFacturDesde = New CustomControls.Panel()
        Me.dtfDiasFactur = New CustomControls.DatafieldLabel()
        Me.pnlSpace35 = New CustomControls.Panel()
        Me.dttFacturDesde = New CustomControls.DataTime()
        Me.pnlSpace34 = New CustomControls.Panel()
        Me.dtdFacturDesde = New CustomControls.DataDateLabel()
        Me.pnlDatosRetorno = New CustomControls.Panel()
        Me.dtfDiasRetorno = New CustomControls.DatafieldLabel()
        Me.pnlSpace33 = New CustomControls.Panel()
        Me.dttHRetorno = New CustomControls.DataTime()
        Me.pnlSpace32 = New CustomControls.Panel()
        Me.dtdFRetorno = New CustomControls.DataDateLabel()
        Me.pnlCabeceraCierre = New CustomControls.Panel()
        CType(Me.pnlBlock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pvwBase, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pvwBase.SuspendLayout()
        CType(Me.stbBase, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pvpGeneral.SuspendLayout()
        CType(Me.pnlGenDer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlGenDer.SuspendLayout()
        CType(Me.gbxCotiza, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxCotiza.SuspendLayout()
        CType(Me.pnlGridLiCon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlGridLiCon.SuspendLayout()
        CType(Me.dgvLiCon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvLiCon.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlGridBasesCon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlGridBasesCon.SuspendLayout()
        CType(Me.dgvBasesCon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvBasesCon.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTotal.SuspendLayout()
        CType(Me.pnlSpace20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSpace21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSpace47, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSpace48, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSpace46, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnExpand, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlGenIzq, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlGenIzq.SuspendLayout()
        CType(Me.gbxDatosCotiza, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxDatosCotiza.SuspendLayout()
        CType(Me.btnRecalcularGeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnLoadTari, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbxDatosVehi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxDatosVehi.SuspendLayout()
        CType(Me.pnlCombustibleKilometros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCombustibleKilometros.SuspendLayout()
        CType(Me.pnlLitrosOctavosSalida, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlLitrosOctavosSalida.SuspendLayout()
        CType(Me.pnlKilometros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlKilometros.SuspendLayout()
        CType(Me.pnlVehiculo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlVehiculo.SuspendLayout()
        CType(Me.pnlVehi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlVehi.SuspendLayout()
        CType(Me.pnlSpace17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbxDatosCli, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxDatosCli.SuspendLayout()
        CType(Me.pnlCabeceraGeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCabeceraGeneral.SuspendLayout()
        CType(Me.pnlCabecera, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCabecera.SuspendLayout()
        CType(Me.pnlDatosPrevistos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDatosPrevistos.SuspendLayout()
        CType(Me.pnlSpace16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSpace15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSpace14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSpace13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSpace12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlDatosSalida, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDatosSalida.SuspendLayout()
        CType(Me.pnlSpace10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSpace19, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSpace19.SuspendLayout()
        CType(Me.pnlSpace9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSpace8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSpace7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSpace6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlCabezeraSup, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCabezeraSup.SuspendLayout()
        CType(Me.pnlSpace4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSpace2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSpace1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSpace5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pvpOtrosDatos.SuspendLayout()
        CType(Me.pnlOtrosDatosDer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlOtrosDatosDer.SuspendLayout()
        CType(Me.pnlOtrosDatosIzq, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlOtrosDatosIzq.SuspendLayout()
        CType(Me.pnlOpcionesAlquiler, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlOpcionesAlquiler.SuspendLayout()
        CType(Me.pnlChecksOtrosDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlChecksOtrosDatos.SuspendLayout()
        CType(Me.chnNoPrtImp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkImproductivo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkExentos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chnNoPendCob, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkVehi2000Kg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chProlongacionAutomatica, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSpace22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rdgTipoAlquiler, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rdgTipoAlquiler.SuspendLayout()
        CType(Me.radCorta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.radLarga, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlCabeceraOtros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pvpConductores.SuspendLayout()
        CType(Me.pnlConductoresDer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlConductoresDer.SuspendLayout()
        CType(Me.gbxConductoresAdicionales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxConductoresAdicionales.SuspendLayout()
        CType(Me.gbxOtroCond3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxOtroCond3.SuspendLayout()
        CType(Me.pnlOtroPermismo3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlOtroPermismo3.SuspendLayout()
        CType(Me.pnlOtroFPermismo3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlOtroFPermismo3.SuspendLayout()
        CType(Me.gbxOtroCond2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxOtroCond2.SuspendLayout()
        CType(Me.pnlOtroPermismo2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlOtroPermismo2.SuspendLayout()
        CType(Me.pnlOtroFPermismo2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlOtroFPermismo2.SuspendLayout()
        CType(Me.gbxOtroCond, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxOtroCond.SuspendLayout()
        CType(Me.pnlOtroPermismo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlOtroPermismo.SuspendLayout()
        CType(Me.pnlOtroFPermismo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlOtroFPermismo.SuspendLayout()
        CType(Me.pnlConductoresIzq, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlConductoresIzq.SuspendLayout()
        CType(Me.gbxConductor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxConductor.SuspendLayout()
        CType(Me.pnlTarjeta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTarjeta.SuspendLayout()
        CType(Me.pnlSpace31, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTarCadu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSpace30, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlPermiso, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPermiso.SuspendLayout()
        CType(Me.pnlPermisoInf, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPermisoInf.SuspendLayout()
        CType(Me.pnlSpace29, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlPermisoSup, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPermisoSup.SuspendLayout()
        CType(Me.pnlSpace28, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlLuNace, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlLuNace.SuspendLayout()
        CType(Me.pnlSpace27, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlNifTelf, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlNifTelf.SuspendLayout()
        CType(Me.pnlSpace25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSpace24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlConductor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlConductor.SuspendLayout()
        CType(Me.pnlSpace23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnCargarCond, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSpace26, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnGuardar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlCabeceraConductores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pvpCierre.SuspendLayout()
        CType(Me.pnlCierreDer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlCierreIzq, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCierreIzq.SuspendLayout()
        CType(Me.rdgDevolucion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rdgDevolucion.SuspendLayout()
        CType(Me.pnlKmLitrosCierre, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlKmLitrosCierre.SuspendLayout()
        CType(Me.pnlCombustibleCierre, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCombustibleCierre.SuspendLayout()
        CType(Me.pnlSpace45, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSpace44, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSpace43, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSpace42, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSpace41, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlKilometrosCierre, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlKilometrosCierre.SuspendLayout()
        CType(Me.pnlSpace40, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSpace39, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSpace38, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlLabelsCierre, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlLabelsCierre.SuspendLayout()
        CType(Me.lblCargos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDiferencia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblLlegada, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblSalida, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnRecalcularCierre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.radConRecalc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.radSinRecalc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlFacturHasta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFacturHasta.SuspendLayout()
        CType(Me.btnPasaraLienas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSpace37, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSpace36, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlFacturDesde, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFacturDesde.SuspendLayout()
        CType(Me.pnlSpace35, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSpace34, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlDatosRetorno, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDatosRetorno.SuspendLayout()
        CType(Me.pnlSpace33, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSpace32, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlCabeceraCierre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlBlock
        '
        Me.pnlBlock.Location = New System.Drawing.Point(0, 479)
        '
        'pvwBase
        '
        Me.pvwBase.Controls.Add(Me.pvpGeneral)
        Me.pvwBase.Controls.Add(Me.pvpCierre)
        Me.pvwBase.Controls.Add(Me.pvpOtrosDatos)
        Me.pvwBase.Controls.Add(Me.pvpConductores)
        Me.pvwBase.SelectedPage = Me.pvpConductores
        Me.pvwBase.Size = New System.Drawing.Size(1272, 569)
        '
        'stbBase
        '
        Me.stbBase.Size = New System.Drawing.Size(1272, 25)
        '
        'rbtEdicion
        '
        Me.rbtEdicion.BackColor = System.Drawing.Color.White
        Me.rbtEdicion.BorderColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.rbtEdicion.BorderGradientStyle = Telerik.WinControls.GradientStyles.Solid
        Me.rbtEdicion.Bounds = New System.Drawing.Rectangle(0, 0, 64, 28)
        Me.rbtEdicion.ClipDrawing = True
        Me.rbtEdicion.ClipText = True
        Me.rbtEdicion.DrawBorder = True
        Me.rbtEdicion.DrawFill = True
        Me.rbtEdicion.ForeColor = System.Drawing.Color.Black
        Me.rbtEdicion.GradientStyle = Telerik.WinControls.GradientStyles.Solid
        Me.rbtEdicion.ImageAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.rbtEdicion.ImageLayout = System.Windows.Forms.ImageLayout.None
        Me.rbtEdicion.IsSelected = False
        Me.rbtEdicion.MinSize = New System.Drawing.Size(8, 8)
        Me.rbtEdicion.NumberOfColors = 1
        Me.rbtEdicion.Padding = New System.Windows.Forms.Padding(4)
        Me.rbtEdicion.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.rbtEdicion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.Color.Transparent
        Me.btnAdd.Bounds = New System.Drawing.Rectangle(0, 0, 51, 75)
        Me.btnAdd.CanFocus = True
        Me.btnAdd.ForeColor = System.Drawing.Color.Black
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.Transparent
        Me.btnSave.Bounds = New System.Drawing.Rectangle(0, 0, 52, 75)
        Me.btnSave.CanFocus = True
        Me.btnSave.ForeColor = System.Drawing.Color.Black
        '
        'btnRecargar
        '
        Me.btnRecargar.BackColor = System.Drawing.Color.Transparent
        Me.btnRecargar.Bounds = New System.Drawing.Rectangle(0, 0, 57, 75)
        Me.btnRecargar.CanFocus = True
        Me.btnRecargar.ForeColor = System.Drawing.Color.Black
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.Color.Transparent
        Me.btnDelete.Bounds = New System.Drawing.Rectangle(0, 0, 52, 75)
        Me.btnDelete.CanFocus = True
        Me.btnDelete.ForeColor = System.Drawing.Color.Black
        '
        'rbgEdicion
        '
        Me.rbgEdicion.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.rbgEdicion.Bounds = New System.Drawing.Rectangle(0, 0, 246, 96)
        Me.rbgEdicion.ForeColor = System.Drawing.Color.Black
        '
        'rbgDesplaza
        '
        Me.rbgDesplaza.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.rbgDesplaza.Bounds = New System.Drawing.Rectangle(0, 0, 243, 92)
        Me.rbgDesplaza.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.rbgDesplaza.ForeColor = System.Drawing.Color.Black
        Me.rbgDesplaza.Margin = New System.Windows.Forms.Padding(2)
        Me.rbgDesplaza.MaxSize = New System.Drawing.Size(0, 100)
        Me.rbgDesplaza.MinSize = New System.Drawing.Size(20, 86)
        '
        'btnPrimero
        '
        Me.btnPrimero.BackColor = System.Drawing.Color.Transparent
        Me.btnPrimero.Bounds = New System.Drawing.Rectangle(0, 0, 52, 70)
        Me.btnPrimero.CanFocus = True
        Me.btnPrimero.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.btnPrimero.ForeColor = System.Drawing.Color.Black
        '
        'btnAnterior
        '
        Me.btnAnterior.BackColor = System.Drawing.Color.Transparent
        Me.btnAnterior.Bounds = New System.Drawing.Rectangle(0, 0, 52, 70)
        Me.btnAnterior.CanFocus = True
        Me.btnAnterior.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.btnAnterior.ForeColor = System.Drawing.Color.Black
        '
        'btnSiguiente
        '
        Me.btnSiguiente.BackColor = System.Drawing.Color.Transparent
        Me.btnSiguiente.Bounds = New System.Drawing.Rectangle(0, 0, 53, 70)
        Me.btnSiguiente.CanFocus = True
        Me.btnSiguiente.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.btnSiguiente.ForeColor = System.Drawing.Color.Black
        '
        'btnUltimo
        '
        Me.btnUltimo.BackColor = System.Drawing.Color.Transparent
        Me.btnUltimo.Bounds = New System.Drawing.Rectangle(0, 0, 52, 70)
        Me.btnUltimo.CanFocus = True
        Me.btnUltimo.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.btnUltimo.ForeColor = System.Drawing.Color.Black
        '
        'rbgImpresion
        '
        Me.rbgImpresion.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.rbgImpresion.Bounds = New System.Drawing.Rectangle(0, 0, 120, 92)
        Me.rbgImpresion.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.rbgImpresion.ForeColor = System.Drawing.Color.Black
        Me.rbgImpresion.Margin = New System.Windows.Forms.Padding(2)
        Me.rbgImpresion.MaxSize = New System.Drawing.Size(0, 100)
        Me.rbgImpresion.MinSize = New System.Drawing.Size(20, 86)
        '
        'btnImprimir
        '
        Me.btnImprimir.BackColor = System.Drawing.Color.Transparent
        Me.btnImprimir.Bounds = New System.Drawing.Rectangle(0, 0, 52, 70)
        Me.btnImprimir.CanFocus = True
        Me.btnImprimir.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.btnImprimir.ForeColor = System.Drawing.Color.Black
        '
        'btnMail
        '
        Me.btnMail.BackColor = System.Drawing.Color.Transparent
        Me.btnMail.Bounds = New System.Drawing.Rectangle(0, 0, 52, 70)
        Me.btnMail.CanFocus = True
        Me.btnMail.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.btnMail.ForeColor = System.Drawing.Color.Black
        '
        'pvpGeneral
        '
        Me.pvpGeneral.Controls.Add(Me.pnlGenDer)
        Me.pvpGeneral.Controls.Add(Me.pnlGenIzq)
        Me.pvpGeneral.Controls.Add(Me.pnlCabeceraGeneral)
        Me.pvpGeneral.ItemSize = New System.Drawing.SizeF(83.0!, 23.0!)
        Me.pvpGeneral.Location = New System.Drawing.Point(129, 5)
        Me.pvpGeneral.Name = "pvpGeneral"
        Me.pvpGeneral.PanelCabezeraContainer = Me.pnlCabeceraGeneral
        Me.pvpGeneral.Size = New System.Drawing.Size(1246, 559)
        Me.pvpGeneral.Text = "General"
        '
        'pnlGenDer
        '
        Me.pnlGenDer.Auto_Size = False
        Me.pnlGenDer.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlGenDer.ChangeDock = False
        Me.pnlGenDer.Control_Resize = False
        Me.pnlGenDer.Controls.Add(Me.gbxCotiza)
        Me.pnlGenDer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlGenDer.isSpace = False
        Me.pnlGenDer.Location = New System.Drawing.Point(472, 78)
        Me.pnlGenDer.Name = "pnlGenDer"
        Me.pnlGenDer.numRows = 0
        Me.pnlGenDer.Padding = New System.Windows.Forms.Padding(3)
        Me.pnlGenDer.Reorder = True
        Me.pnlGenDer.Size = New System.Drawing.Size(774, 481)
        Me.pnlGenDer.TabIndex = 1
        '
        'gbxCotiza
        '
        Me.gbxCotiza.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.gbxCotiza.Controls.Add(Me.pnlGridLiCon)
        Me.gbxCotiza.Controls.Add(Me.pnlGridBasesCon)
        Me.gbxCotiza.Controls.Add(Me.pnlTotal)
        Me.gbxCotiza.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbxCotiza.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.gbxCotiza.HeaderText = "Cotización"
        Me.gbxCotiza.Location = New System.Drawing.Point(3, 3)
        Me.gbxCotiza.Name = "gbxCotiza"
        Me.gbxCotiza.numRows = 0
        Me.gbxCotiza.Padding = New System.Windows.Forms.Padding(6, 18, 6, 6)
        Me.gbxCotiza.Reorder = True
        Me.gbxCotiza.Size = New System.Drawing.Size(768, 475)
        Me.gbxCotiza.TabIndex = 0
        Me.gbxCotiza.Text = "Cotización"
        Me.gbxCotiza.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.gbxCotiza.ThemeName = "Windows8"
        Me.gbxCotiza.Title = "Cotización"
        '
        'pnlGridLiCon
        '
        Me.pnlGridLiCon.Auto_Size = False
        Me.pnlGridLiCon.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlGridLiCon.ChangeDock = True
        Me.pnlGridLiCon.Control_Resize = False
        Me.pnlGridLiCon.Controls.Add(Me.dgvLiCon)
        Me.pnlGridLiCon.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlGridLiCon.isSpace = False
        Me.pnlGridLiCon.Location = New System.Drawing.Point(6, 18)
        Me.pnlGridLiCon.Name = "pnlGridLiCon"
        Me.pnlGridLiCon.numRows = 0
        Me.pnlGridLiCon.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.pnlGridLiCon.Reorder = True
        Me.pnlGridLiCon.Size = New System.Drawing.Size(756, 291)
        Me.pnlGridLiCon.TabIndex = 0
        '
        'dgvLiCon
        '
        Me.dgvLiCon.ColRel = Nothing
        Me.dgvLiCon.ColSelectFilter = Nothing
        Me.dgvLiCon.DataGridType = CustomControls.DataGrid.GridType.Edit
        Me.dgvLiCon.DBConnection = Nothing
        Me.dgvLiCon.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvLiCon.EnforceConstrains = True
        Me.dgvLiCon.Grupo = Nothing
        Me.dgvLiCon.idRel = Nothing
        Me.dgvLiCon.Location = New System.Drawing.Point(0, 0)
        Me.dgvLiCon.MarcarFilas = False
        '
        'dgvLiCon
        '
        Me.dgvLiCon.MasterTemplate.AllowAddNewRow = False
        Me.dgvLiCon.MasterTemplate.AllowColumnChooser = False
        Me.dgvLiCon.MasterTemplate.AllowDeleteRow = False
        Me.dgvLiCon.MasterTemplate.EnableFiltering = True
        Me.dgvLiCon.MasterTemplate.EnableGrouping = False
        Me.dgvLiCon.MasterTemplate.MultiSelect = True
        Me.dgvLiCon.MasterTemplate.SelectionMode = Telerik.WinControls.UI.GridViewSelectionMode.CellSelect
        Me.dgvLiCon.Name = "dgvLiCon"
        Me.dgvLiCon.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.dgvLiCon.Size = New System.Drawing.Size(756, 285)
        Me.dgvLiCon.TabIndex = 0
        Me.dgvLiCon.TablaEdit = Nothing
        Me.dgvLiCon.Tarifa = Nothing
        Me.dgvLiCon.Text = "GridLiCon1"
        Me.dgvLiCon.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dgvLiCon.ThemeName = "TelerikMetroBlue"
        '
        'pnlGridBasesCon
        '
        Me.pnlGridBasesCon.Auto_Size = False
        Me.pnlGridBasesCon.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlGridBasesCon.ChangeDock = True
        Me.pnlGridBasesCon.Control_Resize = False
        Me.pnlGridBasesCon.Controls.Add(Me.dgvBasesCon)
        Me.pnlGridBasesCon.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlGridBasesCon.isSpace = False
        Me.pnlGridBasesCon.Location = New System.Drawing.Point(6, 309)
        Me.pnlGridBasesCon.Name = "pnlGridBasesCon"
        Me.pnlGridBasesCon.numRows = 0
        Me.pnlGridBasesCon.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.pnlGridBasesCon.Reorder = True
        Me.pnlGridBasesCon.Size = New System.Drawing.Size(756, 140)
        Me.pnlGridBasesCon.TabIndex = 1
        Me.pnlGridBasesCon.Visible = False
        '
        'dgvBasesCon
        '
        Me.dgvBasesCon.ColRel = Nothing
        Me.dgvBasesCon.ColSelectFilter = Nothing
        Me.dgvBasesCon.DataGridType = CustomControls.DataGrid.GridType.Edit
        Me.dgvBasesCon.DBConnection = Nothing
        Me.dgvBasesCon.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvBasesCon.EnforceConstrains = True
        Me.dgvBasesCon.idRel = Nothing
        Me.dgvBasesCon.Location = New System.Drawing.Point(0, 0)
        Me.dgvBasesCon.MarcarFilas = False
        '
        'dgvBasesCon
        '
        Me.dgvBasesCon.MasterTemplate.AllowColumnChooser = False
        Me.dgvBasesCon.MasterTemplate.EnableFiltering = True
        Me.dgvBasesCon.MasterTemplate.EnableGrouping = False
        Me.dgvBasesCon.MasterTemplate.MultiSelect = True
        Me.dgvBasesCon.MasterTemplate.SelectionMode = Telerik.WinControls.UI.GridViewSelectionMode.CellSelect
        Me.dgvBasesCon.Name = "dgvBasesCon"
        Me.dgvBasesCon.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.dgvBasesCon.Size = New System.Drawing.Size(756, 134)
        Me.dgvBasesCon.TabIndex = 0
        Me.dgvBasesCon.TablaEdit = Nothing
        Me.dgvBasesCon.Text = "GridBasesCon1"
        Me.dgvBasesCon.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dgvBasesCon.ThemeName = "TelerikMetroBlue"
        '
        'pnlTotal
        '
        Me.pnlTotal.Auto_Size = False
        Me.pnlTotal.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlTotal.ChangeDock = True
        Me.pnlTotal.Control_Resize = False
        Me.pnlTotal.Controls.Add(Me.dtfBrutoCon)
        Me.pnlTotal.Controls.Add(Me.pnlSpace20)
        Me.pnlTotal.Controls.Add(Me.dtfDto)
        Me.pnlTotal.Controls.Add(Me.pnlSpace21)
        Me.pnlTotal.Controls.Add(Me.dtfBasei)
        Me.pnlTotal.Controls.Add(Me.pnlSpace47)
        Me.pnlTotal.Controls.Add(Me.dtfIVA)
        Me.pnlTotal.Controls.Add(Me.pnlSpace48)
        Me.pnlTotal.Controls.Add(Me.dtfCuota)
        Me.pnlTotal.Controls.Add(Me.pnlSpace46)
        Me.pnlTotal.Controls.Add(Me.btnExpand)
        Me.pnlTotal.Controls.Add(Me.dtfTotalCon)
        Me.pnlTotal.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlTotal.isSpace = False
        Me.pnlTotal.Location = New System.Drawing.Point(6, 449)
        Me.pnlTotal.Name = "pnlTotal"
        Me.pnlTotal.numRows = 1
        Me.pnlTotal.Reorder = True
        Me.pnlTotal.Size = New System.Drawing.Size(756, 20)
        Me.pnlTotal.TabIndex = 2
        '
        'dtfBrutoCon
        '
        Me.dtfBrutoCon.Allow_Empty = True
        Me.dtfBrutoCon.Allow_Negative = True
        Me.dtfBrutoCon.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfBrutoCon.BackColor = System.Drawing.SystemColors.Control
        Me.dtfBrutoCon.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfBrutoCon.DataField = Nothing
        Me.dtfBrutoCon.DataTable = ""
        Me.dtfBrutoCon.Descripcion = "Bruto"
        Me.dtfBrutoCon.Dock = System.Windows.Forms.DockStyle.Right
        Me.dtfBrutoCon.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfBrutoCon.FocoEnAgregar = False
        Me.dtfBrutoCon.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfBrutoCon.Image = Nothing
        Me.dtfBrutoCon.Label_Space = 50
        Me.dtfBrutoCon.Length_Data = 32767
        Me.dtfBrutoCon.Location = New System.Drawing.Point(17, 0)
        Me.dtfBrutoCon.Max_Value = 0.0R
        Me.dtfBrutoCon.MensajeIncorrectoCustom = Nothing
        Me.dtfBrutoCon.Name = "dtfBrutoCon"
        Me.dtfBrutoCon.Null_on_Empty = True
        Me.dtfBrutoCon.OpenForm = Nothing
        Me.dtfBrutoCon.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfBrutoCon.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfBrutoCon.ReadOnly_Data = False
        Me.dtfBrutoCon.Show_Button = False
        Me.dtfBrutoCon.Size = New System.Drawing.Size(125, 20)
        Me.dtfBrutoCon.TabIndex = 0
        Me.dtfBrutoCon.Text_Data = ""
        Me.dtfBrutoCon.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfBrutoCon.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfBrutoCon.TopPadding = 0
        Me.dtfBrutoCon.Upper_Case = False
        Me.dtfBrutoCon.Validate_on_lost_focus = True
        Me.dtfBrutoCon.Visible = False
        '
        'pnlSpace20
        '
        Me.pnlSpace20.Auto_Size = False
        Me.pnlSpace20.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace20.ChangeDock = True
        Me.pnlSpace20.Control_Resize = False
        Me.pnlSpace20.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSpace20.isSpace = True
        Me.pnlSpace20.Location = New System.Drawing.Point(142, 0)
        Me.pnlSpace20.Name = "pnlSpace20"
        Me.pnlSpace20.numRows = 0
        Me.pnlSpace20.Reorder = True
        Me.pnlSpace20.Size = New System.Drawing.Size(6, 20)
        Me.pnlSpace20.TabIndex = 2
        '
        'dtfDto
        '
        Me.dtfDto.Allow_Empty = True
        Me.dtfDto.Allow_Negative = False
        Me.dtfDto.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfDto.BackColor = System.Drawing.SystemColors.Control
        Me.dtfDto.Data_Allowed = CustomControls.Datafield.List_Data.nDouble
        Me.dtfDto.DataField = Nothing
        Me.dtfDto.DataTable = ""
        Me.dtfDto.Descripcion = "Descuento"
        Me.dtfDto.Dock = System.Windows.Forms.DockStyle.Right
        Me.dtfDto.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfDto.FocoEnAgregar = False
        Me.dtfDto.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfDto.Image = Nothing
        Me.dtfDto.Label_Space = 75
        Me.dtfDto.Length_Data = 32767
        Me.dtfDto.Location = New System.Drawing.Point(148, 0)
        Me.dtfDto.Max_Value = 0.0R
        Me.dtfDto.MensajeIncorrectoCustom = Nothing
        Me.dtfDto.Name = "dtfDto"
        Me.dtfDto.Null_on_Empty = True
        Me.dtfDto.OpenForm = Nothing
        Me.dtfDto.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfDto.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfDto.ReadOnly_Data = False
        Me.dtfDto.Show_Button = False
        Me.dtfDto.Size = New System.Drawing.Size(110, 20)
        Me.dtfDto.TabIndex = 3
        Me.dtfDto.Text_Data = ""
        Me.dtfDto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.dtfDto.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfDto.TopPadding = 0
        Me.dtfDto.Upper_Case = False
        Me.dtfDto.Validate_on_lost_focus = True
        Me.dtfDto.Visible = False
        '
        'pnlSpace21
        '
        Me.pnlSpace21.Auto_Size = False
        Me.pnlSpace21.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace21.ChangeDock = True
        Me.pnlSpace21.Control_Resize = False
        Me.pnlSpace21.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSpace21.isSpace = True
        Me.pnlSpace21.Location = New System.Drawing.Point(258, 0)
        Me.pnlSpace21.Name = "pnlSpace21"
        Me.pnlSpace21.numRows = 0
        Me.pnlSpace21.Reorder = True
        Me.pnlSpace21.Size = New System.Drawing.Size(6, 20)
        Me.pnlSpace21.TabIndex = 4
        '
        'dtfBasei
        '
        Me.dtfBasei.Allow_Empty = True
        Me.dtfBasei.Allow_Negative = True
        Me.dtfBasei.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfBasei.BackColor = System.Drawing.SystemColors.Control
        Me.dtfBasei.Data_Allowed = CustomControls.Datafield.List_Data.nDouble
        Me.dtfBasei.DataField = "BASEI_CON2"
        Me.dtfBasei.DataTable = "C2"
        Me.dtfBasei.Descripcion = "Base"
        Me.dtfBasei.Dock = System.Windows.Forms.DockStyle.Right
        Me.dtfBasei.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfBasei.FocoEnAgregar = False
        Me.dtfBasei.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfBasei.Image = Nothing
        Me.dtfBasei.Label_Space = 50
        Me.dtfBasei.Length_Data = 32767
        Me.dtfBasei.Location = New System.Drawing.Point(264, 0)
        Me.dtfBasei.Max_Value = 0.0R
        Me.dtfBasei.MensajeIncorrectoCustom = Nothing
        Me.dtfBasei.Name = "dtfBasei"
        Me.dtfBasei.Null_on_Empty = True
        Me.dtfBasei.OpenForm = Nothing
        Me.dtfBasei.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfBasei.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfBasei.ReadOnly_Data = False
        Me.dtfBasei.Show_Button = False
        Me.dtfBasei.Size = New System.Drawing.Size(125, 20)
        Me.dtfBasei.TabIndex = 5
        Me.dtfBasei.Text_Data = ""
        Me.dtfBasei.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.dtfBasei.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfBasei.TopPadding = 0
        Me.dtfBasei.Upper_Case = False
        Me.dtfBasei.Validate_on_lost_focus = True
        '
        'pnlSpace47
        '
        Me.pnlSpace47.Auto_Size = False
        Me.pnlSpace47.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace47.ChangeDock = True
        Me.pnlSpace47.Control_Resize = False
        Me.pnlSpace47.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSpace47.isSpace = True
        Me.pnlSpace47.Location = New System.Drawing.Point(389, 0)
        Me.pnlSpace47.Name = "pnlSpace47"
        Me.pnlSpace47.numRows = 0
        Me.pnlSpace47.Reorder = True
        Me.pnlSpace47.Size = New System.Drawing.Size(6, 20)
        Me.pnlSpace47.TabIndex = 6
        '
        'dtfIVA
        '
        Me.dtfIVA.Allow_Empty = True
        Me.dtfIVA.Allow_Negative = True
        Me.dtfIVA.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfIVA.BackColor = System.Drawing.SystemColors.Control
        Me.dtfIVA.Data_Allowed = CustomControls.Datafield.List_Data.nDouble
        Me.dtfIVA.DataField = "TIIVA_CON2"
        Me.dtfIVA.DataTable = "C2"
        Me.dtfIVA.Descripcion = "Imp."
        Me.dtfIVA.Dock = System.Windows.Forms.DockStyle.Right
        Me.dtfIVA.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfIVA.FocoEnAgregar = False
        Me.dtfIVA.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfIVA.Image = Nothing
        Me.dtfIVA.Label_Space = 50
        Me.dtfIVA.Length_Data = 32767
        Me.dtfIVA.Location = New System.Drawing.Point(395, 0)
        Me.dtfIVA.Max_Value = 0.0R
        Me.dtfIVA.MensajeIncorrectoCustom = Nothing
        Me.dtfIVA.Name = "dtfIVA"
        Me.dtfIVA.Null_on_Empty = True
        Me.dtfIVA.OpenForm = Nothing
        Me.dtfIVA.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfIVA.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfIVA.ReadOnly_Data = True
        Me.dtfIVA.Show_Button = False
        Me.dtfIVA.Size = New System.Drawing.Size(99, 20)
        Me.dtfIVA.TabIndex = 7
        Me.dtfIVA.TabStop = False
        Me.dtfIVA.Text_Data = ""
        Me.dtfIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.dtfIVA.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfIVA.TopPadding = 0
        Me.dtfIVA.Upper_Case = False
        Me.dtfIVA.Validate_on_lost_focus = True
        '
        'pnlSpace48
        '
        Me.pnlSpace48.Auto_Size = False
        Me.pnlSpace48.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace48.ChangeDock = True
        Me.pnlSpace48.Control_Resize = False
        Me.pnlSpace48.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSpace48.isSpace = True
        Me.pnlSpace48.Location = New System.Drawing.Point(494, 0)
        Me.pnlSpace48.Name = "pnlSpace48"
        Me.pnlSpace48.numRows = 0
        Me.pnlSpace48.Reorder = True
        Me.pnlSpace48.Size = New System.Drawing.Size(6, 20)
        Me.pnlSpace48.TabIndex = 8
        '
        'dtfCuota
        '
        Me.dtfCuota.Allow_Empty = True
        Me.dtfCuota.Allow_Negative = True
        Me.dtfCuota.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfCuota.BackColor = System.Drawing.SystemColors.Control
        Me.dtfCuota.Data_Allowed = CustomControls.Datafield.List_Data.nDouble
        Me.dtfCuota.DataField = "IVA_CON2"
        Me.dtfCuota.DataTable = "C2"
        Me.dtfCuota.Descripcion = "Cuota"
        Me.dtfCuota.Dock = System.Windows.Forms.DockStyle.Right
        Me.dtfCuota.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfCuota.FocoEnAgregar = False
        Me.dtfCuota.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfCuota.Image = Nothing
        Me.dtfCuota.Label_Space = 50
        Me.dtfCuota.Length_Data = 32767
        Me.dtfCuota.Location = New System.Drawing.Point(500, 0)
        Me.dtfCuota.Max_Value = 0.0R
        Me.dtfCuota.MensajeIncorrectoCustom = Nothing
        Me.dtfCuota.Name = "dtfCuota"
        Me.dtfCuota.Null_on_Empty = True
        Me.dtfCuota.OpenForm = Nothing
        Me.dtfCuota.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfCuota.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfCuota.ReadOnly_Data = False
        Me.dtfCuota.Show_Button = False
        Me.dtfCuota.Size = New System.Drawing.Size(125, 20)
        Me.dtfCuota.TabIndex = 9
        Me.dtfCuota.Text_Data = ""
        Me.dtfCuota.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.dtfCuota.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfCuota.TopPadding = 0
        Me.dtfCuota.Upper_Case = False
        Me.dtfCuota.Validate_on_lost_focus = True
        '
        'pnlSpace46
        '
        Me.pnlSpace46.Auto_Size = False
        Me.pnlSpace46.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace46.ChangeDock = True
        Me.pnlSpace46.Control_Resize = False
        Me.pnlSpace46.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSpace46.isSpace = True
        Me.pnlSpace46.Location = New System.Drawing.Point(625, 0)
        Me.pnlSpace46.Name = "pnlSpace46"
        Me.pnlSpace46.numRows = 0
        Me.pnlSpace46.Reorder = True
        Me.pnlSpace46.Size = New System.Drawing.Size(6, 20)
        Me.pnlSpace46.TabIndex = 10
        '
        'btnExpand
        '
        Me.btnExpand.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnExpand.Location = New System.Drawing.Point(3, 0)
        Me.btnExpand.Name = "btnExpand"
        Me.btnExpand.Size = New System.Drawing.Size(19, 18)
        Me.btnExpand.TabIndex = 1
        Me.btnExpand.Text = "+"
        Me.btnExpand.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.btnExpand.ThemeName = "Windows8"
        '
        'dtfTotalCon
        '
        Me.dtfTotalCon.Allow_Empty = True
        Me.dtfTotalCon.Allow_Negative = True
        Me.dtfTotalCon.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfTotalCon.BackColor = System.Drawing.SystemColors.Control
        Me.dtfTotalCon.Data_Allowed = CustomControls.Datafield.List_Data.nDouble
        Me.dtfTotalCon.DataField = "TOLON_CON2"
        Me.dtfTotalCon.DataTable = "C2"
        Me.dtfTotalCon.Descripcion = "Total"
        Me.dtfTotalCon.Dock = System.Windows.Forms.DockStyle.Right
        Me.dtfTotalCon.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfTotalCon.FocoEnAgregar = False
        Me.dtfTotalCon.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfTotalCon.Image = Nothing
        Me.dtfTotalCon.Label_Space = 50
        Me.dtfTotalCon.Length_Data = 32767
        Me.dtfTotalCon.Location = New System.Drawing.Point(631, 0)
        Me.dtfTotalCon.Max_Value = 0.0R
        Me.dtfTotalCon.MensajeIncorrectoCustom = Nothing
        Me.dtfTotalCon.Name = "dtfTotalCon"
        Me.dtfTotalCon.Null_on_Empty = True
        Me.dtfTotalCon.OpenForm = Nothing
        Me.dtfTotalCon.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfTotalCon.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfTotalCon.ReadOnly_Data = False
        Me.dtfTotalCon.Show_Button = False
        Me.dtfTotalCon.Size = New System.Drawing.Size(125, 20)
        Me.dtfTotalCon.TabIndex = 11
        Me.dtfTotalCon.Text_Data = ""
        Me.dtfTotalCon.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.dtfTotalCon.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfTotalCon.TopPadding = 0
        Me.dtfTotalCon.Upper_Case = False
        Me.dtfTotalCon.Validate_on_lost_focus = True
        '
        'pnlGenIzq
        '
        Me.pnlGenIzq.Auto_Size = False
        Me.pnlGenIzq.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlGenIzq.ChangeDock = False
        Me.pnlGenIzq.Control_Resize = False
        Me.pnlGenIzq.Controls.Add(Me.gbxDatosCotiza)
        Me.pnlGenIzq.Controls.Add(Me.gbxDatosVehi)
        Me.pnlGenIzq.Controls.Add(Me.gbxDatosCli)
        Me.pnlGenIzq.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlGenIzq.isSpace = False
        Me.pnlGenIzq.Location = New System.Drawing.Point(0, 78)
        Me.pnlGenIzq.Name = "pnlGenIzq"
        Me.pnlGenIzq.numRows = 0
        Me.pnlGenIzq.Padding = New System.Windows.Forms.Padding(3)
        Me.pnlGenIzq.Reorder = True
        Me.pnlGenIzq.Size = New System.Drawing.Size(472, 481)
        Me.pnlGenIzq.TabIndex = 0
        '
        'gbxDatosCotiza
        '
        Me.gbxDatosCotiza.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.gbxDatosCotiza.Controls.Add(Me.btnRecalcularGeneral)
        Me.gbxDatosCotiza.Controls.Add(Me.btnLoadTari)
        Me.gbxDatosCotiza.Controls.Add(Me.dtfComisio)
        Me.gbxDatosCotiza.Controls.Add(Me.dtfTarifa)
        Me.gbxDatosCotiza.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbxDatosCotiza.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.gbxDatosCotiza.HeaderText = "Datos de la Cotización"
        Me.gbxDatosCotiza.Location = New System.Drawing.Point(3, 225)
        Me.gbxDatosCotiza.Name = "gbxDatosCotiza"
        Me.gbxDatosCotiza.numRows = 0
        Me.gbxDatosCotiza.Padding = New System.Windows.Forms.Padding(6, 18, 6, 6)
        Me.gbxDatosCotiza.Reorder = True
        Me.gbxDatosCotiza.Size = New System.Drawing.Size(466, 103)
        Me.gbxDatosCotiza.TabIndex = 2
        Me.gbxDatosCotiza.Text = "Datos de la Cotización"
        Me.gbxDatosCotiza.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.gbxDatosCotiza.ThemeName = "Windows8"
        Me.gbxDatosCotiza.Title = "Datos de la Cotización"
        '
        'btnRecalcularGeneral
        '
        Me.btnRecalcularGeneral.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnRecalcularGeneral.Location = New System.Drawing.Point(125, 73)
        Me.btnRecalcularGeneral.Name = "btnRecalcularGeneral"
        Me.btnRecalcularGeneral.Size = New System.Drawing.Size(75, 23)
        Me.btnRecalcularGeneral.TabIndex = 3
        Me.btnRecalcularGeneral.Text = "Recalcular"
        Me.btnRecalcularGeneral.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.btnRecalcularGeneral.ThemeName = "Windows8"
        '
        'btnLoadTari
        '
        Me.btnLoadTari.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnLoadTari.Location = New System.Drawing.Point(9, 73)
        Me.btnLoadTari.Name = "btnLoadTari"
        Me.btnLoadTari.Size = New System.Drawing.Size(110, 23)
        Me.btnLoadTari.TabIndex = 2
        Me.btnLoadTari.Text = "Cotiza"
        Me.btnLoadTari.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.btnLoadTari.ThemeName = "Windows8"
        '
        'dtfComisio
        '
        Me.dtfComisio.Allow_Empty = True
        Me.dtfComisio.Allow_Negative = True
        Me.dtfComisio.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfComisio.BackColor = System.Drawing.SystemColors.Control
        Me.dtfComisio.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfComisio.DataField = "COMISIO_CON2"
        Me.dtfComisio.DataTable = "C2"
        Me.dtfComisio.DB = Connection1
        Me.dtfComisio.Desc_Datafield = "NOMBRE"
        Me.dtfComisio.Desc_DBPK = "NUM_COMI"
        Me.dtfComisio.Desc_DBTable = "COMISIO"
        Me.dtfComisio.Desc_Where = Nothing
        Me.dtfComisio.Desc_WhereObligatoria = Nothing
        Me.dtfComisio.Descripcion = "Comisionista"
        Me.dtfComisio.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfComisio.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfComisio.ExtraSQL = ""
        Me.dtfComisio.FocoEnAgregar = False
        Me.dtfComisio.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfComisio.Formulario = Nothing
        Me.dtfComisio.Label_Space = 80
        Me.dtfComisio.Length_Data = 32767
        Me.dtfComisio.Location = New System.Drawing.Point(6, 44)
        Me.dtfComisio.Lupa = Nothing
        Me.dtfComisio.Max_Value = 0.0R
        Me.dtfComisio.MensajeIncorrectoCustom = Nothing
        Me.dtfComisio.Name = "dtfComisio"
        Me.dtfComisio.Null_on_Empty = True
        Me.dtfComisio.OpenForm = Nothing
        Me.dtfComisio.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfComisio.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfComisio.Query_on_Text_Changed = True
        Me.dtfComisio.ReadOnly_Data = False
        Me.dtfComisio.ReQuery = False
        Me.dtfComisio.ShowButton = True
        Me.dtfComisio.Size = New System.Drawing.Size(454, 26)
        Me.dtfComisio.TabIndex = 1
        Me.dtfComisio.Text_Data = ""
        Me.dtfComisio.Text_Data_Desc = ""
        Me.dtfComisio.Text_Width = 80
        Me.dtfComisio.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfComisio.TopPadding = 0
        Me.dtfComisio.Upper_Case = False
        Me.dtfComisio.Validate_on_lost_focus = True
        '
        'dtfTarifa
        '
        Me.dtfTarifa.Allow_Empty = False
        Me.dtfTarifa.Allow_Negative = True
        Me.dtfTarifa.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfTarifa.BackColor = System.Drawing.SystemColors.Control
        Me.dtfTarifa.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfTarifa.DataField = "TARIFA_CON1"
        Me.dtfTarifa.DataTable = "C1"
        Me.dtfTarifa.DB = Connection2
        Me.dtfTarifa.Desc_Datafield = "NOMBRE"
        Me.dtfTarifa.Desc_DBPK = "CODIGO"
        Me.dtfTarifa.Desc_DBTable = "NTARI"
        Me.dtfTarifa.Desc_Where = Nothing
        Me.dtfTarifa.Desc_WhereObligatoria = Nothing
        Me.dtfTarifa.Descripcion = "Tarifa"
        Me.dtfTarifa.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfTarifa.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfTarifa.ExtraSQL = ""
        Me.dtfTarifa.FocoEnAgregar = False
        Me.dtfTarifa.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfTarifa.Formulario = Nothing
        Me.dtfTarifa.Label_Space = 80
        Me.dtfTarifa.Length_Data = 32767
        Me.dtfTarifa.Location = New System.Drawing.Point(6, 18)
        Me.dtfTarifa.Lupa = Nothing
        Me.dtfTarifa.Max_Value = 0.0R
        Me.dtfTarifa.MensajeIncorrectoCustom = Nothing
        Me.dtfTarifa.Name = "dtfTarifa"
        Me.dtfTarifa.Null_on_Empty = True
        Me.dtfTarifa.OpenForm = Nothing
        Me.dtfTarifa.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfTarifa.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfTarifa.Query_on_Text_Changed = True
        Me.dtfTarifa.ReadOnly_Data = False
        Me.dtfTarifa.ReQuery = False
        Me.dtfTarifa.ShowButton = True
        Me.dtfTarifa.Size = New System.Drawing.Size(454, 26)
        Me.dtfTarifa.TabIndex = 0
        Me.dtfTarifa.Text_Data = ""
        Me.dtfTarifa.Text_Data_Desc = ""
        Me.dtfTarifa.Text_Width = 80
        Me.dtfTarifa.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfTarifa.TopPadding = 0
        Me.dtfTarifa.Upper_Case = False
        Me.dtfTarifa.Validate_on_lost_focus = True
        '
        'gbxDatosVehi
        '
        Me.gbxDatosVehi.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.gbxDatosVehi.Controls.Add(Me.pnlCombustibleKilometros)
        Me.gbxDatosVehi.Controls.Add(Me.pnlVehiculo)
        Me.gbxDatosVehi.Controls.Add(Me.pnlVehi)
        Me.gbxDatosVehi.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbxDatosVehi.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.gbxDatosVehi.HeaderText = "Datos del Vehículo"
        Me.gbxDatosVehi.Location = New System.Drawing.Point(3, 101)
        Me.gbxDatosVehi.Name = "gbxDatosVehi"
        Me.gbxDatosVehi.numRows = 4
        Me.gbxDatosVehi.Padding = New System.Windows.Forms.Padding(6, 18, 6, 6)
        Me.gbxDatosVehi.Reorder = True
        Me.gbxDatosVehi.Size = New System.Drawing.Size(466, 124)
        Me.gbxDatosVehi.TabIndex = 1
        Me.gbxDatosVehi.Text = "Datos del Vehículo"
        Me.gbxDatosVehi.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.gbxDatosVehi.ThemeName = "Windows8"
        Me.gbxDatosVehi.Title = "Datos del Vehículo"
        '
        'pnlCombustibleKilometros
        '
        Me.pnlCombustibleKilometros.Auto_Size = False
        Me.pnlCombustibleKilometros.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlCombustibleKilometros.ChangeDock = False
        Me.pnlCombustibleKilometros.Control_Resize = False
        Me.pnlCombustibleKilometros.Controls.Add(Me.trbLitrosSale)
        Me.pnlCombustibleKilometros.Controls.Add(Me.pnlLitrosOctavosSalida)
        Me.pnlCombustibleKilometros.Controls.Add(Me.pnlKilometros)
        Me.pnlCombustibleKilometros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCombustibleKilometros.isSpace = False
        Me.pnlCombustibleKilometros.Location = New System.Drawing.Point(6, 70)
        Me.pnlCombustibleKilometros.Name = "pnlCombustibleKilometros"
        Me.pnlCombustibleKilometros.numRows = 2
        Me.pnlCombustibleKilometros.Reorder = True
        Me.pnlCombustibleKilometros.Size = New System.Drawing.Size(454, 52)
        Me.pnlCombustibleKilometros.TabIndex = 2
        '
        'trbLitrosSale
        '
        Me.trbLitrosSale.Descripcion = ""
        Me.trbLitrosSale.Dock = System.Windows.Forms.DockStyle.Fill
        Me.trbLitrosSale.FocoEnAgregar = False
        Me.trbLitrosSale.LitrosAct = 0.0R
        Me.trbLitrosSale.Location = New System.Drawing.Point(160, 0)
        Me.trbLitrosSale.Name = "trbLitrosSale"
        Me.trbLitrosSale.Octavos = 0
        Me.trbLitrosSale.Size = New System.Drawing.Size(254, 52)
        Me.trbLitrosSale.TabIndex = 1
        Me.trbLitrosSale.TotalLitros = 0.0R
        '
        'pnlLitrosOctavosSalida
        '
        Me.pnlLitrosOctavosSalida.Auto_Size = False
        Me.pnlLitrosOctavosSalida.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlLitrosOctavosSalida.ChangeDock = True
        Me.pnlLitrosOctavosSalida.Control_Resize = False
        Me.pnlLitrosOctavosSalida.Controls.Add(Me.dtfLitrosSalida)
        Me.pnlLitrosOctavosSalida.Controls.Add(Me.mdfOctavosSalida)
        Me.pnlLitrosOctavosSalida.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlLitrosOctavosSalida.isSpace = False
        Me.pnlLitrosOctavosSalida.Location = New System.Drawing.Point(414, 0)
        Me.pnlLitrosOctavosSalida.Name = "pnlLitrosOctavosSalida"
        Me.pnlLitrosOctavosSalida.numRows = 0
        Me.pnlLitrosOctavosSalida.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.pnlLitrosOctavosSalida.Reorder = True
        Me.pnlLitrosOctavosSalida.Size = New System.Drawing.Size(40, 52)
        Me.pnlLitrosOctavosSalida.TabIndex = 2
        '
        'dtfLitrosSalida
        '
        Me.dtfLitrosSalida.Allow_Empty = True
        Me.dtfLitrosSalida.Allow_Negative = False
        Me.dtfLitrosSalida.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfLitrosSalida.BackColor = System.Drawing.SystemColors.Control
        Me.dtfLitrosSalida.Data_Allowed = CustomControls.Datafield.List_Data.nDouble
        Me.dtfLitrosSalida.DataField = "LITROS_SALE"
        Me.dtfLitrosSalida.DataTable = "VC"
        Me.dtfLitrosSalida.Descripcion = "Litros de Salida"
        Me.dtfLitrosSalida.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfLitrosSalida.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfLitrosSalida.FocoEnAgregar = False
        Me.dtfLitrosSalida.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfLitrosSalida.Length_Data = 32767
        Me.dtfLitrosSalida.Location = New System.Drawing.Point(6, 26)
        Me.dtfLitrosSalida.Max_Value = 0.0R
        Me.dtfLitrosSalida.MensajeIncorrectoCustom = Nothing
        Me.dtfLitrosSalida.Name = "dtfLitrosSalida"
        Me.dtfLitrosSalida.Null_on_Empty = True
        Me.dtfLitrosSalida.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfLitrosSalida.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfLitrosSalida.ReadOnly_Data = False
        Me.dtfLitrosSalida.Size = New System.Drawing.Size(34, 26)
        Me.dtfLitrosSalida.TabIndex = 1
        Me.dtfLitrosSalida.Text_Data = ""
        Me.dtfLitrosSalida.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfLitrosSalida.TopPadding = 0
        Me.dtfLitrosSalida.Upper_Case = False
        Me.dtfLitrosSalida.Validate_on_lost_focus = True
        '
        'mdfOctavosSalida
        '
        Me.mdfOctavosSalida.Alignemnt = System.Windows.Forms.HorizontalAlignment.Right
        Me.mdfOctavosSalida.Allow_Empty = True
        Me.mdfOctavosSalida.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.mdfOctavosSalida.BackColor = System.Drawing.SystemColors.Control
        Me.mdfOctavosSalida.DataField = "GASSALITEX"
        Me.mdfOctavosSalida.DataTable = "VC"
        Me.mdfOctavosSalida.Descripcion = "Octavos de Salida"
        Me.mdfOctavosSalida.Dock = System.Windows.Forms.DockStyle.Top
        Me.mdfOctavosSalida.FocoEnAgregar = False
        Me.mdfOctavosSalida.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.mdfOctavosSalida.Location = New System.Drawing.Point(6, 0)
        Me.mdfOctavosSalida.Mask = "#/8"
        Me.mdfOctavosSalida.MensajeIncorrectoCustom = Nothing
        Me.mdfOctavosSalida.Name = "mdfOctavosSalida"
        Me.mdfOctavosSalida.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.mdfOctavosSalida.ReadOnly_Data = False
        Me.mdfOctavosSalida.Regex = ""
        Me.mdfOctavosSalida.RegexInput = "[0-8]"
        Me.mdfOctavosSalida.Size = New System.Drawing.Size(34, 26)
        Me.mdfOctavosSalida.TabIndex = 0
        Me.mdfOctavosSalida.Text_Data = "_/8"
        Me.mdfOctavosSalida.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.mdfOctavosSalida.TopPadding = 0
        Me.mdfOctavosSalida.Upper_Case = False
        Me.mdfOctavosSalida.Validate_on_lost_focus = True
        '
        'pnlKilometros
        '
        Me.pnlKilometros.Auto_Size = False
        Me.pnlKilometros.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlKilometros.ChangeDock = False
        Me.pnlKilometros.Control_Resize = False
        Me.pnlKilometros.Controls.Add(Me.dtfKmIncluidos)
        Me.pnlKilometros.Controls.Add(Me.dtfKilometros)
        Me.pnlKilometros.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlKilometros.isSpace = False
        Me.pnlKilometros.Location = New System.Drawing.Point(0, 0)
        Me.pnlKilometros.Name = "pnlKilometros"
        Me.pnlKilometros.numRows = 0
        Me.pnlKilometros.Reorder = True
        Me.pnlKilometros.Size = New System.Drawing.Size(160, 52)
        Me.pnlKilometros.TabIndex = 0
        '
        'dtfKmIncluidos
        '
        Me.dtfKmIncluidos.Allow_Empty = True
        Me.dtfKmIncluidos.Allow_Negative = False
        Me.dtfKmIncluidos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfKmIncluidos.BackColor = System.Drawing.SystemColors.Control
        Me.dtfKmIncluidos.Data_Allowed = CustomControls.Datafield.List_Data.nDouble
        Me.dtfKmIncluidos.DataField = "KMINCL_CON1"
        Me.dtfKmIncluidos.DataTable = "C1"
        Me.dtfKmIncluidos.Descripcion = "Km. Incluidos"
        Me.dtfKmIncluidos.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfKmIncluidos.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfKmIncluidos.FocoEnAgregar = False
        Me.dtfKmIncluidos.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfKmIncluidos.Image = Nothing
        Me.dtfKmIncluidos.Label_Space = 80
        Me.dtfKmIncluidos.Length_Data = 32767
        Me.dtfKmIncluidos.Location = New System.Drawing.Point(0, 26)
        Me.dtfKmIncluidos.Max_Value = 0.0R
        Me.dtfKmIncluidos.MensajeIncorrectoCustom = Nothing
        Me.dtfKmIncluidos.Name = "dtfKmIncluidos"
        Me.dtfKmIncluidos.Null_on_Empty = True
        Me.dtfKmIncluidos.OpenForm = Nothing
        Me.dtfKmIncluidos.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfKmIncluidos.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfKmIncluidos.ReadOnly_Data = False
        Me.dtfKmIncluidos.Show_Button = False
        Me.dtfKmIncluidos.Size = New System.Drawing.Size(160, 26)
        Me.dtfKmIncluidos.TabIndex = 1
        Me.dtfKmIncluidos.Text_Data = ""
        Me.dtfKmIncluidos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.dtfKmIncluidos.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfKmIncluidos.TopPadding = 0
        Me.dtfKmIncluidos.Upper_Case = False
        Me.dtfKmIncluidos.Validate_on_lost_focus = True
        '
        'dtfKilometros
        '
        Me.dtfKilometros.Allow_Empty = True
        Me.dtfKilometros.Allow_Negative = False
        Me.dtfKilometros.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfKilometros.BackColor = System.Drawing.SystemColors.Control
        Me.dtfKilometros.Data_Allowed = CustomControls.Datafield.List_Data.nDouble
        Me.dtfKilometros.DataField = "KM"
        Me.dtfKilometros.DataTable = "VC"
        Me.dtfKilometros.Descripcion = "Kilómetros"
        Me.dtfKilometros.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfKilometros.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfKilometros.FocoEnAgregar = False
        Me.dtfKilometros.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfKilometros.Image = Nothing
        Me.dtfKilometros.Label_Space = 80
        Me.dtfKilometros.Length_Data = 32767
        Me.dtfKilometros.Location = New System.Drawing.Point(0, 0)
        Me.dtfKilometros.Max_Value = 0.0R
        Me.dtfKilometros.MensajeIncorrectoCustom = Nothing
        Me.dtfKilometros.Name = "dtfKilometros"
        Me.dtfKilometros.Null_on_Empty = True
        Me.dtfKilometros.OpenForm = Nothing
        Me.dtfKilometros.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfKilometros.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfKilometros.ReadOnly_Data = True
        Me.dtfKilometros.Show_Button = False
        Me.dtfKilometros.Size = New System.Drawing.Size(160, 26)
        Me.dtfKilometros.TabIndex = 0
        Me.dtfKilometros.TabStop = False
        Me.dtfKilometros.Text_Data = ""
        Me.dtfKilometros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.dtfKilometros.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfKilometros.TopPadding = 0
        Me.dtfKilometros.Upper_Case = False
        Me.dtfKilometros.Validate_on_lost_focus = True
        '
        'pnlVehiculo
        '
        Me.pnlVehiculo.Auto_Size = False
        Me.pnlVehiculo.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlVehiculo.ChangeDock = True
        Me.pnlVehiculo.Control_Resize = False
        Me.pnlVehiculo.Controls.Add(Me.dtfVehiculo)
        Me.pnlVehiculo.Controls.Add(Me.dtfVehiculo_Ctr)
        Me.pnlVehiculo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlVehiculo.isSpace = False
        Me.pnlVehiculo.Location = New System.Drawing.Point(6, 44)
        Me.pnlVehiculo.Name = "pnlVehiculo"
        Me.pnlVehiculo.numRows = 1
        Me.pnlVehiculo.Reorder = True
        Me.pnlVehiculo.Size = New System.Drawing.Size(454, 26)
        Me.pnlVehiculo.TabIndex = 1
        '
        'dtfVehiculo
        '
        Me.dtfVehiculo.Allow_Empty = False
        Me.dtfVehiculo.Allow_Negative = True
        Me.dtfVehiculo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfVehiculo.BackColor = System.Drawing.SystemColors.Control
        Me.dtfVehiculo.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfVehiculo.DataField = "CODIINT_VC"
        Me.dtfVehiculo.DataTable = "VC"
        Me.dtfVehiculo.DB = Connection3
        Me.dtfVehiculo.Desc_Datafield = "ISNULL(MARCA, '')  + ' ' + ISNULL(MODELO, '') MODMARCA"
        Me.dtfVehiculo.Desc_DBPK = "CODIINT"
        Me.dtfVehiculo.Desc_DBTable = "VEHICULO1"
        Me.dtfVehiculo.Desc_Where = Nothing
        Me.dtfVehiculo.Desc_WhereObligatoria = Nothing
        Me.dtfVehiculo.Descripcion = "Vehiculo"
        Me.dtfVehiculo.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfVehiculo.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfVehiculo.ExtraSQL = ""
        Me.dtfVehiculo.FocoEnAgregar = False
        Me.dtfVehiculo.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfVehiculo.Formulario = Nothing
        Me.dtfVehiculo.Label_Space = 80
        Me.dtfVehiculo.Length_Data = 32767
        Me.dtfVehiculo.Location = New System.Drawing.Point(0, 0)
        Me.dtfVehiculo.Lupa = Nothing
        Me.dtfVehiculo.Max_Value = 0.0R
        Me.dtfVehiculo.MensajeIncorrectoCustom = Nothing
        Me.dtfVehiculo.Name = "dtfVehiculo"
        Me.dtfVehiculo.Null_on_Empty = True
        Me.dtfVehiculo.OpenForm = Nothing
        Me.dtfVehiculo.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfVehiculo.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfVehiculo.Query_on_Text_Changed = True
        Me.dtfVehiculo.ReadOnly_Data = False
        Me.dtfVehiculo.ReQuery = False
        Me.dtfVehiculo.ShowButton = True
        Me.dtfVehiculo.Size = New System.Drawing.Size(444, 26)
        Me.dtfVehiculo.TabIndex = 0
        Me.dtfVehiculo.Text_Data = ""
        Me.dtfVehiculo.Text_Data_Desc = ""
        Me.dtfVehiculo.Text_Width = 80
        Me.dtfVehiculo.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfVehiculo.TopPadding = 0
        Me.dtfVehiculo.Upper_Case = False
        Me.dtfVehiculo.Validate_on_lost_focus = True
        '
        'dtfVehiculo_Ctr
        '
        Me.dtfVehiculo_Ctr.Allow_Empty = True
        Me.dtfVehiculo_Ctr.Allow_Negative = True
        Me.dtfVehiculo_Ctr.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfVehiculo_Ctr.BackColor = System.Drawing.SystemColors.Control
        Me.dtfVehiculo_Ctr.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfVehiculo_Ctr.DataField = "VCACT_CON1"
        Me.dtfVehiculo_Ctr.DataTable = "C1"
        Me.dtfVehiculo_Ctr.Descripcion = Nothing
        Me.dtfVehiculo_Ctr.Dock = System.Windows.Forms.DockStyle.Right
        Me.dtfVehiculo_Ctr.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfVehiculo_Ctr.FocoEnAgregar = False
        Me.dtfVehiculo_Ctr.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfVehiculo_Ctr.Length_Data = 32767
        Me.dtfVehiculo_Ctr.Location = New System.Drawing.Point(444, 0)
        Me.dtfVehiculo_Ctr.Max_Value = 0.0R
        Me.dtfVehiculo_Ctr.MensajeIncorrectoCustom = Nothing
        Me.dtfVehiculo_Ctr.Name = "dtfVehiculo_Ctr"
        Me.dtfVehiculo_Ctr.Null_on_Empty = True
        Me.dtfVehiculo_Ctr.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfVehiculo_Ctr.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfVehiculo_Ctr.ReadOnly_Data = True
        Me.dtfVehiculo_Ctr.Size = New System.Drawing.Size(10, 26)
        Me.dtfVehiculo_Ctr.TabIndex = 1
        Me.dtfVehiculo_Ctr.TabStop = False
        Me.dtfVehiculo_Ctr.Text_Data = ""
        Me.dtfVehiculo_Ctr.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfVehiculo_Ctr.TopPadding = 0
        Me.dtfVehiculo_Ctr.Upper_Case = False
        Me.dtfVehiculo_Ctr.Validate_on_lost_focus = True
        Me.dtfVehiculo_Ctr.Visible = False
        '
        'pnlVehi
        '
        Me.pnlVehi.Auto_Size = False
        Me.pnlVehi.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlVehi.ChangeDock = False
        Me.pnlVehi.Control_Resize = False
        Me.pnlVehi.Controls.Add(Me.dtfGrupo)
        Me.pnlVehi.Controls.Add(Me.pnlSpace17)
        Me.pnlVehi.Controls.Add(Me.dtfMatricula)
        Me.pnlVehi.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlVehi.isSpace = False
        Me.pnlVehi.Location = New System.Drawing.Point(6, 18)
        Me.pnlVehi.Name = "pnlVehi"
        Me.pnlVehi.numRows = 1
        Me.pnlVehi.Reorder = True
        Me.pnlVehi.Size = New System.Drawing.Size(454, 26)
        Me.pnlVehi.TabIndex = 0
        '
        'dtfGrupo
        '
        Me.dtfGrupo.Allow_Empty = True
        Me.dtfGrupo.Allow_Negative = True
        Me.dtfGrupo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfGrupo.BackColor = System.Drawing.SystemColors.Control
        Me.dtfGrupo.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfGrupo.DataField = "GRUPO_CON1"
        Me.dtfGrupo.DataTable = "C1"
        Me.dtfGrupo.DB = Connection4
        Me.dtfGrupo.Desc_Datafield = "NOMBRE"
        Me.dtfGrupo.Desc_DBPK = "CODIGO"
        Me.dtfGrupo.Desc_DBTable = "GRUPOS"
        Me.dtfGrupo.Desc_Where = Nothing
        Me.dtfGrupo.Desc_WhereObligatoria = Nothing
        Me.dtfGrupo.Descripcion = "Grupo"
        Me.dtfGrupo.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfGrupo.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfGrupo.ExtraSQL = ""
        Me.dtfGrupo.FocoEnAgregar = False
        Me.dtfGrupo.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfGrupo.Formulario = Nothing
        Me.dtfGrupo.Label_Space = 75
        Me.dtfGrupo.Length_Data = 32767
        Me.dtfGrupo.Location = New System.Drawing.Point(166, 0)
        Me.dtfGrupo.Lupa = Nothing
        Me.dtfGrupo.Max_Value = 0.0R
        Me.dtfGrupo.MensajeIncorrectoCustom = Nothing
        Me.dtfGrupo.Name = "dtfGrupo"
        Me.dtfGrupo.Null_on_Empty = True
        Me.dtfGrupo.OpenForm = Nothing
        Me.dtfGrupo.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfGrupo.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfGrupo.Query_on_Text_Changed = True
        Me.dtfGrupo.ReadOnly_Data = False
        Me.dtfGrupo.ReQuery = False
        Me.dtfGrupo.ShowButton = True
        Me.dtfGrupo.Size = New System.Drawing.Size(288, 26)
        Me.dtfGrupo.TabIndex = 2
        Me.dtfGrupo.Text_Data = ""
        Me.dtfGrupo.Text_Data_Desc = ""
        Me.dtfGrupo.Text_Width = 40
        Me.dtfGrupo.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfGrupo.TopPadding = 0
        Me.dtfGrupo.Upper_Case = False
        Me.dtfGrupo.Validate_on_lost_focus = True
        '
        'pnlSpace17
        '
        Me.pnlSpace17.Auto_Size = False
        Me.pnlSpace17.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace17.ChangeDock = True
        Me.pnlSpace17.Control_Resize = False
        Me.pnlSpace17.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace17.isSpace = True
        Me.pnlSpace17.Location = New System.Drawing.Point(160, 0)
        Me.pnlSpace17.Name = "pnlSpace17"
        Me.pnlSpace17.numRows = 0
        Me.pnlSpace17.Reorder = True
        Me.pnlSpace17.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace17.TabIndex = 1
        '
        'dtfMatricula
        '
        Me.dtfMatricula.Allow_Empty = True
        Me.dtfMatricula.Allow_Negative = True
        Me.dtfMatricula.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfMatricula.BackColor = System.Drawing.SystemColors.Control
        Me.dtfMatricula.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfMatricula.DataField = "MATRI_VC"
        Me.dtfMatricula.DataTable = "VC"
        Me.dtfMatricula.DB = Connection5
        Me.dtfMatricula.Desc_Datafield = "CODIINT"
        Me.dtfMatricula.Desc_DBPK = "MATRICULA"
        Me.dtfMatricula.Desc_DBTable = "VEHICULO1"
        Me.dtfMatricula.Desc_Where = Nothing
        Me.dtfMatricula.Desc_WhereObligatoria = Nothing
        Me.dtfMatricula.Descripcion = "Matricula"
        Me.dtfMatricula.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfMatricula.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfMatricula.ExtraSQL = ""
        Me.dtfMatricula.FocoEnAgregar = False
        Me.dtfMatricula.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfMatricula.Formulario = Nothing
        Me.dtfMatricula.Label_Space = 80
        Me.dtfMatricula.Length_Data = 32767
        Me.dtfMatricula.Location = New System.Drawing.Point(0, 0)
        Me.dtfMatricula.Lupa = Nothing
        Me.dtfMatricula.Max_Value = 0.0R
        Me.dtfMatricula.MensajeIncorrectoCustom = Nothing
        Me.dtfMatricula.Name = "dtfMatricula"
        Me.dtfMatricula.Null_on_Empty = True
        Me.dtfMatricula.OpenForm = Nothing
        Me.dtfMatricula.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfMatricula.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfMatricula.Query_on_Text_Changed = False
        Me.dtfMatricula.ReadOnly_Data = False
        Me.dtfMatricula.ReQuery = False
        Me.dtfMatricula.ShowButton = False
        Me.dtfMatricula.Size = New System.Drawing.Size(160, 26)
        Me.dtfMatricula.TabIndex = 0
        Me.dtfMatricula.Text_Data = ""
        Me.dtfMatricula.Text_Data_Desc = ""
        Me.dtfMatricula.Text_Width = 80
        Me.dtfMatricula.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfMatricula.TopPadding = 0
        Me.dtfMatricula.Upper_Case = False
        Me.dtfMatricula.Validate_on_lost_focus = True
        '
        'gbxDatosCli
        '
        Me.gbxDatosCli.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.gbxDatosCli.Controls.Add(Me.dtfConductor)
        Me.gbxDatosCli.Controls.Add(Me.dtfDelegacion)
        Me.gbxDatosCli.Controls.Add(Me.dtfCliente)
        Me.gbxDatosCli.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbxDatosCli.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.gbxDatosCli.HeaderText = "Datos del Cliente"
        Me.gbxDatosCli.Location = New System.Drawing.Point(3, 3)
        Me.gbxDatosCli.Name = "gbxDatosCli"
        Me.gbxDatosCli.numRows = 3
        Me.gbxDatosCli.Padding = New System.Windows.Forms.Padding(6, 18, 6, 6)
        Me.gbxDatosCli.Reorder = True
        Me.gbxDatosCli.Size = New System.Drawing.Size(466, 98)
        Me.gbxDatosCli.TabIndex = 0
        Me.gbxDatosCli.Text = "Datos del Cliente"
        Me.gbxDatosCli.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.gbxDatosCli.ThemeName = "Windows8"
        Me.gbxDatosCli.Title = "Datos del Cliente"
        '
        'dtfConductor
        '
        Me.dtfConductor.Allow_Empty = False
        Me.dtfConductor.Allow_Negative = True
        Me.dtfConductor.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfConductor.BackColor = System.Drawing.SystemColors.Control
        Me.dtfConductor.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfConductor.DataField = "CONDUCTOR_CON1"
        Me.dtfConductor.DataField_DescEdit = Nothing
        Me.dtfConductor.DataTable = "C1"
        Me.dtfConductor.DataTable_DescEdit = ""
        Me.dtfConductor.DB = Connection6
        Me.dtfConductor.Desc_Datafield = "NOMBRE"
        Me.dtfConductor.Desc_DBPK = "NUMERO_CLI"
        Me.dtfConductor.Desc_DBTable = "CLIENTES1"
        Me.dtfConductor.Desc_Where = "BAJA IS NULL"
        Me.dtfConductor.Desc_WhereObligatoria = Nothing
        Me.dtfConductor.Descripcion = "Conductor"
        Me.dtfConductor.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfConductor.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfConductor.ExtraSQL = ""
        Me.dtfConductor.FocoEnAgregar = False
        Me.dtfConductor.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfConductor.Formulario = Nothing
        Me.dtfConductor.Label_Space = 80
        Me.dtfConductor.Length_Data = 32767
        Me.dtfConductor.Location = New System.Drawing.Point(6, 70)
        Me.dtfConductor.Lupa = Nothing
        Me.dtfConductor.Max_Value = 0.0R
        Me.dtfConductor.MensajeIncorrectoCustom = Nothing
        Me.dtfConductor.Name = "dtfConductor"
        Me.dtfConductor.Null_on_Empty = True
        Me.dtfConductor.OpenForm = Nothing
        Me.dtfConductor.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfConductor.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfConductor.Query_on_Text_Changed = True
        Me.dtfConductor.ReadOnly_Data = False
        Me.dtfConductor.ReadOnly_Desc = False
        Me.dtfConductor.ReQuery = False
        Me.dtfConductor.ShowButton = True
        Me.dtfConductor.Size = New System.Drawing.Size(454, 26)
        Me.dtfConductor.TabIndex = 2
        Me.dtfConductor.Text_Data = ""
        Me.dtfConductor.Text_Data_Desc = ""
        Me.dtfConductor.Text_Width = 80
        Me.dtfConductor.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfConductor.TopPadding = 0
        Me.dtfConductor.Upper_Case = False
        Me.dtfConductor.Validate_on_lost_focus = True
        '
        'dtfDelegacion
        '
        Me.dtfDelegacion.Allow_Empty = True
        Me.dtfDelegacion.Allow_Negative = True
        Me.dtfDelegacion.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfDelegacion.BackColor = System.Drawing.SystemColors.Control
        Me.dtfDelegacion.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfDelegacion.DataField = "CLI_DELEGA_CON1"
        Me.dtfDelegacion.DataTable = "C1"
        Me.dtfDelegacion.DB = Connection7
        Me.dtfDelegacion.Desc_Datafield = "CLDDELEGACION"
        Me.dtfDelegacion.Desc_DBPK = "CLDIDDELEGA"
        Me.dtfDelegacion.Desc_DBTable = "CLIDELEGA"
        Me.dtfDelegacion.Desc_Where = Nothing
        Me.dtfDelegacion.Desc_WhereObligatoria = Nothing
        Me.dtfDelegacion.Descripcion = "Delegacion"
        Me.dtfDelegacion.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfDelegacion.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfDelegacion.ExtraSQL = ""
        Me.dtfDelegacion.FocoEnAgregar = False
        Me.dtfDelegacion.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfDelegacion.Formulario = Nothing
        Me.dtfDelegacion.Label_Space = 80
        Me.dtfDelegacion.Length_Data = 32767
        Me.dtfDelegacion.Location = New System.Drawing.Point(6, 44)
        Me.dtfDelegacion.Lupa = Nothing
        Me.dtfDelegacion.Max_Value = 0.0R
        Me.dtfDelegacion.MensajeIncorrectoCustom = Nothing
        Me.dtfDelegacion.Name = "dtfDelegacion"
        Me.dtfDelegacion.Null_on_Empty = True
        Me.dtfDelegacion.OpenForm = Nothing
        Me.dtfDelegacion.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfDelegacion.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfDelegacion.Query_on_Text_Changed = True
        Me.dtfDelegacion.ReadOnly_Data = False
        Me.dtfDelegacion.ReQuery = False
        Me.dtfDelegacion.ShowButton = True
        Me.dtfDelegacion.Size = New System.Drawing.Size(454, 26)
        Me.dtfDelegacion.TabIndex = 1
        Me.dtfDelegacion.Text_Data = ""
        Me.dtfDelegacion.Text_Data_Desc = ""
        Me.dtfDelegacion.Text_Width = 80
        Me.dtfDelegacion.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfDelegacion.TopPadding = 0
        Me.dtfDelegacion.Upper_Case = False
        Me.dtfDelegacion.Validate_on_lost_focus = True
        '
        'dtfCliente
        '
        Me.dtfCliente.Allow_Empty = False
        Me.dtfCliente.Allow_Negative = True
        Me.dtfCliente.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfCliente.BackColor = System.Drawing.SystemColors.Control
        Me.dtfCliente.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfCliente.DataField = "CLIENTE_CON1"
        Me.dtfCliente.DataField_DescEdit = "NOMBRE_CON1"
        Me.dtfCliente.DataTable = "C1"
        Me.dtfCliente.DataTable_DescEdit = "C1"
        Me.dtfCliente.DB = Connection8
        Me.dtfCliente.Desc_Datafield = "NOMBRE"
        Me.dtfCliente.Desc_DBPK = "NUMERO_CLI"
        Me.dtfCliente.Desc_DBTable = "CLIENTES1"
        Me.dtfCliente.Desc_Where = "BAJA IS NULL"
        Me.dtfCliente.Desc_WhereObligatoria = ""
        Me.dtfCliente.Descripcion = "Cliente"
        Me.dtfCliente.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfCliente.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfCliente.ExtraSQL = ""
        Me.dtfCliente.FocoEnAgregar = False
        Me.dtfCliente.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfCliente.Formulario = Nothing
        Me.dtfCliente.Label_Space = 80
        Me.dtfCliente.Length_Data = 32767
        Me.dtfCliente.Location = New System.Drawing.Point(6, 18)
        Me.dtfCliente.Lupa = Nothing
        Me.dtfCliente.Max_Value = 0.0R
        Me.dtfCliente.MensajeIncorrectoCustom = Nothing
        Me.dtfCliente.Name = "dtfCliente"
        Me.dtfCliente.Null_on_Empty = True
        Me.dtfCliente.OpenForm = Nothing
        Me.dtfCliente.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfCliente.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfCliente.Query_on_Text_Changed = True
        Me.dtfCliente.ReadOnly_Data = False
        Me.dtfCliente.ReadOnly_Desc = False
        Me.dtfCliente.ReQuery = False
        Me.dtfCliente.ShowButton = True
        Me.dtfCliente.Size = New System.Drawing.Size(454, 26)
        Me.dtfCliente.TabIndex = 0
        Me.dtfCliente.Text_Data = ""
        Me.dtfCliente.Text_Data_Desc = ""
        Me.dtfCliente.Text_Width = 80
        Me.dtfCliente.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfCliente.TopPadding = 0
        Me.dtfCliente.Upper_Case = False
        Me.dtfCliente.Validate_on_lost_focus = True
        '
        'pnlCabeceraGeneral
        '
        Me.pnlCabeceraGeneral.Auto_Size = False
        Me.pnlCabeceraGeneral.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlCabeceraGeneral.ChangeDock = False
        Me.pnlCabeceraGeneral.Control_Resize = False
        Me.pnlCabeceraGeneral.Controls.Add(Me.pnlCabecera)
        Me.pnlCabeceraGeneral.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCabeceraGeneral.isSpace = False
        Me.pnlCabeceraGeneral.Location = New System.Drawing.Point(0, 0)
        Me.pnlCabeceraGeneral.Name = "pnlCabeceraGeneral"
        Me.pnlCabeceraGeneral.numRows = 3
        Me.pnlCabeceraGeneral.Reorder = True
        Me.pnlCabeceraGeneral.Size = New System.Drawing.Size(1246, 78)
        Me.pnlCabeceraGeneral.TabIndex = 5
        '
        'pnlCabecera
        '
        Me.pnlCabecera.Auto_Size = False
        Me.pnlCabecera.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlCabecera.ChangeDock = False
        Me.pnlCabecera.Control_Resize = False
        Me.pnlCabecera.Controls.Add(Me.pnlDatosPrevistos)
        Me.pnlCabecera.Controls.Add(Me.pnlDatosSalida)
        Me.pnlCabecera.Controls.Add(Me.pnlCabezeraSup)
        Me.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCabecera.isSpace = False
        Me.pnlCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlCabecera.Name = "pnlCabecera"
        Me.pnlCabecera.numRows = 3
        Me.pnlCabecera.Padding = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.pnlCabecera.Reorder = True
        Me.pnlCabecera.Size = New System.Drawing.Size(1246, 78)
        Me.pnlCabecera.TabIndex = 0
        '
        'pnlDatosPrevistos
        '
        Me.pnlDatosPrevistos.Auto_Size = False
        Me.pnlDatosPrevistos.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlDatosPrevistos.ChangeDock = False
        Me.pnlDatosPrevistos.Control_Resize = False
        Me.pnlDatosPrevistos.Controls.Add(Me.dtfLugarRecogida)
        Me.pnlDatosPrevistos.Controls.Add(Me.pnlSpace16)
        Me.pnlDatosPrevistos.Controls.Add(Me.dtfUsuRecoje)
        Me.pnlDatosPrevistos.Controls.Add(Me.pnlSpace15)
        Me.pnlDatosPrevistos.Controls.Add(Me.dtfOfiLlegada)
        Me.pnlDatosPrevistos.Controls.Add(Me.pnlSpace14)
        Me.pnlDatosPrevistos.Controls.Add(Me.dttHPrevista)
        Me.pnlDatosPrevistos.Controls.Add(Me.pnlSpace13)
        Me.pnlDatosPrevistos.Controls.Add(Me.dtdFPrevista)
        Me.pnlDatosPrevistos.Controls.Add(Me.pnlSpace12)
        Me.pnlDatosPrevistos.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlDatosPrevistos.isSpace = False
        Me.pnlDatosPrevistos.Location = New System.Drawing.Point(3, 55)
        Me.pnlDatosPrevistos.Name = "pnlDatosPrevistos"
        Me.pnlDatosPrevistos.numRows = 1
        Me.pnlDatosPrevistos.Reorder = True
        Me.pnlDatosPrevistos.Size = New System.Drawing.Size(1240, 26)
        Me.pnlDatosPrevistos.TabIndex = 2
        '
        'dtfLugarRecogida
        '
        Me.dtfLugarRecogida.Allow_Empty = True
        Me.dtfLugarRecogida.Allow_Negative = True
        Me.dtfLugarRecogida.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfLugarRecogida.BackColor = System.Drawing.SystemColors.Control
        Me.dtfLugarRecogida.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfLugarRecogida.DataField = "LUDEVO_CON1"
        Me.dtfLugarRecogida.DataTable = "C1"
        Me.dtfLugarRecogida.Descripcion = "Lugar Recogida"
        Me.dtfLugarRecogida.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfLugarRecogida.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfLugarRecogida.FocoEnAgregar = False
        Me.dtfLugarRecogida.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfLugarRecogida.Image = Nothing
        Me.dtfLugarRecogida.Label_Space = 100
        Me.dtfLugarRecogida.Length_Data = 32767
        Me.dtfLugarRecogida.Location = New System.Drawing.Point(660, 0)
        Me.dtfLugarRecogida.Max_Value = 0.0R
        Me.dtfLugarRecogida.MensajeIncorrectoCustom = Nothing
        Me.dtfLugarRecogida.Name = "dtfLugarRecogida"
        Me.dtfLugarRecogida.Null_on_Empty = True
        Me.dtfLugarRecogida.OpenForm = Nothing
        Me.dtfLugarRecogida.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfLugarRecogida.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfLugarRecogida.ReadOnly_Data = False
        Me.dtfLugarRecogida.Show_Button = True
        Me.dtfLugarRecogida.Size = New System.Drawing.Size(580, 26)
        Me.dtfLugarRecogida.TabIndex = 9
        Me.dtfLugarRecogida.Text_Data = ""
        Me.dtfLugarRecogida.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfLugarRecogida.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfLugarRecogida.TopPadding = 0
        Me.dtfLugarRecogida.Upper_Case = False
        Me.dtfLugarRecogida.Validate_on_lost_focus = True
        '
        'pnlSpace16
        '
        Me.pnlSpace16.Auto_Size = False
        Me.pnlSpace16.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace16.ChangeDock = True
        Me.pnlSpace16.Control_Resize = False
        Me.pnlSpace16.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace16.isSpace = True
        Me.pnlSpace16.Location = New System.Drawing.Point(654, 0)
        Me.pnlSpace16.Name = "pnlSpace16"
        Me.pnlSpace16.numRows = 0
        Me.pnlSpace16.Reorder = True
        Me.pnlSpace16.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace16.TabIndex = 8
        '
        'dtfUsuRecoje
        '
        Me.dtfUsuRecoje.Allow_Empty = True
        Me.dtfUsuRecoje.Allow_Negative = True
        Me.dtfUsuRecoje.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfUsuRecoje.BackColor = System.Drawing.SystemColors.Control
        Me.dtfUsuRecoje.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfUsuRecoje.DataField = "RENTAL2_CON1"
        Me.dtfUsuRecoje.DataTable = "C1"
        Me.dtfUsuRecoje.DB = Connection9
        Me.dtfUsuRecoje.Desc_Datafield = "NOMBRE"
        Me.dtfUsuRecoje.Desc_DBPK = "CODIGO"
        Me.dtfUsuRecoje.Desc_DBTable = "USURE"
        Me.dtfUsuRecoje.Desc_Where = "FBAJA IS NULL"
        Me.dtfUsuRecoje.Desc_WhereObligatoria = Nothing
        Me.dtfUsuRecoje.Descripcion = "Usu Recoje"
        Me.dtfUsuRecoje.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfUsuRecoje.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfUsuRecoje.ExtraSQL = ""
        Me.dtfUsuRecoje.FocoEnAgregar = False
        Me.dtfUsuRecoje.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfUsuRecoje.Formulario = Nothing
        Me.dtfUsuRecoje.Label_Space = 75
        Me.dtfUsuRecoje.Length_Data = 32767
        Me.dtfUsuRecoje.Location = New System.Drawing.Point(512, 0)
        Me.dtfUsuRecoje.Lupa = Nothing
        Me.dtfUsuRecoje.Max_Value = 0.0R
        Me.dtfUsuRecoje.MensajeIncorrectoCustom = Nothing
        Me.dtfUsuRecoje.Name = "dtfUsuRecoje"
        Me.dtfUsuRecoje.Null_on_Empty = True
        Me.dtfUsuRecoje.OpenForm = Nothing
        Me.dtfUsuRecoje.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfUsuRecoje.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfUsuRecoje.Query_on_Text_Changed = True
        Me.dtfUsuRecoje.ReadOnly_Data = False
        Me.dtfUsuRecoje.ReQuery = False
        Me.dtfUsuRecoje.ShowButton = True
        Me.dtfUsuRecoje.Size = New System.Drawing.Size(142, 26)
        Me.dtfUsuRecoje.TabIndex = 7
        Me.dtfUsuRecoje.Text_Data = ""
        Me.dtfUsuRecoje.Text_Data_Desc = ""
        Me.dtfUsuRecoje.Text_Width = 40
        Me.dtfUsuRecoje.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfUsuRecoje.TopPadding = 0
        Me.dtfUsuRecoje.Upper_Case = False
        Me.dtfUsuRecoje.Validate_on_lost_focus = True
        '
        'pnlSpace15
        '
        Me.pnlSpace15.Auto_Size = False
        Me.pnlSpace15.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace15.ChangeDock = True
        Me.pnlSpace15.Control_Resize = False
        Me.pnlSpace15.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace15.isSpace = True
        Me.pnlSpace15.Location = New System.Drawing.Point(506, 0)
        Me.pnlSpace15.Name = "pnlSpace15"
        Me.pnlSpace15.numRows = 0
        Me.pnlSpace15.Reorder = True
        Me.pnlSpace15.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace15.TabIndex = 6
        '
        'dtfOfiLlegada
        '
        Me.dtfOfiLlegada.Allow_Empty = True
        Me.dtfOfiLlegada.Allow_Negative = True
        Me.dtfOfiLlegada.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfOfiLlegada.BackColor = System.Drawing.SystemColors.Control
        Me.dtfOfiLlegada.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfOfiLlegada.DataField = "OFIRETORNO_CON1"
        Me.dtfOfiLlegada.DataTable = "C1"
        Me.dtfOfiLlegada.DB = Connection10
        Me.dtfOfiLlegada.Desc_Datafield = "NOMBRE"
        Me.dtfOfiLlegada.Desc_DBPK = "CODIGO"
        Me.dtfOfiLlegada.Desc_DBTable = "OFICINAS"
        Me.dtfOfiLlegada.Desc_Where = "FEC_BAJA IS NULL"
        Me.dtfOfiLlegada.Desc_WhereObligatoria = Nothing
        Me.dtfOfiLlegada.Descripcion = "Oficina Llegada"
        Me.dtfOfiLlegada.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfOfiLlegada.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfOfiLlegada.ExtraSQL = ""
        Me.dtfOfiLlegada.FocoEnAgregar = False
        Me.dtfOfiLlegada.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfOfiLlegada.Formulario = Nothing
        Me.dtfOfiLlegada.Label_Space = 100
        Me.dtfOfiLlegada.Length_Data = 32767
        Me.dtfOfiLlegada.Location = New System.Drawing.Point(354, 0)
        Me.dtfOfiLlegada.Lupa = Nothing
        Me.dtfOfiLlegada.Max_Value = 0.0R
        Me.dtfOfiLlegada.MensajeIncorrectoCustom = Nothing
        Me.dtfOfiLlegada.Name = "dtfOfiLlegada"
        Me.dtfOfiLlegada.Null_on_Empty = True
        Me.dtfOfiLlegada.OpenForm = Nothing
        Me.dtfOfiLlegada.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfOfiLlegada.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfOfiLlegada.Query_on_Text_Changed = True
        Me.dtfOfiLlegada.ReadOnly_Data = False
        Me.dtfOfiLlegada.ReQuery = False
        Me.dtfOfiLlegada.ShowButton = True
        Me.dtfOfiLlegada.Size = New System.Drawing.Size(152, 26)
        Me.dtfOfiLlegada.TabIndex = 5
        Me.dtfOfiLlegada.Text_Data = ""
        Me.dtfOfiLlegada.Text_Data_Desc = ""
        Me.dtfOfiLlegada.Text_Width = 25
        Me.dtfOfiLlegada.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfOfiLlegada.TopPadding = 0
        Me.dtfOfiLlegada.Upper_Case = False
        Me.dtfOfiLlegada.Validate_on_lost_focus = True
        '
        'pnlSpace14
        '
        Me.pnlSpace14.Auto_Size = False
        Me.pnlSpace14.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace14.ChangeDock = True
        Me.pnlSpace14.Control_Resize = False
        Me.pnlSpace14.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace14.isSpace = True
        Me.pnlSpace14.Location = New System.Drawing.Point(348, 0)
        Me.pnlSpace14.Name = "pnlSpace14"
        Me.pnlSpace14.numRows = 0
        Me.pnlSpace14.Reorder = True
        Me.pnlSpace14.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace14.TabIndex = 4
        '
        'dttHPrevista
        '
        Me.dttHPrevista.Allow_Empty = False
        Me.dttHPrevista.DataField = "HPREV_CON1"
        Me.dttHPrevista.DataTable = "C1"
        Me.dttHPrevista.Descripcion = "Hora Prevista"
        Me.dttHPrevista.Dock = System.Windows.Forms.DockStyle.Left
        Me.dttHPrevista.FocoEnAgregar = False
        Me.dttHPrevista.Location = New System.Drawing.Point(272, 0)
        Me.dttHPrevista.MensajeIncorrectoCustom = Nothing
        Me.dttHPrevista.Name = "dttHPrevista"
        Me.dttHPrevista.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dttHPrevista.ReadOnly_Data = False
        Me.dttHPrevista.Size = New System.Drawing.Size(76, 26)
        Me.dttHPrevista.TabIndex = 3
        Me.dttHPrevista.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dttHPrevista.Time = System.TimeSpan.Parse("10:59:00")
        Me.dttHPrevista.Validate_on_lost_focus = True
        '
        'pnlSpace13
        '
        Me.pnlSpace13.Auto_Size = False
        Me.pnlSpace13.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace13.ChangeDock = True
        Me.pnlSpace13.Control_Resize = False
        Me.pnlSpace13.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace13.isSpace = True
        Me.pnlSpace13.Location = New System.Drawing.Point(266, 0)
        Me.pnlSpace13.Name = "pnlSpace13"
        Me.pnlSpace13.numRows = 0
        Me.pnlSpace13.Reorder = True
        Me.pnlSpace13.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace13.TabIndex = 2
        '
        'dtdFPrevista
        '
        Me.dtdFPrevista.Allow_Empty = False
        Me.dtdFPrevista.DataField = "FPREV_CON1"
        Me.dtdFPrevista.DataTable = "C1"
        Me.dtdFPrevista.Default_Value = Nothing
        Me.dtdFPrevista.Descripcion = "Fecha Prevista"
        Me.dtdFPrevista.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtdFPrevista.FocoEnAgregar = False
        Me.dtdFPrevista.Label_Space = 95
        Me.dtdFPrevista.Location = New System.Drawing.Point(81, 0)
        Me.dtdFPrevista.Max_Value = Nothing
        Me.dtdFPrevista.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdFPrevista.MensajeIncorrectoCustom = Nothing
        Me.dtdFPrevista.Min_Value = Nothing
        Me.dtdFPrevista.MinDate = New Date(CType(0, Long))
        Me.dtdFPrevista.MinimumSize = New System.Drawing.Size(185, 26)
        Me.dtdFPrevista.Name = "dtdFPrevista"
        Me.dtdFPrevista.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdFPrevista.ReadOnly_Data = False
        Me.dtdFPrevista.Size = New System.Drawing.Size(185, 26)
        Me.dtdFPrevista.TabIndex = 1
        Me.dtdFPrevista.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdFPrevista.Validate_on_lost_focus = True
        Me.dtdFPrevista.Value_Data = New Date(2016, 6, 10, 0, 0, 0, 0)
        '
        'pnlSpace12
        '
        Me.pnlSpace12.Auto_Size = False
        Me.pnlSpace12.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace12.ChangeDock = True
        Me.pnlSpace12.Control_Resize = False
        Me.pnlSpace12.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace12.isSpace = True
        Me.pnlSpace12.Location = New System.Drawing.Point(0, 0)
        Me.pnlSpace12.Name = "pnlSpace12"
        Me.pnlSpace12.numRows = 0
        Me.pnlSpace12.Reorder = True
        Me.pnlSpace12.Size = New System.Drawing.Size(81, 26)
        Me.pnlSpace12.TabIndex = 0
        '
        'pnlDatosSalida
        '
        Me.pnlDatosSalida.Auto_Size = False
        Me.pnlDatosSalida.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlDatosSalida.ChangeDock = False
        Me.pnlDatosSalida.Control_Resize = False
        Me.pnlDatosSalida.Controls.Add(Me.dtfLugarEntrega)
        Me.pnlDatosSalida.Controls.Add(Me.pnlSpace10)
        Me.pnlDatosSalida.Controls.Add(Me.dtfUsuEntrega)
        Me.pnlDatosSalida.Controls.Add(Me.pnlSpace19)
        Me.pnlDatosSalida.Controls.Add(Me.dtfOfiSalida)
        Me.pnlDatosSalida.Controls.Add(Me.pnlSpace8)
        Me.pnlDatosSalida.Controls.Add(Me.dttHSalida)
        Me.pnlDatosSalida.Controls.Add(Me.pnlSpace7)
        Me.pnlDatosSalida.Controls.Add(Me.dtdFSalida)
        Me.pnlDatosSalida.Controls.Add(Me.pnlSpace6)
        Me.pnlDatosSalida.Controls.Add(Me.dtfDiasPrevistos)
        Me.pnlDatosSalida.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlDatosSalida.isSpace = False
        Me.pnlDatosSalida.Location = New System.Drawing.Point(3, 29)
        Me.pnlDatosSalida.Name = "pnlDatosSalida"
        Me.pnlDatosSalida.numRows = 1
        Me.pnlDatosSalida.Reorder = True
        Me.pnlDatosSalida.Size = New System.Drawing.Size(1240, 26)
        Me.pnlDatosSalida.TabIndex = 1
        '
        'dtfLugarEntrega
        '
        Me.dtfLugarEntrega.Allow_Empty = True
        Me.dtfLugarEntrega.Allow_Negative = True
        Me.dtfLugarEntrega.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfLugarEntrega.BackColor = System.Drawing.SystemColors.Control
        Me.dtfLugarEntrega.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfLugarEntrega.DataField = "LUENTRE_CON1"
        Me.dtfLugarEntrega.DataTable = "C1"
        Me.dtfLugarEntrega.Descripcion = "Lugar Entrega"
        Me.dtfLugarEntrega.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfLugarEntrega.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfLugarEntrega.FocoEnAgregar = False
        Me.dtfLugarEntrega.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfLugarEntrega.Image = Nothing
        Me.dtfLugarEntrega.Label_Space = 100
        Me.dtfLugarEntrega.Length_Data = 32767
        Me.dtfLugarEntrega.Location = New System.Drawing.Point(660, 0)
        Me.dtfLugarEntrega.Max_Value = 0.0R
        Me.dtfLugarEntrega.MensajeIncorrectoCustom = Nothing
        Me.dtfLugarEntrega.Name = "dtfLugarEntrega"
        Me.dtfLugarEntrega.Null_on_Empty = True
        Me.dtfLugarEntrega.OpenForm = Nothing
        Me.dtfLugarEntrega.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfLugarEntrega.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfLugarEntrega.ReadOnly_Data = False
        Me.dtfLugarEntrega.Show_Button = True
        Me.dtfLugarEntrega.Size = New System.Drawing.Size(580, 26)
        Me.dtfLugarEntrega.TabIndex = 10
        Me.dtfLugarEntrega.Text_Data = ""
        Me.dtfLugarEntrega.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfLugarEntrega.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfLugarEntrega.TopPadding = 0
        Me.dtfLugarEntrega.Upper_Case = False
        Me.dtfLugarEntrega.Validate_on_lost_focus = True
        '
        'pnlSpace10
        '
        Me.pnlSpace10.Auto_Size = False
        Me.pnlSpace10.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace10.ChangeDock = True
        Me.pnlSpace10.Control_Resize = False
        Me.pnlSpace10.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace10.isSpace = True
        Me.pnlSpace10.Location = New System.Drawing.Point(654, 0)
        Me.pnlSpace10.Name = "pnlSpace10"
        Me.pnlSpace10.numRows = 0
        Me.pnlSpace10.Reorder = True
        Me.pnlSpace10.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace10.TabIndex = 9
        '
        'dtfUsuEntrega
        '
        Me.dtfUsuEntrega.Allow_Empty = True
        Me.dtfUsuEntrega.Allow_Negative = True
        Me.dtfUsuEntrega.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfUsuEntrega.BackColor = System.Drawing.SystemColors.Control
        Me.dtfUsuEntrega.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfUsuEntrega.DataField = "RENTAL1_CON1"
        Me.dtfUsuEntrega.DataTable = "C1"
        Me.dtfUsuEntrega.DB = Connection11
        Me.dtfUsuEntrega.Desc_Datafield = "NOMBRE"
        Me.dtfUsuEntrega.Desc_DBPK = "CODIGO"
        Me.dtfUsuEntrega.Desc_DBTable = "USURE"
        Me.dtfUsuEntrega.Desc_Where = "FBAJA IS NULL"
        Me.dtfUsuEntrega.Desc_WhereObligatoria = Nothing
        Me.dtfUsuEntrega.Descripcion = "Usu Entrega"
        Me.dtfUsuEntrega.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfUsuEntrega.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfUsuEntrega.ExtraSQL = ""
        Me.dtfUsuEntrega.FocoEnAgregar = False
        Me.dtfUsuEntrega.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfUsuEntrega.Formulario = Nothing
        Me.dtfUsuEntrega.Label_Space = 75
        Me.dtfUsuEntrega.Length_Data = 32767
        Me.dtfUsuEntrega.Location = New System.Drawing.Point(512, 0)
        Me.dtfUsuEntrega.Lupa = Nothing
        Me.dtfUsuEntrega.Max_Value = 0.0R
        Me.dtfUsuEntrega.MensajeIncorrectoCustom = Nothing
        Me.dtfUsuEntrega.Name = "dtfUsuEntrega"
        Me.dtfUsuEntrega.Null_on_Empty = True
        Me.dtfUsuEntrega.OpenForm = Nothing
        Me.dtfUsuEntrega.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfUsuEntrega.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfUsuEntrega.Query_on_Text_Changed = True
        Me.dtfUsuEntrega.ReadOnly_Data = False
        Me.dtfUsuEntrega.ReQuery = False
        Me.dtfUsuEntrega.ShowButton = True
        Me.dtfUsuEntrega.Size = New System.Drawing.Size(142, 26)
        Me.dtfUsuEntrega.TabIndex = 8
        Me.dtfUsuEntrega.Text_Data = ""
        Me.dtfUsuEntrega.Text_Data_Desc = ""
        Me.dtfUsuEntrega.Text_Width = 40
        Me.dtfUsuEntrega.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfUsuEntrega.TopPadding = 0
        Me.dtfUsuEntrega.Upper_Case = False
        Me.dtfUsuEntrega.Validate_on_lost_focus = True
        '
        'pnlSpace19
        '
        Me.pnlSpace19.Auto_Size = False
        Me.pnlSpace19.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace19.ChangeDock = True
        Me.pnlSpace19.Control_Resize = False
        Me.pnlSpace19.Controls.Add(Me.pnlSpace9)
        Me.pnlSpace19.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace19.isSpace = True
        Me.pnlSpace19.Location = New System.Drawing.Point(506, 0)
        Me.pnlSpace19.Name = "pnlSpace19"
        Me.pnlSpace19.numRows = 0
        Me.pnlSpace19.Reorder = True
        Me.pnlSpace19.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace19.TabIndex = 7
        '
        'pnlSpace9
        '
        Me.pnlSpace9.Auto_Size = False
        Me.pnlSpace9.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace9.ChangeDock = True
        Me.pnlSpace9.Control_Resize = False
        Me.pnlSpace9.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace9.isSpace = True
        Me.pnlSpace9.Location = New System.Drawing.Point(0, 0)
        Me.pnlSpace9.Name = "pnlSpace9"
        Me.pnlSpace9.numRows = 0
        Me.pnlSpace9.Reorder = True
        Me.pnlSpace9.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace9.TabIndex = 0
        '
        'dtfOfiSalida
        '
        Me.dtfOfiSalida.Allow_Empty = True
        Me.dtfOfiSalida.Allow_Negative = True
        Me.dtfOfiSalida.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfOfiSalida.BackColor = System.Drawing.SystemColors.Control
        Me.dtfOfiSalida.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfOfiSalida.DataField = "OFISALIDA_CON1"
        Me.dtfOfiSalida.DataTable = "C1"
        Me.dtfOfiSalida.DB = Connection12
        Me.dtfOfiSalida.Desc_Datafield = "NOMBRE"
        Me.dtfOfiSalida.Desc_DBPK = "CODIGO"
        Me.dtfOfiSalida.Desc_DBTable = "OFICINAS"
        Me.dtfOfiSalida.Desc_Where = "FEC_BAJA IS NULL"
        Me.dtfOfiSalida.Desc_WhereObligatoria = Nothing
        Me.dtfOfiSalida.Descripcion = "Oficina Salida"
        Me.dtfOfiSalida.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfOfiSalida.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfOfiSalida.ExtraSQL = ""
        Me.dtfOfiSalida.FocoEnAgregar = False
        Me.dtfOfiSalida.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfOfiSalida.Formulario = Nothing
        Me.dtfOfiSalida.Label_Space = 100
        Me.dtfOfiSalida.Length_Data = 32767
        Me.dtfOfiSalida.Location = New System.Drawing.Point(354, 0)
        Me.dtfOfiSalida.Lupa = Nothing
        Me.dtfOfiSalida.Max_Value = 0.0R
        Me.dtfOfiSalida.MensajeIncorrectoCustom = Nothing
        Me.dtfOfiSalida.Name = "dtfOfiSalida"
        Me.dtfOfiSalida.Null_on_Empty = True
        Me.dtfOfiSalida.OpenForm = Nothing
        Me.dtfOfiSalida.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfOfiSalida.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfOfiSalida.Query_on_Text_Changed = True
        Me.dtfOfiSalida.ReadOnly_Data = False
        Me.dtfOfiSalida.ReQuery = False
        Me.dtfOfiSalida.ShowButton = True
        Me.dtfOfiSalida.Size = New System.Drawing.Size(152, 26)
        Me.dtfOfiSalida.TabIndex = 6
        Me.dtfOfiSalida.Text_Data = ""
        Me.dtfOfiSalida.Text_Data_Desc = ""
        Me.dtfOfiSalida.Text_Width = 25
        Me.dtfOfiSalida.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfOfiSalida.TopPadding = 0
        Me.dtfOfiSalida.Upper_Case = False
        Me.dtfOfiSalida.Validate_on_lost_focus = True
        '
        'pnlSpace8
        '
        Me.pnlSpace8.Auto_Size = False
        Me.pnlSpace8.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace8.ChangeDock = True
        Me.pnlSpace8.Control_Resize = False
        Me.pnlSpace8.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace8.isSpace = True
        Me.pnlSpace8.Location = New System.Drawing.Point(348, 0)
        Me.pnlSpace8.Name = "pnlSpace8"
        Me.pnlSpace8.numRows = 0
        Me.pnlSpace8.Reorder = True
        Me.pnlSpace8.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace8.TabIndex = 5
        '
        'dttHSalida
        '
        Me.dttHSalida.Allow_Empty = False
        Me.dttHSalida.DataField = "HSALIDA_CON1"
        Me.dttHSalida.DataTable = "C1"
        Me.dttHSalida.Descripcion = "Hora de Salida"
        Me.dttHSalida.Dock = System.Windows.Forms.DockStyle.Left
        Me.dttHSalida.FocoEnAgregar = False
        Me.dttHSalida.Location = New System.Drawing.Point(272, 0)
        Me.dttHSalida.MensajeIncorrectoCustom = Nothing
        Me.dttHSalida.Name = "dttHSalida"
        Me.dttHSalida.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dttHSalida.ReadOnly_Data = False
        Me.dttHSalida.Size = New System.Drawing.Size(76, 26)
        Me.dttHSalida.TabIndex = 4
        Me.dttHSalida.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dttHSalida.Time = System.TimeSpan.Parse("10:59:00")
        Me.dttHSalida.Validate_on_lost_focus = True
        '
        'pnlSpace7
        '
        Me.pnlSpace7.Auto_Size = False
        Me.pnlSpace7.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace7.ChangeDock = True
        Me.pnlSpace7.Control_Resize = False
        Me.pnlSpace7.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace7.isSpace = True
        Me.pnlSpace7.Location = New System.Drawing.Point(266, 0)
        Me.pnlSpace7.Name = "pnlSpace7"
        Me.pnlSpace7.numRows = 0
        Me.pnlSpace7.Reorder = True
        Me.pnlSpace7.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace7.TabIndex = 3
        '
        'dtdFSalida
        '
        Me.dtdFSalida.Allow_Empty = False
        Me.dtdFSalida.DataField = "FSALIDA_CON1"
        Me.dtdFSalida.DataTable = "C1"
        Me.dtdFSalida.Default_Value = Nothing
        Me.dtdFSalida.Descripcion = "Fecha de Salida"
        Me.dtdFSalida.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtdFSalida.FocoEnAgregar = False
        Me.dtdFSalida.Label_Space = 95
        Me.dtdFSalida.Location = New System.Drawing.Point(81, 0)
        Me.dtdFSalida.Max_Value = Nothing
        Me.dtdFSalida.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdFSalida.MensajeIncorrectoCustom = Nothing
        Me.dtdFSalida.Min_Value = Nothing
        Me.dtdFSalida.MinDate = New Date(CType(0, Long))
        Me.dtdFSalida.MinimumSize = New System.Drawing.Size(185, 26)
        Me.dtdFSalida.Name = "dtdFSalida"
        Me.dtdFSalida.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdFSalida.ReadOnly_Data = False
        Me.dtdFSalida.Size = New System.Drawing.Size(185, 26)
        Me.dtdFSalida.TabIndex = 2
        Me.dtdFSalida.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdFSalida.Validate_on_lost_focus = True
        Me.dtdFSalida.Value_Data = New Date(2016, 6, 10, 0, 0, 0, 0)
        '
        'pnlSpace6
        '
        Me.pnlSpace6.Auto_Size = False
        Me.pnlSpace6.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace6.ChangeDock = True
        Me.pnlSpace6.Control_Resize = False
        Me.pnlSpace6.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace6.isSpace = True
        Me.pnlSpace6.Location = New System.Drawing.Point(75, 0)
        Me.pnlSpace6.Name = "pnlSpace6"
        Me.pnlSpace6.numRows = 0
        Me.pnlSpace6.Reorder = True
        Me.pnlSpace6.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace6.TabIndex = 1
        '
        'dtfDiasPrevistos
        '
        Me.dtfDiasPrevistos.Allow_Empty = False
        Me.dtfDiasPrevistos.Allow_Negative = False
        Me.dtfDiasPrevistos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfDiasPrevistos.BackColor = System.Drawing.SystemColors.Control
        Me.dtfDiasPrevistos.Data_Allowed = CustomControls.Datafield.List_Data.nInteger
        Me.dtfDiasPrevistos.DataField = "DIAS_CON1"
        Me.dtfDiasPrevistos.DataTable = "C1"
        Me.dtfDiasPrevistos.Descripcion = "Dias"
        Me.dtfDiasPrevistos.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfDiasPrevistos.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfDiasPrevistos.FocoEnAgregar = False
        Me.dtfDiasPrevistos.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfDiasPrevistos.Image = Nothing
        Me.dtfDiasPrevistos.Label_Space = 40
        Me.dtfDiasPrevistos.Length_Data = 32767
        Me.dtfDiasPrevistos.Location = New System.Drawing.Point(0, 0)
        Me.dtfDiasPrevistos.Max_Value = 0.0R
        Me.dtfDiasPrevistos.MensajeIncorrectoCustom = Nothing
        Me.dtfDiasPrevistos.Name = "dtfDiasPrevistos"
        Me.dtfDiasPrevistos.Null_on_Empty = True
        Me.dtfDiasPrevistos.OpenForm = Nothing
        Me.dtfDiasPrevistos.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfDiasPrevistos.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfDiasPrevistos.ReadOnly_Data = False
        Me.dtfDiasPrevistos.Show_Button = False
        Me.dtfDiasPrevistos.Size = New System.Drawing.Size(75, 26)
        Me.dtfDiasPrevistos.TabIndex = 0
        Me.dtfDiasPrevistos.Text_Data = ""
        Me.dtfDiasPrevistos.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfDiasPrevistos.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfDiasPrevistos.TopPadding = 0
        Me.dtfDiasPrevistos.Upper_Case = False
        Me.dtfDiasPrevistos.Validate_on_lost_focus = True
        '
        'pnlCabezeraSup
        '
        Me.pnlCabezeraSup.Auto_Size = False
        Me.pnlCabezeraSup.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlCabezeraSup.ChangeDock = False
        Me.pnlCabezeraSup.Control_Resize = False
        Me.pnlCabezeraSup.Controls.Add(Me.dtfEmpresaOficina)
        Me.pnlCabezeraSup.Controls.Add(Me.pnlSpace4)
        Me.pnlCabezeraSup.Controls.Add(Me.dtdFecha)
        Me.pnlCabezeraSup.Controls.Add(Me.pnlSpace2)
        Me.pnlCabezeraSup.Controls.Add(Me.dtfReserva)
        Me.pnlCabezeraSup.Controls.Add(Me.pnlSpace1)
        Me.pnlCabezeraSup.Controls.Add(Me.dtfCodigo)
        Me.pnlCabezeraSup.Controls.Add(Me.pnlSpace5)
        Me.pnlCabezeraSup.Controls.Add(Me.dttHora)
        Me.pnlCabezeraSup.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCabezeraSup.isSpace = False
        Me.pnlCabezeraSup.Location = New System.Drawing.Point(3, 3)
        Me.pnlCabezeraSup.Name = "pnlCabezeraSup"
        Me.pnlCabezeraSup.numRows = 1
        Me.pnlCabezeraSup.Reorder = True
        Me.pnlCabezeraSup.Size = New System.Drawing.Size(1240, 26)
        Me.pnlCabezeraSup.TabIndex = 0
        '
        'dtfEmpresaOficina
        '
        Me.dtfEmpresaOficina.DataField_Empresa = "SUBLICEN_CON1"
        Me.dtfEmpresaOficina.DataField_Oficina = "OFICINA_CON1"
        Me.dtfEmpresaOficina.DataTable_Empresa = "C1"
        Me.dtfEmpresaOficina.DataTable_Oficina = "C1"
        Me.dtfEmpresaOficina.Descripcion = Nothing
        Me.dtfEmpresaOficina.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfEmpresaOficina.FocoEnAgregar = False
        Me.dtfEmpresaOficina.Location = New System.Drawing.Point(354, 0)
        Me.dtfEmpresaOficina.Lupa = Nothing
        Me.dtfEmpresaOficina.MensajeIncorrectoCustom = Nothing
        Me.dtfEmpresaOficina.Name = "dtfEmpresaOficina"
        Me.dtfEmpresaOficina.OficinaReadOnly = False
        Me.dtfEmpresaOficina.ShowLupa = True
        Me.dtfEmpresaOficina.Size = New System.Drawing.Size(658, 26)
        Me.dtfEmpresaOficina.Size_Empresa = 85
        Me.dtfEmpresaOficina.TabIndex = 4
        Me.dtfEmpresaOficina.Text_Empresa = ""
        Me.dtfEmpresaOficina.Text_Oficina = ""
        '
        'pnlSpace4
        '
        Me.pnlSpace4.Auto_Size = False
        Me.pnlSpace4.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace4.ChangeDock = True
        Me.pnlSpace4.Control_Resize = False
        Me.pnlSpace4.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSpace4.isSpace = True
        Me.pnlSpace4.Location = New System.Drawing.Point(1012, 0)
        Me.pnlSpace4.Name = "pnlSpace4"
        Me.pnlSpace4.numRows = 0
        Me.pnlSpace4.Reorder = True
        Me.pnlSpace4.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace4.TabIndex = 5
        '
        'dtdFecha
        '
        Me.dtdFecha.Allow_Empty = True
        Me.dtdFecha.DataField = "FECHA_CON1"
        Me.dtdFecha.DataTable = "C1"
        Me.dtdFecha.Default_Value = New Date(2015, 8, 28, 0, 0, 0, 0)
        Me.dtdFecha.Descripcion = "Fecha"
        Me.dtdFecha.Dock = System.Windows.Forms.DockStyle.Right
        Me.dtdFecha.FocoEnAgregar = False
        Me.dtdFecha.Label_Space = 50
        Me.dtdFecha.Location = New System.Drawing.Point(1018, 0)
        Me.dtdFecha.Max_Value = Nothing
        Me.dtdFecha.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdFecha.MensajeIncorrectoCustom = Nothing
        Me.dtdFecha.Min_Value = Nothing
        Me.dtdFecha.MinDate = New Date(CType(0, Long))
        Me.dtdFecha.MinimumSize = New System.Drawing.Size(140, 26)
        Me.dtdFecha.Name = "dtdFecha"
        Me.dtdFecha.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdFecha.ReadOnly_Data = False
        Me.dtdFecha.Size = New System.Drawing.Size(140, 26)
        Me.dtdFecha.TabIndex = 6
        Me.dtdFecha.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdFecha.Validate_on_lost_focus = True
        Me.dtdFecha.Value_Data = New Date(2015, 8, 28, 0, 0, 0, 0)
        '
        'pnlSpace2
        '
        Me.pnlSpace2.Auto_Size = False
        Me.pnlSpace2.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace2.ChangeDock = True
        Me.pnlSpace2.Control_Resize = False
        Me.pnlSpace2.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace2.isSpace = True
        Me.pnlSpace2.Location = New System.Drawing.Point(348, 0)
        Me.pnlSpace2.Name = "pnlSpace2"
        Me.pnlSpace2.numRows = 0
        Me.pnlSpace2.Reorder = True
        Me.pnlSpace2.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace2.TabIndex = 3
        '
        'dtfReserva
        '
        Me.dtfReserva.Allow_Empty = True
        Me.dtfReserva.Allow_Negative = True
        Me.dtfReserva.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfReserva.BackColor = System.Drawing.SystemColors.Control
        Me.dtfReserva.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfReserva.DataField = "RESERVA_CON1"
        Me.dtfReserva.DataTable = "C1"
        Me.dtfReserva.DB = Connection13
        Me.dtfReserva.Desc_Datafield = "NUMERO_RES"
        Me.dtfReserva.Desc_DBPK = "NUMERO_RES"
        Me.dtfReserva.Desc_DBTable = "RESERVAS1"
        Me.dtfReserva.Desc_Where = Nothing
        Me.dtfReserva.Desc_WhereObligatoria = Nothing
        Me.dtfReserva.Descripcion = "Reserva"
        Me.dtfReserva.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfReserva.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfReserva.ExtraSQL = ""
        Me.dtfReserva.FocoEnAgregar = True
        Me.dtfReserva.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfReserva.Formulario = Nothing
        Me.dtfReserva.Label_Space = 75
        Me.dtfReserva.Length_Data = 32767
        Me.dtfReserva.Location = New System.Drawing.Point(166, 0)
        Me.dtfReserva.Lupa = Nothing
        Me.dtfReserva.Max_Value = 0.0R
        Me.dtfReserva.MensajeIncorrectoCustom = Nothing
        Me.dtfReserva.Name = "dtfReserva"
        Me.dtfReserva.Null_on_Empty = True
        Me.dtfReserva.OpenForm = Nothing
        Me.dtfReserva.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfReserva.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfReserva.Query_on_Text_Changed = True
        Me.dtfReserva.ReadOnly_Data = True
        Me.dtfReserva.ReQuery = False
        Me.dtfReserva.ShowButton = True
        Me.dtfReserva.Size = New System.Drawing.Size(182, 26)
        Me.dtfReserva.TabIndex = 2
        Me.dtfReserva.TabStop = False
        Me.dtfReserva.Text_Data = ""
        Me.dtfReserva.Text_Data_Desc = ""
        Me.dtfReserva.Text_Width = 80
        Me.dtfReserva.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfReserva.TopPadding = 0
        Me.dtfReserva.Upper_Case = False
        Me.dtfReserva.Validate_on_lost_focus = True
        '
        'pnlSpace1
        '
        Me.pnlSpace1.Auto_Size = False
        Me.pnlSpace1.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace1.ChangeDock = True
        Me.pnlSpace1.Control_Resize = False
        Me.pnlSpace1.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace1.isSpace = True
        Me.pnlSpace1.Location = New System.Drawing.Point(160, 0)
        Me.pnlSpace1.Name = "pnlSpace1"
        Me.pnlSpace1.numRows = 0
        Me.pnlSpace1.Reorder = True
        Me.pnlSpace1.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace1.TabIndex = 1
        '
        'dtfCodigo
        '
        Me.dtfCodigo.Allow_Empty = False
        Me.dtfCodigo.Allow_Negative = True
        Me.dtfCodigo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfCodigo.BackColor = System.Drawing.SystemColors.Control
        Me.dtfCodigo.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfCodigo.DataField = "NUMERO"
        Me.dtfCodigo.DataTable = "C1"
        Me.dtfCodigo.Descripcion = "Contrato"
        Me.dtfCodigo.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfCodigo.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfCodigo.FocoEnAgregar = False
        Me.dtfCodigo.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfCodigo.Image = Nothing
        Me.dtfCodigo.Label_Space = 75
        Me.dtfCodigo.Length_Data = 32767
        Me.dtfCodigo.Location = New System.Drawing.Point(0, 0)
        Me.dtfCodigo.Max_Value = 0.0R
        Me.dtfCodigo.MensajeIncorrectoCustom = Nothing
        Me.dtfCodigo.Name = "dtfCodigo"
        Me.dtfCodigo.Null_on_Empty = True
        Me.dtfCodigo.OpenForm = Nothing
        Me.dtfCodigo.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfCodigo.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfCodigo.ReadOnly_Data = True
        Me.dtfCodigo.Show_Button = False
        Me.dtfCodigo.Size = New System.Drawing.Size(160, 26)
        Me.dtfCodigo.TabIndex = 0
        Me.dtfCodigo.TabStop = False
        Me.dtfCodigo.Text_Data = ""
        Me.dtfCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfCodigo.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfCodigo.TopPadding = 0
        Me.dtfCodigo.Upper_Case = False
        Me.dtfCodigo.Validate_on_lost_focus = True
        '
        'pnlSpace5
        '
        Me.pnlSpace5.Auto_Size = False
        Me.pnlSpace5.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace5.ChangeDock = True
        Me.pnlSpace5.Control_Resize = False
        Me.pnlSpace5.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSpace5.isSpace = True
        Me.pnlSpace5.Location = New System.Drawing.Point(1158, 0)
        Me.pnlSpace5.Name = "pnlSpace5"
        Me.pnlSpace5.numRows = 0
        Me.pnlSpace5.Reorder = True
        Me.pnlSpace5.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace5.TabIndex = 7
        '
        'dttHora
        '
        Me.dttHora.Allow_Empty = True
        Me.dttHora.DataField = "HORA_CON1"
        Me.dttHora.DataTable = "C1"
        Me.dttHora.Descripcion = "Hora"
        Me.dttHora.Dock = System.Windows.Forms.DockStyle.Right
        Me.dttHora.FocoEnAgregar = False
        Me.dttHora.Location = New System.Drawing.Point(1164, 0)
        Me.dttHora.MensajeIncorrectoCustom = Nothing
        Me.dttHora.Name = "dttHora"
        Me.dttHora.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dttHora.ReadOnly_Data = False
        Me.dttHora.Size = New System.Drawing.Size(76, 26)
        Me.dttHora.TabIndex = 8
        Me.dttHora.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dttHora.Time = System.TimeSpan.Parse("10:59:00")
        Me.dttHora.Validate_on_lost_focus = True
        '
        'pvpOtrosDatos
        '
        Me.pvpOtrosDatos.Controls.Add(Me.pnlOtrosDatosDer)
        Me.pvpOtrosDatos.Controls.Add(Me.pnlOtrosDatosIzq)
        Me.pvpOtrosDatos.Controls.Add(Me.pnlCabeceraOtros)
        Me.pvpOtrosDatos.ItemSize = New System.Drawing.SizeF(83.0!, 23.0!)
        Me.pvpOtrosDatos.Location = New System.Drawing.Point(129, 5)
        Me.pvpOtrosDatos.Name = "pvpOtrosDatos"
        Me.pvpOtrosDatos.PanelCabezeraContainer = Me.pnlCabeceraOtros
        Me.pvpOtrosDatos.Size = New System.Drawing.Size(1138, 559)
        Me.pvpOtrosDatos.Text = "Otros Datos"
        '
        'pnlOtrosDatosDer
        '
        Me.pnlOtrosDatosDer.Auto_Size = False
        Me.pnlOtrosDatosDer.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlOtrosDatosDer.ChangeDock = True
        Me.pnlOtrosDatosDer.Control_Resize = False
        Me.pnlOtrosDatosDer.Controls.Add(Me.dtfDanos)
        Me.pnlOtrosDatosDer.Controls.Add(Me.dtaTrayecto)
        Me.pnlOtrosDatosDer.Controls.Add(Me.dtaDescripción)
        Me.pnlOtrosDatosDer.Controls.Add(Me.dtaObservaciones)
        Me.pnlOtrosDatosDer.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlOtrosDatosDer.isSpace = False
        Me.pnlOtrosDatosDer.Location = New System.Drawing.Point(568, 78)
        Me.pnlOtrosDatosDer.Name = "pnlOtrosDatosDer"
        Me.pnlOtrosDatosDer.numRows = 0
        Me.pnlOtrosDatosDer.Padding = New System.Windows.Forms.Padding(3)
        Me.pnlOtrosDatosDer.Reorder = True
        Me.pnlOtrosDatosDer.Size = New System.Drawing.Size(568, 481)
        Me.pnlOtrosDatosDer.TabIndex = 2
        '
        'dtfDanos
        '
        Me.dtfDanos.Allow_Empty = True
        Me.dtfDanos.Allow_Negative = True
        Me.dtfDanos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfDanos.BackColor = System.Drawing.SystemColors.Control
        Me.dtfDanos.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfDanos.DataField = "DANOS_CON1"
        Me.dtfDanos.DataTable = "C1"
        Me.dtfDanos.Descripcion = "Daños"
        Me.dtfDanos.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfDanos.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfDanos.FocoEnAgregar = False
        Me.dtfDanos.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfDanos.Image = Nothing
        Me.dtfDanos.Label_Space = 50
        Me.dtfDanos.Length_Data = 32767
        Me.dtfDanos.Location = New System.Drawing.Point(3, 341)
        Me.dtfDanos.Max_Value = 0.0R
        Me.dtfDanos.MensajeIncorrectoCustom = Nothing
        Me.dtfDanos.Name = "dtfDanos"
        Me.dtfDanos.Null_on_Empty = True
        Me.dtfDanos.OpenForm = Nothing
        Me.dtfDanos.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfDanos.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfDanos.ReadOnly_Data = False
        Me.dtfDanos.Show_Button = True
        Me.dtfDanos.Size = New System.Drawing.Size(562, 26)
        Me.dtfDanos.TabIndex = 3
        Me.dtfDanos.Text_Data = ""
        Me.dtfDanos.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfDanos.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfDanos.TopPadding = 0
        Me.dtfDanos.Upper_Case = False
        Me.dtfDanos.Validate_on_lost_focus = True
        '
        'dtaTrayecto
        '
        Me.dtaTrayecto.Allow_Empty = True
        Me.dtaTrayecto.Allow_Negative = True
        Me.dtaTrayecto.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtaTrayecto.BackColor = System.Drawing.SystemColors.Control
        Me.dtaTrayecto.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtaTrayecto.DataField = "NOTAS_CON1"
        Me.dtaTrayecto.DataTable = "C1"
        Me.dtaTrayecto.Descripcion = "Trayecto"
        Me.dtaTrayecto.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtaTrayecto.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtaTrayecto.FocoEnAgregar = False
        Me.dtaTrayecto.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtaTrayecto.Length_Data = 32767
        Me.dtaTrayecto.Location = New System.Drawing.Point(3, 237)
        Me.dtaTrayecto.Max_Value = 0.0R
        Me.dtaTrayecto.MensajeIncorrectoCustom = Nothing
        Me.dtaTrayecto.Name = "dtaTrayecto"
        Me.dtaTrayecto.Null_on_Empty = True
        Me.dtaTrayecto.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtaTrayecto.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtaTrayecto.ReadOnly_Data = False
        Me.dtaTrayecto.Size = New System.Drawing.Size(562, 104)
        Me.dtaTrayecto.TabIndex = 2
        Me.dtaTrayecto.Text_Data = ""
        Me.dtaTrayecto.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtaTrayecto.TopPadding = 0
        Me.dtaTrayecto.Upper_Case = False
        Me.dtaTrayecto.Validate_on_lost_focus = True
        '
        'dtaDescripción
        '
        Me.dtaDescripción.Allow_Empty = True
        Me.dtaDescripción.Allow_Negative = True
        Me.dtaDescripción.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtaDescripción.BackColor = System.Drawing.SystemColors.Control
        Me.dtaDescripción.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtaDescripción.DataField = "DESCSERV_CON1"
        Me.dtaDescripción.DataTable = "C1"
        Me.dtaDescripción.Descripcion = "Descripción"
        Me.dtaDescripción.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtaDescripción.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtaDescripción.FocoEnAgregar = False
        Me.dtaDescripción.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtaDescripción.Length_Data = 32767
        Me.dtaDescripción.Location = New System.Drawing.Point(3, 133)
        Me.dtaDescripción.Max_Value = 0.0R
        Me.dtaDescripción.MensajeIncorrectoCustom = Nothing
        Me.dtaDescripción.Name = "dtaDescripción"
        Me.dtaDescripción.Null_on_Empty = True
        Me.dtaDescripción.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtaDescripción.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtaDescripción.ReadOnly_Data = False
        Me.dtaDescripción.Size = New System.Drawing.Size(562, 104)
        Me.dtaDescripción.TabIndex = 1
        Me.dtaDescripción.Text_Data = ""
        Me.dtaDescripción.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtaDescripción.TopPadding = 0
        Me.dtaDescripción.Upper_Case = False
        Me.dtaDescripción.Validate_on_lost_focus = True
        '
        'dtaObservaciones
        '
        Me.dtaObservaciones.Allow_Empty = True
        Me.dtaObservaciones.Allow_Negative = True
        Me.dtaObservaciones.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtaObservaciones.BackColor = System.Drawing.SystemColors.Control
        Me.dtaObservaciones.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtaObservaciones.DataField = "OBS1_CON2"
        Me.dtaObservaciones.DataTable = "C2"
        Me.dtaObservaciones.Descripcion = "Observaciones"
        Me.dtaObservaciones.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtaObservaciones.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtaObservaciones.FocoEnAgregar = False
        Me.dtaObservaciones.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtaObservaciones.Length_Data = 32767
        Me.dtaObservaciones.Location = New System.Drawing.Point(3, 3)
        Me.dtaObservaciones.Max_Value = 0.0R
        Me.dtaObservaciones.MensajeIncorrectoCustom = Nothing
        Me.dtaObservaciones.Name = "dtaObservaciones"
        Me.dtaObservaciones.Null_on_Empty = True
        Me.dtaObservaciones.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtaObservaciones.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtaObservaciones.ReadOnly_Data = False
        Me.dtaObservaciones.Size = New System.Drawing.Size(562, 130)
        Me.dtaObservaciones.TabIndex = 0
        Me.dtaObservaciones.Text_Data = ""
        Me.dtaObservaciones.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtaObservaciones.TopPadding = 0
        Me.dtaObservaciones.Upper_Case = False
        Me.dtaObservaciones.Validate_on_lost_focus = True
        '
        'pnlOtrosDatosIzq
        '
        Me.pnlOtrosDatosIzq.Auto_Size = False
        Me.pnlOtrosDatosIzq.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlOtrosDatosIzq.ChangeDock = True
        Me.pnlOtrosDatosIzq.Control_Resize = False
        Me.pnlOtrosDatosIzq.Controls.Add(Me.dtfMotivoImproduc)
        Me.pnlOtrosDatosIzq.Controls.Add(Me.dtfUbicacion)
        Me.pnlOtrosDatosIzq.Controls.Add(Me.dtfActiVehi)
        Me.pnlOtrosDatosIzq.Controls.Add(Me.dtfUsoAlquiler)
        Me.pnlOtrosDatosIzq.Controls.Add(Me.dtfTipoImpreso)
        Me.pnlOtrosDatosIzq.Controls.Add(Me.dtfBloqueFactur)
        Me.pnlOtrosDatosIzq.Controls.Add(Me.dtfEmpleado)
        Me.pnlOtrosDatosIzq.Controls.Add(Me.dtfIdioma)
        Me.pnlOtrosDatosIzq.Controls.Add(Me.dtfReferenciaFactura)
        Me.pnlOtrosDatosIzq.Controls.Add(Me.dtfOrigen)
        Me.pnlOtrosDatosIzq.Controls.Add(Me.dtfFcobro)
        Me.pnlOtrosDatosIzq.Controls.Add(Me.pnlOpcionesAlquiler)
        Me.pnlOtrosDatosIzq.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlOtrosDatosIzq.isSpace = False
        Me.pnlOtrosDatosIzq.Location = New System.Drawing.Point(0, 78)
        Me.pnlOtrosDatosIzq.Name = "pnlOtrosDatosIzq"
        Me.pnlOtrosDatosIzq.numRows = 0
        Me.pnlOtrosDatosIzq.Padding = New System.Windows.Forms.Padding(3)
        Me.pnlOtrosDatosIzq.Reorder = True
        Me.pnlOtrosDatosIzq.Size = New System.Drawing.Size(568, 481)
        Me.pnlOtrosDatosIzq.TabIndex = 1
        '
        'dtfMotivoImproduc
        '
        Me.dtfMotivoImproduc.Allow_Empty = True
        Me.dtfMotivoImproduc.Allow_Negative = True
        Me.dtfMotivoImproduc.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfMotivoImproduc.BackColor = System.Drawing.SystemColors.Control
        Me.dtfMotivoImproduc.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfMotivoImproduc.DataField = "MOTIVO_IMPRODUC"
        Me.dtfMotivoImproduc.DataTable = "C1"
        Me.dtfMotivoImproduc.DB = Connection14
        Me.dtfMotivoImproduc.Desc_Datafield = "NOMBRE"
        Me.dtfMotivoImproduc.Desc_DBPK = "CODIGO"
        Me.dtfMotivoImproduc.Desc_DBTable = "MOTIMPRODUC"
        Me.dtfMotivoImproduc.Desc_Where = Nothing
        Me.dtfMotivoImproduc.Desc_WhereObligatoria = Nothing
        Me.dtfMotivoImproduc.Descripcion = "Motivo Improduc."
        Me.dtfMotivoImproduc.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfMotivoImproduc.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfMotivoImproduc.ExtraSQL = ""
        Me.dtfMotivoImproduc.FocoEnAgregar = False
        Me.dtfMotivoImproduc.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfMotivoImproduc.Formulario = Nothing
        Me.dtfMotivoImproduc.Label_Space = 100
        Me.dtfMotivoImproduc.Length_Data = 32767
        Me.dtfMotivoImproduc.Location = New System.Drawing.Point(3, 341)
        Me.dtfMotivoImproduc.Lupa = Nothing
        Me.dtfMotivoImproduc.Max_Value = 0.0R
        Me.dtfMotivoImproduc.MensajeIncorrectoCustom = Nothing
        Me.dtfMotivoImproduc.Name = "dtfMotivoImproduc"
        Me.dtfMotivoImproduc.Null_on_Empty = True
        Me.dtfMotivoImproduc.OpenForm = Nothing
        Me.dtfMotivoImproduc.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfMotivoImproduc.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfMotivoImproduc.Query_on_Text_Changed = True
        Me.dtfMotivoImproduc.ReadOnly_Data = False
        Me.dtfMotivoImproduc.ReQuery = False
        Me.dtfMotivoImproduc.ShowButton = True
        Me.dtfMotivoImproduc.Size = New System.Drawing.Size(562, 26)
        Me.dtfMotivoImproduc.TabIndex = 11
        Me.dtfMotivoImproduc.Text_Data = ""
        Me.dtfMotivoImproduc.Text_Data_Desc = ""
        Me.dtfMotivoImproduc.Text_Width = 58
        Me.dtfMotivoImproduc.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfMotivoImproduc.TopPadding = 0
        Me.dtfMotivoImproduc.Upper_Case = False
        Me.dtfMotivoImproduc.Validate_on_lost_focus = True
        '
        'dtfUbicacion
        '
        Me.dtfUbicacion.Allow_Empty = True
        Me.dtfUbicacion.Allow_Negative = True
        Me.dtfUbicacion.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfUbicacion.BackColor = System.Drawing.SystemColors.Control
        Me.dtfUbicacion.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfUbicacion.DataField = "UBICACION_PROV"
        Me.dtfUbicacion.DataTable = "C1"
        Me.dtfUbicacion.DB = Connection15
        Me.dtfUbicacion.Desc_Datafield = "PROV"
        Me.dtfUbicacion.Desc_DBPK = "SIGLAS"
        Me.dtfUbicacion.Desc_DBTable = "PROVINCIA"
        Me.dtfUbicacion.Desc_Where = Nothing
        Me.dtfUbicacion.Desc_WhereObligatoria = Nothing
        Me.dtfUbicacion.Descripcion = "Ubicación"
        Me.dtfUbicacion.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfUbicacion.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfUbicacion.ExtraSQL = ""
        Me.dtfUbicacion.FocoEnAgregar = False
        Me.dtfUbicacion.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfUbicacion.Formulario = Nothing
        Me.dtfUbicacion.Label_Space = 100
        Me.dtfUbicacion.Length_Data = 32767
        Me.dtfUbicacion.Location = New System.Drawing.Point(3, 315)
        Me.dtfUbicacion.Lupa = Nothing
        Me.dtfUbicacion.Max_Value = 0.0R
        Me.dtfUbicacion.MensajeIncorrectoCustom = Nothing
        Me.dtfUbicacion.Name = "dtfUbicacion"
        Me.dtfUbicacion.Null_on_Empty = True
        Me.dtfUbicacion.OpenForm = Nothing
        Me.dtfUbicacion.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfUbicacion.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfUbicacion.Query_on_Text_Changed = True
        Me.dtfUbicacion.ReadOnly_Data = False
        Me.dtfUbicacion.ReQuery = False
        Me.dtfUbicacion.ShowButton = True
        Me.dtfUbicacion.Size = New System.Drawing.Size(562, 26)
        Me.dtfUbicacion.TabIndex = 10
        Me.dtfUbicacion.Text_Data = ""
        Me.dtfUbicacion.Text_Data_Desc = ""
        Me.dtfUbicacion.Text_Width = 58
        Me.dtfUbicacion.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfUbicacion.TopPadding = 0
        Me.dtfUbicacion.Upper_Case = False
        Me.dtfUbicacion.Validate_on_lost_focus = True
        '
        'dtfActiVehi
        '
        Me.dtfActiVehi.Allow_Empty = True
        Me.dtfActiVehi.Allow_Negative = True
        Me.dtfActiVehi.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfActiVehi.BackColor = System.Drawing.SystemColors.Control
        Me.dtfActiVehi.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfActiVehi.DataField = "ACTIVIDAD_CON1"
        Me.dtfActiVehi.DataTable = "C1"
        Me.dtfActiVehi.DB = Connection16
        Me.dtfActiVehi.Desc_Datafield = "NOMBRE"
        Me.dtfActiVehi.Desc_DBPK = "NUM_ACTIVEHI"
        Me.dtfActiVehi.Desc_DBTable = "ACTIVEHI"
        Me.dtfActiVehi.Desc_Where = Nothing
        Me.dtfActiVehi.Desc_WhereObligatoria = Nothing
        Me.dtfActiVehi.Descripcion = "Actividad Vehí."
        Me.dtfActiVehi.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfActiVehi.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfActiVehi.ExtraSQL = ""
        Me.dtfActiVehi.FocoEnAgregar = False
        Me.dtfActiVehi.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfActiVehi.Formulario = Nothing
        Me.dtfActiVehi.Label_Space = 100
        Me.dtfActiVehi.Length_Data = 32767
        Me.dtfActiVehi.Location = New System.Drawing.Point(3, 289)
        Me.dtfActiVehi.Lupa = Nothing
        Me.dtfActiVehi.Max_Value = 0.0R
        Me.dtfActiVehi.MensajeIncorrectoCustom = Nothing
        Me.dtfActiVehi.Name = "dtfActiVehi"
        Me.dtfActiVehi.Null_on_Empty = True
        Me.dtfActiVehi.OpenForm = Nothing
        Me.dtfActiVehi.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfActiVehi.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfActiVehi.Query_on_Text_Changed = True
        Me.dtfActiVehi.ReadOnly_Data = False
        Me.dtfActiVehi.ReQuery = False
        Me.dtfActiVehi.ShowButton = True
        Me.dtfActiVehi.Size = New System.Drawing.Size(562, 26)
        Me.dtfActiVehi.TabIndex = 9
        Me.dtfActiVehi.Text_Data = ""
        Me.dtfActiVehi.Text_Data_Desc = ""
        Me.dtfActiVehi.Text_Width = 58
        Me.dtfActiVehi.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfActiVehi.TopPadding = 0
        Me.dtfActiVehi.Upper_Case = False
        Me.dtfActiVehi.Validate_on_lost_focus = True
        '
        'dtfUsoAlquiler
        '
        Me.dtfUsoAlquiler.Allow_Empty = True
        Me.dtfUsoAlquiler.Allow_Negative = True
        Me.dtfUsoAlquiler.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfUsoAlquiler.BackColor = System.Drawing.SystemColors.Control
        Me.dtfUsoAlquiler.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfUsoAlquiler.DataField = "USO_ALQUILER"
        Me.dtfUsoAlquiler.DataTable = "C1"
        Me.dtfUsoAlquiler.DB = Connection17
        Me.dtfUsoAlquiler.Desc_Datafield = "NOMBRE"
        Me.dtfUsoAlquiler.Desc_DBPK = "CODIGO"
        Me.dtfUsoAlquiler.Desc_DBTable = "USO_ALQUILER"
        Me.dtfUsoAlquiler.Desc_Where = Nothing
        Me.dtfUsoAlquiler.Desc_WhereObligatoria = Nothing
        Me.dtfUsoAlquiler.Descripcion = "Uso Alquiler"
        Me.dtfUsoAlquiler.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfUsoAlquiler.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfUsoAlquiler.ExtraSQL = ""
        Me.dtfUsoAlquiler.FocoEnAgregar = False
        Me.dtfUsoAlquiler.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfUsoAlquiler.Formulario = Nothing
        Me.dtfUsoAlquiler.Label_Space = 100
        Me.dtfUsoAlquiler.Length_Data = 32767
        Me.dtfUsoAlquiler.Location = New System.Drawing.Point(3, 263)
        Me.dtfUsoAlquiler.Lupa = Nothing
        Me.dtfUsoAlquiler.Max_Value = 0.0R
        Me.dtfUsoAlquiler.MensajeIncorrectoCustom = Nothing
        Me.dtfUsoAlquiler.Name = "dtfUsoAlquiler"
        Me.dtfUsoAlquiler.Null_on_Empty = True
        Me.dtfUsoAlquiler.OpenForm = Nothing
        Me.dtfUsoAlquiler.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfUsoAlquiler.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfUsoAlquiler.Query_on_Text_Changed = True
        Me.dtfUsoAlquiler.ReadOnly_Data = False
        Me.dtfUsoAlquiler.ReQuery = False
        Me.dtfUsoAlquiler.ShowButton = True
        Me.dtfUsoAlquiler.Size = New System.Drawing.Size(562, 26)
        Me.dtfUsoAlquiler.TabIndex = 8
        Me.dtfUsoAlquiler.Text_Data = ""
        Me.dtfUsoAlquiler.Text_Data_Desc = ""
        Me.dtfUsoAlquiler.Text_Width = 58
        Me.dtfUsoAlquiler.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfUsoAlquiler.TopPadding = 0
        Me.dtfUsoAlquiler.Upper_Case = False
        Me.dtfUsoAlquiler.Validate_on_lost_focus = True
        '
        'dtfTipoImpreso
        '
        Me.dtfTipoImpreso.Allow_Empty = True
        Me.dtfTipoImpreso.Allow_Negative = True
        Me.dtfTipoImpreso.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfTipoImpreso.BackColor = System.Drawing.SystemColors.Control
        Me.dtfTipoImpreso.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfTipoImpreso.DataField = "CONTRATIPIMPR"
        Me.dtfTipoImpreso.DataTable = "C2"
        Me.dtfTipoImpreso.DB = Connection18
        Me.dtfTipoImpreso.Desc_Datafield = "NOMBRE"
        Me.dtfTipoImpreso.Desc_DBPK = "CODIGO"
        Me.dtfTipoImpreso.Desc_DBTable = "FRATIPIMPR"
        Me.dtfTipoImpreso.Desc_Where = Nothing
        Me.dtfTipoImpreso.Desc_WhereObligatoria = "ISNULL(DOCU, 0) = 0 OR DOCU = 0"
        Me.dtfTipoImpreso.Descripcion = "Tipo de Impreso"
        Me.dtfTipoImpreso.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfTipoImpreso.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfTipoImpreso.ExtraSQL = ""
        Me.dtfTipoImpreso.FocoEnAgregar = False
        Me.dtfTipoImpreso.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfTipoImpreso.Formulario = Nothing
        Me.dtfTipoImpreso.Label_Space = 100
        Me.dtfTipoImpreso.Length_Data = 32767
        Me.dtfTipoImpreso.Location = New System.Drawing.Point(3, 237)
        Me.dtfTipoImpreso.Lupa = Nothing
        Me.dtfTipoImpreso.Max_Value = 0.0R
        Me.dtfTipoImpreso.MensajeIncorrectoCustom = Nothing
        Me.dtfTipoImpreso.Name = "dtfTipoImpreso"
        Me.dtfTipoImpreso.Null_on_Empty = True
        Me.dtfTipoImpreso.OpenForm = Nothing
        Me.dtfTipoImpreso.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfTipoImpreso.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfTipoImpreso.Query_on_Text_Changed = True
        Me.dtfTipoImpreso.ReadOnly_Data = False
        Me.dtfTipoImpreso.ReQuery = False
        Me.dtfTipoImpreso.ShowButton = True
        Me.dtfTipoImpreso.Size = New System.Drawing.Size(562, 26)
        Me.dtfTipoImpreso.TabIndex = 7
        Me.dtfTipoImpreso.Text_Data = ""
        Me.dtfTipoImpreso.Text_Data_Desc = ""
        Me.dtfTipoImpreso.Text_Width = 58
        Me.dtfTipoImpreso.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfTipoImpreso.TopPadding = 0
        Me.dtfTipoImpreso.Upper_Case = False
        Me.dtfTipoImpreso.Validate_on_lost_focus = True
        '
        'dtfBloqueFactur
        '
        Me.dtfBloqueFactur.Allow_Empty = True
        Me.dtfBloqueFactur.Allow_Negative = True
        Me.dtfBloqueFactur.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfBloqueFactur.BackColor = System.Drawing.SystemColors.Control
        Me.dtfBloqueFactur.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfBloqueFactur.DataField = "BLOQUEFAC"
        Me.dtfBloqueFactur.DataTable = "C1"
        Me.dtfBloqueFactur.DB = Connection19
        Me.dtfBloqueFactur.Desc_Datafield = "NOMBRE"
        Me.dtfBloqueFactur.Desc_DBPK = "CODIGO"
        Me.dtfBloqueFactur.Desc_DBTable = "BLOQUEFAC"
        Me.dtfBloqueFactur.Desc_Where = Nothing
        Me.dtfBloqueFactur.Desc_WhereObligatoria = Nothing
        Me.dtfBloqueFactur.Descripcion = "Bloque Factur."
        Me.dtfBloqueFactur.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfBloqueFactur.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfBloqueFactur.ExtraSQL = ""
        Me.dtfBloqueFactur.FocoEnAgregar = False
        Me.dtfBloqueFactur.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfBloqueFactur.Formulario = Nothing
        Me.dtfBloqueFactur.Label_Space = 100
        Me.dtfBloqueFactur.Length_Data = 32767
        Me.dtfBloqueFactur.Location = New System.Drawing.Point(3, 211)
        Me.dtfBloqueFactur.Lupa = Nothing
        Me.dtfBloqueFactur.Max_Value = 0.0R
        Me.dtfBloqueFactur.MensajeIncorrectoCustom = Nothing
        Me.dtfBloqueFactur.Name = "dtfBloqueFactur"
        Me.dtfBloqueFactur.Null_on_Empty = True
        Me.dtfBloqueFactur.OpenForm = Nothing
        Me.dtfBloqueFactur.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfBloqueFactur.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfBloqueFactur.Query_on_Text_Changed = True
        Me.dtfBloqueFactur.ReadOnly_Data = False
        Me.dtfBloqueFactur.ReQuery = False
        Me.dtfBloqueFactur.ShowButton = True
        Me.dtfBloqueFactur.Size = New System.Drawing.Size(562, 26)
        Me.dtfBloqueFactur.TabIndex = 6
        Me.dtfBloqueFactur.Text_Data = ""
        Me.dtfBloqueFactur.Text_Data_Desc = ""
        Me.dtfBloqueFactur.Text_Width = 58
        Me.dtfBloqueFactur.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfBloqueFactur.TopPadding = 0
        Me.dtfBloqueFactur.Upper_Case = False
        Me.dtfBloqueFactur.Validate_on_lost_focus = True
        '
        'dtfEmpleado
        '
        Me.dtfEmpleado.Allow_Empty = True
        Me.dtfEmpleado.Allow_Negative = True
        Me.dtfEmpleado.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfEmpleado.BackColor = System.Drawing.SystemColors.Control
        Me.dtfEmpleado.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfEmpleado.DataField = Nothing
        Me.dtfEmpleado.DataTable = ""
        Me.dtfEmpleado.DB = Connection20
        Me.dtfEmpleado.Desc_Datafield = Nothing
        Me.dtfEmpleado.Desc_DBPK = Nothing
        Me.dtfEmpleado.Desc_DBTable = Nothing
        Me.dtfEmpleado.Desc_Where = Nothing
        Me.dtfEmpleado.Desc_WhereObligatoria = Nothing
        Me.dtfEmpleado.Descripcion = "Empleado Agen."
        Me.dtfEmpleado.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfEmpleado.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfEmpleado.ExtraSQL = ""
        Me.dtfEmpleado.FocoEnAgregar = False
        Me.dtfEmpleado.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfEmpleado.Formulario = Nothing
        Me.dtfEmpleado.Label_Space = 100
        Me.dtfEmpleado.Length_Data = 32767
        Me.dtfEmpleado.Location = New System.Drawing.Point(3, 185)
        Me.dtfEmpleado.Lupa = Nothing
        Me.dtfEmpleado.Max_Value = 0.0R
        Me.dtfEmpleado.MensajeIncorrectoCustom = Nothing
        Me.dtfEmpleado.Name = "dtfEmpleado"
        Me.dtfEmpleado.Null_on_Empty = True
        Me.dtfEmpleado.OpenForm = Nothing
        Me.dtfEmpleado.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfEmpleado.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfEmpleado.Query_on_Text_Changed = True
        Me.dtfEmpleado.ReadOnly_Data = False
        Me.dtfEmpleado.ReQuery = False
        Me.dtfEmpleado.ShowButton = True
        Me.dtfEmpleado.Size = New System.Drawing.Size(562, 26)
        Me.dtfEmpleado.TabIndex = 5
        Me.dtfEmpleado.Text_Data = ""
        Me.dtfEmpleado.Text_Data_Desc = ""
        Me.dtfEmpleado.Text_Width = 58
        Me.dtfEmpleado.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfEmpleado.TopPadding = 0
        Me.dtfEmpleado.Upper_Case = False
        Me.dtfEmpleado.Validate_on_lost_focus = True
        '
        'dtfIdioma
        '
        Me.dtfIdioma.Allow_Empty = True
        Me.dtfIdioma.Allow_Negative = True
        Me.dtfIdioma.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfIdioma.BackColor = System.Drawing.SystemColors.Control
        Me.dtfIdioma.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfIdioma.DataField = "IDIOMA"
        Me.dtfIdioma.DataTable = "C1"
        Me.dtfIdioma.DB = Connection21
        Me.dtfIdioma.Desc_Datafield = "NOMBRE"
        Me.dtfIdioma.Desc_DBPK = "CODIGO"
        Me.dtfIdioma.Desc_DBTable = "IDIOMAS"
        Me.dtfIdioma.Desc_Where = Nothing
        Me.dtfIdioma.Desc_WhereObligatoria = Nothing
        Me.dtfIdioma.Descripcion = "Idioma"
        Me.dtfIdioma.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfIdioma.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfIdioma.ExtraSQL = ""
        Me.dtfIdioma.FocoEnAgregar = False
        Me.dtfIdioma.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfIdioma.Formulario = Nothing
        Me.dtfIdioma.Label_Space = 100
        Me.dtfIdioma.Length_Data = 32767
        Me.dtfIdioma.Location = New System.Drawing.Point(3, 159)
        Me.dtfIdioma.Lupa = Nothing
        Me.dtfIdioma.Max_Value = 0.0R
        Me.dtfIdioma.MensajeIncorrectoCustom = Nothing
        Me.dtfIdioma.Name = "dtfIdioma"
        Me.dtfIdioma.Null_on_Empty = True
        Me.dtfIdioma.OpenForm = Nothing
        Me.dtfIdioma.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfIdioma.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfIdioma.Query_on_Text_Changed = True
        Me.dtfIdioma.ReadOnly_Data = False
        Me.dtfIdioma.ReQuery = False
        Me.dtfIdioma.ShowButton = True
        Me.dtfIdioma.Size = New System.Drawing.Size(562, 26)
        Me.dtfIdioma.TabIndex = 4
        Me.dtfIdioma.Text_Data = ""
        Me.dtfIdioma.Text_Data_Desc = ""
        Me.dtfIdioma.Text_Width = 58
        Me.dtfIdioma.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfIdioma.TopPadding = 0
        Me.dtfIdioma.Upper_Case = False
        Me.dtfIdioma.Validate_on_lost_focus = True
        '
        'dtfReferenciaFactura
        '
        Me.dtfReferenciaFactura.Allow_Empty = True
        Me.dtfReferenciaFactura.Allow_Negative = True
        Me.dtfReferenciaFactura.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfReferenciaFactura.BackColor = System.Drawing.SystemColors.Control
        Me.dtfReferenciaFactura.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfReferenciaFactura.DataField = "REFERE_CON1"
        Me.dtfReferenciaFactura.DataTable = "C1"
        Me.dtfReferenciaFactura.Descripcion = "Referencia Fac."
        Me.dtfReferenciaFactura.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfReferenciaFactura.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfReferenciaFactura.FocoEnAgregar = False
        Me.dtfReferenciaFactura.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfReferenciaFactura.Image = Nothing
        Me.dtfReferenciaFactura.Label_Space = 100
        Me.dtfReferenciaFactura.Length_Data = 32767
        Me.dtfReferenciaFactura.Location = New System.Drawing.Point(3, 133)
        Me.dtfReferenciaFactura.Max_Value = 0.0R
        Me.dtfReferenciaFactura.MensajeIncorrectoCustom = Nothing
        Me.dtfReferenciaFactura.Name = "dtfReferenciaFactura"
        Me.dtfReferenciaFactura.Null_on_Empty = True
        Me.dtfReferenciaFactura.OpenForm = Nothing
        Me.dtfReferenciaFactura.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfReferenciaFactura.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfReferenciaFactura.ReadOnly_Data = False
        Me.dtfReferenciaFactura.Show_Button = False
        Me.dtfReferenciaFactura.Size = New System.Drawing.Size(562, 26)
        Me.dtfReferenciaFactura.TabIndex = 3
        Me.dtfReferenciaFactura.Text_Data = ""
        Me.dtfReferenciaFactura.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfReferenciaFactura.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfReferenciaFactura.TopPadding = 0
        Me.dtfReferenciaFactura.Upper_Case = False
        Me.dtfReferenciaFactura.Validate_on_lost_focus = True
        '
        'dtfOrigen
        '
        Me.dtfOrigen.Allow_Empty = True
        Me.dtfOrigen.Allow_Negative = True
        Me.dtfOrigen.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfOrigen.BackColor = System.Drawing.SystemColors.Control
        Me.dtfOrigen.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfOrigen.DataField = "ORIGEN_CON2"
        Me.dtfOrigen.DataTable = "C2"
        Me.dtfOrigen.DB = Connection22
        Me.dtfOrigen.Desc_Datafield = "NOMBRE"
        Me.dtfOrigen.Desc_DBPK = "NUM_ORIGEN"
        Me.dtfOrigen.Desc_DBTable = "ORIGEN"
        Me.dtfOrigen.Desc_Where = Nothing
        Me.dtfOrigen.Desc_WhereObligatoria = Nothing
        Me.dtfOrigen.Descripcion = "Origen"
        Me.dtfOrigen.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfOrigen.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfOrigen.ExtraSQL = ""
        Me.dtfOrigen.FocoEnAgregar = False
        Me.dtfOrigen.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfOrigen.Formulario = Nothing
        Me.dtfOrigen.Label_Space = 100
        Me.dtfOrigen.Length_Data = 32767
        Me.dtfOrigen.Location = New System.Drawing.Point(3, 107)
        Me.dtfOrigen.Lupa = Nothing
        Me.dtfOrigen.Max_Value = 0.0R
        Me.dtfOrigen.MensajeIncorrectoCustom = Nothing
        Me.dtfOrigen.Name = "dtfOrigen"
        Me.dtfOrigen.Null_on_Empty = True
        Me.dtfOrigen.OpenForm = Nothing
        Me.dtfOrigen.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfOrigen.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfOrigen.Query_on_Text_Changed = True
        Me.dtfOrigen.ReadOnly_Data = False
        Me.dtfOrigen.ReQuery = False
        Me.dtfOrigen.ShowButton = True
        Me.dtfOrigen.Size = New System.Drawing.Size(562, 26)
        Me.dtfOrigen.TabIndex = 2
        Me.dtfOrigen.Text_Data = ""
        Me.dtfOrigen.Text_Data_Desc = ""
        Me.dtfOrigen.Text_Width = 58
        Me.dtfOrigen.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfOrigen.TopPadding = 0
        Me.dtfOrigen.Upper_Case = False
        Me.dtfOrigen.Validate_on_lost_focus = True
        '
        'dtfFcobro
        '
        Me.dtfFcobro.Allow_Empty = True
        Me.dtfFcobro.Allow_Negative = True
        Me.dtfFcobro.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfFcobro.BackColor = System.Drawing.SystemColors.Control
        Me.dtfFcobro.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfFcobro.DataField = "FCOBRO_CON1"
        Me.dtfFcobro.DataTable = "C1"
        Me.dtfFcobro.DB = Connection23
        Me.dtfFcobro.Desc_Datafield = "NOMBRE"
        Me.dtfFcobro.Desc_DBPK = "CODIGO"
        Me.dtfFcobro.Desc_DBTable = "FORMAS"
        Me.dtfFcobro.Desc_Where = Nothing
        Me.dtfFcobro.Desc_WhereObligatoria = Nothing
        Me.dtfFcobro.Descripcion = "Forma de Cobro"
        Me.dtfFcobro.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfFcobro.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfFcobro.ExtraSQL = ""
        Me.dtfFcobro.FocoEnAgregar = False
        Me.dtfFcobro.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfFcobro.Formulario = Nothing
        Me.dtfFcobro.Label_Space = 100
        Me.dtfFcobro.Length_Data = 32767
        Me.dtfFcobro.Location = New System.Drawing.Point(3, 81)
        Me.dtfFcobro.Lupa = Nothing
        Me.dtfFcobro.Max_Value = 0.0R
        Me.dtfFcobro.MensajeIncorrectoCustom = Nothing
        Me.dtfFcobro.Name = "dtfFcobro"
        Me.dtfFcobro.Null_on_Empty = True
        Me.dtfFcobro.OpenForm = Nothing
        Me.dtfFcobro.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfFcobro.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfFcobro.Query_on_Text_Changed = True
        Me.dtfFcobro.ReadOnly_Data = False
        Me.dtfFcobro.ReQuery = False
        Me.dtfFcobro.ShowButton = True
        Me.dtfFcobro.Size = New System.Drawing.Size(562, 26)
        Me.dtfFcobro.TabIndex = 1
        Me.dtfFcobro.Text_Data = ""
        Me.dtfFcobro.Text_Data_Desc = ""
        Me.dtfFcobro.Text_Width = 58
        Me.dtfFcobro.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfFcobro.TopPadding = 0
        Me.dtfFcobro.Upper_Case = False
        Me.dtfFcobro.Validate_on_lost_focus = True
        '
        'pnlOpcionesAlquiler
        '
        Me.pnlOpcionesAlquiler.Auto_Size = False
        Me.pnlOpcionesAlquiler.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlOpcionesAlquiler.ChangeDock = True
        Me.pnlOpcionesAlquiler.Control_Resize = False
        Me.pnlOpcionesAlquiler.Controls.Add(Me.pnlChecksOtrosDatos)
        Me.pnlOpcionesAlquiler.Controls.Add(Me.pnlSpace22)
        Me.pnlOpcionesAlquiler.Controls.Add(Me.rdgTipoAlquiler)
        Me.pnlOpcionesAlquiler.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlOpcionesAlquiler.isSpace = False
        Me.pnlOpcionesAlquiler.Location = New System.Drawing.Point(3, 3)
        Me.pnlOpcionesAlquiler.Name = "pnlOpcionesAlquiler"
        Me.pnlOpcionesAlquiler.numRows = 3
        Me.pnlOpcionesAlquiler.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.pnlOpcionesAlquiler.Reorder = True
        Me.pnlOpcionesAlquiler.Size = New System.Drawing.Size(562, 78)
        Me.pnlOpcionesAlquiler.TabIndex = 0
        '
        'pnlChecksOtrosDatos
        '
        Me.pnlChecksOtrosDatos.Auto_Size = False
        Me.pnlChecksOtrosDatos.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlChecksOtrosDatos.ChangeDock = True
        Me.pnlChecksOtrosDatos.Control_Resize = False
        Me.pnlChecksOtrosDatos.Controls.Add(Me.chnNoPrtImp)
        Me.pnlChecksOtrosDatos.Controls.Add(Me.chkImproductivo)
        Me.pnlChecksOtrosDatos.Controls.Add(Me.chkExentos)
        Me.pnlChecksOtrosDatos.Controls.Add(Me.chnNoPendCob)
        Me.pnlChecksOtrosDatos.Controls.Add(Me.chkVehi2000Kg)
        Me.pnlChecksOtrosDatos.Controls.Add(Me.chProlongacionAutomatica)
        Me.pnlChecksOtrosDatos.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlChecksOtrosDatos.isSpace = False
        Me.pnlChecksOtrosDatos.Location = New System.Drawing.Point(134, 0)
        Me.pnlChecksOtrosDatos.Name = "pnlChecksOtrosDatos"
        Me.pnlChecksOtrosDatos.numRows = 3
        Me.pnlChecksOtrosDatos.Reorder = True
        Me.pnlChecksOtrosDatos.Size = New System.Drawing.Size(428, 78)
        Me.pnlChecksOtrosDatos.TabIndex = 2
        '
        'chnNoPrtImp
        '
        Me.chnNoPrtImp.DataField = "NOIMPRIMIR_IMP"
        Me.chnNoPrtImp.DataTable = "C1"
        Me.chnNoPrtImp.Descripcion = "No imprimir Importes"
        Me.chnNoPrtImp.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.chnNoPrtImp.Location = New System.Drawing.Point(178, 54)
        Me.chnNoPrtImp.Name = "chnNoPrtImp"
        Me.chnNoPrtImp.Size = New System.Drawing.Size(146, 18)
        Me.chnNoPrtImp.TabIndex = 5
        Me.chnNoPrtImp.Text = "No imprimir Importes"
        Me.chnNoPrtImp.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.chnNoPrtImp.ThemeName = "Windows8"
        Me.chnNoPrtImp.Value = False
        '
        'chkImproductivo
        '
        Me.chkImproductivo.DataField = "IMPRODUC_CON1"
        Me.chkImproductivo.DataTable = "C1"
        Me.chkImproductivo.Descripcion = "Improductivo"
        Me.chkImproductivo.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.chkImproductivo.Location = New System.Drawing.Point(6, 30)
        Me.chkImproductivo.Name = "chkImproductivo"
        Me.chkImproductivo.Size = New System.Drawing.Size(99, 18)
        Me.chkImproductivo.TabIndex = 2
        Me.chkImproductivo.Text = "Improductivo"
        Me.chkImproductivo.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.chkImproductivo.ThemeName = "Windows8"
        Me.chkImproductivo.Value = False
        '
        'chkExentos
        '
        Me.chkExentos.DataField = Nothing
        Me.chkExentos.DataTable = ""
        Me.chkExentos.Descripcion = "Exentos"
        Me.chkExentos.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.chkExentos.Location = New System.Drawing.Point(6, 6)
        Me.chkExentos.Name = "chkExentos"
        Me.chkExentos.Size = New System.Drawing.Size(68, 18)
        Me.chkExentos.TabIndex = 0
        Me.chkExentos.Text = "Exentos"
        Me.chkExentos.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.chkExentos.ThemeName = "Windows8"
        Me.chkExentos.Value = False
        '
        'chnNoPendCob
        '
        Me.chnNoPendCob.DataField = "NOCONTAR_ENPENCO"
        Me.chnNoPendCob.DataTable = "C1"
        Me.chnNoPendCob.Descripcion = "No pendiente de Cobro"
        Me.chnNoPendCob.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.chnNoPendCob.Location = New System.Drawing.Point(178, 30)
        Me.chnNoPendCob.Name = "chnNoPendCob"
        Me.chnNoPendCob.Size = New System.Drawing.Size(154, 18)
        Me.chnNoPendCob.TabIndex = 3
        Me.chnNoPendCob.Text = "No pendiente de Cobro"
        Me.chnNoPendCob.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.chnNoPendCob.ThemeName = "Windows8"
        Me.chnNoPendCob.Value = False
        '
        'chkVehi2000Kg
        '
        Me.chkVehi2000Kg.DataField = "VH_ESMAS2000KG_CON1"
        Me.chkVehi2000Kg.DataTable = "C1"
        Me.chkVehi2000Kg.Descripcion = "Vehículo > 2000 Kg."
        Me.chkVehi2000Kg.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.chkVehi2000Kg.Location = New System.Drawing.Point(178, 6)
        Me.chkVehi2000Kg.Name = "chkVehi2000Kg"
        Me.chkVehi2000Kg.Size = New System.Drawing.Size(140, 18)
        Me.chkVehi2000Kg.TabIndex = 1
        Me.chkVehi2000Kg.Text = "Vehículo > 2000 Kg."
        Me.chkVehi2000Kg.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.chkVehi2000Kg.ThemeName = "Windows8"
        Me.chkVehi2000Kg.Value = False
        '
        'chProlongacionAutomatica
        '
        Me.chProlongacionAutomatica.DataField = "USAPROLONAUTO_CON1"
        Me.chProlongacionAutomatica.DataTable = "C1"
        Me.chProlongacionAutomatica.Descripcion = "Prolongación Automática"
        Me.chProlongacionAutomatica.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.chProlongacionAutomatica.Location = New System.Drawing.Point(6, 54)
        Me.chProlongacionAutomatica.Name = "chProlongacionAutomatica"
        Me.chProlongacionAutomatica.Size = New System.Drawing.Size(164, 18)
        Me.chProlongacionAutomatica.TabIndex = 4
        Me.chProlongacionAutomatica.Text = "Prolongación Automática"
        Me.chProlongacionAutomatica.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.chProlongacionAutomatica.ThemeName = "Windows8"
        Me.chProlongacionAutomatica.Value = False
        '
        'pnlSpace22
        '
        Me.pnlSpace22.Auto_Size = False
        Me.pnlSpace22.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace22.ChangeDock = True
        Me.pnlSpace22.Control_Resize = False
        Me.pnlSpace22.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace22.isSpace = True
        Me.pnlSpace22.Location = New System.Drawing.Point(128, 0)
        Me.pnlSpace22.Name = "pnlSpace22"
        Me.pnlSpace22.numRows = 0
        Me.pnlSpace22.Reorder = True
        Me.pnlSpace22.Size = New System.Drawing.Size(6, 72)
        Me.pnlSpace22.TabIndex = 1
        '
        'rdgTipoAlquiler
        '
        Me.rdgTipoAlquiler.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.rdgTipoAlquiler.Controls.Add(Me.radCorta)
        Me.rdgTipoAlquiler.Controls.Add(Me.radLarga)
        Me.rdgTipoAlquiler.DataField = "DURACION_CON1"
        Me.rdgTipoAlquiler.DataTable = "C1"
        Me.rdgTipoAlquiler.DefaultIndex = Nothing
        Me.rdgTipoAlquiler.Descripcion = "Tipo de Alquiler"
        Me.rdgTipoAlquiler.Dock = System.Windows.Forms.DockStyle.Left
        Me.rdgTipoAlquiler.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.rdgTipoAlquiler.HeaderText = "Tipo de Alquiler"
        Me.rdgTipoAlquiler.Index = "C"
        Me.rdgTipoAlquiler.Location = New System.Drawing.Point(0, 0)
        Me.rdgTipoAlquiler.Name = "rdgTipoAlquiler"
        Me.rdgTipoAlquiler.numRows = 0
        Me.rdgTipoAlquiler.Padding = New System.Windows.Forms.Padding(6, 18, 6, 6)
        Me.rdgTipoAlquiler.Reorder = True
        Me.rdgTipoAlquiler.Size = New System.Drawing.Size(128, 72)
        Me.rdgTipoAlquiler.TabIndex = 0
        Me.rdgTipoAlquiler.Text = "Tipo de Alquiler"
        Me.rdgTipoAlquiler.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.rdgTipoAlquiler.ThemeName = "Windows8"
        Me.rdgTipoAlquiler.Title = "Tipo de Alquiler"
        '
        'radCorta
        '
        Me.radCorta.BackColor = System.Drawing.SystemColors.Control
        Me.radCorta.Checked = True
        Me.radCorta.CheckState = System.Windows.Forms.CheckState.Checked
        Me.radCorta.Descripcion = "Corta Duración"
        Me.radCorta.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.radCorta.Index = "C"
        Me.radCorta.Location = New System.Drawing.Point(9, 21)
        Me.radCorta.Name = "radCorta"
        Me.radCorta.Size = New System.Drawing.Size(109, 18)
        Me.radCorta.TabIndex = 0
        Me.radCorta.TabStop = True
        Me.radCorta.Text = "Corta Duración"
        Me.radCorta.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.radCorta.ThemeName = "Windows8"
        Me.radCorta.ToggleState = Telerik.WinControls.Enumerations.ToggleState.[On]
        '
        'radLarga
        '
        Me.radLarga.BackColor = System.Drawing.SystemColors.Control
        Me.radLarga.Checked = False
        Me.radLarga.Descripcion = "Larga Duración"
        Me.radLarga.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.radLarga.Index = "L"
        Me.radLarga.Location = New System.Drawing.Point(9, 45)
        Me.radLarga.Name = "radLarga"
        Me.radLarga.Size = New System.Drawing.Size(110, 18)
        Me.radLarga.TabIndex = 1
        Me.radLarga.Text = "Larga Duración"
        Me.radLarga.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.radLarga.ThemeName = "Windows8"
        '
        'pnlCabeceraOtros
        '
        Me.pnlCabeceraOtros.Auto_Size = False
        Me.pnlCabeceraOtros.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlCabeceraOtros.ChangeDock = False
        Me.pnlCabeceraOtros.Control_Resize = False
        Me.pnlCabeceraOtros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCabeceraOtros.isSpace = False
        Me.pnlCabeceraOtros.Location = New System.Drawing.Point(0, 0)
        Me.pnlCabeceraOtros.Name = "pnlCabeceraOtros"
        Me.pnlCabeceraOtros.numRows = 3
        Me.pnlCabeceraOtros.Reorder = True
        Me.pnlCabeceraOtros.Size = New System.Drawing.Size(1138, 78)
        Me.pnlCabeceraOtros.TabIndex = 0
        '
        'pvpConductores
        '
        Me.pvpConductores.Controls.Add(Me.pnlConductoresDer)
        Me.pvpConductores.Controls.Add(Me.pnlConductoresIzq)
        Me.pvpConductores.Controls.Add(Me.pnlCabeceraConductores)
        Me.pvpConductores.ItemSize = New System.Drawing.SizeF(83.0!, 23.0!)
        Me.pvpConductores.Location = New System.Drawing.Point(129, 5)
        Me.pvpConductores.Name = "pvpConductores"
        Me.pvpConductores.PanelCabezeraContainer = Me.pnlCabeceraConductores
        Me.pvpConductores.Size = New System.Drawing.Size(1138, 559)
        Me.pvpConductores.Text = "Conductores"
        '
        'pnlConductoresDer
        '
        Me.pnlConductoresDer.Auto_Size = False
        Me.pnlConductoresDer.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlConductoresDer.ChangeDock = True
        Me.pnlConductoresDer.Control_Resize = False
        Me.pnlConductoresDer.Controls.Add(Me.gbxConductoresAdicionales)
        Me.pnlConductoresDer.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlConductoresDer.isSpace = False
        Me.pnlConductoresDer.Location = New System.Drawing.Point(568, 78)
        Me.pnlConductoresDer.Name = "pnlConductoresDer"
        Me.pnlConductoresDer.numRows = 0
        Me.pnlConductoresDer.Padding = New System.Windows.Forms.Padding(3)
        Me.pnlConductoresDer.Reorder = True
        Me.pnlConductoresDer.Size = New System.Drawing.Size(568, 481)
        Me.pnlConductoresDer.TabIndex = 3
        '
        'gbxConductoresAdicionales
        '
        Me.gbxConductoresAdicionales.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.gbxConductoresAdicionales.Controls.Add(Me.gbxOtroCond3)
        Me.gbxConductoresAdicionales.Controls.Add(Me.gbxOtroCond2)
        Me.gbxConductoresAdicionales.Controls.Add(Me.gbxOtroCond)
        Me.gbxConductoresAdicionales.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbxConductoresAdicionales.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.gbxConductoresAdicionales.HeaderText = "Conductores Adicionales"
        Me.gbxConductoresAdicionales.Location = New System.Drawing.Point(3, 3)
        Me.gbxConductoresAdicionales.Name = "gbxConductoresAdicionales"
        Me.gbxConductoresAdicionales.numRows = 0
        Me.gbxConductoresAdicionales.Padding = New System.Windows.Forms.Padding(6, 18, 6, 6)
        Me.gbxConductoresAdicionales.Reorder = True
        Me.gbxConductoresAdicionales.Size = New System.Drawing.Size(562, 318)
        Me.gbxConductoresAdicionales.TabIndex = 0
        Me.gbxConductoresAdicionales.Text = "Conductores Adicionales"
        Me.gbxConductoresAdicionales.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.gbxConductoresAdicionales.ThemeName = "Windows8"
        Me.gbxConductoresAdicionales.Title = "Conductores Adicionales"
        '
        'gbxOtroCond3
        '
        Me.gbxOtroCond3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.gbxOtroCond3.Controls.Add(Me.pnlOtroPermismo3)
        Me.gbxOtroCond3.Controls.Add(Me.pnlOtroFPermismo3)
        Me.gbxOtroCond3.Controls.Add(Me.dtfOtroCond3)
        Me.gbxOtroCond3.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbxOtroCond3.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.gbxOtroCond3.HeaderText = "Conductor Adicional"
        Me.gbxOtroCond3.Location = New System.Drawing.Point(6, 214)
        Me.gbxOtroCond3.Name = "gbxOtroCond3"
        Me.gbxOtroCond3.numRows = 3
        Me.gbxOtroCond3.Padding = New System.Windows.Forms.Padding(6, 18, 6, 6)
        Me.gbxOtroCond3.Reorder = True
        Me.gbxOtroCond3.Size = New System.Drawing.Size(550, 98)
        Me.gbxOtroCond3.TabIndex = 2
        Me.gbxOtroCond3.Text = "Conductor Adicional"
        Me.gbxOtroCond3.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.gbxOtroCond3.ThemeName = "Windows8"
        Me.gbxOtroCond3.Title = "Conductor Adicional"
        '
        'pnlOtroPermismo3
        '
        Me.pnlOtroPermismo3.Auto_Size = False
        Me.pnlOtroPermismo3.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlOtroPermismo3.ChangeDock = False
        Me.pnlOtroPermismo3.Control_Resize = False
        Me.pnlOtroPermismo3.Controls.Add(Me.dtdOtroNac3)
        Me.pnlOtroPermismo3.Controls.Add(Me.dtfOtroPer3)
        Me.pnlOtroPermismo3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlOtroPermismo3.isSpace = False
        Me.pnlOtroPermismo3.Location = New System.Drawing.Point(6, 44)
        Me.pnlOtroPermismo3.Name = "pnlOtroPermismo3"
        Me.pnlOtroPermismo3.numRows = 0
        Me.pnlOtroPermismo3.Reorder = True
        Me.pnlOtroPermismo3.Size = New System.Drawing.Size(352, 48)
        Me.pnlOtroPermismo3.TabIndex = 1
        '
        'dtdOtroNac3
        '
        Me.dtdOtroNac3.Allow_Empty = True
        Me.dtdOtroNac3.DataField = "OTRONAC3_CON2"
        Me.dtdOtroNac3.DataTable = "C2"
        Me.dtdOtroNac3.Default_Value = New Date(2015, 10, 7, 0, 0, 0, 0)
        Me.dtdOtroNac3.Descripcion = "F. Nacimiento"
        Me.dtdOtroNac3.Dock = System.Windows.Forms.DockStyle.Right
        Me.dtdOtroNac3.FocoEnAgregar = False
        Me.dtdOtroNac3.Label_Space = 90
        Me.dtdOtroNac3.Location = New System.Drawing.Point(172, 26)
        Me.dtdOtroNac3.Max_Value = Nothing
        Me.dtdOtroNac3.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdOtroNac3.MensajeIncorrectoCustom = Nothing
        Me.dtdOtroNac3.Min_Value = Nothing
        Me.dtdOtroNac3.MinDate = New Date(CType(0, Long))
        Me.dtdOtroNac3.MinimumSize = New System.Drawing.Size(180, 26)
        Me.dtdOtroNac3.Name = "dtdOtroNac3"
        Me.dtdOtroNac3.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdOtroNac3.ReadOnly_Data = False
        Me.dtdOtroNac3.Size = New System.Drawing.Size(180, 26)
        Me.dtdOtroNac3.TabIndex = 1
        Me.dtdOtroNac3.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdOtroNac3.Validate_on_lost_focus = True
        Me.dtdOtroNac3.Value_Data = New Date(2015, 10, 7, 0, 0, 0, 0)
        '
        'dtfOtroPer3
        '
        Me.dtfOtroPer3.Allow_Empty = True
        Me.dtfOtroPer3.Allow_Negative = True
        Me.dtfOtroPer3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfOtroPer3.BackColor = System.Drawing.SystemColors.Control
        Me.dtfOtroPer3.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfOtroPer3.DataField = "OTRO3PER_CON2"
        Me.dtfOtroPer3.DataTable = "C2"
        Me.dtfOtroPer3.Descripcion = "Permiso"
        Me.dtfOtroPer3.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfOtroPer3.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfOtroPer3.FocoEnAgregar = False
        Me.dtfOtroPer3.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfOtroPer3.Image = Nothing
        Me.dtfOtroPer3.Label_Space = 75
        Me.dtfOtroPer3.Length_Data = 32767
        Me.dtfOtroPer3.Location = New System.Drawing.Point(0, 0)
        Me.dtfOtroPer3.Max_Value = 0.0R
        Me.dtfOtroPer3.MensajeIncorrectoCustom = Nothing
        Me.dtfOtroPer3.Name = "dtfOtroPer3"
        Me.dtfOtroPer3.Null_on_Empty = True
        Me.dtfOtroPer3.OpenForm = Nothing
        Me.dtfOtroPer3.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfOtroPer3.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfOtroPer3.ReadOnly_Data = False
        Me.dtfOtroPer3.Show_Button = False
        Me.dtfOtroPer3.Size = New System.Drawing.Size(352, 26)
        Me.dtfOtroPer3.TabIndex = 0
        Me.dtfOtroPer3.Text_Data = ""
        Me.dtfOtroPer3.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfOtroPer3.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfOtroPer3.TopPadding = 0
        Me.dtfOtroPer3.Upper_Case = False
        Me.dtfOtroPer3.Validate_on_lost_focus = True
        '
        'pnlOtroFPermismo3
        '
        Me.pnlOtroFPermismo3.Auto_Size = False
        Me.pnlOtroFPermismo3.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlOtroFPermismo3.ChangeDock = False
        Me.pnlOtroFPermismo3.Control_Resize = False
        Me.pnlOtroFPermismo3.Controls.Add(Me.dtdOtroCadu3)
        Me.pnlOtroFPermismo3.Controls.Add(Me.dtdOtroExpe3)
        Me.pnlOtroFPermismo3.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlOtroFPermismo3.isSpace = False
        Me.pnlOtroFPermismo3.Location = New System.Drawing.Point(358, 44)
        Me.pnlOtroFPermismo3.Name = "pnlOtroFPermismo3"
        Me.pnlOtroFPermismo3.numRows = 0
        Me.pnlOtroFPermismo3.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.pnlOtroFPermismo3.Reorder = True
        Me.pnlOtroFPermismo3.Size = New System.Drawing.Size(186, 48)
        Me.pnlOtroFPermismo3.TabIndex = 2
        '
        'dtdOtroCadu3
        '
        Me.dtdOtroCadu3.Allow_Empty = True
        Me.dtdOtroCadu3.DataField = "OTRO3FVTO_CON2"
        Me.dtdOtroCadu3.DataTable = "C2"
        Me.dtdOtroCadu3.Default_Value = New Date(2015, 10, 7, 0, 0, 0, 0)
        Me.dtdOtroCadu3.Descripcion = "F. Caducidad"
        Me.dtdOtroCadu3.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtdOtroCadu3.FocoEnAgregar = False
        Me.dtdOtroCadu3.Label_Space = 90
        Me.dtdOtroCadu3.Location = New System.Drawing.Point(6, 26)
        Me.dtdOtroCadu3.Max_Value = Nothing
        Me.dtdOtroCadu3.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdOtroCadu3.MensajeIncorrectoCustom = Nothing
        Me.dtdOtroCadu3.Min_Value = Nothing
        Me.dtdOtroCadu3.MinDate = New Date(CType(0, Long))
        Me.dtdOtroCadu3.MinimumSize = New System.Drawing.Size(180, 26)
        Me.dtdOtroCadu3.Name = "dtdOtroCadu3"
        Me.dtdOtroCadu3.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdOtroCadu3.ReadOnly_Data = False
        Me.dtdOtroCadu3.Size = New System.Drawing.Size(180, 26)
        Me.dtdOtroCadu3.TabIndex = 1
        Me.dtdOtroCadu3.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdOtroCadu3.Validate_on_lost_focus = True
        Me.dtdOtroCadu3.Value_Data = New Date(2015, 10, 7, 0, 0, 0, 0)
        '
        'dtdOtroExpe3
        '
        Me.dtdOtroExpe3.Allow_Empty = True
        Me.dtdOtroExpe3.DataField = "OTRO3FEXPE_CON2"
        Me.dtdOtroExpe3.DataTable = "C2"
        Me.dtdOtroExpe3.Default_Value = New Date(2015, 10, 7, 0, 0, 0, 0)
        Me.dtdOtroExpe3.Descripcion = "F. Expedicion"
        Me.dtdOtroExpe3.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtdOtroExpe3.FocoEnAgregar = False
        Me.dtdOtroExpe3.Label_Space = 90
        Me.dtdOtroExpe3.Location = New System.Drawing.Point(6, 0)
        Me.dtdOtroExpe3.Max_Value = Nothing
        Me.dtdOtroExpe3.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdOtroExpe3.MensajeIncorrectoCustom = Nothing
        Me.dtdOtroExpe3.Min_Value = Nothing
        Me.dtdOtroExpe3.MinDate = New Date(CType(0, Long))
        Me.dtdOtroExpe3.MinimumSize = New System.Drawing.Size(180, 26)
        Me.dtdOtroExpe3.Name = "dtdOtroExpe3"
        Me.dtdOtroExpe3.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdOtroExpe3.ReadOnly_Data = False
        Me.dtdOtroExpe3.Size = New System.Drawing.Size(180, 26)
        Me.dtdOtroExpe3.TabIndex = 0
        Me.dtdOtroExpe3.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdOtroExpe3.Validate_on_lost_focus = True
        Me.dtdOtroExpe3.Value_Data = New Date(2015, 10, 7, 0, 0, 0, 0)
        '
        'dtfOtroCond3
        '
        Me.dtfOtroCond3.Allow_Empty = True
        Me.dtfOtroCond3.Allow_Negative = True
        Me.dtfOtroCond3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfOtroCond3.BackColor = System.Drawing.SystemColors.Control
        Me.dtfOtroCond3.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfOtroCond3.DataField = "OTRO3COND_CON2"
        Me.dtfOtroCond3.DataTable = "C2"
        Me.dtfOtroCond3.DB = Connection24
        Me.dtfOtroCond3.Desc_Datafield = "NOMBRE"
        Me.dtfOtroCond3.Desc_DBPK = "NUMERO_CLI"
        Me.dtfOtroCond3.Desc_DBTable = "CLIENTES1"
        Me.dtfOtroCond3.Desc_Where = Nothing
        Me.dtfOtroCond3.Desc_WhereObligatoria = Nothing
        Me.dtfOtroCond3.Descripcion = "Conductor"
        Me.dtfOtroCond3.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfOtroCond3.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfOtroCond3.ExtraSQL = ""
        Me.dtfOtroCond3.FocoEnAgregar = False
        Me.dtfOtroCond3.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfOtroCond3.Formulario = Nothing
        Me.dtfOtroCond3.Label_Space = 75
        Me.dtfOtroCond3.Length_Data = 32767
        Me.dtfOtroCond3.Location = New System.Drawing.Point(6, 18)
        Me.dtfOtroCond3.Lupa = Nothing
        Me.dtfOtroCond3.Max_Value = 0.0R
        Me.dtfOtroCond3.MensajeIncorrectoCustom = Nothing
        Me.dtfOtroCond3.Name = "dtfOtroCond3"
        Me.dtfOtroCond3.Null_on_Empty = True
        Me.dtfOtroCond3.OpenForm = Nothing
        Me.dtfOtroCond3.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfOtroCond3.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfOtroCond3.Query_on_Text_Changed = True
        Me.dtfOtroCond3.ReadOnly_Data = False
        Me.dtfOtroCond3.ReQuery = False
        Me.dtfOtroCond3.ShowButton = True
        Me.dtfOtroCond3.Size = New System.Drawing.Size(538, 26)
        Me.dtfOtroCond3.TabIndex = 0
        Me.dtfOtroCond3.Text_Data = ""
        Me.dtfOtroCond3.Text_Data_Desc = ""
        Me.dtfOtroCond3.Text_Width = 58
        Me.dtfOtroCond3.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfOtroCond3.TopPadding = 0
        Me.dtfOtroCond3.Upper_Case = False
        Me.dtfOtroCond3.Validate_on_lost_focus = True
        '
        'gbxOtroCond2
        '
        Me.gbxOtroCond2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.gbxOtroCond2.Controls.Add(Me.pnlOtroPermismo2)
        Me.gbxOtroCond2.Controls.Add(Me.pnlOtroFPermismo2)
        Me.gbxOtroCond2.Controls.Add(Me.dtfOtroCond2)
        Me.gbxOtroCond2.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbxOtroCond2.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.gbxOtroCond2.HeaderText = "Conductor Adicional"
        Me.gbxOtroCond2.Location = New System.Drawing.Point(6, 116)
        Me.gbxOtroCond2.Name = "gbxOtroCond2"
        Me.gbxOtroCond2.numRows = 3
        Me.gbxOtroCond2.Padding = New System.Windows.Forms.Padding(6, 18, 6, 6)
        Me.gbxOtroCond2.Reorder = True
        Me.gbxOtroCond2.Size = New System.Drawing.Size(550, 98)
        Me.gbxOtroCond2.TabIndex = 1
        Me.gbxOtroCond2.Text = "Conductor Adicional"
        Me.gbxOtroCond2.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.gbxOtroCond2.ThemeName = "Windows8"
        Me.gbxOtroCond2.Title = "Conductor Adicional"
        '
        'pnlOtroPermismo2
        '
        Me.pnlOtroPermismo2.Auto_Size = False
        Me.pnlOtroPermismo2.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlOtroPermismo2.ChangeDock = False
        Me.pnlOtroPermismo2.Control_Resize = False
        Me.pnlOtroPermismo2.Controls.Add(Me.dtdOtroNac2)
        Me.pnlOtroPermismo2.Controls.Add(Me.dtfOtroPer2)
        Me.pnlOtroPermismo2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlOtroPermismo2.isSpace = False
        Me.pnlOtroPermismo2.Location = New System.Drawing.Point(6, 44)
        Me.pnlOtroPermismo2.Name = "pnlOtroPermismo2"
        Me.pnlOtroPermismo2.numRows = 0
        Me.pnlOtroPermismo2.Reorder = True
        Me.pnlOtroPermismo2.Size = New System.Drawing.Size(352, 48)
        Me.pnlOtroPermismo2.TabIndex = 1
        '
        'dtdOtroNac2
        '
        Me.dtdOtroNac2.Allow_Empty = True
        Me.dtdOtroNac2.DataField = "OTRONAC2_CON2"
        Me.dtdOtroNac2.DataTable = "C2"
        Me.dtdOtroNac2.Default_Value = New Date(2015, 10, 7, 0, 0, 0, 0)
        Me.dtdOtroNac2.Descripcion = "F. Nacimiento"
        Me.dtdOtroNac2.Dock = System.Windows.Forms.DockStyle.Right
        Me.dtdOtroNac2.FocoEnAgregar = False
        Me.dtdOtroNac2.Label_Space = 90
        Me.dtdOtroNac2.Location = New System.Drawing.Point(172, 26)
        Me.dtdOtroNac2.Max_Value = Nothing
        Me.dtdOtroNac2.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdOtroNac2.MensajeIncorrectoCustom = Nothing
        Me.dtdOtroNac2.Min_Value = Nothing
        Me.dtdOtroNac2.MinDate = New Date(CType(0, Long))
        Me.dtdOtroNac2.MinimumSize = New System.Drawing.Size(180, 26)
        Me.dtdOtroNac2.Name = "dtdOtroNac2"
        Me.dtdOtroNac2.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdOtroNac2.ReadOnly_Data = False
        Me.dtdOtroNac2.Size = New System.Drawing.Size(180, 26)
        Me.dtdOtroNac2.TabIndex = 1
        Me.dtdOtroNac2.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdOtroNac2.Validate_on_lost_focus = True
        Me.dtdOtroNac2.Value_Data = New Date(2015, 10, 7, 0, 0, 0, 0)
        '
        'dtfOtroPer2
        '
        Me.dtfOtroPer2.Allow_Empty = True
        Me.dtfOtroPer2.Allow_Negative = True
        Me.dtfOtroPer2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfOtroPer2.BackColor = System.Drawing.SystemColors.Control
        Me.dtfOtroPer2.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfOtroPer2.DataField = "OTRO2PER_CON2"
        Me.dtfOtroPer2.DataTable = "C2"
        Me.dtfOtroPer2.Descripcion = "Permiso"
        Me.dtfOtroPer2.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfOtroPer2.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfOtroPer2.FocoEnAgregar = False
        Me.dtfOtroPer2.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfOtroPer2.Image = Nothing
        Me.dtfOtroPer2.Label_Space = 75
        Me.dtfOtroPer2.Length_Data = 32767
        Me.dtfOtroPer2.Location = New System.Drawing.Point(0, 0)
        Me.dtfOtroPer2.Max_Value = 0.0R
        Me.dtfOtroPer2.MensajeIncorrectoCustom = Nothing
        Me.dtfOtroPer2.Name = "dtfOtroPer2"
        Me.dtfOtroPer2.Null_on_Empty = True
        Me.dtfOtroPer2.OpenForm = Nothing
        Me.dtfOtroPer2.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfOtroPer2.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfOtroPer2.ReadOnly_Data = False
        Me.dtfOtroPer2.Show_Button = False
        Me.dtfOtroPer2.Size = New System.Drawing.Size(352, 26)
        Me.dtfOtroPer2.TabIndex = 0
        Me.dtfOtroPer2.Text_Data = ""
        Me.dtfOtroPer2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfOtroPer2.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfOtroPer2.TopPadding = 0
        Me.dtfOtroPer2.Upper_Case = False
        Me.dtfOtroPer2.Validate_on_lost_focus = True
        '
        'pnlOtroFPermismo2
        '
        Me.pnlOtroFPermismo2.Auto_Size = False
        Me.pnlOtroFPermismo2.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlOtroFPermismo2.ChangeDock = False
        Me.pnlOtroFPermismo2.Control_Resize = False
        Me.pnlOtroFPermismo2.Controls.Add(Me.dtdOtroCadu2)
        Me.pnlOtroFPermismo2.Controls.Add(Me.dtdOtroExpe2)
        Me.pnlOtroFPermismo2.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlOtroFPermismo2.isSpace = False
        Me.pnlOtroFPermismo2.Location = New System.Drawing.Point(358, 44)
        Me.pnlOtroFPermismo2.Name = "pnlOtroFPermismo2"
        Me.pnlOtroFPermismo2.numRows = 0
        Me.pnlOtroFPermismo2.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.pnlOtroFPermismo2.Reorder = True
        Me.pnlOtroFPermismo2.Size = New System.Drawing.Size(186, 48)
        Me.pnlOtroFPermismo2.TabIndex = 2
        '
        'dtdOtroCadu2
        '
        Me.dtdOtroCadu2.Allow_Empty = True
        Me.dtdOtroCadu2.DataField = "OTRO2FVTO_CON2"
        Me.dtdOtroCadu2.DataTable = "C2"
        Me.dtdOtroCadu2.Default_Value = New Date(2015, 10, 7, 0, 0, 0, 0)
        Me.dtdOtroCadu2.Descripcion = "F. Caducidad"
        Me.dtdOtroCadu2.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtdOtroCadu2.FocoEnAgregar = False
        Me.dtdOtroCadu2.Label_Space = 90
        Me.dtdOtroCadu2.Location = New System.Drawing.Point(6, 26)
        Me.dtdOtroCadu2.Max_Value = Nothing
        Me.dtdOtroCadu2.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdOtroCadu2.MensajeIncorrectoCustom = Nothing
        Me.dtdOtroCadu2.Min_Value = Nothing
        Me.dtdOtroCadu2.MinDate = New Date(CType(0, Long))
        Me.dtdOtroCadu2.MinimumSize = New System.Drawing.Size(180, 26)
        Me.dtdOtroCadu2.Name = "dtdOtroCadu2"
        Me.dtdOtroCadu2.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdOtroCadu2.ReadOnly_Data = False
        Me.dtdOtroCadu2.Size = New System.Drawing.Size(180, 26)
        Me.dtdOtroCadu2.TabIndex = 1
        Me.dtdOtroCadu2.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdOtroCadu2.Validate_on_lost_focus = True
        Me.dtdOtroCadu2.Value_Data = New Date(2015, 10, 7, 0, 0, 0, 0)
        '
        'dtdOtroExpe2
        '
        Me.dtdOtroExpe2.Allow_Empty = True
        Me.dtdOtroExpe2.DataField = "OTRO2FEXPE_CON2"
        Me.dtdOtroExpe2.DataTable = "C2"
        Me.dtdOtroExpe2.Default_Value = New Date(2015, 10, 7, 0, 0, 0, 0)
        Me.dtdOtroExpe2.Descripcion = "F. Expedicion"
        Me.dtdOtroExpe2.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtdOtroExpe2.FocoEnAgregar = False
        Me.dtdOtroExpe2.Label_Space = 90
        Me.dtdOtroExpe2.Location = New System.Drawing.Point(6, 0)
        Me.dtdOtroExpe2.Max_Value = Nothing
        Me.dtdOtroExpe2.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdOtroExpe2.MensajeIncorrectoCustom = Nothing
        Me.dtdOtroExpe2.Min_Value = Nothing
        Me.dtdOtroExpe2.MinDate = New Date(CType(0, Long))
        Me.dtdOtroExpe2.MinimumSize = New System.Drawing.Size(180, 26)
        Me.dtdOtroExpe2.Name = "dtdOtroExpe2"
        Me.dtdOtroExpe2.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdOtroExpe2.ReadOnly_Data = False
        Me.dtdOtroExpe2.Size = New System.Drawing.Size(180, 26)
        Me.dtdOtroExpe2.TabIndex = 0
        Me.dtdOtroExpe2.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdOtroExpe2.Validate_on_lost_focus = True
        Me.dtdOtroExpe2.Value_Data = New Date(2015, 10, 7, 0, 0, 0, 0)
        '
        'dtfOtroCond2
        '
        Me.dtfOtroCond2.Allow_Empty = True
        Me.dtfOtroCond2.Allow_Negative = True
        Me.dtfOtroCond2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfOtroCond2.BackColor = System.Drawing.SystemColors.Control
        Me.dtfOtroCond2.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfOtroCond2.DataField = "OTRO2COND_CON2"
        Me.dtfOtroCond2.DataTable = "C2"
        Me.dtfOtroCond2.DB = Connection25
        Me.dtfOtroCond2.Desc_Datafield = "NOMBRE"
        Me.dtfOtroCond2.Desc_DBPK = "NUMERO_CLI"
        Me.dtfOtroCond2.Desc_DBTable = "CLIENTES1"
        Me.dtfOtroCond2.Desc_Where = Nothing
        Me.dtfOtroCond2.Desc_WhereObligatoria = Nothing
        Me.dtfOtroCond2.Descripcion = "Conductor"
        Me.dtfOtroCond2.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfOtroCond2.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfOtroCond2.ExtraSQL = ""
        Me.dtfOtroCond2.FocoEnAgregar = False
        Me.dtfOtroCond2.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfOtroCond2.Formulario = Nothing
        Me.dtfOtroCond2.Label_Space = 75
        Me.dtfOtroCond2.Length_Data = 32767
        Me.dtfOtroCond2.Location = New System.Drawing.Point(6, 18)
        Me.dtfOtroCond2.Lupa = Nothing
        Me.dtfOtroCond2.Max_Value = 0.0R
        Me.dtfOtroCond2.MensajeIncorrectoCustom = Nothing
        Me.dtfOtroCond2.Name = "dtfOtroCond2"
        Me.dtfOtroCond2.Null_on_Empty = True
        Me.dtfOtroCond2.OpenForm = Nothing
        Me.dtfOtroCond2.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfOtroCond2.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfOtroCond2.Query_on_Text_Changed = True
        Me.dtfOtroCond2.ReadOnly_Data = False
        Me.dtfOtroCond2.ReQuery = False
        Me.dtfOtroCond2.ShowButton = True
        Me.dtfOtroCond2.Size = New System.Drawing.Size(538, 26)
        Me.dtfOtroCond2.TabIndex = 0
        Me.dtfOtroCond2.Text_Data = ""
        Me.dtfOtroCond2.Text_Data_Desc = ""
        Me.dtfOtroCond2.Text_Width = 58
        Me.dtfOtroCond2.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfOtroCond2.TopPadding = 0
        Me.dtfOtroCond2.Upper_Case = False
        Me.dtfOtroCond2.Validate_on_lost_focus = True
        '
        'gbxOtroCond
        '
        Me.gbxOtroCond.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.gbxOtroCond.Controls.Add(Me.pnlOtroPermismo)
        Me.gbxOtroCond.Controls.Add(Me.pnlOtroFPermismo)
        Me.gbxOtroCond.Controls.Add(Me.dtfOtroCond)
        Me.gbxOtroCond.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbxOtroCond.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.gbxOtroCond.HeaderText = "Conductor Adicional"
        Me.gbxOtroCond.Location = New System.Drawing.Point(6, 18)
        Me.gbxOtroCond.Name = "gbxOtroCond"
        Me.gbxOtroCond.numRows = 3
        Me.gbxOtroCond.Padding = New System.Windows.Forms.Padding(6, 18, 6, 6)
        Me.gbxOtroCond.Reorder = True
        Me.gbxOtroCond.Size = New System.Drawing.Size(550, 98)
        Me.gbxOtroCond.TabIndex = 0
        Me.gbxOtroCond.Text = "Conductor Adicional"
        Me.gbxOtroCond.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.gbxOtroCond.ThemeName = "Windows8"
        Me.gbxOtroCond.Title = "Conductor Adicional"
        '
        'pnlOtroPermismo
        '
        Me.pnlOtroPermismo.Auto_Size = False
        Me.pnlOtroPermismo.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlOtroPermismo.ChangeDock = False
        Me.pnlOtroPermismo.Control_Resize = False
        Me.pnlOtroPermismo.Controls.Add(Me.dtdOtroNac)
        Me.pnlOtroPermismo.Controls.Add(Me.dtfOtroPer)
        Me.pnlOtroPermismo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlOtroPermismo.isSpace = False
        Me.pnlOtroPermismo.Location = New System.Drawing.Point(6, 44)
        Me.pnlOtroPermismo.Name = "pnlOtroPermismo"
        Me.pnlOtroPermismo.numRows = 0
        Me.pnlOtroPermismo.Reorder = True
        Me.pnlOtroPermismo.Size = New System.Drawing.Size(352, 48)
        Me.pnlOtroPermismo.TabIndex = 1
        '
        'dtdOtroNac
        '
        Me.dtdOtroNac.Allow_Empty = True
        Me.dtdOtroNac.DataField = "OTRONAC_CON2"
        Me.dtdOtroNac.DataTable = "C2"
        Me.dtdOtroNac.Default_Value = New Date(2015, 10, 7, 0, 0, 0, 0)
        Me.dtdOtroNac.Descripcion = "F. Nacimiento"
        Me.dtdOtroNac.Dock = System.Windows.Forms.DockStyle.Right
        Me.dtdOtroNac.FocoEnAgregar = False
        Me.dtdOtroNac.Label_Space = 90
        Me.dtdOtroNac.Location = New System.Drawing.Point(172, 26)
        Me.dtdOtroNac.Max_Value = Nothing
        Me.dtdOtroNac.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdOtroNac.MensajeIncorrectoCustom = Nothing
        Me.dtdOtroNac.Min_Value = Nothing
        Me.dtdOtroNac.MinDate = New Date(CType(0, Long))
        Me.dtdOtroNac.MinimumSize = New System.Drawing.Size(180, 26)
        Me.dtdOtroNac.Name = "dtdOtroNac"
        Me.dtdOtroNac.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdOtroNac.ReadOnly_Data = False
        Me.dtdOtroNac.Size = New System.Drawing.Size(180, 26)
        Me.dtdOtroNac.TabIndex = 1
        Me.dtdOtroNac.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdOtroNac.Validate_on_lost_focus = True
        Me.dtdOtroNac.Value_Data = New Date(2015, 10, 7, 0, 0, 0, 0)
        '
        'dtfOtroPer
        '
        Me.dtfOtroPer.Allow_Empty = True
        Me.dtfOtroPer.Allow_Negative = True
        Me.dtfOtroPer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfOtroPer.BackColor = System.Drawing.SystemColors.Control
        Me.dtfOtroPer.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfOtroPer.DataField = "OTROPER_CON2"
        Me.dtfOtroPer.DataTable = "C2"
        Me.dtfOtroPer.Descripcion = "Permiso"
        Me.dtfOtroPer.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfOtroPer.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfOtroPer.FocoEnAgregar = False
        Me.dtfOtroPer.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfOtroPer.Image = Nothing
        Me.dtfOtroPer.Label_Space = 75
        Me.dtfOtroPer.Length_Data = 32767
        Me.dtfOtroPer.Location = New System.Drawing.Point(0, 0)
        Me.dtfOtroPer.Max_Value = 0.0R
        Me.dtfOtroPer.MensajeIncorrectoCustom = Nothing
        Me.dtfOtroPer.Name = "dtfOtroPer"
        Me.dtfOtroPer.Null_on_Empty = True
        Me.dtfOtroPer.OpenForm = Nothing
        Me.dtfOtroPer.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfOtroPer.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfOtroPer.ReadOnly_Data = False
        Me.dtfOtroPer.Show_Button = False
        Me.dtfOtroPer.Size = New System.Drawing.Size(352, 26)
        Me.dtfOtroPer.TabIndex = 0
        Me.dtfOtroPer.Text_Data = ""
        Me.dtfOtroPer.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfOtroPer.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfOtroPer.TopPadding = 0
        Me.dtfOtroPer.Upper_Case = False
        Me.dtfOtroPer.Validate_on_lost_focus = True
        '
        'pnlOtroFPermismo
        '
        Me.pnlOtroFPermismo.Auto_Size = False
        Me.pnlOtroFPermismo.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlOtroFPermismo.ChangeDock = False
        Me.pnlOtroFPermismo.Control_Resize = False
        Me.pnlOtroFPermismo.Controls.Add(Me.dtdOtroCadu)
        Me.pnlOtroFPermismo.Controls.Add(Me.dtdOtroExpe)
        Me.pnlOtroFPermismo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlOtroFPermismo.isSpace = False
        Me.pnlOtroFPermismo.Location = New System.Drawing.Point(358, 44)
        Me.pnlOtroFPermismo.Name = "pnlOtroFPermismo"
        Me.pnlOtroFPermismo.numRows = 0
        Me.pnlOtroFPermismo.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.pnlOtroFPermismo.Reorder = True
        Me.pnlOtroFPermismo.Size = New System.Drawing.Size(186, 48)
        Me.pnlOtroFPermismo.TabIndex = 2
        '
        'dtdOtroCadu
        '
        Me.dtdOtroCadu.Allow_Empty = True
        Me.dtdOtroCadu.DataField = "OTROFVTO_CON2"
        Me.dtdOtroCadu.DataTable = "C2"
        Me.dtdOtroCadu.Default_Value = New Date(2015, 10, 7, 0, 0, 0, 0)
        Me.dtdOtroCadu.Descripcion = "F. Caducidad"
        Me.dtdOtroCadu.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtdOtroCadu.FocoEnAgregar = False
        Me.dtdOtroCadu.Label_Space = 90
        Me.dtdOtroCadu.Location = New System.Drawing.Point(6, 26)
        Me.dtdOtroCadu.Max_Value = Nothing
        Me.dtdOtroCadu.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdOtroCadu.MensajeIncorrectoCustom = Nothing
        Me.dtdOtroCadu.Min_Value = Nothing
        Me.dtdOtroCadu.MinDate = New Date(CType(0, Long))
        Me.dtdOtroCadu.MinimumSize = New System.Drawing.Size(180, 26)
        Me.dtdOtroCadu.Name = "dtdOtroCadu"
        Me.dtdOtroCadu.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdOtroCadu.ReadOnly_Data = False
        Me.dtdOtroCadu.Size = New System.Drawing.Size(180, 26)
        Me.dtdOtroCadu.TabIndex = 1
        Me.dtdOtroCadu.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdOtroCadu.Validate_on_lost_focus = True
        Me.dtdOtroCadu.Value_Data = New Date(2015, 10, 7, 0, 0, 0, 0)
        '
        'dtdOtroExpe
        '
        Me.dtdOtroExpe.Allow_Empty = True
        Me.dtdOtroExpe.DataField = "OTROFEXPE_CON2"
        Me.dtdOtroExpe.DataTable = "C2"
        Me.dtdOtroExpe.Default_Value = New Date(2015, 10, 7, 0, 0, 0, 0)
        Me.dtdOtroExpe.Descripcion = "F. Expedicion"
        Me.dtdOtroExpe.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtdOtroExpe.FocoEnAgregar = False
        Me.dtdOtroExpe.Label_Space = 90
        Me.dtdOtroExpe.Location = New System.Drawing.Point(6, 0)
        Me.dtdOtroExpe.Max_Value = Nothing
        Me.dtdOtroExpe.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdOtroExpe.MensajeIncorrectoCustom = Nothing
        Me.dtdOtroExpe.Min_Value = Nothing
        Me.dtdOtroExpe.MinDate = New Date(CType(0, Long))
        Me.dtdOtroExpe.MinimumSize = New System.Drawing.Size(180, 26)
        Me.dtdOtroExpe.Name = "dtdOtroExpe"
        Me.dtdOtroExpe.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdOtroExpe.ReadOnly_Data = False
        Me.dtdOtroExpe.Size = New System.Drawing.Size(180, 26)
        Me.dtdOtroExpe.TabIndex = 0
        Me.dtdOtroExpe.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdOtroExpe.Validate_on_lost_focus = True
        Me.dtdOtroExpe.Value_Data = New Date(2015, 10, 7, 0, 0, 0, 0)
        '
        'dtfOtroCond
        '
        Me.dtfOtroCond.Allow_Empty = True
        Me.dtfOtroCond.Allow_Negative = True
        Me.dtfOtroCond.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfOtroCond.BackColor = System.Drawing.SystemColors.Control
        Me.dtfOtroCond.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfOtroCond.DataField = "OTROCOND_CON2"
        Me.dtfOtroCond.DataTable = "C2"
        Me.dtfOtroCond.DB = Connection26
        Me.dtfOtroCond.Desc_Datafield = "NOMBRE"
        Me.dtfOtroCond.Desc_DBPK = "NUMERO_CLI"
        Me.dtfOtroCond.Desc_DBTable = "CLIENTES1"
        Me.dtfOtroCond.Desc_Where = Nothing
        Me.dtfOtroCond.Desc_WhereObligatoria = Nothing
        Me.dtfOtroCond.Descripcion = "Conductor"
        Me.dtfOtroCond.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfOtroCond.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfOtroCond.ExtraSQL = ""
        Me.dtfOtroCond.FocoEnAgregar = False
        Me.dtfOtroCond.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfOtroCond.Formulario = Nothing
        Me.dtfOtroCond.Label_Space = 75
        Me.dtfOtroCond.Length_Data = 32767
        Me.dtfOtroCond.Location = New System.Drawing.Point(6, 18)
        Me.dtfOtroCond.Lupa = Nothing
        Me.dtfOtroCond.Max_Value = 0.0R
        Me.dtfOtroCond.MensajeIncorrectoCustom = Nothing
        Me.dtfOtroCond.Name = "dtfOtroCond"
        Me.dtfOtroCond.Null_on_Empty = True
        Me.dtfOtroCond.OpenForm = Nothing
        Me.dtfOtroCond.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfOtroCond.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfOtroCond.Query_on_Text_Changed = True
        Me.dtfOtroCond.ReadOnly_Data = False
        Me.dtfOtroCond.ReQuery = False
        Me.dtfOtroCond.ShowButton = True
        Me.dtfOtroCond.Size = New System.Drawing.Size(538, 26)
        Me.dtfOtroCond.TabIndex = 0
        Me.dtfOtroCond.Text_Data = ""
        Me.dtfOtroCond.Text_Data_Desc = ""
        Me.dtfOtroCond.Text_Width = 58
        Me.dtfOtroCond.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfOtroCond.TopPadding = 0
        Me.dtfOtroCond.Upper_Case = False
        Me.dtfOtroCond.Validate_on_lost_focus = True
        '
        'pnlConductoresIzq
        '
        Me.pnlConductoresIzq.Auto_Size = False
        Me.pnlConductoresIzq.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlConductoresIzq.ChangeDock = True
        Me.pnlConductoresIzq.Control_Resize = False
        Me.pnlConductoresIzq.Controls.Add(Me.gbxConductor)
        Me.pnlConductoresIzq.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlConductoresIzq.isSpace = False
        Me.pnlConductoresIzq.Location = New System.Drawing.Point(0, 78)
        Me.pnlConductoresIzq.Name = "pnlConductoresIzq"
        Me.pnlConductoresIzq.numRows = 0
        Me.pnlConductoresIzq.Padding = New System.Windows.Forms.Padding(3)
        Me.pnlConductoresIzq.Reorder = True
        Me.pnlConductoresIzq.Size = New System.Drawing.Size(568, 481)
        Me.pnlConductoresIzq.TabIndex = 2
        '
        'gbxConductor
        '
        Me.gbxConductor.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.gbxConductor.Controls.Add(Me.pnlTarjeta)
        Me.gbxConductor.Controls.Add(Me.dtfTarjetaCond)
        Me.gbxConductor.Controls.Add(Me.dtfEmailCond)
        Me.gbxConductor.Controls.Add(Me.pnlPermiso)
        Me.gbxConductor.Controls.Add(Me.pnlLuNace)
        Me.gbxConductor.Controls.Add(Me.pnlNifTelf)
        Me.gbxConductor.Controls.Add(Me.dtdDirCond)
        Me.gbxConductor.Controls.Add(Me.dtfNombreCond)
        Me.gbxConductor.Controls.Add(Me.pnlConductor)
        Me.gbxConductor.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbxConductor.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.gbxConductor.HeaderText = "Conductor"
        Me.gbxConductor.Location = New System.Drawing.Point(3, 3)
        Me.gbxConductor.Name = "gbxConductor"
        Me.gbxConductor.numRows = 13
        Me.gbxConductor.Padding = New System.Windows.Forms.Padding(6, 18, 6, 6)
        Me.gbxConductor.Reorder = True
        Me.gbxConductor.Size = New System.Drawing.Size(562, 358)
        Me.gbxConductor.TabIndex = 0
        Me.gbxConductor.Text = "Conductor"
        Me.gbxConductor.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.gbxConductor.ThemeName = "Windows8"
        Me.gbxConductor.Title = "Conductor"
        '
        'pnlTarjeta
        '
        Me.pnlTarjeta.Auto_Size = False
        Me.pnlTarjeta.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlTarjeta.ChangeDock = True
        Me.pnlTarjeta.Control_Resize = False
        Me.pnlTarjeta.Controls.Add(Me.dtfTarNum)
        Me.pnlTarjeta.Controls.Add(Me.pnlSpace31)
        Me.pnlTarjeta.Controls.Add(Me.lblTarCadu)
        Me.pnlTarjeta.Controls.Add(Me.pnlSpace30)
        Me.pnlTarjeta.Controls.Add(Me.mdfTarcadu)
        Me.pnlTarjeta.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTarjeta.isSpace = False
        Me.pnlTarjeta.Location = New System.Drawing.Point(6, 330)
        Me.pnlTarjeta.Name = "pnlTarjeta"
        Me.pnlTarjeta.numRows = 1
        Me.pnlTarjeta.Reorder = True
        Me.pnlTarjeta.Size = New System.Drawing.Size(550, 26)
        Me.pnlTarjeta.TabIndex = 8
        '
        'dtfTarNum
        '
        Me.dtfTarNum.Allow_Empty = True
        Me.dtfTarNum.Allow_Negative = True
        Me.dtfTarNum.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfTarNum.BackColor = System.Drawing.SystemColors.Control
        Me.dtfTarNum.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfTarNum.DataField = "TARNUM_CON2"
        Me.dtfTarNum.DataTable = "C2"
        Me.dtfTarNum.Descripcion = "Número"
        Me.dtfTarNum.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfTarNum.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfTarNum.FocoEnAgregar = False
        Me.dtfTarNum.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfTarNum.Image = Nothing
        Me.dtfTarNum.Label_Space = 75
        Me.dtfTarNum.Length_Data = 32767
        Me.dtfTarNum.Location = New System.Drawing.Point(0, 0)
        Me.dtfTarNum.Max_Value = 0.0R
        Me.dtfTarNum.MensajeIncorrectoCustom = Nothing
        Me.dtfTarNum.Name = "dtfTarNum"
        Me.dtfTarNum.Null_on_Empty = True
        Me.dtfTarNum.OpenForm = Nothing
        Me.dtfTarNum.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfTarNum.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfTarNum.ReadOnly_Data = False
        Me.dtfTarNum.Show_Button = False
        Me.dtfTarNum.Size = New System.Drawing.Size(391, 26)
        Me.dtfTarNum.TabIndex = 0
        Me.dtfTarNum.Text_Data = ""
        Me.dtfTarNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfTarNum.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfTarNum.TopPadding = 0
        Me.dtfTarNum.Upper_Case = False
        Me.dtfTarNum.Validate_on_lost_focus = True
        '
        'pnlSpace31
        '
        Me.pnlSpace31.Auto_Size = False
        Me.pnlSpace31.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace31.ChangeDock = True
        Me.pnlSpace31.Control_Resize = False
        Me.pnlSpace31.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSpace31.isSpace = True
        Me.pnlSpace31.Location = New System.Drawing.Point(391, 0)
        Me.pnlSpace31.Name = "pnlSpace31"
        Me.pnlSpace31.numRows = 0
        Me.pnlSpace31.Reorder = True
        Me.pnlSpace31.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace31.TabIndex = 1
        '
        'lblTarCadu
        '
        Me.lblTarCadu.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblTarCadu.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblTarCadu.Location = New System.Drawing.Point(397, 0)
        Me.lblTarCadu.Name = "lblTarCadu"
        Me.lblTarCadu.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.lblTarCadu.Size = New System.Drawing.Size(102, 19)
        Me.lblTarCadu.TabIndex = 2
        Me.lblTarCadu.Text = "Fecha Caducidad"
        '
        'pnlSpace30
        '
        Me.pnlSpace30.Auto_Size = False
        Me.pnlSpace30.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace30.ChangeDock = True
        Me.pnlSpace30.Control_Resize = False
        Me.pnlSpace30.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSpace30.isSpace = True
        Me.pnlSpace30.Location = New System.Drawing.Point(499, 0)
        Me.pnlSpace30.Name = "pnlSpace30"
        Me.pnlSpace30.numRows = 0
        Me.pnlSpace30.Reorder = True
        Me.pnlSpace30.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace30.TabIndex = 3
        '
        'mdfTarcadu
        '
        Me.mdfTarcadu.Alignemnt = System.Windows.Forms.HorizontalAlignment.Left
        Me.mdfTarcadu.Allow_Empty = True
        Me.mdfTarcadu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.mdfTarcadu.BackColor = System.Drawing.SystemColors.Control
        Me.mdfTarcadu.DataField = "TARCADU_CON2"
        Me.mdfTarcadu.DataTable = "C2"
        Me.mdfTarcadu.Descripcion = "Clase"
        Me.mdfTarcadu.Dock = System.Windows.Forms.DockStyle.Right
        Me.mdfTarcadu.FocoEnAgregar = False
        Me.mdfTarcadu.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.mdfTarcadu.Location = New System.Drawing.Point(505, 0)
        Me.mdfTarcadu.Mask = "##/##"
        Me.mdfTarcadu.MensajeIncorrectoCustom = Nothing
        Me.mdfTarcadu.Name = "mdfTarcadu"
        Me.mdfTarcadu.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.mdfTarcadu.ReadOnly_Data = False
        Me.mdfTarcadu.Regex = "[01-12]/[00-99]"
        Me.mdfTarcadu.RegexInput = "[0-9]"
        Me.mdfTarcadu.Size = New System.Drawing.Size(45, 26)
        Me.mdfTarcadu.TabIndex = 4
        Me.mdfTarcadu.Text_Data = "__/__"
        Me.mdfTarcadu.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.mdfTarcadu.TopPadding = 0
        Me.mdfTarcadu.Upper_Case = False
        Me.mdfTarcadu.Validate_on_lost_focus = True
        '
        'dtfTarjetaCond
        '
        Me.dtfTarjetaCond.Allow_Empty = True
        Me.dtfTarjetaCond.Allow_Negative = True
        Me.dtfTarjetaCond.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfTarjetaCond.BackColor = System.Drawing.SystemColors.Control
        Me.dtfTarjetaCond.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfTarjetaCond.DataField = "TARTI_CON2"
        Me.dtfTarjetaCond.DataTable = "C2"
        Me.dtfTarjetaCond.DB = Connection27
        Me.dtfTarjetaCond.Desc_Datafield = "NOMBRE"
        Me.dtfTarjetaCond.Desc_DBPK = "CODIGO"
        Me.dtfTarjetaCond.Desc_DBTable = "TARCREDI"
        Me.dtfTarjetaCond.Desc_Where = Nothing
        Me.dtfTarjetaCond.Desc_WhereObligatoria = Nothing
        Me.dtfTarjetaCond.Descripcion = "Tarjeta"
        Me.dtfTarjetaCond.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfTarjetaCond.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfTarjetaCond.ExtraSQL = ""
        Me.dtfTarjetaCond.FocoEnAgregar = False
        Me.dtfTarjetaCond.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfTarjetaCond.Formulario = Nothing
        Me.dtfTarjetaCond.Label_Space = 75
        Me.dtfTarjetaCond.Length_Data = 32767
        Me.dtfTarjetaCond.Location = New System.Drawing.Point(6, 304)
        Me.dtfTarjetaCond.Lupa = Nothing
        Me.dtfTarjetaCond.Max_Value = 0.0R
        Me.dtfTarjetaCond.MensajeIncorrectoCustom = Nothing
        Me.dtfTarjetaCond.Name = "dtfTarjetaCond"
        Me.dtfTarjetaCond.Null_on_Empty = True
        Me.dtfTarjetaCond.OpenForm = Nothing
        Me.dtfTarjetaCond.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfTarjetaCond.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfTarjetaCond.Query_on_Text_Changed = True
        Me.dtfTarjetaCond.ReadOnly_Data = False
        Me.dtfTarjetaCond.ReQuery = False
        Me.dtfTarjetaCond.ShowButton = True
        Me.dtfTarjetaCond.Size = New System.Drawing.Size(550, 26)
        Me.dtfTarjetaCond.TabIndex = 7
        Me.dtfTarjetaCond.Text_Data = ""
        Me.dtfTarjetaCond.Text_Data_Desc = ""
        Me.dtfTarjetaCond.Text_Width = 58
        Me.dtfTarjetaCond.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfTarjetaCond.TopPadding = 0
        Me.dtfTarjetaCond.Upper_Case = False
        Me.dtfTarjetaCond.Validate_on_lost_focus = True
        '
        'dtfEmailCond
        '
        Me.dtfEmailCond.Allow_Empty = True
        Me.dtfEmailCond.Allow_Negative = True
        Me.dtfEmailCond.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfEmailCond.BackColor = System.Drawing.SystemColors.Control
        Me.dtfEmailCond.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfEmailCond.DataField = "MAILCOND_CON2"
        Me.dtfEmailCond.DataTable = "C2"
        Me.dtfEmailCond.Descripcion = "Email"
        Me.dtfEmailCond.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfEmailCond.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfEmailCond.FocoEnAgregar = False
        Me.dtfEmailCond.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfEmailCond.Image = Nothing
        Me.dtfEmailCond.Label_Space = 75
        Me.dtfEmailCond.Length_Data = 32767
        Me.dtfEmailCond.Location = New System.Drawing.Point(6, 278)
        Me.dtfEmailCond.Max_Value = 0.0R
        Me.dtfEmailCond.MensajeIncorrectoCustom = Nothing
        Me.dtfEmailCond.Name = "dtfEmailCond"
        Me.dtfEmailCond.Null_on_Empty = True
        Me.dtfEmailCond.OpenForm = Nothing
        Me.dtfEmailCond.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfEmailCond.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfEmailCond.ReadOnly_Data = False
        Me.dtfEmailCond.Show_Button = True
        Me.dtfEmailCond.Size = New System.Drawing.Size(550, 26)
        Me.dtfEmailCond.TabIndex = 6
        Me.dtfEmailCond.Text_Data = ""
        Me.dtfEmailCond.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfEmailCond.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfEmailCond.TopPadding = 0
        Me.dtfEmailCond.Upper_Case = False
        Me.dtfEmailCond.Validate_on_lost_focus = True
        '
        'pnlPermiso
        '
        Me.pnlPermiso.Auto_Size = False
        Me.pnlPermiso.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlPermiso.ChangeDock = True
        Me.pnlPermiso.Control_Resize = False
        Me.pnlPermiso.Controls.Add(Me.pnlPermisoInf)
        Me.pnlPermiso.Controls.Add(Me.pnlPermisoSup)
        Me.pnlPermiso.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlPermiso.isSpace = False
        Me.pnlPermiso.Location = New System.Drawing.Point(6, 226)
        Me.pnlPermiso.Name = "pnlPermiso"
        Me.pnlPermiso.numRows = 2
        Me.pnlPermiso.Reorder = True
        Me.pnlPermiso.Size = New System.Drawing.Size(550, 52)
        Me.pnlPermiso.TabIndex = 5
        '
        'pnlPermisoInf
        '
        Me.pnlPermisoInf.Auto_Size = False
        Me.pnlPermisoInf.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlPermisoInf.ChangeDock = True
        Me.pnlPermisoInf.Control_Resize = False
        Me.pnlPermisoInf.Controls.Add(Me.dtfLuExpe)
        Me.pnlPermisoInf.Controls.Add(Me.pnlSpace29)
        Me.pnlPermisoInf.Controls.Add(Me.dtdFeExpe)
        Me.pnlPermisoInf.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlPermisoInf.isSpace = False
        Me.pnlPermisoInf.Location = New System.Drawing.Point(0, 26)
        Me.pnlPermisoInf.Name = "pnlPermisoInf"
        Me.pnlPermisoInf.numRows = 1
        Me.pnlPermisoInf.Reorder = True
        Me.pnlPermisoInf.Size = New System.Drawing.Size(550, 26)
        Me.pnlPermisoInf.TabIndex = 1
        '
        'dtfLuExpe
        '
        Me.dtfLuExpe.Allow_Empty = True
        Me.dtfLuExpe.Allow_Negative = True
        Me.dtfLuExpe.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfLuExpe.BackColor = System.Drawing.SystemColors.Control
        Me.dtfLuExpe.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfLuExpe.DataField = "LUEXPE_CON2"
        Me.dtfLuExpe.DataTable = "C2"
        Me.dtfLuExpe.Descripcion = "en"
        Me.dtfLuExpe.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfLuExpe.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfLuExpe.FocoEnAgregar = False
        Me.dtfLuExpe.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfLuExpe.Image = Nothing
        Me.dtfLuExpe.Label_Space = 25
        Me.dtfLuExpe.Length_Data = 32767
        Me.dtfLuExpe.Location = New System.Drawing.Point(171, 0)
        Me.dtfLuExpe.Max_Value = 0.0R
        Me.dtfLuExpe.MensajeIncorrectoCustom = Nothing
        Me.dtfLuExpe.Name = "dtfLuExpe"
        Me.dtfLuExpe.Null_on_Empty = True
        Me.dtfLuExpe.OpenForm = Nothing
        Me.dtfLuExpe.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfLuExpe.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfLuExpe.ReadOnly_Data = False
        Me.dtfLuExpe.Show_Button = False
        Me.dtfLuExpe.Size = New System.Drawing.Size(379, 26)
        Me.dtfLuExpe.TabIndex = 2
        Me.dtfLuExpe.Text_Data = ""
        Me.dtfLuExpe.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfLuExpe.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfLuExpe.TopPadding = 0
        Me.dtfLuExpe.Upper_Case = False
        Me.dtfLuExpe.Validate_on_lost_focus = True
        '
        'pnlSpace29
        '
        Me.pnlSpace29.Auto_Size = False
        Me.pnlSpace29.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace29.ChangeDock = True
        Me.pnlSpace29.Control_Resize = False
        Me.pnlSpace29.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace29.isSpace = True
        Me.pnlSpace29.Location = New System.Drawing.Point(165, 0)
        Me.pnlSpace29.Name = "pnlSpace29"
        Me.pnlSpace29.numRows = 0
        Me.pnlSpace29.Reorder = True
        Me.pnlSpace29.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace29.TabIndex = 1
        '
        'dtdFeExpe
        '
        Me.dtdFeExpe.Allow_Empty = True
        Me.dtdFeExpe.DataField = "FEEXPE_CON2"
        Me.dtdFeExpe.DataTable = "C2"
        Me.dtdFeExpe.Default_Value = New Date(2015, 9, 21, 0, 0, 0, 0)
        Me.dtdFeExpe.Descripcion = "Expedido el"
        Me.dtdFeExpe.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtdFeExpe.FocoEnAgregar = False
        Me.dtdFeExpe.Label_Space = 75
        Me.dtdFeExpe.Location = New System.Drawing.Point(0, 0)
        Me.dtdFeExpe.Max_Value = Nothing
        Me.dtdFeExpe.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdFeExpe.MensajeIncorrectoCustom = Nothing
        Me.dtdFeExpe.Min_Value = Nothing
        Me.dtdFeExpe.MinDate = New Date(CType(0, Long))
        Me.dtdFeExpe.MinimumSize = New System.Drawing.Size(165, 26)
        Me.dtdFeExpe.Name = "dtdFeExpe"
        Me.dtdFeExpe.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdFeExpe.ReadOnly_Data = False
        Me.dtdFeExpe.Size = New System.Drawing.Size(165, 26)
        Me.dtdFeExpe.TabIndex = 0
        Me.dtdFeExpe.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdFeExpe.Validate_on_lost_focus = True
        Me.dtdFeExpe.Value_Data = New Date(2015, 9, 21, 0, 0, 0, 0)
        '
        'pnlPermisoSup
        '
        Me.pnlPermisoSup.Auto_Size = False
        Me.pnlPermisoSup.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlPermisoSup.ChangeDock = True
        Me.pnlPermisoSup.Control_Resize = False
        Me.pnlPermisoSup.Controls.Add(Me.dtfPermiso)
        Me.pnlPermisoSup.Controls.Add(Me.pnlSpace28)
        Me.pnlPermisoSup.Controls.Add(Me.dtfClase)
        Me.pnlPermisoSup.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlPermisoSup.isSpace = False
        Me.pnlPermisoSup.Location = New System.Drawing.Point(0, 0)
        Me.pnlPermisoSup.Name = "pnlPermisoSup"
        Me.pnlPermisoSup.numRows = 1
        Me.pnlPermisoSup.Reorder = True
        Me.pnlPermisoSup.Size = New System.Drawing.Size(550, 26)
        Me.pnlPermisoSup.TabIndex = 0
        '
        'dtfPermiso
        '
        Me.dtfPermiso.Allow_Empty = True
        Me.dtfPermiso.Allow_Negative = True
        Me.dtfPermiso.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfPermiso.BackColor = System.Drawing.SystemColors.Control
        Me.dtfPermiso.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfPermiso.DataField = "PERMISO_CON2"
        Me.dtfPermiso.DataTable = "C2"
        Me.dtfPermiso.Descripcion = "Permiso"
        Me.dtfPermiso.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfPermiso.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfPermiso.FocoEnAgregar = False
        Me.dtfPermiso.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfPermiso.Image = Nothing
        Me.dtfPermiso.Label_Space = 75
        Me.dtfPermiso.Length_Data = 32767
        Me.dtfPermiso.Location = New System.Drawing.Point(0, 0)
        Me.dtfPermiso.Max_Value = 0.0R
        Me.dtfPermiso.MensajeIncorrectoCustom = Nothing
        Me.dtfPermiso.Name = "dtfPermiso"
        Me.dtfPermiso.Null_on_Empty = True
        Me.dtfPermiso.OpenForm = Nothing
        Me.dtfPermiso.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfPermiso.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfPermiso.ReadOnly_Data = False
        Me.dtfPermiso.Show_Button = False
        Me.dtfPermiso.Size = New System.Drawing.Size(379, 26)
        Me.dtfPermiso.TabIndex = 0
        Me.dtfPermiso.Text_Data = ""
        Me.dtfPermiso.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfPermiso.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfPermiso.TopPadding = 0
        Me.dtfPermiso.Upper_Case = False
        Me.dtfPermiso.Validate_on_lost_focus = True
        '
        'pnlSpace28
        '
        Me.pnlSpace28.Auto_Size = False
        Me.pnlSpace28.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace28.ChangeDock = True
        Me.pnlSpace28.Control_Resize = False
        Me.pnlSpace28.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSpace28.isSpace = True
        Me.pnlSpace28.Location = New System.Drawing.Point(379, 0)
        Me.pnlSpace28.Name = "pnlSpace28"
        Me.pnlSpace28.numRows = 0
        Me.pnlSpace28.Reorder = True
        Me.pnlSpace28.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace28.TabIndex = 1
        '
        'dtfClase
        '
        Me.dtfClase.Allow_Empty = True
        Me.dtfClase.Allow_Negative = True
        Me.dtfClase.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfClase.BackColor = System.Drawing.SystemColors.Control
        Me.dtfClase.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfClase.DataField = "CLASE_CON2"
        Me.dtfClase.DataTable = "C2"
        Me.dtfClase.Descripcion = "Clase"
        Me.dtfClase.Dock = System.Windows.Forms.DockStyle.Right
        Me.dtfClase.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfClase.FocoEnAgregar = False
        Me.dtfClase.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfClase.Image = Nothing
        Me.dtfClase.Label_Space = 75
        Me.dtfClase.Length_Data = 32767
        Me.dtfClase.Location = New System.Drawing.Point(385, 0)
        Me.dtfClase.Max_Value = 0.0R
        Me.dtfClase.MensajeIncorrectoCustom = Nothing
        Me.dtfClase.Name = "dtfClase"
        Me.dtfClase.Null_on_Empty = True
        Me.dtfClase.OpenForm = Nothing
        Me.dtfClase.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfClase.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfClase.ReadOnly_Data = False
        Me.dtfClase.Show_Button = False
        Me.dtfClase.Size = New System.Drawing.Size(165, 26)
        Me.dtfClase.TabIndex = 2
        Me.dtfClase.Text_Data = ""
        Me.dtfClase.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfClase.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfClase.TopPadding = 0
        Me.dtfClase.Upper_Case = False
        Me.dtfClase.Validate_on_lost_focus = True
        '
        'pnlLuNace
        '
        Me.pnlLuNace.Auto_Size = False
        Me.pnlLuNace.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlLuNace.ChangeDock = True
        Me.pnlLuNace.Control_Resize = False
        Me.pnlLuNace.Controls.Add(Me.dtfLuNace)
        Me.pnlLuNace.Controls.Add(Me.pnlSpace27)
        Me.pnlLuNace.Controls.Add(Me.dtdFechaNac)
        Me.pnlLuNace.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlLuNace.isSpace = False
        Me.pnlLuNace.Location = New System.Drawing.Point(6, 200)
        Me.pnlLuNace.Name = "pnlLuNace"
        Me.pnlLuNace.numRows = 1
        Me.pnlLuNace.Reorder = True
        Me.pnlLuNace.Size = New System.Drawing.Size(550, 26)
        Me.pnlLuNace.TabIndex = 4
        '
        'dtfLuNace
        '
        Me.dtfLuNace.Allow_Empty = True
        Me.dtfLuNace.Allow_Negative = True
        Me.dtfLuNace.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfLuNace.BackColor = System.Drawing.SystemColors.Control
        Me.dtfLuNace.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfLuNace.DataField = "LUNACI_CON2"
        Me.dtfLuNace.DataTable = "C2"
        Me.dtfLuNace.Descripcion = "Lugar Nac."
        Me.dtfLuNace.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfLuNace.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfLuNace.FocoEnAgregar = False
        Me.dtfLuNace.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfLuNace.Image = Nothing
        Me.dtfLuNace.Label_Space = 75
        Me.dtfLuNace.Length_Data = 32767
        Me.dtfLuNace.Location = New System.Drawing.Point(0, 0)
        Me.dtfLuNace.Max_Value = 0.0R
        Me.dtfLuNace.MensajeIncorrectoCustom = Nothing
        Me.dtfLuNace.Name = "dtfLuNace"
        Me.dtfLuNace.Null_on_Empty = True
        Me.dtfLuNace.OpenForm = Nothing
        Me.dtfLuNace.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfLuNace.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfLuNace.ReadOnly_Data = False
        Me.dtfLuNace.Show_Button = False
        Me.dtfLuNace.Size = New System.Drawing.Size(364, 26)
        Me.dtfLuNace.TabIndex = 0
        Me.dtfLuNace.Text_Data = ""
        Me.dtfLuNace.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfLuNace.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfLuNace.TopPadding = 0
        Me.dtfLuNace.Upper_Case = False
        Me.dtfLuNace.Validate_on_lost_focus = True
        '
        'pnlSpace27
        '
        Me.pnlSpace27.Auto_Size = False
        Me.pnlSpace27.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace27.ChangeDock = True
        Me.pnlSpace27.Control_Resize = False
        Me.pnlSpace27.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSpace27.isSpace = True
        Me.pnlSpace27.Location = New System.Drawing.Point(364, 0)
        Me.pnlSpace27.Name = "pnlSpace27"
        Me.pnlSpace27.numRows = 0
        Me.pnlSpace27.Reorder = True
        Me.pnlSpace27.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace27.TabIndex = 1
        '
        'dtdFechaNac
        '
        Me.dtdFechaNac.Allow_Empty = True
        Me.dtdFechaNac.DataField = "FENACI_CON2"
        Me.dtdFechaNac.DataTable = "C2"
        Me.dtdFechaNac.Default_Value = New Date(2015, 9, 21, 0, 0, 0, 0)
        Me.dtdFechaNac.Descripcion = "F. Nacimiento"
        Me.dtdFechaNac.Dock = System.Windows.Forms.DockStyle.Right
        Me.dtdFechaNac.FocoEnAgregar = False
        Me.dtdFechaNac.Label_Space = 90
        Me.dtdFechaNac.Location = New System.Drawing.Point(370, 0)
        Me.dtdFechaNac.Max_Value = Nothing
        Me.dtdFechaNac.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdFechaNac.MensajeIncorrectoCustom = Nothing
        Me.dtdFechaNac.Min_Value = Nothing
        Me.dtdFechaNac.MinDate = New Date(CType(0, Long))
        Me.dtdFechaNac.MinimumSize = New System.Drawing.Size(180, 26)
        Me.dtdFechaNac.Name = "dtdFechaNac"
        Me.dtdFechaNac.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdFechaNac.ReadOnly_Data = False
        Me.dtdFechaNac.Size = New System.Drawing.Size(180, 26)
        Me.dtdFechaNac.TabIndex = 2
        Me.dtdFechaNac.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdFechaNac.Validate_on_lost_focus = True
        Me.dtdFechaNac.Value_Data = New Date(2015, 9, 21, 0, 0, 0, 0)
        '
        'pnlNifTelf
        '
        Me.pnlNifTelf.Auto_Size = False
        Me.pnlNifTelf.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlNifTelf.ChangeDock = False
        Me.pnlNifTelf.Control_Resize = False
        Me.pnlNifTelf.Controls.Add(Me.dtfNIFCond)
        Me.pnlNifTelf.Controls.Add(Me.pnlSpace25)
        Me.pnlNifTelf.Controls.Add(Me.dtfTelfCond)
        Me.pnlNifTelf.Controls.Add(Me.pnlSpace24)
        Me.pnlNifTelf.Controls.Add(Me.dtfTelfCond2)
        Me.pnlNifTelf.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlNifTelf.isSpace = False
        Me.pnlNifTelf.Location = New System.Drawing.Point(6, 174)
        Me.pnlNifTelf.Name = "pnlNifTelf"
        Me.pnlNifTelf.numRows = 1
        Me.pnlNifTelf.Reorder = True
        Me.pnlNifTelf.Size = New System.Drawing.Size(550, 26)
        Me.pnlNifTelf.TabIndex = 3
        '
        'dtfNIFCond
        '
        Me.dtfNIFCond.Allow_Empty = True
        Me.dtfNIFCond.Allow_Negative = True
        Me.dtfNIFCond.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfNIFCond.BackColor = System.Drawing.SystemColors.Control
        Me.dtfNIFCond.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfNIFCond.DataField = "DNICOND_CON2"
        Me.dtfNIFCond.DataTable = "C2"
        Me.dtfNIFCond.Descripcion = "NIF"
        Me.dtfNIFCond.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfNIFCond.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfNIFCond.FocoEnAgregar = False
        Me.dtfNIFCond.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfNIFCond.Image = Nothing
        Me.dtfNIFCond.Label_Space = 75
        Me.dtfNIFCond.Length_Data = 32767
        Me.dtfNIFCond.Location = New System.Drawing.Point(0, 0)
        Me.dtfNIFCond.Max_Value = 0.0R
        Me.dtfNIFCond.MensajeIncorrectoCustom = Nothing
        Me.dtfNIFCond.Name = "dtfNIFCond"
        Me.dtfNIFCond.Null_on_Empty = True
        Me.dtfNIFCond.OpenForm = Nothing
        Me.dtfNIFCond.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfNIFCond.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfNIFCond.ReadOnly_Data = False
        Me.dtfNIFCond.Show_Button = False
        Me.dtfNIFCond.Size = New System.Drawing.Size(258, 26)
        Me.dtfNIFCond.TabIndex = 0
        Me.dtfNIFCond.Text_Data = ""
        Me.dtfNIFCond.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfNIFCond.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfNIFCond.TopPadding = 0
        Me.dtfNIFCond.Upper_Case = False
        Me.dtfNIFCond.Validate_on_lost_focus = True
        '
        'pnlSpace25
        '
        Me.pnlSpace25.Auto_Size = False
        Me.pnlSpace25.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace25.ChangeDock = True
        Me.pnlSpace25.Control_Resize = False
        Me.pnlSpace25.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSpace25.isSpace = True
        Me.pnlSpace25.Location = New System.Drawing.Point(258, 0)
        Me.pnlSpace25.Name = "pnlSpace25"
        Me.pnlSpace25.numRows = 0
        Me.pnlSpace25.Reorder = True
        Me.pnlSpace25.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace25.TabIndex = 1
        '
        'dtfTelfCond
        '
        Me.dtfTelfCond.Allow_Empty = True
        Me.dtfTelfCond.Allow_Negative = True
        Me.dtfTelfCond.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfTelfCond.BackColor = System.Drawing.SystemColors.Control
        Me.dtfTelfCond.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfTelfCond.DataField = "TELCOND_CON2"
        Me.dtfTelfCond.DataTable = "C2"
        Me.dtfTelfCond.Descripcion = "Telefono"
        Me.dtfTelfCond.Dock = System.Windows.Forms.DockStyle.Right
        Me.dtfTelfCond.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfTelfCond.FocoEnAgregar = False
        Me.dtfTelfCond.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfTelfCond.Image = Nothing
        Me.dtfTelfCond.Label_Space = 60
        Me.dtfTelfCond.Length_Data = 32767
        Me.dtfTelfCond.Location = New System.Drawing.Point(264, 0)
        Me.dtfTelfCond.Max_Value = 0.0R
        Me.dtfTelfCond.MensajeIncorrectoCustom = Nothing
        Me.dtfTelfCond.Name = "dtfTelfCond"
        Me.dtfTelfCond.Null_on_Empty = True
        Me.dtfTelfCond.OpenForm = Nothing
        Me.dtfTelfCond.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfTelfCond.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfTelfCond.ReadOnly_Data = False
        Me.dtfTelfCond.Show_Button = False
        Me.dtfTelfCond.Size = New System.Drawing.Size(170, 26)
        Me.dtfTelfCond.TabIndex = 2
        Me.dtfTelfCond.Text_Data = ""
        Me.dtfTelfCond.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfTelfCond.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfTelfCond.TopPadding = 0
        Me.dtfTelfCond.Upper_Case = False
        Me.dtfTelfCond.Validate_on_lost_focus = True
        '
        'pnlSpace24
        '
        Me.pnlSpace24.Auto_Size = False
        Me.pnlSpace24.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace24.ChangeDock = True
        Me.pnlSpace24.Control_Resize = False
        Me.pnlSpace24.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSpace24.isSpace = True
        Me.pnlSpace24.Location = New System.Drawing.Point(434, 0)
        Me.pnlSpace24.Name = "pnlSpace24"
        Me.pnlSpace24.numRows = 0
        Me.pnlSpace24.Reorder = True
        Me.pnlSpace24.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace24.TabIndex = 3
        '
        'dtfTelfCond2
        '
        Me.dtfTelfCond2.Allow_Empty = True
        Me.dtfTelfCond2.Allow_Negative = True
        Me.dtfTelfCond2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfTelfCond2.BackColor = System.Drawing.SystemColors.Control
        Me.dtfTelfCond2.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfTelfCond2.DataField = "TEL2COND_CON2"
        Me.dtfTelfCond2.DataTable = "C2"
        Me.dtfTelfCond2.Descripcion = "Telefono"
        Me.dtfTelfCond2.Dock = System.Windows.Forms.DockStyle.Right
        Me.dtfTelfCond2.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfTelfCond2.FocoEnAgregar = False
        Me.dtfTelfCond2.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfTelfCond2.Length_Data = 32767
        Me.dtfTelfCond2.Location = New System.Drawing.Point(440, 0)
        Me.dtfTelfCond2.Max_Value = 0.0R
        Me.dtfTelfCond2.MensajeIncorrectoCustom = Nothing
        Me.dtfTelfCond2.Name = "dtfTelfCond2"
        Me.dtfTelfCond2.Null_on_Empty = True
        Me.dtfTelfCond2.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfTelfCond2.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfTelfCond2.ReadOnly_Data = False
        Me.dtfTelfCond2.Size = New System.Drawing.Size(110, 26)
        Me.dtfTelfCond2.TabIndex = 4
        Me.dtfTelfCond2.Text_Data = ""
        Me.dtfTelfCond2.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfTelfCond2.TopPadding = 0
        Me.dtfTelfCond2.Upper_Case = False
        Me.dtfTelfCond2.Validate_on_lost_focus = True
        '
        'dtdDirCond
        '
        Me.dtdDirCond.AutoSize = True
        Me.dtdDirCond.Datafield_CP = "CPCOND_CON2"
        Me.dtdDirCond.Datafield_Direccion = "DIRCOND_CON2"
        Me.dtdDirCond.Datafield_Direccion2L = Nothing
        Me.dtdDirCond.Datafield_GPS = Nothing
        Me.dtdDirCond.Datafield_Pais = "PAISCOND_CON2"
        Me.dtdDirCond.Datafield_Poblacion = "POCOND_CON2"
        Me.dtdDirCond.Datafield_Provincia = "PROVCOND_CON2"
        Me.dtdDirCond.Datatable_CP = "C2"
        Me.dtdDirCond.Datatable_Direccion = "C2"
        Me.dtdDirCond.Datatable_Direccion2L = ""
        Me.dtdDirCond.Datatable_GPS = ""
        Me.dtdDirCond.Datatable_Pais = "C2"
        Me.dtdDirCond.Datatable_Poblacion = "C2"
        Me.dtdDirCond.Datatable_Provincia = "C2"
        Me.dtdDirCond.Descripcion = "Direccion Conductor"
        Me.dtdDirCond.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtdDirCond.FocoEnAgregar = False
        Me.dtdDirCond.Label_Space = 75
        Me.dtdDirCond.Location = New System.Drawing.Point(6, 70)
        Me.dtdDirCond.Name = "dtdDirCond"
        Me.dtdDirCond.ReadOnly_Data = False
        Me.dtdDirCond.requeryCP = False
        Me.dtdDirCond.Show_Dir2L = False
        Me.dtdDirCond.Show_GPS = False
        Me.dtdDirCond.Show_Pais = True
        Me.dtdDirCond.Size = New System.Drawing.Size(550, 104)
        Me.dtdDirCond.TabIndex = 2
        Me.dtdDirCond.Text_Data_CP = ""
        Me.dtdDirCond.Text_Data_Direccion = ""
        Me.dtdDirCond.Text_Data_Direccion2L = ""
        Me.dtdDirCond.Text_Data_GPS = ""
        Me.dtdDirCond.Text_Data_Pais = ""
        Me.dtdDirCond.Text_Data_Poblacion = ""
        Me.dtdDirCond.Text_Data_Provincia = ""
        '
        'dtfNombreCond
        '
        Me.dtfNombreCond.Allow_Empty = True
        Me.dtfNombreCond.Allow_Negative = True
        Me.dtfNombreCond.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfNombreCond.BackColor = System.Drawing.SystemColors.Control
        Me.dtfNombreCond.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfNombreCond.DataField = "NOMBRE_CON1"
        Me.dtfNombreCond.DataTable = "C1"
        Me.dtfNombreCond.Descripcion = "Nombre"
        Me.dtfNombreCond.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfNombreCond.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfNombreCond.FocoEnAgregar = False
        Me.dtfNombreCond.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfNombreCond.Image = Nothing
        Me.dtfNombreCond.Label_Space = 75
        Me.dtfNombreCond.Length_Data = 32767
        Me.dtfNombreCond.Location = New System.Drawing.Point(6, 44)
        Me.dtfNombreCond.Max_Value = 0.0R
        Me.dtfNombreCond.MensajeIncorrectoCustom = Nothing
        Me.dtfNombreCond.Name = "dtfNombreCond"
        Me.dtfNombreCond.Null_on_Empty = True
        Me.dtfNombreCond.OpenForm = Nothing
        Me.dtfNombreCond.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfNombreCond.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfNombreCond.ReadOnly_Data = False
        Me.dtfNombreCond.Show_Button = False
        Me.dtfNombreCond.Size = New System.Drawing.Size(550, 26)
        Me.dtfNombreCond.TabIndex = 1
        Me.dtfNombreCond.Text_Data = ""
        Me.dtfNombreCond.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfNombreCond.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfNombreCond.TopPadding = 0
        Me.dtfNombreCond.Upper_Case = False
        Me.dtfNombreCond.Validate_on_lost_focus = True
        '
        'pnlConductor
        '
        Me.pnlConductor.Auto_Size = False
        Me.pnlConductor.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlConductor.ChangeDock = False
        Me.pnlConductor.Control_Resize = False
        Me.pnlConductor.Controls.Add(Me.dtfConductorDetalles)
        Me.pnlConductor.Controls.Add(Me.pnlSpace23)
        Me.pnlConductor.Controls.Add(Me.btnCargarCond)
        Me.pnlConductor.Controls.Add(Me.pnlSpace26)
        Me.pnlConductor.Controls.Add(Me.btnGuardar)
        Me.pnlConductor.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlConductor.isSpace = False
        Me.pnlConductor.Location = New System.Drawing.Point(6, 18)
        Me.pnlConductor.Name = "pnlConductor"
        Me.pnlConductor.numRows = 1
        Me.pnlConductor.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.pnlConductor.Reorder = True
        Me.pnlConductor.Size = New System.Drawing.Size(550, 26)
        Me.pnlConductor.TabIndex = 0
        '
        'dtfConductorDetalles
        '
        Me.dtfConductorDetalles.Allow_Empty = True
        Me.dtfConductorDetalles.Allow_Negative = True
        Me.dtfConductorDetalles.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfConductorDetalles.BackColor = System.Drawing.SystemColors.Control
        Me.dtfConductorDetalles.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfConductorDetalles.DataField = "CONDUCTOR_CON1"
        Me.dtfConductorDetalles.DataTable = "C1"
        Me.dtfConductorDetalles.DB = Connection28
        Me.dtfConductorDetalles.Desc_Datafield = "NOMBRE"
        Me.dtfConductorDetalles.Desc_DBPK = "NUMERO_CLI"
        Me.dtfConductorDetalles.Desc_DBTable = "CLIENTES1"
        Me.dtfConductorDetalles.Desc_Where = Nothing
        Me.dtfConductorDetalles.Desc_WhereObligatoria = Nothing
        Me.dtfConductorDetalles.Descripcion = "Conductor"
        Me.dtfConductorDetalles.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfConductorDetalles.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfConductorDetalles.ExtraSQL = ""
        Me.dtfConductorDetalles.FocoEnAgregar = False
        Me.dtfConductorDetalles.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfConductorDetalles.Formulario = Nothing
        Me.dtfConductorDetalles.Label_Space = 75
        Me.dtfConductorDetalles.Length_Data = 32767
        Me.dtfConductorDetalles.Location = New System.Drawing.Point(0, 0)
        Me.dtfConductorDetalles.Lupa = Nothing
        Me.dtfConductorDetalles.Max_Value = 0.0R
        Me.dtfConductorDetalles.MensajeIncorrectoCustom = Nothing
        Me.dtfConductorDetalles.Name = "dtfConductorDetalles"
        Me.dtfConductorDetalles.Null_on_Empty = True
        Me.dtfConductorDetalles.OpenForm = Nothing
        Me.dtfConductorDetalles.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.dtfConductorDetalles.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfConductorDetalles.Query_on_Text_Changed = True
        Me.dtfConductorDetalles.ReadOnly_Data = False
        Me.dtfConductorDetalles.ReQuery = False
        Me.dtfConductorDetalles.ShowButton = True
        Me.dtfConductorDetalles.Size = New System.Drawing.Size(435, 26)
        Me.dtfConductorDetalles.TabIndex = 0
        Me.dtfConductorDetalles.Text_Data = ""
        Me.dtfConductorDetalles.Text_Data_Desc = ""
        Me.dtfConductorDetalles.Text_Width = 58
        Me.dtfConductorDetalles.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfConductorDetalles.TopPadding = 0
        Me.dtfConductorDetalles.Upper_Case = False
        Me.dtfConductorDetalles.Validate_on_lost_focus = True
        '
        'pnlSpace23
        '
        Me.pnlSpace23.Auto_Size = False
        Me.pnlSpace23.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace23.ChangeDock = True
        Me.pnlSpace23.Control_Resize = False
        Me.pnlSpace23.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSpace23.isSpace = True
        Me.pnlSpace23.Location = New System.Drawing.Point(435, 0)
        Me.pnlSpace23.Name = "pnlSpace23"
        Me.pnlSpace23.numRows = 0
        Me.pnlSpace23.Reorder = True
        Me.pnlSpace23.Size = New System.Drawing.Size(6, 20)
        Me.pnlSpace23.TabIndex = 1
        '
        'btnCargarCond
        '
        Me.btnCargarCond.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnCargarCond.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnCargarCond.Location = New System.Drawing.Point(441, 0)
        Me.btnCargarCond.Name = "btnCargarCond"
        Me.btnCargarCond.Size = New System.Drawing.Size(44, 20)
        Me.btnCargarCond.TabIndex = 2
        Me.btnCargarCond.Text = "Cargar"
        Me.btnCargarCond.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.btnCargarCond.ThemeName = "Windows8"
        '
        'pnlSpace26
        '
        Me.pnlSpace26.Auto_Size = False
        Me.pnlSpace26.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace26.ChangeDock = True
        Me.pnlSpace26.Control_Resize = False
        Me.pnlSpace26.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSpace26.isSpace = True
        Me.pnlSpace26.Location = New System.Drawing.Point(485, 0)
        Me.pnlSpace26.Name = "pnlSpace26"
        Me.pnlSpace26.numRows = 0
        Me.pnlSpace26.Reorder = True
        Me.pnlSpace26.Size = New System.Drawing.Size(6, 20)
        Me.pnlSpace26.TabIndex = 3
        '
        'btnGuardar
        '
        Me.btnGuardar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnGuardar.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnGuardar.Location = New System.Drawing.Point(491, 0)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(59, 20)
        Me.btnGuardar.TabIndex = 4
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.btnGuardar.ThemeName = "Windows8"
        '
        'pnlCabeceraConductores
        '
        Me.pnlCabeceraConductores.Auto_Size = False
        Me.pnlCabeceraConductores.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlCabeceraConductores.ChangeDock = False
        Me.pnlCabeceraConductores.Control_Resize = False
        Me.pnlCabeceraConductores.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCabeceraConductores.isSpace = False
        Me.pnlCabeceraConductores.Location = New System.Drawing.Point(0, 0)
        Me.pnlCabeceraConductores.Name = "pnlCabeceraConductores"
        Me.pnlCabeceraConductores.numRows = 3
        Me.pnlCabeceraConductores.Reorder = True
        Me.pnlCabeceraConductores.Size = New System.Drawing.Size(1138, 78)
        Me.pnlCabeceraConductores.TabIndex = 1
        '
        'pvpCierre
        '
        Me.pvpCierre.Controls.Add(Me.pnlCierreDer)
        Me.pvpCierre.Controls.Add(Me.pnlCierreIzq)
        Me.pvpCierre.Controls.Add(Me.pnlCabeceraCierre)
        Me.pvpCierre.ItemSize = New System.Drawing.SizeF(83.0!, 23.0!)
        Me.pvpCierre.Location = New System.Drawing.Point(129, 5)
        Me.pvpCierre.Name = "pvpCierre"
        Me.pvpCierre.PanelCabezeraContainer = Me.pnlCabeceraCierre
        Me.pvpCierre.Size = New System.Drawing.Size(1138, 559)
        Me.pvpCierre.Text = "Datos Cierre"
        '
        'pnlCierreDer
        '
        Me.pnlCierreDer.Auto_Size = False
        Me.pnlCierreDer.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlCierreDer.ChangeDock = False
        Me.pnlCierreDer.Control_Resize = False
        Me.pnlCierreDer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlCierreDer.isSpace = False
        Me.pnlCierreDer.Location = New System.Drawing.Point(472, 78)
        Me.pnlCierreDer.Name = "pnlCierreDer"
        Me.pnlCierreDer.numRows = 0
        Me.pnlCierreDer.Padding = New System.Windows.Forms.Padding(3)
        Me.pnlCierreDer.Reorder = True
        Me.pnlCierreDer.Size = New System.Drawing.Size(666, 481)
        Me.pnlCierreDer.TabIndex = 2
        '
        'pnlCierreIzq
        '
        Me.pnlCierreIzq.Auto_Size = False
        Me.pnlCierreIzq.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlCierreIzq.ChangeDock = False
        Me.pnlCierreIzq.Control_Resize = False
        Me.pnlCierreIzq.Controls.Add(Me.rdgDevolucion)
        Me.pnlCierreIzq.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlCierreIzq.isSpace = False
        Me.pnlCierreIzq.Location = New System.Drawing.Point(0, 78)
        Me.pnlCierreIzq.Name = "pnlCierreIzq"
        Me.pnlCierreIzq.numRows = 0
        Me.pnlCierreIzq.Padding = New System.Windows.Forms.Padding(3)
        Me.pnlCierreIzq.Reorder = True
        Me.pnlCierreIzq.Size = New System.Drawing.Size(472, 481)
        Me.pnlCierreIzq.TabIndex = 3
        '
        'rdgDevolucion
        '
        Me.rdgDevolucion.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.rdgDevolucion.Controls.Add(Me.pnlKmLitrosCierre)
        Me.rdgDevolucion.Controls.Add(Me.btnRecalcularCierre)
        Me.rdgDevolucion.Controls.Add(Me.radConRecalc)
        Me.rdgDevolucion.Controls.Add(Me.radSinRecalc)
        Me.rdgDevolucion.Controls.Add(Me.pnlFacturHasta)
        Me.rdgDevolucion.Controls.Add(Me.pnlFacturDesde)
        Me.rdgDevolucion.Controls.Add(Me.pnlDatosRetorno)
        Me.rdgDevolucion.DataField = Nothing
        Me.rdgDevolucion.DataTable = ""
        Me.rdgDevolucion.DefaultIndex = Nothing
        Me.rdgDevolucion.Descripcion = "Datos de Devolucion"
        Me.rdgDevolucion.Dock = System.Windows.Forms.DockStyle.Top
        Me.rdgDevolucion.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.rdgDevolucion.HeaderText = "Datos de Devolucion"
        Me.rdgDevolucion.Index = "1"
        Me.rdgDevolucion.Location = New System.Drawing.Point(3, 3)
        Me.rdgDevolucion.Name = "rdgDevolucion"
        Me.rdgDevolucion.numRows = 10
        Me.rdgDevolucion.Padding = New System.Windows.Forms.Padding(6, 18, 6, 6)
        Me.rdgDevolucion.Reorder = True
        Me.rdgDevolucion.Size = New System.Drawing.Size(466, 280)
        Me.rdgDevolucion.TabIndex = 0
        Me.rdgDevolucion.Text = "Datos de Devolucion"
        Me.rdgDevolucion.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.rdgDevolucion.ThemeName = "Windows8"
        Me.rdgDevolucion.Title = "Datos de Devolucion"
        '
        'pnlKmLitrosCierre
        '
        Me.pnlKmLitrosCierre.Auto_Size = False
        Me.pnlKmLitrosCierre.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlKmLitrosCierre.ChangeDock = True
        Me.pnlKmLitrosCierre.Control_Resize = False
        Me.pnlKmLitrosCierre.Controls.Add(Me.trbLitrosLlega)
        Me.pnlKmLitrosCierre.Controls.Add(Me.pnlCombustibleCierre)
        Me.pnlKmLitrosCierre.Controls.Add(Me.pnlKilometrosCierre)
        Me.pnlKmLitrosCierre.Controls.Add(Me.pnlLabelsCierre)
        Me.pnlKmLitrosCierre.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlKmLitrosCierre.isSpace = False
        Me.pnlKmLitrosCierre.Location = New System.Drawing.Point(6, 144)
        Me.pnlKmLitrosCierre.Name = "pnlKmLitrosCierre"
        Me.pnlKmLitrosCierre.numRows = 5
        Me.pnlKmLitrosCierre.Reorder = True
        Me.pnlKmLitrosCierre.Size = New System.Drawing.Size(454, 130)
        Me.pnlKmLitrosCierre.TabIndex = 6
        '
        'trbLitrosLlega
        '
        Me.trbLitrosLlega.Descripcion = ""
        Me.trbLitrosLlega.Dock = System.Windows.Forms.DockStyle.Top
        Me.trbLitrosLlega.FocoEnAgregar = False
        Me.trbLitrosLlega.LitrosAct = 0.0R
        Me.trbLitrosLlega.Location = New System.Drawing.Point(0, 78)
        Me.trbLitrosLlega.Name = "trbLitrosLlega"
        Me.trbLitrosLlega.Octavos = 0
        Me.trbLitrosLlega.Size = New System.Drawing.Size(454, 49)
        Me.trbLitrosLlega.TabIndex = 3
        Me.trbLitrosLlega.TotalLitros = 0.0R
        '
        'pnlCombustibleCierre
        '
        Me.pnlCombustibleCierre.Auto_Size = False
        Me.pnlCombustibleCierre.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlCombustibleCierre.ChangeDock = True
        Me.pnlCombustibleCierre.Control_Resize = False
        Me.pnlCombustibleCierre.Controls.Add(Me.dtfDiferenciaCombus)
        Me.pnlCombustibleCierre.Controls.Add(Me.pnlSpace45)
        Me.pnlCombustibleCierre.Controls.Add(Me.pnlSpace44)
        Me.pnlCombustibleCierre.Controls.Add(Me.mdfOctavosLlegadaCierre)
        Me.pnlCombustibleCierre.Controls.Add(Me.pnlSpace43)
        Me.pnlCombustibleCierre.Controls.Add(Me.dtfCombusLlegadaCierre)
        Me.pnlCombustibleCierre.Controls.Add(Me.pnlSpace42)
        Me.pnlCombustibleCierre.Controls.Add(Me.mdfOctavosSalicaCierre)
        Me.pnlCombustibleCierre.Controls.Add(Me.pnlSpace41)
        Me.pnlCombustibleCierre.Controls.Add(Me.dtfCombusSalidaCierre)
        Me.pnlCombustibleCierre.Controls.Add(Me.dtfCargosCombus)
        Me.pnlCombustibleCierre.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCombustibleCierre.isSpace = False
        Me.pnlCombustibleCierre.Location = New System.Drawing.Point(0, 52)
        Me.pnlCombustibleCierre.Name = "pnlCombustibleCierre"
        Me.pnlCombustibleCierre.numRows = 1
        Me.pnlCombustibleCierre.Reorder = True
        Me.pnlCombustibleCierre.Size = New System.Drawing.Size(454, 26)
        Me.pnlCombustibleCierre.TabIndex = 2
        '
        'dtfDiferenciaCombus
        '
        Me.dtfDiferenciaCombus.Allow_Empty = True
        Me.dtfDiferenciaCombus.Allow_Negative = True
        Me.dtfDiferenciaCombus.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfDiferenciaCombus.BackColor = System.Drawing.SystemColors.Control
        Me.dtfDiferenciaCombus.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfDiferenciaCombus.DataField = Nothing
        Me.dtfDiferenciaCombus.DataTable = ""
        Me.dtfDiferenciaCombus.Descripcion = Nothing
        Me.dtfDiferenciaCombus.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfDiferenciaCombus.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfDiferenciaCombus.FocoEnAgregar = False
        Me.dtfDiferenciaCombus.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfDiferenciaCombus.Length_Data = 32767
        Me.dtfDiferenciaCombus.Location = New System.Drawing.Point(259, 0)
        Me.dtfDiferenciaCombus.Max_Value = 0.0R
        Me.dtfDiferenciaCombus.MensajeIncorrectoCustom = Nothing
        Me.dtfDiferenciaCombus.Name = "dtfDiferenciaCombus"
        Me.dtfDiferenciaCombus.Null_on_Empty = True
        Me.dtfDiferenciaCombus.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfDiferenciaCombus.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfDiferenciaCombus.ReadOnly_Data = True
        Me.dtfDiferenciaCombus.Size = New System.Drawing.Size(106, 26)
        Me.dtfDiferenciaCombus.TabIndex = 8
        Me.dtfDiferenciaCombus.TabStop = False
        Me.dtfDiferenciaCombus.Text_Data = ""
        Me.dtfDiferenciaCombus.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfDiferenciaCombus.TopPadding = 0
        Me.dtfDiferenciaCombus.Upper_Case = False
        Me.dtfDiferenciaCombus.Validate_on_lost_focus = True
        '
        'pnlSpace45
        '
        Me.pnlSpace45.Auto_Size = False
        Me.pnlSpace45.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace45.ChangeDock = True
        Me.pnlSpace45.Control_Resize = False
        Me.pnlSpace45.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSpace45.isSpace = True
        Me.pnlSpace45.Location = New System.Drawing.Point(365, 0)
        Me.pnlSpace45.Name = "pnlSpace45"
        Me.pnlSpace45.numRows = 0
        Me.pnlSpace45.Reorder = True
        Me.pnlSpace45.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace45.TabIndex = 9
        '
        'pnlSpace44
        '
        Me.pnlSpace44.Auto_Size = False
        Me.pnlSpace44.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace44.ChangeDock = True
        Me.pnlSpace44.Control_Resize = False
        Me.pnlSpace44.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace44.isSpace = True
        Me.pnlSpace44.Location = New System.Drawing.Point(253, 0)
        Me.pnlSpace44.Name = "pnlSpace44"
        Me.pnlSpace44.numRows = 0
        Me.pnlSpace44.Reorder = True
        Me.pnlSpace44.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace44.TabIndex = 7
        '
        'mdfOctavosLlegadaCierre
        '
        Me.mdfOctavosLlegadaCierre.Alignemnt = System.Windows.Forms.HorizontalAlignment.Right
        Me.mdfOctavosLlegadaCierre.Allow_Empty = True
        Me.mdfOctavosLlegadaCierre.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.mdfOctavosLlegadaCierre.BackColor = System.Drawing.SystemColors.Control
        Me.mdfOctavosLlegadaCierre.DataField = ""
        Me.mdfOctavosLlegadaCierre.DataTable = ""
        Me.mdfOctavosLlegadaCierre.Descripcion = "Combustible de Llegada"
        Me.mdfOctavosLlegadaCierre.Dock = System.Windows.Forms.DockStyle.Left
        Me.mdfOctavosLlegadaCierre.FocoEnAgregar = False
        Me.mdfOctavosLlegadaCierre.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.mdfOctavosLlegadaCierre.Location = New System.Drawing.Point(223, 0)
        Me.mdfOctavosLlegadaCierre.Mask = "#/8"
        Me.mdfOctavosLlegadaCierre.MensajeIncorrectoCustom = Nothing
        Me.mdfOctavosLlegadaCierre.Name = "mdfOctavosLlegadaCierre"
        Me.mdfOctavosLlegadaCierre.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.mdfOctavosLlegadaCierre.ReadOnly_Data = False
        Me.mdfOctavosLlegadaCierre.Regex = ""
        Me.mdfOctavosLlegadaCierre.RegexInput = "[0-8]"
        Me.mdfOctavosLlegadaCierre.Size = New System.Drawing.Size(30, 26)
        Me.mdfOctavosLlegadaCierre.TabIndex = 6
        Me.mdfOctavosLlegadaCierre.Text_Data = "_/8"
        Me.mdfOctavosLlegadaCierre.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.mdfOctavosLlegadaCierre.TopPadding = 0
        Me.mdfOctavosLlegadaCierre.Upper_Case = False
        Me.mdfOctavosLlegadaCierre.Validate_on_lost_focus = True
        '
        'pnlSpace43
        '
        Me.pnlSpace43.Auto_Size = False
        Me.pnlSpace43.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace43.ChangeDock = True
        Me.pnlSpace43.Control_Resize = False
        Me.pnlSpace43.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace43.isSpace = True
        Me.pnlSpace43.Location = New System.Drawing.Point(217, 0)
        Me.pnlSpace43.Name = "pnlSpace43"
        Me.pnlSpace43.numRows = 0
        Me.pnlSpace43.Reorder = True
        Me.pnlSpace43.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace43.TabIndex = 5
        '
        'dtfCombusLlegadaCierre
        '
        Me.dtfCombusLlegadaCierre.Allow_Empty = True
        Me.dtfCombusLlegadaCierre.Allow_Negative = True
        Me.dtfCombusLlegadaCierre.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfCombusLlegadaCierre.BackColor = System.Drawing.SystemColors.Control
        Me.dtfCombusLlegadaCierre.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfCombusLlegadaCierre.DataField = ""
        Me.dtfCombusLlegadaCierre.DataTable = ""
        Me.dtfCombusLlegadaCierre.Descripcion = "Combustible de Llegada"
        Me.dtfCombusLlegadaCierre.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfCombusLlegadaCierre.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfCombusLlegadaCierre.FocoEnAgregar = False
        Me.dtfCombusLlegadaCierre.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfCombusLlegadaCierre.Length_Data = 32767
        Me.dtfCombusLlegadaCierre.Location = New System.Drawing.Point(167, 0)
        Me.dtfCombusLlegadaCierre.Max_Value = 0.0R
        Me.dtfCombusLlegadaCierre.MensajeIncorrectoCustom = Nothing
        Me.dtfCombusLlegadaCierre.Name = "dtfCombusLlegadaCierre"
        Me.dtfCombusLlegadaCierre.Null_on_Empty = True
        Me.dtfCombusLlegadaCierre.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfCombusLlegadaCierre.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfCombusLlegadaCierre.ReadOnly_Data = False
        Me.dtfCombusLlegadaCierre.Size = New System.Drawing.Size(50, 26)
        Me.dtfCombusLlegadaCierre.TabIndex = 4
        Me.dtfCombusLlegadaCierre.Text_Data = ""
        Me.dtfCombusLlegadaCierre.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfCombusLlegadaCierre.TopPadding = 0
        Me.dtfCombusLlegadaCierre.Upper_Case = False
        Me.dtfCombusLlegadaCierre.Validate_on_lost_focus = True
        '
        'pnlSpace42
        '
        Me.pnlSpace42.Auto_Size = False
        Me.pnlSpace42.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace42.ChangeDock = True
        Me.pnlSpace42.Control_Resize = False
        Me.pnlSpace42.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace42.isSpace = True
        Me.pnlSpace42.Location = New System.Drawing.Point(161, 0)
        Me.pnlSpace42.Name = "pnlSpace42"
        Me.pnlSpace42.numRows = 0
        Me.pnlSpace42.Reorder = True
        Me.pnlSpace42.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace42.TabIndex = 3
        '
        'mdfOctavosSalicaCierre
        '
        Me.mdfOctavosSalicaCierre.Alignemnt = System.Windows.Forms.HorizontalAlignment.Right
        Me.mdfOctavosSalicaCierre.Allow_Empty = True
        Me.mdfOctavosSalicaCierre.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.mdfOctavosSalicaCierre.BackColor = System.Drawing.SystemColors.Control
        Me.mdfOctavosSalicaCierre.DataField = "GASSALITEX"
        Me.mdfOctavosSalicaCierre.DataTable = "VC"
        Me.mdfOctavosSalicaCierre.Descripcion = "Combustible"
        Me.mdfOctavosSalicaCierre.Dock = System.Windows.Forms.DockStyle.Left
        Me.mdfOctavosSalicaCierre.FocoEnAgregar = False
        Me.mdfOctavosSalicaCierre.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.mdfOctavosSalicaCierre.Location = New System.Drawing.Point(131, 0)
        Me.mdfOctavosSalicaCierre.Mask = "#/8"
        Me.mdfOctavosSalicaCierre.MensajeIncorrectoCustom = Nothing
        Me.mdfOctavosSalicaCierre.Name = "mdfOctavosSalicaCierre"
        Me.mdfOctavosSalicaCierre.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.mdfOctavosSalicaCierre.ReadOnly_Data = True
        Me.mdfOctavosSalicaCierre.Regex = ""
        Me.mdfOctavosSalicaCierre.RegexInput = "[0-8]"
        Me.mdfOctavosSalicaCierre.Size = New System.Drawing.Size(30, 26)
        Me.mdfOctavosSalicaCierre.TabIndex = 2
        Me.mdfOctavosSalicaCierre.TabStop = False
        Me.mdfOctavosSalicaCierre.Text_Data = "_/8"
        Me.mdfOctavosSalicaCierre.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.mdfOctavosSalicaCierre.TopPadding = 0
        Me.mdfOctavosSalicaCierre.Upper_Case = False
        Me.mdfOctavosSalicaCierre.Validate_on_lost_focus = True
        '
        'pnlSpace41
        '
        Me.pnlSpace41.Auto_Size = False
        Me.pnlSpace41.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace41.ChangeDock = True
        Me.pnlSpace41.Control_Resize = False
        Me.pnlSpace41.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace41.isSpace = True
        Me.pnlSpace41.Location = New System.Drawing.Point(125, 0)
        Me.pnlSpace41.Name = "pnlSpace41"
        Me.pnlSpace41.numRows = 0
        Me.pnlSpace41.Reorder = True
        Me.pnlSpace41.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace41.TabIndex = 1
        '
        'dtfCombusSalidaCierre
        '
        Me.dtfCombusSalidaCierre.Allow_Empty = True
        Me.dtfCombusSalidaCierre.Allow_Negative = True
        Me.dtfCombusSalidaCierre.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfCombusSalidaCierre.BackColor = System.Drawing.SystemColors.Control
        Me.dtfCombusSalidaCierre.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfCombusSalidaCierre.DataField = "LITROS_SALE"
        Me.dtfCombusSalidaCierre.DataTable = "VC"
        Me.dtfCombusSalidaCierre.Descripcion = "Combustible"
        Me.dtfCombusSalidaCierre.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfCombusSalidaCierre.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfCombusSalidaCierre.FocoEnAgregar = False
        Me.dtfCombusSalidaCierre.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfCombusSalidaCierre.Image = Nothing
        Me.dtfCombusSalidaCierre.Label_Space = 75
        Me.dtfCombusSalidaCierre.Length_Data = 32767
        Me.dtfCombusSalidaCierre.Location = New System.Drawing.Point(0, 0)
        Me.dtfCombusSalidaCierre.Max_Value = 0.0R
        Me.dtfCombusSalidaCierre.MensajeIncorrectoCustom = Nothing
        Me.dtfCombusSalidaCierre.Name = "dtfCombusSalidaCierre"
        Me.dtfCombusSalidaCierre.Null_on_Empty = True
        Me.dtfCombusSalidaCierre.OpenForm = Nothing
        Me.dtfCombusSalidaCierre.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfCombusSalidaCierre.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfCombusSalidaCierre.ReadOnly_Data = True
        Me.dtfCombusSalidaCierre.Show_Button = False
        Me.dtfCombusSalidaCierre.Size = New System.Drawing.Size(125, 26)
        Me.dtfCombusSalidaCierre.TabIndex = 0
        Me.dtfCombusSalidaCierre.TabStop = False
        Me.dtfCombusSalidaCierre.Text_Data = ""
        Me.dtfCombusSalidaCierre.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfCombusSalidaCierre.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfCombusSalidaCierre.TopPadding = 0
        Me.dtfCombusSalidaCierre.Upper_Case = False
        Me.dtfCombusSalidaCierre.Validate_on_lost_focus = True
        '
        'dtfCargosCombus
        '
        Me.dtfCargosCombus.Allow_Empty = True
        Me.dtfCargosCombus.Allow_Negative = True
        Me.dtfCargosCombus.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfCargosCombus.BackColor = System.Drawing.SystemColors.Control
        Me.dtfCargosCombus.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfCargosCombus.DataField = Nothing
        Me.dtfCargosCombus.DataTable = ""
        Me.dtfCargosCombus.Descripcion = Nothing
        Me.dtfCargosCombus.Dock = System.Windows.Forms.DockStyle.Right
        Me.dtfCargosCombus.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfCargosCombus.FocoEnAgregar = False
        Me.dtfCargosCombus.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfCargosCombus.Length_Data = 32767
        Me.dtfCargosCombus.Location = New System.Drawing.Point(371, 0)
        Me.dtfCargosCombus.Max_Value = 0.0R
        Me.dtfCargosCombus.MensajeIncorrectoCustom = Nothing
        Me.dtfCargosCombus.Name = "dtfCargosCombus"
        Me.dtfCargosCombus.Null_on_Empty = True
        Me.dtfCargosCombus.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfCargosCombus.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfCargosCombus.ReadOnly_Data = True
        Me.dtfCargosCombus.Size = New System.Drawing.Size(83, 26)
        Me.dtfCargosCombus.TabIndex = 10
        Me.dtfCargosCombus.TabStop = False
        Me.dtfCargosCombus.Text_Data = ""
        Me.dtfCargosCombus.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfCargosCombus.TopPadding = 0
        Me.dtfCargosCombus.Upper_Case = False
        Me.dtfCargosCombus.Validate_on_lost_focus = True
        '
        'pnlKilometrosCierre
        '
        Me.pnlKilometrosCierre.Auto_Size = False
        Me.pnlKilometrosCierre.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlKilometrosCierre.ChangeDock = True
        Me.pnlKilometrosCierre.Control_Resize = False
        Me.pnlKilometrosCierre.Controls.Add(Me.dtfDiferenciaKilometros)
        Me.pnlKilometrosCierre.Controls.Add(Me.pnlSpace40)
        Me.pnlKilometrosCierre.Controls.Add(Me.pnlSpace39)
        Me.pnlKilometrosCierre.Controls.Add(Me.dtfKmLlegadaCierre)
        Me.pnlKilometrosCierre.Controls.Add(Me.pnlSpace38)
        Me.pnlKilometrosCierre.Controls.Add(Me.dtfKmSalidaCierre)
        Me.pnlKilometrosCierre.Controls.Add(Me.dtfCargosKilometros)
        Me.pnlKilometrosCierre.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlKilometrosCierre.isSpace = False
        Me.pnlKilometrosCierre.Location = New System.Drawing.Point(0, 26)
        Me.pnlKilometrosCierre.Name = "pnlKilometrosCierre"
        Me.pnlKilometrosCierre.numRows = 1
        Me.pnlKilometrosCierre.Reorder = True
        Me.pnlKilometrosCierre.Size = New System.Drawing.Size(454, 26)
        Me.pnlKilometrosCierre.TabIndex = 1
        '
        'dtfDiferenciaKilometros
        '
        Me.dtfDiferenciaKilometros.Allow_Empty = True
        Me.dtfDiferenciaKilometros.Allow_Negative = True
        Me.dtfDiferenciaKilometros.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfDiferenciaKilometros.BackColor = System.Drawing.SystemColors.Control
        Me.dtfDiferenciaKilometros.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfDiferenciaKilometros.DataField = Nothing
        Me.dtfDiferenciaKilometros.DataTable = ""
        Me.dtfDiferenciaKilometros.Descripcion = Nothing
        Me.dtfDiferenciaKilometros.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtfDiferenciaKilometros.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfDiferenciaKilometros.FocoEnAgregar = False
        Me.dtfDiferenciaKilometros.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfDiferenciaKilometros.Length_Data = 32767
        Me.dtfDiferenciaKilometros.Location = New System.Drawing.Point(259, 0)
        Me.dtfDiferenciaKilometros.Max_Value = 0.0R
        Me.dtfDiferenciaKilometros.MensajeIncorrectoCustom = Nothing
        Me.dtfDiferenciaKilometros.Name = "dtfDiferenciaKilometros"
        Me.dtfDiferenciaKilometros.Null_on_Empty = True
        Me.dtfDiferenciaKilometros.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfDiferenciaKilometros.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfDiferenciaKilometros.ReadOnly_Data = True
        Me.dtfDiferenciaKilometros.Size = New System.Drawing.Size(106, 26)
        Me.dtfDiferenciaKilometros.TabIndex = 4
        Me.dtfDiferenciaKilometros.TabStop = False
        Me.dtfDiferenciaKilometros.Text_Data = ""
        Me.dtfDiferenciaKilometros.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfDiferenciaKilometros.TopPadding = 0
        Me.dtfDiferenciaKilometros.Upper_Case = False
        Me.dtfDiferenciaKilometros.Validate_on_lost_focus = True
        '
        'pnlSpace40
        '
        Me.pnlSpace40.Auto_Size = False
        Me.pnlSpace40.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace40.ChangeDock = True
        Me.pnlSpace40.Control_Resize = False
        Me.pnlSpace40.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSpace40.isSpace = True
        Me.pnlSpace40.Location = New System.Drawing.Point(365, 0)
        Me.pnlSpace40.Name = "pnlSpace40"
        Me.pnlSpace40.numRows = 0
        Me.pnlSpace40.Reorder = True
        Me.pnlSpace40.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace40.TabIndex = 5
        '
        'pnlSpace39
        '
        Me.pnlSpace39.Auto_Size = False
        Me.pnlSpace39.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace39.ChangeDock = True
        Me.pnlSpace39.Control_Resize = False
        Me.pnlSpace39.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace39.isSpace = True
        Me.pnlSpace39.Location = New System.Drawing.Point(253, 0)
        Me.pnlSpace39.Name = "pnlSpace39"
        Me.pnlSpace39.numRows = 0
        Me.pnlSpace39.Reorder = True
        Me.pnlSpace39.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace39.TabIndex = 3
        '
        'dtfKmLlegadaCierre
        '
        Me.dtfKmLlegadaCierre.Allow_Empty = True
        Me.dtfKmLlegadaCierre.Allow_Negative = False
        Me.dtfKmLlegadaCierre.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfKmLlegadaCierre.BackColor = System.Drawing.SystemColors.Control
        Me.dtfKmLlegadaCierre.Data_Allowed = CustomControls.Datafield.List_Data.nDouble
        Me.dtfKmLlegadaCierre.DataField = Nothing
        Me.dtfKmLlegadaCierre.DataTable = ""
        Me.dtfKmLlegadaCierre.Descripcion = "Kilómetros de Llegada"
        Me.dtfKmLlegadaCierre.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfKmLlegadaCierre.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfKmLlegadaCierre.FocoEnAgregar = False
        Me.dtfKmLlegadaCierre.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfKmLlegadaCierre.Length_Data = 32767
        Me.dtfKmLlegadaCierre.Location = New System.Drawing.Point(167, 0)
        Me.dtfKmLlegadaCierre.Max_Value = 0.0R
        Me.dtfKmLlegadaCierre.MensajeIncorrectoCustom = Nothing
        Me.dtfKmLlegadaCierre.Name = "dtfKmLlegadaCierre"
        Me.dtfKmLlegadaCierre.Null_on_Empty = True
        Me.dtfKmLlegadaCierre.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfKmLlegadaCierre.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfKmLlegadaCierre.ReadOnly_Data = False
        Me.dtfKmLlegadaCierre.Size = New System.Drawing.Size(86, 26)
        Me.dtfKmLlegadaCierre.TabIndex = 2
        Me.dtfKmLlegadaCierre.Text_Data = ""
        Me.dtfKmLlegadaCierre.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfKmLlegadaCierre.TopPadding = 0
        Me.dtfKmLlegadaCierre.Upper_Case = False
        Me.dtfKmLlegadaCierre.Validate_on_lost_focus = True
        '
        'pnlSpace38
        '
        Me.pnlSpace38.Auto_Size = False
        Me.pnlSpace38.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace38.ChangeDock = True
        Me.pnlSpace38.Control_Resize = False
        Me.pnlSpace38.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace38.isSpace = True
        Me.pnlSpace38.Location = New System.Drawing.Point(161, 0)
        Me.pnlSpace38.Name = "pnlSpace38"
        Me.pnlSpace38.numRows = 0
        Me.pnlSpace38.Reorder = True
        Me.pnlSpace38.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace38.TabIndex = 1
        '
        'dtfKmSalidaCierre
        '
        Me.dtfKmSalidaCierre.Allow_Empty = True
        Me.dtfKmSalidaCierre.Allow_Negative = False
        Me.dtfKmSalidaCierre.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfKmSalidaCierre.BackColor = System.Drawing.SystemColors.Control
        Me.dtfKmSalidaCierre.Data_Allowed = CustomControls.Datafield.List_Data.nDouble
        Me.dtfKmSalidaCierre.DataField = "KM"
        Me.dtfKmSalidaCierre.DataTable = "VC"
        Me.dtfKmSalidaCierre.Descripcion = "Kilómetros"
        Me.dtfKmSalidaCierre.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfKmSalidaCierre.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfKmSalidaCierre.FocoEnAgregar = False
        Me.dtfKmSalidaCierre.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfKmSalidaCierre.Image = Nothing
        Me.dtfKmSalidaCierre.Label_Space = 75
        Me.dtfKmSalidaCierre.Length_Data = 32767
        Me.dtfKmSalidaCierre.Location = New System.Drawing.Point(0, 0)
        Me.dtfKmSalidaCierre.Max_Value = 0.0R
        Me.dtfKmSalidaCierre.MensajeIncorrectoCustom = Nothing
        Me.dtfKmSalidaCierre.Name = "dtfKmSalidaCierre"
        Me.dtfKmSalidaCierre.Null_on_Empty = True
        Me.dtfKmSalidaCierre.OpenForm = Nothing
        Me.dtfKmSalidaCierre.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfKmSalidaCierre.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfKmSalidaCierre.ReadOnly_Data = True
        Me.dtfKmSalidaCierre.Show_Button = False
        Me.dtfKmSalidaCierre.Size = New System.Drawing.Size(161, 26)
        Me.dtfKmSalidaCierre.TabIndex = 0
        Me.dtfKmSalidaCierre.TabStop = False
        Me.dtfKmSalidaCierre.Text_Data = ""
        Me.dtfKmSalidaCierre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.dtfKmSalidaCierre.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfKmSalidaCierre.TopPadding = 0
        Me.dtfKmSalidaCierre.Upper_Case = False
        Me.dtfKmSalidaCierre.Validate_on_lost_focus = True
        '
        'dtfCargosKilometros
        '
        Me.dtfCargosKilometros.Allow_Empty = True
        Me.dtfCargosKilometros.Allow_Negative = True
        Me.dtfCargosKilometros.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfCargosKilometros.BackColor = System.Drawing.SystemColors.Control
        Me.dtfCargosKilometros.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfCargosKilometros.DataField = Nothing
        Me.dtfCargosKilometros.DataTable = ""
        Me.dtfCargosKilometros.Descripcion = Nothing
        Me.dtfCargosKilometros.Dock = System.Windows.Forms.DockStyle.Right
        Me.dtfCargosKilometros.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfCargosKilometros.FocoEnAgregar = False
        Me.dtfCargosKilometros.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfCargosKilometros.Length_Data = 32767
        Me.dtfCargosKilometros.Location = New System.Drawing.Point(371, 0)
        Me.dtfCargosKilometros.Max_Value = 0.0R
        Me.dtfCargosKilometros.MensajeIncorrectoCustom = Nothing
        Me.dtfCargosKilometros.Name = "dtfCargosKilometros"
        Me.dtfCargosKilometros.Null_on_Empty = True
        Me.dtfCargosKilometros.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfCargosKilometros.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfCargosKilometros.ReadOnly_Data = True
        Me.dtfCargosKilometros.Size = New System.Drawing.Size(83, 26)
        Me.dtfCargosKilometros.TabIndex = 6
        Me.dtfCargosKilometros.TabStop = False
        Me.dtfCargosKilometros.Text_Data = ""
        Me.dtfCargosKilometros.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfCargosKilometros.TopPadding = 0
        Me.dtfCargosKilometros.Upper_Case = False
        Me.dtfCargosKilometros.Validate_on_lost_focus = True
        '
        'pnlLabelsCierre
        '
        Me.pnlLabelsCierre.Auto_Size = False
        Me.pnlLabelsCierre.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlLabelsCierre.ChangeDock = True
        Me.pnlLabelsCierre.Control_Resize = False
        Me.pnlLabelsCierre.Controls.Add(Me.lblCargos)
        Me.pnlLabelsCierre.Controls.Add(Me.lblDiferencia)
        Me.pnlLabelsCierre.Controls.Add(Me.lblLlegada)
        Me.pnlLabelsCierre.Controls.Add(Me.lblSalida)
        Me.pnlLabelsCierre.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlLabelsCierre.isSpace = False
        Me.pnlLabelsCierre.Location = New System.Drawing.Point(0, 0)
        Me.pnlLabelsCierre.Name = "pnlLabelsCierre"
        Me.pnlLabelsCierre.numRows = 1
        Me.pnlLabelsCierre.Reorder = True
        Me.pnlLabelsCierre.Size = New System.Drawing.Size(454, 26)
        Me.pnlLabelsCierre.TabIndex = 0
        '
        'lblCargos
        '
        Me.lblCargos.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblCargos.Location = New System.Drawing.Point(371, 2)
        Me.lblCargos.Name = "lblCargos"
        Me.lblCargos.Size = New System.Drawing.Size(54, 18)
        Me.lblCargos.TabIndex = 3
        Me.lblCargos.Text = "Cargos"
        '
        'lblDiferencia
        '
        Me.lblDiferencia.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblDiferencia.Location = New System.Drawing.Point(259, 2)
        Me.lblDiferencia.Name = "lblDiferencia"
        Me.lblDiferencia.Size = New System.Drawing.Size(77, 18)
        Me.lblDiferencia.TabIndex = 2
        Me.lblDiferencia.Text = "Diferencia"
        '
        'lblLlegada
        '
        Me.lblLlegada.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblLlegada.Location = New System.Drawing.Point(167, 2)
        Me.lblLlegada.Name = "lblLlegada"
        Me.lblLlegada.Size = New System.Drawing.Size(64, 18)
        Me.lblLlegada.TabIndex = 1
        Me.lblLlegada.Text = "LLegada"
        '
        'lblSalida
        '
        Me.lblSalida.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblSalida.Location = New System.Drawing.Point(74, 2)
        Me.lblSalida.Name = "lblSalida"
        Me.lblSalida.Size = New System.Drawing.Size(49, 18)
        Me.lblSalida.TabIndex = 0
        Me.lblSalida.Text = "Salida"
        '
        'btnRecalcularCierre
        '
        Me.btnRecalcularCierre.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnRecalcularCierre.Location = New System.Drawing.Point(359, 100)
        Me.btnRecalcularCierre.Name = "btnRecalcularCierre"
        Me.btnRecalcularCierre.Size = New System.Drawing.Size(101, 20)
        Me.btnRecalcularCierre.TabIndex = 3
        Me.btnRecalcularCierre.Text = "Recalcular"
        Me.btnRecalcularCierre.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.btnRecalcularCierre.ThemeName = "Windows8"
        '
        'radConRecalc
        '
        Me.radConRecalc.BackColor = System.Drawing.SystemColors.Control
        Me.radConRecalc.Checked = True
        Me.radConRecalc.CheckState = System.Windows.Forms.CheckState.Checked
        Me.radConRecalc.Descripcion = "CON Recálculo Automático"
        Me.radConRecalc.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.radConRecalc.Index = "1"
        Me.radConRecalc.Location = New System.Drawing.Point(182, 102)
        Me.radConRecalc.Name = "radConRecalc"
        Me.radConRecalc.Size = New System.Drawing.Size(174, 18)
        Me.radConRecalc.TabIndex = 5
        Me.radConRecalc.TabStop = True
        Me.radConRecalc.Text = "CON Recálculo Automático"
        Me.radConRecalc.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.radConRecalc.ThemeName = "Windows8"
        Me.radConRecalc.ToggleState = Telerik.WinControls.Enumerations.ToggleState.[On]
        '
        'radSinRecalc
        '
        Me.radSinRecalc.BackColor = System.Drawing.SystemColors.Control
        Me.radSinRecalc.Checked = False
        Me.radSinRecalc.Descripcion = "SIN Recálculo Automático"
        Me.radSinRecalc.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.radSinRecalc.Index = "0"
        Me.radSinRecalc.Location = New System.Drawing.Point(9, 102)
        Me.radSinRecalc.Name = "radSinRecalc"
        Me.radSinRecalc.Size = New System.Drawing.Size(170, 18)
        Me.radSinRecalc.TabIndex = 4
        Me.radSinRecalc.Text = "SIN Recálculo Automático"
        Me.radSinRecalc.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.radSinRecalc.ThemeName = "Windows8"
        '
        'pnlFacturHasta
        '
        Me.pnlFacturHasta.Auto_Size = False
        Me.pnlFacturHasta.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlFacturHasta.ChangeDock = True
        Me.pnlFacturHasta.Control_Resize = False
        Me.pnlFacturHasta.Controls.Add(Me.btnPasaraLienas)
        Me.pnlFacturHasta.Controls.Add(Me.pnlSpace37)
        Me.pnlFacturHasta.Controls.Add(Me.dttFacturHasta)
        Me.pnlFacturHasta.Controls.Add(Me.pnlSpace36)
        Me.pnlFacturHasta.Controls.Add(Me.dtdFacturHasta)
        Me.pnlFacturHasta.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFacturHasta.isSpace = False
        Me.pnlFacturHasta.Location = New System.Drawing.Point(6, 70)
        Me.pnlFacturHasta.Name = "pnlFacturHasta"
        Me.pnlFacturHasta.numRows = 1
        Me.pnlFacturHasta.Reorder = True
        Me.pnlFacturHasta.Size = New System.Drawing.Size(454, 26)
        Me.pnlFacturHasta.TabIndex = 2
        '
        'btnPasaraLienas
        '
        Me.btnPasaraLienas.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnPasaraLienas.Location = New System.Drawing.Point(289, 0)
        Me.btnPasaraLienas.Name = "btnPasaraLienas"
        Me.btnPasaraLienas.Size = New System.Drawing.Size(165, 20)
        Me.btnPasaraLienas.TabIndex = 4
        Me.btnPasaraLienas.Text = "Pasar a Lineas"
        Me.btnPasaraLienas.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.btnPasaraLienas.ThemeName = "Windows8"
        '
        'pnlSpace37
        '
        Me.pnlSpace37.Auto_Size = False
        Me.pnlSpace37.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace37.ChangeDock = True
        Me.pnlSpace37.Control_Resize = False
        Me.pnlSpace37.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace37.isSpace = True
        Me.pnlSpace37.Location = New System.Drawing.Point(283, 0)
        Me.pnlSpace37.Name = "pnlSpace37"
        Me.pnlSpace37.numRows = 0
        Me.pnlSpace37.Reorder = True
        Me.pnlSpace37.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace37.TabIndex = 3
        '
        'dttFacturHasta
        '
        Me.dttFacturHasta.Allow_Empty = True
        Me.dttFacturHasta.DataField = Nothing
        Me.dttFacturHasta.DataTable = ""
        Me.dttFacturHasta.Descripcion = Nothing
        Me.dttFacturHasta.Dock = System.Windows.Forms.DockStyle.Left
        Me.dttFacturHasta.FocoEnAgregar = False
        Me.dttFacturHasta.Location = New System.Drawing.Point(206, 0)
        Me.dttFacturHasta.MensajeIncorrectoCustom = Nothing
        Me.dttFacturHasta.Name = "dttFacturHasta"
        Me.dttFacturHasta.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dttFacturHasta.ReadOnly_Data = False
        Me.dttFacturHasta.Size = New System.Drawing.Size(77, 26)
        Me.dttFacturHasta.TabIndex = 2
        Me.dttFacturHasta.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dttFacturHasta.Time = Nothing
        Me.dttFacturHasta.Validate_on_lost_focus = True
        '
        'pnlSpace36
        '
        Me.pnlSpace36.Auto_Size = False
        Me.pnlSpace36.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace36.ChangeDock = True
        Me.pnlSpace36.Control_Resize = False
        Me.pnlSpace36.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace36.isSpace = True
        Me.pnlSpace36.Location = New System.Drawing.Point(200, 0)
        Me.pnlSpace36.Name = "pnlSpace36"
        Me.pnlSpace36.numRows = 0
        Me.pnlSpace36.Reorder = True
        Me.pnlSpace36.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace36.TabIndex = 1
        '
        'dtdFacturHasta
        '
        Me.dtdFacturHasta.Allow_Empty = True
        Me.dtdFacturHasta.DataField = Nothing
        Me.dtdFacturHasta.DataTable = ""
        Me.dtdFacturHasta.Default_Value = Nothing
        Me.dtdFacturHasta.Descripcion = "Facturar Hasta"
        Me.dtdFacturHasta.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtdFacturHasta.FocoEnAgregar = False
        Me.dtdFacturHasta.Label_Space = 110
        Me.dtdFacturHasta.Location = New System.Drawing.Point(0, 0)
        Me.dtdFacturHasta.Max_Value = Nothing
        Me.dtdFacturHasta.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdFacturHasta.MensajeIncorrectoCustom = Nothing
        Me.dtdFacturHasta.Min_Value = Nothing
        Me.dtdFacturHasta.MinDate = New Date(CType(0, Long))
        Me.dtdFacturHasta.MinimumSize = New System.Drawing.Size(200, 26)
        Me.dtdFacturHasta.Name = "dtdFacturHasta"
        Me.dtdFacturHasta.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdFacturHasta.ReadOnly_Data = False
        Me.dtdFacturHasta.Size = New System.Drawing.Size(200, 26)
        Me.dtdFacturHasta.TabIndex = 0
        Me.dtdFacturHasta.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdFacturHasta.Validate_on_lost_focus = True
        Me.dtdFacturHasta.Value_Data = Nothing
        '
        'pnlFacturDesde
        '
        Me.pnlFacturDesde.Auto_Size = False
        Me.pnlFacturDesde.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlFacturDesde.ChangeDock = True
        Me.pnlFacturDesde.Control_Resize = False
        Me.pnlFacturDesde.Controls.Add(Me.dtfDiasFactur)
        Me.pnlFacturDesde.Controls.Add(Me.pnlSpace35)
        Me.pnlFacturDesde.Controls.Add(Me.dttFacturDesde)
        Me.pnlFacturDesde.Controls.Add(Me.pnlSpace34)
        Me.pnlFacturDesde.Controls.Add(Me.dtdFacturDesde)
        Me.pnlFacturDesde.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFacturDesde.isSpace = False
        Me.pnlFacturDesde.Location = New System.Drawing.Point(6, 44)
        Me.pnlFacturDesde.Name = "pnlFacturDesde"
        Me.pnlFacturDesde.numRows = 1
        Me.pnlFacturDesde.Reorder = True
        Me.pnlFacturDesde.Size = New System.Drawing.Size(454, 26)
        Me.pnlFacturDesde.TabIndex = 1
        '
        'dtfDiasFactur
        '
        Me.dtfDiasFactur.Allow_Empty = True
        Me.dtfDiasFactur.Allow_Negative = True
        Me.dtfDiasFactur.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfDiasFactur.BackColor = System.Drawing.SystemColors.Control
        Me.dtfDiasFactur.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfDiasFactur.DataField = Nothing
        Me.dtfDiasFactur.DataTable = ""
        Me.dtfDiasFactur.Descripcion = "Dias a Facturar"
        Me.dtfDiasFactur.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfDiasFactur.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfDiasFactur.FocoEnAgregar = False
        Me.dtfDiasFactur.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfDiasFactur.Image = Nothing
        Me.dtfDiasFactur.Label_Space = 100
        Me.dtfDiasFactur.Length_Data = 32767
        Me.dtfDiasFactur.Location = New System.Drawing.Point(289, 0)
        Me.dtfDiasFactur.Max_Value = 0.0R
        Me.dtfDiasFactur.MensajeIncorrectoCustom = Nothing
        Me.dtfDiasFactur.Name = "dtfDiasFactur"
        Me.dtfDiasFactur.Null_on_Empty = True
        Me.dtfDiasFactur.OpenForm = Nothing
        Me.dtfDiasFactur.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfDiasFactur.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfDiasFactur.ReadOnly_Data = False
        Me.dtfDiasFactur.Show_Button = False
        Me.dtfDiasFactur.Size = New System.Drawing.Size(165, 26)
        Me.dtfDiasFactur.TabIndex = 4
        Me.dtfDiasFactur.Text_Data = ""
        Me.dtfDiasFactur.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfDiasFactur.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfDiasFactur.TopPadding = 0
        Me.dtfDiasFactur.Upper_Case = False
        Me.dtfDiasFactur.Validate_on_lost_focus = True
        '
        'pnlSpace35
        '
        Me.pnlSpace35.Auto_Size = False
        Me.pnlSpace35.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace35.ChangeDock = True
        Me.pnlSpace35.Control_Resize = False
        Me.pnlSpace35.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace35.isSpace = True
        Me.pnlSpace35.Location = New System.Drawing.Point(283, 0)
        Me.pnlSpace35.Name = "pnlSpace35"
        Me.pnlSpace35.numRows = 0
        Me.pnlSpace35.Reorder = True
        Me.pnlSpace35.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace35.TabIndex = 3
        '
        'dttFacturDesde
        '
        Me.dttFacturDesde.Allow_Empty = True
        Me.dttFacturDesde.DataField = Nothing
        Me.dttFacturDesde.DataTable = ""
        Me.dttFacturDesde.Descripcion = Nothing
        Me.dttFacturDesde.Dock = System.Windows.Forms.DockStyle.Left
        Me.dttFacturDesde.FocoEnAgregar = False
        Me.dttFacturDesde.Location = New System.Drawing.Point(206, 0)
        Me.dttFacturDesde.MensajeIncorrectoCustom = Nothing
        Me.dttFacturDesde.Name = "dttFacturDesde"
        Me.dttFacturDesde.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dttFacturDesde.ReadOnly_Data = False
        Me.dttFacturDesde.Size = New System.Drawing.Size(77, 26)
        Me.dttFacturDesde.TabIndex = 2
        Me.dttFacturDesde.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dttFacturDesde.Time = Nothing
        Me.dttFacturDesde.Validate_on_lost_focus = True
        '
        'pnlSpace34
        '
        Me.pnlSpace34.Auto_Size = False
        Me.pnlSpace34.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace34.ChangeDock = True
        Me.pnlSpace34.Control_Resize = False
        Me.pnlSpace34.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace34.isSpace = True
        Me.pnlSpace34.Location = New System.Drawing.Point(200, 0)
        Me.pnlSpace34.Name = "pnlSpace34"
        Me.pnlSpace34.numRows = 0
        Me.pnlSpace34.Reorder = True
        Me.pnlSpace34.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace34.TabIndex = 1
        '
        'dtdFacturDesde
        '
        Me.dtdFacturDesde.Allow_Empty = True
        Me.dtdFacturDesde.DataField = Nothing
        Me.dtdFacturDesde.DataTable = ""
        Me.dtdFacturDesde.Default_Value = Nothing
        Me.dtdFacturDesde.Descripcion = "Facturar Desde"
        Me.dtdFacturDesde.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtdFacturDesde.FocoEnAgregar = False
        Me.dtdFacturDesde.Label_Space = 110
        Me.dtdFacturDesde.Location = New System.Drawing.Point(0, 0)
        Me.dtdFacturDesde.Max_Value = Nothing
        Me.dtdFacturDesde.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdFacturDesde.MensajeIncorrectoCustom = Nothing
        Me.dtdFacturDesde.Min_Value = Nothing
        Me.dtdFacturDesde.MinDate = New Date(CType(0, Long))
        Me.dtdFacturDesde.MinimumSize = New System.Drawing.Size(200, 26)
        Me.dtdFacturDesde.Name = "dtdFacturDesde"
        Me.dtdFacturDesde.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdFacturDesde.ReadOnly_Data = False
        Me.dtdFacturDesde.Size = New System.Drawing.Size(200, 26)
        Me.dtdFacturDesde.TabIndex = 0
        Me.dtdFacturDesde.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdFacturDesde.Validate_on_lost_focus = True
        Me.dtdFacturDesde.Value_Data = Nothing
        '
        'pnlDatosRetorno
        '
        Me.pnlDatosRetorno.Auto_Size = False
        Me.pnlDatosRetorno.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlDatosRetorno.ChangeDock = True
        Me.pnlDatosRetorno.Control_Resize = False
        Me.pnlDatosRetorno.Controls.Add(Me.dtfDiasRetorno)
        Me.pnlDatosRetorno.Controls.Add(Me.pnlSpace33)
        Me.pnlDatosRetorno.Controls.Add(Me.dttHRetorno)
        Me.pnlDatosRetorno.Controls.Add(Me.pnlSpace32)
        Me.pnlDatosRetorno.Controls.Add(Me.dtdFRetorno)
        Me.pnlDatosRetorno.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlDatosRetorno.isSpace = False
        Me.pnlDatosRetorno.Location = New System.Drawing.Point(6, 18)
        Me.pnlDatosRetorno.Name = "pnlDatosRetorno"
        Me.pnlDatosRetorno.numRows = 1
        Me.pnlDatosRetorno.Reorder = True
        Me.pnlDatosRetorno.Size = New System.Drawing.Size(454, 26)
        Me.pnlDatosRetorno.TabIndex = 0
        '
        'dtfDiasRetorno
        '
        Me.dtfDiasRetorno.Allow_Empty = True
        Me.dtfDiasRetorno.Allow_Negative = True
        Me.dtfDiasRetorno.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtfDiasRetorno.BackColor = System.Drawing.SystemColors.Control
        Me.dtfDiasRetorno.Data_Allowed = CustomControls.Datafield.List_Data.Text
        Me.dtfDiasRetorno.DataField = Nothing
        Me.dtfDiasRetorno.DataTable = ""
        Me.dtfDiasRetorno.Descripcion = "Dias de Alquiler"
        Me.dtfDiasRetorno.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtfDiasRetorno.Encoding = CustomControls.Datafield.Code_Collation.LATIN
        Me.dtfDiasRetorno.FocoEnAgregar = False
        Me.dtfDiasRetorno.Font_Data = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtfDiasRetorno.Image = Nothing
        Me.dtfDiasRetorno.Label_Space = 100
        Me.dtfDiasRetorno.Length_Data = 32767
        Me.dtfDiasRetorno.Location = New System.Drawing.Point(289, 0)
        Me.dtfDiasRetorno.Max_Value = 0.0R
        Me.dtfDiasRetorno.MensajeIncorrectoCustom = Nothing
        Me.dtfDiasRetorno.Name = "dtfDiasRetorno"
        Me.dtfDiasRetorno.Null_on_Empty = True
        Me.dtfDiasRetorno.OpenForm = Nothing
        Me.dtfDiasRetorno.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtfDiasRetorno.PasswordChar_Data = Global.Microsoft.VisualBasic.ChrW(0)
        Me.dtfDiasRetorno.ReadOnly_Data = True
        Me.dtfDiasRetorno.Show_Button = False
        Me.dtfDiasRetorno.Size = New System.Drawing.Size(165, 26)
        Me.dtfDiasRetorno.TabIndex = 4
        Me.dtfDiasRetorno.TabStop = False
        Me.dtfDiasRetorno.Text_Data = ""
        Me.dtfDiasRetorno.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dtfDiasRetorno.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtfDiasRetorno.TopPadding = 0
        Me.dtfDiasRetorno.Upper_Case = False
        Me.dtfDiasRetorno.Validate_on_lost_focus = True
        '
        'pnlSpace33
        '
        Me.pnlSpace33.Auto_Size = False
        Me.pnlSpace33.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace33.ChangeDock = True
        Me.pnlSpace33.Control_Resize = False
        Me.pnlSpace33.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace33.isSpace = True
        Me.pnlSpace33.Location = New System.Drawing.Point(283, 0)
        Me.pnlSpace33.Name = "pnlSpace33"
        Me.pnlSpace33.numRows = 0
        Me.pnlSpace33.Reorder = True
        Me.pnlSpace33.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace33.TabIndex = 3
        '
        'dttHRetorno
        '
        Me.dttHRetorno.Allow_Empty = True
        Me.dttHRetorno.DataField = Nothing
        Me.dttHRetorno.DataTable = ""
        Me.dttHRetorno.Descripcion = Nothing
        Me.dttHRetorno.Dock = System.Windows.Forms.DockStyle.Left
        Me.dttHRetorno.FocoEnAgregar = False
        Me.dttHRetorno.Location = New System.Drawing.Point(206, 0)
        Me.dttHRetorno.MensajeIncorrectoCustom = Nothing
        Me.dttHRetorno.Name = "dttHRetorno"
        Me.dttHRetorno.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dttHRetorno.ReadOnly_Data = False
        Me.dttHRetorno.Size = New System.Drawing.Size(77, 26)
        Me.dttHRetorno.TabIndex = 2
        Me.dttHRetorno.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dttHRetorno.Time = Nothing
        Me.dttHRetorno.Validate_on_lost_focus = True
        '
        'pnlSpace32
        '
        Me.pnlSpace32.Auto_Size = False
        Me.pnlSpace32.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlSpace32.ChangeDock = True
        Me.pnlSpace32.Control_Resize = False
        Me.pnlSpace32.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSpace32.isSpace = True
        Me.pnlSpace32.Location = New System.Drawing.Point(200, 0)
        Me.pnlSpace32.Name = "pnlSpace32"
        Me.pnlSpace32.numRows = 0
        Me.pnlSpace32.Reorder = True
        Me.pnlSpace32.Size = New System.Drawing.Size(6, 26)
        Me.pnlSpace32.TabIndex = 1
        '
        'dtdFRetorno
        '
        Me.dtdFRetorno.Allow_Empty = True
        Me.dtdFRetorno.DataField = ""
        Me.dtdFRetorno.DataTable = ""
        Me.dtdFRetorno.Default_Value = Nothing
        Me.dtdFRetorno.Descripcion = "Fecha de Retorno"
        Me.dtdFRetorno.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtdFRetorno.FocoEnAgregar = False
        Me.dtdFRetorno.Label_Space = 110
        Me.dtdFRetorno.Location = New System.Drawing.Point(0, 0)
        Me.dtdFRetorno.Max_Value = Nothing
        Me.dtdFRetorno.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtdFRetorno.MensajeIncorrectoCustom = Nothing
        Me.dtdFRetorno.Min_Value = Nothing
        Me.dtdFRetorno.MinDate = New Date(CType(0, Long))
        Me.dtdFRetorno.MinimumSize = New System.Drawing.Size(200, 26)
        Me.dtdFRetorno.Name = "dtdFRetorno"
        Me.dtdFRetorno.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.dtdFRetorno.ReadOnly_Data = False
        Me.dtdFRetorno.Size = New System.Drawing.Size(200, 26)
        Me.dtdFRetorno.TabIndex = 0
        Me.dtdFRetorno.Theme = VariablesGlobales.Modulo_VariablesGlobales.ThemeType.Plain
        Me.dtdFRetorno.Validate_on_lost_focus = True
        Me.dtdFRetorno.Value_Data = Nothing
        '
        'pnlCabeceraCierre
        '
        Me.pnlCabeceraCierre.Auto_Size = False
        Me.pnlCabeceraCierre.BorderColor = System.Drawing.SystemColors.Control
        Me.pnlCabeceraCierre.ChangeDock = False
        Me.pnlCabeceraCierre.Control_Resize = False
        Me.pnlCabeceraCierre.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCabeceraCierre.isSpace = False
        Me.pnlCabeceraCierre.Location = New System.Drawing.Point(0, 0)
        Me.pnlCabeceraCierre.Name = "pnlCabeceraCierre"
        Me.pnlCabeceraCierre.numRows = 3
        Me.pnlCabeceraCierre.Reorder = True
        Me.pnlCabeceraCierre.Size = New System.Drawing.Size(1138, 78)
        Me.pnlCabeceraCierre.TabIndex = 4
        '
        'Contratos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1272, 754)
        Me.Name = "Contratos"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Contratos"
        CType(Me.pnlBlock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pvwBase, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pvwBase.ResumeLayout(False)
        CType(Me.stbBase, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pvpGeneral.ResumeLayout(False)
        CType(Me.pnlGenDer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlGenDer.ResumeLayout(False)
        CType(Me.gbxCotiza, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxCotiza.ResumeLayout(False)
        CType(Me.pnlGridLiCon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlGridLiCon.ResumeLayout(False)
        CType(Me.dgvLiCon.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvLiCon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlGridBasesCon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlGridBasesCon.ResumeLayout(False)
        CType(Me.dgvBasesCon.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvBasesCon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlTotal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTotal.ResumeLayout(False)
        CType(Me.pnlSpace20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSpace21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSpace47, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSpace48, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSpace46, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnExpand, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlGenIzq, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlGenIzq.ResumeLayout(False)
        CType(Me.gbxDatosCotiza, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxDatosCotiza.ResumeLayout(False)
        CType(Me.btnRecalcularGeneral, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnLoadTari, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbxDatosVehi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxDatosVehi.ResumeLayout(False)
        CType(Me.pnlCombustibleKilometros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCombustibleKilometros.ResumeLayout(False)
        CType(Me.pnlLitrosOctavosSalida, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlLitrosOctavosSalida.ResumeLayout(False)
        CType(Me.pnlKilometros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlKilometros.ResumeLayout(False)
        CType(Me.pnlVehiculo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlVehiculo.ResumeLayout(False)
        CType(Me.pnlVehi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlVehi.ResumeLayout(False)
        CType(Me.pnlSpace17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbxDatosCli, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxDatosCli.ResumeLayout(False)
        CType(Me.pnlCabeceraGeneral, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCabeceraGeneral.ResumeLayout(False)
        CType(Me.pnlCabecera, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCabecera.ResumeLayout(False)
        CType(Me.pnlDatosPrevistos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDatosPrevistos.ResumeLayout(False)
        CType(Me.pnlSpace16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSpace15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSpace14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSpace13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSpace12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlDatosSalida, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDatosSalida.ResumeLayout(False)
        CType(Me.pnlSpace10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSpace19, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSpace19.ResumeLayout(False)
        CType(Me.pnlSpace9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSpace8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSpace7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSpace6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlCabezeraSup, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCabezeraSup.ResumeLayout(False)
        CType(Me.pnlSpace4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSpace2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSpace1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSpace5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pvpOtrosDatos.ResumeLayout(False)
        CType(Me.pnlOtrosDatosDer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlOtrosDatosDer.ResumeLayout(False)
        CType(Me.pnlOtrosDatosIzq, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlOtrosDatosIzq.ResumeLayout(False)
        CType(Me.pnlOpcionesAlquiler, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlOpcionesAlquiler.ResumeLayout(False)
        CType(Me.pnlChecksOtrosDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlChecksOtrosDatos.ResumeLayout(False)
        Me.pnlChecksOtrosDatos.PerformLayout()
        CType(Me.chnNoPrtImp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkImproductivo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkExentos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chnNoPendCob, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkVehi2000Kg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chProlongacionAutomatica, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSpace22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rdgTipoAlquiler, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rdgTipoAlquiler.ResumeLayout(False)
        Me.rdgTipoAlquiler.PerformLayout()
        CType(Me.radCorta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.radLarga, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlCabeceraOtros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pvpConductores.ResumeLayout(False)
        CType(Me.pnlConductoresDer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlConductoresDer.ResumeLayout(False)
        CType(Me.gbxConductoresAdicionales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxConductoresAdicionales.ResumeLayout(False)
        CType(Me.gbxOtroCond3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxOtroCond3.ResumeLayout(False)
        CType(Me.pnlOtroPermismo3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlOtroPermismo3.ResumeLayout(False)
        CType(Me.pnlOtroFPermismo3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlOtroFPermismo3.ResumeLayout(False)
        CType(Me.gbxOtroCond2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxOtroCond2.ResumeLayout(False)
        CType(Me.pnlOtroPermismo2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlOtroPermismo2.ResumeLayout(False)
        CType(Me.pnlOtroFPermismo2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlOtroFPermismo2.ResumeLayout(False)
        CType(Me.gbxOtroCond, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxOtroCond.ResumeLayout(False)
        CType(Me.pnlOtroPermismo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlOtroPermismo.ResumeLayout(False)
        CType(Me.pnlOtroFPermismo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlOtroFPermismo.ResumeLayout(False)
        CType(Me.pnlConductoresIzq, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlConductoresIzq.ResumeLayout(False)
        CType(Me.gbxConductor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxConductor.ResumeLayout(False)
        Me.gbxConductor.PerformLayout()
        CType(Me.pnlTarjeta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTarjeta.ResumeLayout(False)
        Me.pnlTarjeta.PerformLayout()
        CType(Me.pnlSpace31, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTarCadu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSpace30, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlPermiso, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPermiso.ResumeLayout(False)
        CType(Me.pnlPermisoInf, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPermisoInf.ResumeLayout(False)
        CType(Me.pnlSpace29, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlPermisoSup, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPermisoSup.ResumeLayout(False)
        CType(Me.pnlSpace28, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlLuNace, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlLuNace.ResumeLayout(False)
        CType(Me.pnlSpace27, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlNifTelf, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlNifTelf.ResumeLayout(False)
        CType(Me.pnlSpace25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSpace24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlConductor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlConductor.ResumeLayout(False)
        CType(Me.pnlSpace23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnCargarCond, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSpace26, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnGuardar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlCabeceraConductores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pvpCierre.ResumeLayout(False)
        CType(Me.pnlCierreDer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlCierreIzq, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCierreIzq.ResumeLayout(False)
        CType(Me.rdgDevolucion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rdgDevolucion.ResumeLayout(False)
        Me.rdgDevolucion.PerformLayout()
        CType(Me.pnlKmLitrosCierre, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlKmLitrosCierre.ResumeLayout(False)
        CType(Me.pnlCombustibleCierre, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCombustibleCierre.ResumeLayout(False)
        CType(Me.pnlSpace45, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSpace44, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSpace43, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSpace42, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSpace41, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlKilometrosCierre, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlKilometrosCierre.ResumeLayout(False)
        CType(Me.pnlSpace40, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSpace39, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSpace38, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlLabelsCierre, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlLabelsCierre.ResumeLayout(False)
        Me.pnlLabelsCierre.PerformLayout()
        CType(Me.lblCargos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDiferencia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblLlegada, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblSalida, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnRecalcularCierre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.radConRecalc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.radSinRecalc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlFacturHasta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFacturHasta.ResumeLayout(False)
        CType(Me.btnPasaraLienas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSpace37, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSpace36, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlFacturDesde, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFacturDesde.ResumeLayout(False)
        CType(Me.pnlSpace35, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSpace34, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlDatosRetorno, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDatosRetorno.ResumeLayout(False)
        CType(Me.pnlSpace33, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSpace32, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlCabeceraCierre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pvpGeneral As CustomControls.PageViewPage
    Friend WithEvents pnlGenIzq As CustomControls.Panel
    Friend WithEvents pnlGenDer As CustomControls.Panel
    Friend WithEvents gbxDatosVehi As CustomControls.GroupBox
    Friend WithEvents gbxDatosCli As CustomControls.GroupBox
    Friend WithEvents dtfConductor As CustomControls.DualDataFieldEditableLabel
    Friend WithEvents dtfDelegacion As CustomControls.DualDatafieldLabel
    Friend WithEvents dtfCliente As CustomControls.DualDataFieldEditableLabel
    Friend WithEvents pnlVehi As CustomControls.Panel
    Friend WithEvents dtfGrupo As CustomControls.DualDatafieldLabel
    Friend WithEvents pnlSpace17 As CustomControls.Panel
    Friend WithEvents dtfMatricula As CustomControls.DualDatafieldLabel
    Friend WithEvents pnlCombustibleKilometros As CustomControls.Panel
    Friend WithEvents pnlKilometros As CustomControls.Panel
    Friend WithEvents dtfKmIncluidos As CustomControls.DatafieldLabel
    Friend WithEvents dtfKilometros As CustomControls.DatafieldLabel
    Friend WithEvents trbLitrosSale As CustomControls.TrackBar
    Friend WithEvents gbxDatosCotiza As CustomControls.GroupBox
    Friend WithEvents dtfTarifa As CustomControls.DualDatafieldLabel
    Friend WithEvents dtfComisio As CustomControls.DualDatafieldLabel
    Friend WithEvents pnlCabeceraGeneral As CustomControls.Panel
    Friend WithEvents pnlCabecera As CustomControls.Panel
    Friend WithEvents pnlDatosPrevistos As CustomControls.Panel
    Friend WithEvents dtfLugarRecogida As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace16 As CustomControls.Panel
    Friend WithEvents dtfUsuRecoje As CustomControls.DualDatafieldLabel
    Friend WithEvents pnlSpace15 As CustomControls.Panel
    Friend WithEvents dtfOfiLlegada As CustomControls.DualDatafieldLabel
    Friend WithEvents pnlSpace14 As CustomControls.Panel
    Friend WithEvents dttHPrevista As CustomControls.DataTime
    Friend WithEvents pnlSpace13 As CustomControls.Panel
    Friend WithEvents dtdFPrevista As CustomControls.DataDateLabel
    Friend WithEvents pnlSpace12 As CustomControls.Panel
    Friend WithEvents pnlDatosSalida As CustomControls.Panel
    Friend WithEvents dtfLugarEntrega As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace10 As CustomControls.Panel
    Friend WithEvents dtfUsuEntrega As CustomControls.DualDatafieldLabel
    Friend WithEvents pnlSpace19 As CustomControls.Panel
    Friend WithEvents pnlSpace9 As CustomControls.Panel
    Friend WithEvents dtfOfiSalida As CustomControls.DualDatafieldLabel
    Friend WithEvents pnlSpace8 As CustomControls.Panel
    Friend WithEvents dttHSalida As CustomControls.DataTime
    Friend WithEvents pnlSpace7 As CustomControls.Panel
    Friend WithEvents dtdFSalida As CustomControls.DataDateLabel
    Friend WithEvents pnlSpace6 As CustomControls.Panel
    Friend WithEvents dtfDiasPrevistos As CustomControls.DatafieldLabel
    Friend WithEvents pnlCabezeraSup As CustomControls.Panel
    Friend WithEvents pnlSpace4 As CustomControls.Panel
    Friend WithEvents dtdFecha As CustomControls.DataDateLabel
    Friend WithEvents pnlSpace2 As CustomControls.Panel
    Friend WithEvents dtfReserva As CustomControls.DualDatafieldLabel
    Friend WithEvents pnlSpace1 As CustomControls.Panel
    Friend WithEvents dtfCodigo As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace5 As CustomControls.Panel
    Friend WithEvents dttHora As CustomControls.DataTime
    Friend WithEvents dtfEmpresaOficina As CustomControls.EmpresaOficina
    Friend WithEvents gbxCotiza As CustomControls.GroupBox
    Friend WithEvents pnlTotal As CustomControls.Panel
    Friend WithEvents dtfTotalCon As CustomControls.DatafieldLabel
    Friend WithEvents dtfDto As CustomControls.DatafieldLabel
    Friend WithEvents pnlGridLiCon As CustomControls.Panel
    Friend WithEvents dgvLiCon As Karve.frm.RentACar.GridLiCon
    Friend WithEvents pnlGridBasesCon As CustomControls.Panel
    Friend WithEvents dgvBasesCon As Karve.frm.RentACar.GridBasesCon
    Friend WithEvents dtfBrutoCon As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace20 As CustomControls.Panel
    Friend WithEvents pnlSpace21 As CustomControls.Panel
    Friend WithEvents btnLoadTari As CustomControls.Button
    Friend WithEvents pvpOtrosDatos As CustomControls.PageViewPage
    Friend WithEvents pnlCabeceraOtros As CustomControls.Panel
    Friend WithEvents pnlOtrosDatosIzq As CustomControls.Panel
    Friend WithEvents pnlOtrosDatosDer As CustomControls.Panel
    Friend WithEvents pnlOpcionesAlquiler As CustomControls.Panel
    Friend WithEvents rdgTipoAlquiler As CustomControls.RadioGroup
    Friend WithEvents radCorta As CustomControls.DataRadio
    Friend WithEvents radLarga As CustomControls.DataRadio
    Friend WithEvents chkImproductivo As CustomControls.DataCheck
    Friend WithEvents chkExentos As CustomControls.DataCheck
    Friend WithEvents pnlSpace22 As CustomControls.Panel
    Friend WithEvents pnlChecksOtrosDatos As CustomControls.Panel
    Friend WithEvents chProlongacionAutomatica As CustomControls.DataCheck
    Friend WithEvents chnNoPrtImp As CustomControls.DataCheck
    Friend WithEvents chnNoPendCob As CustomControls.DataCheck
    Friend WithEvents chkVehi2000Kg As CustomControls.DataCheck
    Friend WithEvents dtfFcobro As CustomControls.DualDatafieldLabel
    Friend WithEvents dtfEmpleado As CustomControls.DualDatafieldLabel
    Friend WithEvents dtfIdioma As CustomControls.DualDatafieldLabel
    Friend WithEvents dtfReferenciaFactura As CustomControls.DatafieldLabel
    Friend WithEvents dtfOrigen As CustomControls.DualDatafieldLabel
    Friend WithEvents dtfTipoImpreso As CustomControls.DualDatafieldLabel
    Friend WithEvents dtfBloqueFactur As CustomControls.DualDatafieldLabel
    Friend WithEvents dtfActiVehi As CustomControls.DualDatafieldLabel
    Friend WithEvents dtfUsoAlquiler As CustomControls.DualDatafieldLabel
    Friend WithEvents dtfUbicacion As CustomControls.DualDatafieldLabel
    Friend WithEvents dtaTrayecto As CustomControls.DataAreaLabel
    Friend WithEvents dtaDescripción As CustomControls.DataAreaLabel
    Friend WithEvents dtaObservaciones As CustomControls.DataAreaLabel
    Friend WithEvents dtfDanos As CustomControls.DatafieldLabel
    Friend WithEvents pvpConductores As CustomControls.PageViewPage
    Friend WithEvents pnlCabeceraConductores As CustomControls.Panel
    Friend WithEvents pnlConductoresIzq As CustomControls.Panel
    Friend WithEvents pnlConductoresDer As CustomControls.Panel
    Friend WithEvents gbxConductor As CustomControls.GroupBox
    Friend WithEvents pnlConductor As CustomControls.Panel
    Friend WithEvents dtfConductorDetalles As CustomControls.DualDatafieldLabel
    Friend WithEvents pnlSpace23 As CustomControls.Panel
    Friend WithEvents btnCargarCond As CustomControls.Button
    Friend WithEvents dtfNombreCond As CustomControls.DatafieldLabel
    Friend WithEvents dtdDirCond As CustomControls.DataDir
    Friend WithEvents pnlNifTelf As CustomControls.Panel
    Friend WithEvents dtfNIFCond As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace25 As CustomControls.Panel
    Friend WithEvents dtfTelfCond As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace24 As CustomControls.Panel
    Friend WithEvents dtfTelfCond2 As CustomControls.Datafield
    Friend WithEvents pnlLuNace As CustomControls.Panel
    Friend WithEvents pnlPermiso As CustomControls.Panel
    Friend WithEvents pnlPermisoInf As CustomControls.Panel
    Friend WithEvents pnlPermisoSup As CustomControls.Panel
    Friend WithEvents dtfEmailCond As CustomControls.DatafieldLabel
    Friend WithEvents dtfTarjetaCond As CustomControls.DualDatafieldLabel
    Friend WithEvents pnlTarjeta As CustomControls.Panel
    Friend WithEvents pnlSpace26 As CustomControls.Panel
    Friend WithEvents btnGuardar As CustomControls.Button
    Friend WithEvents pnlSpace27 As CustomControls.Panel
    Friend WithEvents dtfLuNace As CustomControls.DatafieldLabel
    Friend WithEvents dtdFechaNac As CustomControls.DataDateLabel
    Friend WithEvents dtfPermiso As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace28 As CustomControls.Panel
    Friend WithEvents dtfClase As CustomControls.DatafieldLabel
    Friend WithEvents dtfLuExpe As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace29 As CustomControls.Panel
    Friend WithEvents dtdFeExpe As CustomControls.DataDateLabel
    Friend WithEvents dtfTarNum As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace30 As CustomControls.Panel
    Friend WithEvents mdfTarcadu As CustomControls.MaskedDataField
    Friend WithEvents pnlSpace31 As CustomControls.Panel
    Friend WithEvents lblTarCadu As CustomControls.Label
    Friend WithEvents pvpCierre As CustomControls.PageViewPage
    Friend WithEvents pnlCierreDer As CustomControls.Panel
    Friend WithEvents pnlCierreIzq As CustomControls.Panel
    Friend WithEvents pnlCabeceraCierre As CustomControls.Panel
    Friend WithEvents rdgDevolucion As CustomControls.RadioGroup
    Friend WithEvents dttHRetorno As CustomControls.DataTime
    Friend WithEvents dtdFRetorno As CustomControls.DataDateLabel
    Friend WithEvents pnlDatosRetorno As CustomControls.Panel
    Friend WithEvents pnlSpace32 As CustomControls.Panel
    Friend WithEvents pnlSpace33 As CustomControls.Panel
    Friend WithEvents dtfDiasRetorno As CustomControls.DatafieldLabel
    Friend WithEvents pnlFacturHasta As CustomControls.Panel
    Friend WithEvents pnlSpace37 As CustomControls.Panel
    Friend WithEvents dttFacturHasta As CustomControls.DataTime
    Friend WithEvents pnlSpace36 As CustomControls.Panel
    Friend WithEvents dtdFacturHasta As CustomControls.DataDateLabel
    Friend WithEvents pnlFacturDesde As CustomControls.Panel
    Friend WithEvents dtfDiasFactur As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace35 As CustomControls.Panel
    Friend WithEvents dttFacturDesde As CustomControls.DataTime
    Friend WithEvents pnlSpace34 As CustomControls.Panel
    Friend WithEvents dtdFacturDesde As CustomControls.DataDateLabel
    Friend WithEvents radConRecalc As CustomControls.DataRadio
    Friend WithEvents radSinRecalc As CustomControls.DataRadio
    Friend WithEvents btnRecalcularCierre As CustomControls.Button
    Friend WithEvents btnPasaraLienas As CustomControls.Button
    Friend WithEvents btnRecalcularGeneral As CustomControls.Button
    Friend WithEvents pnlKmLitrosCierre As CustomControls.Panel
    Friend WithEvents trbLitrosLlega As CustomControls.TrackBar
    Friend WithEvents pnlCombustibleCierre As CustomControls.Panel
    Friend WithEvents pnlKilometrosCierre As CustomControls.Panel
    Friend WithEvents pnlLitrosOctavosSalida As CustomControls.Panel
    Friend WithEvents dtfLitrosSalida As CustomControls.Datafield
    Friend WithEvents mdfOctavosSalida As CustomControls.MaskedDataField
    Friend WithEvents dtfCombusSalidaCierre As CustomControls.DatafieldLabel
    Friend WithEvents dtfKmSalidaCierre As CustomControls.DatafieldLabel
    Friend WithEvents pnlLabelsCierre As CustomControls.Panel
    Friend WithEvents lblCargos As CustomControls.Label
    Friend WithEvents lblDiferencia As CustomControls.Label
    Friend WithEvents lblLlegada As CustomControls.Label
    Friend WithEvents lblSalida As CustomControls.Label
    Friend WithEvents mdfOctavosSalicaCierre As CustomControls.MaskedDataField
    Friend WithEvents pnlSpace41 As CustomControls.Panel
    Friend WithEvents dtfDiferenciaCombus As CustomControls.Datafield
    Friend WithEvents pnlSpace45 As CustomControls.Panel
    Friend WithEvents pnlSpace44 As CustomControls.Panel
    Friend WithEvents mdfOctavosLlegadaCierre As CustomControls.MaskedDataField
    Friend WithEvents pnlSpace43 As CustomControls.Panel
    Friend WithEvents dtfCombusLlegadaCierre As CustomControls.Datafield
    Friend WithEvents pnlSpace42 As CustomControls.Panel
    Friend WithEvents dtfCargosCombus As CustomControls.Datafield
    Friend WithEvents dtfDiferenciaKilometros As CustomControls.Datafield
    Friend WithEvents pnlSpace40 As CustomControls.Panel
    Friend WithEvents pnlSpace39 As CustomControls.Panel
    Friend WithEvents dtfKmLlegadaCierre As CustomControls.Datafield
    Friend WithEvents pnlSpace38 As CustomControls.Panel
    Friend WithEvents dtfCargosKilometros As CustomControls.Datafield
    Friend WithEvents dtfMotivoImproduc As CustomControls.DualDatafieldLabel
    Friend WithEvents gbxConductoresAdicionales As CustomControls.GroupBox
    Friend WithEvents gbxOtroCond As CustomControls.GroupBox
    Friend WithEvents pnlOtroFPermismo As CustomControls.Panel
    Friend WithEvents pnlOtroPermismo As CustomControls.Panel
    Friend WithEvents dtfOtroCond As CustomControls.DualDatafieldLabel
    Friend WithEvents dtfOtroPer As CustomControls.DatafieldLabel
    Friend WithEvents dtdOtroNac As CustomControls.DataDateLabel
    Friend WithEvents dtdOtroCadu As CustomControls.DataDateLabel
    Friend WithEvents dtdOtroExpe As CustomControls.DataDateLabel
    Friend WithEvents gbxOtroCond3 As CustomControls.GroupBox
    Friend WithEvents pnlOtroPermismo3 As CustomControls.Panel
    Friend WithEvents dtdOtroNac3 As CustomControls.DataDateLabel
    Friend WithEvents dtfOtroPer3 As CustomControls.DatafieldLabel
    Friend WithEvents pnlOtroFPermismo3 As CustomControls.Panel
    Friend WithEvents dtdOtroCadu3 As CustomControls.DataDateLabel
    Friend WithEvents dtdOtroExpe3 As CustomControls.DataDateLabel
    Friend WithEvents dtfOtroCond3 As CustomControls.DualDatafieldLabel
    Friend WithEvents gbxOtroCond2 As CustomControls.GroupBox
    Friend WithEvents pnlOtroPermismo2 As CustomControls.Panel
    Friend WithEvents dtdOtroNac2 As CustomControls.DataDateLabel
    Friend WithEvents dtfOtroPer2 As CustomControls.DatafieldLabel
    Friend WithEvents pnlOtroFPermismo2 As CustomControls.Panel
    Friend WithEvents dtdOtroCadu2 As CustomControls.DataDateLabel
    Friend WithEvents dtdOtroExpe2 As CustomControls.DataDateLabel
    Friend WithEvents dtfOtroCond2 As CustomControls.DualDatafieldLabel
    Friend WithEvents dtfVehiculo_Ctr As CustomControls.Datafield
    Friend WithEvents btnExpand As CustomControls.Button
    Friend WithEvents pnlVehiculo As CustomControls.Panel
    Friend WithEvents dtfVehiculo As CustomControls.DualDatafieldLabel
    Friend WithEvents dtfBasei As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace47 As CustomControls.Panel
    Friend WithEvents dtfCuota As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace46 As CustomControls.Panel
    Friend WithEvents dtfIVA As CustomControls.DatafieldLabel
    Friend WithEvents pnlSpace48 As CustomControls.Panel

End Class
