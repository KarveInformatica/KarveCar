using System;
using System.ComponentModel;
using System.Deployment.Application;
using System.Linq.Expressions;
using System.Timers;
using System.Windows.Forms;
using MultiEventCommand.Classes;
using MultiEventCommand.ViewModels;
using Timer = System.Timers.Timer;

namespace MultiEventCommand.Views
{
    
    /// <summary>
    /// Interaction logic for SplasScreen.xaml
    /// </summary>
    public partial class SplashScreen:INotifyPropertyChanged
    {
        private readonly Timer _timer = new Timer();
        private int _counter;
        private const int Max = 2000;

       
        private double _progressBarValue;

        public double ProgressBarValue
        {
            get { return _progressBarValue; }
            set
            {
                _progressBarValue = value;
                NotifyPropertyChanged(this, o => o.ProgressBarValue);
            }
        }

        protected void NotifyPropertyChanged<T, TP>(T source, Expression<Func<T, TP>> pe)
        {
            PropertyChanged.Raise(source, pe);
        }

        readonly BackgroundWorker _bg = new BackgroundWorker();
        public SplashScreen()
        {
            DataContext = this;
            InitializeComponent();
            
            _bg.DoWork += BgDoWork;
            _bg.RunWorkerCompleted += BgRunWorkerCompleted;
            _timer.Interval = 20;
            _timer.Elapsed += TimerElapsed;
            _timer.Disposed += TimerDisposed;
            _timer.Enabled = true;
            _timer.Start();
        }

        void TimerDisposed(object sender, EventArgs e)
        {

            Dispatcher.BeginInvoke(new Action(() => _bg.RunWorkerAsync()));
        }

        void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            TryCatch.BeginTryCatch(()=>
                                       {
                                           
                                          _counter= _counter + 20;
                                           ProgressBarValue = (double)_counter / Max * 100;
                                           if (_counter != Max) return;
                                           _timer.Stop();
                                           _timer.Dispose();
                                           
                                       }
                );
        }

        private void BgRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var dashboard = new Dashboard();
            dashboard.Show();
            Close();
            
        }

        void BgDoWork(object sender, DoWorkEventArgs e)
        {
           
        }

        private void WindowLoaded(object sender, System.Windows.RoutedEventArgs e)
        {
            TryCatch.BeginTryCatch(() =>
            {

                if (ApplicationDeployment.IsNetworkDeployed)
                    txtVersion.Text = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
                else
                  txtVersion.Text =  Application.ProductVersion;
               
            }
            );
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
