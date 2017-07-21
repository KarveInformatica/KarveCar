using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Prism.Unity;
using System.Windows;
using KarveCar.View;

namespace KarveCar
{
    class Bootstrapper : UnityBootstrapper
        {
            protected override DependencyObject CreateShell()
            {
                return Container.Resolve<MainWindow>();
            }

            protected override void InitializeShell()
            {
                Application.Current.MainWindow.Show();
            }
        }
    
}
