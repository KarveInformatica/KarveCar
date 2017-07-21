using System.Windows;
namespace KarveCar
{
    /// <summary>
    ///  This starts the bootstrapper and so on.
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var bootstrapper = new Bootstrapper();
            bootstrapper.Run();
        }
    }
}
