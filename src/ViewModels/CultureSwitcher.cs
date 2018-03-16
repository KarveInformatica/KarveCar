using System.Globalization;
using System.Threading;
using System.Windows.Data;
using System.Windows.Input;
using KarveCommon.Generic;
using KarveCommon.Services;
using KarveLocale;

namespace KarveCar.ViewModels
{
    /// <summary>
    ///  This is view model has the single responsability of switching the culture.
    /// </summary>
    public class CultureSwitcher
    {
        /// <summary>
        ///  Resources 
        /// </summary>
        private KarveLocale.Properties.Resources _resources;

        /// <summary>
        ///  Configuration service
        /// </summary>
        private readonly IConfigurationService _configurationService;

        private readonly IEventManager _eventManager;
        /// <summary>
        ///  Data object provider.
        /// </summary>
        private readonly ObjectDataProvider _objectDataProvider = new ObjectDataProvider();

        /// <summary>
        ///  Constructor for the configuration service.
        /// </summary>
        /// <param name="configurationService"></param>
        public CultureSwitcher(IConfigurationService configurationService, IEventManager eventManager)
        {
            _configurationService = configurationService;
            _eventManager = eventManager;
        }

        /// <summary>
        /// Command for changing the language
        /// </summary>
        public ICommand ChangeLanguageCommand { get; set; }

        /// <summary>
        ///  This is a resource in Karve
        /// </summary>
        public KarveLocale.Properties.Resources Resources
        {
            get => _resources; 
            set => _resources = value;
        }

        /// <summary>
        ///  Culture switcher. This switches the view model culture 
        ///  from a view model to another one. 
        /// </summary>
        public CultureSwitcher() : base()
        {
          
        }

        /// <summary>
        /// This command switches the culture of the language.
        /// </summary>
        /// <param name="parameter">Locale string</param>
        private void OnChangeCommand(object parameter)
        {
            
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(parameter.ToString());
            Enumerations.ResourceSource source =
                _configurationService.GetUserSettings().UserSettingsLoader.GetLocaleType();
            _resources = LocaleResourceFactory.GetLanguageLocale(Thread.CurrentThread.CurrentUICulture, source);
            // The toolbar shall be informed of a culture switcher
            DataPayLoad payLoad = new DataPayLoad();
            payLoad.PayloadType = DataPayLoad.Type.CultureChange;
            _eventManager.NotifyObserver(payLoad);
        }

        /// <summary>
        /// Devuelve el ObjectDataProvider en uso. TODO: see who is using this,
        /// </summary>
        public ObjectDataProvider ObjectDataProvider
        {
            get { return _objectDataProvider; }

        }
        /// <summary>
        ///  Execute the culture part
        /// </summary>
        /// <param name="param">Parameter to change</param>
        public void Execute(object param)
        {
            OnChangeCommand(param);
        }

    /// <summary>
        /// Cambia la cultura aplicada a los recursos y refresca la propiedad ResourceProvider
        /// </summary>
        /// <param name="culture"></param>
        public static void ChangeCulture(CultureInfo culture)
        {
            KarveLocale.Properties.Resources.Culture = culture;
           
        }
    }
}