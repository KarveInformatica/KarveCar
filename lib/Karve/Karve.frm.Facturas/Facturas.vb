Imports System.Windows.Forms
Imports Karve.ConfiguracionApp
Imports Karve.Logic
Imports Karve.CrystalPreview
Imports Karve.Definiciones

Public Class Facturas
    Inherits Bases.frmBase

    Private operLineas As New OperacionesLineas
    Private kMsgBox As New CustomControls.kMsgBox

    Protected Overrides Sub setTables()
        With New frmTablasFacturas
            tablasEdit = .Tablas
        End With
        pkEdit = tablasEdit.Where(Function(o) o.Tabla = "FACTURAS").First.CamposID.Where(Function(o) o.CampoID = "NUMERO_FAC").First

        tablaUltmodi.TableAlias = "F"
        tablaUltmodi.CampoID = "ULTMODI_FAC"

        tablaUsumodi.TableAlias = "F"
        tablaUsumodi.CampoID = "USUARIO_FAC"

        tablaOficina.TableAlias = "F"
        tablaOficina.CampoID = "OFICINA_FAC"

        tablaEmpresa.TableAlias = "F"
        tablaEmpresa.CampoID = "SUBLICEN_FAC"
    End Sub

    Protected Overrides Sub setLupas()
        dtfCliente.Lupa = lupaClientes
        dtfOficina.Lupa = lupaOficina
        'dtfVendedor.Lupa =
        'dtfFormaPago.Lupa =
        'dtfDepartamento.Lupa =
        'dtfOrigen.Lupa =
        'dtfTipoImpreso.Lupa =
        'dtfExtra.Lupa =
    End Sub

    Protected Overrides Sub setOpenForm()
        dtfCliente.OpenForm = frmClientes
        dtfOficina.OpenForm = frmOficina
        'dtfVendedor.OpenForm = 
        'dtfFormaPago.OpenForm =
        'dtfDepartamento.OpenForm =
        'dtfOrigen.OpenForm =
        'dtfTipoImpreso.OpenForm =
        'dtfExtra.OpenForm =
    End Sub

    Protected Overrides Sub ValidateExtra()
        If Not checkVtos() Then
            Dim res As DialogResult = kMsgBox.Print("La suma de los vencimientos no coincide con el total de la factura." & vbCrLf & "Desea recalcular los vencimientos?", CustomControls.kMsgBox.kMsgBoxStyle.YesNoCancel)
            If res = Windows.Forms.DialogResult.Yes Then
                recalcularVtos()
            ElseIf res = Windows.Forms.DialogResult.Cancel Then
                datosIncorrectos = True
            End If
        End If
    End Sub

    Protected Overrides Sub setIconosExtra()

    End Sub

#Region "Ocultar Cabecera/Pie"

    Private Sub btnHideCabecera_Click(sender As Object, e As EventArgs) Handles btnHideCabecera.Click
        If pnlCabecera.numRows <> 1 Then
            pnlCabecera.numRows = 1
            btnHideCabecera.Image = Global.Karve.frm.Facturas.My.Resources.Resources.Expand_Arrow
        Else
            pnlCabecera.numRows = 8
            btnHideCabecera.Image = Global.Karve.frm.Facturas.My.Resources.Resources.Collapse_Arrow
        End If
    End Sub

    Private Sub btnHidePie_Click(sender As Object, e As EventArgs) Handles btnHidePie.Click
        If pnlPie.numRows <> 1 Then
            pnlPie.numRows = 1
            dtfTotalFac.SendToBack()
            btnHidePie.Image = Global.Karve.frm.Facturas.My.Resources.Resources.Collapse_Arrow
        Else
            pnlPie.numRows = 5
            dtfTotalFac.BringToFront()
            btnHidePie.Image = Global.Karve.frm.Facturas.My.Resources.Resources.Expand_Arrow
        End If
    End Sub

#End Region

