Imports System.Windows.Forms
Imports Karve.ConfiguracionApp
Imports System.Xml
Imports Karve.Definiciones


Public Class ClientesPrueba
    Inherits Bases.frmBase

#Region "Setters"
    Protected Overrides Sub setTables()
        With New frmTablasClientes
            tablasEdit = .Tablas
        End With
        pkEdit = tablasEdit.Where(Function(o) o.Tabla = "CLIENTES1").First.CamposID.Where(Function(o) o.CampoID = "NUMERO_CLI").First

        tablaUltmodi.TableAlias = "CL2"
        tablaUltmodi.CampoID = "ULTMODI"

        tablaUsumodi.TableAlias = "CL2"
        tablaUsumodi.CampoID = "USUARIO"

        tablaOficina.TableAlias = "CL2"
        tablaOficina.CampoID = "OFICINA"

        tablaEmpresa.TableAlias = "CL2"
        tablaEmpresa.CampoID = "SUBLICEN"
    End Sub

    Protected Overrides Sub setOpenForm()
        dtfOrigen.OpenForm = OrigenesCliente
        dtfNegocio.OpenForm = NegociosCliente
        dtfMercado.OpenForm = MercadosCliente
        dtfTipo.OpenForm = TiposCliente
        dtfCanal.OpenForm = CanalesCliente
        dtfZona.OpenForm = Karve.ConfiguracionApp.Zonas
        dtfSectAct.OpenForm = Karve.ConfiguracionApp.ActividadesCliente
        dftClavePresu.OpenForm = Karve.ConfiguracionApp.ClavePto
        dtfZona.OpenForm = Karve.ConfiguracionApp.Zonas
        dtfUsoAlq.OpenForm = Karve.ConfiguracionApp.UsoAlquilerCliente
        dtfBloqueFac.OpenForm = Karve.ConfiguracionApp.BloquesFacturacion
        dtfTartipo.OpenForm = Karve.ConfiguracionApp.TarjetasCredito
    End Sub

    Protected Overrides Sub setLupas()
        dtfOficina.Lupa = lupaOficina
        dtfTipo.Lupa = Karve.ConfiguracionApp.lupaTipoCliente
        dtfZona.Lupa = Karve.ConfiguracionApp.lupaZonas
        dtfOrigen.Lupa = Karve.ConfiguracionApp.lupaOrigenesCliente
        dtfMercado.Lupa = Karve.ConfiguracionApp.lupaMercadosCliente
        dtfNegocio.Lupa = Karve.ConfiguracionApp.lupaNegociosCliente
        dtfCanal.Lupa = Karve.ConfiguracionApp.lupaCanalCliente
        dtfSectAct.Lupa = Karve.ConfiguracionApp.lupaActividadesCliente
        dftClavePresu.Lupa = Karve.ConfiguracionApp.lupaClavePto
        dtfUsoAlq.Lupa = Karve.ConfiguracionApp.lupaUsoAlquilerCliente
        dtfBloqueFac.Lupa = Karve.ConfiguracionApp.lupaBloquesFacturacion
        dtfTartipo.Lupa = Karve.ConfiguracionApp.lupaTarjetasCredito

    End Sub

