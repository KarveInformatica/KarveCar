Imports CustomControls
Imports Karve.ConfiguracionApp
Imports VariablesGlobales
Imports Telerik.WinControls.UI

Public Class AccesoRapido

    Public Sub New()
        LoadAccesoComunes()
        LoadAccesoAlquiler()
        LoadAccesoTaller()
        LoadAccesoContabilidad()
        LoadAccesoFacturacion()
    End Sub

    Private Sub LoadAccesoFacturacion()
        MDI.rbgFacturacion.Visibility = Telerik.WinControls.ElementVisibility.Visible
        MDI.rbgFacturacion.Items.Add(LoadItemFactura)
        MDI.rbgFacturacion.Items.Add(LoadItemPruebas)
    End Sub

    Private Sub LoadAccesoComunes()
        MDI.rbgComunes.Visibility = Telerik.WinControls.ElementVisibility.Visible
        MDI.rbgComunes.Items.Add(LoadItemCliente)
        MDI.rbgComunes.Items.Add(LoadItemProvee)
    End Sub

    Private Sub LoadAccesoAlquiler()
        MDI.rbgAlquiler.Visibility = Telerik.WinControls.ElementVisibility.Visible
        MDI.rbgAlquiler.Items.Add(LoadItemReserva)
        MDI.rbgAlquiler.Items.Add(LoadItemContrato)
    End Sub

    Private Sub LoadAccesoTaller()
        MDI.rbgTaller.Visibility = Telerik.WinControls.ElementVisibility.Collapsed
    End Sub

    Private Sub LoadAccesoContabilidad()
        MDI.rbgContabilidad.Visibility = Telerik.WinControls.ElementVisibility.Collapsed
    End Sub

    Public Function LoadItemPruebas() As RadButtonElement
        Dim RC As New RadButtonElement
        With RC
            .Name = "RIPruebas"
            .Text = "Pruebas"
            .ToolTipText = .Text
            .ShouldPaint = False
            .ShowBorder = True
            .TextImageRelation = TextImageRelation.ImageAboveText
            .DisplayStyle = Telerik.WinControls.DisplayStyle.Image
            .Image = TemaAplicacion.Iconos(Theme.Theme_Definicion.euIconos.Config_Ic)
            .Visibility = Telerik.WinControls.ElementVisibility.Visible
            .AccessibleDescription = "RIPruebas"
            .AccessibleName = "RIPruebas"
        End With
        AddHandler RC.Click, AddressOf AccesoRapidoClick
        Return RC
    End Function

    Public Function LoadItemFactura() As RadButtonElement
        Dim RC As New RadButtonElement
        With RC
            .Name = "RIFactura"
            .Text = "Facturas"
            .ToolTipText = .Text
            .Tag = lupaFacturas
            .ShouldPaint = False
            .ShowBorder = True
            .TextImageRelation = TextImageRelation.ImageAboveText
            .DisplayStyle = Telerik.WinControls.DisplayStyle.ImageAndText
            .Image = TemaAplicacion.Iconos(Theme.Theme_Definicion.euIconos.Facturas_Ic)
        End With
        AddHandler RC.Click, AddressOf AccesoRapidoClick
        Return RC
    End Function

    Public Function LoadItemCliente() As RadButtonElement
        Dim RC As New RadButtonElement
        With RC
            .Name = "RICliente"
            .Text = "Clientes"
            .Margin = New Padding(3, 0, 3, 0)
            .ToolTipText = .Text
            .Tag = lupaClientes
            .ShouldPaint = False
            .ShowBorder = True
            .TextImageRelation = TextImageRelation.ImageAboveText
            .DisplayStyle = Telerik.WinControls.DisplayStyle.ImageAndText
            .Image = TemaAplicacion.Iconos(Theme.Theme_Definicion.euIconos.Clientes_Ic)
        End With
        AddHandler RC.Click, AddressOf AccesoRapidoClick
        Return RC
    End Function

    Public Function LoadItemContrato() As RadButtonElement
        Dim RC As New RadButtonElement
        With RC
            .Name = "RIContrato"
            .Text = "Contratos"
            .Margin = New Padding(3, 0, 3, 0)
            .ToolTipText = .Text
            .Tag = lupaContratos
            .ShouldPaint = False
            .ShowBorder = True
            .TextImageRelation = TextImageRelation.ImageAboveText
            .DisplayStyle = Telerik.WinControls.DisplayStyle.ImageAndText
            .Image = TemaAplicacion.Iconos(Theme.Theme_Definicion.euIconos.Contratos_Ic)
        End With
        AddHandler RC.Click, AddressOf AccesoRapidoClick
        Return RC
    End Function

    Public Function LoadItemReserva() As RadButtonElement
        Dim RC As New RadButtonElement
        With RC
            .Name = "RIReserva"
            .Text = "Reserva"
            .Margin = New Padding(3, 0, 3, 0)
            .ToolTipText = .Text
            .Tag = lupaReservas
            .ShouldPaint = False
            .ShowBorder = True
            .TextImageRelation = TextImageRelation.ImageAboveText
            .DisplayStyle = Telerik.WinControls.DisplayStyle.ImageAndText
            .Image = TemaAplicacion.Iconos(Theme.Theme_Definicion.euIconos.Reservas_Ic)
        End With
        AddHandler RC.Click, AddressOf AccesoRapidoClick
        Return RC
    End Function

    Public Function LoadItemProvee() As RadButtonElement
        Dim RC As New RadButtonElement
        With RC
            .Name = "RIProvee"
            .Text = "Proveedores"
            .Margin = New Padding(3, 0, 3, 0)
            .ToolTipText = .Text
            .ShouldPaint = False
            .ShowBorder = True
            .Tag = lupaProvee
            .TextImageRelation = TextImageRelation.ImageAboveText
            .DisplayStyle = Telerik.WinControls.DisplayStyle.ImageAndText
            .Image = TemaAplicacion.Iconos(Theme.Theme_Definicion.euIconos.Proveedores_Ic)
        End With
        AddHandler RC.Click, AddressOf AccesoRapidoClick
        Return RC
    End Function

    Private Sub AccesoRapidoClick(sender As Object, e As EventArgs)
        If sender.name = "RIPruebas" Then Pruebas.Show() : Exit Sub
        If sender.Tag.ToString <> "" Then VariablesGlobales.OpenTab(sender.Tag)
    End Sub

End Class