#Region "Extra Queries"

    Private Sub dtfOficina_QueryThrown(dts As DataSet) Handles dtfOficina.QueryThrown
        Try
            dtfEmpresa.Text_Data = dts.Tables(0).Rows(0).Item(1)
        Catch
            dtfEmpresa.Text_Data = ""
        End Try
    End Sub

    Private Sub dtfCliente_QueryThrown(dts As DataSet) Handles dtfCliente.QueryThrown
        Try
            dtfDelegacion.MensajeIncorrectoCustom = "Esta delegacion no pertenece a este cliente."
            dtfDelegacion.Desc_Where = "CLDIDCLIENTE = '" & dtfCliente.Text_Data & "'"
            dtfDelegacion.forceQuery()
        Catch ex As Exception
            dtfDelegacion.Desc_Where = "1 = 0"
            dtfDelegacion.MensajeIncorrectoCustom = "Primero debe asignar un cliente."
        End Try

        Try

            dtfNombreCliFac.Text_Data = dts.Tables(0).Rows(0).Item("NOMBRE")
            dtfNIFCliFac.Text_Data = dts.Tables(0).Rows(0).Item("NIF")
            dirCliFac.Text_Data_Direccion = dts.Tables(0).Rows(0).Item("DIRECCION")
            dirCliFac.Text_Data_CP = dts.Tables(0).Rows(0).Item("CP")
            dirCliFac.Text_Data_Poblacion = dts.Tables(0).Rows(0).Item("POBLACION")
            dirCliFac.Text_Data_Provincia = dts.Tables(0).Rows(0).Item("PROVINCIA")
            dirCliFac.Text_Data_Pais = dts.Tables(0).Rows(0).Item("NACIODOMI")
        Catch ex As Exception
            dtfNombreCliFac.Text_Data = ""
            dtfNIFCliFac.Text_Data = ""
            dirCliFac.Text_Data_Direccion = ""
            dirCliFac.Text_Data_CP = ""
            dirCliFac.Text_Data_Poblacion = ""
            dirCliFac.Text_Data_Provincia = ""
            dirCliFac.Text_Data_Pais = ""
        End Try

        dirCliFac.requeryCP = False
    End Sub

#End Region

#Region "Load extras"

    Protected Overrides Sub LoadExtra()
        If Not IsDBNull(dtsEdit.Tables(dtfAbonoDeFac.DataTable).Rows(0).Item(dtfAbonoDeFac.DataField)) Then
            If dtsEdit.Tables(dtfAbonoDeFac.DataTable).Rows(0).Item(dtfAbonoDeFac.DataField) <> "" Then
                dtfAbonoDeFac.Visible = True
            End If
        End If

        If Not IsDBNull(dtsEdit.Tables(dtfFacRectifPor.DataTable).Rows(0).Item(dtfFacRectifPor.DataField)) Then
            If dtsEdit.Tables(dtfFacRectifPor.DataTable).Rows(0).Item(dtfFacRectifPor.DataField) <> "" Then
                dtfFacRectifPor.Visible = True
            End If
        End If

        cargaGrids()
    End Sub

    Protected Overrides Sub LoadDescripciones()
        dtfNombre_TextChanged()
    End Sub

    Protected Overrides Sub loadAfterSave()
        cargaGrids()
    End Sub

    Private Sub cargaGrids()
        dgvLifacs.idRel = pkEdit.CodEdit
        dgvLifacs.loadGrid()

        dgvBases.idRel = pkEdit.CodEdit
        dgvBases.loadGrid()

        dtfImpDtoPP.Text_Data = dtfBrutoFac.Text_Data * IIf(dtfDtoPP.Text_Data = "", 0, dtfDtoPP.Text_Data) / 100

        dtfImpDtoPie.Text_Data = dtfBrutoFac.Text_Data * IIf(dtfDtoPie.Text_Data = "", 0, dtfDtoPie.Text_Data) / 100
    End Sub

    Private Sub Facturas_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not DesignMode Then
            Me.Image = TemaAplicacion.IconosMini(Karve.Theme.Theme_Definicion.euIconosMini.Mail_Ic)
        End If

        dgvLifacs.DBConnection = db
        dgvLifacs.generateGrid()

        dgvBases.DBConnection = db
        dgvBases.generateGrid()
    End Sub

