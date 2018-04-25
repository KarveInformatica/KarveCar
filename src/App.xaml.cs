using System.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using System.Windows;
namespace KarveCar
{
    /// <summary>
    ///  This starts the bootstrapper and so on.
    /// </summary>
    public partial class App : Application
    {
      Boot.Bootstrapper bootstrapper;

        protected override void OnStartup(StartupEventArgs e)
        {
            //localization.
            string culture = ConfigurationManager.AppSettings["Culture"];
            if (!string.IsNullOrEmpty(culture))
            {
                CultureInfo ci = new CultureInfo(culture);
                // Force application to work with $ regardless of culture
                // Demonstrates customization of culture for app (optional)
                //  ci.NumberFormat.CurrencySymbol = "$";
                Thread.CurrentThread.CurrentCulture = ci;
                Thread.CurrentThread.CurrentUICulture = ci;

            }
            else
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-ES");
            }
            // debugging binding
            PresentationTraceSources.Refresh();
            PresentationTraceSources.DataBindingSource.Listeners.Add(new ConsoleTraceListener());
                //  PresentationTraceSources.DataBindingSource.Listeners.Add(new DebugTraceListener());
            PresentationTraceSources.DataBindingSource.Switch.Level = SourceLevels.Warning | SourceLevels.Error | SourceLevels.Critical;

            base.OnStartup(e);
            bootstrapper = new Boot.Bootstrapper();
            bootstrapper.Run();
        }


    }
}
