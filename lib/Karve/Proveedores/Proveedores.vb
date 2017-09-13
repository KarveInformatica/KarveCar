Imports System.Windows.Forms
Imports Karve.ConfiguracionApp
Imports VariablesGlobales
Imports Karve.Definiciones

Public Class Proveedores
    Inherits Bases.frmBase
    Dim ListaCtrCtas As New List(Of CustomControls.DualDatafield)

    Protected Overrides Sub setTables()
        With New frmTablasProveedores
            tablasEdit = .Tablas
        End With
        pkEdit = tablasEdit.Where(Function(o) o.Tabla = "PROVEE1").First.CamposID.Where(Function(o) o.CampoID = "NUM_PROVEE").First

        tablaUltmodi.TableAlias = "PR1"
        tablaUltmodi.CampoID = "ULTMODI"

        tablaUsumodi.TableAlias = "PR1"
        tablaUsumodi.CampoID = "USUARIO"

        tablaOficina.TableAlias = "PR1"
        tablaOficina.CampoID = "OFICINA"

        tablaEmpresa.TableAlias = "PR1"
        tablaEmpresa.CampoID = "SUBLICEN"
    End Sub

    Protected Overrides Sub setControles()
        LoadLupasCtas()
    End Sub

    Protected Overrides Sub setLupas()
        dtfOficina.Lupa = lupaOficina
        dtfTipoProvee.Lupa = lupaTiposProvee
        dftFormaPago.Lupa = lupaFormasProvee
        dtfBanco.Lupa = lupaBancosCliente
        dftIdioma.Lupa = lupaIdiomas
        SetLupasCtrCtas()
    End Sub

    Protected Overrides Sub setOpenForm()
        dtfTipoProvee.OpenForm = TiposProvee
        dftFormaPago.OpenForm = FormasProvee
        dtfBanco.OpenForm = BancosCliente
        dftIdioma.OpenForm = Idiomas
    End Sub

    Private Sub dtfOficina_QueryThrown(dts As DataSet) Handles dtfOficina.QueryThrown
        Try
            dtfEmpresa.Text_Data = dts.Tables(0).Rows(0).Item(1)
        Catch
            dtfEmpresa.Text_Data = ""
        End Try
    End Sub

    Protected Overrides Sub SaveBefore(AddReg As Boolean)
        If AddReg Then
            CodigoEdicion = ConfiguracionApp.dameCodigoAgregar(db, ConfiguracionApp.tipoCodigo.proveedores)
            dgvDelegacion.idRel = CodigoEdicion
            dgvContactos.idRel = CodigoEdicion
            dgvDelegacion.setIdRel()
            dgvContactos.setIdRel()
        End If
    End Sub

    Protected Overrides Sub SaveExtra(newReg As Boolean)
        dgvDelegacion.guardar()
        dgvContactos.guardar()
    End Sub

    Private Sub Form_Load(sender As Object, e As EventArgs) Handles Me.Load
        dgvDelegacion.DBConnection = db
        dgvContactos.DBConnection = db
        dgvDelegacion.generateGrid()
        dgvContactos.generateGrid()
    End Sub


    Protected Overrides Sub LoadExtra()
        dgvDelegacion.idRel = CodigoEdicion
        dgvContactos.idRel = CodigoEdicion
        dgvDelegacion.loadGrid()
        dgvContactos.loadGrid()
    End Sub

    Protected Overrides Sub loadAfterSave()
        dgvDelegacion.idRel = CodigoEdicion
        dgvContactos.idRel = CodigoEdicion
        dgvDelegacion.loadGrid()
        dgvContactos.loadGrid()
    End Sub

    Private Sub Proveedores_SelectedPageChanging(sender As Object, e As Telerik.WinControls.UI.RadPageViewCancelEventArgs) Handles Me.SelectedPageChanging
        'Select Case e.Page.Name
        '    Case Me.pvpDatosGenerales.Name : pnlGenS.Controls.Add(pnlGen)
        '    Case Me.pvpFacturacionContable.Name : pnlFacContaS.Controls.Add(pnlGen)
        '    Case Me.pvpDelegaciones.Name : pnlDelegaS.Controls.Add(pnlGen)
        '    Case Me.pvpContactos.Name : pnlContactosS.Controls.Add(pnlGen)
        '    Case Me.pvpAcumulados.Name : pnlAcumS.Controls.Add(pnlGen)
        '    Case Me.pvpVisitas.Name : pnlVisitasS.Controls.Add(pnlGen)
        '    Case Me.pvpDirecciones.Name : pnlDirS.Controls.Add(pnlGen)
        '    Case Me.pvpEvaluacion.Name : pnlEvaS.Controls.Add(pnlGen)
        'End Select

    End Sub

    Private Sub LoadLupasCtas()
        ListaCtrCtas.Add(dtfCtaContable)
        ListaCtrCtas.Add(dtfCtaCompGasto)
        ListaCtrCtas.Add(dtfCtaRetencion)
        ListaCtrCtas.Add(dtfCtaPago)
        ListaCtrCtas.Add(dtfCtaGastoAbono)
        ListaCtrCtas.Add(dtfCtaCP)
        ListaCtrCtas.Add(dtfCtaLp)
        ListaCtrCtas.Add(dtfIntracoSoportado)
        ListaCtrCtas.Add(dtfIntracoRepercutido)
    End Sub

    Private Sub SetLupasCtrCtas()
        For Each oCtr In ListaCtrCtas
            AddHandler oCtr.AbrirLupaExtraAfter, AddressOf AbrirLupaExtraAfter
            AddHandler oCtr.AbrirLupaExtraBefore, AddressOf AbrirLupaExtraBefore
            AddHandler oCtr.Texto_Changing, AddressOf TextoChanged
            oCtr.Lupa = lupaCtasContables
        Next
    End Sub

    Private Sub AbrirLupaExtraAfter(Sender As Object)
        sEmpresaCons = ""
    End Sub

    Private Sub AbrirLupaExtraBefore(Sender As Object)
        sEmpresaCons = Me.dtfEmpresa.Text_Data
    End Sub

    Private Sub TextoChanged(Sender As Object)
        Try
            CType(Sender, CustomControls.DualDatafield).Desc_WhereObligatoria = "SUBLICEN = " & _
                                VD.setApostrofa(IIf(CK.GStr("EMP_PLANCTA") <> "", _
                                                    CK.GStr("EMP_PLANCTA"), _
                                                IIf((dtfEmpresa.Text_Data = ""), _
                                                    CE.GStr("EMPRESA"), _
                                                    dtfEmpresa.Text_Data)))
        Catch ex As Exception
        End Try
    End Sub
    
    Private Sub dtfNombre_TextChanged() Handles dtfNombre.TextChanged
        Me.NombreRegistro = dtfNombre.Text_Data
    End Sub
End Class