#End Region

    Protected Overrides Sub SaveBefore(AddReg As Boolean)
        If AddReg Then
            CodigoEdicion = ConfiguracionApp.dameCodigoAgregar(db, ConfiguracionApp.tipoCodigo.facturas)
            dgvLifacs.idRel = CodigoEdicion
            dgvLifacs.setIdRel()

            dgvBases.idRel = CodigoEdicion
            dgvBases.setIdRel()
        End If
    End Sub

    Protected Overrides Sub SaveExtra(newReg As Boolean)
        Me.Estado = EstadoForm.Guardando
        recalcularTotales()
        dgvLifacs.EndEdit()
        dgvLifacs.guardar()
        dgvBases.EndEdit()
        dgvBases.guardar()
    End Sub

    Private Sub dgvBases_IvaChanged(oldIva As Double, newIva As Double) Handles dgvBases.IvaChanged

        Dim updateRows = From rows In CType(dgvLifacs.DataSource, DataTable).Rows
                     Where rows.Item("Iva") = oldIva
                     Select rows

        For Each row In updateRows
            row.Item("Iva") = newIva
        Next
    End Sub

    Private Sub TotalesChanged() Handles dgvLifacs.TotalesChanged, dgvBases.TotalesChanged, dtfDtoPie.TextChanged, dtfDtoPP.TextChanged
        If Me.Estado <> EstadoForm.Cargando And Me.Estado <> EstadoForm.Cancelando And Me.Estado <> EstadoForm.Guardando Then
            recalcularTotales()
        End If
    End Sub

    Private Sub dtfNombre_TextChanged() Handles dtfCliente.Texto_Changed
        Me.NombreRegistro = dtfCliente.Text_Data_Desc
    End Sub

    Private Sub recalcularTotales()
        Dim totales As DataTable

        dtfBrutoFac.Text_Data = dgvLifacs.Bruto

        totales = operLineas.calculaTotales(CodigoEdicion, dgvBases.DataSource, dgvLifacs.Bases, dtfBrutoFac.Text_Data, _
                                            IIf(dtfDtoPP.Text_Data = "", 0, dtfDtoPP.Text_Data), IIf(dtfDtoPie.Text_Data = "", 0, dtfDtoPie.Text_Data))

        dtfImpDtoPP.Text_Data = totales.Rows(0).Item("DtoPP")
        dtfImpDtoPie.Text_Data = totales.Rows(0).Item("DtoPie")
        dtfBaseSin.Text_Data = totales.Rows(0).Item("BaseSin")
        dtfTotalFac.Text_Data = totales.Rows(0).Item("Total")

        recalcularVtos()
    End Sub

    Protected Overrides Function getExtraChanges() As Boolean
        If dgvBases.DataSource.Dataset.HasChanges() Or dgvLifacs.DataSource.Dataset.HasChanges() Then
            Dim a As Boolean = dgvBases.DataSource.Dataset.HasChanges()
            Dim b As Boolean = dgvLifacs.DataSource.Dataset.HasChanges()
            Return True
        End If
        Return False
    End Function

    Protected Overrides Sub setCrystalProperties()
        reportPath = "euros/Factura.rpt"
        reportWhere = "{F.NUMERO_FAC} = '" & CodigoEdicion & "'"
        reportName = "Factura_" & CodigoEdicion
    End Sub

    
