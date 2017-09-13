Imports System.Windows.Forms
Imports Karve.ConfiguracionApp
Imports Karve.Definiciones

Public Class Vehiculos
    Inherits Bases.frmBase
    Dim dts_contra As DataSet

    Protected Overrides Sub setTables()

        With New frmTablasVehiculos
            tablasEdit = .Tablas
        End With
        pkEdit = tablasEdit.Where(Function(o) o.Tabla = "VEHICULO1").First.CamposID.Where(Function(o) o.CampoID = "CODIINT").First

        tablaUltmodi.TableAlias = "V1"
        tablaUltmodi.CampoID = "ULTMODI"

        tablaUsumodi.TableAlias = "V1"
        tablaUsumodi.CampoID = "USUARIO"

    End Sub

    Private Function dameCodigoVehiculo() As String
        Return dameCodigoAgregar(db, tipoCodigo.vehiculos, CE.GStr("EMPRESA"), CO.GStr("OFICINA"))
    End Function


    Protected Overrides Sub setLupas()
        Me.dtfColor.Lupa = lupaColoresVehiculo
        Me.dtfMarca.Lupa = lupaMarcasVehiculo
        Me.dtfGrupo.Lupa = lupaGruposVehiculo
        Me.dtfActividad.Lupa = lupaActividadesVehiculo
        Me.dtfFormaPagoCompra.Lupa = lupaFormasProvee
        Me.dtfOficinaActual.Lupa = lupaOficina
        Me.dtfOficinaAsig.Lupa = lupaOficina
        Me.dtfZonaImpuesto.Lupa = lupaZonas
        Me.dtfVendedor.Lupa = lupaVendedores
        Me.dtfComprador.Lupa = lupaClientes

        'Me.dtfCuentaOtros.Lupa = lupaCuenta
        'Me.dtfPoblacionImp.Lupa = lupaPoblacion
        'Me.dtfProveedor.Lupa = LupaProveedor
        'Me.dtfCompañia.Lupa = LupaProveedor

    End Sub

    Protected Overrides Sub setOpenForm()
        Me.dtfColor.OpenForm = ColoresVehiculo
        Me.dtfMarca.OpenForm = MarcasVehiculo
        Me.dtfGrupo.OpenForm = GruposVehiculo
        Me.dtfActividad.OpenForm = ActividadesVehiculo
        Me.dtfContratoOtros.OpenForm = frmContratos
    End Sub

    Protected Overrides Sub SaveBefore(AddReg As Boolean)
        If AddReg Then
            CodigoEdicion = dameCodigoVehiculo()
        End If
    End Sub

    Protected Overrides Sub SaveExtra(newReg As Boolean)

    End Sub

    Private Sub Form_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Text = "Vehículos"
        Me.pvwBase.SelectedPage = Me.pvpGeneral
        dtfModelo.QueryOnTextChanged = False
    End Sub

    Protected Overrides Sub AddExtra()
        dtfCodigo.Text_Data = dameCodigoVehiculo()
        dtfCodigo.ReadOnly_Data = False
        Me.dtdFCompra.Value_Data = Today
    End Sub

    Protected Overrides Sub loadAfterSave()

    End Sub

    Protected Overrides Sub ValidateExtra()

    End Sub

    Protected Overrides Sub LoadExtra()
        ConductorContratosSituacion()
        'poblacionventa()
    End Sub

    Private Sub ConductorContratosSituacion()
        Try
            dts_contra = db.fillDts("SELECT contrato, matri_vc, desde, hdesde, hasta, hhasta, manual_con1, NOMBRE_CON1 " & vbNewLine & _
                        "FROM Vehi_Cont VC " & "LEFT OUTER JOIN CONTRATOS1 C1 ON C1.NUMERO = VC.CONTRATO " & vbNewLine & _
                        "INNER JOIN CONTRATOS2 C2 ON C1.NUMERO = C2.NUMERO " & vbNewLine & _
                        "WHERE CODIINT_VC='" & dtsEdit.Tables(dtfCodigo.DataTable).Rows(0).Item(dtfCodigo.DataField) & "'" & vbNewLine & _
                        "and (hasta is null or hasta  > getdate()) AND (FEANU_CON2 IS NULL OR ISNULL(ANULADO_CON2,'N') = 'N')")
            dtfConductorSit.Text_Data = dts_contra.Tables(0).Rows(0)(7)
            dtfContratoOtros.Text_Data = dts_contra.Tables(0).Rows(0)(1)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub poblacionventa()
        dts_contra = db.fillDts("SELECT TOP 1 CODVEHI,ANO,FECHA,IMPORTE,POBLACION,ZONA,FACTURAR " & vbNewLine & _
                   "FROM IMPUESTOS " & vbNewLine & _
                  "WHERE CODVEHI = '" & dtfCodigo.Text_Data & "'" & vbNewLine & _
                 "ORDER BY ANO DESC")
        If (dts_contra.Tables(0).Rows.Count > 0) Then
            dtfPoblacionImp.Text_Data = dts_contra.Tables(0).Rows(0)(4)
        End If
    End Sub

    Private Sub dtfMarca_TextChanged() Handles dtfMarca.TextChanged
        dtfModelo.Marca = dtfMarca.Text_Data
    End Sub
End Class

