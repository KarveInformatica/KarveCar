using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;
using Prism.Commands;
using Prism.Mvvm;

namespace KarveControlsTest
{
    /// <summary>
    /// Test ViewModel.
    /// </summary>
    public class ClientData
    {
        public string Zip { get; set; }
    }
    /// <summary>
    ///  ClientDataView.
    /// </summary>
    public class ClientDataView
    {
        public string Zip { get; set; }
        public string City { get; set; }
    }
    public class ViewModel: BindableBase
    {
        private ObservableCollection<ClientData> _cData = new ObservableCollection<ClientData>()
        {
            new ClientData()
            {
                Zip = "08904"
            },
            new ClientData()
            {
                Zip = "08900"
            },
            new ClientData()
            {
                Zip = "08800"
            }
        };

        private ObservableCollection<ClientDataView> _cDataView = new ObservableCollection<ClientDataView>()
        {
            new ClientDataView()
            {
                Zip = "08904",
                City = "Barcelona"
            },
            new ClientDataView()
            {
                Zip = "08900",
                City = "Barcelona"
            },
            new ClientDataView()
            {
                Zip = "08800",
                City = "Barcelona"
            }
        };

        private ObservableCollection<ClientDataView> _dataView = new ObservableCollection<ClientDataView>();
        public ViewModel() : base()
        {
            ItemChangedCommand = new DelegateCommand<object>(OnItemChanged);
            MagnifierCommand = new DelegateCommand<object>(OnMagnifierEvent);
            SourceView = _cDataView;
        }
        private void OnItemChanged(object var)
        {
            MessageBox.Show("Damme che acabo esto");
        }
        private void OnMagnifierEvent(object magnifer)
        {
            SourceView = _cDataView;
        }
        /// <summary>
        ///  DataSource.
        /// </summary>
        public ObservableCollection<ClientData> DataSource
        {
            get { return _cData; }
            set { _cData = value; RaisePropertyChanged(); }             
        }
        /// <summary>
        ///  SourceView 
        /// </summary>
        public ObservableCollection<ClientDataView> SourceView
        {
            get { return _dataView; }
            set { _dataView = value; RaisePropertyChanged(); }
        }
        /// <summary>
        ///  Item changed command
        /// </summary>
        public ICommand ItemChangedCommand { set; get; }
        /// <summary>
        ///  Magnifier command.
        /// </summary>
        public ICommand MagnifierCommand { set; get; }
    }
}