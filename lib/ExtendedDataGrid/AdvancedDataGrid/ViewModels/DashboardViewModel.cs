using System;
using System.Diagnostics;
using MultiEventCommandBinder;

//using AttachedCommands.ACB;

namespace MultiEventCommand.ViewModels
{
    public class DashboardViewModel : ViewModelBase
    {
        #region Members

        private RelayCommand _codeplexCommand;

        #endregion

        #region Commands



        public RelayCommand CodePlexCommand
        {
            get { return _codeplexCommand ?? (_codeplexCommand = new RelayCommand((Action<object>) CodePlexCommandHandler)); }
            set { _codeplexCommand = value; }
        }

       



        #endregion

        #region Handlers

        private void CodePlexCommandHandler(object obj)
        {
            Process.Start("http://columnchooser.codeplex.com/");
        }

        #endregion
    }
}
