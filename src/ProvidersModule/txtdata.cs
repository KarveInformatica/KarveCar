using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
  If iNoMod = 0 Then
          If Not CK("RENTMULTIMEDIA") And sNomCta <> getColValueSQL(cSELECT & "DESCRIP" & cFROM & "cu1" & _
                                  cWHERE & "codigo='" & Trim(Cuenta) & "'" & _
                                  cAND & "SUBLICEN = '" & IIf(EmpresaPlanCta <> "", EmpresaPlanCta, EmpresaConectada) & "'", separator, "DESCRIP") Then
            OK = dbUpdateTo("CU1", "DESCRIP", sNomCta, cWHERE & "codigo='" & Trim(Cuenta) & "'" & cAND & "SUBLICEN = '" & IIf(EmpresaPlanCta <> "", EmpresaPlanCta, EmpresaConectada) & "'")
          End If
          If sNomCta2 <> "" And Text2.Text <> getColValueSQL(cSELECT & "DESCRIP2" & cFROM & "cu1" & _
                                  cWHERE & "codigo='" & Trim(Cuenta) & "'" & _
                                cAND & "SUBLICEN = '" & IIf(EmpresaPlanCta <> "", EmpresaPlanCta, EmpresaConectada) & "'", separator, "DESCRIP2") Then
            OK = dbUpdateTo("CU1", "DESCRIP2", sNomCta2, cWHERE & "codigo='" & Trim(Cuenta) & "'" & cAND & "SUBLICEN = '" & IIf(EmpresaPlanCta <> "", EmpresaPlanCta, EmpresaConectada) & "'")
          End If
       

 */


/* GUARDAR
   If cE("GEST_DOCVEHI") And OK Then OK = DOCUS.GuardarDocs
If OK Then GuardaLin

sNomCta = DameNombreCta

If GetIntNotNull(DatosConfig(Confi_Emp, "NO_CTA_CONTA_PROVEE")) = 0 Then
If GetIntNotNull(DatosConfig(Confi_Emp, "CONTAALBPROV")) <> 0 And GetIntNotNull(chk(0).Value) <> 0 Then
  Dim ctapendfac As String, Cols As String, Vals As String
  ctapendfac = "409" & FDer(Right(Text1.Text, NivelCta - 3), "0", NivelCta - 3)
  If Not Existe_en_CU1(ctapendfac, IIf(EmpresaPlanCta <> "", EmpresaPlanCta, EmpresaConectada)) Then
    Cols = "Codigo" & separator & "Descrip" & separator & _
            "ultmodi" & separator & "usuario" & separator & _
            "SUBLICEN" & separator & "Activo"
    Vals = ctapendfac & separator & sNomCta & " FAC.PENDIENTES" & separator & _
          txtUltmodi.Text & separator & TxtUsuario.Text & separator & _
          EmpresaConectada & separator & "P"
    OK = dbInsertTo("Cu1", Cols, Vals)
  Else
    If Not CK("RENTMULTIMEDIA") And TxtNom.Text <> getColValueSQL(cSELECT & "DESCRIP" & cFROM & "cu1" & _
                            cWHERE & "codigo='" & txtContable.Text & "'" & _
                            cAND & "SUBLICEN = '" & IIf(EmpresaPlanCta <> "", EmpresaPlanCta, EmpresaConectada) & "'", separator, "DESCRIP") Then
      OK = dbUpdateTo("CU1", "DESCRIP", sNomCta, cWHERE & "codigo='" & txtContable.Text & "'" & cAND & "SUBLICEN = '" & IIf(EmpresaPlanCta <> "", EmpresaPlanCta, EmpresaConectada) & "'")
    End If
  End If
End If
If GetIntNotNull(DatosConfig(Confi_Emp, "EFECTOS_PROVEE")) <> 0 And txtCtaEfecto.Text <> "" Then
  If Not Existe_en_CU1(txtCtaEfecto.Text, EmpresaConectada) Then
    Cols = "Codigo" & separator & "Descrip" & separator & _
            "ultmodi" & separator & "usuario" & separator & _
            "SUBLICEN" & separator & "Activo"
    Vals = txtCtaEfecto.Text & separator & sNomCta & " EFECTOS" & separator & _
          txtUltmodi.Text & separator & TxtUsuario.Text & separator & _
          EmpresaConectada & separator & "P"
    OK = dbInsertTo("Cu1", Cols, Vals)
  End If
 End If
 If OK And bCambioCta Then OK = BorraCtaVieja(CuentaA)
End If
If OK Then
  Guardar_Delega_NoTrac Me, Text1.Text, vDelega, "ProDelega"
  Guardar_Contacto_NoTrac Me, Text1.Text, vContacto, "ProContactos"
  Guardar_Visitas_PROV_NoTrac Me, Text1.Text, vVisitas
End If
If OK And ExisteProveeDest Then OK = dbUpdateTo("clientes1", "PROVEE_DEST", Text1.Text, cWHERE & "NUMERO_cli = '" & edKCli.Text & "'")
If Not OK Then
  GoTo ROLL
Else
  AutoCodigoEliminar
End If
bdCommitTrans
GestionaComi
CargarTrans
If (GetIntNotNull(DatosConfig(Docs, "HERRERO")) <> 0 And Icono_Formularios_ID = 201) Then
  If dIncr <> GetDoubleNotNull(txtIncr.Text) Then
    ValDivisa = getColValueSQL(cSELECT & "XCONVEURO" & cFROM & "TL_DIVISA" & cWHERE & "CODIGO = '" & edDivisa.Text & "'", separator, "XCONVEURO")
    If ValDivisa = 0 Then ValDivisa = 1
    dIncr = GetDoubleNotNull(txtIncr.Text) / 100
    ExecuteDirect cUPDATE & "TL_RECAMBIO set PRECIO = ((Coste - (Coste * Dto / 100)) * " & Double2StrPunto(ValDivisa, 2) & ") + (((Coste - (Coste * Dto / 100)) * " & Double2StrPunto(ValDivisa, 2) & " * " & Double2StrPunto(dIncr, 2) & "))" & vbNewLine & _
                  cFROM & "TL_PROVRECAMBIO as TPR" & vbNewLine & _
                  cINNER & "TL_RECAMBIO as TRE on TPR.RECAMBIO = TRE.CODIGO" & vbNewLine & _
                  cWHERE & "TPR.PROVEEDOR = '" & Text1.Text & "'"
  End If
End If
On Error GoTo 0
sCtaGastoVieja = TxtCu.Text
Mensa "DATOS_GUARDADOS"
TxtModo.Text = edModos.Actualizar
misCambios = False
OjoContactos = False
Exit Sub
ROLL:
bdRollback
ErrorsAdoDB
End Sub
 */
