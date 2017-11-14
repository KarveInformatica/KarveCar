using KarveCar.Model.Sybase;
using KarveCar.Properties;
using KarveCar.View;
using System.Windows.Controls.Ribbon;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using KarveCar.ViewModels;
using static KarveCar.Model.Generic.RecopilatorioCollections;

namespace KarveCar.Utility
{
    public class UserAndDefaultConfig
    {
        /// <summary>
        /// Devuelve el Value de la Key recibida por params desde el archivo app.exe.config
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetSetting(string key)
        {
            string value = null;
            try
            {   //Recupera el Value de la Key recibida por params desde el archivo app.exe.config
                value = ConfigurationManager.AppSettings[key].ToString();
            }
            catch
            {   //en caso contrario, devuelve un string vacío
                value = string.Empty;
            }
            return value;
        }

        /// <summary>
        /// Guarda en el archivo app.exe.config la configuración personalizada del usuario
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private static bool SetSetting(string key, string value)
        {
            bool result = false;
            try
            {
                //La línea siguiente no funcionará bien en tiempo de diseño pues VC# usa el fichero 
                //xxx.vshost.config en la depuración:
                //Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                //Así pues utilizamos: 
                Configuration config = ConfigurationManager.OpenExeConfiguration(System.Reflection.Assembly.GetExecutingAssembly().Location);

                //Eliminamos la key (si existe). Si no se elimina la key, los valores se irán acumulando separados por coma 
                config.AppSettings.Settings.Remove(key);

                //Asignamos el valor en la clave indicada 
                config.AppSettings.Settings.Add(key, value);

                //Guardamos los cambios definitivamente en el fichero de configuración 
                config.Save(ConfigurationSaveMode.Modified);
            }
            catch (Exception e)
            {
                ErrorsGeneric.MessageError(e);
            }
            return result;
        }

        /// <summary>
        /// Devuelve un Boolean si se carga correctamente la configuración por defecto desde Variablesglobales.ribbontabdictionary,
        /// del RibbonTab recibido por params
        /// </summary>
        /// <param name="ribbontab"></param>
        /// <returns></returns>
        public static bool GetDefaultRibbonTabConfig(RibbonTab ribbontab)
        {
            bool result = false;
            /*
            try
            { 
                if (ribbontab.Items.Count > 0)
                {   //Vacía los items del RibbonTab pasado por params. Este paso es necesario antes de añadir los RibbonGroups con el nuevo orden
                    ribbontab.Items.Clear();
                    
                    //Se recuperan los RibbonGroups del Ribbontab pasado por params
                    List<RibbonGroup> ribbontabdic = ribbontabdictionary.Where(r => r.Key.ToString() == ribbontab.Name.ToString()).FirstOrDefault().Value.ribbongroup;

                    //Se recorren los RibbonGroups del Ribbontab pasado por params. Al Name del RibbonTab se le añade el índex ya que
                    //la es como se guardan las Key en app.exe.config. Se recupera el Name del RibbonGroup. Se guarda en el archivo 
                    //app.exe.config la configuración personalizada del usuario (Key=RibbonTab.Name+Index, Value=RibbonGroup.Name)
                    int j = 0;
                    foreach (var item in ribbontabdic)
                    {
                        ribbontab.Items.Insert(j, item);
                        string ribbontabname = string.Format("{0}{1}", ribbontab.Name.ToString(), j);
                        string ribbongroupname = item.Name.ToString();
                        SetSetting(ribbontabname, ribbongroupname);
                        j++;
                    }                
                }
                result = true;
            }
            catch (Exception e)
            {                
                ErrorsGeneric.MessageError(e);
            }
            */
            return result;
        }

