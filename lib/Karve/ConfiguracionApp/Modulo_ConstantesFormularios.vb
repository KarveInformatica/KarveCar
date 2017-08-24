Public Module Modulo_ConstantesFormularios

#Region "Constantes Formularios"

#Region "Clientes"
    Public frmClientes As String
    Public lupaClientes As String
#End Region

#Region "Proveedores"
    Public frmProvee As String
    Public lupaProvee As String
#End Region

#Region "Oficinas"
    Public frmOficina As String
    Public lupaOficina As String
#End Region

#Region "Facturas"
    Public frmFacturas As String
    Public lupaFacturas As String
#End Region

#Region "Vehiculos"
    Public Vehiculos As String
    Public lupaVehiculos As String
#End Region

#Region "Tarifas"
    Public Tarifas As String
    Public lupaTarifas As String
#End Region

#Region "Contratos"
    Public frmContratos As String
    Public lupaContratos As String
#End Region

#Region "Reservas"
    Public frmReservas As String
    Public lupaReservas As String
#End Region

#Region "Auxiliares"

#Region "   .   ActividadesCliente. "

    Public lupaActividadesCliente As String
    Public ActividadesCliente As String

#End Region

#Region "   .   ActividadesVehiculo. "

    Public lupaActividadesVehiculo As String
    Public ActividadesVehiculo As String

#End Region

#Region "   .   BancosCliente. "

    Public lupaBancosCliente As String
    Public BancosCliente As String

#End Region

#Region "   .   BloquesFacturacion. "

    Public lupaBloquesFacturacion As String
    Public BloquesFacturacion As String

#End Region

#Region "   .   CanalesCliente. "

    Public lupaCanalCliente As String
    Public CanalesCliente As String

#End Region

#Region "   .   CargosPersonalCliente. "

    Public lupaCargosPersonalCliente As String
    Public CargosPersonalCliente As String

#End Region

#Region "   .   ClavePto. "

    Public lupaClavePto As String
    Public ClavePto As String

#End Region

#Region "   .   ColoresVehiculo. "

    Public lupaColoresVehiculo As String
    Public ColoresVehiculo As String

#End Region

#Region "   .   ConceptosFacturacion"
    Public frmConceptosFacturacion As String
    Public lupaConceptosFacturacion As String
#End Region

#Region "   .   CtasContables. "

    Public lupaCtasContables As String
    Public CtasContables As String

#End Region

#Region "   .   CtasContables. "

    Public lupaDivisas As String
    Public Divisas As String

#End Region

#Region "   .   ExtrasVehiculo. "

    Public lupaExtrasVehiculo As String
    Public ExtrasVehiculo As String

#End Region

#Region "   .   FormasProvee. "

    Public lupaFormasProvee As String
    Public FormasProvee As String

#End Region

#Region "   .   GruposVehiculo. "

    Public lupaGruposVehiculo As String
    Public GruposVehiculo As String

#End Region

#Region "   .   Idiomas. "

    Public lupaIdiomas As String
    Public Idiomas As String

#End Region

#Region "   .   MarcasVehiculo. "

    Public lupaMarcasVehiculo As String
    Public MarcasVehiculo As String

#End Region

#Region "   .   ModelosVehiculo. "

    Public lupaModelosVehiculo As String
    Public ModelosVehiculo As String

#End Region

#Region "   .   MercadosCliente. "

    Public lupaMercadosCliente As String
    Public MercadosCliente As String

#End Region

#Region "   .   MotivosRepostaje. "

    Public lupaMotivosRepostaje As String
    Public MotivosRepostaje As String

#End Region

#Region "   .   NegociosCliente. "

    Public lupaNegociosCliente As String
    Public NegociosCliente As String

#End Region

#Region "   .   OrigenesCliente. "

    Public lupaOrigenesCliente As String
    Public OrigenesCliente As String

#End Region

#Region "   .   Provincia. "

    Public lupaProvincia As String
    Public Provincia As String

#End Region

#Region "   .   Pais. "

    Public lupaPais As String
    Public Pais As String

#End Region

#Region "   .   Población. "

    Public lupaPoblacion As String
    Public Poblacion As String

#End Region

#Region "   .   TarjetasCredito. "

    Public lupaTarjetasCredito As String
    Public TarjetasCredito As String

#End Region

