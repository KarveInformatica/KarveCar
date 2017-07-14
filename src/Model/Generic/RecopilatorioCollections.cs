using KRibbon.View;
using Microsoft.Windows.Controls.Ribbon;
using System.Collections.Generic;
using System.Windows;
using static KRibbon.Model.Generic.RecopilatorioEnumerations;

namespace KRibbon.Model.Generic
{
    public class RecopilatorioCollections
    {
        /// <summary>
        /// Dictionary que recopila los TabItem activos. 
        /// Key=EOpcion, 
        /// Value=DatosInfoTabItem(GenericObservableCollection obscollectionorigin, GenericObservableCollection obscollectioncopy, TabItem)
        /// </summary>
        public static Dictionary<EOpcion, TemplateInfoTabItem> tabitemdictionary = new Dictionary<EOpcion, TemplateInfoTabItem>();

        /// <summary>
        /// Dictionary que recopila la información de los RibbonButtons (la referencia en Resources, el nombre de la tabla de la BBDD)
        /// Key=EOpcion, Value=DatosInfoRibbonButton(string propertiesresources, string nombretabladb)
        /// </summary>
        public static Dictionary<EOpcion, TemplateInfoRibbonButton> ribbonbuttondictionary = new Dictionary<EOpcion, TemplateInfoRibbonButton>()
        {
            #region Maestros
            { EOpcion.rbtnBancosClientes,     new TemplateInfoRibbonButton { propertiesresources = "lrbtnBancosClientes",
                                                                             nombretabladb = "BANCO" } },
            { EOpcion.rbtnBloqueFacturacion,  new TemplateInfoRibbonButton { propertiesresources = "lrbtnBloqueFacturacion",
                                                                             nombretabladb = "BLOQUEFAC" } },
            { EOpcion.rbtnCanales,            new TemplateInfoRibbonButton { propertiesresources = "lrbtnCanales",
                                                                             nombretabladb = "CANAL" } },
            { EOpcion.rbtnCargosPersonal,     new TemplateInfoRibbonButton { propertiesresources = "lrbtnCargosPersonal",
                                                                             nombretabladb = "CATEGOPER" } },

            { EOpcion.rbtnTipoComisionista,   new TemplateInfoRibbonButton { propertiesresources = "lrbtnTipoComisionista",
                                                                             nombretabladb =  "TIPOCOMI" } },

            { EOpcion.rbtnFormaPagoProveedor, new TemplateInfoRibbonButton { propertiesresources = "lrbtnFormaPagoProveedor",
                                                                             nombretabladb = "FORPRO" } },

            { EOpcion.rbtnGruposTarifa,       new TemplateInfoRibbonButton { propertiesresources = "lrbtnGruposTarifa",
                                                                             nombretabladb = "GRUPOS_TARI" } },
            #endregion

            #region Contratos
            #endregion

            #region Reservas
            #endregion

            #region Atipicos
            #endregion

            #region Comercial
            #endregion

            #region Facturación
            #endregion

            #region Flota
            #endregion

            #region Incidencias
            #endregion

            #region Estadísticas
            #endregion

            #region Listados
            #endregion

            #region Configuración
            { EOpcion.rbtnCinta,            new TemplateInfoRibbonButton { propertiesresources = "lrbtnCinta",
                                                                           nombretabladb = string.Empty } },
            #endregion
        };

