Imports CustomControls
Imports VariablesGlobales
Imports Karve.ConfiguracionApp
Imports Bases
Imports Telerik.WinControls.UI
Imports Karve.Theme

Public Class ClienteBrow
    Inherits ClienteCons

    Private MnuClientes As RadContextMenu

    Private Sub ClienteCons_CintaClick(sender As Object, e As EventArgs) Handles Me.CintaClick
        Dim antes As DateTime = DateTime.Now
        Dim despues As TimeSpan = DateTime.Now - antes
        Try


            Dim frm As New Bases.frmBase_old
            frm = OpenForm(frmClientes)
            frm.CodigoEdicion = MyBase.dtsResult.Tables(0).Rows(0).Item("NUMERO_CLI").ToString

            frm.Tablas = dgtTables
            frm.Ordenes = dgoOrdenes
            frm.Reglas = dgrRules
            OpenTab(frm, frm.CodigoEdicion)
            despues = DateTime.Now - antes
        Catch
        End Try
    End Sub

    Private Sub ClienteBrow_OpenMenu(Sender As Object, e As ContextMenuOpeningEventArgs) Handles Me.OpenMenu
        e.ContextMenu = MnuClientes.DropDown
    End Sub

    'Private Sub RadButton1_Click(sender As Object, e As EventArgs) Handles RadButton1.Click
    '    Grid.MasterView.TableFilteringRow.Cells("NOMBRE").BeginEdit()
    'End Sub

    Private Sub ClienteCons_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Grid.Focus()
        Grid.MasterView.TableFilteringRow.Cells("NOMBRE").BeginEdit()
    End Sub

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        CrearMenusContextuales()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub CrearMenusContextuales()
        MnuClientes = New RadContextMenu()
        MnuClientes.Items.Add(MenuAbrir)
        'MnuClientes.Items.Add(MenuEliminar)
        'MnuClientes.Items.Add(MenuFecbaja)
        MnuClientes.Items.Add(MenuSeparador)
        MnuClientes.Items.Add(MenuCambiarCodigo)
    End Sub

    Private Function MenuCambiarCodigo() As RadMenuItem
        Dim MnuCambioCodCli As New RadMenuItem("MnuCambioCodCli")

        MnuCambioCodCli.Text = "Cambio Código de Cliente"
        MnuCambioCodCli.Image = TemaAplicacion.IconosTree(Theme_Definicion.euIconosTree.Check_Ict)
        AddHandler MnuCambioCodCli.Click, AddressOf CambiarCodigoCliente
        Return MnuCambioCodCli
    End Function

    Private Function MenuAbrir() As RadMenuItem
        Dim MnuAbrir As New RadMenuItem("MnuAbrir")
        With MnuAbrir
            .Text = "Abrir Cliente"
            .Image = TemaAplicacion.IconosTree(Theme_Definicion.euIconosTree.Check_Ict)
            AddHandler .Click, AddressOf AbrirCliente
        End With
        Return MnuAbrir
    End Function

    Private Sub CambiarCodigoCliente()
        MsgBox("Cambiar Código de Cliente", vbExclamation)
    End Sub

    Private Sub AbrirCliente()
        MsgBox("Abrir Cliente", vbExclamation)
    End Sub

    Private Function MenuSeparador() As RadMenuSeparatorItem
        Dim MnuSeparador As New RadMenuSeparatorItem
        Return MnuSeparador
    End Function

End Class