#Region "   .   TarjetasEmpresa. "

    Public lupaTarjetasEmpresa As String
    Public TarjetasEmpresa As String

#End Region

#Region "   .   TipoCliente. "

    Public lupaTipoCliente As String
    Public TiposCliente As String

#End Region

#Region "   .   TipoDocumentos. "

    Public lupaTipoDocumentos As String
    Public TiposDocumentos As String

#End Region

#Region "   .   TiposProvee. "

    Public lupaTiposProvee As String
    Public TiposProvee As String

#End Region

#Region "   .   TiposVehiculo. "

    Public lupaTiposVehiculo As String
    Public TiposVehiculo As String

#End Region

#Region "   .   TiposVisitaCliente. "

    Public lupaTiposVisita As String
    Public TiposVisita As String

#End Region

#Region "   .   UsoAlquiler. "

    Public lupaUsoAlquilerCliente As String
    Public UsoAlquilerCliente As String

#End Region

#Region "   .   Vendedores. "

    Public lupaVendedores As String
    Public Vendedores As String

#End Region

#Region "   .   Zonas. "

    Public lupaZonas As String
    Public Zonas As String

#End Region

#End Region

#End Region

#Region "Cargar Constantes"

    Public Sub CargarConstantesFormularios()
        CargarConstantesFormulariosCoches()
    End Sub

    Private Sub CargarConstantesFormulariosCoches()

        CargarConstantesAuxiliaresCoches()
        CargarConstantesOperacionesCoches()
        CargarConstantesMaestrosCoches()

    End Sub

    Public Sub CargarConstantesMaestrosCoches()
        Clientes_s()
        Provee_s()
        Oficina_s()
        Vehiculos_s()
        Tarifas_s()
    End Sub

    Public Sub CargarConstantesOperacionesCoches()
        Facturas_s()
        Contratos_s_RC()
        Reservas_s_RC()
    End Sub

    Public Sub CargarConstantesAuxiliaresCoches()
        ActividadesCliente_s()
        ActividadesVehiculo_s()
        BancosCliente_s()
        BloquesFacturacion_s()
        CanalesCliente_s()
        CargosPersonalCliente_s()
        ClavePto_s()
        ColoresVehiculo_s()
        ConceptosFacturacion_s()
        CtasContables_s()
        FormasProvee_s()
        GruposVehiculo_s()
        Idiomas_s()
        MarcasVehiculo_s()
        ModelosVehiculo_s()
        MercadosCliente_s()
        MotivosRepostaje_s()
        NegociosCliente_s()
        OrigenesCliente_s()
        Pais_s()
        Provincia_s()
        TarjetasCredito_s()
        TiposCliente_s()
        TiposProvee_s()
        TiposVehiculo_s()
        UsoAlquilerCliente_s()
        Zonas_s()
        Vendedores_s()
        TiposVisita_s()
        TarjetasEmpresa_s()
        TipoDocumentos_s()
        ExtrasVehiculo_s()
        Divisas_s()
        Poblacion_s()
    End Sub

    Private Sub ActividadesCliente_s()
        ActividadesCliente = "Karve.frm.Auxiliares.ActividadesCliente"
        lupaActividadesCliente = "Karve.frm.Auxiliares.ActividadesClienteCons"
    End Sub

    Private Sub ActividadesVehiculo_s()
        ActividadesVehiculo = "Karve.frm.Auxiliares.ActividadVehiculo"
        lupaActividadesVehiculo = "Karve.frm.Auxiliares.ActividadesVehiculoCons"
    End Sub

    Private Sub BancosCliente_s()
        BancosCliente = "Karve.frm.Auxiliares.BancosCliente"
        lupaBancosCliente = "Karve.frm.Auxiliares.BancosClienteCons"
    End Sub

    Private Sub BloquesFacturacion_s()
        BloquesFacturacion = "Karve.frm.Auxiliares.BloquesFacturacion"
        lupaBloquesFacturacion = "Karve.frm.Auxiliares.BloquesFacturacionCons"
    End Sub

    Private Sub CanalesCliente_s()
        lupaCanalCliente = "Karve.frm.Auxiliares.CanalesClienteCons"
        CanalesCliente = "Karve.frm.Auxiliares.CanalesCliente"
    End Sub

    Private Sub CargosPersonalCliente_s()
        lupaCargosPersonalCliente = "Karve.frm.Auxiliares.CargosPersonalCons"
        CargosPersonalCliente = "Karve.frm.Auxiliares.CargosPersonalCliente"
    End Sub

    Private Sub ClavePto_s()
        lupaClavePto = "Karve.frm.Auxiliares.ClavesPresupuestoCons"
        ClavePto = "Karve.frm.Auxiliares.ClavesPresupuesto"
    End Sub

    Private Sub Clientes_s()
        frmClientes = "Karve.frm.Clientes.ClientesPrueba"
        lupaClientes = "Karve.frm.Clientes.ClienteCons"
    End Sub

    Private Sub ConceptosFacturacion_s()
        frmConceptosFacturacion = "Karve.frm.Auxiliares.ConceptosFacturacion"
        lupaConceptosFacturacion = "Karve.frm.Auxiliares.ConceptosFacturacionCons"
    End Sub

    Private Sub ColoresVehiculo_s()
        ColoresVehiculo = "Karve.frm.Auxiliares.ColoresVehiculo"
        lupaColoresVehiculo = "Karve.frm.Auxiliares.ColoresVehiculoCons"
    End Sub

    Private Sub CtasContables_s()
        CtasContables = "Karve.frm.Auxiliares.CtasContables"
        lupaCtasContables = "Karve.frm.Auxiliares.CtasContablesCons"
    End Sub
    Private Sub Divisas_s()
        Divisas = "Karve.frm.Auxiliares.Divisas"
        lupaDivisas = "Karve.frm.Auxiliares.DivisasCons"
    End Sub
    Private Sub ExtrasVehiculo_s()
        ExtrasVehiculo = "Karve.frm.Auxiliares.ExtrasVehiculo"
        lupaExtrasVehiculo = "Karve.frm.Auxiliares.ExtrasVehiculoCons"
    End Sub
    Private Sub FormasProvee_s()
        FormasProvee = "Karve.frm.Auxiliares.FormasPago"
        lupaFormasProvee = "Karve.frm.Auxiliares.FormasPagoCons"
    End Sub

    Private Sub GruposVehiculo_s()
        GruposVehiculo = "Karve.frm.Auxiliares.GruposVehiculos"
        lupaGruposVehiculo = "Karve.frm.Auxiliares.GruposVehiculosCons"
    End Sub

    Private Sub Idiomas_s()
        Idiomas = "Karve.frm.Auxiliares.Idiomas"
        lupaIdiomas = "Karve.frm.Auxiliares.IdiomasCons"
    End Sub

    Private Sub Facturas_s()
        frmFacturas = "Karve.frm.Facturas.Facturas"
        lupaFacturas = "Karve.frm.Facturas.FacturasCons"
    End Sub

    Private Sub Reservas_s_RC()
        frmReservas = "Karve.frm.RentACar.Reservas"
        lupaReservas = "Karve.frm.RentACar.ReservasCons"
    End Sub

    Private Sub Contratos_s_RC()
        frmContratos = "Karve.frm.RentACar.Contratos"
        lupaContratos = "Karve.frm.RentACar.ContratosCons"
    End Sub

    Private Sub MarcasVehiculo_s()
        lupaMarcasVehiculo = "Karve.frm.Auxiliares.MarcasVehiculoCons"
        MarcasVehiculo = "Karve.frm.Auxiliares.MarcasVehiculo"
    End Sub

    Private Sub ModelosVehiculo_s()
        lupaModelosVehiculo = "Karve.frm.Auxiliares.ModelosVehiculoCons"
        ModelosVehiculo = "Karve.frm.Auxiliares.ModelosVehiculo"
    End Sub

    Private Sub MercadosCliente_s()
        lupaMercadosCliente = "Karve.frm.Auxiliares.MercadosClienteCons"
        MercadosCliente = "Karve.frm.Auxiliares.MercadosCliente"
    End Sub

    Private Sub MotivosRepostaje_s()
        lupaMotivosRepostaje = "Karve.frm.Auxiliares.MotivosRepostajeCons"
        MotivosRepostaje = "Karve.frm.Auxiliares.MotivosRepostaje"
    End Sub

    Private Sub NegociosCliente_s()
        lupaNegociosCliente = "Karve.frm.Auxiliares.NegociosClienteCons"
        NegociosCliente = "Karve.frm.Auxiliares.NegociosCliente"
    End Sub

    Private Sub Vehiculos_s()
        Vehiculos = "Karve.frm.Vehiculos.Vehiculos"
        lupaVehiculos = "Karve.frm.Vehiculos.VehiculosCons"
    End Sub

    Private Sub Tarifas_s()
        Tarifas = "Karve.frm.Tarifas.Tarifas"
        lupaTarifas = "Karve.frm.Tarifas.TarifasCons"
    End Sub

    Private Sub Oficina_s()
        lupaOficina = "Karve.frm.ConfiEmpOfi.OficinaCons"
    End Sub

    Private Sub OrigenesCliente_s()
        lupaOrigenesCliente = "Karve.frm.Auxiliares.OrigenesClienteCons"
        OrigenesCliente = "Karve.frm.Auxiliares.OrigenesCliente"
    End Sub

    Private Sub Pais_s()
        lupaPais = "Karve.frm.Auxiliares.PaisCons"
        Pais = "Karve.frm.Auxiliares.Pais"
        lupaIdiomas = "Karve.frm.Auxiliares.IdiomasCons"
    End Sub
    Private Sub Poblacion_s()
        lupaPoblacion = "Karve.frm.Auxiliares.PoblacionCons"
        Poblacion = "Karve.frm.Auxiliares.Poblacion"
    End Sub

    Private Sub Provee_s()
        frmProvee = "Karve.frm.Proveedores.Proveedores"
        lupaProvee = "Karve.frm.Proveedores.ProveedoresCons"
    End Sub

    Private Sub Provincia_s()
        lupaProvincia = "Karve.frm.Auxiliares.ProvinciaCons"
        Provincia = "Karve.frm.Auxiliares.Provincia"
        lupaPais = "Karve.frm.Auxiliares.PaisCons"
    End Sub

    Private Sub TarjetasCredito_s()
        TarjetasCredito = "Karve.frm.Auxiliares.TarjetasCredito"
        lupaTarjetasCredito = "Karve.frm.Auxiliares.TarjetaCreditoCons"
    End Sub
    Private Sub TarjetasEmpresa_s()
        TarjetasEmpresa = "Karve.frm.Auxiliares.TarjetasEmpresa"
        lupaTarjetasEmpresa = "Karve.frm.Auxiliares.TarjetasEmpresaCons"
    End Sub
    Private Sub TiposCliente_s()
        lupaTipoCliente = "Karve.frm.Auxiliares.TipoClienteCons"
        TiposCliente = "Karve.frm.Auxiliares.TiposCliente"
    End Sub
    Private Sub TipoDocumentos_s()
        lupaTipoDocumentos = "Karve.frm.Auxiliares.TipoDocumentosCons"
        TiposDocumentos = "Karve.frm.Auxiliares.TipoDocumentos"
    End Sub
    Private Sub TiposProvee_s()
        lupaTiposProvee = "Karve.frm.Auxiliares.TiposProveeCons"
        TiposProvee = "Karve.frm.Auxiliares.TiposProvee"
    End Sub

    Private Sub TiposVehiculo_s()
        lupaTiposVehiculo = "Karve.frm.Auxiliares.TiposVehiculoCons"
        TiposVehiculo = "Karve.frm.Auxiliares.TiposVehiculo"
    End Sub

    Private Sub TiposVisita_s()
        lupaTiposVisita = "Karve.frm.Auxiliares.TiposVisitaCons"
        TiposVisita = "Karve.frm.Auxiliares.TiposVisita"
    End Sub

    Private Sub UsoAlquilerCliente_s()
        lupaUsoAlquilerCliente = "Karve.frm.Auxiliares.UsoAlquilerClienteCons"
        UsoAlquilerCliente = "Karve.frm.Auxiliares.UsoAlquilerCliente"
    End Sub

    Private Sub Zonas_s()
        lupaZonas = "Karve.frm.Auxiliares.ZonasCons"
        Zonas = "Karve.frm.Auxiliares.Zonas"
    End Sub

    Private Sub Vendedores_s()
        lupaVendedores = "Karve.frm.Auxiliares.VendedoresCons"
        Vendedores = "Karve.frm.Auxiliares.Vendedores"
    End Sub
#End Region

End Module
