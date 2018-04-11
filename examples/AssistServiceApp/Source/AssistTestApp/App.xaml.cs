using System.Windows;

namespace AssistTestApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        Bootstrapper bootstrapper;
        protected override void OnStartup(StartupEventArgs e)
        {
            //localization.

            base.OnStartup(e);
            bootstrapper = new Bootstrapper();
            bootstrapper.Run();
        }
        
    }
}
