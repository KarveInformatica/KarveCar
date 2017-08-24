Imports Telerik.WinControls.UI
Imports Karve.ConfiguracionApp
Imports VariablesGlobales
Imports Karve.Theme

Public Class RibbonContratos

#Region "Variables"
    Public Event VerCierre()
    Public Event Cerrar()
    Public Event Prolongar()
    Public Event Reabrir()
    Public Event Facturar()
    Public Event Cobros()

    Private _estadoCtr As EstadoCtr
#End Region

#Region "Propiedades"
    ReadOnly Property CommandTabs As RadRibbonBarCommandTabCollection
        Get
            Return ribbon.CommandTabs
        End Get
    End Property

    Property EstadoCtr As EstadoCtr
        Get
            Return _estadoCtr
        End Get
        Set(value As EstadoCtr)
            _estadoCtr = value
            setEstado(value)
        End Set
    End Property
#End Region

#Region "Funcion3es"
    Public Sub setIconos()
        btnVerCierre.Image = TemaAplicacion.Iconos(Theme_Definicion.euIconos.VerCtr)
        btnCerrar.Image = TemaAplicacion.Iconos(Theme_Definicion.euIconos.CerrarCtr)
        btnProlongar.Image = TemaAplicacion.Iconos(Theme_Definicion.euIconos.ProlongarCtr)
        btnReabrir.Image = TemaAplicacion.Iconos(Theme_Definicion.euIconos.ReabrirCtr)

        btnFacturar.Image = TemaAplicacion.Iconos(Theme_Definicion.euIconos.Facturar)
        btnCobros.Image = TemaAplicacion.Iconos(Theme_Definicion.euIconos.Cobros)
    End Sub

    Private Sub setEstado(ByVal estado As EstadoCtr)
        Select Case estado
            Case EstadoCtr.Null
                btnVerCierre.Enabled = False
                btnCerrar.Enabled = False
                btnProlongar.Enabled = False
                btnReabrir.Enabled = False
                btnFacturar.Enabled = False
                btnCobros.Enabled = False
            Case EstadoCtr.Abierto
                btnVerCierre.Enabled = True
                btnCerrar.Enabled = True
                btnProlongar.Enabled = False
                btnReabrir.Enabled = False
                btnFacturar.Enabled = False
                btnCobros.Enabled = True
            Case EstadoCtr.Cerrado
                btnVerCierre.Enabled = True
                btnCerrar.Enabled = False
                btnProlongar.Enabled = True
                btnReabrir.Enabled = True
                btnFacturar.Enabled = True
                btnCobros.Enabled = True
            Case EstadoCtr.Facturado
                btnVerCierre.Enabled = True
                btnCerrar.Enabled = False
                btnProlongar.Enabled = False
                btnReabrir.Enabled = False
                btnFacturar.Enabled = False
                btnCobros.Enabled = False
        End Select
    End Sub
#End Region

#Region "Eventos"
    Private Sub btnVerCierre_Click(sender As Object, e As EventArgs) Handles btnVerCierre.Click
        RaiseEvent VerCierre()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        RaiseEvent Cerrar()
    End Sub

    Private Sub btnProlongar_Click(sender As Object, e As EventArgs) Handles btnProlongar.Click
        RaiseEvent Prolongar()
    End Sub

    Private Sub btnReabrir_Click(sender As Object, e As EventArgs) Handles btnReabrir.Click
        RaiseEvent Reabrir()
    End Sub

    Private Sub btnFacturar_Click(sender As Object, e As EventArgs) Handles btnFacturar.Click
        RaiseEvent Facturar()
    End Sub

    Private Sub btnCobros_Click(sender As Object, e As EventArgs) Handles btnCobros.Click
        RaiseEvent Cobros()
    End Sub

#End Region
End Class
