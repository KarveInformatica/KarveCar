Imports Karve.ConfiguracionApp
Imports VariablesGlobales
Imports Karve.Theme
Imports System.Windows.Forms

Public Class CrystalViewer

    Protected crpViewer As New CrystalPreviewer
    Protected _reportPath As String
    Protected _reportWhere As String
    Protected _reportName As String

    Public Property reportPath As String
        Get
            Return _reportPath
        End Get
        Set(value As String)
            _reportPath = value
        End Set
    End Property

    Public Property reportWhere As String
        Get
            Return _reportWhere
        End Get
        Set(value As String)
            _reportWhere = value
        End Set
    End Property

    Public Property reportName As String
        Get
            Return _reportName
        End Get
        Set(value As String)
            _reportName = value
        End Set
    End Property


    Private Sub CrystalViewer_HandleCreated(sender As Object, e As EventArgs) Handles Me.HandleCreated

    End Sub


    Private Sub CrystalViewer_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not DesignMode Then
            setIconos()
            ConfiguraCintaEdicion(rbnRibbon)
            crpViewer = getCrystalVersion()
            setCrystal()
            loadExtra()
            AddHandler crpViewer.reportLoaded, AddressOf reportLoaded
        End If
    End Sub

    Protected Overridable Sub loadExtra()

    End Sub

    Protected Overridable Sub setIconos()
            btnPrint.Image = TemaAplicacion.Iconos(Theme_Definicion.euIconos.Print_Ic)
            btnExport.Image = TemaAplicacion.Iconos(Theme_Definicion.euIconos.Export_Ic)

            btnFirstPage.Image = TemaAplicacion.Iconos(Theme_Definicion.euIconos.Start_Ic)
            btnPrevPage.Image = TemaAplicacion.Iconos(Theme_Definicion.euIconos.Previus_Ic)
            btnNextPage.Image = TemaAplicacion.Iconos(Theme_Definicion.euIconos.Next_Ic)
            btnLastPage.Image = TemaAplicacion.Iconos(Theme_Definicion.euIconos.End_Ic)
            btnBuscar.Image = TemaAplicacion.IconosMini(Theme_Definicion.euIconosMini.Buscar_Ic)
            cbxZoom.Image = TemaAplicacion.IconosMini(Theme_Definicion.euIconosMini.Lupa_Ic)
            btnRefresh.Image = TemaAplicacion.IconosMini(Theme_Definicion.euIconosMini.Actualizar_Ic)
    End Sub

    Protected Overridable Sub setCrystal()
        crpViewer.Dock = Windows.Forms.DockStyle.Fill
        Me.Controls.Add(crpViewer)
    End Sub

    Protected Overridable Sub reportLoaded(ByVal export As Boolean)
        lblZoom.Text = Translate("Zoom") & ": 100%"
        setPageNum()
    End Sub

    Private Sub CrystalViewer_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        crpViewer.reportPath = _reportPath
        crpViewer.reportWhere = _reportWhere
        crpViewer.Print()
        tabSizeChange()
    End Sub

    Private Sub CrystalViewer_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        tabSizeChange()
    End Sub

    Private Sub tabSizeChange()
        For Each ctr As Control In Me.Controls
            If ctr.GetType Is GetType(CustomControls.Panel) Then
                If CType(ctr, CustomControls.Panel).ChangeDock Then
                    If Me.Width < (930 + 125) Then
                        CType(ctr, CustomControls.Panel).Dock = DockStyle.Top
                    Else
                        CType(ctr, CustomControls.Panel).Dock = DockStyle.Left
                        ctr.Width = Me.Width / 2 - 1
                    End If
                    ctr.Refresh()
                End If
            End If
        Next
        Me.Refresh()
    End Sub

    Private Sub RadButtonElement1_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        crpViewer.PrintToPrinter()
        setPageNum()
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        crpViewer.Export()
    End Sub

    Private Sub RadButtonElement1_Click_1(sender As Object, e As EventArgs) Handles btnFirstPage.Click
        crpViewer.FirstPage()
        setPageNum()
    End Sub

    Private Sub RadButtonElement2_Click(sender As Object, e As EventArgs) Handles btnPrevPage.Click
        crpViewer.PrevPage()
        setPageNum()
    End Sub

    Private Sub RadButtonElement3_Click(sender As Object, e As EventArgs) Handles btnNextPage.Click
        crpViewer.NextPage()
        setPageNum()
    End Sub

    Private Sub RadButtonElement4_Click(sender As Object, e As EventArgs) Handles btnLastPage.Click
        crpViewer.LastPage()
        setPageNum()
    End Sub

    Private Sub btnBuscarr_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        crpViewer.Search(txtBuscar.Text)
        setPageNum()
    End Sub

    Protected Sub setPageNum()
        lblPagAct.Text = Translate("Nº de página actual") & ": " & crpViewer.CurrentPage
        lblMaxPag.Text = Translate("Nº total de páginas") & ": " & crpViewer.PageCount
    End Sub

    Private Sub cbxOptClick_Click(sender As Object, e As EventArgs) Handles opt400.Click, opt300.Click, opt200.Click, opt150.Click, opt100.Click, opt75.Click, opt50.Click, opt25.Click
        crpViewer.Zoom(sender.KeyTip)
        lblZoom.Text = Translate("Zoom") & ": " & sender.KeyTip & "%"
    End Sub
End Class