#Region "Vencimientos"

    Private Sub btnRecalcVtos_Click(sender As Object, e As EventArgs) Handles btnRecalcVtos.Click
        recalcularVtos()
    End Sub

    Private Sub btnResetVto_Click(sender As Object, e As EventArgs) Handles btnResetVto.Click
        resetVto()
    End Sub

    Private Sub resetVto()
        Dim dbVto As New ASADB.Connection
        Dim dtsPagos As New DataSet
        Dim PlazosPago As New ArrayList
        Dim DiasPago As New ArrayList

        If dtfCliente.Text_Data <> "" And dtfCliente.Incorrecto = False Then
            dtsPagos = dbVto.fillDts("select PLAZO, PLAZO2, PLAZO3, PLAZO4, PLAZO5, DIA, DIA2, DIA3 from CLIENTES1 where NUMERO_CLI = '" & dtfCliente.Text_Data & "'")

            If Not IsDBNull(dtsPagos.Tables(0).Rows(0).Item("PLAZO")) Then PlazosPago.Add(dtsPagos.Tables(0).Rows(0).Item("PLAZO"))
            If Not IsDBNull(dtsPagos.Tables(0).Rows(0).Item("PLAZO2")) Then PlazosPago.Add(dtsPagos.Tables(0).Rows(0).Item("PLAZO2"))
            If Not IsDBNull(dtsPagos.Tables(0).Rows(0).Item("PLAZO3")) Then PlazosPago.Add(dtsPagos.Tables(0).Rows(0).Item("PLAZO3"))
            If Not IsDBNull(dtsPagos.Tables(0).Rows(0).Item("PLAZO4")) Then PlazosPago.Add(dtsPagos.Tables(0).Rows(0).Item("PLAZO4"))
            If Not IsDBNull(dtsPagos.Tables(0).Rows(0).Item("PLAZO5")) Then PlazosPago.Add(dtsPagos.Tables(0).Rows(0).Item("PLAZO5"))

            If Not IsDBNull(dtsPagos.Tables(0).Rows(0).Item("DIA")) Then DiasPago.Add(dtsPagos.Tables(0).Rows(0).Item("DIA"))
            If Not IsDBNull(dtsPagos.Tables(0).Rows(0).Item("DIA2")) Then DiasPago.Add(dtsPagos.Tables(0).Rows(0).Item("DIA2"))
            If Not IsDBNull(dtsPagos.Tables(0).Rows(0).Item("DIA3")) Then DiasPago.Add(dtsPagos.Tables(0).Rows(0).Item("DIA3"))

            PlazosPago.Sort()
            DiasPago.Sort()

            setVtoNull()
            setImpVtoNull()

            If PlazosPago.Count = 0 Then
                If DiasPago.Count = 0 Then
                    dtdVto1.Value_Data = dtdFefchaFac.Value_Data
                Else
                    dtdVto1.Value_Data = nextDay(dtdFefchaFac.Value_Data, DiasPago)
                End If
                dtfImpVto1.Text_Data = dtfTotalFac.Text_Data
            Else
                Dim Vtos As New ArrayList
                For Each plazo In PlazosPago
                    Dim dia As Date
                    dia = dtdFefchaFac.Value_Data
                    dia = dia.AddDays(plazo)
                    If DiasPago.Count > 0 Then
                        dia = nextDay(dia, DiasPago)
                    End If
                    Vtos.Add(dia)
                Next


                dtdVto1.Value_Data = Vtos(0)
                If Vtos.Count > 1 Then dtdVto2.Value_Data = Vtos(1)
                If Vtos.Count > 2 Then dtdVto3.Value_Data = Vtos(2)
                If Vtos.Count > 3 Then dtdVto4.Value_Data = Vtos(3)
                If Vtos.Count > 4 Then dtdVto5.Value_Data = Vtos(4)

                recalcularVtos()
            End If
        End If
    End Sub

    Private Sub recalcularVtos()
        Dim vtos As Integer

        setImpVtoNull()
        Dim j As Integer = 1
        For i = 1 To 10
            Dim ctr As CustomControls.DataDate = Controls.Find("dtdVto" & i, True).First
            If Not IsNothing(ctr.Value_Data) Then
                vtos += 1
            Else
                Dim oldCtr As CustomControls.DataDate = ctr
                j = i
                While IsNothing(ctr.Value_Data) And j < 10
                    j += 1
                    ctr = Controls.Find("dtdVto" & j, True).First
                End While
                If j <= 10 And Not IsNothing(ctr.Value_Data) Then
                    oldCtr.Value_Data = ctr.Value_Data
                    ctr.Value_Data = Nothing
                    vtos += 1
                End If
            End If
        Next

        Dim impVto As Double = dtfTotalFac.Text_Data / vtos
        Dim decimalPart As Integer = Math.Truncate(Math.Round((impVto * 100 - Math.Truncate(impVto * 100)) * vtos, 0))
        impVto = Math.Truncate(impVto * 100) / 100

        For i = 1 To vtos
            Dim ctr As CustomControls.Datafield = Controls.Find("dtfImpVto" & i, True).First
            ctr.Text_Data = impVto
            If decimalPart >= i Then ctr.Text_Data += 0.01
        Next
    End Sub

    Private Sub setVtoNull()
        dtdVto1.Value_Data = Nothing
        dtdVto2.Value_Data = Nothing
        dtdVto3.Value_Data = Nothing
        dtdVto4.Value_Data = Nothing
        dtdVto5.Value_Data = Nothing
        dtdVto6.Value_Data = Nothing
        dtdVto7.Value_Data = Nothing
        dtdVto8.Value_Data = Nothing
        dtdVto9.Value_Data = Nothing
        dtdVto10.Value_Data = Nothing


    End Sub

    Private Sub setImpVtoNull()
        dtfImpVto1.Text_Data = ""
        dtfImpVto2.Text_Data = ""
        dtfImpVto3.Text_Data = ""
        dtfImpVto4.Text_Data = ""
        dtfImpVto5.Text_Data = ""
        dtfImpVto6.Text_Data = ""
        dtfImpVto7.Text_Data = ""
        dtfImpVto8.Text_Data = ""
        dtfImpVto9.Text_Data = ""
        dtfImpVto10.Text_Data = ""
    End Sub

    Private Function nextDay(ByVal fromDate As Date, ByVal Dias As ArrayList) As Date
        If Dias.Count = 1 Then
            Dim daysToAdd = Dias(0) - fromDate.Day
            If daysToAdd < 0 Then
                Return fromDate.AddDays(daysToAdd + Date.DaysInMonth(fromDate.Year, fromDate.Month))
            Else
                Return fromDate.AddDays(daysToAdd)
            End If
        Else
            Dim nearDay As Integer
            nearDay = Dias(0)

            For Each dia In Dias
                If dia > fromDate.Day Then
                    nearDay = dia
                    Exit For
                End If
            Next

            Dim tmp As New ArrayList
            tmp.Add(nearDay)
            Return nextDay(fromDate, tmp)
        End If
    End Function

    Private Function checkVtos() As Boolean
        Dim impTotal As Double
        impTotal = 0
        For i = 1 To 10
            Dim ctr As CustomControls.Datafield = Controls.Find("dtfImpVto" & i, True).First
            Try
                impTotal += ctr.Text_Data
            Catch
            End Try
        Next

        If impTotal = dtfTotalFac.Text_Data Then
            Return True
        End If
        Return False
    End Function

#End Region

   
End Class