        /// <summary>
        /// Dictionary que recopila la información de los RibbonTab (el RibbonTab, sus correspondientes RibbonGroups, el CheckBox de la opción CintaOpciones)
        /// Key=ERibbonTab, Value=DatosInfoRibbonTabAndGroup(RibbonTab ribbontab, string checkbox, List<RibbonGroup> ribbongroup)
        /// </summary>
        public static Dictionary<ERibbonTab, TemplateInfoRibbonTabAndGroup> ribbontabdictionary = new Dictionary<ERibbonTab, TemplateInfoRibbonTabAndGroup> ()
        {
            { ERibbonTab.rbtbMaestros,      new TemplateInfoRibbonTabAndGroup { ribbontab = ((MainWindow)Application.Current.MainWindow).rbtbMaestros,
                                                                              checkbox  = "ckbCintaOpcionesMaestros",
                                                                              ribbongroup = new List<RibbonGroup>() {
                                                                                            ((MainWindow)Application.Current.MainWindow).rgrCentrosAlquiler ,
                                                                                            ((MainWindow)Application.Current.MainWindow).rgrClientes,
                                                                                            ((MainWindow)Application.Current.MainWindow).rgrComisionistas,
                                                                                            ((MainWindow)Application.Current.MainWindow).rgrProveedores,
                                                                                            ((MainWindow)Application.Current.MainWindow).rgrTarifas,
                                                                                            ((MainWindow)Application.Current.MainWindow).rgrVehiculos,
                                                                                            ((MainWindow)Application.Current.MainWindow).rgrAuxiliares } }},

            { ERibbonTab.rbtbContratos,     new TemplateInfoRibbonTabAndGroup { ribbontab = ((MainWindow)Application.Current.MainWindow).rbtbContratos,
                                                                              checkbox  = "ckbCintaOpcionesContratos",
                                                                              ribbongroup = new List<RibbonGroup>() {
                                                                                            ((MainWindow)Application.Current.MainWindow).rgrContratos,
                                                                                            ((MainWindow)Application.Current.MainWindow).rgrCambiosContratos,
                                                                                            ((MainWindow)Application.Current.MainWindow).rgrVariosContratos } } },

            { ERibbonTab.rbtbReservas,      new TemplateInfoRibbonTabAndGroup { ribbontab = ((MainWindow)Application.Current.MainWindow).rbtbReservas,
                                                                              checkbox  = "ckbCintaOpcionesReservas",
                                                                              ribbongroup = new List<RibbonGroup>() {
                                                                                            ((MainWindow)Application.Current.MainWindow).rgrReservas } } },
            { ERibbonTab.rbtbAtipicos,      new TemplateInfoRibbonTabAndGroup { ribbontab = ((MainWindow)Application.Current.MainWindow).rbtbAtipicos,
                                                                              checkbox  = "ckbCintaOpcionesAtipicos",
                                                                              ribbongroup = new List<RibbonGroup>() {
                                                                                            ((MainWindow)Application.Current.MainWindow).rgrAtipicos } } },
            { ERibbonTab.rbtbComercial,     new TemplateInfoRibbonTabAndGroup { ribbontab = ((MainWindow)Application.Current.MainWindow).rbtbComercial,
                                                                              checkbox  = "ckbCintaOpcionesComercial",
                                                                              ribbongroup = new List<RibbonGroup>() {
                                                                                            ((MainWindow)Application.Current.MainWindow).rgrComercial } } },

            { ERibbonTab.rbtbFacturacion,   new TemplateInfoRibbonTabAndGroup { ribbontab = ((MainWindow)Application.Current.MainWindow).rbtbFacturacion,
                                                                              checkbox  = "ckbCintaOpcionesFacturacion",
                                                                              ribbongroup = new List<RibbonGroup>() {
                                                                                            ((MainWindow)Application.Current.MainWindow).rgrFacturacion,
                                                                                            ((MainWindow)Application.Current.MainWindow).rgrRecibosCartera,
                                                                                            ((MainWindow)Application.Current.MainWindow).rgrRemesas,
                                                                                            ((MainWindow)Application.Current.MainWindow).rgrEnlacesContables,
                                                                                            ((MainWindow)Application.Current.MainWindow).rgrExportacion,
                                                                                            ((MainWindow)Application.Current.MainWindow).rgrImpresion,
                                                                                            ((MainWindow)Application.Current.MainWindow).rgrEstadisticasFacturas } } },        

            { ERibbonTab.rbtbFlota,         new TemplateInfoRibbonTabAndGroup { ribbontab = ((MainWindow)Application.Current.MainWindow).rbtbFlota,
                                                                              checkbox  = "ckbCintaOpcionesFlota",
                                                                              ribbongroup = new List<RibbonGroup>() {
                                                                                            ((MainWindow)Application.Current.MainWindow).rgrInmovilizaciones,
                                                                                            ((MainWindow)Application.Current.MainWindow).rgrUtilidades,
                                                                                            ((MainWindow)Application.Current.MainWindow).rgrVariosFlota } } },

            { ERibbonTab.rbtbIncidencias,   new TemplateInfoRibbonTabAndGroup { ribbontab = ((MainWindow)Application.Current.MainWindow).rbtbIncidencias,
                                                                              checkbox  = "ckbCintaOpcionesIncidencias",
                                                                              ribbongroup = new List<RibbonGroup>() {
                                                                                            ((MainWindow)Application.Current.MainWindow).rgrIncidencias } } },
            { ERibbonTab.rbtbEstadisticas,  new TemplateInfoRibbonTabAndGroup { ribbontab = ((MainWindow)Application.Current.MainWindow).rbtbEstadisticas,
                                                                              checkbox  = "ckbCintaOpcionesEstadisticas",
                                                                              ribbongroup = new List<RibbonGroup>() {
                                                                                         ((MainWindow)Application.Current.MainWindow).rgrEstadisticas } } },
            { ERibbonTab.rbtbListados,      new TemplateInfoRibbonTabAndGroup { ribbontab = ((MainWindow)Application.Current.MainWindow).rbtbListados,
                                                                              checkbox  = "ckbCintaOpcionesListados",
                                                                              ribbongroup = new List<RibbonGroup>() {
                                                                                          ((MainWindow)Application.Current.MainWindow).rgrListados } } },

            { ERibbonTab.rbtbConfiguracion, new TemplateInfoRibbonTabAndGroup { ribbontab = ((MainWindow)Application.Current.MainWindow).rbtbConfiguracion,
                                                                              checkbox  = "ckbCintaOpcionesConfiguracion",
                                                                              ribbongroup = new List<RibbonGroup>() {
                                                                                            ((MainWindow)Application.Current.MainWindow).rgrConfiguracion,
                                                                                            ((MainWindow)Application.Current.MainWindow).rgrIdiomas,
                                                                                            ((MainWindow)Application.Current.MainWindow).rgrPersonal,
                                                                                            ((MainWindow)Application.Current.MainWindow).rgrUtilitarios,
                                                                                            ((MainWindow)Application.Current.MainWindow).rgrVariosConfiguracion,
                                                                                            ((MainWindow)Application.Current.MainWindow).rgrKarve } } }
        };


        /// <summary>
        /// List que recopila los RibbonTab
        /// </summary>
        public static List<RibbonTab> ribbontablist = new List<RibbonTab>()
        {
            ((MainWindow)Application.Current.MainWindow).rbtbMaestros,
            ((MainWindow)Application.Current.MainWindow).rbtbContratos,
            ((MainWindow)Application.Current.MainWindow).rbtbReservas,
            ((MainWindow)Application.Current.MainWindow).rbtbAtipicos,
            ((MainWindow)Application.Current.MainWindow).rbtbComercial,
            ((MainWindow)Application.Current.MainWindow).rbtbFacturacion,
            ((MainWindow)Application.Current.MainWindow).rbtbFlota,
            ((MainWindow)Application.Current.MainWindow).rbtbIncidencias,
            ((MainWindow)Application.Current.MainWindow).rbtbListados,
            ((MainWindow)Application.Current.MainWindow).rbtbConfiguracion
        };
    }
}
