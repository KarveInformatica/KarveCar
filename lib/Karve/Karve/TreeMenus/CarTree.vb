Imports Telerik.WinControls.UI
Imports Karve.ConfiguracionApp
Imports Karve.ConfiguracionApp.Modulo_ConstantesFormularios
Public Class CarTree
    Private nodeList As New ArrayList

    Public Sub New()
        loadCarTree()
    End Sub

    Public Function getNodes() As ArrayList
        Return nodeList
    End Function

    Private Sub loadCarTree()
        nodeList.Add(Maestros())
        nodeList.Add(Reservas())
        nodeList.Add(Contratos())
        'nodeList.Add(Vehiculos())
        nodeList.Add(Facturas())
        nodeList.Add(Auxiliares())
    End Sub

    Private Function Maestros() As CustomControls.TreeNode
        Maestros = New CustomControls.TreeNode("Maestros", CustomControls.TreeNode.nodeType.container, "", "Maestros")
        Dim list As New ArrayList()
        Maestros.Nodes.Add(New CustomControls.TreeNode("Clientes", CustomControls.TreeNode.nodeType.node, lupaClientes, "CliMaestros"))
        If CK.GBool("BDCONTACTOS") Then Maestros.Nodes.Add(New CustomControls.TreeNode("Potenciales", CustomControls.TreeNode.nodeType.node, "", "PotenMaestros"))
        Maestros.Nodes.Add(New CustomControls.TreeNode("Vehículos", CustomControls.TreeNode.nodeType.node, lupaVehiculos, "lupaVehiculos"))
        Maestros.Nodes.Add(New CustomControls.TreeNode("Comisionistas", CustomControls.TreeNode.nodeType.node, "", "ComiMaestros"))
        Maestros.Nodes.Add(New CustomControls.TreeNode("Proveedores", CustomControls.TreeNode.nodeType.node, lupaProvee, "ProveMaestros"))
        Maestros.Nodes.Add(New CustomControls.TreeNode("Oficinas", CustomControls.TreeNode.nodeType.node, lupaOficina, "OfiMaestros"))
        Maestros.Nodes.Add(New CustomControls.TreeNode("Empresas", CustomControls.TreeNode.nodeType.node, "", "EmpMaestros"))
        Maestros.Nodes.Add(New CustomControls.TreeNode("Tarifas", CustomControls.TreeNode.nodeType.node, lupaTarifas, "TariMaestros"))
    End Function

    Private Function Facturas() As CustomControls.TreeNode
        Facturas = New CustomControls.TreeNode("Facturas", CustomControls.TreeNode.nodeType.container, "", "Facturas")
        Facturas.Nodes.Add(New CustomControls.TreeNode("Facturas", CustomControls.TreeNode.nodeType.node, Karve.ConfiguracionApp.Modulo_ConstantesFormularios.lupaFacturas, "FacFacturas"))
    End Function

    Private Function Reservas() As CustomControls.TreeNode
        Reservas = New CustomControls.TreeNode("Reservas", CustomControls.TreeNode.nodeType.container, "", "Reservas")
        Reservas.Nodes.Add(New CustomControls.TreeNode("Reservas", CustomControls.TreeNode.nodeType.node, lupaReservas, "Reservaslupa"))
    End Function

    Private Function Contratos() As CustomControls.TreeNode
        Contratos = New CustomControls.TreeNode("Contratos", CustomControls.TreeNode.nodeType.container, "", "Contratos")
        'Contratos.Nodes.Add(New CustomControls.TreeNode("Contratos", CustomControls.TreeNode.nodeType.node, lupaContratos, "CtrContratos"))
        Contratos.Nodes.Add(New CustomControls.TreeNode("Contratos", CustomControls.TreeNode.nodeType.node, lupaContratos, "Contratoslupa"))
    End Function

    Private Function Vehiculos() As CustomControls.TreeNode
        Vehiculos = New CustomControls.TreeNode("Vehículos", CustomControls.TreeNode.nodeType.container, "Vehiculos")
        Vehiculos.Nodes.Add(New CustomControls.TreeNode("Vehículos", CustomControls.TreeNode.nodeType.node, "KarvePruebas.Form2", "VehiVehiculos"))

    End Function