        /// <summary>
        /// Guarda la configuración por defecto (Variablesglobales.Dictionary<ERibbonTab, RibbonTabAndGroup> ribbontabdictionary )
        /// de los RibbonGroups de los RibbonTab seleccionados
        /// </summary>
        /// <param name="cintaopcionesusercontrol"></param>
        public static void SetDefaultRibbonTabConfig(CintaOpcionesUserControl cintaopcionesusercontrol)
        {
            try
            {   //Boolean = true, Indica que se ha marcado algún Checkbox, y mostrará un mensaje de información para el usuario
                bool result = false;
                //Recorre los controles de la Grid que contiene los Checkbox. Si el Control es un CheckBox comprobará si está marcado, y en ese caso,
                //se reordenará a la configuración por defecto el RibbonTab según establecido en VariablesGlobales.ribbontabdictionary  
                foreach (Control control in cintaopcionesusercontrol.grdCintaOpciones.Children)
                {
                    if (control is CheckBox)
                    {
                        CheckBox checkbox = control as CheckBox;
                        if (checkbox.IsChecked == true)
                        {
                            string ribbontabname = ribbontabdictionary.Where(r => r.Value.checkbox.Equals(checkbox.Name.ToString())).FirstOrDefault().Key.ToString();
                            RibbonTab ribbontab = ribbontabdictionary.Where(r => r.Key.ToString().Equals(ribbontabname)).FirstOrDefault().Value.ribbontab;
                            if (GetDefaultRibbonTabConfig(ribbontab))
                            {
                                result = true;
                            }
                        }
                    }
                }
                if (result)
                {
                    MessageBox.Show(Resources.msgSaveCintaOpcionesOK, Resources.lrbtnCinta, MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception e)
            {
                ErrorsGeneric.MessageError(e);
            }
        }

        /// <summary>
        /// Devuelve la configuración personalizada de los RibbonGroups del RibbonTab recibido por params
        /// </summary>
        /// <param name="ribbontab"></param>
        public static List<RibbonGroup> GetCurrentUserRibbonTabConfig(RibbonTab ribbontab)
        {
            List<RibbonGroup> rbgroup = new List<RibbonGroup>();
            try
            {
                if (ribbontab.Items.Count > 0)
                {
                    int ribbontabcount = ribbontab.Items.Count;
                    //Vacía los items del RibbonTab pasado por params. Este paso es necesario antes de añadir los RibbonGroups con el nuevo orden
                    ribbontab.Items.Clear();

                    //Se recorre el RibbonTab pasado por params. Al Name del RibbonTab se le añade el índex ya que la es como se guardan las Key 
                    //en app.exe.config. Se recuperan los RibbonGroups del Ribbontab pasado por params, y después se recupera concretamente el 
                    //RibbonGroup con el Name según la Key RibbonTab+Index. Se añade el RibbonGroup al RibbonTab
                    for (int i = 0; i < ribbontabcount; i++)
                    {
                        string ribbontabname = string.Format("{0}{1}", ribbontab.Name.ToString(), i);
                        string ribbongroupname = GetSetting(ribbontabname);

                        List<RibbonGroup> ribbontablist = ribbontabdictionary.Where(r => r.Key.ToString() == ribbontab.Name.ToString()).FirstOrDefault().Value.ribbongroup;
                        RibbonGroup ribbongroup = ribbontablist.Where(r => r.Name.ToString() == ribbongroupname).FirstOrDefault();

                        ribbontab.Items.Insert(i, ribbongroup);
                        if(ribbongroup != null)
                        {
                            rbgroup.Add(ribbongroup);
                        }
                    }
                }
                return rbgroup;
            }
            catch (Exception e)
            {
                ErrorsGeneric.MessageError(e);
            }
            return null;
        }

        /// <summary>
        /// Guarda la configuración personalizada de los RibbonGroups del RibbonTab en el cual se está utilizando
        /// </summary>
        /// <param name="ribbontab"></param>
        public static void SetCurrentUserRibbonTabConfig(RibbonTab ribbontab)
        {
            try
            { 
                if (ribbontab.Items.Count > 0)
                {   //Se recorre el RibbonTab pasado por params. Al Name del RibbonTab se le añade el índex ya que la es como se guardan 
                    //las Key en app.exe.config. Se recupera el Name del RibbonGroup. Se guarda en el archivo app.exe.config la configuración 
                    //personalizada del usuario (Key=RibbonTab.Name+Index, Value=RibbonGroup.Name)
                    int j = 0;
                    foreach (var item in ribbontab.Items)
                    {
                        RibbonGroup rbgroup = (RibbonGroup) item;
                        string ribbontabname = string.Format("{0}{1}", ribbontab.Name.ToString(), j);
                        string ribbongroupname = rbgroup.Name.ToString();                    
                        SetSetting(ribbontabname, ribbongroupname);
                        j++;
                    }
                }
            }
            catch (Exception e)
            {
                ErrorsGeneric.MessageError(e);
            }
        }

        /// <summary>
        /// Establece el idioma de la app según esté guardado en app.exe.config. 
        /// </summary>
        /// TODO: fix the language support.
        public static void GetLanguage()
        {
            try
            {   //Recupera el idioma desde el archivo app.exe.config con la Key "Language", y se lo pasa al 
                //SetLanguagesViewModel.SetLanguages para que cargue el idioma deseado
                string lang = GetSetting("Language");
                if (!lang.Equals(string.Empty))
                {
              //      KarveCar.Views.MainWindow window = Application.Current.MainWindow as KarveCar.Views.MainWindow;
                ///    MainWindowViewModel slvm = new MainWindowViewModel(window.UnityContainer);
                  //  slvm.SetLanguages(lang);
                }
            }
            catch (Exception e)
            {
                ErrorsGeneric.MessageError(e);
            }
        }

        /// <summary>
        /// Guarda la configuración personalizada del idioma
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void SetCurrentUserLanguage(string key, string value)
        {   //Se guarda en el archivo app.exe.config el idioma personalizado del usuario (Key="Language", Value=CultureInfo según el RibbonButton seleccionado)
            SetSetting(key, value);
        }

        /// <summary>
        /// Carga la configuración por defecto de los RibbonTab
        /// </summary>
        public static void LoadDefaultRibbonTabConfig()
        {
            try
            {
                //Carga el idioma de la app según esté guardado en app.exe.config 
                GetLanguage();
                //Recorre los diferentes RibbonTab guardados en VariablesGlobales.ribbontabdictionary
                foreach (var item in ribbontabdictionary)
                {   //Para cada RibbonTab, se cargan los RibbonGroups de la configuración por defecto según VariablesGlobales.ribbontabdictionary
                    if (item.Value.ribbontab != null)
                    {
                        GetDefaultRibbonTabConfig(item.Value.ribbontab);
                    }
                }
            }
            catch (Exception e)
            {
                ErrorsGeneric.MessageError(e);
            }
        }

        /// <summary>
        /// Carga la configuración personalizada del usuario de los RibbonTab. En caso de que no haya configuración personalizada del usuario, 
        /// se carga la configuración por defecto según VariablesGlobales.ribbontabdictionary
        /// </summary>
        public static void LoadCurrentUserRibbonTabConfig()
        {
            try
            {
                //Carga el idioma de la app según esté guardado en app.exe.config 
                GetLanguage();
                //Recorre los diferentes RibbonTab guardados en VariablesGlobales.ribbontabdictionary
                foreach (var item in ribbontabdictionary)
                {
                    if (item.Value.ribbontab != null)
                    {   //Para cada RibbonTab, se devuelve una List con los RibbonGroups que contiene. En caso que la List se reciba vacía, se cargarán
                        //los RibbonGroups de la configuración por defecto, en caso contrario, se habrán cargado los RibbonGroups personalizados del usuario
                        List<RibbonGroup> rbgroup = GetCurrentUserRibbonTabConfig(item.Value.ribbontab);

                        if (rbgroup == null || rbgroup.Count == 0)
                        {
                            GetDefaultRibbonTabConfig(item.Value.ribbontab);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ErrorsGeneric.MessageError(e);
            }
        }
    }
}
