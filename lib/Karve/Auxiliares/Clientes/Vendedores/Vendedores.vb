Imports System.Windows.Forms
Imports Karve.ConfiguracionApp
Imports Karve.Definiciones
Imports CustomControls
Imports VariablesGlobales

Public Class Vendedores
    Inherits Bases.frmBase
    Private kMsgBox As New CustomControls.kMsgBox
    Protected Overrides Sub setTables()

        With New frmTablasVendedores
            tablasEdit = .Tablas
        End With
        pkEdit = tablasEdit(0).CamposID(0)
        tablaUltmodi.TableAlias = "VEND"
        tablaUltmodi.CampoID = "ULTMODI"

        tablaUsumodi.TableAlias = "VEND"
        tablaUsumodi.CampoID = "USUARIO"

    End Sub

    Protected Overrides Sub setLupas()
        dtfZona.Lupa = Karve.ConfiguracionApp.lupaZonas
    End Sub

    Private Sub dtfWeb_btnActionClick() Handles dtfWeb.btnActionClick
        Try
            Process.Start(dtfWeb.Text_Data)
        Catch ex As Exception
            kMsgBox.Print(TranslateVars("La dirección %v no es válida;" & dtfWeb.Text_Data), CustomControls.kMsgBox.kMsgBoxStyle.ErrorInformation _
                          , ex.Message)
        End Try
    End Sub

    Private Sub dtfMail_btnActionClick() Handles dtfEmail.btnActionClick
        Dim mail As String = "mailto:"
        mail = mail + dtfEmail.Text_Data.Replace("#", "@")
        MessageBox.Show(mail)
        Process.Start(mail)
    End Sub
    Protected Overrides Sub SaveBefore(AddReg As Boolean)
        If AddReg Then
            pkEdit.CodEdit = ConfiguracionApp.dameCodigoAgregar(db, ConfiguracionApp.tipoCodigo.vendedores)
        End If
    End Sub
End Class