#Region "Auxiliares"

    Private Function Auxiliares() As CustomControls.TreeNode
        Auxiliares = New CustomControls.TreeNode("Auxiliares", CustomControls.TreeNode.nodeType.container)
        Auxiliares.Nodes.Add(AuxiliaresClientes())
        Auxiliares.Nodes.Add(AuxiliaresVehiculos())
        Auxiliares.Nodes.Add(AuxiliaresComisionistas())
        Auxiliares.Nodes.Add(AuxiliaresProveedores())
        Auxiliares.Nodes.Add(AuxiliaresTarifas())
        Auxiliares.Nodes.Add(AuxiliaresContratos())
        Auxiliares.Nodes.Add(New CustomControls.TreeNode("Textos Estandars", CustomControls.TreeNode.nodeType.node, ""))
    End Function

    Private Function AuxiliaresClientes() As CustomControls.TreeNode
        Dim img As Image = TemaAplicacion.IconosTree(Theme.ThemeDefault.euIconosTree.Auxiliares_Ict)
        AuxiliaresClientes = New CustomControls.TreeNode("Clientes", CustomControls.TreeNode.nodeType.container)
        AuxiliaresClientes.Nodes.Add(New CustomControls.TreeNode("Actividades Comerciales", CustomControls.TreeNode.nodeType.node, lupaActividadesCliente, "", img))
        AuxiliaresClientes.Nodes.Add(New CustomControls.TreeNode("Bancos", CustomControls.TreeNode.nodeType.node, lupaBancosCliente, "", img))
        AuxiliaresClientes.Nodes.Add(New CustomControls.TreeNode("Bloque de Facturación", CustomControls.TreeNode.nodeType.node, lupaBloquesFacturacion, "", img))
        AuxiliaresClientes.Nodes.Add(New CustomControls.TreeNode("Canales", CustomControls.TreeNode.nodeType.node, lupaCanalCliente, "", img))
        AuxiliaresClientes.Nodes.Add(New CustomControls.TreeNode("Cargos del Personal", CustomControls.TreeNode.nodeType.node, lupaCargosPersonalCliente, "", img))
        AuxiliaresClientes.Nodes.Add(New CustomControls.TreeNode("Claves de Presupuesto", CustomControls.TreeNode.nodeType.node, lupaClavePto, "", img))
        AuxiliaresClientes.Nodes.Add(New CustomControls.TreeNode("Formas de Cobro", CustomControls.TreeNode.nodeType.node, ""))
        AuxiliaresClientes.Nodes.Add(New CustomControls.TreeNode("Mercados", CustomControls.TreeNode.nodeType.node, lupaMercadosCliente, "", img))
        AuxiliaresClientes.Nodes.Add(New CustomControls.TreeNode("Negocios", CustomControls.TreeNode.nodeType.node, lupaNegociosCliente, "", img))
        AuxiliaresClientes.Nodes.Add(New CustomControls.TreeNode("Origen de Clientes", CustomControls.TreeNode.nodeType.node, lupaOrigenesCliente, "", img))
        AuxiliaresClientes.Nodes.Add(New CustomControls.TreeNode("Paises", CustomControls.TreeNode.nodeType.node, lupaPais, "", img))
        AuxiliaresClientes.Nodes.Add(New CustomControls.TreeNode("Poblaciones", CustomControls.TreeNode.nodeType.node, lupaPoblacion, ""))
        AuxiliaresClientes.Nodes.Add(New CustomControls.TreeNode("Provincias", CustomControls.TreeNode.nodeType.node, lupaProvincia, "", img))
        AuxiliaresClientes.Nodes.Add(New CustomControls.TreeNode("Sectores de Actividad", CustomControls.TreeNode.nodeType.node, lupaActividadesCliente, "", img))
        AuxiliaresClientes.Nodes.Add(New CustomControls.TreeNode("Tarjetas de Credito", CustomControls.TreeNode.nodeType.node, lupaTarjetasCredito, "", img))
        AuxiliaresClientes.Nodes.Add(New CustomControls.TreeNode("Tarjetas de Empresa", CustomControls.TreeNode.nodeType.node, lupaTarjetasEmpresa, "", img))
        AuxiliaresClientes.Nodes.Add(New CustomControls.TreeNode("Tipos de Clientes", CustomControls.TreeNode.nodeType.node, lupaTipoCliente, "", img))
        AuxiliaresClientes.Nodes.Add(New CustomControls.TreeNode("Tipo de Documentos", CustomControls.TreeNode.nodeType.node, lupaTipoDocumentos, "", img))
        AuxiliaresClientes.Nodes.Add(New CustomControls.TreeNode("Tipos de Visitas", CustomControls.TreeNode.nodeType.node, lupaTiposVisita, "", img))
        AuxiliaresClientes.Nodes.Add(New CustomControls.TreeNode("Uso Alquiler", CustomControls.TreeNode.nodeType.node, lupaUsoAlquilerCliente, "", img))
        AuxiliaresClientes.Nodes.Add(New CustomControls.TreeNode("Vendedores", CustomControls.TreeNode.nodeType.node, lupaVendedores, "", img))
        AuxiliaresClientes.Nodes.Add(New CustomControls.TreeNode("Agentes", CustomControls.TreeNode.nodeType.node, ""))
        AuxiliaresClientes.Nodes.Add(New CustomControls.TreeNode("Zonas", CustomControls.TreeNode.nodeType.node, lupaZonas, "", img))
    End Function

    Private Function AuxiliaresVehiculos() As CustomControls.TreeNode
        Dim img As Image = TemaAplicacion.IconosTree(Theme.ThemeDefault.euIconosTree.Auxiliares_Car)
        AuxiliaresVehiculos = New CustomControls.TreeNode("Vehículos", CustomControls.TreeNode.nodeType.container)
        AuxiliaresVehiculos.Nodes.Add(New CustomControls.TreeNode("Actividades de Vehículos", CustomControls.TreeNode.nodeType.node, lupaActividadesVehiculo, "", img))
        AuxiliaresVehiculos.Nodes.Add(New CustomControls.TreeNode("Tipos", CustomControls.TreeNode.nodeType.node, lupaTiposVehiculo, "", img))
        AuxiliaresVehiculos.Nodes.Add(New CustomControls.TreeNode("Colores", CustomControls.TreeNode.nodeType.node, lupaColoresVehiculo, "", img))
        AuxiliaresVehiculos.Nodes.Add(New CustomControls.TreeNode("Extras", CustomControls.TreeNode.nodeType.node, lupaExtrasVehiculo, "", img))
        AuxiliaresVehiculos.Nodes.Add(New CustomControls.TreeNode("Grupos de Vehiculos", CustomControls.TreeNode.nodeType.node, lupaGruposVehiculo, "", img))
        AuxiliaresVehiculos.Nodes.Add(New CustomControls.TreeNode("Codigos de Mantenimiento", CustomControls.TreeNode.nodeType.node, ""))
        AuxiliaresVehiculos.Nodes.Add(New CustomControls.TreeNode("Marcas", CustomControls.TreeNode.nodeType.node, lupaMarcasVehiculo, "", img))
        AuxiliaresVehiculos.Nodes.Add(New CustomControls.TreeNode("Modelos", CustomControls.TreeNode.nodeType.node, lupaModelosVehiculo, "", img))
        AuxiliaresVehiculos.Nodes.Add(New CustomControls.TreeNode("Motivos de Repostaje", CustomControls.TreeNode.nodeType.node, lupaMotivosRepostaje, "", img))
        AuxiliaresVehiculos.Nodes.Add(New CustomControls.TreeNode("Propietarios", CustomControls.TreeNode.nodeType.node, ""))
    End Function

    Private Function AuxiliaresComisionistas() As CustomControls.TreeNode
        AuxiliaresComisionistas = New CustomControls.TreeNode("Comisionistas", CustomControls.TreeNode.nodeType.container)
        AuxiliaresComisionistas.Nodes.Add(New CustomControls.TreeNode("Tipo Comisionista", CustomControls.TreeNode.nodeType.node, ""))
        AuxiliaresComisionistas.Nodes.Add(New CustomControls.TreeNode("Empleados de Agencia", CustomControls.TreeNode.nodeType.node, ""))
    End Function

    Private Function AuxiliaresProveedores() As CustomControls.TreeNode
        Dim img As Image = TemaAplicacion.IconosTree(Theme.ThemeDefault.euIconosTree.Auxiliares_Ict)
        AuxiliaresProveedores = New CustomControls.TreeNode("Proveedores", CustomControls.TreeNode.nodeType.container)
        AuxiliaresProveedores.Nodes.Add(New CustomControls.TreeNode("Bancos", CustomControls.TreeNode.nodeType.node, lupaBancosCliente, "", img))
        AuxiliaresProveedores.Nodes.Add(New CustomControls.TreeNode("Formas de Pago", CustomControls.TreeNode.nodeType.node, ""))
        AuxiliaresProveedores.Nodes.Add(New CustomControls.TreeNode("Tipos", CustomControls.TreeNode.nodeType.node, lupaTiposProvee, "", img))
        AuxiliaresProveedores.Nodes.Add(New CustomControls.TreeNode("Divisas", CustomControls.TreeNode.nodeType.node, lupaDivisas, ""))
    End Function

    Private Function AuxiliaresTarifas() As CustomControls.TreeNode
        Dim img As Image = TemaAplicacion.IconosTree(Theme.ThemeDefault.euIconosTree.Auxiliares_Ict)
        AuxiliaresTarifas = New CustomControls.TreeNode("Tarifas", CustomControls.TreeNode.nodeType.container)
        AuxiliaresTarifas.Nodes.Add(New CustomControls.TreeNode("Conceptos de Facturación", CustomControls.TreeNode.nodeType.node, lupaConceptosFacturacion, "", img))
        AuxiliaresTarifas.Nodes.Add(New CustomControls.TreeNode("Grupos de Tarifas", CustomControls.TreeNode.nodeType.node, ""))
    End Function

    Private Function AuxiliaresContratos() As CustomControls.TreeNode
        AuxiliaresContratos = New CustomControls.TreeNode("Auxiliares", CustomControls.TreeNode.nodeType.container, "", "AuxCtr")
        AuxiliaresContratos.Nodes.Add(New CustomControls.TreeNode("Tipos de Impreso Contrato", CustomControls.TreeNode.nodeType.node, ""))
        AuxiliaresContratos.Nodes.Add(New CustomControls.TreeNode("Motivos de Anulación", CustomControls.TreeNode.nodeType.node, ""))
        AuxiliaresContratos.Nodes.Add(New CustomControls.TreeNode("Motivos de Cancelación", CustomControls.TreeNode.nodeType.node, ""))
        AuxiliaresContratos.Nodes.Add(New CustomControls.TreeNode("Lugares de Entrega", CustomControls.TreeNode.nodeType.node, ""))
        AuxiliaresContratos.Nodes.Add(New CustomControls.TreeNode("Codigos Incidencias", CustomControls.TreeNode.nodeType.node, ""))
        AuxiliaresContratos.Nodes.Add(New CustomControls.TreeNode("Motivos Imroductivo", CustomControls.TreeNode.nodeType.node, ""))
    End Function

#End Region

End Class
