Imports VariablesGlobales
Imports CustomControls
Imports Karve.ConfiguracionApp
Imports Karve.Definiciones
Imports Karve.Logic

Public Class ContratosGen
    Inherits TraspasarOperaciones

    Public Sub New()
        TablasOrigen = New frmTablasReservasRC
        TablasDestino = New frmTablasContratosRC
        TablasDestino.Tablas(0).SufijoABuscar = "RES1"
        TablasDestino.Tablas(1).SufijoABuscar = "RES2"

        CamposAEvitar.Add("FECHA_CON1")
        CamposAEvitar.Add("HORA_CON1")
    End Sub

    Protected Overrides Sub ExtraMatch(ByRef dtsOrigen As DataSet, ByRef dtsDestino As DataSet)
        'dtsDestino.Tables("C1").Rows(0).Item("") = dtsOrigen.Tables("R1").Rows(0).Item("")
        loadVehi(dtsDestino)
    End Sub

    Private Sub loadVehi(ByRef dts As DataSet)
        If Not IsDBNull(dts.Tables("C1").Rows(0).Item("VCACT_CON1")) Then
            dts.Tables("VC").Rows(0).Item("CODIINT_VC") = dts.Tables("C1").Rows(0).Item("VCACT_CON1")

            Dim DV As New DatosVehiculo(dts.Tables("C1").Rows(0).Item("VCACT_CON1"), db)
            If DV.Datos.Tables(0).Rows.Count <> 0 Then
                dts.Tables("VC").Rows(0).Item("MATRI_VC") = DV.Datos.Tables(0).Rows(0).Item("MATRICULA").ToString
                dts.Tables("VC").Rows(0).Item("KM") = DV.GDbl("KM")
                dts.Tables("VC").Rows(0).Item("LITROS_SALE") = DV.GDbl("LITROS")
            End If
        End If
    End Sub

    Public Sub LoadLicon(ByRef dgvLicon As GridLiCon, Optional ByVal grupo As String = "", Optional ByVal vehiculo As String = "")
        Dim dts As DataSet
        Dim ivaxconcep As Boolean = False
        Dim iva As Double = 0

        dts = db.fillDts("select * from lireser where numero = '" & Me.CodigoOrigen & "'")
        dgvLicon.Clear()

        ivaxconcep = CK.GBool("TIPOPORCONCEPTO") 'iva por concepto
        If Not ivaxconcep Then
            iva = VD.getDouble(CE.GDbl("IVA")) 'iva normal
            If CK.GBool("TIPOPORGRUPO_VEHI") And grupo <> "" Then 'iva por grupo
                iva = VD.getDouble(db.executeQuery("select IVA_GR from GRUPOS where CODIGO = '" & grupo & "'"))
            ElseIf CK.GBool("TIPOPORMODELO_VEHI") And vehiculo <> "" Then 'iva por modelo
                iva = VD.getDouble(db.executeQuery("select IVA_MOD from MODELO where MARCA + CODIGO + VARIANTE = (" & _
                                                   "select MAR + MO1 + MO2 from VEHICULO1 where CODIINT ='" & vehiculo & "')"))
            End If
            If iva = 0 Then
                iva = VD.getDouble(CE.GDbl("IVA")) 'iva normal
            End If
        End If

        For Each row In dts.Tables(0).Rows
            If ivaxconcep Then  'iva por concepto
                iva = VD.getDouble(db.executeQuery("select IGIC from CONCEP_FACTUR where CODIGO = '" & row.item("concepto") & "'"))
            End If
            dgvLicon.addLinea(VD.getString(row.item("concepto")), VD.getBool(row.item("incluido")), VD.getString(row.item("unidad")), VD.getDouble(row.item("cantidad")), VD.getDouble(row.item("precio")), VD.getDouble(row.item("dto")), iva)
        Next
        'dgvLicon.addLinea("concepto", True, "unidad", "cantidad", "precio", "dto", "iva")
    End Sub
End Class