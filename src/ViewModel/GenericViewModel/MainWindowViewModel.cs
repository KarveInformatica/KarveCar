using KarveCar.Commands.Generic;
using KarveCar.Logic.Generic;
using KarveCar.Utility;
using System.Globalization;
using System.Threading;
using System.Windows.Input;
using KarveCommon.Generic;
using KarveCommon.Services;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Mvvm;

namespace KarveCar.ViewModel.GenericViewModel
{
    public class MainWindowViewModel : BindableBase
    {
        private DelegateCommand<object> _setLanguagesCommand;
        private IUnityContainer _container;
        private string _title = "KarveWinNG 0.1";
        private DelegateCommand _closeWindowCommand;

        public MainWindowViewModel(IUnityContainer container)
        {
            this._setLanguagesCommand = new DelegateCommand<object>(SetLanguages);
            this._closeWindowCommand = new DelegateCommand(CloseWindow);
            this._container = container;
            
        }
        public string Title
        {
            get { return _title; }
        }

        public ICommand CloseWindowCommand
        {
            get
            {
                return _closeWindowCommand;
            }
            set
            {
               _closeWindowCommand = (DelegateCommand) value;
            }


        }
        public ICommand SetLanguagesCommand
        {
            get
            {
                return _setLanguagesCommand;
            }
        }

        private void CloseWindow()
        {
            Logic.Generic.CloseWindowLogic.CloseWindowFromCommand();
        }
        private IConfigurationService ConfigurationService
        {
            get { return _container.Resolve<IConfigurationService>(); }    
        }
        /// <summary>
        /// Cambia el idioma según el param recibido del xaml, y guardamos el idioma en app.config
        /// </summary>
        /// <param name="parameter"></param>
        public void SetLanguages(object parameter)
        {
            //Cambia el idioma según el param recibido del xaml
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(parameter.ToString());
            ChangeLanguageLogic.ChangeCulture(Thread.CurrentThread.CurrentUICulture);

            // Se guarda el idioma según el param recibido del xaml en app.config
            UserAndDefaultConfig.SetCurrentUserLanguage("Language", parameter.ToString());
        }
    }
}
