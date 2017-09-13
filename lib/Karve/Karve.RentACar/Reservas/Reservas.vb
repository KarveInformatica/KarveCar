Imports Karve.ConfiguracionApp
Imports Karve.Logic
Imports Telerik.WinControls.UI
Imports VariablesGlobales
Imports Karve.Definiciones

Public Class Reservas
    Inherits Bases.frmBase

#Region "   Setters.    "

    Protected Overrides Sub setTables()
        'Me.rbnAction.CommandTabs.AddRange(New Telerik.WinControls.RadItem() {Me.rbtEdicion})
        With New frmTablasReservasRC
            tablasEdit = .Tablas
        End With
        pkEdit = tablasEdit.Where(Function(o) o.Tabla = "RESERVAS1").First.CamposID.Where(Function(o) o.CampoID = "NUMERO_RES").First

        tablaUltmodi.TableAlias = "R1"
        tablaUltmodi.CampoID = "ULTMODI_RES1"

        tablaUsumodi.TableAlias = "R1"
        tablaUsumodi.CampoID = "USUARIO_RES1"

        tablaOficina.TableAlias = "R1"
        tablaOficina.CampoID = "OFICINA_RES1"

        tablaEmpresa.TableAlias = "R1"
        tablaEmpresa.CampoID = "SUBLICEN_RES1"
    End Sub

    Protected Overrides Sub setLupas()
        Me.dtfOfiSalida.Lupa = lupaOficina
        Me.dtfOfiLlegada.Lupa = lupaOficina
        Me.dtfCliente.Lupa = lupaClientes
        Me.dtfConductor.Lupa = lupaClientes
        Me.dtfGrupo.Lupa = lupaGruposVehiculo
        Me.dtfTarifa.Lupa = lupaTarifas
    End Sub

    Protected Overrides Sub setOpenForm()
        Me.dtfGrupo.OpenForm = GruposVehiculo
        Me.dtfCliente.OpenForm = frmClientes
        Me.dtfConductor.OpenForm = frmClientes
        Me.dtfGrupo.OpenForm = GruposVehiculo
        Me.dtfTarifa.OpenForm = Tarifas
    End Sub

    Private Sub Form_HandleCreated(sender As Object, e As EventArgs) Handles Me.HandleCreated
        'Ribbon_Bar.CommandTabs.Add(rbtContrato)
    End Sub

    Private Sub Form_Load(sender As Object, e As EventArgs) Handles Me.Load
        dtfSubComisio.Visible = MuestraSubComi()

        dgvLiRes.DBConnection = db
        dgvLiRes.generateGrid()
    End Sub

    Protected Overrides Sub setCrystalProperties()
        'reportPath = "euros/Contra.rpt"
        reportWhere = "{CT1.NUMERO} = '" & CodigoEdicion & "' AND {LC.INCLUIDO} <> 0"
        reportName = "Contrato_" & CodigoEdicion
    End Sub

    Protected Overrides Sub setIconosExtra()
        'ribbon.setIconos()
    End Sub

    Private Function MuestraSubComi() As Boolean
        '*  hay varios casos, para evitar enrevesar el control de visualización, lo encapsulamos en una fn
        Return CE.GBool("GESTIONAR_SUBCOMI")
    End Function

#End Region

#Region "   Agregar.   "

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

        dtfEmpresaOficina.Text_Oficina = CO.GStr("OFICINA")
        Me.dtfOfiSalida.Text_Data = CO.GStr("OFICINA")
        Me.dtfOfiLlegada.Text_Data = CO.GStr("OFICINA")
        Me.dtfRSC.Text_Data = US.GStr("CODIGO")

        dtfDiasPrevistos.Text_Data = 1

        dgvLiRes.EnforceConstrains = False
        cargaGrids()
    End Sub

    Protected Overrides Sub SaveBefore(AddReg As Boolean)
        If AddReg Then
            CodigoEdicion = ConfiguracionApp.dameCodigoAgregar(db, ConfiguracionApp.tipoCodigo.res, CE.GStr("EMPRESA"), CO.GStr("OFICINA"))


            dgvLiRes.idRel = CodigoEdicion
            dgvLiRes.setIdRel()
        End If
    End Sub

    Protected Overrides Sub SaveExtra(newReg As Boolean)
        dgvLiRes.EndEdit()
        dgvLiRes.guardar()
        'dgvBasesCon.EndEdit()
        'dgvBasesCon.guardar()
    End Sub

#End Region

    Private Sub cargaGrids()
        dgvLiRes.idRel = CodigoEdicion
        dgvLiRes.loadGrid()
        dgvLiRes.Tarifa = dtfTarifa.Text_Data
        dgvLiRes.Grupo = dtfGrupo.Text_Data

        'dgvBasesCon.idRel = idEdit
        'dgvBasesCon.loadGrid()
    End Sub

    Protected Overrides Sub loadAfterSave()
        cargaGrids()
    End Sub

    Protected Overrides Sub LoadExtra()
        cargaGrids()
    End Sub

    Protected Overrides Function getExtraChanges() As Boolean
        'dgvBasesCon.DataSource.Dataset.HasChanges() Or
        If dgvLiRes.DataSource.Dataset.HasChanges() Then
            'Dim a As Boolean = dgvBasesres.DataSource.Dataset.HasChanges()
            Dim b As Boolean = dgvLiRes.DataSource.Dataset.HasChanges()
            Return True
        End If
        Return False
    End Function
   
    
End Class