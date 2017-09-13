using System.Windows;
namespace KarveCar
{
    /// <summary>
    ///  This starts the bootstrapper and so on.
    /// </summary>
    public partial class App : Application
    {
        Bootstrapper bootstrapper;
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            bootstrapper = new Bootstrapper();
            bootstrapper.Run();
        }
    }
}
