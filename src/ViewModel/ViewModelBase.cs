using System.Globalization;
using System.Threading;
using System.Windows.Input;

using KarveCar.Commands.Generic;
using Prism.Mvvm;

namespace KarveCar.ViewModel
{
        public class ViewModelBase : BindableBase
        {

            private SetLanguagesCommand setlanguagescommand;

            public ViewModelBase()
            {
               // this.setlanguagescommand = new SetLanguagesCommand(this);
            }

            public ICommand SetLanguagesCommand
            {
                get
                {
                    return setlanguagescommand;
                }
            }

            /// <summary>
            /// Cambia el idioma según el param recibido del xaml, y guardamos el idioma en app.config
            /// </summary>
            /// <param name="parameter"></param>
            public void SetLanguages(object parameter)
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(parameter.ToString());
               // ChangeLanguageHelper.ChangeCulture(Thread.CurrentThread.CurrentUICulture);
               // ChangeLanguageHelper.SetLanguage(parameter.ToString()); 
            }   
            
    }
}