#End Region
    Protected Overrides Sub AddExtra()
        dtfCodigo.Text_Data = "AGREGAR"
        rdgPersEmp.Index = "F"
    End Sub

    Protected Overrides Sub SaveBefore(AddReg As Boolean)
        If AddReg Then
            pkEdit.CodEdit = ConfiguracionApp.dameCodigoAgregar(db, ConfiguracionApp.tipoCodigo.clientes)

            For Each table In Me.tablasEdit
                For Each pk As PrimaryKey In table.CamposID
                    If pk.CampoGrid = "NUMERO_CLI" Then
                        pk.CodEdit = pkEdit.CodEdit
                    End If
                Next
            Next

            dgvDelegacion.idRel = pkEdit.CodEdit
            dgvDelegacion.setIdRel()
        End If
    End Sub

    Protected Overrides Sub SaveExtra(newReg As Boolean)
        dgvDelegacion.guardar()
    End Sub

    Private Sub ClientesPrueba_Load(sender As Object, e As EventArgs) Handles Me.Load
        dgvDelegacion.DBConnection = db
        dgvDelegacion.generateGrid()
    End Sub

    Private Sub pnlTelf_SizeChanged(sender As Object, e As EventArgs) Handles pnlTelf.SizeChanged
        pnlTelf1.Width = pnlTelf.Width / 2 - 3
        pnlTelf2.Width = pnlTelf.Width / 2 - IIf(pnlTelf.Width Mod 2 = 0, 0, 1) - 3
    End Sub

    Private Sub pnlEmpOfi_SizeChanged(sender As Object, e As EventArgs) Handles pnlEmpOfi.SizeChanged
        dtfEmpresa.Width = pnlEmpOfi.Width / 2 - 3
    End Sub

    Private Sub dtfOficina_QueryThrown(dts As DataSet) Handles dtfOficina.QueryThrown
        Try
            dtfEmpresa.Text_Data = dts.Tables(0).Rows(0).Item(1)
        Catch
            dtfEmpresa.Text_Data = ""
        End Try
    End Sub

    Protected Overrides Sub LoadExtra()
        dgvDelegacion.idRel = pkEdit.CodEdit
        dgvDelegacion.loadGrid()
    End Sub

    Protected Overrides Sub loadAfterSave()
        dgvDelegacion.idRel = pkEdit.CodEdit
        dgvDelegacion.loadGrid()
    End Sub

#Region "Persona Fisica/Juridica"

    Private Sub rdgPersEmp_IndexChanged(Index As String) Handles rdgPersEmp.IndexChanged
        setTipoPersona(Index)
    End Sub

    Private Sub setTipoPersona(Index As String)
        If Index = "F" Then
            setPersonaFisica()
        ElseIf Index = "J" Then
            setPersonaJuridica()
        End If
    End Sub

    Private Sub setPersonaFisica()
        'datos generales
        pnlGenEmpresa.Visible = False
        pnlGenPersona.Visible = True

        'direcciones
        gbx2aResidencia.Visible = True
        gbxDirFac.Visible = False

        'resize y reorder
        pnlPersonaEmpresa.AutoResize()
        pnlGenDer.TabReorder()
    End Sub

    Private Sub setPersonaJuridica()
        'datos generales
        pnlGenEmpresa.Visible = True
        pnlGenPersona.Visible = False

        'direcciones
        gbx2aResidencia.Visible = False
        gbxDirFac.Visible = True

        'resize y reorder
        pnlPersonaEmpresa.AutoResize()
        pnlGenDer.TabReorder()
    End Sub
#End Region

    Private Sub ClientesPrueba_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        setTipoPersona(rdgPersEmp.Index)
    End Sub

    Private Sub PageView1_SelectedPageChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub dtfNombre_TextChanged() Handles dtfNombre.TextChanged
        Me.NombreRegistro = dtfNombre.Text_Data
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim xmlString As String
        xmlString = dtsEdit.GetXml
        Dim xmlDoc As New XmlDocument
        Dim dtsTmp As New DataSet
        xmlDoc.LoadXml(xmlString)
        Dim xmlNodeRdr As New XmlNodeReader(xmlDoc)
        dtsTmp.ReadXml(xmlNodeRdr)


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'SERVER
        Dim tcpServer As New Networking.Server("0.0.0.0", 5225, Networking.Server.protocol.TCP)
        Dim msg = tcpServer.StartServer



    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'CLIENTE
        Dim xmlString As String
        Dim cliente As New Networking.ComrpovacionTCP("0.0.0.0", "5225", "", "127.0.0.1")
        xmlString = cliente.sendData("select * from contratos1 where numero = 'C100000004'; select * from contratos2 where numero = 'C100000004'; select * from contratos4 where numero = 'C100000004'")
        Dim xmlDoc As New XmlDocument
        Try
            Dim dtsTmp As New DataSet
            xmlDoc.LoadXml(xmlString)
            Dim xmlNodeRdr As New XmlNodeReader(xmlDoc)
            dtsTmp.ReadXml(xmlNodeRdr)
            MsgBox(dtsTmp.Tables(0).Rows(0).Item("numero"))
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        'MsgBox(Me.Width)
        'MsgBox(Me.Height)


    End Sub


End Class