Imports System.Windows.Forms
Imports Karve.ConfiguracionApp
Imports VariablesGlobales
Imports Karve.Definiciones

Public Class ModelosVehiculo
    Inherits Bases.frmBase


    Dim pnl As New System.Windows.Forms.Panel

    Protected Overrides Sub setTables()

        With New frmTablasModelosVehiculo
            tablasEdit = .Tablas
        End With
        pkEdit = tablasEdit(0).CamposID(0)
        tablaUltmodi.TableAlias = "COD_MOD"
        tablaUltmodi.CampoID = "ULTMODI"

        tablaUsumodi.TableAlias = "COD_MOD"
        tablaUsumodi.CampoID = "USUARIO"

    End Sub

    Protected Overrides Sub setLupas()
        dtfMarca.Lupa = Karve.ConfiguracionApp.lupaMarcasVehiculo
        dtfGrupo.Lupa = Karve.ConfiguracionApp.lupaGruposVehiculo
    End Sub

    Protected Overrides Sub setOpenForm()
        dtfMarca.OpenForm = Karve.ConfiguracionApp.MarcasVehiculo
        dtfGrupo.OpenForm = Karve.ConfiguracionApp.GruposVehiculo
    End Sub

    Protected Overrides Sub SaveBefore(AddReg As Boolean)
        If AddReg Then
            pkEdit.CodEdit = dtfCodigo.Text_Data
        End If
    End Sub

    Protected Overrides Sub SaveExtra(newReg As Boolean)
        dgvExtras.guardar()
    End Sub

    Protected Overrides Sub CancelExtra()
        LoadMedidaGas()
    End Sub

    Private Sub Modelos_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Text = "Modelos"
        LoadMedidaGas()
        dgvExtras.DBConnection = db
        dgvExtras.generateGrid()
    End Sub

    Private Sub LoadMedidaGas()
        If CE.GInt("MEDIDAGAS") <> 0 Then
            dfDeposito.Text_Data = Translate("Galones")
            dfConsumo.Text_Data = Translate("Galones / 100 Km.")
        Else
            dfDeposito.Text_Data = Translate("Litros")
            If CK.GInt("MEDIDAGAS") <> 0 Then
                dfConsumo.Text_Data = Translate("100 Km / Litros.")
            Else : dfConsumo.Text_Data = Translate("Litros / 100 Km.")
            End If
        End If
        dfMantecada.Text_Data = Translate("Kms.")
    End Sub

    Protected Overrides Sub AddExtra()
        dtfMarca.ReadOnly_Data = False
        dtfCod.ReadOnly_Data = False
        dfVariante.ReadOnly_Data = False
    End Sub

    Protected Overrides Sub Estado_Editar()
        dtfMarca.ReadOnly_Data = True
        dtfCod.ReadOnly_Data = True
        dfVariante.ReadOnly_Data = True
    End Sub

    Protected Overrides Sub loadAfterSave()
        Me.dgvExtras.idRel = pkEdit.CodEdit
        Me.dgvExtras.loadGrid()
    End Sub

    Protected Overrides Sub ValidateBefore()
        If newReg Then
            Me.dtfCodigo.Text_Data = Me.dtfMarca.Text_Data & _
                                     Me.dtfCod.Text_Data & _
                                     Me.dfVariante.Text_Data
        End If
    End Sub

    Private Sub ModelosVehiculo_SelectedPageChanging(sender As Object, e As Telerik.WinControls.UI.RadPageViewCancelEventArgs) Handles Me.SelectedPageChanging
        Select Case e.Page.Name
            Case Me.pvpGeneral.Name : pnlPpalSoporte.Controls.Add(pnlPpal)
            Case Me.pvpMantenimientos.Name : pnlManSoporte.Controls.Add(pnlPpal)
            Case Me.pvpFoto.Name : pnlFotoSoporte.Controls.Add(pnlPpal)
            Case Me.pvpExtras.Name : pnlExtrasSoporte.Controls.Add(pnlPpal)
            Case Me.pvpFichaTecnica.Name : pnlFtecSoporte.Controls.Add(pnlPpal)
        End Select
    End Sub

    Protected Overrides Sub LoadExtra()
        If dtfMarca.Text_Data_Desc = "" Then
            dtfMarca.forceQuery(True)
        End If

        dgvExtras.idRel = pkEdit.CodEdit
        dgvExtras.loadGrid()
    End Sub

    Private Sub dtfNombre_TextChanged() Handles dtfNombre.TextChanged
        Me.NombreRegistro = dtfNombre.Text_Data
    End Sub

End Class
